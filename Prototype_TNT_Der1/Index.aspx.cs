using Eventrix_Client;
using Eventrix_Client.Model;
using Eventrix_Client.Model.ClientDefinition;
using Eventrix_Client.Model.ServiceClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Prototype_TNT_Der1
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string UserLevel = Convert.ToString(Session["Level"]);
            //UserLevel
            //<a class="btn btn-primary" href="AllEventList.aspx">More Events</a>
          
            if (UserLevel.Equals("Guest"))
            {
                int UserID = Convert.ToInt32(Session["ID"]);
                MoreEvents.InnerHtml = "<a class='btn btn-primary' href='GuestManagement.aspx?GuestID=" + UserID + "'>More Events</a>";
                homeTitle.InnerHtml = "My Upcoming Events";
                string slider = "";
                slider += "<div class='item active'>";
                slider += "<img src='img/home/home-guest-1.jpg' alt='Hero Slide'/>";
                slider += "<div class='container'>";
                slider += "<div class='carousel-caption'>";
                slider += "<h1 class='animated lightSpeedIn'>Keep up to date.";
                slider += "<br/>";
                slider += "Attend Eventrix sponsored Events</h1><br/>";
                slider += "<p class='lead animated lightSpeedIn'>";
                slider += " ";
               slider += " ";
                slider += "</p>";
                slider += "</div>";
                slider += "</div>";
                slider += "</div>";

                slider += "<div class='item'>";
                slider += "<img src='img/home/home-general-1.jpg' alt='Hero Slide'/>";
                slider += "<div class='container'>";
                slider += "<div class='carousel-caption'>";
                slider += "<h1 class='animated bounceIn'>Load up credits for your";
                slider += "<br />";
                slider += "QR Code Ticket</h1>";
                slider += "<p class='lead animated bounceIn'>Explore eventrix to learn, attend and explore a variety of events all over South Africa</p>";
                slider += "</div>";
                slider += "</div>";
                slider += "</div>";
                homeSlider.InnerHtml = slider;
            }
            else if(UserLevel.Equals("Host"))
            {
                //         homeTitle.InnerHtml = "My Upcoming Events";
                int UserID = Convert.ToInt32(Session["ID"]);
                MoreEvents.InnerHtml = "<a class='btn btn-primary' href='EventManagement.aspx?HostID= " + UserID + "'>More Events</a>";
                homeTitle.InnerHtml = "My Upcoming Events";
                string slider = "";
                slider += "<div class='item active'>"; 
                slider += "<img src='img/home/QR-Code-image.png' alt='Hero Slide'/>";
               slider += "<div class='container'>";
                slider += "<div class='carousel-caption'>";
                slider += "<h1 class='animated lightSpeedIn'>Manage Your Event";
                slider += "<br/>";
                slider += "With Efficiency</h1>";
                slider += "<p class='lead animated lightSpeedIn'>";
                slider += "Create your event online, and try our smart guest import to invite guests.";
                slider += "Then send customized email invites with QR codes to your guests.";
                slider += "</p>";
                slider += "</div>";
                   slider += "</div>";
                slider += "</div>";
              
                slider += "<div class='item'>";
                slider += "<img src='img/home/home-image-02.png' alt='Hero Slide'/>";
                slider += "<div class='container'>";
                slider += "<div class='carousel-caption'>";
                slider += "<h1 class='animated bounceIn'>Check-in Guest And";
                slider += "<br />";
                slider += "Monitor Your Event</h1>";
                slider += "<p class='lead animated bounceIn'>Synchorinize your guest list and monitor arrivals on the device, get full analytics for your event in real time.</p>";
                slider += "</div>";
                slider += "</div>";
                slider += "</div>";
                homeSlider.InnerHtml = slider;
            }
            else
            {
                MoreEvents.InnerHtml = "<a class='btn btn-primary' href='AllEventList.aspx'>More Events</a>";
                homeTitle.InnerHtml = "Upcoming Events";
                string slider = "";
                slider += "<div class='item active'>";
                slider += "<img src='img/home/home-image-02.png' alt='Hero Slide'/>";
                slider += "<div class='container'>";
                slider += "<div class='carousel-caption'>";
                slider += "<h1 class='animated lightSpeedIn'>Manage Your Event";
                slider += "<br/>";
                slider += "With Efficiency</h1>";
                slider += "<p class='lead animated lightSpeedIn'>";
                slider += "Create your event online, and try our smart guest import to invite guests.";
                slider += "Then send customized email invites with QR codes to your guests.";
                slider += "</p>";
                slider += "</div>";
                slider += "</div>";
                slider += "</div>";

                slider += "<div class='item'>";
                slider += "<img src='img/home/home-host-1.jpg' alt='Hero Slide'/>";

                slider += "<div class='container'>";
                slider += "<div class='carousel-caption'>";
                slider += "<h1 class='animated bounceIn'>Check-in Guest And";
                slider += "<br />";
                slider += "Monitor Your Event</h1>";
                slider += "<p class='lead animated bounceIn'>Synchorinize your guest list and monitor arrivals on the device, get full analytics for your event in real time.</p>";
                slider += "</div>";
                slider += "</div>";
                slider += "</div>";
                homeSlider.InnerHtml = slider;
            }
        }
    }
}