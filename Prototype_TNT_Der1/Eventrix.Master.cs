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
	public partial class Eventrix : System.Web.UI.MasterPage
	{
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID"] != null)
            {
                string htmltag = "";
                if (Session["PROFILE_IMAGE"] != null)
                {
                    htmltag += "<a href='EditGuest.aspx'>";
                    htmltag += "<img class='profile-pic' src='" + Session["PROFILE_IMAGE"] + "' alt='' />";
                    htmltag += "</a>";

                }
                else if (Session["DEFAULT_IMAGE"].Equals("ProfilePic.png"))
                {
                    htmltag += "<a class='navbar-brand' href='EditGuest.aspx'>";
                    htmltag += "<img class='profile-pic' src='" + Session["DEFAULT_IMAGE"] + "' alt='' />";
                    htmltag += "</a>";
                }
                profilePic.Visible = true;
                profilePic.InnerHtml = htmltag;

            }
            if (Session.Count >= 1)
            {
                if (Session["Level"].Equals("Host"))
                {
                    event_management.Visible = false;
                    list_login.Visible = false;
                    list_reg.Visible = false;
                    list_account.Visible = true;
                    MyEvents.Visible = true;
                    Ticket.Visible = false;
                    editGuest.Visible = false;

                    createEvent.Visible = true;
                    //Off Canvas Nav Menu

                    offMyEvents.Visible = true;
                    Off_EventManagement.Visible = false;
                    offLogin.Visible = false;
                    offReg.Visible = false;
                    offAcc.Visible = true;

                 //   getUrlParameter('LoggedID') + "," + getUrlParameter('Type'));
                    int UserID = Convert.ToInt32(Session["ID"]);
                    homeList.InnerHtml = "<a class='navbar-brand' href='Index.aspx?LoggedID=" + UserID + "&Type=Host'>Home</a>";
                    OffLogo.InnerHtml = "<a class='navbar-brand' href='Index.aspx?LoggedID=" + UserID + "&Type=Host'>TNT Eventrix</a>";
                    
                    string html = "<a class='navbar-brand' href='Index.aspx?LoggedID=" + UserID + "&Type=Host'>";
                    html += "<img src='img/background/eventrix-logo.png' alt=''/>";
                    logoID.InnerHtml = html;


                    string htmtag = "";
                    string LoggedID = Convert.ToString(Session["ID"]);
                    htmtag = "<a href='EventManagement.aspx?HostID= " + LoggedID + "'>My Event</a>";
                    MyEvents.InnerHtml = htmtag;
                    offMyEvents.InnerHtml = htmtag;
                }
                else if (Session["Level"].Equals("Staff"))
                {
                    event_management.Visible = false;
                    list_login.Visible = false;
                    list_reg.Visible = false;
                    list_account.Visible = true;
                    editGuest.Visible = false;
                    //   PaymentSetting.Visible = false;
                    DeleteAccount.Visible = false;
                    MyEvents.Visible = false;
                    Ticket.Visible = false;
                    createEvent.Visible = false;

                    //Off Canvas Nav Menu
                    offMyEvents.Visible = false;
                    Off_EventManagement.Visible = false;
                    offLogin.Visible = false;
                    offReg.Visible = false;
                    offAcc.Visible = true;
                  //  offPaymentSetting.Visible = false;
                    OffDeleteAcc.Visible = false;

                    int UserID = Convert.ToInt32(Session["ID"]);
                    homeList.InnerHtml = "<a href='Index.aspx?LoggedID=" + UserID + "&Type=All'> Home </a>";
                    OffLogo.InnerHtml = "<a href='Index.aspx?LoggedID=" + UserID + "&Type=All'> TNT Eventrix </a>";
                    string html = "<a class='navbar-brand' href='Index.aspx?LoggedID=" + UserID + "&Type=All'>";
                    html += "<img src='img/background/eventrix-logo.png' alt=''/>";
                    logoID.InnerHtml = html;
                }
                else if (Session["Level"].Equals("Guest"))
                {
                    event_management.Visible = false;
                    list_login.Visible = false;
                    list_reg.Visible = false;
                    list_account.Visible = true;
                    MyEvents.Visible = true;
                    createEvent.Visible = false;
                    //Off Canvas Nav Menu
                    offMyEvents.Visible = true;
                    Off_EventManagement.Visible = false;
                    offLogin.Visible = false;
                    offReg.Visible = false;
                    offAcc.Visible = true;

                    //GuestManagement.aspx
                    // htmtag += "<a href='GuestTicketList.aspx?hostID=" + Guest_ID + "'>Load Ticket</a>";
                    //  loadticket.InnerHtml = htmtag;
                    int UserID = Convert.ToInt32(Session["ID"]);
                    homeList.InnerHtml = "<a href='Index.aspx?LoggedID=" + UserID + "&Type=Guest'> Home </a>";
                    OffLogo.InnerHtml = "<a href='Index.aspx?LoggedID=" + UserID + "&Type=Guest'> TNT Eventrix </a>";
                    string html = "<a class='navbar-brand' href='Index.aspx?LoggedID=" + UserID + "&Type=Guest'>";
                    html += "<img src='img/background/eventrix-logo.png' alt=''/>";
                    logoID.InnerHtml = html;


                    string G_ID = Convert.ToString(Session["ID"]);
                    string htmltag = "";
                    htmltag = "<a href='GuestManagement.aspx?GuestID=" + G_ID + "'>My Event<b class='caret'></b></a>";
                    MyEvents.InnerHtml = htmltag;
                    offMyEvents.InnerText = htmltag;
                }
            }
            else
            {
                
                event_management.Visible = false;
                list_login.Visible = true;
                list_reg.Visible = true;
                list_account.Visible = false;
                MyEvents.Visible = false;
                Ticket.Visible = false;
                createEvent.Visible = false;
                //Off Canvas Nav Menu
                offMyEvents.Visible = false;
                Off_EventManagement.Visible = false;
                offLogin.Visible = true;
                offReg.Visible = true;
                offAcc.Visible = false;

                int UserID = 0;
                homeList.InnerHtml = "<a href='Index.aspx?LoggedID=" + UserID + "&Type=All'> Home </a>";
                OffLogo.InnerHtml = "<a href='Index.aspx?LoggedID=" + UserID + "&Type=All'> TNT Eventrix </a>";
                string html = "<a class='navbar-brand' href='Index.aspx?LoggedID=" + UserID + "&Type=All'>";
                html += "<img src='img/background/eventrix-logo.png' alt=''/>";
                logoID.InnerHtml = html;
            }

        }
	}
}