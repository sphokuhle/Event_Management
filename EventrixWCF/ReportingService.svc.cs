using Eventrix_Client.Model.ClientDefinition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Eventrix_Client.Model;
using System.Globalization;

namespace EventrixWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ReportingService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ReportingService.svc or ReportingService.svc.cs at the Solution Explorer and start debugging.
    public class ReportingService : IReportingService
    {

        //return number of tickets remaining for each ticket type //doughnut
        public List<int> GetTicketCountPerEvent(string EventID)
        {
            int _id = Convert.ToInt32(EventID);
            List<int> data = null;
            try
            {
                data = new List<int>();
                using (EventrixDBDataContext db = new EventrixDBDataContext())
                {
                    MAIN_EVENT QueryOne = (from count in db.MAIN_EVENTs where count.E_ID == _id select count).First();
                    if(QueryOne != null)
                    {
                        data.Add(Convert.ToInt32(QueryOne.E_EB_Ticket));
                        data.Add(Convert.ToInt32(QueryOne.E_RG_Ticket));
                        data.Add(Convert.ToInt32(QueryOne.E_VIP_Ticket));
                        data.Add(Convert.ToInt32(QueryOne.E_VVIP_Ticket));
                    }
                    return data;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<EventModel> getAllEventsByHostID(string HostID)
        {
                int _id = Convert.ToInt32(HostID);
                try
                {
                    using (EventrixDBDataContext db = new EventrixDBDataContext())
                    {
                    return db.MAIN_EVENTs.Where(ev => ev.EH_ID == _id).Select(ev => new EventModel
                    {
                        Name = ev.E_Name,
                        EventID = ev.E_ID,
                        Desc = ev.E_Desc,
                        Type = ev.E_Type,
                        HostID = Convert.ToInt32(ev.EH_ID),
                        //  EventAddress = ev.AD_Id,
                        EB_Quantity = Convert.ToInt32(ev.E_EB_Ticket),
                        Reg_Quantity = Convert.ToInt32(ev.E_RG_Ticket),
                        VIP_Quantity = Convert.ToInt32(ev.E_VIP_Ticket),
                        VVIP_Quantity = Convert.ToInt32(ev.E_VVIP_Ticket),
                        Product_Quantity = Convert.ToInt32(ev.E_NumProduct),
                        sDate = Convert.ToString(ev.E_StartDate),
                        eDate = Convert.ToString(ev.E_EndDate),
                        EventView = Convert.ToInt32(ev.NumViews),
                        }).ToList();
                    }
                }
                catch (Exception)
                {
                    return null;
                }
        }

        public List<StaffModel> findallstaffbyHostID(string id)
        {
            int _id = Convert.ToInt32(id);
            List<StaffModel> staffList = new List<StaffModel>();
            using (EventrixDBDataContext mde = new EventrixDBDataContext())
            {
                try
                {
                    var staffquery = (from events in mde.MAIN_EVENTs where events.EH_ID == _id
                                      join staff in mde.Staffs on events.E_ID equals staff.eventid select staff).Count();
                    if(staffquery != 0)
                    {
                        var foundStaff = from events in mde.MAIN_EVENTs
                                          where events.EH_ID == _id
                                          join staff in mde.Staffs on events.E_ID equals staff.eventid
                                          select new StaffModel
                                          {
                                              ID = staff.StaffId,
                                              NAME = staff.Name,
                                              Occupation = staff.Occupation,
                                              EMAIL = staff.Email,
                                              EventID = staff.eventid,
                                          };
                        foreach(StaffModel _staff in foundStaff)
                        {
                            staffList.Add(_staff);
                        }
                        return staffList;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch
                {
                    return null;
                }
            };
        }

        public List<ProductInfo> findallProductByHostID(string id)
        {
            int _id = Convert.ToInt32(id);
            List<ProductInfo> ProductList = new List<ProductInfo>();
            using (EventrixDBDataContext mde = new EventrixDBDataContext())
            {
                try
                {
                    var productquery = (from events in mde.MAIN_EVENTs
                                      where events.EH_ID == _id
                                      join prod in mde.Products on events.E_ID equals prod.eventid
                                      select prod).Count();
                    if (productquery != 0)
                    {
                        var foundProduct = from events in mde.MAIN_EVENTs
                                         where events.EH_ID == _id
                                         join prod in mde.Products on events.E_ID equals prod.eventid
                                         select new ProductInfo
                                         {
                                             ID = prod.ProductID,
                                             Name = prod.P_Name,
                                             Price = Convert.ToInt32(prod.P_Price),
                                             Quantity = Convert.ToInt32(prod.P_Quantity),
                                             EventID = Convert.ToInt32(prod.eventid),
                                         };
                        foreach (ProductInfo _product in foundProduct)
                        {
                            ProductList.Add(_product);
                        }
                        return ProductList;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch
                {
                    return null;
                }
            };
        }

        public List<int> GetNumberOfProductSold(string eventID)
        {
            throw new NotImplementedException();
        }


        public List<int> GetNumberOfShares(string eventID)
        {
            throw new NotImplementedException();
        }

        public List<int> GetNumberOfCheckedGuest(string eventID)
        {
            int _id = Convert.ToInt32(eventID);
            List<int> data = new List<int>();
            using (EventrixDBDataContext db = new EventrixDBDataContext())
            {
                try
                {
                    //Get checked in QRCode
                    //GetNumberOfCheckedGuest/2035
                    var checkedIn = (from _ticket in db.Ticket_Templates
                                 where _ticket.eventid == _id
                                 join BT in db.Guest_Tickets on _ticket.TicketID equals BT.ticket_temp_id
                                 join QRCode in db.Guest_QRCodes on BT.ticket_Id equals QRCode.ticket_Id where QRCode.Checked_In.Equals(1)
                                 select QRCode).Count();
                    //Get QRCode  not checked in
                    var NotcheckedIn = (from _ticket in db.Ticket_Templates
                                 where _ticket.eventid == _id
                                 join BT in db.Guest_Tickets on _ticket.TicketID equals BT.ticket_temp_id
                                 join QRCode in db.Guest_QRCodes on BT.ticket_Id equals QRCode.ticket_Id
                                 where QRCode.Checked_In.Equals(0)
                                 select QRCode).Count();

                        data.Add(checkedIn);
                        data.Add(NotcheckedIn);
                        return data;
                    
                }
                catch (Exception)
                {
                    return null;
                }
            };
        }

        //Get list of products sold or not for the current event
        //GetProductStatus/1022
        public List<EventProduct> GetProductStatus(string eventID)
        {
            List<EventProduct> data = new List<EventProduct>();
            int _id = Convert.ToInt32(eventID);
            using (EventrixDBDataContext db = new EventrixDBDataContext())
            {
                try
                {
                    var query = (from product in db.Products where product.eventid.Equals(_id) select product).Count();
                    if(query != 0)
                    {
                        var prdQuery = from product in db.Products
                                       where product.eventid.Equals(_id)
                                       select new EventProduct
                                       {
                                           _ID = product.ProductID,
                                           _Name = product.P_Name,
                                           _Desc = product.P_Description,
                                           _Quantity = Convert.ToInt32(product.P_Quantity),
                                           _Price = Convert.ToInt32(product.P_Price),
                                           EventID = Convert.ToInt32(product.eventid),
                                           ProdRemaining = Convert.ToInt32(product.P_Quantity_Remaining),
                                       };
                        foreach(EventProduct prod in prdQuery)
                        {
                            data.Add(prod);
                        }
                        return data;
                    }else
                    {
                        return null;
                    }
                }
                catch (Exception)
                {
                    return null;
                }
            };
        }

        /*
         * 5. Track most used work-stations
	     *Radar graph...
	     *Number of transactions per procurement
         * Test using: /GetMostUsedWorkstation/1022
         * */
        public List<StaffModel> GetMostUsedWorkstation(string eventID)
        {
            int _id = Convert.ToInt32(eventID);
            List<StaffModel> staffList = new List<StaffModel>();
            using (EventrixDBDataContext mde = new EventrixDBDataContext())
            {
               
                    var staffquery = (from staff in mde.Staffs
                                      where staff.eventid == _id && staff.Occupation.ToLower().Contains("procurement")
                                      select staff).Count();
                    if (staffquery != 0)
                    {
                    var query = (from st in mde.Staffs
                                 where st.eventid.Equals(_id) && st.Occupation.ToLower().Contains("procurement")
                                 select new StaffModel
                                 {
                                     ID = st.StaffId,
                                     NAME = st.Name,
                                     Occupation = st.Occupation,
                                     NumScans = Convert.ToInt32(st.NumScans),
                                 }).ToList();
                        foreach (StaffModel _staff in query)
                        {
                            staffList.Add(_staff);
                        }
                        return staffList;
                    }
                    else
                    {
                        return null;
                    }
              
            };
        }

        //access_control
        /*
         *4. Track most checked in entrance
	     *Radar graph...Based on access control
	     *Numebr of transactions per access control
         * y-Axis : Number of scans
         * x-axis : Number of staff
         *  Test using: /GetMostCheckedinEntrance/1022
         * */
        public List<StaffModel> GetMostCheckedinEntrance(string eventID)
        {
            int _id = Convert.ToInt32(eventID);
            List<StaffModel> staffList = new List<StaffModel>();
            using (EventrixDBDataContext mde = new EventrixDBDataContext())
            {
                try
                {
                    var staffquery = (from staff in mde.Staffs
                                      where staff.eventid == _id && staff.Occupation.ToLower().Contains("access")
                                      select staff).Count();
                    
                    if (staffquery != 0)
                    {
                        var foundStaff = (from staff in mde.Staffs
                                          where staff.eventid == _id && staff.Occupation.ToLower().Contains("access")
                                          select new StaffModel {
                                              ID = staff.StaffId,
                                              NAME = staff.Name,
                                              Occupation = staff.Occupation,
                                              EMAIL = staff.Email,
                                              EventID = staff.eventid,
                                              NumScans = Convert.ToInt32(staff.NumScans),
                                              WorkStation = staff.WorkStation,
                                          }).ToList();
                        foreach (StaffModel _staff in foundStaff)
                        {
                            staffList.Add(_staff);
                        }
                        return staffList;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch
                {
                    return null;
                }
            };
        }


        /*Get Range between event start Date and Event end date
         * Then return the range in 4 hourd intervals
         * */
        //HourlyInterVals/2034
        public List<string> HourlyInterVals(string id)
        {
            List<string> data = new List<string>();
            int _id = Convert.ToInt32(id);
            try
            {
                using (EventrixDBDataContext db = new EventrixDBDataContext())
                {
                    var Query = (from _event in db.MAIN_EVENTs
                                 where _event.E_ID == _id
                                 select _event).Count();
                    DateTime startDate = DateTime.Now;
                    DateTime endDate = DateTime.Now;
                    if (Query != 0)
                    {
                        var EventQuery = (from _event in db.MAIN_EVENTs
                                          where _event.E_ID == _id
                                          select _event).First();
                        startDate = Convert.ToDateTime(EventQuery.E_StartDate);
                        endDate = Convert.ToDateTime(EventQuery.E_EndDate);
                        double hours = (endDate - startDate).TotalHours;
                       double Intervals = Math.Round(hours / 4, 1);
                        DateTime intertval1 = startDate.AddHours(Intervals);
                        DateTime intertval2 = intertval1.AddHours(Intervals);
                        DateTime intertval3 = intertval2.AddHours(Intervals);

                        //data.Add(hours);
                        //data.Add(Intervals);
                        //data.Add(0);
                        //data.Add(0);
                        data.Add(startDate.Hour.ToString());
                        data.Add(intertval1.Hour.ToString());
                        data.Add(intertval2.Hour.ToString());
                        data.Add(intertval3.Hour.ToString());
                        data.Add(endDate.Hour.ToString());

                        //data.Add(0);
                        //data.Add(0);

                        //data.Add(startDate.Hour);
                        //data.Add(endDate.Hour);
                        return data;
                    }
                    else
                    {
                        data.Add("");
                        return data;
                    }
                };
            }
            catch (Exception)
            {
                data.Add("");
                return data;
            }
        }

        public List<DateTime> findEventHours(string id)
        {
            List<DateTime> data = new List<DateTime>();
            int _id = Convert.ToInt32(id);
            try
            {
                using (EventrixDBDataContext db = new EventrixDBDataContext())
                {
                    var Query = (from _event in db.MAIN_EVENTs
                                      where _event.E_ID == _id
                                      select _event).Count();
                    DateTime startDate = DateTime.Now;
                    DateTime endDate = DateTime.Now;
                    if(Query != 0)
                    {
                        var EventQuery = (from _event in db.MAIN_EVENTs
                                          where _event.E_ID == _id
                                          select _event).First();
                        startDate = Convert.ToDateTime(EventQuery.E_StartDate);
                        endDate = Convert.ToDateTime(EventQuery.E_EndDate);
                        TimeSpan diff = endDate - startDate;
                        double hours = diff.TotalHours;
                        double rounded = (hours / 4);
                      //  int hourlyInterval = (int)Math.Round(rounded);
                        DateTime intertval1 = startDate.AddHours(rounded);
                        DateTime intertval2 = intertval1.AddHours(rounded);
                        DateTime intertval3 = intertval2.AddHours(rounded);
                        data.Add(startDate);
                        data.Add(intertval1);
                        data.Add(intertval2);
                        data.Add(intertval3);
                        data.Add(endDate);
                        return data;
                    }
                    else
                    {
                        return null;
                    }
                };
            }catch(Exception)
            {
                return null;
            }
        }

        public List<int> TicketInIntervals(string eventID, string myInerval)
        {
            List<DateTime> TimeIntervals = new List<DateTime>();
            TimeIntervals = findEventHours(eventID);
            DateTime StartInterval = DateTime.Now;
            DateTime EndInterval = DateTime.Now;
            //Check interval needed
            if (myInerval.ToLower().Equals("one")) { StartInterval = TimeIntervals[0]; EndInterval = TimeIntervals[1]; }
            if (myInerval.ToLower().Equals("two")) { StartInterval = TimeIntervals[1]; EndInterval = TimeIntervals[2]; }
            if (myInerval.ToLower().Equals("three")) { StartInterval = TimeIntervals[2]; EndInterval = TimeIntervals[3]; }
            if (myInerval.ToLower().Equals("four")) { StartInterval = TimeIntervals[3]; EndInterval = TimeIntervals[4]; }

            int _id = Convert.ToInt32(eventID); //get event ID
            List<int> data = new List<int>();
            int CheckedIncount = 0; //number of checked in ticket
            using (EventrixDBDataContext db = new EventrixDBDataContext())
            {
                try
                {
                    //Get checked in QRCode
                    //TicketInIntervalOne/2035
                    var checkedIn = (from _ticket in db.Ticket_Templates
                                     where _ticket.eventid == _id
                                     join BT in db.Guest_Tickets on _ticket.TicketID equals BT.ticket_temp_id
                                     join QRCode in db.Guest_QRCodes on BT.ticket_Id equals QRCode.ticket_Id
                                     where QRCode.Checked_In.Equals(1)
                                     select QRCode).Count();
                    if (checkedIn != 0)
                    {
                        var QRCodes = (from _ticket in db.Ticket_Templates
                                       where _ticket.eventid == _id
                                       join BT in db.Guest_Tickets on _ticket.TicketID equals BT.ticket_temp_id
                                       join QRCode in db.Guest_QRCodes on BT.ticket_Id equals QRCode.ticket_Id
                                       where QRCode.Checked_In.Equals(1)
                                       select QRCode).ToList();
                        DateTime qrcodeTime = new DateTime();
                        foreach (Guest_QRCode qrcodes in QRCodes)
                        {
                            qrcodeTime = Convert.ToDateTime(qrcodes.EntranceTime);
                            if (qrcodeTime >= StartInterval && qrcodeTime < EndInterval)
                            {
                                CheckedIncount++;
                            }
                        }
                        data.Add(CheckedIncount);
                    }else
                    {
                        data.Add(0);
                        data.Add(0);
                        return data;
                    }

                    //Get QRCode  not checked in
                    var NotcheckedIn = (from _ticket in db.Ticket_Templates
                                        where _ticket.eventid == _id
                                        join BT in db.Guest_Tickets on _ticket.TicketID equals BT.ticket_temp_id
                                        join QRCode in db.Guest_QRCodes on BT.ticket_Id equals QRCode.ticket_Id
                                        where QRCode.Checked_In.Equals(0)
                                        select QRCode).Count();
                    int notCheckedInCount = NotcheckedIn + checkedIn - CheckedIncount;
                    data.Add(notCheckedInCount);
                    return data;
                }
                catch (Exception)
                {
                    data.Add(0);
                    data.Add(0);
                    return data;
                }
            };
        }

        //Date of the most recent event view or share
        public string GetLatestView(string eventID, string Type)
        {
            int _id = Convert.ToInt32(eventID);
            List<string> ViewList = new List<string>();
            using (EventrixDBDataContext db = new EventrixDBDataContext())
            {
                try
                {
                    var lastPlayerControlCommand = db.EventViews
                                .Where(c => c.eventID == _id && c.Type.Equals(Type))
                                .OrderByDescending(t => t.ViewDate)
                                .FirstOrDefault();
                    string sDate = Convert.ToString(lastPlayerControlCommand.ViewDate);
                    return sDate;
                }
                catch(Exception)
                {
                    return null;
                }
            };
        }

        public List<GuestModel> RSVPGuest(string eventID, string Type)
        {
                EventService event_service = new EventService();
                List<GuestModel> items = new List<GuestModel>();
                int _id = Convert.ToInt32(eventID);
                using (EventrixDBDataContext db = new EventrixDBDataContext())
                {
                    try
                    {
                        var query = (from res in db.EventRSVPs where res.E_ID.Equals(eventID) && res.Status.Equals(Type)
                                     select new GuestModel
                                     {
                                         ID = res.Guest.G_ID,
                                         NAME = res.Guest.Name,
                                         SURNAME = res.Guest.Surname,
                                         EMAIL = res.Guest.Email,
                                     }).ToList();
                        return query;
                    }
                    catch (Exception)
                    {
                        return null;
                    }
                };
            
        }

        public List<int> RSVPCount(string eventID)
        {
                List<int> items = new List<int>();
                int _id = Convert.ToInt32(eventID);
                using (EventrixDBDataContext db = new EventrixDBDataContext())
                {
                    try
                    {
                    var intComing = (from confirmed in db.EventRSVPs where confirmed.E_ID.Equals(_id) &&
                                     confirmed.Status.ToLower().Equals("confirmed") select confirmed).Count();

                    var NotComing = (from declined in db.EventRSVPs where declined.E_ID.Equals(_id)
                                     && declined.Status.ToLower().Equals("declined") select declined).Count();
                    items.Add(intComing);
                    items.Add(NotComing);
                    return items;
                }
                    catch (Exception)
                    {
                        return null;
                    }
                };
           
        }
    }
}
