using Eventrix_Client;
using Eventrix_Client.Model;
using Eventrix_Client.Model.ClientDefinition;
using Eventrix_Client.Model.ServiceClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZXing;

namespace Prototype_TNT_Der1
{
    public partial class EventRSVP : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string eventID = Request.QueryString["ev"];
            int G_ID = Convert.ToInt32(Session["ID"]);

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

            em = eventClient.findByEventID(eventID);
            img = fuc.getImageById(eventID);
            listimages = fuc.getMultipleImagesById(eventID);
            string output = "";
            string imgLocation = "";
            ImageFile mainPic = new ImageFile();
            if (listimages.Count == 0)
            {
                output = "/Events/eventrix-icon.png";
                string strIhtml = "<img src='" + output + "' class='img-responsive' alt=''/>";
                divImageSlider.InnerHtml = strIhtml;
                secondaryImageSlider.Visible = false;
            }
            else
            if (listimages.Count == 1)  //one pic uploaded
            {
                imgLocation = img.Location;
                output = imgLocation.Substring(imgLocation.IndexOf('E')); //trim string path from Event
                                                                          //image slider
                string strIhtml = "<img src='" + output + "' class='img-responsive' alt=''/>";
                divImageSlider.InnerHtml = strIhtml;
                secondaryImageSlider.Visible = false;
            }
            else //more than one pic uploaded
            {
                mainPic = null;
                mainPic = listimages.First();
                imgLocation = mainPic.Location;
                output = imgLocation.Substring(imgLocation.IndexOf('E')); //trim string path from Event
                                                                          //image slider
                string secImageLocation = listimages[1].Location;
                string strIhtml = "<img src='" + output + "' class='img-responsive' alt=''/>";
                divImageSlider.InnerHtml = strIhtml;
                output = secImageLocation.Substring(imgLocation.IndexOf('E'));
                string secImageSlider = "<div class='item'><img src='" + output + "' class='img-responsive' alt=''/></div>";
                secondaryImageSlider.InnerHtml = secImageSlider;
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
        }
        protected void btnComing_Click(object sender, EventArgs e)
        {
            string eventID = Request.QueryString["ev"];
            int G_ID = Convert.ToInt32(Session["ID"]);

            EventServiceClient event_client = new EventServiceClient();

            //Update event RSVP table
            bool isRecorded = event_client.RecordRSVP(eventID, Convert.ToString(G_ID), "Confirmed");

            //Retreive event info
            EventModel newEvent = new EventModel();
            EventModel updatedEvent = new EventModel();
            newEvent = event_client.findByEventID(eventID);

            string ticket_Type =  Convert.ToString(Session["TYPE"]);
            //Create BarCode
            TicketServiceClient tsc = new TicketServiceClient();
            EventTicket ticket = new EventTicket();
            if (ticket_Type.ToLower().Contains("early bird") && newEvent.EB_Quantity > 0)
            {
                ticket = tsc.getEBTicket(Convert.ToString(eventID));
                newEvent.EB_Quantity = newEvent.EB_Quantity - 1;
                updatedEvent = event_client.updateEvent(newEvent, eventID);
            }
            else
            if (ticket_Type.ToLower().Contains("regular") && newEvent.Reg_Quantity > 0)
            {
                ticket = tsc.getRegularTicket(Convert.ToString(eventID));
                newEvent.Reg_Quantity = newEvent.Reg_Quantity - 1;
                updatedEvent = event_client.updateEvent(newEvent, eventID);
            }
            else if (ticket_Type.ToLower().Contains("vip") && newEvent.VIP_Quantity > 0)
            {
                ticket = tsc.getVIPTicket(Convert.ToString(eventID));
                newEvent.VIP_Quantity = newEvent.VIP_Quantity - 1;
                updatedEvent = event_client.updateEvent(newEvent, eventID);
            }
            else
            if (ticket_Type.ToLower().Contains("vvip") && newEvent.VVIP_Quantity > 0)
            {
                ticket = tsc.getVVIPTicket(Convert.ToString(eventID));
                newEvent.VVIP_Quantity = newEvent.VVIP_Quantity - 1;
                updatedEvent = event_client.updateEvent(newEvent, eventID);
            }

            //Check if tickets sstill available
            if(ticket != null)
            {
                //Purchase ticket 
                ticket._GuestID = G_ID;
                int ticketID = tsc.PurchaseTicket(ticket);
                if(ticketID != 0) //successfull transaction
                {
                    QRCodeImage img = new QRCodeImage();
                    img = GenerateCode(ticket, 1, Convert.ToString(G_ID), ticketID, eventID);
                    //Send Barcode to guest
                    EmailClient emails = new EmailClient();
                    //Find guest details
                    string Name = Convert.ToString(Session["Name"]);
                    string Surname = Convert.ToString(Session["Surname"]);
                    string Email = Convert.ToString(Session["Email"]);
                    emails.sendMsg_TicketPurchased(Name, Email, newEvent, img, ticket);
                    Response.Redirect("EventDetails.aspx?ev=" + eventID);
                }
            }

        }

        protected void btnNotCOming_Click(object sender, EventArgs e)
        {
            string G_ID = Convert.ToString(Session["ID"]);
            string eventID = Request.QueryString["ev"];
            EventServiceClient event_client = new EventServiceClient();
            bool isRecorded = event_client.RecordRSVP(eventID, G_ID, "Declined");
            Response.Redirect("Index.aspx");
        }
        private QRCodeImage GenerateCode(EventTicket _ticket, int count, string G_ID, int bridgingID, string EventID)
        {
            string ImageName = "Dummy";
            //store New image to database
            QRCodeImage img = new QRCodeImage();
            QRCodeImage qrcode = new QRCodeImage();
            img.Name = ImageName;
            img.ticket_ID = bridgingID;
            img.EntranceTime = DateTime.Now;
            img.Checked_in = 0;
            img.Credit = _ticket._Credit;
            img.Location = "Dummy";
            FileUploadClient fuc = new FileUploadClient();
            int intQRCodeID = fuc.saveQRCodeImage(img);
            if (intQRCodeID != 0)
            {
                //create QR Code Image
                string QRCodeCotntent = Convert.ToString(intQRCodeID);
                var writer = new BarcodeWriter();
                writer.Format = BarcodeFormat.QR_CODE; //populate code with GuestID
                var result = writer.Write(QRCodeCotntent);
                string path = Server.MapPath("~/Events/" + _ticket._EventID + "/QR_Codes/" + bridgingID + "_" + G_ID + "_QRImage.jpg");
                ImageName = bridgingID + "_" + G_ID + "_QRImage.jpg";
                var barcodeBitmap = new Bitmap(result);
                using (MemoryStream memory = new MemoryStream())
                {
                    using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.ReadWrite))
                    {
                        barcodeBitmap.Save(memory, ImageFormat.Png);
                        byte[] bytes = memory.ToArray();
                        fs.Write(bytes, 0, bytes.Length);
                    }
                }

                //UPdate Last Added QRCode Image
                qrcode.Name = ImageName;
                qrcode.Location = path;
                qrcode.EntranceTime = DateTime.Now;

                bool isUpdated = fuc.UpdateQRCode(qrcode, Convert.ToString(intQRCodeID));
                if (isUpdated == true)
                {

                    //Alert is created
                }
            }
            return qrcode;
        }

        protected void lnkFB_Click(object sender, EventArgs e)
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
            }
            else
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
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
}