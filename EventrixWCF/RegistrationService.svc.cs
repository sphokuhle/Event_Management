using EventrixWCF.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web.Script.Serialization;

namespace EventrixWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RegistrationService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select RegistrationService.svc or RegistrationService.svc.cs at the Solution Explorer and start debugging.
    public class RegistrationService : IRegistrationService
    {
        public string InsertOTP(EventGuest guest, string ID)
        {

            HashPass hashedPass = new HashPass();
            string pass = HashPass.HashPassword(guest.PASS);
            using (EventrixDBDataContext db = new EventrixDBDataContext())
            {
                try
                {
                    int _id = Convert.ToInt32(ID);
                    var query = (from gst in db.Guests where gst.G_ID.Equals(_id) select gst).First();
                    Guest toUpdate = query;
                    toUpdate.Password = pass;
                    db.SubmitChanges();
                    return "success";
                }catch(Exception)
                {
                    return "fail";
                }
            };
        }

        public int RegisterGuest(EventGuest guest)
        {
            string reg = "";
            HashPass hashedPass = new HashPass();
            string pass = HashPass.HashPassword(guest.PASS);
            using (EventrixDBDataContext dbd = new EventrixDBDataContext())
            {
                try
                {
                    int MailChecker = (from gst in dbd.Guests where gst.Email.Equals(guest.EMAIL) select gst).Count();
                    if(MailChecker == 0)
                    {
                        Guest _guest = new Guest();
                        _guest.Name = guest.NAME;
                        _guest.Email = guest.EMAIL;
                        _guest.Surname = guest.SURNAME;
                        _guest.Type = guest.TYPE;
                        _guest.Password = pass;
                        dbd.Guests.InsertOnSubmit(_guest);
                        dbd.SubmitChanges();
                        reg = "success";
                    }else
                    {
                        reg = "fail";
                    }
                }
                catch (Exception e)
                {
                    return -1 ;
                }
            };
            if(reg.Equals("success"))
            {
                using (EventrixDBDataContext db = new EventrixDBDataContext())
                {
                    try
                    {
                        var query = (from res in db.Guests select res).ToList();
                        Guest lastEntry = query.Last();
                        int ID = lastEntry.G_ID;
                        return ID;
                    }
                    catch (Exception)
                    {
                        return -1;
                    }
                };
            }else
            {
                return -1;
            }
        }

        public string RegisterHost(Host host)
        {
            HashPass hashedPass = new HashPass();
            string pass = HashPass.HashPassword(host.PASS);
            using (EventrixDBDataContext dbd = new EventrixDBDataContext())
            {
                try
                {
                    int MailChecker = (from eh in dbd.EventHosts where eh.Email.Equals(host.EMAIL) select eh).Count();
                    if (MailChecker == 0)
                    {
                        EventHost _host = new EventHost();
                        _host.Name = host.NAME;
                        _host.Email = host.EMAIL;
                        _host.Surname = host.SURNAME;
                        _host.Password = pass;
                        dbd.EventHosts.InsertOnSubmit(_host);
                        dbd.SubmitChanges();
                        return "Registered " + _host.Name + "successfully";
                    }
                    else
                    {
                        return "Error: Account already taken";
                    }
                }
                catch (Exception e)
                {
                    return e.GetBaseException().ToString();
                }
            };
        }

        public string RegisterStaff(EventStaff _staff)
        {
            HashPass hashedPass = new HashPass();
            string pass = HashPass.HashPassword(_staff.PASS);
            using (EventrixDBDataContext dbd = new EventrixDBDataContext())
            {
                try
                {
                    int MailChecker = (from eh in dbd.Staffs where eh.Email.Equals(_staff.EMAIL) && eh.eventid == _staff.EventID select eh).Count();
                    if (MailChecker == 0)
                    {
                        int  _id = Convert.ToInt32(_staff.EventID);
                        Staff staff = new Staff();
                        staff.Name = _staff.NAME;
                        staff.Email = _staff.EMAIL;
                        staff.Occupation = _staff.Occupation;
                        staff.Password = pass;
                        staff.eventid = _id;
                        dbd.Staffs.InsertOnSubmit(staff);
                        dbd.SubmitChanges();
                        return "Registered " + staff.Name + " successfully";
                    }
                    else
                    {
                        return "Error: Account already taken";
                    }
                }
                catch (Exception e)
                {
                    return e.GetBaseException().ToString();
                }
            };
        }
    }
}
