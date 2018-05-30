using Eventrix_Client.Model.ClientDefinition;
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
    public class ProductServiceClient
    {
        string BASE_URL = "http://localhost:53056/ProductService.svc/";

        public string createProduct(EventProduct product)
        {
            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(
                   typeof(EventProduct));
                MemoryStream mem = new MemoryStream();
                ser.WriteObject(mem, product);
                string data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
                WebClient webClient = new WebClient();
                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;
                string response = webClient.UploadString(BASE_URL + "createProduct", "POST", data);

                return response;
            }
            catch
            {
                return null;
            }
        }

        //EditProduct
        public bool EditProduct(EventProduct _product)
        {
            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(EventProduct));
                MemoryStream mem = new MemoryStream();
                ser.WriteObject(mem, _product);
                string data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
                WebClient webclient = new WebClient();
                webclient.Headers["Content-type"] = "application/json";
                webclient.Encoding = Encoding.UTF8;
                string res = webclient.UploadString(BASE_URL + "EditProduct", "PUT", data);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public List<EventProduct> findAllProducts()
        {
            try
            {
                var webclient = new WebClient();
                var json = webclient.DownloadString(BASE_URL + "findallproduct");
                var js = new JavaScriptSerializer();
                return js.Deserialize<List<EventProduct>>(json);
            }
            catch
            {
                return null;
            }
        }

        public List<EventProduct> getProductByEventID(string EventID)
        {
            try
            {
                var webclient = new WebClient();
                var json = webclient.DownloadString(BASE_URL + "getProductByEventID/" + EventID);
                var js = new JavaScriptSerializer();
                return js.Deserialize<List<EventProduct>>(json);
            }
            catch
            {
                return null;
            }
        }

        public string DeleteProductByEventID(string EventID)
        {
            string json = null;
            try
            {
                WebClient webClient = new WebClient();
                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;
                json = webClient.UploadString(BASE_URL + "deleteProductByID/" + EventID, "DELETE", "");
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