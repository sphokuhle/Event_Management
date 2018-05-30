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
    public partial class GuestEventList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //int loggedID = Convert.ToInt32(Session["ID"]);

            //ImageFile img = new ImageFile();
            //FileUploadClient fuc = new FileUploadClient();
            //GuestServiceClient gsc = new GuestServiceClient();
            //EventServiceClient esc = new EventServiceClient();
            //List<EventModel> newEvent = new List<EventModel>();
            //newEvent = esc.findEventbyID("0", Convert.ToString(Session["ID"]));
            //if(newEvent != null)
            //{
            //    string htmltag = "";
            //    foreach (EventModel em in newEvent)
            //    {
            //        string output = "";
            //        string imgLocation = "";
            //        string EventID = Convert.ToString(em.EventID);
            //        img = fuc.getImageById(EventID);
            //        if (img == null)
            //        {
            //            output = "Events/Eventrix_Default_Image.png";
            //        }
            //        else
            //        {
            //            imgLocation = img.Location;
            //            output = imgLocation.Substring(imgLocation.IndexOf('E')); //trim string path from Event
            //        }
            //        htmltag += "<div class='portfolio-item col-sm-6 col-md-4' data-groups='['all', 'numbers', 'blue', 'square']'>";
            //        htmltag += "<div class='single-portfolio'>";
            //        htmltag += "<img src='" + output + "' alt=''>";
            //        htmltag += "<div class='portfolio-links'>";
            //        htmltag += "<a class='image-link' href='" + output + "'><i class='fa fa-search-plus'></i></a>";
            //        htmltag += "<a href='EventDetails.aspx?EventID=" + em.EventID + "'><i class='fa fa-link'></i></a>";
            //        htmltag += "<li class='fa fa-link'>";
            //        htmltag += "<a href='#' style='font-size: 18px;";
            //        htmltag += "font-family: 'Roboto', sans-serif";
            //        htmltag += "color: white;'>";
            //        htmltag += "<p>" + em.Name + "</p>";
            //        htmltag += "<p>" + em.sDate + " </p></a>";
            //        htmltag += "</li>";
            //        htmltag += "</div><!-- /.links -->";
            //        htmltag += "</div><!-- /.single-portfolio -->";
            //        htmltag += "</div><!-- /.portfolio-item -->";
            //    }
            //    grid.InnerHtml = htmltag;
            //}
           
        }
    }
}