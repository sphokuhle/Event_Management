using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Eventrix_Client.Model.ClientDefinition;

namespace EventrixWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "EventViewsService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select EventViewsService.svc or EventViewsService.svc.cs at the Solution Explorer and start debugging.
    public class EventViewsService : IEventViewsService
    {
        //Get Number of event views per event
        public EventModel ViewsStat(string eventID)
        {
            int _id = Convert.ToInt32(eventID);
            using(EventrixDBDataContext db = new EventrixDBDataContext())
             {
                int isAvail = (from vw in db.EventViews where vw.eventID.Equals(_id)select vw).Count();
                if(isAvail != 0)
                {
                    return db.EventViews.Where(vw => vw.eventID == _id).Select(ev => new EventModel
                    {
                        //count = isAvail,
                        sDate = Convert.ToString(ev.ViewDate),
                    }).First();
                }
                else
                {
                    return null;
                }
            };
        }

        //Insert new event view
        public bool RecordEventView(string eventID, string HostID, string GuestID)
        {
            int E_ID = Convert.ToInt32(eventID);
            int H_ID = Convert.ToInt32(HostID);
            int G_ID = Convert.ToInt32(GuestID);
            using (EventrixDBDataContext dbd = new EventrixDBDataContext())
            {
                    if(H_ID == 0)  //then record guest's event view
                    {
                        int isAvail = (from vw in dbd.EventViews where vw.eventID.Equals(E_ID) && vw.G_ID.Equals(G_ID) select vw).Count();
                        if (isAvail == 0)
                        {
                            EventView view = new EventView();
                            view.eventID = E_ID;
                            view.G_ID = G_ID;
                            view.EH_ID = H_ID;
                            dbd.EventViews.InsertOnSubmit(view);
                            dbd.SubmitChanges();
                            return true;
                        }
                        else  //view already exist
                        {
                            return false;
                        }
                    }
                    else   //record event host's event view
                    {
                        int isAvail = (from vw in dbd.EventViews where vw.eventID.Equals(E_ID) && vw.EH_ID.Equals(H_ID) select vw).Count();
                        if (isAvail == 0)
                        {
                            EventView view = new EventView();
                            view.eventID = E_ID;
                            view.G_ID = G_ID;
                            view.EH_ID = H_ID;
                            dbd.EventViews.InsertOnSubmit(view);
                            dbd.SubmitChanges();
                        return true;
                        }
                        else  //view already exist
                        {
                            return false;
                        }
                    }
               
            };
        }
    }
}
