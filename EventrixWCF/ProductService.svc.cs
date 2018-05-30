using Eventrix_Client.Model.ClientDefinition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EventrixWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ProductService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ProductService.svc or ProductService.svc.cs at the Solution Explorer and start debugging.
    public class ProductService : IProductService
    {
        public string createProduct(EventProduct product)
        {
            try
            {
                using (EventrixDBDataContext dbd = new EventrixDBDataContext())
                {
                    int isAvail = (from eh in dbd.Products where eh.eventid.Equals(product.EventID) && eh.P_Name.Equals(product._Name) select eh).Count();
                    if (isAvail == 0)
                    {
                        Product _host = new Product()
                        {
                            P_Name = product._Name,
                            P_Description = product._Desc,
                            P_Quantity = product._Quantity,
                            P_Price = product._Price,
                            eventid = product.EventID,
                            P_Quantity_Remaining = product._Quantity,
                        };
                        dbd.Products.InsertOnSubmit(_host);
                        dbd.SubmitChanges();
                        return "success";
                    }
                    else //edit existing record
                    {
                        int _id = Convert.ToInt32(product._ID);
                        Product pro = dbd.Products.Single(p => p.eventid == product.EventID && p.P_Name.Equals(product._Name));
                        Product _createNew = new Product();
                        pro.P_Name = product._Name;
                        pro.P_Description = product._Desc;
                        pro.P_Quantity = product._Quantity;
                        pro.P_Price = product._Price;
                        pro.P_Quantity_Remaining = product._Quantity;
                        //    pro.eventid = _product.EventID;
                        //  mde.Products.InsertOnSubmit(_createNew);
                        dbd.SubmitChanges();
                        return "success";
                    }
                };
            }
            catch(Exception)
            {
                return "fail";
            }
        }

        public string deleteProductByID(string eventID)
        {
            int _id = Convert.ToInt32(eventID);
            try
            {
                using (EventrixDBDataContext db = new EventrixDBDataContext())
                {
                    List<Product> toDelete = (from dl in db.Products where dl.eventid == _id select dl).ToList();
                    if (toDelete == null)
                    {
                        return "success: Product Not Found";
                    }
                    else
                    {
                        db.Products.DeleteAllOnSubmit(toDelete);
                        db.SubmitChanges();
                        return "success";
                    }
                };
            }
            catch (Exception)
            {
                return "Failed";
            }
        }

        public List<EventProduct> EventProduct(string EventID)
        {
            int _id = Convert.ToInt32(EventID);
            using (EventrixDBDataContext mde = new EventrixDBDataContext())
            {
                try
                {
                    return mde.Products.Where(pe => pe.eventid == _id).Select(pe => new EventProduct
                    {
                        _ID = pe.ProductID,
                        _Name = pe.P_Name,
                        _Desc = pe.P_Description,
                        _Quantity = Convert.ToInt32(pe.P_Quantity),
                        _Price = Convert.ToInt32(pe.P_Price),
                        EventID = Convert.ToInt32(pe.eventid),
                        ProdRemaining = Convert.ToInt32(pe.P_Quantity_Remaining),
                    }).ToList();
                }
                catch
                {
                    return null;
                }
            };
        }

        public List<EventProduct> findallproduct()
        {
            using (EventrixDBDataContext mde = new EventrixDBDataContext())
            {
                try
                {
                    return mde.Products.Select(pe => new EventProduct
                    {
                        _ID = pe.ProductID,
                        _Name = pe.P_Name,
                        _Desc = pe.P_Description,
                        _Quantity = Convert.ToInt32(pe.P_Quantity),
                        _Price = Convert.ToInt32(pe.P_Price),
                        EventID = Convert.ToInt32(pe.eventid),
                    }).ToList();
                }
                catch
                {
                    return null;
                }
            };
        }

        public List<EventProduct> getProductByEventID(string EventID)
        {
            int _id = Convert.ToInt32(EventID);
            try
            {
                using (EventrixDBDataContext mde = new EventrixDBDataContext())
                {
                    return mde.Products.Where(pe => pe.eventid.Equals(_id)).Select(pe => new EventProduct
                    {
                        _ID = pe.ProductID,
                        _Name = pe.P_Name,
                        _Desc = pe.P_Description,
                        _Quantity = Convert.ToInt32(pe.P_Quantity),
                        _Price = Convert.ToInt32(pe.P_Price),
                        EventID = Convert.ToInt32(pe.eventid),
                        ProdRemaining = Convert.ToInt32(pe.P_Quantity_Remaining),
                    }).ToList();
                };
            }
            catch(Exception)
            {
                return null;
            }
        }

        public EventModel updateProduct(string id, EventModel _event)
        {
            throw new NotImplementedException();
        }
    }
}
