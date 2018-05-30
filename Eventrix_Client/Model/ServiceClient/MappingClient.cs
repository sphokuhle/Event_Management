using Eventrix_Client.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;

namespace Eventrix_Client
{
    public class MappingClient
    {
         string BASE_URL = "http://localhost:53056/MappingService.svc/";

        //insertions
        public int createAddress(EventAddress address)
        {
            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(
                   typeof(EventAddress));
                MemoryStream mem = new MemoryStream();
                ser.WriteObject(mem, address);
                string data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
                WebClient webClient = new WebClient();
                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;
                string response = webClient.UploadString(BASE_URL + "createAddress", "POST", data);
                int ID = JsonConvert.DeserializeObject<int>(response);
              //  int ID = Convert.ToInt32(response);
                return ID;
            }
            catch
            {
                return 000;
            }
        }

        //getters
        public EventAddress getAddressById(string id)
        {
            string json = null;
            EventAddress addr = new EventAddress();
            try
            {
                WebClient webClient = new WebClient();
                json = webClient.DownloadString(BASE_URL + "getAddressById/" + id);
                addr = JsonConvert.DeserializeObject<EventAddress>(json);
                return addr;
            }
            catch
            {
                return null;
            }
        }

        public List<EventAddress> getAllAddresses()
        {
           // string json = null;
           // List<EventAddress> addr = null;
            try
            {
                WebClient webClient = new WebClient();
                string json = webClient.DownloadString(BASE_URL + "getAllAddresses");
                List<EventAddress> addr = JsonConvert.DeserializeObject<List<EventAddress>>(json);

                return addr;
            }
            catch
            {
                return null;
            }
        }

        public EventAddress EditAddress(EventAddress _address,string id)
        {  //updateAddress
            string response = null;
            string data = null;
            EventAddress newAdd = null;
            try
            {
                newAdd = new EventAddress();
                DataContractJsonSerializer ser = new DataContractJsonSerializer(
                    typeof(EventAddress));
                MemoryStream mem = new MemoryStream();
                ser.WriteObject(mem, _address);
                data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
                WebClient webClient = new WebClient();
                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;
                response = webClient.UploadString(BASE_URL + "updateAddress/" + id, "PUT", data);
                newAdd = JsonConvert.DeserializeObject<EventAddress>(response);

                return newAdd;
            }
            catch
            {
                return null;
            }
        }

        //deleteAddressByID(string ID)
        public void deleteAddressByID(string ID)
        {
            string json = null;
            try
            {
                WebClient webClient = new WebClient();
                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;
                json = webClient.UploadString(BASE_URL + "deleteAddressByID/" + ID, "DELETE", "");
              //  return json;
            }
            catch(Exception)
            {
                string res = "Failed";
             //   return res;
            }
        }

        public List<string> getLatLong(string street, string town, string city)
        {
            string json = null;
            List<string> LatLong = null;
            try
            {
                WebClient webClient = new WebClient();
                json = webClient.DownloadString(BASE_URL + "getLatLong/" + street + "," + town + "," + city);
                LatLong = JsonConvert.DeserializeObject<List<string>>(json);

                return LatLong;
            }
            catch
            {
                return null;
            }
        }
    }
}