using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Eventrix_Client.Model.ClientDefinition;
using Eventrix_Client.Model;

namespace EventrixWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ScanningService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ScanningService.svc or ScanningService.svc.cs at the Solution Explorer and start debugging.
    public class ScanningService : IScanningService
    {
        public bool CheckInGuest(string QR_ID, string S_ID)
        {
            int s_ID = Convert.ToInt32(S_ID);
            int _id = Convert.ToInt32(QR_ID);
            using (EventrixDBDataContext db = new EventrixDBDataContext())
            {
                try
                {
                    var query = (from qr in db.Guest_QRCodes where qr.QR_Id.Equals(QR_ID) select qr).First();
                    if(query != null)
                    {
                        Guest_QRCode data = query;
                        data.Checked_In = 1;
                        data.EntranceTime = DateTime.Now;
                        db.SubmitChanges();
                        UpdateStaffNumScans(s_ID);
                        return true;
                    }else
                    {
                        return false;
                    }
                    
                }catch(Exception)
                {
                    return false;
                }
            };
        }

        public bool UpdateStaffNumScans(int staffID)
        {
            using (EventrixDBDataContext db = new EventrixDBDataContext())
            {
                try
                {
                    var updateStaff = (from sl in db.Staffs where sl.StaffId.Equals(staffID) select sl).First();
                    updateStaff.NumScans += 1;
                    db.SubmitChanges();
                    return true;
                }
                catch(Exception)
                {
                    return false;
                }
            }
        }
        public List<EventModel> GetEventByProductID(string G_ID)
        {
            throw new NotImplementedException();
        }
        //3228,3054,5
        //100,2047,15
        public string PurchaseProduct(string QR_ID, string ProductID, string quantity,string str_StaffID)
        {
            int staffID = Convert.ToInt32(str_StaffID);
            int prodQuantity = Convert.ToInt32(quantity);
            using (EventrixDBDataContext db = new EventrixDBDataContext())
            {
                try
                {
                    int _id = Convert.ToInt32(QR_ID);
                    var QRquery = (from qr in db.Guest_QRCodes
                                 where qr.QR_Id.Equals(_id)
                                 select  qr).Single();
                    int QRCodeCredits = Convert.ToInt32(QRquery.Credit);
                    if(QRCodeCredits <= 0)
                    {
                        return "fail: insufficient credits";
                    }
                    //Get Product Credit
                    int ID = Convert.ToInt32(ProductID);
                    var ProdQuery = (from prod in db.Products where prod.ProductID.Equals(ID) select prod).First();
                    int Quantity = Convert.ToInt32(ProdQuery.P_Quantity_Remaining);
                    int ProdPrice = Convert.ToInt32(ProdQuery.P_Price);
                    if (Quantity <= 0)
                    {
                        return "fail: sold out";
                    }else
                    {
                        if(QRCodeCredits >= ProdPrice)
                        {
                            //Deduct
                            int Cost = Convert.ToInt32(QRCodeCredits - ProdPrice);
                            //Update Product Quantity
                            ProdQuery.P_Quantity_Remaining = ProdQuery.P_Quantity_Remaining - prodQuantity;
                            db.SubmitChanges();
                            //Update Guest Credits
                            QRquery.Credit = QRCodeCredits - ProdPrice * prodQuantity;
                            db.SubmitChanges();
                            UpdateStaffNumScans(staffID);
                            return "success product purchased";
                        }
                        else
                        {
                            return "fail: Insufficient credits";
                        }
                    }
                }
                catch(Exception)
                {
                    return "fail: catched";
                }
            };
        }

        //scanning QR Code and changing the check in status
        public bool updateQRCode(QRCodeImage image)
        {
            try
            {
                using (EventrixDBDataContext db = new EventrixDBDataContext())
                {
                    Guest_QRCode toInsert = (from st in db.Guest_QRCodes where st.QR_Id.Equals(image.QRCodeID) select st).First();
                    toInsert.Checked_In = image.Checked_in;
                    db.SubmitChanges();
                    return true;
                };
            }catch(Exception)
            {
                return false;
            }
        }

        public bool updateTicket(EventTicket _ticket)
        {
            try
            {
                using (EventrixDBDataContext dbd = new EventrixDBDataContext())
                {
                    Ticket_Template toInsert = (from st in dbd.Ticket_Templates where st.eventid.Equals(_ticket._EventID) select st).First();
                    toInsert.Type = _ticket._Type;
                    toInsert.Credit = _ticket._Credit;
                    toInsert.Price = _ticket._Price;
                    toInsert.RefundPolicy = _ticket._Refund;
                    toInsert.StartDate = _ticket._StartDate;
                    toInsert.EndDate = _ticket._EndDate;
                    toInsert.eventid = _ticket._EventID;
                    //    toInsert.G_ID = _ticket._GuestID;
                    dbd.SubmitChanges();
                    return true;
                };
            }catch(Exception)
            {

                return false;
            }
        }
    }
}
