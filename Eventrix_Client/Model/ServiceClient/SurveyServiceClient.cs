using Eventrix_Client.Model.ClientDefinition;
using Eventrix_Client.Model.ClientDefinition.Survey;
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
    public class SurveyServiceClient
    {
        string BASE_URL = "http://localhost:53056/SurveyService.svc/";

        public int createSurvey(Survey _surv)
        {
            int ID = 0;
            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(
                    typeof(Survey));
                MemoryStream mem = new MemoryStream();
                ser.WriteObject(mem, _surv);
                string data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
                WebClient webClient = new WebClient();
                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;
                string json = webClient.UploadString(BASE_URL + "createAnswers", "POST", data);
                ID = JsonConvert.DeserializeObject<int>(json);
                return ID;
            }
            catch
            {
                return 0;
            }
        }

        //find event by host id
        //GetAnswer(string type, string eventID)
        public List<Survey> FindRecord(string type, string eventID)
        {
            string json = null;
            List<Survey> items = null;
            try
            {
                WebClient webClient = new WebClient();
                json = webClient.DownloadString(BASE_URL + "GetAnswer/" + type + "," + eventID);
                items = JsonConvert.DeserializeObject<List<Survey>>(json);
                return items;
            }
            catch
            {
                return null;
            }
        }

        //Helper Function
        public bool record(Survey _surv, string functionName)
        {
            bool isCreated = false;
            string response = null;
            string data = null;

            DataContractJsonSerializer ser = new DataContractJsonSerializer(
                typeof(Survey));
            MemoryStream mem = new MemoryStream();
            ser.WriteObject(mem, _surv);
            data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
            WebClient webClient = new WebClient();
            webClient.Headers["Content-type"] = "application/json";
            webClient.Encoding = Encoding.UTF8;
            response = webClient.UploadString(BASE_URL + functionName, "PUT", data);
            isCreated = JsonConvert.DeserializeObject<bool>(response);
            return isCreated;
        }

        public bool Rec_Date(Survey _surv)
        {
            bool isAdded = false;
            isAdded = record(_surv, "Rec_Date");
            return isAdded;
        }
        public bool Rec_FirstTime(Survey _surv)
        {
            bool isAdded = false;
            isAdded = record(_surv, "Rec_FirstTime");
            return isAdded;
        }
        public bool Rec_FutureAttendence(Survey _surv)
        {
            bool isAdded = false;
            isAdded = record(_surv, "Rec_FutureAttendence");
            return isAdded;
        }
        public bool Rec_Food(Survey _surv)
        {
            bool isAdded = false;
            isAdded = record(_surv, "Rec_Food");
            return isAdded;
        }
        //Rec_Location
        public bool Rec_Location(Survey _surv)
        {
            bool isAdded = false;
            isAdded = record(_surv, "Rec_Location");
            return isAdded;
        }
        public bool Rec_Long_Quiz(Survey _surv)
        {
            bool isAdded = false;
            isAdded = record(_surv, "Rec_Long_Quiz");
            return isAdded;
        }
        public bool Rec_Overall_Satisfaction(Survey _surv)
        {
            bool isAdded = false;
            isAdded = record(_surv, "Rec_Overall_Satisfaction");
            return isAdded;
        }
        public bool Rec_Recommendation(Survey _surv)
        {
            bool isAdded = false;
            isAdded = record(_surv, "Rec_Recommendation");
            return isAdded;
        }
        //Rec_Session
        public bool Rec_Session(Survey _surv)
        {
            bool isAdded = false;
            isAdded = record(_surv, "Rec_Session");
            return isAdded;
        }
        public bool Rec_Speaker(Survey _surv)
        {
            bool isAdded = false;
            isAdded = record(_surv, "Rec_Speaker");
            return isAdded;
        }
        //Rec_Vendor
        public bool Rec_Vendor(Survey _surv)
        {
            bool isAdded = false;
            isAdded = record(_surv, "Rec_Vendor");
            return isAdded;
        }
    }
}