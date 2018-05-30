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

namespace Eventrix_Client.Model
{
    public class StaffServiceClient
    {
        string BASE_URL = "http://localhost:53056/ServiceStaff.svc/";

        public List<StaffModel> findAllStaff()
        {
            try
            {
                var webclient = new WebClient();
                var json = webclient.DownloadString(BASE_URL + "findallstaff");
                var js = new JavaScriptSerializer();
                return js.Deserialize<List<StaffModel>>(json);
            }
            catch
            {
                return null;
            }
        }
        public StaffModel StaffLogin(string email, string pass)
        {
            StaffModel _staff = new StaffModel();
            try
            {
                var webclient = new WebClient();
                string url = string.Format(BASE_URL + "staffLogin/{0}", email);
                var json = webclient.DownloadString(url);
                var js = new JavaScriptSerializer();
                _staff = js.Deserialize<StaffModel>(json);
                if (_staff.PASS.Equals(pass))
                {
                    return _staff;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }
        public StaffModel findStaffbyID(string id)
        {
            try
            {
                var webclient = new WebClient();
                string url = string.Format(BASE_URL + "findStaffbyID/{0}", id);
                var json = webclient.DownloadString(url);
                var js = new JavaScriptSerializer();
                return js.Deserialize<StaffModel>(json);
            }
            catch
            {
                return null;
            }
        }

        public bool createStaff(StaffModel _staff)
        {
            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(
                   typeof(StaffModel));
                MemoryStream mem = new MemoryStream();
                ser.WriteObject(mem, _staff);
                string data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
                WebClient webClient = new WebClient();
                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;
                string response = webClient.UploadString(BASE_URL + "createStaff", "POST", data);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public string deleteStaffByEventID(string id)
        {
            string json = null;
            try
            {
                WebClient webClient = new WebClient();
                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;
                json = webClient.UploadString(BASE_URL + "deleteStaffByEventID/" + id, "DELETE", "");
                return json;
            }
            catch
            {
                string res = "Failed";
                return res;
            }
        }

        //find event by host id
        public List<StaffModel> findStaffbyEventID(string ID)
        {
            string json = null;
            List<StaffModel> events = null;
            try
            {
                WebClient webClient = new WebClient();
                json = webClient.DownloadString(BASE_URL + "getAllStaffbyID/" + ID);
                events = JsonConvert.DeserializeObject<List<StaffModel>>(json);
                return events;
            }
            catch
            {
                return null;
            }
        }
        //updateSTaff
        public bool updateStaff(StaffModel staff, string id)
        {
            string response = null;
            string data = null;
            StaffModel _staff = null;
            try
            {
                _staff = new StaffModel();
                DataContractJsonSerializer ser = new DataContractJsonSerializer(
                    typeof(StaffModel));
                MemoryStream mem = new MemoryStream();
                ser.WriteObject(mem, staff);
                data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
                WebClient webClient = new WebClient();
                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;
                response = webClient.UploadString(BASE_URL + "updateSTaff/" + id, "PUT", data);
                _staff = JsonConvert.DeserializeObject<StaffModel>(response);
                if(_staff != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
             //   return _staff;
            }
            catch
            {
                return false;
            }
        }
    }
}