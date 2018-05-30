using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Prototype_TNT_Der1
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session.Count >= 1)
            {
                Session.Abandon(); int LogID = Convert.ToInt32(Session["ID"]);
                string homeIndex = "Index.aspx?LoggedID=" + 0 + "&Type=All";
                Response.Redirect(homeIndex);
            }
        }
    }
}