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
    public partial class Tester : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if(!IsPostBack)
            //{

            //}
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ScanningServiceClient ssc = new ScanningServiceClient();
            string ID = "3238";
            bool  isCheckedIn = ssc.PurchaseProduct(ID, "3054");
            if(isCheckedIn)
            {
                String name = "asdfghgfdsfgh";
            }else
            {
                String name = "asdfghgfdsfgh";
            }
        }
    }
}