using Eventrix_Client;
using Eventrix_Client.Model;
using Eventrix_Client.Model.ClientDefinition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web.Script.Serialization;

namespace EventrixWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "EventService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select EventService.svc or EventService.svc.cs at the Solution Explorer and start debugging.
    public class EventService : IEventService
    {
        //setters
        MappingService maps = new MappingService();
        public string createEvent(EventModel _event)
        {
            using (EventrixDBDataContext dbd = new EventrixDBDataContext())
            {
              try
                {
                    MAIN_EVENT myevent = new MAIN_EVENT();
                    myevent.E_Name = _event.Name;
                    myevent.E_Type = _event.Type;
                    myevent.E_Desc = _event.Desc;
                    myevent.EH_ID = _event.HostID;
                    myevent.AD_Id = _event.EventAddress;
                    myevent.E_EB_Ticket = _event.EB_Quantity;
                    myevent.E_RG_Ticket = _event.Reg_Quantity;
                    myevent.E_VIP_Ticket = _event.VIP_Quantity;
                    myevent.E_VVIP_Ticket = _event.VVIP_Quantity;
                    myevent.E_NumProduct = _event.Product_Quantity;
                    myevent.E_StartDate = Convert.ToDateTime(_event.sDate);
                    myevent.E_EndDate = Convert.ToDateTime(_event.eDate);
                    myevent.NumViews = 0;
                    if(_event.Category == null)
                    {
                        myevent.Category = "All";
                    }
                    else
                    {
                        myevent.Category = _event.Category;
                    }
                    dbd.MAIN_EVENTs.InsertOnSubmit(myevent);
                    dbd.SubmitChanges();
                    return "success";
                }
                catch(Exception)
                {
                    return "failed";
                }
              
            };
        }
        public string deleteEventByID(string eventID)
        {
            SurveyService _survey = new SurveyService();
            int _id = Convert.ToInt32(eventID);
           bool isDeleted =  dl_EnevtRSVP(eventID);
            bool dl_survey = _survey.dl_Survey(eventID);
            if (isDeleted == true && dl_survey == true)
            {
               
                    using (EventrixDBDataContext db = new EventrixDBDataContext())
                    {
                        List<MAIN_EVENT> toDelete = (from dl in db.MAIN_EVENTs where dl.E_ID == _id select dl).ToList();
                        if (toDelete == null)
                        {
                            return "Failed:";
                        }
                        else
                        {
                            db.MAIN_EVENTs.DeleteAllOnSubmit(toDelete);
                            db.SubmitChanges();
                            return "success";
                        }
                    };
                
               
            }
            else
            {
                return "Failed";
            }

        }
        public int findEventID(EventModel _event)
        {
            try
            {
                using (EventrixDBDataContext db = new EventrixDBDataContext())
                {
                    MAIN_EVENT ev = db.MAIN_EVENTs.Single(_ev => _ev.EH_ID == _event.HostID && _ev.AD_Id == _event.EventAddress
                    && _ev.E_Name.Equals(_event.Name) && _ev.E_Type.Equals(_event.Type));
                    int EVENTID = ev.E_ID;
                    return EVENTID;
                };
            }
            catch (Exception)
            {
                return 000;
            }
        }
        public List<EventModel> getAllEvents()
        {
            try
            {
                FileUpload fileService = new FileUpload();
                List<EventModel> data = new List<EventModel>();
                using (EventrixDBDataContext db = new EventrixDBDataContext())
                {
                    var EventQuery =
                       ( from ev in db.MAIN_EVENTs
                        join address in db.Addresses on ev.AD_Id equals address.AD_Id
                        select new EventModel
                        {
                            Name = ev.E_Name,
                            EventID = ev.E_ID,
                            Desc = ev.E_Desc,
                            Type = ev.E_Type,
                            HostID = Convert.ToInt32(ev.EH_ID),
                            EventAddress = ev.AD_Id,
                            EB_Quantity = Convert.ToInt32(ev.E_EB_Ticket),
                            Reg_Quantity = Convert.ToInt32(ev.E_RG_Ticket),
                            VIP_Quantity = Convert.ToInt32(ev.E_VIP_Ticket),
                            VVIP_Quantity = Convert.ToInt32(ev.E_VVIP_Ticket),
                            Product_Quantity = Convert.ToInt32(ev.E_NumProduct),
                            City = ev.Address.AD_City,
                            Province = ev.Address.AD_Province,
                            Street = ev.Address.AD_StreetName,
                            sDate = Convert.ToString(ev.E_StartDate),
                            Start_Date = Convert.ToDateTime(ev.E_StartDate),
                            eDate = Convert.ToString(ev.E_EndDate),
                            Category = ev.Category,
                           ImageLocation = fileService.getImageLocationByEventId(Convert.ToString(ev.E_ID)),
                     
                        }).OrderByDescending(t=>t.Start_Date);
                    foreach(EventModel events in EventQuery)
                    {
                        string output = "";
                        if (events.ImageLocation == "fail")
                        {
                            output = "Events/Eventrix_Default_Image.png";
                            events.ImageLocation = output;
                        }

                        data.Add(events);
                    }
                    return data;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        public List<EventModel> getAllEventsByHostID(string HostID, string Guest_ID)
        {
            if(Convert.ToInt32(HostID) != 0 && Convert.ToInt32(Guest_ID) == 0)
            {
                FileUpload fileService = new FileUpload();
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
                            EventAddress = ev.AD_Id,
                            EB_Quantity = Convert.ToInt32(ev.E_EB_Ticket),
                            Reg_Quantity = Convert.ToInt32(ev.E_RG_Ticket),
                            VIP_Quantity = Convert.ToInt32(ev.E_VIP_Ticket),
                            VVIP_Quantity = Convert.ToInt32(ev.E_VVIP_Ticket),
                            Product_Quantity = Convert.ToInt32(ev.E_NumProduct),
                            sDate = Convert.ToString(ev.E_StartDate),
                            eDate = Convert.ToString(ev.E_EndDate),
                            City = ev.Address.AD_City,
                            Province = ev.Address.AD_Province,
                            Street = ev.Address.AD_StreetName,
                            Start_Date = Convert.ToDateTime(ev.E_StartDate),
                            Category = ev.Category,
                            ImageLocation = fileService.getImageLocationByEventId(Convert.ToString(ev.E_ID)),
                        }).OrderByDescending(t => t.Start_Date).ToList();
                    }
                }
                catch (Exception)
                {
                    return null;
                }
            }else   //Guest Events
            {
                int _id = Convert.ToInt32(Guest_ID);
                List<EventModel> _events = null;
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
                        select new EventModel
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
                            sDate = Convert.ToString(events.E_StartDate),
                            eDate = Convert.ToString(events.E_StartDate),
                            City = events.Address.AD_City,
                            Province = events.Address.AD_Province,
                            Street = events.Address.AD_StreetName,
                            Category = events.Category,
                            Product_Quantity = Convert.ToInt32(events.E_NumProduct),
                        };
                        _events = new List<EventModel>();
                        foreach(EventModel ev in innerJoinQuery)
                        {
                            _events.Add(ev);
                        }
                        return _events;
                    }
                }
                catch (Exception)
                {
                    return null;
                }
            }

        }
        public EventModel getEventByEventID(string EventID)
        {
          //  EventAddress _address = maps.getAddressById(EventID);
            int _id = Convert.ToInt32(EventID);
            try
            {
                FileUpload fileservice = new FileUpload();
                using (EventrixDBDataContext db = new EventrixDBDataContext())
                {
                    var query = (from ev in db.MAIN_EVENTs where ev.E_ID.Equals(_id) select new EventModel
                    {
                        Name = ev.E_Name,
                        EventID = ev.E_ID,
                        Desc = ev.E_Desc,
                        Type = ev.E_Type,
                        HostID = Convert.ToInt32(ev.EH_ID),
                        EventAddress = ev.AD_Id,
                        EB_Quantity = Convert.ToInt32(ev.E_EB_Ticket),
                        Reg_Quantity = Convert.ToInt32(ev.E_RG_Ticket),
                        VIP_Quantity = Convert.ToInt32(ev.E_VIP_Ticket),
                        VVIP_Quantity = Convert.ToInt32(ev.E_VVIP_Ticket),
                        Product_Quantity = Convert.ToInt32(ev.E_NumProduct),
                        sDate = Convert.ToString(ev.E_StartDate),
                        City = ev.Address.AD_City,
                        Start_Date = Convert.ToDateTime(ev.E_StartDate),
                        eDate = Convert.ToString(ev.E_EndDate),
                        Category = ev.Category,
                        ImageLocation = fileservice.getImageLocationByEventId(EventID),
                    }).First();
                    EventModel _event = query;
                    return _event;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        public List<EventModel> findGuestEventsByGuestID(string guest_ID)
        {
            int _id = Convert.ToInt32(guest_ID);
            List<EventModel> events = new List<EventModel>();

            return events;
        }
        public EventModel updateEvent(string id, EventModel _event)
        {
            using (EventrixDBDataContext db = new EventrixDBDataContext())
            {
                try
                {
               //     FileUpload fileService = new FileUpload();
                    var query = (from add in db.MAIN_EVENTs where add.E_ID.Equals(Convert.ToInt32(id)) select add);
                    if (query.Count() == 1)
                    {
                        MAIN_EVENT res = query.Single();
                        res.E_Name = _event.Name;
                        res.E_Desc = _event.Desc;
                        res.E_Type = _event.Type;
                        res.E_EB_Ticket = _event.EB_Quantity;
                        res.E_RG_Ticket = _event.Reg_Quantity;
                        res.E_VIP_Ticket = _event.VIP_Quantity;
                        res.E_VVIP_Ticket = _event.VVIP_Quantity;
                        res.E_StartDate = Convert.ToDateTime(_event.sDate);
                        res.E_EndDate = Convert.ToDateTime(_event.eDate);
                        res.Category = _event.Category;
                       // res.E_NumProduct = _event.Product_Quantity;
                        db.SubmitChanges();
                        _event = new EventModel()
                        {
                            EventID = res.E_ID,
                            HostID = Convert.ToInt32(res.EH_ID),
                            Name = res.E_Name,
                            Desc= res.E_Desc,
                            Type = res.E_Type,
                            EB_Quantity = Convert.ToInt32(res.E_EB_Ticket),
                            Reg_Quantity = Convert.ToInt32(res.E_RG_Ticket),
                            VIP_Quantity= Convert.ToInt32(res.E_VIP_Ticket),
                            VVIP_Quantity=  Convert.ToInt32(res.E_VVIP_Ticket),
                            sDate =  Convert.ToString(res.E_StartDate),
                            eDate=   Convert.ToString(res.E_EndDate),
                            Category = res.Category,
                        //    ImageLocation = fileService.getImageLocationByEventId(Convert.ToString(id)),
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
        public bool addEventView(EventModel _event)
        {
             using (EventrixDBDataContext db = new EventrixDBDataContext())
              {
                if(_event.HostID == 0 && _event.GuestID != 0)  //Update Views by logged in host
                {
                    var query = (from events in db.EventViews
                                 where events.eventID.Equals(_event.EventID)
                     && events.G_ID.Equals(_event.GuestID) && events.Type.Equals(_event.Type)
                                 select events).Count();
                    if (query == 0)
                    {
                        EventView res = new EventView();
                        res.eventID = _event.EventID;
                        res.G_ID = _event.GuestID;
                        db.EventViews.InsertOnSubmit(res);
                        res.Type = _event.Type;
                        res.ViewDate = DateTime.Now;
                        db.SubmitChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if(_event.HostID !=0 && _event.GuestID == 0) //Update Views by logged in host
                {
                    var query = (from events in db.EventViews
                                 where events.eventID.Equals(_event.EventID)
                     && events.EH_ID.Equals(_event.HostID) && events.Type.Equals(_event.Type)
                                 select events).Count();
                    if (query == 0)
                    {
                        EventView res = new EventView();
                        res.eventID = _event.EventID;
                        res.EH_ID = _event.HostID;
                        res.Type = _event.Type;
                        res.ViewDate = DateTime.Now;
                        db.EventViews.InsertOnSubmit(res);
                        db.SubmitChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                return false;
             };
           
        }
        //Get All Events that the guets is to attendcreateEvent
        public List<EventModel> GuestLiveEvent(string Guest_ID)
        {
            int _id = Convert.ToInt32(Guest_ID);
            List<EventModel> _events = null;
            FileUpload fileService = new FileUpload();
            try
            {
                using (EventrixDBDataContext db = new EventrixDBDataContext())
                {
                    var innerJoinQuery =
                  (  from guest in db.Guests
                    where guest.G_ID.Equals(_id)
                    join guest_ticket in db.Guest_Tickets on guest.G_ID equals guest_ticket.G_ID
                    join tickets in db.Ticket_Templates on guest_ticket.ticket_temp_id equals tickets.TicketID
                    join events in db.MAIN_EVENTs on tickets.eventid equals events.E_ID
                    join img in db.EventImages on events.E_ID equals img.EventID
                    select new EventModel
                    {
                        EventID = Convert.ToInt32(events.E_ID),
                        HostID = Convert.ToInt32(events.EH_ID),
                        EventAddress = Convert.ToInt32(events.AD_Id),
                        Name = events.E_Name,
                        Desc = events.E_Desc,
                        Type = events.E_Type,
                   //     EB_Quantity = Convert.ToInt32(events.E_EB_Ticket),
                    //    Reg_Quantity = Convert.ToInt32(events.E_RG_Ticket),
                    //    VIP_Quantity = Convert.ToInt32(events.E_VIP_Ticket),
                     //   VVIP_Quantity = Convert.ToInt32(events.E_VVIP_Ticket),
                        sDate = Convert.ToString(events.E_StartDate),
                        Start_Date = Convert.ToDateTime(events.E_StartDate),
                        eDate = Convert.ToString(events.E_StartDate),
                     //   Product_Quantity = Convert.ToInt32(events.E_NumProduct),
                        ImageLocation = img.Location,
                        Category = events.Category,
                    }).OrderByDescending(t => t.Start_Date);
                    _events = new List<EventModel>();
                    foreach (EventModel _event in innerJoinQuery)
                    {
                        string output = "";
                        if (_event.ImageLocation == null)
                        {
                            output = "Events/Eventrix_Default_Image.png";
                        }
                        else
                        {
                            output = _event.ImageLocation.Substring(_event.ImageLocation.IndexOf('E')); //trim string path from Event
                        }
                        _event.ImageLocation = output;

                       
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
        //Get Event for scanned Guest QR-CODE
        public EventModel EventByQRCodeID(string ID)
        {
            int _id = Convert.ToInt32(ID);
            try
            {
                using (EventrixDBDataContext db = new EventrixDBDataContext())
                {
                    var innerJoinQuery =
                    (from qr in db.Guest_QRCodes
                     where qr.QR_Id.Equals(_id)
                     select new EventModel
                     {
                         EventID = qr.Guest_Ticket.Ticket_Template.MAIN_EVENT.E_ID,
                         HostID = qr.Guest_Ticket.Ticket_Template.MAIN_EVENT.E_ID,
                         Name = qr.Guest_Ticket.Ticket_Template.MAIN_EVENT.E_Name,
                         Desc = qr.Guest_Ticket.Ticket_Template.MAIN_EVENT.E_Desc,
                         Type = qr.Guest_Ticket.Ticket_Template.MAIN_EVENT.E_Type,
                         EB_Quantity = Convert.ToInt32(qr.Guest_Ticket.Ticket_Template.MAIN_EVENT.E_EB_Ticket),
                         Reg_Quantity = Convert.ToInt32(qr.Guest_Ticket.Ticket_Template.MAIN_EVENT.E_RG_Ticket),
                         VIP_Quantity = Convert.ToInt32(qr.Guest_Ticket.Ticket_Template.MAIN_EVENT.E_VIP_Ticket),
                         VVIP_Quantity = Convert.ToInt32(qr.Guest_Ticket.Ticket_Template.MAIN_EVENT.E_VVIP_Ticket),
                         sDate = Convert.ToString(qr.Guest_Ticket.Ticket_Template.MAIN_EVENT.E_StartDate),
                         eDate = Convert.ToString(qr.Guest_Ticket.Ticket_Template.MAIN_EVENT.E_EndDate),
                         Product_Quantity = Convert.ToInt32(qr.Guest_Ticket.Ticket_Template.MAIN_EVENT.E_NumProduct),
                         Start_Date = Convert.ToDateTime(qr.Guest_Ticket.Ticket_Template.MAIN_EVENT.E_StartDate),
                         ImageLocation = qr.Guest_Ticket.Ticket_Template.MAIN_EVENT.EventImages.Select(pe => pe.Location).First(),
                     }).Single();
                    return innerJoinQuery;
               };
            }catch(Exception)
            {
                return null;
            }
        }
        public List<EventModel> GuestEventTicketList(string Guest_ID)
        {
            int _id = Convert.ToInt32(Guest_ID);
            List<EventModel> _events = new List<EventModel>();
            ImageFile images = new ImageFile();
            List<EventTicket> _tickets = new List<EventTicket>();
            TicketService ticketservice = new TicketService();
            FileUpload fileService = new FileUpload();
            try
            {
                using (EventrixDBDataContext db = new EventrixDBDataContext())
                {
                    var innerJoinQueryCount =
                    (from guest in db.Guests
                     where guest.G_ID.Equals(_id)
                     join guest_ticket in db.Guest_Tickets on guest.G_ID equals guest_ticket.G_ID
                     join tickets in db.Ticket_Templates on guest_ticket.ticket_temp_id equals tickets.TicketID
                     join events in db.MAIN_EVENTs on tickets.eventid equals events.E_ID
                     select events).Count();

                    if (innerJoinQueryCount != 0)
                    {
                        var innerJoinQuery =
                       (from guest in db.Guests
                        where guest.G_ID.Equals(_id)
                        join guest_ticket in db.Guest_Tickets on guest.G_ID equals guest_ticket.G_ID
                        join tickets in db.Ticket_Templates on guest_ticket.ticket_temp_id equals tickets.TicketID
                        join events in db.MAIN_EVENTs on tickets.eventid equals events.E_ID
                        select new EventModel
                        {
                            EventID = Convert.ToInt32(events.E_ID),
                            HostID = Convert.ToInt32(events.EH_ID),
                            EventAddress = Convert.ToInt32(events.AD_Id),
                            Name = events.E_Name,
                            //      Desc = events.E_Desc,
                            Type = events.E_Type,
                            EB_Quantity = Convert.ToInt32(events.E_EB_Ticket),
                            Reg_Quantity = Convert.ToInt32(events.E_RG_Ticket),
                            VIP_Quantity = Convert.ToInt32(events.E_VIP_Ticket),
                            VVIP_Quantity = Convert.ToInt32(events.E_VVIP_Ticket),
                            sDate = Convert.ToString(events.E_StartDate),
                            Start_Date = Convert.ToDateTime(events.E_StartDate),
                            eDate = Convert.ToString(events.E_StartDate),
                            Product_Quantity = Convert.ToInt32(events.E_NumProduct),
                            Category = events.Category,
                            City = events.Address.AD_City,
                            Province = events.Address.AD_Province,
                            Street = events.Address.AD_StreetName,
                            //    mycount = Convert.ToInt32(guest_ticket.Guest_QRCodes.Where(pe => pe.ticket_Id.Equals(guest_ticket.ticket_Id)).Select(p => p.Credit).First()),
                            //EventImage
                            //  EventImage = fileService.getImageById(Convert.ToString(events.E_ID)),
                            ImageLocation = fileService.getImageLocationByEventId(Convert.ToString(events.E_ID)),
                            eventTicket = ticketservice.GetGuestTicketForEvent(Guest_ID, Convert.ToString(events.E_ID)),

                        }).OrderByDescending(t => t.Start_Date).ToList();

                        _events = new List<EventModel>();
                        foreach (EventModel _Event in innerJoinQuery)
                        {
                                _events.Add(_Event);
                        }
                    }
                    return _events;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        public bool RecordView(EventViews _views)
        {
                using (EventrixDBDataContext db = new EventrixDBDataContext())
                {
                    var query = (from views in db.EventViews where views.eventID.Equals(_views.E_ID)
                                 && views.G_ID.Equals(_views.G_ID) select views);
                    if (query.Count() == 0)
                    {
                    EventView toinsert = new EventView();
                    toinsert.eventID = _views.E_ID;
                    toinsert.G_ID = _views.G_ID;
                    toinsert.EH_ID = _views.EH_ID;

                    db.EventViews.InsertOnSubmit(toinsert);
                    db.SubmitChanges();
                    return true;
                    }
                    else
                    {
                    return false;
                    }
                };
            }
        //Get Number of event views per event
        public int ViewsStat(string eventID, string Type)
        {
            try {
                  int _id = Convert.ToInt32(eventID);
                using (EventrixDBDataContext db = new EventrixDBDataContext())
                {
                    var isAvail = (from vw in db.EventViews where vw.eventID.Equals(_id)
                                   && vw.Type.Equals(Type) select vw);
                    int strCount = isAvail.Count();
                    return strCount;
                };
            }
            catch (Exception)
            {
                return 0;
            }
        }

        //Get Guest Info By Event ID
        public GuestModel GuestByQRCodeID(string ID)
        {
            int _id = Convert.ToInt32(ID);
            try
            {
                using (EventrixDBDataContext db = new EventrixDBDataContext())
                {
                    var innerJoinQuery =
                    (from qr in db.Guest_QRCodes
                     where qr.QR_Id.Equals(_id)
                     select new GuestModel
                     {
                         ID = qr.Guest_Ticket.Guest.G_ID,
                         NAME = qr.Guest_Ticket.Guest.Name,
                         SURNAME = qr.Guest_Ticket.Guest.Surname,
                         EMAIL = qr.Guest_Ticket.Guest.Email,
                     }).Single();
                    return innerJoinQuery;
                };
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<int> TestGustEventList(string Guest_ID)
        {
            return null;
        }

        public bool RecordRSVP(string eventID, string GuestID, string Status)
        {
            int ev_ID = Convert.ToInt32(eventID);
            int g_ID = Convert.ToInt32(GuestID);
            using (EventrixDBDataContext db = new EventrixDBDataContext())
            {
                try
                {
                    int query = (from res in db.EventRSVPs where res.E_ID.Equals(ev_ID) && res.G_ID.Equals(g_ID) select res).Count();
                    if(query == 0)
                    {
                        EventRSVP rsvp = new EventRSVP();
                        rsvp.E_ID = ev_ID;
                        rsvp.G_ID = g_ID;
                        rsvp.Status = Status;
                        db.EventRSVPs.InsertOnSubmit(rsvp);
                        db.SubmitChanges();
                        return true;
                    }else
                    {
                        var update = (from res in db.EventRSVPs where res.E_ID.Equals(ev_ID) && res.G_ID.Equals(g_ID) select res).First();
                        update.Status = Status;
                        db.SubmitChanges();
                        return true;
                    }
                }catch(Exception)
                {
                    return false;
                }
            };
        }

        public bool dl_EnevtRSVP(string eventID)
        {
            int _id = Convert.ToInt32(eventID);
            try
            {
                using (EventrixDBDataContext db = new EventrixDBDataContext())
                {
                    List<EventRSVP> toDelete = (from dl in db.EventRSVPs where dl.E_ID == _id select dl).ToList();
                    if (toDelete == null)
                    {
                        return false;
                    }
                    else
                    {
                        db.EventRSVPs.DeleteAllOnSubmit(toDelete);
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

        public List<EventModel> getHomeEvent(string UserID, string type)
        {
            if(UserID.Equals("undefined") || type.Equals("undefined"))
            {
                return getAllEvents();
            }
            int _id = Convert.ToInt32(UserID);
            List<EventModel> _events = new List<EventModel>();
            if (type.Equals("Host"))
            {
                FileUpload fileService = new FileUpload();
                try
                {
                    using (EventrixDBDataContext db = new EventrixDBDataContext())
                    {
                        var query = (from ev in db.MAIN_EVENTs where ev.EH_ID.Equals(_id) select new EventModel
                        {
                            Name = ev.E_Name,
                            EventID = ev.E_ID,
                            Desc = ev.E_Desc,
                            Type = ev.E_Type,
                            HostID = Convert.ToInt32(ev.EH_ID),
                            EventAddress = ev.AD_Id,
                            EB_Quantity = Convert.ToInt32(ev.E_EB_Ticket),
                            Reg_Quantity = Convert.ToInt32(ev.E_RG_Ticket),
                            VIP_Quantity = Convert.ToInt32(ev.E_VIP_Ticket),
                            VVIP_Quantity = Convert.ToInt32(ev.E_VVIP_Ticket),
                            Product_Quantity = Convert.ToInt32(ev.E_NumProduct),
                            City = ev.Address.AD_City,
                            Province = ev.Address.AD_Province,
                            Street = ev.Address.AD_StreetName,

                            sDate = Convert.ToString(ev.E_StartDate),
                            eDate = Convert.ToString(ev.E_EndDate),
                            Start_Date = Convert.ToDateTime(ev.E_StartDate),
                            Category = ev.Category,
                            ImageLocation = fileService.getImageLocationByEventId(Convert.ToString(ev.E_ID)),
                        }).OrderByDescending(t => t.Start_Date).ToList();

                        _events = query;
                    };
                }
                catch (Exception)
                {
                    return null;
                }
            }
            else if(type.Equals("Guest"))  //Guest Events
            {
                
                _events = GuestEventTicketList(Convert.ToString(_id));
                if(_events == null)
                {
                    return null;
                }
            }
            else //All Events
            {
                 _events =  getAllEvents();
            }

            //Cut Count to 4
            List<EventModel> data = new List<EventModel>();
            int count = 1;
            foreach(EventModel ev in _events)
            {
                if(count >= 1 && count <= 4)
                {
                    data.Add(ev);
                }
                else
                {
                    break;
                }
                count++;
            }
            return data;

        }
    }
}
