using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace Eventrix_Client.Model.ServiceClient
{
    public class ScanningServiceClient
    {
        public string BASE_URL = "http://localhost:53056/ScanningService.svc/";
        //updateQRCode(QRCodeImage image)
        //CheckInGuest
        //find event by event id
        public bool CheckInGuest(string ID)
        {
            string json = null;
            bool isUpdated = true;
            try
            {
                WebClient webClient = new WebClient();
                json = webClient.DownloadString(BASE_URL + "CheckInGuest/" + ID);
                isUpdated = JsonConvert.DeserializeObject<bool>(json);
                if(isUpdated)
                {
                    return true;
                }else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        //PurchaseProduct
        public bool PurchaseProduct(string ID, string ProductID)
        {
            string json = null;
            string isUpdated = "" ;
            try
            {
                WebClient webClient = new WebClient();
                json = webClient.DownloadString(BASE_URL + "PurchaseProduct/" + ID + "," + ProductID);
                isUpdated = JsonConvert.DeserializeObject<string>(json);
                if (isUpdated.ToLower().Contains("success"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}