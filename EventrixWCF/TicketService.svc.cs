using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Net.Mail;
using Eventrix_Client.Model.ClientDefinition;
using Eventrix_Client.Model;

namespace EventrixWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "TicketService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select TicketService.svc or TicketService.svc.cs at the Solution Explorer and start debugging.
    public class TicketService : ITicketService
    {
        public string createTicket(EventTicket _ticket)
        {
            using (EventrixDBDataContext dbd = new EventrixDBDataContext())
            {
                try
                {
                    int isAvail = (from st in dbd.Ticket_Templates where st.eventid.Equals(_ticket._EventID) && st.Type.Equals(_ticket._Type) select st).Count();
                    if (isAvail == 0)
                    {
                        Ticket_Template toInsert = new Ticket_Template();
                        toInsert.Type = _ticket._Type;
                        toInsert.Credit = _ticket._Credit;
                        toInsert.Price = _ticket._Price;
                        toInsert.RefundPolicy = _ticket._Refund;
                        toInsert.StartDate = _ticket._StartDate;
                        toInsert.EndDate = _ticket._EndDate;
                        toInsert.eventid = _ticket._EventID;
                        dbd.Ticket_Templates.InsertOnSubmit(toInsert);
                        dbd.SubmitChanges();
                        return "success";
                    }
                    else  //update available tickets
                    {
                        Ticket_Template toInsert = (from st in dbd.Ticket_Templates where st.eventid.Equals(_ticket._EventID) && st.Type.Equals(_ticket._Type) select st).First();
                        toInsert.Type = _ticket._Type;
                        toInsert.Credit = _ticket._Credit;
                        toInsert.Price = _ticket._Price;
                        toInsert.RefundPolicy = _ticket._Refund;
                        toInsert.StartDate = _ticket._StartDate;
                        toInsert.EndDate = _ticket._EndDate;
                        toInsert.eventid = _ticket._EventID;
                        dbd.SubmitChanges();
                        string srtTickID = Convert.ToString(toInsert.TicketID);
                        return srtTickID;
                    }

                }
                catch (Exception)
                {
                    return "fail";
                }
            };
        }

        public string deleteGuestTicketByID(string ticket_id)
        {
            int _id = Convert.ToInt32(ticket_id);
            try
            {
                using (EventrixDBDataContext db = new EventrixDBDataContext())
                {
                    List<Guest_Ticket> toDelete = (from dl in db.Guest_Tickets where dl.ticket_temp_id == _id select dl).ToList();
                    if (toDelete == null)
                    {
                        return "Failed: Image Not Found";
                    }
                    else
                    {
                        db.Guest_Tickets.DeleteAllOnSubmit(toDelete);
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
        public bool deleteTicket(EventTicket _ticket)
        {
            throw new NotImplementedException();
        }
        //still to edit
        public string deleteTicketByID(string eventID)
        {
            int _id = Convert.ToInt32(eventID);
            try
            {
                using (EventrixDBDataContext db = new EventrixDBDataContext())
                {
                    List<Ticket_Template> toDelete = (from dl in db.Ticket_Templates where dl.eventid == _id select dl).ToList();
                    if (toDelete == null)
                    {
                        return "Failed: Ticket Not Found";
                    }
                    else
                    {
                        db.Ticket_Templates.DeleteAllOnSubmit(toDelete);
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
        public bool EditTicket(EventTicket _ticket)
        {
            try
            {
                using (EventrixDBDataContext dbd = new EventrixDBDataContext())
                {
                    Ticket_Template toInsert = (from st in dbd.Ticket_Templates where st.eventid.Equals(_ticket._EventID) && st.Type.Equals(_ticket._Type) select st).First();
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
            }
            catch(Exception)
            {
                return false;
            }
        }
        public List<EventTicket> findallticket()
        {
            using (EventrixDBDataContext mde = new EventrixDBDataContext())
            {
                try
                {
                    return mde.Ticket_Templates.Select(pe => new EventTicket
                    {
                        _TicketID = pe.TicketID,
                        _Type = pe.Type,
                        _Credit = Convert.ToInt32(pe.Credit),
                        _Price = Convert.ToDecimal(pe.Price),
                        _Refund = pe.RefundPolicy,
                        _StartDate = Convert.ToDateTime(pe.StartDate),
                        _EndDate = Convert.ToDateTime(pe.EndDate),
                    }).ToList();
                }
                catch
                {
                    return null;
                }
            };
        }
        public List<EventTicket> findticketbyGuestID(string id)
        {
            int _id = Convert.ToInt32(id);
            using (EventrixDBDataContext mde = new EventrixDBDataContext())
            {
                try
                {
                    return mde.Ticket_Templates.Where(pe => pe.eventid == _id).Select(pe => new EventTicket
                    {
                        _TicketID = pe.TicketID,
                        _Type = pe.Type,
                        _Credit = Convert.ToInt32(pe.Credit),
                        _Price = Convert.ToDecimal(pe.Price),
                        _Refund = pe.RefundPolicy,
                        _StartDate = Convert.ToDateTime(pe.StartDate),
                        _EndDate = Convert.ToDateTime(pe.EndDate),
                    }).ToList();
                }
                catch
                {
                    return null;
                }
            };
        }
        public EventTicket getEarlyBirdTicket(string EventID)
        {
            int _id = Convert.ToInt32(EventID);
            using (EventrixDBDataContext mde = new EventrixDBDataContext())
            {
                try
                {
                    return mde.Ticket_Templates.Where(pe => pe.eventid == _id && pe.Type.Equals("Early Bird")).Select(pe => new EventTicket
                    {
                        _TicketID = pe.TicketID,
                        _Type = pe.Type,
                        _Credit = Convert.ToInt32(pe.Credit),
                        _Price = Convert.ToDecimal(pe.Price),
                        _Refund = pe.RefundPolicy,
                        _StartDate = Convert.ToDateTime(pe.StartDate),
                        _EndDate = Convert.ToDateTime(pe.EndDate),
                        _EventID = Convert.ToInt32(pe.eventid),
                    }).First();
                }
                catch
                {
                    return null;
                }
            };
        }
        //get bridging table info by event id
        public List<GuestTicket_BT> getGuestTicketByEventID(string evnetID)
        {
            List<GuestTicket_BT> Guest_tickets = null;
            try
            {
                using (EventrixDBDataContext db = new EventrixDBDataContext())
                {
                    var innerJoinQuery =
                    from ticket_template in db.Ticket_Templates
                    where ticket_template.eventid.Equals(evnetID)
                    join guest_ticket in db.Guest_Tickets on ticket_template.TicketID equals guest_ticket.ticket_temp_id
                   // join QRCode in db.Guest_QRCodes on guest_ticket.ticket_Id equals QRCode.ticket_Id
                    select new GuestTicket_BT
                    {
                        guestticket_BT_ID = guest_ticket.ticket_Id,
                        Guest_ID = guest_ticket.G_ID,
                        ticket_template_id = guest_ticket.ticket_temp_id,
                        numTicket = guest_ticket.numTicket,
                    };
                    Guest_tickets = new List<GuestTicket_BT>();
                    foreach (GuestTicket_BT tickets in innerJoinQuery)
                    {
                        Guest_tickets.Add(tickets);
                    }
                    return Guest_tickets;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        //get Guest QR Codes by eventID
        public List<QRCodeImage> getQRCodeListByEventID(string evnetID)
        {
            List<QRCodeImage> QRCodes = null;
            try
            {
                using (EventrixDBDataContext db = new EventrixDBDataContext())
                {
                    var innerJoinQuery =
                    from ticket_template in db.Ticket_Templates
                    where ticket_template.eventid.Equals(evnetID)
                    join guest_ticket in db.Guest_Tickets on ticket_template.TicketID equals guest_ticket.ticket_temp_id
                    join QRCode in db.Guest_QRCodes on guest_ticket.ticket_Id equals QRCode.ticket_Id
                    select new QRCodeImage
                    {
                        QRCodeID = QRCode.QR_Id,
                        Name = QRCode.Name,
                        ticket_ID = Convert.ToInt32(QRCode.ticket_Id),
                        Location = QRCode.Location,
                    };
                    QRCodes = new List<QRCodeImage>();
                    foreach(QRCodeImage img in innerJoinQuery)
                    {
                        QRCodes.Add(img);
                    }
                    return QRCodes;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public EventTicket getRegularTicket(string EventID)
        {
            int _id = Convert.ToInt32(EventID);
            using (EventrixDBDataContext mde = new EventrixDBDataContext())
            {
                try
                {
                    return mde.Ticket_Templates.Where(pe => pe.eventid == _id && pe.Type.Equals("Regular")).Select(pe => new EventTicket
                    {
                        _TicketID = pe.TicketID,
                        _Type = pe.Type,
                        _Credit = Convert.ToInt32(pe.Credit),
                        _Price = Convert.ToDecimal(pe.Price),
                        _Refund = pe.RefundPolicy,
                        _StartDate = Convert.ToDateTime(pe.StartDate),
                        _EndDate = Convert.ToDateTime(pe.EndDate),
                        _EventID = Convert.ToInt32(pe.eventid),
                    }).First();
                }
                catch
                {
                    return null;
                }
            };
        }

        public List<EventTicket> getTicketbyEventID(string EventID)
        {
            int _id = Convert.ToInt32(EventID);
            using (EventrixDBDataContext mde = new EventrixDBDataContext())
            {
                try
                {
                    return mde.Ticket_Templates.Where(pe => pe.eventid == _id).Select(pe => new EventTicket
                    {
                        _TicketID = pe.TicketID,
                        _Type = pe.Type,
                        _Credit = Convert.ToInt32(pe.Credit),
                        _Price = Convert.ToDecimal(pe.Price),
                        _Refund = pe.RefundPolicy,
                        _StartDate = Convert.ToDateTime(pe.StartDate),
                        _EndDate = Convert.ToDateTime(pe.EndDate),
                        _EventID = Convert.ToInt32(pe.eventid),

                    }).ToList();
                }
                catch
                {
                    return null;
                }
            };
        }
        //get ticket template info by event id
        public List<EventTicket> getTicketTemplateByEventID(string evnetID)
        {
            List<EventTicket> templates = null;
            try
            {
                using (EventrixDBDataContext db = new EventrixDBDataContext())
                {
                    var innerJoinQuery =
                    from ticket_template in db.Ticket_Templates
                    where ticket_template.eventid.Equals(evnetID)
                  //  join guest_ticket in db.Guest_Tickets on ticket_template.TicketID equals guest_ticket.ticket_temp_id
                    // join QRCode in db.Guest_QRCodes on guest_ticket.ticket_Id equals QRCode.ticket_Id
                    select new EventTicket
                    {
                        _TicketID = ticket_template.TicketID,
                        _Type = ticket_template.Type,
                        _Credit = Convert.ToInt32(ticket_template.Credit),
                        _Price = Convert.ToDecimal(ticket_template.Price),
                        _Refund = ticket_template.RefundPolicy,
                        _StartDate = Convert.ToDateTime(ticket_template.StartDate),
                        _EndDate = Convert.ToDateTime(ticket_template.EndDate),
                        _EventID = Convert.ToInt32(ticket_template.eventid),
                    };
                    templates = new List<EventTicket>();
                    foreach (EventTicket tickets in innerJoinQuery)
                    {
                        templates.Add(tickets);
                    }
                    return templates;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        public EventTicket getVIPTicket(string EventID)
        {
            int _id = Convert.ToInt32(EventID);
            using (EventrixDBDataContext mde = new EventrixDBDataContext())
            {
                try
                {
                    return mde.Ticket_Templates.Where(pe => pe.eventid == _id && pe.Type.Equals("VIP")).Select(pe => new EventTicket
                    {
                        _TicketID = pe.TicketID,
                        _Type = pe.Type,
                        _Credit = Convert.ToInt32(pe.Credit),
                        _Price = Convert.ToDecimal(pe.Price),
                        _Refund = pe.RefundPolicy,
                        _StartDate = Convert.ToDateTime(pe.StartDate),
                        _EndDate = Convert.ToDateTime(pe.EndDate),
                        _EventID = Convert.ToInt32(pe.eventid),

                    }).First();
                }
                catch
                {
                    return null;
                }
            };
        }
        public EventTicket getVVIPTicket(string EventID)
        {
            int _id = Convert.ToInt32(EventID);
            using (EventrixDBDataContext mde = new EventrixDBDataContext())
            {
                try
                {
                    return mde.Ticket_Templates.Where(pe => pe.eventid == _id && pe.Type.Equals("VVIP")).Select(pe => new EventTicket
                    {
                        _TicketID = pe.TicketID,
                        _Type = pe.Type,
                        _Credit = Convert.ToInt32(pe.Credit),
                        _Price = Convert.ToDecimal(pe.Price),
                        _Refund = pe.RefundPolicy,
                        _StartDate = Convert.ToDateTime(pe.StartDate),
                        _EndDate = Convert.ToDateTime(pe.EndDate),
                        _EventID = Convert.ToInt32(pe.eventid),

                    }).First();
                }
                catch
                {
                    return null;
                }
            };
        }
        //purchase ticket
        public int updateTicket(EventTicket _ticket)
        {
            try
            {
                using (EventrixDBDataContext dbd = new EventrixDBDataContext())
                {
                    int isAvail = (from st in dbd.Guest_Tickets where st.ticket_temp_id.Equals(_ticket._TicketID) && st.G_ID.Equals(_ticket._GuestID) select st).Count();
                    if (isAvail != 0)
                    {
                        return 0;    //ticket already exist
                    }
                    else  //update available tickets
                    {
                        Guest_Ticket toInsert = new Guest_Ticket();
                        toInsert.ticket_temp_id = _ticket._TicketID;
                        toInsert.G_ID = _ticket._GuestID;
                        toInsert.numTicket = _ticket.numTicket;
                        dbd.Guest_Tickets.InsertOnSubmit(toInsert);
                        dbd.SubmitChanges();
                    }
                }
                using (EventrixDBDataContext dbd = new EventrixDBDataContext())
                {
                    Guest_Ticket toInsert = (from st in dbd.Guest_Tickets where st.ticket_temp_id.Equals(_ticket._TicketID) && st.G_ID.Equals(_ticket._GuestID) select st).First();
                    int ID = toInsert.ticket_Id;
                    return ID;
                };
            }
            catch(Exception)
            {
                return -1;
            }
        }
        // working deletions deletions
        //delete QR Code tickets
        public string deleteQRCodeByEventID(string eventID)
        {
            int _id = Convert.ToInt32(eventID);
            try
            {
                using (EventrixDBDataContext db = new EventrixDBDataContext())
                {
                    List<Guest_QRCode> toDelete =
                    (from ticket_template in db.Ticket_Templates
                     where ticket_template.eventid.Equals(_id)
                     join guest_ticket in db.Guest_Tickets on ticket_template.TicketID equals guest_ticket.ticket_temp_id
                     join QRCode in db.Guest_QRCodes on guest_ticket.ticket_Id equals QRCode.ticket_Id select QRCode).ToList();
                   if(toDelete == null)
                    {
                        return "success: image not found";
                    }else
                    {
                        db.Guest_QRCodes.DeleteAllOnSubmit(toDelete);
                        db.SubmitChanges();
                        return "success";
                    }
                }
            }
            catch (Exception)
            {
                return "failed";
            }
        }
        // delete ticket template by event ID
        public string deleteTicketTemplateByEventID(string EventID)
        {
            int _id = Convert.ToInt32(EventID);
            try
            {
                using (EventrixDBDataContext db = new EventrixDBDataContext())
                {
                    List<Ticket_Template> toDelete = (from dl in db.Ticket_Templates where dl.eventid == _id select dl).ToList();
                    if (toDelete == null)
                    {
                        return "success: Tickets Not Found";
                    }
                    else
                    {
                        db.Ticket_Templates.DeleteAllOnSubmit(toDelete);
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
        //delete guest ticket bridging table
        public string delete_Guest_Ticket_ByEventID(string eventID)
        {
            int _id = Convert.ToInt32(eventID);
            try
            {
                using (EventrixDBDataContext db = new EventrixDBDataContext())
                {
                    List<Guest_Ticket> toDelete =
                   (from ticket_template in db.Ticket_Templates
                    where ticket_template.eventid.Equals(_id)
                    join guest_ticket in db.Guest_Tickets on ticket_template.TicketID equals guest_ticket.ticket_temp_id
                    select guest_ticket).ToList();
                    // join QRCode in db.Guest_QRCodes on guest_ticket.ticket_Id equals QRCode.ticket_Id
                    if(toDelete == null)
                    {
                        return "success: tickets not found";
                    }
                    else
                    {
                        db.Guest_Tickets.DeleteAllOnSubmit(toDelete);
                        db.SubmitChanges();
                        return "success";
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        //Get Guest's Ticket for a specific event
        public List<EventTicket> GetGuestTicketForEvent(string GuestID,string EventID)
        {
            int _id = Convert.ToInt32(GuestID);
            int ev_ID = Convert.ToInt32(EventID);
            List<EventTicket> data = null;
            try
            {
                using (EventrixDBDataContext db = new EventrixDBDataContext())
                {

                    var innerJoinQuery =
                    from guest in db.Guests
                    where guest.G_ID.Equals(_id)
                    join guest_ticket in db.Guest_Tickets on guest.G_ID equals guest_ticket.G_ID
                    join tickets in db.Ticket_Templates on guest_ticket.ticket_temp_id equals tickets.TicketID
                    where tickets.eventid.Equals(ev_ID)
                    select new EventTicket
                    {
                        _TicketID = tickets.TicketID,
                        _Type = tickets.Type,
                        _Credit = Convert.ToInt32(tickets.Credit),
                        _Price = Convert.ToDecimal(tickets.Price),
                        _Refund = tickets.RefundPolicy,
                        _StartDate = Convert.ToDateTime(tickets.StartDate),
                    _EndDate = Convert.ToDateTime(tickets.EndDate),
                    _EventID = Convert.ToInt32(tickets.eventid),
                    numTicket = guest_ticket.numTicket,
                    };
                    data = new List<EventTicket>();
                    foreach (EventTicket items in innerJoinQuery)
                    {
                        if(items._Type.Equals("Early Bird"))
                        {
                            items._Type = "EarlyBird";
                        }
                        data.Add(items);
                    }
                    return data;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        public string UpdateTiket(EventTicket _ticket)
        {
            using (EventrixDBDataContext dbd = new EventrixDBDataContext())
            {
                try
                {
                    int isAvail = (from st in dbd.Ticket_Templates where st.eventid.Equals(_ticket._EventID) && st.Type.Equals(_ticket._Type) select st).Count();
                    if (isAvail == 0)
                    {
                        Ticket_Template toInsert = new Ticket_Template();
                        toInsert.Type = _ticket._Type;
                        toInsert.Credit = _ticket._Credit;
                        toInsert.Price = _ticket._Price;
                        toInsert.RefundPolicy = _ticket._Refund;
                        toInsert.StartDate = _ticket._StartDate;
                        toInsert.EndDate = _ticket._EndDate;
                        toInsert.eventid = _ticket._EventID;
                        dbd.Ticket_Templates.InsertOnSubmit(toInsert);
                        dbd.SubmitChanges();
                        return "success";
                    }
                    else  //update available tickets
                    {
                        Ticket_Template toInsert = (from st in dbd.Ticket_Templates where st.eventid.Equals(_ticket._EventID) && st.Type.Equals(_ticket._Type) select st).First();
                       
                        toInsert.Type = _ticket._Type;
                        toInsert.Credit = _ticket._Credit;
                        toInsert.Price = _ticket._Price;
                        toInsert.RefundPolicy = _ticket._Refund;
                        toInsert.StartDate = _ticket._StartDate;
                        toInsert.EndDate = _ticket._EndDate;
                        toInsert.eventid = _ticket._EventID;
                        dbd.SubmitChanges();
                        return "success";
                    }
                }
                catch(Exception)
                {
                    return "failed";
                }
            }
        }
        //Upload User CreditsS
        public bool UploadCredit(EventTicket _ticket)
        {
            using (EventrixDBDataContext db = new EventrixDBDataContext())
            {
                try
                {
                    Ticket_Template toInsert = (from st in db.Ticket_Templates where st.TicketID.Equals(_ticket._TicketID) select st).First();
                    toInsert.Credit = _ticket._Credit;
                    db.SubmitChanges();

                    List<Guest_Ticket> insert = (from st in db.Guest_Tickets where st.ticket_temp_id.Equals(_ticket._TicketID) && st.G_ID.Equals(_ticket._GuestID) select st).ToList();
                    //   toInsert.Credit = _ticket._Credit;
                    foreach (Guest_Ticket gt in insert)
                    {
                        var query = (from qr in db.Guest_QRCodes where qr.ticket_Id.Equals(gt.ticket_Id) select qr).First();
                        Guest_QRCode GQR = query;
                        GQR.Credit = _ticket._Credit;
                        db.SubmitChanges();

                    }
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public int purchaseTicket(EventTicket _ticket)
        {
            string tracker = "";
            using (EventrixDBDataContext dbd = new EventrixDBDataContext())
            {
                try
                {
                        Guest_Ticket toInsert = new Guest_Ticket();
                        toInsert.G_ID = _ticket._GuestID;
                        toInsert.ticket_temp_id = _ticket._TicketID;
                      //  toInsert.numTicket = 0;
                        dbd.Guest_Tickets.InsertOnSubmit(toInsert);
                        dbd.SubmitChanges();
                        tracker = "success";
                }
                catch (Exception)
                {
                    return 0;
                }
            };
            using(EventrixDBDataContext db = new EventrixDBDataContext())
            {
                if(tracker.Equals("success"))
                {
                    var query = (from tk in db.Guest_Tickets select tk).ToList();
                    Guest_Ticket tick = query.Last();
                    int ID = tick.ticket_Id;
                    return ID;
                }else
                {
                    return 0;
                }
            };
        }

        public EventTicket getTicketByGuestID(string QRCOdeID)
        {
            using (EventrixDBDataContext db = new EventrixDBDataContext())
            {
                try
                {
                    int _id = Convert.ToInt32(QRCOdeID);
                    var query = (from qr in db.Guest_QRCodes where qr.QR_Id.Equals(_id) select
                                new EventTicket {
                                    _TicketID = qr.Guest_Ticket.Ticket_Template.TicketID,
                                    _Type = qr.Guest_Ticket.Ticket_Template.Type,
                                    _Credit = Convert.ToInt32(qr.Guest_Ticket.Ticket_Template.Credit),
                                    _Price = Convert.ToDecimal(qr.Guest_Ticket.Ticket_Template.Price),
                                    _Refund = qr.Guest_Ticket.Ticket_Template.RefundPolicy,
                                }).Single();
                    return query;
                }catch(Exception)
                {
                    return null;
                }
            };
        }

        public EventTicket getTicketByEventIDANDGuestID(string QRID)
        {
            int _id = Convert.ToInt32(QRID);
            using (EventrixDBDataContext db = new EventrixDBDataContext())
            {
                try
                {
                    var query = (from qr in db.Guest_QRCodes
                                 where qr.QR_Id.Equals(_id)
                                 select
                                    new EventTicket
                                    {
                                        _Credit = Convert.ToInt32(qr.Guest_Ticket.Ticket_Template.Credit),
                                        _Type = qr.Guest_Ticket.Ticket_Template.Type,

                                    }).First();
                    return query;
                }catch(Exception)
                {
                    return null;
                }
            };
        }

        public int dl_BT_AND_QRCode(string G_ID, string EventID)
        {
            int _id = Convert.ToInt32(G_ID);
            int e_ID = Convert.ToInt32(EventID);
            int CountDeleted = 0;
            EventService _eventService = new EventService();
            EventModel _updatedEvent = new EventModel();
            EventModel _Event = new EventModel();
            _Event = _eventService.getEventByEventID(EventID);
            try
            {
                using (EventrixDBDataContext db = new EventrixDBDataContext())
                {
                    List < Guest_Ticket > toDelete =
                  (from ticket_template in db.Ticket_Templates
                   where ticket_template.eventid.Equals(e_ID)
                   join guest_ticket in db.Guest_Tickets on ticket_template.TicketID equals guest_ticket.ticket_temp_id
                   where guest_ticket.G_ID.Equals(_id)
                   select guest_ticket).ToList();

                    foreach (Guest_Ticket tick in toDelete)
                    {
                        //Delete QRCode for specific ticket template
                        List<Guest_QRCode> query = (from dl in db.Guest_QRCodes where dl.ticket_Id.Equals(tick.ticket_Id) select dl).ToList();
                        CountDeleted = query.Count();
                        db.Guest_QRCodes.DeleteAllOnSubmit(query);
                        db.SubmitChanges();

                        //Increment Ticket Count for event
                        if (tick.Ticket_Template.Type.Equals("Regular"))
                        {
                            _Event.Reg_Quantity += 1;
                            _updatedEvent = _eventService.updateEvent(EventID, _Event);
                        }
                        else if (tick.Ticket_Template.Type.Equals("VIP"))
                        {
                            _Event.VIP_Quantity += 1;
                            _updatedEvent = _eventService.updateEvent(EventID, _Event);
                        }else
                        if (tick.Ticket_Template.Type.Equals("VVIP"))
                        {
                            _Event.VVIP_Quantity += 1;
                            _updatedEvent = _eventService.updateEvent(EventID, _Event);
                        }else
                        if (tick.Ticket_Template.Type.Contains("Early"))
                        {
                            _Event.EB_Quantity += 1;
                            _updatedEvent = _eventService.updateEvent(EventID, _Event);
                        }
                    }
                    db.Guest_Tickets.DeleteAllOnSubmit(toDelete);
                    db.SubmitChanges();
                    return CountDeleted;
                }
            }
            catch (Exception)
            {
                return -1;
            }
        }
    }
}
