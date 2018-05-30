using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;

namespace Eventrix_Client.Model
{
    public class UpdateClient
    {
        private string BASE_URL = "http://localhost:53056/Update.svc/";
        //Update
        public string updateAccommo(string id, UpdateModel accommo)
        {
            string response = null;
            string data = null;
            UpdateModel acc = null;
            try
            {
                acc = new UpdateModel();
                DataContractJsonSerializer ser = new DataContractJsonSerializer(
                    typeof(UpdateModel));
                MemoryStream mem = new MemoryStream();
                ser.WriteObject(mem, accommo);
                data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
                WebClient webClient = new WebClient();
                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;
                response = webClient.UploadString(BASE_URL + "updateTester/" + id, "PUT", data);
              //   acc = JsonConvert.DeserializeObject<UpdateModel>(response);

                return response;
            }
            catch
            {
                return null;
            }
        }
    }
}