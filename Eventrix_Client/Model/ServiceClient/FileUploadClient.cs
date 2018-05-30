using Eventrix_Client.Model;
using Eventrix_Client.Model.ClientDefinition;
using Newtonsoft.Json;
using OfficeOpenXml;
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
    public class FileUploadClient
    {
        string BASE_URL = "http://localhost:53056/FileUpload.svc/";


        public bool ImportData(string name,string surname,string email)
        {
            string json = null;
            try
            {
                WebClient webClient = new WebClient();
                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;
                json = webClient.UploadString(BASE_URL + "ImportData/" + name + "," + surname + "," + email, "PUT", "");
                if(json.Contains("Success"))
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        //Deletions
        public string deleteImagebyEventID(string id)
        {
            string json = null;
            try
            {
                WebClient webClient = new WebClient();
                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;
                json = webClient.UploadString(BASE_URL + "deleteImagebyEventID/" + id, "DELETE", "");
                return json;
            }
            catch
            {
                string res = "Failed";
                return res;
            }
        }

        //deleteQRCodeFileByTicketID
        public string deleteQRCodeFileByTicketID(string id)
        {
            string json = null;
            try
            {
                WebClient webClient = new WebClient();
                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;
                json = webClient.UploadString(BASE_URL + "deleteQRCodeFileByTicketID/" + id, "DELETE", "");
                return json;
            }
            catch
            {
                string res = "Failed";
                return res;
            }
        }

        //Insertions
        //saveQRCodeImage
        public int saveQRCodeImage(QRCodeImage image)
        {
            string response = null;
            string data = null;
                DataContractJsonSerializer ser = new DataContractJsonSerializer(
                    typeof(QRCodeImage));
                MemoryStream mem = new MemoryStream();
                ser.WriteObject(mem, image);
                data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
                WebClient webClient = new WebClient();
                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;
                response = webClient.UploadString(BASE_URL + "saveQRCodeImage", "POST", data);
            int ID = Convert.ToInt32(response);
                return ID;
        }

        //UpdateQRCode
        public bool UpdateQRCode(QRCodeImage image, string id)
        {
            string response = null;
            string data = null;
            bool isCreated = false;
            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(
                    typeof(QRCodeImage));
                MemoryStream mem = new MemoryStream();
                ser.WriteObject(mem, image);
                data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
                WebClient webClient = new WebClient();
                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;
                response = webClient.UploadString(BASE_URL + "UpdateQRCode/" + id, "PUT", data);
                isCreated = JsonConvert.DeserializeObject<bool>(response);
                return isCreated;
            }
            catch
            {
                return false;
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
        //Getters
        public List<ImageFile> getAllImages()
        {
            string json = null;
            List<ImageFile> acc = null;
            try
            {
                WebClient webClient = new WebClient();
                json = webClient.DownloadString(BASE_URL + "getAllImages");
                acc = JsonConvert.DeserializeObject<List<ImageFile>>(json);

                return acc;
            }
            catch
            {
                return null;
            }
        }

        public List<ImageFile> getMultipleImagesById(string eventID)
        {
            string json = null;
            List<ImageFile> acc = null;
            try
            {
                //getMultipleImagesById
                WebClient webClient = new WebClient();
                json = webClient.DownloadString(BASE_URL + "getMultipleImagesById/" + eventID);
                acc = JsonConvert.DeserializeObject<List<ImageFile>>(json);

                return acc;
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


        public string saveMultipleImages(List<ImageFile> imagesToUpload)
        {
            string response = null;
            string data = null;
            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(
                    typeof(List<ImageFile>));
                MemoryStream mem = new MemoryStream();
                ser.WriteObject(mem, imagesToUpload);
                data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
                WebClient webClient = new WebClient();
                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;
                response = webClient.UploadString(BASE_URL + "saveMultipleImages", "POST", data);

                return response;
            }
            catch
            {
                return null;
            }
        }


    }
}