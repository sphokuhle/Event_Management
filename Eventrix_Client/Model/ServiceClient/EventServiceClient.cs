using Eventrix_Client.Model.ClientDefinition;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;

namespace Eventrix_Client.Model.ServiceClient
{
    public class EventServiceClient
    {
        string BASE_URL = "http://localhost:53056/EventService.svc/";

        public string createEvent(EventModel _event)
        {
            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(
                    typeof(EventModel));
                MemoryStream mem = new MemoryStream();
                ser.WriteObject(mem, _event);
                string data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
                WebClient webClient = new WebClient();
                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;
                string response = webClient.UploadString(BASE_URL + "createEvent", "POST", data);

                return response;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public int findEventID(EventModel _event)
        {
            try
            {
                _event.Start_Date = DateTime.Now;
                DataContractJsonSerializer ser = new DataContractJsonSerializer(
                   typeof(EventModel));
                MemoryStream mem = new MemoryStream();
                ser.WriteObject(mem, _event);
                string data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
                WebClient webClient = new WebClient();
                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;
                string response = webClient.UploadString(BASE_URL + "findEventID", "POST", data);
                int ID = Convert.ToInt32(response);
                return ID;
            }
            catch
            {
                return 000;
            }
        }

        //find event by host id
        public List<EventModel> findEventbyID(string hostID,string GuestID)
        {
            string json = null;
            List<EventModel> events = null;
            try
            {
                WebClient webClient = new WebClient();
                json = webClient.DownloadString(BASE_URL + "getAllEventsByHostID/" + hostID + "," + GuestID);
                events = JsonConvert.DeserializeObject<List<EventModel>>(json);
                return events;
            }
            catch
            {
                return null;
            }
        }

        //Record RSVP
        //InsertOTP
        public bool RecordRSVP(string eventID, string GuestID, string Status)
        {
            bool response = false;
            string res = "";
          
                WebClient webClient = new WebClient();
                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;
                res = webClient.UploadString(BASE_URL + "RecordRSVP/" + eventID + "," + GuestID + "," + Status, "POST", "");
                response = JsonConvert.DeserializeObject<bool>(res);

                return response;
           
        }


        //public List<EventModel> GuestLiveEvent(string Guest_ID)
        //find event by host id
        public List<EventModel> GuestLiveEvent( string GuestID)
        {
            string json = null;
            List<EventModel> events = null;
            try
            {
                WebClient webClient = new WebClient();
                json = webClient.DownloadString(BASE_URL + "GuestLiveEvent/" + GuestID);
                events = JsonConvert.DeserializeObject<List<EventModel>>(json);
                return events;
            }
            catch
            {
                return null;
            }
        }

        //findGuestEventsByGuestID(string guest_ID)
        //find event by host id
        public EventModel findGuestEventsByGuestID(string ID)
        {
            string json = null;
            EventModel events = null;
            try
            {
                WebClient webClient = new WebClient();
                json = webClient.DownloadString(BASE_URL + "findGuestEventsByGuestID/" + ID);
                events = JsonConvert.DeserializeObject<EventModel>(json);
                return events;
            }
            catch
            {
                return null;
            }
        }
        //find event by event id
        public EventModel findByEventID(string ID)
        {
            string json = null;
            EventModel events = null;
          
                WebClient webClient = new WebClient();
                json = webClient.DownloadString(BASE_URL + "getEventByEventID/" + ID);
                events = JsonConvert.DeserializeObject<EventModel>(json);
                return events;
           
        }

        public List<EventModel> findAllEvent()
        {
            string json = null;
            List<EventModel> events = null;
            try
            {
                WebClient webClient = new WebClient();
                json = webClient.DownloadString(BASE_URL + "getAllEvents");
                events = JsonConvert.DeserializeObject<List<EventModel>>(json);
                return events;
            }
            catch
            {
                return null;
            }
        }

        public string deleteEventByID(string EventID)
        {
            string json = null;
            try
            {
                WebClient webClient = new WebClient();
                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;
                json = webClient.UploadString(BASE_URL + "deleteEventByID/" + EventID, "DELETE", "");
                return json;
            }
            catch
            {
                string res = "Failed";
                return res;
            }
        }

        //upDateEvent
        //updateEvent
        public EventModel updateEvent(EventModel _event,string id)
        {
            _event.Start_Date = DateTime.Now;
            string response = null;
            string data = null;
            EventModel newEvent = null;
            try
            {
                newEvent = new EventModel();
                DataContractJsonSerializer ser = new DataContractJsonSerializer(
                    typeof(EventModel));
                MemoryStream mem = new MemoryStream();
                ser.WriteObject(mem, _event);
                data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
                WebClient webClient = new WebClient();
                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;
                response = webClient.UploadString(BASE_URL + "updateEvent/" + id, "PUT", data);
                newEvent = JsonConvert.DeserializeObject<EventModel>(response);
                return newEvent;
            }
            catch
            {
                return null;
            }
        }
        //addEventView(string eventID, string view)
        //updateEvent
        public bool addEventView(EventModel _event)
        {
            string response = null;
            string data = null;
            bool isAdded = false;
            DateTime dDate = DateTime.Now;
            _event.eDate = Convert.ToString(dDate);
            _event.sDate = Convert.ToString(dDate);
            _event.Start_Date = DateTime.Now;

            DataContractJsonSerializer ser = new DataContractJsonSerializer(
                    typeof(EventModel));
                MemoryStream mem = new MemoryStream();
                ser.WriteObject(mem, _event);
                data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
                WebClient webClient = new WebClient();
                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;
                response = webClient.UploadString(BASE_URL + "addEventView", "PUT", data);
                if(response.ToLower().Contains("true"))
                {
                    isAdded = true;
                }else
                {
                    isAdded = false;
                }
                return isAdded;
        }

        //RecordView
        public bool RecordView(EventViews _views)
        {
            string response = null;
            string data = null;
            bool isAdded = false;
           
            DataContractJsonSerializer ser = new DataContractJsonSerializer(
                typeof(EventViews));
            MemoryStream mem = new MemoryStream();
            ser.WriteObject(mem, _views);
            data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
            WebClient webClient = new WebClient();
            webClient.Headers["Content-type"] = "application/json";
            webClient.Encoding = Encoding.UTF8;
            response = webClient.UploadString(BASE_URL + "RecordView", "PUT", data);
            if (response.ToLower().Contains("true"))
            {
                isAdded = true;
            }
            else
            {
                isAdded = false;
            }
            return isAdded;
        }

        //ViewsStat(string eventID, string Type)
        //find event by host id
        public int GetNumViews(string eventID, string Type)
        {
            string json = null;
            int event_view = 0;
            try
            {
                WebClient webClient = new WebClient();
                json = webClient.DownloadString(BASE_URL + "ViewsStat/" + eventID + "," + Type);
                event_view = JsonConvert.DeserializeObject<int>(json);
                return event_view;
            }
            catch
            {
                return 0;
            }
        }

    }
}