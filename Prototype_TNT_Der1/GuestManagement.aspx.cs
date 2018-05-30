using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Prototype_TNT_Der1
{
    public partial class GuestManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int LoggedID = Convert.ToInt32(Session["ID"]);
            string htmltag = "";
            htmltag = "<a href='GuestTicketList.aspx?hostID=" + LoggedID + "' class='btn btn-default btn-xs'><i class='fa fa-pencil'></i>Load Ticket</a>";
            loadTicket.InnerHtml = htmltag;
        }
    }
}