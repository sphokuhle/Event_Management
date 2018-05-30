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
    public partial class EventList : System.Web.UI.Page
    {
        int strEventID;
        protected void Page_Load(object sender, EventArgs e)
        {

            //delete event trigger===========================================
            string Status = "";
            String deleterequest = (Request.QueryString["dl"]);
        
            if (deleterequest != null)
            {
                //delete QR Code;
                TicketServiceClient ticketToDelete = new TicketServiceClient();
                string dl_GT_BridgingTable ="";
                string dl_ticket_template = "";
                string dl_QRCode = ticketToDelete.dl_QRCodeByEventID(deleterequest);
                if (dl_QRCode.ToLower().Contains("success"))
                {
                    dl_GT_BridgingTable = ticketToDelete.dl_GuestTicket_BT_ByEventID(deleterequest);
                    if(dl_GT_BridgingTable.ToLower().Contains("success"))
                    {
                        dl_ticket_template = ticketToDelete.dl_TicketTemplate_byEventID(deleterequest);
                        if(dl_ticket_template.ToLower().Contains("success"))
                        {
                            Status = "\n All tickets Deleted";
                        }
                    }
                }
                FileUploadClient img = new FileUploadClient();
                string deleteImage = img.deleteImagebyEventID(deleterequest);
                if (deleteImage.ToLower().Contains("Failed"))
                {
                    Status += "\n Image not Delete";
                }
                else
                {
                    Status += "\n Image Delete";
                }
                StaffServiceClient ssc = new StaffServiceClient();
                string deletestaff = ssc.deleteStaffByEventID(deleterequest);
                if (deletestaff.ToLower().Contains("Failed"))
                {
                    Status += "\n Staff not Deleted";
                }
                else
                {
                    Status += "\n Staff Deleted";
                }
                ProductServiceClient psc = new ProductServiceClient();
                string deleteProduct = psc.DeleteProductByEventID(deleterequest);
                if (deleteProduct.ToLower().Contains("Failed"))
                {
                    Status += "\n Product not Deleted";
                }
                else
                {
                    Status += "\n Product Deleted";
                }
                EventServiceClient esc = new EventServiceClient();
                EventModel ev = new EventModel();
                ev = esc.findByEventID(deleterequest);
                string deleteEvent = esc.deleteEventByID(deleterequest);
                if (deleteEvent.ToLower().Contains("Failed"))
                {
                    Status += "\n Event not Deleted";
                }
                else
                {
                    Status += "\n Event Deleted";
                    //delete event's address
                   try
                    {
                        int Address_ID = ev.EventAddress;
                        MappingClient mapping = new MappingClient();
                        mapping.deleteAddressByID(Convert.ToString(Address_ID));
                    }
                    catch(Exception)
                    {
                        Status += "Event Already Deleted";
                    }
                    int LoggedID = Convert.ToInt32(Session["ID"]);
                    Response.Redirect("EventManagement.aspx?HostID=" + LoggedID);
                }
            }   //done deleting an event============================================

            //display event list
            List<EventModel> display = new List<EventModel>();
            int intUserID;
            intUserID = Convert.ToInt32(Session["ID"]);
            String request = (Request.QueryString["ME"]);
         
            if (request != null) //If request is made
            {
                //guest's events
            //    int reqID = Convert.ToInt32(request);
                string sessionlevel = Convert.ToString(Session["Level"]);
                if (sessionlevel.ToLower().Equals("guest") && request.ToLower().Equals("1"))
                {
                    string GuestID = Convert.ToString(Session["ID"]);
                    Response.Redirect("GuestEventList.aspx?GuestID="+ GuestID);
                }

                if (request.Equals("Edit")) //Edit Event
                {
                    ImageFile img = new ImageFile();
                    FileUploadClient fuc = new FileUploadClient();
                    display = GetEvent(intUserID);
                    string htmltag = "";
                    foreach (EventModel em in display)
                    {
                        strEventID = em.EventID;
                        string EventID = Convert.ToString(em.EventID);
                        string imgLocation = "";
                        string output = "";//trim string path from Event
                                           //   string strout = output;
                        img = fuc.getImageById(EventID);
                        if (img == null)
                        {
                            output = "Events/Eventrix_Default_Image.png";
                        }
                        else
                        {
                            imgLocation = img.Location;
                            output = imgLocation.Substring(imgLocation.IndexOf('E')); //trim string path from Event
                        }
                        htmltag += "<div class='portfolio-item col-sm-6 col-md-4' data-groups='['all', 'numbers', 'blue', 'square']'>";
                        htmltag += "<div class='single-portfolio'>";
                        htmltag += "<img src='" + output + "' alt='' style='width: 317px; height: 190px'>";
                        //   htmltag += "<asp:Button style='padding:10px 130px;' class='btn btn-primary animated lightSpeedIn' OnClick='btnDelete_Click'><a style='color:white;' href='EditEvent.aspx?EventID=" + em.EventID + "'>Edit Event</a></asp:Button>";
                        htmltag += "<a style='padding:10px 130px;' class='btn btn-primary animated bounceIn' href='EditEvent.aspx?ed=" + em.EventID + "'>Edit Event</a>";
                        htmltag += "<div class='portfolio-links' style='width: 200px; margin-left: -120px;'>";
                        htmltag += "<li class='fa fa-link'>";
                        htmltag += "<a href='#' style='font-size:18px;";
                        htmltag += "font-family:'Roboto',sans-serif;";
                        htmltag += "color:white;'>";
                        htmltag += "<p>" + em.Name + "</p>";
                        htmltag += "<p> " + em.sDate + " </p></a>";
                        htmltag += "</li>";
                        htmltag += "<a class='image-link' href='" + output + "'><i class='fa fa-search-plus'></i></a>";
                        htmltag += "<a href='EventDetails.aspx?EventID=" + em.EventID + "'><i class='fa fa-link'></i></a>";
                        htmltag += "</div><!-- /.links -->";
                        htmltag += "</div><!-- /.single-portfolio -->";
                        htmltag += "</div><!-- /.portfolio-item -->";
                    }
                    grid.InnerHtml = htmltag;
                }
                else if (request.Equals("Delete")) //Delete Event
                {
                    ImageFile img = new ImageFile();
                    FileUploadClient fuc = new FileUploadClient();
                    display = GetEvent(intUserID);
                    string htmltag = "";
                    string imgLocation = "";
                    foreach (EventModel em in display)
                    {
                        string output = "";
                        string EventID = Convert.ToString(em.EventID);
                        img = fuc.getImageById(EventID);
                        if (img == null)
                        {
                            output = "Events/Eventrix_Default_Image.png";
                        }
                        else
                        {
                            imgLocation = img.Location;
                            output = imgLocation.Substring(imgLocation.IndexOf('E')); //trim string path from Event
                        }                                                               //                                                                 //   string strout = output;
                                                                                        //    htmltag += "<a href='EventDetails.aspx'><i class='fa fa-link'></i></a>";
                        htmltag += "<div class='portfolio-item col-sm-6 col-md-4' data-groups='['all', 'numbers', 'blue', 'square']'>";
                        htmltag += "<div class='single-portfolio'>";
                        htmltag += "<img src='" + output + "' alt='' style='width: 317px; height: 190px'>";
                        htmltag += "<a style='padding:10px 130px;' class='btn btn-primary animated bounceIn' href='EventList.aspx?dl=" + em.EventID + "'>Delete Event</a>";
                        htmltag += "<div class='portfolio-links' style='width: 200px; margin-left: -120px;'>";
                        htmltag += "<li class='fa fa-link'>";
                        htmltag += "<a href='#' style='font-size:18px;";
                        htmltag += "font-family:'Roboto',sans-serif;";
                        htmltag += "color:white;'>";
                        htmltag += "<p>" + em.Name + "</p>";
                        htmltag += "<p>" + em.sDate + " </p></a>";
                        htmltag += "</li>";
                        htmltag += "<a class='image-link' href='" + output + "'><i class='fa fa-search-plus'></i></a>";
                        htmltag += "<a href='EventDetails.aspx?EventID=" + em.EventID + "'><i class='fa fa-link'></i></a>";
                        htmltag += "</div><!-- /.links -->";
                        htmltag += "</div><!-- /.single-portfolio -->";
                        htmltag += "</div><!-- /.portfolio-item -->";
                    }
                    grid.InnerHtml = htmltag;
                }else if (request.Equals("EventReport")) //Event Report
                {
                    ImageFile img = new ImageFile();
                    FileUploadClient fuc = new FileUploadClient();
                    display = GetEvent(intUserID);
                    string htmltag = "";
                    string imgLocation = "";
                    foreach (EventModel em in display)
                    {
                        string output = "";
                        string EventID = Convert.ToString(em.EventID);
                        img = fuc.getImageById(EventID);
                        if (img == null)
                        {
                            output = "Events/Eventrix_Default_Image.png";
                        }
                        else
                        {
                            imgLocation = img.Location;
                            output = imgLocation.Substring(imgLocation.IndexOf('E')); //trim string path from Event
                        }                                                               //                                                                 //   string strout = output;
                                                                                        //    htmltag += "<a href='EventDetails.aspx'><i class='fa fa-link'></i></a>";
                        htmltag += "<div class='portfolio-item col-sm-6 col-md-4' data-groups='['all', 'numbers', 'blue', 'square']'>";
                        htmltag += "<div class='single-portfolio'>";
                        htmltag += "<img src='" + output + "' alt='' style='width: 317px; height: 190px'>";
                        //AAFReport.aspx?eventID=" + strEventID
                        htmltag += "<a style='padding:10px 130px;' class='btn btn-primary animated bounceIn' href='AAFReport.aspx?eventID=" + em.EventID + "'>Event Report</a>";
                        htmltag += "<div class='portfolio-links' style='width: 200px; margin-left: -120px;'>";
                        htmltag += "<li class='fa fa-link'>";
                        htmltag += "<a href='#' style='font-size:18px;";
                        htmltag += "font-family:'Roboto',sans-serif;";
                        htmltag += "color:white;'>";
                        htmltag += "<p>" + em.Name + "</p>";
                        htmltag += "<p>" + em.sDate + " </p></a>";
                        htmltag += "</li>";
                        htmltag += "<a class='image-link' href='" + output + "'><i class='fa fa-search-plus'></i></a>";
                        htmltag += "<a href='EventDetails.aspx?EventID=" + em.EventID + "'><i class='fa fa-link'></i></a>";
                        htmltag += "</div><!-- /.links -->";
                        htmltag += "</div><!-- /.single-portfolio -->";
                        htmltag += "</div><!-- /.portfolio-item -->";
                    }
                    grid.InnerHtml = htmltag;
                }
                else //View "My Event"
                {
                    Response.Redirect("HostEventList.aspx?HostID=" + intUserID);
                }
            }
        }

        public List<EventModel> GetEvent(int User_ID)
        {
            List<EventModel> _event = new List<EventModel>();
            EventServiceClient EventClient = new EventServiceClient();
            if (User_ID == 0) //no one logged in || All Event
            {
                _event = EventClient.findAllEvent();
                return _event;
            }
            else //User logged in || Event by Event ID
            {
                string strEventID = Convert.ToString(User_ID);
                _event = EventClient.findEventbyID(strEventID, "0");
                return _event;
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}