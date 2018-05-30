using Eventrix_Client.Model.ServiceClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Prototype_TNT_Der1
{
    public partial class DeleteTicket : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string eventID = Request.QueryString["EventID"];
            string GuestID = Convert.ToString(Session["ID"]);
            TicketServiceClient tsv = new TicketServiceClient();
            string dl_BridgingTable = tsv.dl_BT_AND_QRCode(GuestID, eventID);
            if(dl_BridgingTable.ToLower().Contains("success"))
            {
                //Change RSVP Status
                EventServiceClient esc = new EventServiceClient();
                bool isChanged = esc.RecordRSVP(eventID, GuestID, "Declined");
            }
            Response.Redirect("GuestManagement.aspx?GuestID=" + GuestID);
        }
    }
}