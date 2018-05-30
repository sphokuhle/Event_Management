
using Eventrix_Client.Model.ClientDefinition;
using Eventrix_Client.Model.ServiceClient;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using ZXing;
using Eventrix_Client.Model;
using Eventrix_Client;

namespace Prototype_TNT_Der1
{
    public partial class PurchaseTicket : System.Web.UI.Page
    {
        string LoggedID = "";
        string eventID = "";
        string EB_TicketID = "";
        string RG_TicketID = "";
        string VIP_TicketID = "";
        string VVIP_TicketID = "";
        string LevelID = "";
        string Name = "";
        string Surname = "";
        string Email = "";
        GuestModel guest = new GuestModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedID = Convert.ToString(Session["ID"]);
            LevelID = Convert.ToString(Session["Level"]);
            //disallow staff from purchasing ticket
            if (LevelID.Equals("Staff"))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Not Allowed to purchase tiicket, please sign-up.');", true);
                Response.Redirect("Login.aspx");
            }
            else if (LevelID.Equals("Guest")) //Guest logged in
            {
                Name = Convert.ToString(Session["Name"]);
                Surname = Convert.ToString(Session["Surname"]);
                Email = Convert.ToString(Session["Email"]);
                GuestServiceClient gsc = new GuestServiceClient();
                guest = gsc.findGuestbyID(LoggedID);
            }
            else if (LevelID.Equals("Host"))  //Host logged in
            {
                Name = Convert.ToString(Session["Name"]);
                Surname = Convert.ToString(Session["Surname"]);
                Email = Convert.ToString(Session["Email"]);
            }else //new user
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Please Login or sign up first');", true);
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                txtU_name.Text = Name;
                txtU_name.ReadOnly = true;
                txtU_surname.Text = Surname;
                txtU_surname.ReadOnly = true;
                txtU_Email.Text = Email;
                txtU_Email.ReadOnly = true;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
          
        }

        protected void btnSave_Click1(object sender, EventArgs e)
        {
            
            int numTicket = Convert.ToInt32(txtQtys.Text);  // event's ticket quantity
                                                            //edit ticket by ticket id --create new ticket with ticket 
            eventID = Request.QueryString["E_ID"];
            EventTicket EB_tickets = new EventTicket();
            EventTicket REG_tickets = new EventTicket();
            EventTicket VIP_tickets = new EventTicket();
            EventTicket VVIP_tickets = new EventTicket();
            TicketServiceClient tsc = new TicketServiceClient();
            EventModel currentEvent = new EventModel();
            EventServiceClient esc = new EventServiceClient();
            currentEvent = esc.findByEventID(eventID);
            EventModel newEvent = new EventModel();   //event to be updated 

            //validate ticket selected
            EB_TicketID = Request.QueryString["EBT_ID"];
            if (EB_TicketID == null)
            {
                RG_TicketID = Request.QueryString["RBT_ID"];
                if (RG_TicketID == null)
                {
                    VIP_TicketID = Request.QueryString["VT_ID"];
                    if (VIP_TicketID == null)
                    {
                        VVIP_TicketID = Request.QueryString["VVT_ID"];
                        if (VVIP_TicketID == null)
                        {
                            //free event

                        }
                        else  //get vvip ticket info by ticket id
                        {
                            int currentNumTicket = currentEvent.VVIP_Quantity;
                            if (currentNumTicket >= numTicket)
                            {
                                for(int i =0; i < numTicket; i++)
                                {
                                    VVIP_tickets = tsc.getVIPTicket(eventID);
                                    VVIP_tickets._GuestID = Convert.ToInt32(LoggedID);
                                    VVIP_tickets.numTicket = numTicket;
                                    int purchased_Ticket_ID;
                                    //   int purchasedTicektID = 0;
                                    purchased_Ticket_ID = tsc.PurchaseTicket(VVIP_tickets);
                                    if (purchased_Ticket_ID != 0)
                                    {
                                        purchased_Ticket_ID = Convert.ToInt32(purchased_Ticket_ID);
                                        //QR Code
                                        QRCodeImage qrCode = new QRCodeImage();
                                        qrCode = GenerateCode(VVIP_tickets, numTicket, LoggedID, purchased_Ticket_ID, eventID);
                                        //decrement ticket quantity in main event table
                                        currentEvent.VVIP_Quantity = currentNumTicket - numTicket;
                                        newEvent = esc.updateEvent(currentEvent, eventID);
                                        EmailClient emails = new EmailClient();
                                        //guest, newEvent, EventTicket,
                                        EventServiceClient EventClient = new EventServiceClient();
                                        EventModel items = EventClient.findByEventID(eventID);
                                        emails.sendMsg_TicketPurchased(Name, Email, items, qrCode, VVIP_tickets);
                                    }
                                }
                                Response.Redirect("EventDetails.aspx?ev=" + eventID);
                            }
                        }
                    }
                    else //get vip ticket info by ticket id
                    {
                        int currentNumTicket = currentEvent.VIP_Quantity;
                        if (currentNumTicket >= numTicket)
                        {
                            for(int i = 0; i < numTicket; i++)
                            {
                                VIP_tickets = tsc.getVIPTicket(eventID);
                                VIP_tickets._GuestID = Convert.ToInt32(LoggedID);
                                VIP_tickets.numTicket = numTicket;
                                int purchased_Ticket_ID;
                                //   int purchasedTicektID = 0;
                                purchased_Ticket_ID = tsc.PurchaseTicket(VIP_tickets);
                                if (purchased_Ticket_ID != 0)
                                {
                                    purchased_Ticket_ID = Convert.ToInt32(purchased_Ticket_ID);
                                    //QR Code
                                    QRCodeImage qrCode = new QRCodeImage();
                                    qrCode = GenerateCode(VIP_tickets, numTicket, LoggedID, purchased_Ticket_ID, eventID);
                                    //decrement ticket quantity in main event table
                                    currentEvent.VIP_Quantity = currentNumTicket - numTicket;
                                    newEvent = esc.updateEvent(currentEvent, eventID);
                                    EmailClient emails = new EmailClient();
                                    //guest, newEvent, EventTicket,
                                    EventServiceClient EventClient = new EventServiceClient();
                                    EventModel items = EventClient.findByEventID(eventID);
                                    emails.sendMsg_TicketPurchased(Name, Email, items, qrCode, VIP_tickets);
                                }
                            }
                            Response.Redirect("EventDetails.aspx?ev=" + eventID);
                        }
                    }
                }
                else  //get regular ticket info by ticket id
                {
                    int currentNumTicket = currentEvent.Reg_Quantity;
                    if (currentNumTicket >= numTicket)
                    {
                        for(int i = 0; i < numTicket; i++)
                        {
                            REG_tickets = tsc.getRegularTicket(eventID);
                            REG_tickets._GuestID = Convert.ToInt32(LoggedID);
                            REG_tickets.numTicket = numTicket;
                            int purchased_Ticket_ID = 0;
                            //   int purchasedTicektID = 0;
                            purchased_Ticket_ID = tsc.PurchaseTicket(REG_tickets);
                            if(purchased_Ticket_ID != 0)
                            {
                                //QR Code
                                QRCodeImage qrCode = new QRCodeImage();
                                qrCode = GenerateCode(REG_tickets, numTicket, LoggedID, purchased_Ticket_ID, eventID);
                                //decrement ticket quantity in main event table
                                currentEvent.Reg_Quantity = currentNumTicket - numTicket;
                                newEvent = esc.updateEvent(currentEvent, eventID);

                                EmailClient emails = new EmailClient();
                                //guest, newEvent, EventTicket,
                                EventServiceClient EventClient = new EventServiceClient();
                                EventModel items = EventClient.findByEventID(eventID);
                                emails.sendMsg_TicketPurchased(Name, Email, items, qrCode, REG_tickets);

                            }
                        }
                        Response.Redirect("EventDetails.aspx?ev=" + eventID);
                    }
                }
            }
            else //get early bird ticket info by ticket id
            {
                int currentNumTicket = currentEvent.EB_Quantity;
                if (currentNumTicket >= numTicket)
                {
                    for(int i=0; i < numTicket; i++)
                    {
                        EB_tickets = tsc.getEBTicket(eventID);
                        EB_tickets._GuestID = Convert.ToInt32(LoggedID);
                        EB_tickets.numTicket = numTicket;
                        int purchased_Ticket_ID;
                        //   int purchasedTicektID = 0;
                        purchased_Ticket_ID = tsc.PurchaseTicket(EB_tickets);
                        if (purchased_Ticket_ID != 0)
                        {
                            purchased_Ticket_ID = Convert.ToInt32(purchased_Ticket_ID);
                            //QR Code
                            QRCodeImage qrCode = new QRCodeImage();
                            qrCode= GenerateCode(EB_tickets, numTicket, LoggedID, purchased_Ticket_ID, eventID);
                            //decrement ticket quantity in main event table
                            FileUploadClient fuc = new FileUploadClient();

                            currentEvent.EB_Quantity = currentNumTicket - numTicket;
                            newEvent = esc.updateEvent(currentEvent, eventID);
                            EmailClient emails = new EmailClient();
                            //guest, newEvent, EventTicket,
                            EventServiceClient EventClient = new EventServiceClient();
                            EventModel items = EventClient.findByEventID(eventID);
                            emails.sendMsg_TicketPurchased(Name, Email, items, qrCode, EB_tickets);


                        }
                    }

                    Response.Redirect("EventDetails.aspx?ev=" + eventID);
                }
                else
                {
                    //sold out
                }
            }
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
                if(intQRCodeID != 0)
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
                    if(isUpdated == true)
                    {

                        //Alert is created
                    }
                }
            return qrcode;
        }

        protected void btnSave_Click2(object sender, EventArgs e)
        {

        }
    }
}