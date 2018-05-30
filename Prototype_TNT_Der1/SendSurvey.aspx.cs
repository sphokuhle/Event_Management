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
    public partial class SendSurvey : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int E_ID = Convert.ToInt32(Request.QueryString["eventID"]);
            string LoggedID = Convert.ToString(Session["ID"]);

            EventServiceClient esc = new EventServiceClient();
            EventModel _event = new EventModel();
            GuestServiceClient gsc = new GuestServiceClient();
            EmailClient email = new EmailClient();

            List<GuestModel> gst = gsc.findGuestAttendingEvent(Convert.ToString(E_ID));
            _event = esc.findByEventID(Convert.ToString(E_ID));

            if(gst.Count() != 0)
            {
                foreach(GuestModel guest in gst)
                {
                    email.sendSurvey(guest.NAME, guest.EMAIL, _event);
                }
                Response.Redirect("EventManagement.aspx?HostID=" + LoggedID);
            }
            else
            {
                Response.Redirect("EventManagement.aspx?HostID=" + LoggedID);
            }

        }
    }
}