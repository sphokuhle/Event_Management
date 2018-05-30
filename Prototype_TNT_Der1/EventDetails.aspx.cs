using Eventrix_Client;
using Eventrix_Client.Model;
using Eventrix_Client.Model.ClientDefinition;
using Eventrix_Client.Model.ServiceClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Prototype_TNT_Der1
{
    public partial class EventDetails : System.Web.UI.Page
    {
        int strEventID;
        int EventViews = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            string eventID = Request.QueryString["ev"];

            // GetNumViews(string eventID, string Type)
            EventServiceClient esv = new EventServiceClient();
            ReportServiceClient reportClient = new ReportServiceClient();
            EventModel myEvent = new EventModel();
            //Get Number of Event Vies
            int EventViews = esv.GetNumViews(eventID, "Views");
            int EventShares = esv.GetNumViews(eventID, "Shares");
            string RecentShareDate = reportClient.GetLatestView(eventID, "Shares");
            string RecentViewDate = reportClient.GetLatestView(eventID, "Views");
            numViews.InnerHtml = Convert.ToString(EventViews);
            numShares.InnerHtml = Convert.ToString(EventShares);
            ViewDate.InnerHtml = RecentViewDate;
            shareDate.InnerHtml = RecentShareDate;




            String request = (Request.QueryString["ev"]);
            string HostLevel = Convert.ToString(Session["Level"]);
            int HostID = Convert.ToInt32(Session["ID"]);

            //Trigger event views
            EventServiceClient evsc = new EventServiceClient();
            EventViews newView = new EventViews();
            newView.E_ID = Convert.ToInt32(request);
            if (HostLevel.ToLower().Equals("host"))
            {
                MapVsReportContainer.InnerHtml = "<span class='title' style='text-align:center;'>Ticket Statistics</span>";
                EventServiceClient Service_Client = new EventServiceClient();
                EventModel _event = new EventModel();
                _event = Service_Client.findByEventID(request);
                if (_event.HostID == HostID)
                {
                    btnDelete.Visible = true;
                    btnEdit.Visible = true;
                    btnReport.Visible = true;


                    googleMap.Visible = false;
                    PieChart.Visible = true;
                    market.Visible = true;
                    ticket.Visible = false;
                }
                else
                {
                    btnDelete.Visible = false;
                    btnEdit.Visible = false;
                    btnReport.Visible = false;


                    googleMap.Visible = true;
                    PieChart.Visible = false;
                    market.Visible = false;
                    ticket.Visible = true;
                }


                EventModel view = new EventModel();
                view.EventID = Convert.ToInt32(request);
                view.HostID = Convert.ToInt32(HostID);
                view.Type = "Views";
                evsc.addEventView(view);
            }
            else if(HostLevel.ToLower().Equals("guest"))
            {
                MapVsReportContainer.InnerHtml = "<span class='title' style='text-align:center;'>Get Directions</span>";
                btnDelete.Visible = false;
                btnEdit.Visible = false;
                btnReport.Visible = false;

                googleMap.Visible = true;
                PieChart.Visible = false;
                market.Visible = false;
                ticket.Visible = true;

                EventModel view = new EventModel();
                view.EventID = Convert.ToInt32(request);
                view.GuestID = Convert.ToInt32(HostID);
                view.Type = "View";
                evsc.addEventView(view);
            }else
            {
                MapVsReportContainer.InnerHtml = "<span class='title' style='text-align:center;'>Get Directions</span>";
                btnDelete.Visible = false;
                btnEdit.Visible = false;
                btnReport.Visible = false;

                googleMap.Visible = true;
                PieChart.Visible = false;
                market.Visible = false;
                ticket.Visible = true;
            }

            //bool addViews = false;
            EventModel _View = new EventModel();
            _View.EventID = Convert.ToInt32(request);
            _View.EventView = EventViews;
            DateTime dummyTime = new DateTime();
            dummyTime = DateTime.Now;
            _View.sDate = Convert.ToString(dummyTime);
            _View.eDate = Convert.ToString(dummyTime);

            int EventID = Convert.ToInt32(request);
            strEventID = EventID;
            EventModel em = new EventModel();
            ImageFile img = new ImageFile();
            List<ImageFile> listimages = new List<ImageFile>();
            List<EventProduct> products = new List<EventProduct>();
            EventTicket EB_tickets = new EventTicket();
            EventTicket REG_tickets = new EventTicket();
            EventTicket VIP_tickets = new EventTicket();
            EventTicket VVIP_tickets = new EventTicket();
            EventServiceClient eventClient = new EventServiceClient();
            FileUploadClient fuc = new FileUploadClient();
            TicketServiceClient tsc = new TicketServiceClient();
            ProductServiceClient psc = new ProductServiceClient();

            em = eventClient.findByEventID(request);
            img = fuc.getImageById(request);
            listimages = fuc.getMultipleImagesById(request);
            string output = "";
            string imgLocation = "";
            ImageFile mainPic = new ImageFile();
            if (listimages.Count == 0)
            {
                output = "/Events/Eventrix_Default_Image.png";
                string strIhtml = "<img src='" + output + "' class='img-responsive' alt=''/>";
                divImageSlider.InnerHtml = strIhtml;
                //secondaryImageSlider.Visible = false;
            }
            else
            if (listimages.Count == 1)  //one pic uploaded
            {
                imgLocation = img.Location;
                output = imgLocation.Substring(imgLocation.IndexOf('E')); //trim string path from Event
                                                                          //image slider
                string strIhtml = "<img src='" + output + "' class='img-responsive' alt=''/>";
                divImageSlider.InnerHtml = strIhtml;
              //  secondaryImageSlider.Visible = false;
            }
            string htmltag = "";
            htmltag = "Event Name: " + em.Name;
            EName.InnerHtml = htmltag;

            htmltag = "<span class='title'>Start Date : </span>" + em.sDate;
            StartDate.InnerHtml = htmltag;

            htmltag = "<span class='title'>End Date : </span>" + em.eDate;
            EndDate.InnerHtml = htmltag;

            htmltag = em.Desc;
            Description.InnerHtml = htmltag;

            htmltag = ""; //clean string 
            EB_tickets = tsc.getEBTicket(request);
            REG_tickets = tsc.getRegularTicket(request);
            VIP_tickets = tsc.getVIPTicket(request);
            VVIP_tickets = tsc.getVVIPTicket(request);
            if (EB_tickets != null)
            {
                if(EB_tickets._Price.Equals(0))
                {
                    htmltag += "<li><span class='title'>Early Bird Tickets :Available  " + em.EB_Quantity + " </span> Price: For Free!, Available Till: " + EB_tickets._EndDate + "</li>";
                }
                else
                {
                    htmltag += "<li><span class='title'>Early Bird Tickets :Available  " + em.EB_Quantity + "  </span> Price: R" + EB_tickets._Price + ", Available Till: " + EB_tickets._EndDate + "</li>";
                }
                htmltag += "<li><a class='btn btn-primary animated bounceIn' href ='PurchaseTicket.aspx?EBT_ID=" + EB_tickets._TicketID + "&E_ID="+ request + "'>Buy Early Bird Ticket</a></li><hr/>";
            }

            if (REG_tickets != null)
            {
                if(REG_tickets._Price.Equals(0))
                {
                    htmltag += "<li><span class='title'>Regular Tickets :Available " + em.Reg_Quantity + " </span> Price: For Free!, Available Till: " + REG_tickets._EndDate + "</li>";
                }else
                {
                    htmltag += "<li><span class='title'>Regular Tickets :Available " + em.Reg_Quantity + " </span> Price: R" + REG_tickets._Price + ", Available Till: " + REG_tickets._EndDate + "</li>";
                }
                htmltag += "<li><a class='btn btn-primary animated bounceIn' href ='PurchaseTicket.aspx?RBT_ID=" + REG_tickets._TicketID + "&E_ID=" + request + "'>Buy Regular Ticket</a></li><hr/>";
            }
            if (VIP_tickets != null)
            {
                if(VIP_tickets._Price.Equals(0))
                {
                    htmltag += "<li><span class='title'>VIP Tickets :Available " + em.VIP_Quantity + " </span> Price: For Free!, Available Till: " + VIP_tickets._EndDate + "</li>";
                }else
                {
                    htmltag += "<li><span class='title'>VIP Tickets :Available " + em.VIP_Quantity + " </span> Price: R" + VIP_tickets._Price + ", Available Till: " + VIP_tickets._EndDate + "</li>";
                }
                htmltag += "<li><a class='btn btn-primary animated bounceIn' href ='PurchaseTicket.aspx?VT_ID=" + VIP_tickets._TicketID + "&E_ID=" + request + "'>Buy VIP Ticket</a></li><hr/>";
            }
            if (VVIP_tickets != null)
            {
                if(VVIP_tickets._Price.Equals(0))
                {
                    htmltag += "<li><span class='title'>VVIP Tickets :Available " + em.VVIP_Quantity + " </span> Price: For Free!, Available Till: " + VVIP_tickets._EndDate + "</li>";
                }else
                {
                    htmltag += "<li><span class='title'>VVIP Tickets :Available " + em.VVIP_Quantity + " </span> Price: R" + VVIP_tickets._Price + ", Available Till: " + VVIP_tickets._EndDate + "</li>";
                }
                htmltag += "<li><a class='btn btn-primary animated bounceIn' href ='PurchaseTicket.aspx?VVT_ID=" + VVIP_tickets._TicketID + "&E_ID=" + request + "'>Buy VVIP Ticket</a></li><hr/>";
            }
            ticketInfo.InnerHtml = htmltag;

            //check if ticket entrance is for free
            if (EB_tickets == null && REG_tickets == null && VIP_tickets == null && VVIP_tickets == null)
            {
                AttendEvent.Visible = true;
            }else
            {
                AttendEvent.Visible = false;
            }

            htmltag = ""; //clean string
            products = psc.getProductByEventID(request);
            int PC = products.Count();

            int count = 1;
            if (products != null)
            {
               if(PC != 0)
                {
                    htmltag = "<span class='title'>Products Sold</span>";
                //    ProductsHeading.InnerHtml = htmltag;
                    htmltag = "";
                }
                foreach (EventProduct ep in products)
                {
                    htmltag += "<li><span class='title'>" + count + ". " + ep._Name + "</span>Price: R" + ep._Price + "</li>";
                    count++;
                }
                Products.InnerHtml = htmltag;
            }
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditEvent.aspx?EventID=" + strEventID);

        }
        
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Response.Redirect("EventList.aspx?dl=" + strEventID);

            
        }

        protected void btnReport_Click(object sender, EventArgs e)
        {
             Response.Redirect("AAFReport.aspx?ev=" + strEventID);
            // GetTicketCountPerEvent(string eventID)
        }

        //Link shares
        //<a href="https://facebook.com/sharer.php?u=http://localhost:60469/EventDetails.aspx"><i class="fa fa-facebook"></i></a>
        //<a href="https://twitter.com/intent/tweet?url=http://localhost:60469/EventDetails.aspx"><i class="fa fa-twitter"></i></a>
        //<a href="https://www.linkedin.com/shareArticle?mini=true&amp;url=http://localhost:60469/EventDetails.aspx"><i class="fa fa-linkedin"></i></a>
        //EventDetails.aspx?EventID=" + em.EventID + "
        //htmltag = "";
        //    htmltag = "<a href='https://facebook.com/sharer.php?u=http://localhost:60469/EventDetails.aspx?EventID="+ em.EventID + "'><i class='fa fa-facebook'></i></a>";
        //    htmltag = "";
        //    htmltag = "<a href='https://twitter.com/intent/tweet?url=http://localhost:60469/EventDetails.aspx?EventID=" + em.EventID + "'><i class='fa fa-twitter'></i></a>";
        //    htmltag = "";
        //    htmltag = "<a href='https://www.linkedin.com/shareArticle?mini=true&amp;url=http://localhost:60469/EventDetails.aspx?EventID=" + em.EventID + "'><i class='fa fa-linkedin'></i></a>";

        protected void lnkFB_Click(object sender, EventArgs e)
        {
            if(Session.Count != 0)
            {
                String request = (Request.QueryString["ev"]);
                int HostID = Convert.ToInt32(Session["ID"]);
                string HostLevel = Convert.ToString(Session["Level"]);
                EventServiceClient eventClient = new EventServiceClient();
                if (HostLevel.ToLower().Equals("host"))
                {
                    EventModel AddShare = new EventModel();
                    AddShare.EventID = Convert.ToInt32(request);
                    AddShare.HostID = Convert.ToInt32(HostID);
                    AddShare.Type = "Shares";
                    eventClient.addEventView(AddShare);
                }
                else if (HostLevel.ToLower().Equals("guest"))
                {
                    EventModel AddShare = new EventModel();
                    AddShare.EventID = Convert.ToInt32(request);
                    AddShare.GuestID = Convert.ToInt32(HostID);
                    AddShare.Type = "Shares";
                    eventClient.addEventView(AddShare);
                }

                Response.Redirect("https://facebook.com/sharer.php?u=http://localhost:60469/EventDetails.aspx?EventID=" + request);
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void lnkTWT_Click(object sender, EventArgs e)
        {
            if (Session.Count != 0)
            {
                String request = (Request.QueryString["ev"]);
                int HostID = Convert.ToInt32(Session["ID"]);
                string HostLevel = Convert.ToString(Session["Level"]);
                EventServiceClient eventClient = new EventServiceClient();
                if (HostLevel.ToLower().Equals("host"))
                {
                    EventModel AddShare = new EventModel();
                    AddShare.EventID = Convert.ToInt32(request);
                    AddShare.HostID = Convert.ToInt32(HostID);
                    AddShare.Type = "Shares";
                    eventClient.addEventView(AddShare);
                }
                else if (HostLevel.ToLower().Equals("guest"))
                {
                    EventModel AddShare = new EventModel();
                    AddShare.EventID = Convert.ToInt32(request);
                    AddShare.GuestID = Convert.ToInt32(HostID);
                    AddShare.Type = "Shares";
                    eventClient.addEventView(AddShare);
                }
                Response.Redirect("https://twitter.com/intent/tweet?url=http://localhost:60469/EventDetails.aspx?EventID=" + request);
            }else
            {
                Response.Redirect("Login.aspx");
            }
       }

        protected void lnkLndIn_Click(object sender, EventArgs e)
        {
            if (Session.Count != 0)
            {
                String request = (Request.QueryString["ev"]);
                int HostID = Convert.ToInt32(Session["ID"]);
                string HostLevel = Convert.ToString(Session["Level"]);
                EventServiceClient eventClient = new EventServiceClient();
                if (HostLevel.ToLower().Equals("host"))
                {
                    EventModel AddShare = new EventModel();
                    AddShare.EventID = Convert.ToInt32(request);
                    AddShare.HostID = Convert.ToInt32(HostID);
                    AddShare.Type = "Shares";
                    eventClient.addEventView(AddShare);
                }
                else if (HostLevel.ToLower().Equals("guest"))
                {
                    EventModel AddShare = new EventModel();
                    AddShare.EventID = Convert.ToInt32(request);
                    AddShare.GuestID = Convert.ToInt32(HostID);
                    AddShare.Type = "Shares";
                    eventClient.addEventView(AddShare);
                }
                Response.Redirect("https://www.linkedin.com/shareArticle?mini=true&amp;url=http://localhost:60469/EventDetails.aspx?EventID=" + request);
            }else
            {
                Response.Redirect("Login.aspx");
            }
       }

        protected void AttendEvent_Click(object sender, EventArgs e)
        {

        }

        protected void lnkFB_Click1(object sender, EventArgs e)
        {

        }
    }
}