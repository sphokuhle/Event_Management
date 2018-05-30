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
    public class GuestSvcClient
    {
        string BASE_URL = "http://localhost:53056/GuestEdit.svc/";

        //Retrieve guest
        public GuestModel getGuestByGuestID(string ID)
        {
            string json = null;
            GuestModel guest = null;
            try
            {
                WebClient webClient = new WebClient();
                json = webClient.DownloadString(BASE_URL + "getGuestByGuestID/" + ID);
                guest = JsonConvert.DeserializeObject<GuestModel>(json);
                return guest;
            }
            catch
            {
                return null;
            }
        }

        //Edit Guest
        public GuestModel updateGuest(string id, GuestModel _guest)
        {
            string response = null;
            string data = null;
            try
            {
                GuestModel newGuest = new GuestModel();
                DataContractJsonSerializer ser = new DataContractJsonSerializer(
                    typeof(GuestModel));
                MemoryStream mem = new MemoryStream();
                ser.WriteObject(mem, _guest);
                data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
                WebClient webClient = new WebClient();
                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;
                response = webClient.UploadString(BASE_URL + "updateGuest/" + id, "PUT", data);
                newGuest = JsonConvert.DeserializeObject<GuestModel>(response);
                return newGuest;
            }
            catch
            {
                return null;
            }
        }

        public string saveImage(ImageFile image)
        {
            string response = null;
            string data = null;
            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(
                    typeof(ImageFile));
                MemoryStream mem = new MemoryStream();
                ser.WriteObject(mem, image);
                data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
                WebClient webClient = new WebClient();
                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;
                response = webClient.UploadString(BASE_URL + "saveImage", "POST", data);

                return response;
            }
            catch
            {
                return null;
            }
        }

        public ImageFile getImageById(string fileId)
        {
            string json = null;
            ImageFile acc = null;
            try
            {
                WebClient webClient = new WebClient();
                json = webClient.DownloadString(BASE_URL + "getImageById/" + fileId);
                acc = JsonConvert.DeserializeObject<ImageFile>(json);

                return acc;
            }
            catch
            {
                return null;
            }
        }

        //Deletions
        public string deleteImagebyGuestID(string id)
        {
            string json = null;
            try
            {
                WebClient webClient = new WebClient();
                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;
                json = webClient.UploadString(BASE_URL + "deleteImagebyGuestID/" + id, "DELETE", "");
                return json;
            }
            catch
            {
                string res = "Failed";
                return res;
            }
        }
    }
}