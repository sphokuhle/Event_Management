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
    public partial class GuestTicketList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //int loggedID = Convert.ToInt32(Session["ID"]);

            ////Service Client methods
            //FileUploadClient fuc = new FileUploadClient();
            //GuestServiceClient gsc = new GuestServiceClient();
            //EventServiceClient esc = new EventServiceClient();
            //TicketServiceClient tsc = new TicketServiceClient();
            ////Service Client Definitions
            //ImageFile img = new ImageFile();
            //EventModel _events = new EventModel();

            //List<EventModel> newEvent = new List<EventModel>();
            //List<EventTicket> eventTickets = new List<EventTicket>();
            //newEvent = esc.findEventbyID("0", Convert.ToString(Session["ID"]));

            //if (_events != null)
            //{
            //    string htmltag = "";
            //    int JsCounter = 0;
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
            //        htmltag += "<div class='media'>";
            //        htmltag += "<div class='media-left'>";
            //        htmltag += "<a href='EventDetails.aspx?EventID=" + em.EventID + "'>";
            //        htmltag += "<img class='media-object' src='" + output + "' alt='' style='height: 300px; width: 300px;'> </a></div>";
            //        htmltag += "<div class='media-body'>";
            //        htmltag += "<h2 class='media-heading'>" + em.Name + "</h2>";
            //        htmltag += "<span>" + em.sDate + " till " + em.eDate + "</span>";

            //        //TICKET SECTION
            //        //get event tickets;
            //        eventTickets = tsc.GetGuestTicketForEvent(Convert.ToString(Session["ID"]), Convert.ToString(em.EventID));
            //        if (eventTickets != null)
            //        {
            //            htmltag += "<br/>";
            //            htmltag += "<div class='typography-page-tab' role='tabpanel'>";
            //            htmltag += "<ul class='nav nav-tabs' role='tablist'>";
            //            foreach (EventTicket ticket in eventTickets)
            //            {
            //                if (ticket._Type.ToLower().Equals("early bird"))
            //                {
            //                    htmltag += "<li role='presentation' class='active'><a href='#EB" + JsCounter + "' aria-controls='home' role='tab' data-toggle='tab'>Early Bird</a></li>";
            //                }
            //                else
            //                     if (ticket._Type.ToLower().Equals("regular"))
            //                {

            //                    htmltag += "<li role='presentation'><a href='#RG" + JsCounter + "' aria-controls='profile' role='tab' data-toggle='tab'>Regular</a></li>";
            //                }
            //                else
            //                     if (ticket._Type.ToLower().Equals("vip"))
            //                {

            //                    htmltag += "<li role ='presentation'><a href='#VIP" + JsCounter + "' aria-controls='messages' role='tab' data-toggle='tab'>VIP</a></li>";
            //                }
            //                else
            //                    if (ticket._Type.ToLower().Equals("vvip"))//VVIP
            //                {

            //                    htmltag += "<li role ='presentation'><a href='#VVIP" + JsCounter + "' aria-controls='messages' role='tab' data-toggle='tab'>VVIP</a></li>";
            //                }
            //            }

            //            htmltag += "</ul>";
            //            htmltag += "<div class='tab-content'>";
            //            foreach (EventTicket ticket in eventTickets)
            //            {

            //                if (ticket._Type.ToLower().Equals("early bird"))
            //                {
            //                    // <asp:TextBox ID="txtNewCredit" runat="server" TextMode="Number"></asp:TextBox>
            //                    htmltag += "<div role='tabpanel' class='tab-pane fade in active' id='EB" + JsCounter + "'>";
            //                    htmltag += "<p><b>Current Credits: " + ticket._Credit + "</b> Update Credits to: </p><asp:TextBox ID='txtNewCredit' runat='server' TextMode='Number'></asp:TextBox> ";
            //                    htmltag += "<p>Number of Ticket: " + ticket.numTicket + "</p>";
            //                    htmltag += "<p>Ticket Price: " + ticket._Price + "</p>";
            //                    htmltag += "<p>Refund Policy: " + ticket._Refund + "</p>";
            //                    htmltag += "</div>";
            //                }
            //                if (ticket._Type.ToLower().Equals("regular"))
            //                {
            //                    htmltag += "<div role='tabpanel' class='tab-pane fade' id='RG" + JsCounter + "'>";
            //                    htmltag += "<p><b>Current Credits: " + ticket._Credit + "</b> Update Credits to: </p><asp:TextBox ID='txtNewCredit' runat='server' TextMode='Number'></asp:TextBox>";
            //                    htmltag += "<p>Number of Ticket: " + ticket.numTicket + "</p>";
            //                    htmltag += "<p>Ticket Price: " + ticket._Price + "</p>";
            //                    htmltag += "<p>Refund Policy: " + ticket._Refund + "</p>";
            //                    htmltag += "</div>";
            //                }
            //                if (ticket._Type.ToLower().Equals("vip"))
            //                {
            //                    htmltag += "<div role='tabpanel' class='tab-pane fade' id='VIP" + JsCounter + "'>";
            //                    htmltag += "<p><b>Current Credits: " + ticket._Credit + "</b> Update Credits to: </p><br/>";
            //                    htmltag += "<p>Number of Ticket: " + ticket.numTicket + "</p>";
            //                    htmltag += "<p>Ticket Price: " + ticket._Price + "</p>";
            //                    htmltag += "<p>Refund Policy: " + ticket._Refund + "</p>";
            //                    htmltag += "</div>";
            //                }
            //                if (ticket._Type.ToLower().Equals("vvip"))
            //                {
            //                    htmltag += "<div role='tabpanel' class='tab-pane fade' id='VVIP" + JsCounter + "'>";
            //                    htmltag += "<p><b>Current Credits: " + ticket._Credit + "</b> Update Credits to: </p><asp:TextBox ID='txtNewCredit' runat='server' TextMode='Number'></asp:TextBox> ";
            //                    htmltag += "<p>Number of Ticket: " + ticket.numTicket + "</p>";
            //                    htmltag += "<p>Ticket Price: " + ticket._Price + "</p>";
            //                    htmltag += "<p>Refund Policy: " + ticket._Refund + "</p>";
            //                    htmltag += "</div>";
            //                }
            //            }
            //            htmltag += "</div>";
            //            htmltag += "</div>";
            //        }
            //        else
            //        {
            //            htmltag += "<br/><h3>No Tickets</h3>";
            //        }
            //        htmltag += " </div></div>";
            //        JsCounter++;
            //    }
            //    EventDiv.InnerHtml = htmltag;
            //}
        }

        protected void btnUpdateCredit_Click(object sender, EventArgs e)
        {
            string Guest_ID = Convert.ToString(Session["ID"]);
            TicketServiceClient tsc = new TicketServiceClient();
            EventTicket tick = new EventTicket();
            tick._Credit = Convert.ToInt32(txtNewCredit.Value);
            tick._StartDate = DateTime.Now;
            tick._EndDate = DateTime.Now;
            tick._TicketID = Convert.ToInt32(txt_Ticket_ID.Value);
            tick._GuestID = Convert.ToInt32(Guest_ID);
            String response = tsc.LoadCredits(tick);

            Response.Redirect("GuestTicketList.aspx?hostID=" + Guest_ID);
        }
    }
}