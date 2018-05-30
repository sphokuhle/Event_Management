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

namespace Eventrix_Client.Model.ServiceClient
{
    public class TicketServiceClient
    {
        string BASE_URL = "http://localhost:53056/TicketService.svc/";

        public string createTicket(EventTicket ticket)
        {
            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(
                   typeof(EventTicket));
                MemoryStream mem = new MemoryStream();
                ser.WriteObject(mem, ticket);
                string data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
                WebClient webClient = new WebClient();
                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;
                string response = webClient.UploadString(BASE_URL + "createTicket", "POST", data);

                return response;
            }
            catch (Exception)
            {
                return "fail";
            }

        }

        //updateTicket
        //string UpdateTiket(EventTicket _ticket)
        public string UpdateTiket(EventTicket ticket)
        {
            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(
                   typeof(EventTicket));
                MemoryStream mem = new MemoryStream();
                ser.WriteObject(mem, ticket);
                string data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
                WebClient webClient = new WebClient();
                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;
                string response = webClient.UploadString(BASE_URL + "UpdateTiket", "PUT", data);

                return response;
            }
            catch (Exception)
            {
                return "fail";
            }

        }

        //Update for purchase
        public int PurchaseTicket(EventTicket ticket)
        {

            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(
                   typeof(EventTicket));
                MemoryStream mem = new MemoryStream();
                ser.WriteObject(mem, ticket);
                string data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
                WebClient webClient = new WebClient();
                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;
            string response = webClient.UploadString(BASE_URL + "purchaseTicket", "POST", data);
             int strID  = JsonConvert.DeserializeObject<int>(response);
            int ID = strID;
                return ID;
            }
            catch (Exception)
            {
                return -1;
            }
        }
        //find ticket by host id
        public List<EventTicket> getTicketbyEventID(string ID)
        {
            string json = null;
            List<EventTicket> events = null;
            try
            {
                WebClient webClient = new WebClient();
                json = webClient.DownloadString(BASE_URL + "getTicketbyEventID/" + ID);
                events = JsonConvert.DeserializeObject<List<EventTicket>>(json);
                return events;
            }
            catch
            {
                return null;
            }
        }
        public EventTicket getVIPTicket(string ID)
        {
            string json = null;
            EventTicket ticket = null;
            try
            {
                WebClient webClient = new WebClient();
                json = webClient.DownloadString(BASE_URL + "getVIPTicket/" + ID);
                ticket = JsonConvert.DeserializeObject<EventTicket>(json);
                return ticket;
            }
            catch
            {
                return null;
            }
        }
        public EventTicket getVVIPTicket(string ID)
        {
            string json = null;
            EventTicket ticket = null;
            try
            {
                WebClient webClient = new WebClient();
                json = webClient.DownloadString(BASE_URL + "getVVIPTicket/" + ID);
                ticket = JsonConvert.DeserializeObject<EventTicket>(json);
                return ticket;
            }
            catch
            {
                return null;
            }
        }
        public EventTicket getEBTicket(string ID)
        {
            string json = null;
            EventTicket ticket = null;
            try
            {
                WebClient webClient = new WebClient();
                json = webClient.DownloadString(BASE_URL + "getEarlyBirdTicket/" + ID);
                ticket = JsonConvert.DeserializeObject<EventTicket>(json);
                return ticket;
            }
            catch
            {
                return null;
            }
        }
        public EventTicket getRegularTicket(string ID)
        {
            string json = null;
            EventTicket ticket = null;
            try
            {
                WebClient webClient = new WebClient();
                json = webClient.DownloadString(BASE_URL + "getRegularTicket/" + ID);
                ticket = JsonConvert.DeserializeObject<EventTicket>(json);
                return ticket;
            }
            catch
            {
                return null;
            }
        }

        //    public List<EventTicket> GetGuestTicketForEvent(string GuestID,string EventID)
        public List<EventTicket> GetGuestTicketForEvent(string GuestID, string EventID)
        {
            string json = null;
            List<EventTicket> ticket = null;
            try
            {
                WebClient webClient = new WebClient();
                json = webClient.DownloadString(BASE_URL + "GetGuestTicketForEvent/" + GuestID + "," + EventID);
                ticket = JsonConvert.DeserializeObject<List<EventTicket>>(json);
                return ticket;
            }
            catch
            {
                return null;
            }
        }

        //deletes by inner join
        public string dl_QRCodeByEventID(string evnetID)  //delete QRCode
        {
            string json = null;
            try
            {
                WebClient webClient = new WebClient();
                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;
                json = webClient.UploadString(BASE_URL + "deleteQRCodeByEventID/" + evnetID, "DELETE", "");
                return json;
            }
            catch
            {
                string res = "failed";
                return res;
            }
        }

        public string dl_GuestTicket_BT_ByEventID(string evnetID)  //delete Guest ticket bridging table
        {
            string json = null;
            try
            {
                WebClient webClient = new WebClient();
                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;
                json = webClient.UploadString(BASE_URL + "delete_Guest_Ticket_ByEventID/" + evnetID, "DELETE", "");
                return json;
            }
            catch
            {
                string res = "failed";
                return res;
            }
        }
        public string dl_TicketTemplate_byEventID(string evnetID)  //delete ticket template
        {
            string json = null;
            try
            {
                WebClient webClient = new WebClient();
                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;
                json = webClient.UploadString(BASE_URL + "deleteTicketTemplateByEventID/" + evnetID, "DELETE", "");
                return json;
            }
            catch
            {
                string res = "failed";
                return res;
            }
        }

        //dl_BT_AND_QRCode
        public string dl_BT_AND_QRCode(string G_ID, string EventID)  //delete bridging table as well as QRCodes
        {
            string json = null;
            int NumDeleted = 0;
            try
            {
                WebClient webClient = new WebClient();
                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;
                json = webClient.UploadString(BASE_URL + "dl_BT_AND_QRCode/" + G_ID + "," + EventID, "DELETE", "");
                NumDeleted = JsonConvert.DeserializeObject<int>(json);
                return json;
            }
            catch
            {
                return "failed";
            }
        }

        //UploadCredit(EventTicket _ticket)
        public string LoadCredits(EventTicket ticket)
        {
            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(
                   typeof(EventTicket));
                MemoryStream mem = new MemoryStream();
                ser.WriteObject(mem, ticket);
                string data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
                WebClient webClient = new WebClient();
                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;
                string response = webClient.UploadString(BASE_URL + "UploadCredit", "PUT", data);
                if(response.ToLower().Contains("true"))
                {
                    return "success";
                }else
                {
                    return "failed";
                }
            }
            catch (Exception)
            {
                return "fail";
            }
        }
    }
}