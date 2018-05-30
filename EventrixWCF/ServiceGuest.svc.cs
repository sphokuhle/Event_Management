using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Eventrix_Client.Model.ClientDefinition;

namespace EventrixWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceGuest" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServiceGuest.svc or ServiceGuest.svc.cs at the Solution Explorer and start debugging.
    public class ServiceGuest : IServiceGuest
    {
        public bool createGuest(EventGuest _guest)
        {
            using (EventrixDBDataContext mde = new EventrixDBDataContext())
            {
                try
                {
                    Guest gst = new Guest();
                    gst.Name = _guest.NAME;
                    gst.Surname = _guest.SURNAME;
                    gst.Email = _guest.EMAIL;
                    gst.Password = _guest.PASS;
                    gst.Type = "Public";
                    mde.Guests.InsertOnSubmit(gst);
                    //mde.Guests.Add(gst);
                    //mde.SaveChanges();
                    mde.SubmitChanges();
                    return true;
                }
                catch
                {
                    return false;
                }

            }
        }

        public bool deleteGuest(EventGuest _guest)
        {
            using (EventrixDBDataContext mde = new EventrixDBDataContext())
            {
                try
                {
                    int _id = Convert.ToInt32(_guest.ID);
                    Guest gst = mde.Guests.Single(p => p.G_ID == _id);
                    mde.Guests.DeleteOnSubmit(gst);
                    //mde.Guests.Remove(gst);
                    //mde.SaveChanges();
                    mde.SubmitChanges();
                    return true;
                }
                catch
                {
                    return false;
                }

            };
        }

        public bool editGuest(EventGuest _guest)
        {
            using (EventrixDBDataContext mde = new EventrixDBDataContext())
            {
                try
                {
                    int _id = Convert.ToInt32(_guest.ID);
                    Guest gst = mde.Guests.Single(p => p.G_ID == _id);
                    gst.Name = _guest.NAME;
                    gst.Surname = _guest.SURNAME;
                    gst.Password = _guest.PASS;
                    gst.Email = _guest.EMAIL;
                    mde.Guests.InsertOnSubmit(gst);
                    //mde.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }

            };
        }

        public List<EventGuest> findallguest()
        {
            try
            {
                using (EventrixDBDataContext mde = new EventrixDBDataContext())
                {
                    return mde.Guests.Select(gst => new EventGuest
                    {
                        ID = gst.G_ID,
                        NAME = gst.Name,
                        SURNAME = gst.Surname,
                        PASS = gst.Password,
                        TYPE = gst.Type
                    }).ToList();
                };
            }
            catch(Exception)
            {
                return null;
            }
        }

        public EventGuest findGuestbyID(string id)
        {
            using (EventrixDBDataContext mde = new EventrixDBDataContext())
            {
                int _id = Convert.ToInt32(id);
                try
                {

                    return mde.Guests.Where(gst => gst.G_ID == _id).Select(gst => new EventGuest
                    {
                        ID = gst.G_ID,
                        NAME = gst.Name,
                        SURNAME = gst.Surname,
                        PASS = gst.Password,
                        TYPE = gst.Type,
                        EMAIL = gst.Email,
                    }).First();
                }
                catch
                {
                    return null;
                }
            };
        }

        public EventGuest GuestLogin(string email)
        {
            using (EventrixDBDataContext mde = new EventrixDBDataContext())
            {
                try
                {
                    return mde.Guests.Where(gst => gst.Email == email).Select(gst => new EventGuest
                    {
                        ID = gst.G_ID,
                        NAME = gst.Name,
                        SURNAME = gst.Surname,
                        PASS = gst.Password,
                        TYPE = gst.Type
                    }).First();
                }catch
                {
                    return null;
                }
            };
        }

        public List<EventInfo> findGuestEventsByGuestID(string guest_ID)
        {
            int _id = Convert.ToInt32(guest_ID);
            List<EventInfo> _events = null;
            try
            {
                using (EventrixDBDataContext db = new EventrixDBDataContext())
                {
                    var innerJoinQuery =
                    from guest in db.Guests
                    where guest.G_ID.Equals(_id)
                    join guest_ticket in db.Guest_Tickets on guest.G_ID equals guest_ticket.G_ID
                    join tickets in db.Ticket_Templates on guest_ticket.ticket_temp_id equals tickets.TicketID
                    join events in db.MAIN_EVENTs on tickets.eventid equals events.E_ID
                    select new EventInfo
                    {
                        EventID = Convert.ToInt32(events.E_ID),
                        HostID = Convert.ToInt32(events.EH_ID),
                        EventAddress = Convert.ToInt32(events.AD_Id),
                        Name = events.E_Name,
                        Desc = events.E_Desc,
                        Type = events.E_Type,
                        EB_Quantity = Convert.ToInt32(events.E_EB_Ticket),
                        Reg_Quantity = Convert.ToInt32(events.E_RG_Ticket),
                        VIP_Quantity = Convert.ToInt32(events.E_VIP_Ticket),
                        VVIP_Quantity = Convert.ToInt32(events.E_VVIP_Ticket),
                        sDate = Convert.ToDateTime(events.E_StartDate),
                        eDate = Convert.ToDateTime(events.E_StartDate),
                        Product_Quantity = Convert.ToInt32(events.E_NumProduct),
                    };
                    _events = new List<EventInfo>();
                    foreach (EventInfo _event in innerJoinQuery)
                    {
                        _events.Add(_event);
                    }
                    return _events;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        //Find All Guest Attennding event
        public List<EventGuest> findGuestAttendingEvent(string eventID)
        {
            int E_ID = Convert.ToInt32(eventID);
            List<EventGuest> data = new List<EventGuest>();
            using (EventrixDBDataContext db = new EventrixDBDataContext())
            {
                try
                {
                    var query = (from tick_temp in db.Ticket_Templates
                                 where tick_temp.eventid.Equals(E_ID)
                                 join guestBT in db.Guest_Tickets on tick_temp.TicketID equals guestBT.ticket_temp_id
                                 join gst in db.Guests on guestBT.G_ID equals gst.G_ID
                                 select new EventGuest
                                        {
                                        NAME = gst.Name,
                                        SURNAME = gst.Surname,
                                        EMAIL = gst.Email,
                                        }).ToList();
                    return query;
                }
                catch(Exception)
                {
                    return null;
                }

            };
        }


    }
}
