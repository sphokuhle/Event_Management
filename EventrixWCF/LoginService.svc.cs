using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using EventrixWCF.Users;

namespace EventrixWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "LoginService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select LoginService.svc or LoginService.svc.cs at the Solution Explorer and start debugging.
    public class LoginService : ILoginService
    {
        public EventGuest GuestLogin(string email, string password)
        {
            HashPass hashedPass = new HashPass();
            string pass = HashPass.HashPassword(password);
            using (EventrixDBDataContext mde = new EventrixDBDataContext())
            {
                try
                {
                    return mde.Guests.Where(pe => pe.Email == email && pe.Password == pass).Select(pe => new EventGuest
                    {
                        ID = pe.G_ID,
                        NAME = pe.Name,
                        EMAIL = pe.Email,
                        SURNAME = pe.Surname,
                        PASS = pe.Password,
                        TYPE = pe.Type
                    }).First();
                }
                catch
                {
                    return null;
                }
            };
        }

        public Host HostLogin(string email, string password)
        {
            HashPass hashedPass = new HashPass();
            string pass = HashPass.HashPassword(password);
            using (EventrixDBDataContext mde = new EventrixDBDataContext())
            {
                try
                {
                    return mde.EventHosts.Where(pe => pe.Email == email && pe.Password == pass).Select(pe => new Host
                    {
                        ID = pe.EH_ID,
                        NAME = pe.Name,
                        EMAIL = pe.Email,
                        SURNAME = pe.Surname,
                        PASS = pe.Password,
                    }).First();
                }
                catch
                {
                    return null;
                }
            };
        }

        public EventStaff StaffLogin(string email, string password)
        {
            HashPass hashedPass = new HashPass();
            string pass = HashPass.HashPassword(password);
            using (EventrixDBDataContext mde = new EventrixDBDataContext())
            {
                try
                {
                    return mde.Staffs.Where(pe => pe.Email == email && pe.Password == pass).Select(pe => new EventStaff
                    {
                        ID = pe.StaffId,
                        NAME = pe.Name,
                        EMAIL = pe.Email,
                        Occupation = pe.Occupation,
                        PASS = pe.Password,
                        EventID = Convert.ToInt32(pe.eventid)
                    }).First();
                }
                catch
                {
                    return null;
                }
            };
        }
    }
}
