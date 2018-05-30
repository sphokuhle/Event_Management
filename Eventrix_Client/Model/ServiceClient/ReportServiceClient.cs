using Eventrix_Client.Model.ClientDefinition;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace Eventrix_Client.Model.ServiceClient
{
    public class ReportServiceClient
    {
        string BASE_URL = "http://localhost:53056/ReportingService.svc/";
        //find event by host id
        public List<EventModel> findEventbyID(string hostID)
        {
            string json = null;
            List<EventModel> events = null;
            try
            {
                WebClient webClient = new WebClient();
                json = webClient.DownloadString(BASE_URL + "getAllEventsByHostID/" + hostID);
                events = JsonConvert.DeserializeObject<List<EventModel>>(json);
                return events;
            }
            catch
            {
                return null;
            }
        }
        //findallstaffbyHostID
        public List<StaffModel> findallstaffbyHostID(string id)
        {
            string json = null;
            List<StaffModel> staffList = null;
            try
            {
                WebClient webClient = new WebClient();
                json = webClient.DownloadString(BASE_URL + "findallstaffbyHostID/" + id);
                staffList = JsonConvert.DeserializeObject<List<StaffModel>>(json);
                return staffList;
            }
            catch
            {
                return null;
            }
        }
        //findallProductByHostID(string id)
        public List<ProductInfo> findallProductByHostID(string id)
        {
            string json = null;
            List<ProductInfo> products = null;
            try
            {
                WebClient webClient = new WebClient();
                json = webClient.DownloadString(BASE_URL + "findallProductByHostID/" + id);
                products = JsonConvert.DeserializeObject<List<ProductInfo>>(json);
                return products;
            }
            catch
            {
                return null;
            }
        }

        //Get Number of Ticket
        public List<int> GetTicketCountPerEvent(string eventID)
        {
            List<int> ticketList = new List<int>();
            string json = null;
            try
            {
                WebClient webClient = new WebClient();
                json = webClient.DownloadString(BASE_URL + "GetTicketCountPerEvent/" + eventID);
                ticketList = JsonConvert.DeserializeObject<List<int>>(json);
                return ticketList;
            }
            catch
            {
                return null;
            }
        }

        //GetMostUsedWorkstation
        //Get Number of Ticket
        public List<StaffModel> GetMostUsedWorkstation(string eventID)
        {
            List<StaffModel> staffList = new List<StaffModel>();
            string json = null;
            try
            {
                WebClient webClient = new WebClient();
                json = webClient.DownloadString(BASE_URL + "GetMostUsedWorkstation/" + eventID);
                staffList = JsonConvert.DeserializeObject<List<StaffModel>>(json);
                return staffList;
            }
            catch
            {
                return null;
            }
        }
        //GetMostCheckedinEntrance
        public List<StaffModel> GetMostCheckedinEntrance(string eventID)
        {
            List<StaffModel> staffList = new List<StaffModel>();
            string json = null;
            try
            {
                WebClient webClient = new WebClient();
                json = webClient.DownloadString(BASE_URL + "GetMostCheckedinEntrance/" + eventID);
                staffList = JsonConvert.DeserializeObject<List<StaffModel>>(json);
                return staffList;
            }
            catch
            {
                return null;
            }
        }

        //GetLatestView
        public string GetLatestView(string id, string type)
        {
            string json = null;
            string sDate = null;
            try
            {
                WebClient webClient = new WebClient();
                json = webClient.DownloadString(BASE_URL + "GetLatestView/" + id + "," + type);
                sDate = JsonConvert.DeserializeObject<string>(json);
                return sDate;
            }
            catch
            {
                return null;
            }
        }

        //RSVPGuest       
        public List<GuestModel> RSVPGuest(string eventID, string Type)
        {
            string json = null;
            List<GuestModel> data = new List<GuestModel>();
                try
                {
                    WebClient webClient = new WebClient();
                    json = webClient.DownloadString(BASE_URL + "RSVPGuest/" + eventID + ","+ Type);
                     data = JsonConvert.DeserializeObject<List<GuestModel>>(json);
                    return data;
                }
            catch
            {
                return null;
            }
        }

        //RSVPCount      
        public List<int> RSVPCount(string id)
        {
            string json = null;
            List<int> data = new List<int>();
            try
            {
                WebClient webClient = new WebClient();
                json = webClient.DownloadString(BASE_URL + "RSVPCount/" + id);
                data = JsonConvert.DeserializeObject<List<int>>(json);
                return data;
            }
            catch
            {
                return null;
            }
        }
    }
}