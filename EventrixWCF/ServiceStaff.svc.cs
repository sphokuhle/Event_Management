using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using EventrixWCF.Users;
using Eventrix_Client.Model;

namespace EventrixWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceStaff" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServiceStaff.svc or ServiceStaff.svc.cs at the Solution Explorer and start debugging.
    public class ServiceStaff : IServiceStaff
    {

        
        public List<StaffModel> findallstaff()
        {
            using (EventrixDBDataContext mde = new EventrixDBDataContext())
            {
                try
                {
                    return mde.Staffs.Select(_staff => new StaffModel
                    {

                        ID = _staff.StaffId,
                        NAME = _staff.Name,
                        Occupation = _staff.Occupation,
                        PASS = _staff.Password,
                        EMAIL = _staff.Email,
                            EventID = Convert.ToInt32(_staff.eventid)
                    }).ToList();
                }
                catch
                {
                    return null;
                }
            };
        }

        //public List<EventStaff> findallstaffbyEventID(string id)
        //{
        //    using (EventrixDBDataContext mde = new EventrixDBDataContext())
        //    {
        //        try
        //        {
        //            int _id = Convert.ToInt32(id);
        //            return mde.Staffs.Where(pe => pe.eventid == _id).Select(pe => new EventStaff
        //            {
        //                ID = pe.StaffId,
        //                NAME = pe.Name,
        //                EMAIL = pe.Email,
        //                PASS = pe.Password,
        //                Occupation = pe.Occupation,
        //                EventID = pe.eventid
        //            }).ToList();
        //        }
        //        catch
        //        {
        //            return null;
        //        }
        //    };
        //}
        public List<StaffModel> findallstaffbyEventID(string id)
        {
            using (EventrixDBDataContext mde = new EventrixDBDataContext())
            {
                List<StaffModel> items = new List<StaffModel>();
                List<Staff> myStaff = new List<Staff>();
                StaffModel _st = new StaffModel();
                try
                {
                    int _id = Convert.ToInt32(id);
                    var query = (from add in mde.Staffs where add.eventid.Equals(Convert.ToInt32(id)) select add);
                    if(query.Count() == 0) //return all values
                    {
                        items = findallstaff();
                        return items;
                    }else
                    {
                        return mde.Staffs.Where(pe => pe.eventid == _id).Select(pe => new StaffModel
                        {
                            ID = pe.StaffId,
                            NAME = pe.Name,
                            EMAIL = pe.Email,
                            PASS = pe.Password,
                            Occupation = pe.Occupation,
                            EventID = pe.eventid
                        }).ToList();
                    }

                }
                catch
                {
                    return null;
                }
            };
        }

        public List<StaffModel> getAllStaffbyID(string id)
        {
            int _id = Convert.ToInt32(id);
            try
            {
                using (EventrixDBDataContext db = new EventrixDBDataContext())
                {
                    return db.Staffs.Where(ev => ev.eventid == _id).Select(pe => new StaffModel
                    {
                        ID = pe.StaffId,
                        NAME = pe.Name,
                        EMAIL = pe.Email,
                        PASS = pe.Password,
                        Occupation = pe.Occupation,
                        EventID = pe.eventid,
                    }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public EventStaff findStaffbyID(string id)
        {
            try
            {
                using (EventrixDBDataContext mde = new EventrixDBDataContext())
                {
                    int _id = Convert.ToInt32(id);
                    return mde.Staffs.Where(staff => staff.StaffId == _id).Select(staff => new EventStaff
                    {
                        ID = staff.StaffId,
                        NAME = staff.Name,
                        EMAIL = staff.Email,
                        PASS = staff.Password,
                        Occupation = staff.Occupation,
                           EventID = Convert.ToInt32(staff.eventid)
                    }).First();
                };
            }
            catch
            {
                return null;
            }
       
        }

        public EventStaff staffLogin(string email)
        {
            using (EventrixDBDataContext mde = new EventrixDBDataContext())
            {
                try
                {
                    return mde.Staffs.Where(staff => staff.Email == email).Select(staff => new EventStaff
                    {
                        ID = staff.StaffId,
                        NAME = staff.Name,
                        EMAIL = staff.Email,
                        PASS = staff.Password,
                        Occupation = staff.Occupation,
                          EventID = Convert.ToInt32(staff.eventid)
                    }).First();
                }
                catch
                {
                    return null;
                }
            };
        }

        public EventStaff updateSTaff(string id, EventStaff _event)
        {
            using (EventrixDBDataContext db = new EventrixDBDataContext())
            {
                try
                {
                    var query = (from add in db.Staffs where add.Email.Equals(_event.EMAIL) select add);
                    if (query.Count() == 1)
                    {
                        Staff res = query.Single();
                      //  res.StaffId = _event.ID;
                        res.Name = _event.NAME;
                        res.Occupation = _event.Occupation;
                       // res.Email = _event.EMAIL;
                        res.Password = _event.PASS;
                      //  res.eventid = _event.EventID;
                        db.SubmitChanges();
                        _event = new EventStaff()
                        {
                            ID = res.StaffId,
                            NAME = res.Name,
                            Occupation = res.Occupation,
                            EMAIL = res.Email,
                            PASS = res.Password,
                            EventID = res.eventid,
                        };
                        return _event;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public bool createStaff(StaffModel _staff)
        {
            using (EventrixDBDataContext dbd = new EventrixDBDataContext())
            {
                try
                {
                    int MailChecker = (from eh in dbd.Staffs where eh.Email.Equals(_staff.EMAIL) && eh.eventid == _staff.EventID select eh).Count();
                    if (MailChecker == 0)
                    {
                        int _id = Convert.ToInt32(_staff.EventID);
                        Staff staff = new Staff();
                        staff.Name = _staff.NAME;
                        staff.Email = _staff.EMAIL;
                        staff.Occupation = _staff.Occupation;
                        staff.Password = _staff.PASS;
                        staff.eventid = _id;
                        dbd.Staffs.InsertOnSubmit(staff);
                        dbd.SubmitChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception) 
                {
                    return true;
                }
            };
        }


        public bool deleteStaff(EventStaff _staff)
        {
            int _id = Convert.ToInt32(_staff.EventID);
            try
            {
                using (EventrixDBDataContext db = new EventrixDBDataContext())
                {
                    List<Staff> toDelete = (from dl in db.Staffs where dl.eventid == _id select dl).ToList();
                    if (toDelete == null)
                    {
                        return false;
                    }
                    else
                    {
                        db.Staffs.DeleteAllOnSubmit(toDelete);
                        db.SubmitChanges();
                        return true;
                    }
                };
            }
            catch (Exception)
            {
                return false;
            }
        }

        public string deleteStaffByEventID(string eventID)
        {
            int _id = Convert.ToInt32(eventID);
            try
            {
                using (EventrixDBDataContext db = new EventrixDBDataContext())
                {
                    List<Staff> toDelete = (from dl in db.Staffs where dl.eventid == _id select dl).ToList();
                    if (toDelete == null)
                    {
                        return "success: staff not found";
                    }
                    else
                    {
                        db.Staffs.DeleteAllOnSubmit(toDelete);
                        db.SubmitChanges();
                        return "success: staff deleted";
                    }
                };
            }
            catch (Exception)
            {
                return "failed";
            }
        }
    }
}
