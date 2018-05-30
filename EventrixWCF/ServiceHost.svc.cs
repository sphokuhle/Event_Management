using EventrixWCF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EventrixWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceHost" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServiceHost.svc or ServiceHost.svc.cs at the Solution Explorer and start debugging.
    public class ServiceHost : IServiceHost
    {
        public bool createHost(Host _host)
        {
            using (EventrixDBDataContext mde = new EventrixDBDataContext())
            {
                try
                {
                    EventHost pe = new EventHost();
                    pe.Name = _host.NAME;
                    pe.Surname = _host.SURNAME;
                    pe.Email = _host.EMAIL;
                    pe.Password = _host.PASS;
                    mde.EventHosts.InsertOnSubmit(pe);
                    mde.SubmitChanges();
                  //  mde.EventHosts.Add(pe);
                   // mde.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }

            };
        }

        public bool deleteHost(Host _host)
        {
            using (EventrixDBDataContext mde = new EventrixDBDataContext())
            {
                try
                {
                    int _id = Convert.ToInt32(_host.ID);
                    EventHost pe = mde.EventHosts.Single(p => p.EH_ID == _id);
                    //mde.EventHosts.Remove(pe);
                    //mde.SaveChanges();
                    mde.EventHosts.DeleteOnSubmit(pe);
                    mde.SubmitChanges();
                    return true;
                }
                catch
                {
                    return false;
                }

            };
        }

        public bool editHost(Host _host)
        {
            using (EventrixDBDataContext mde = new EventrixDBDataContext())
            {
                try
                {
                    int _id = Convert.ToInt32(_host.ID);
                    EventHost pe = mde.EventHosts.Single(p => p.EH_ID == _id);
                    pe.Name = _host.NAME;
                    pe.Surname = _host.SURNAME;
                    pe.Email = _host.EMAIL;
                    // mde.SaveChanges();
                    mde.EventHosts.InsertOnSubmit(pe);
                    mde.SubmitChanges();
                    return true;
                }
                catch
                {
                    return false;
                }

            };
        }

        public List<Host> findallhost()
        {
            using (EventrixDBDataContext mde = new EventrixDBDataContext())
            {
                try
                {
                    return mde.EventHosts.Select(pe => new Host
                    {
                        ID = pe.EH_ID,
                        NAME = pe.Name,
                        SURNAME = pe.Surname,
                        PASS = pe.Password,
                    }).ToList();
                }
                catch
                {
                    return null;
                }
                
            };
        }

        public Host findHostbyID(string id)
        {
            using (EventrixDBDataContext mde = new EventrixDBDataContext())
            {
                try
                {
                    int _id = Convert.ToInt32(id);
                    return mde.EventHosts.Where(pe => pe.EH_ID == _id).Select(pe => new Host
                    {
                        ID = pe.EH_ID,
                        NAME = pe.Name,
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

        public Host Login(string email)
        {
            using (EventrixDBDataContext mde = new EventrixDBDataContext())
            {
                try
                {
                    return mde.EventHosts.Where(pe => pe.Email == email).Select(pe => new Host
                    {
                        ID = pe.EH_ID,
                        NAME = pe.Name,
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

        public Host Login(string email, string password)
        {
            using (EventrixDBDataContext mde = new EventrixDBDataContext())
            {
                try
                {
                    return mde.EventHosts.Where(pe => pe.Email == email && pe.Password == password).Select(pe => new Host
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
    }
}
