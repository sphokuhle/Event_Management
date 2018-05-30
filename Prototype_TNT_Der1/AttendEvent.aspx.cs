using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Prototype_TNT_Der1
{
    public partial class AttendEvent : System.Web.UI.Page
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
            }
            else if (LevelID.Equals("Host"))  //Host logged in
            {
                Name = Convert.ToString(Session["Name"]);
                Surname = Convert.ToString(Session["Surname"]);
                Email = Convert.ToString(Session["Email"]);
            }
            else //new user
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

        protected void btnSave_Click1(object sender, EventArgs e)
        {

        }
    }
}