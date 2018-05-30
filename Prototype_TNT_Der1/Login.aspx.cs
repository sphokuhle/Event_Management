using Eventrix_Client;
using Eventrix_Client.Model;
using Eventrix_Client.Model.ServiceClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Prototype_TNT_Der1
{
    public partial class Login : System.Web.UI.Page
    {
        private GuestSvcClient guestClient = new GuestSvcClient();
        private ImageFile img;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
              
        public void SetSessions(EventHostModel _host)
        {
            Session.Add("ID", _host.ID.ToString());
            Session.Add("Name", _host.NAME);
            Session.Add("Surname", _host.SURNAME);
            Session.Add("Email", _host.EMAIL);
            Session.Add("Level", "Host");
            Session.Add("DEFAULT_IMAGE", "ProfilePic.png");
        }

        public void SetSessions(GuestModel _guest)
        {
            Session.Add("ID", _guest.ID.ToString());
            Session.Add("Name", _guest.NAME);
            Session.Add("Surname", _guest.SURNAME);
            Session.Add("Email", _guest.EMAIL);
            Session.Add("TYPE", _guest.TYPE);
            Session.Add("Level", "Guest");
        }

        public void SetSessions(StaffModel _staff)
        {
            Session.Add("ID", _staff.ID.ToString());
            Session.Add("Name", _staff.NAME);
            Session.Add("Surname", _staff.SURNAME);
            Session.Add("Email", _staff.EMAIL);
            Session.Add("Occupation", _staff.Occupation);
            Session.Add("EventID", _staff.EventID.ToString());
            Session.Add("Level", "Staff");
            Session.Add("DEFAULT_IMAGE", "ProfilePic.png");
        }

        protected void btnLogin_Click1(object sender, EventArgs e)
        {
            string RSVPEventID = Request.QueryString["e_ID"];
             UserLogin LoginClient = new UserLogin();
            GuestModel guest = new GuestModel();
            EventHostModel host = new EventHostModel();
            StaffModel staff = new StaffModel();
            string pass = txtLogPass.Text;

           

            string email = txtUserName.Text;

            host = LoginClient.hostLogin(email, pass);
            if (host == null)  //if user is not a host then check guest and host
            {
                guest = LoginClient.Guestlogin(email, pass);
                if (guest == null) //user is not a host nor a guest
                {
                    staff = LoginClient.staffLogin(email, pass);
                    if (staff == null) //the user is neither staff, guest nor host
                    {

                       // Response.Redirect("Login.aspx");
                        Popup(false, "Login.aspx");
                    }
                    else    //the user is a staff
                    {
                        SetSessions(staff);
                        int LogID = Convert.ToInt32(Session["ID"]);
                        string homeIndex =  "Index.aspx?LoggedID=" + LogID + "&Type=All";
                        Popup(true, homeIndex);
                      //  Response.Redirect(homeIndex);
                    }
                }
                else   //the user is a guest
                {
                    string survey = Request.QueryString["purp"];
                    
                    if (survey != null && RSVPEventID != null)
                    {
                        SetSessions(guest);
                        string strURL = "EventSurvey.aspx?eventID=" + RSVPEventID;
                        //   Response.Redirect("EventSurvey.aspx?eventID="+ RSVPEventID);
                        GetProfilePicture(guest.ID.ToString()); //Get guest image or default picture
                        Popup(true, strURL);
                    }
                    else
                    if (RSVPEventID != null)
                    {
                        SetSessions(guest);
                        GetProfilePicture(guest.ID.ToString()); //Get guest image or default picture
                        string strURL = "EventRSVP.aspx?ev=" + RSVPEventID;
                    //    Response.Redirect("EventRSVP.aspx?EventID=" + RSVPEventID);
                        Popup(true, strURL);
                    }
                    else
                    {
                        SetSessions(guest);
                        int LogID = Convert.ToInt32(Session["ID"]);
                        GetProfilePicture(LogID.ToString()); //Get guest image or default picture
                        string homeIndex = "Index.aspx?LoggedID=" + LogID + "&Type=Guest";
                        Popup(true, homeIndex);
                    }
                }
            }
            else  //the user is a host
            {
                // txtLogName.Text = host.NAME;
                
                SetSessions(host);
                int LogID = Convert.ToInt32(Session["ID"]);
                string homeIndex = "Index.aspx?LoggedID=" + LogID + "&Type=Host";
                Popup(true, homeIndex);
            }
        }

        public void Popup(bool isSuccess, string strURL)
        {
            string htmltag = "";
                if (isSuccess == true)
                {
                    htmltag = "<div class='alert alert-success text-center' role='alert'>";
                    htmltag += "<button type = 'button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>&times;</span></button>";
                    htmltag += " <strong> Success!</strong> You have been signed in successfully!";
                    htmltag += "</div>";
                    status.InnerHtml = htmltag;
                    Response.AddHeader("REFRESH", "4;URL=" + strURL);
            }
            else
                {
                    htmltag = "<div class='alert alert-danger text-center' role='alert'>";
                    htmltag += "<button type = 'button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>&times;</span></button>";
                    htmltag += " <strong> Danger!</strong> Incorrect Username or Password !";
                    htmltag += "</div>";
                    status.InnerHtml = htmltag;
                //    Response.AddHeader("REFRESH", "6;URL=" + strURL);
            }
        }

        private void GetProfilePicture(string userID)
        {
            string imgLocation;
            img = guestClient.getImageById(userID);
            if (img == null) //If guest does not have a profile picture retrieve default picture
            {
                Session["DEFAULT_IMAGE"] = "ProfilePic.png";
            }
            else
            {
                imgLocation = img.Location;
                Session["PROFILE_IMAGE"] = imgLocation.Substring(imgLocation.IndexOf('E'));
            }

        }

    }
}