using Eventrix_Client.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;

namespace Eventrix_Client
{
    public class UserLogin
    {
        private string BASE_URL = "http://localhost:53056/LoginService.svc/";

        public EventHostModel hostLogin(string email, string password)
        {
            EventHostModel person = new EventHostModel();
            string json = null;
            JavaScriptSerializer js = null;
            try
            {
                WebClient webClient = new WebClient();
                json = webClient.DownloadString(BASE_URL + "hostlogin?email=" + email + "&password=" + password);
                js = new JavaScriptSerializer();
                person = JsonConvert.DeserializeObject<EventHostModel>(json);
                return person;
            }
            catch
            {
                return null;
            }
        }

        public GuestModel Guestlogin(string email, string password)
        {
            GuestModel person = new GuestModel();
            string json = null;
            JavaScriptSerializer js = null;
            try
            {
                WebClient webClient = new WebClient();
                json = webClient.DownloadString(BASE_URL + "guestlogin?email=" + email + "&password=" + password);
                js = new JavaScriptSerializer();
                person = JsonConvert.DeserializeObject<GuestModel>(json);
                return person;
            }
            catch
            {
                return null;
            }
        }

        public StaffModel staffLogin(string email, string password)
        {
            StaffModel person = new StaffModel();
            string json = null;
            JavaScriptSerializer js = null;
            try
            {
                WebClient webClient = new WebClient();
                json = webClient.DownloadString(BASE_URL + "stafflogin?email=" + email + "&password=" + password);
                js = new JavaScriptSerializer();
                person = JsonConvert.DeserializeObject<StaffModel>(json);
                return person;
            }
            catch
            {
                return null;
            }
        }

    }
}