using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Prototype_TNT_Der1
{
    public partial class DownloadSpreadSheet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string filename = Request.QueryString["fl"];
            //Response.ContentType = "Application/x-msexcel";
            //Response.AppendHeader("Content-Disposition", "attachment;filename=" + filename);
            //string aaa = Server.MapPath("~/Template/" + filename);
            //Response.TransmitFile(aaa);
            //Response.End();

            WebClient req = new WebClient();
            HttpResponse response = HttpContext.Current.Response;
            response.Clear();
            response.ClearHeaders();
            response.Buffer = true;
            response.AddHeader("Content-Disposition", "attachment;filename=" + filename);
            byte[] data = req.DownloadData(Server.MapPath("~/Download/" + filename));
            response.BinaryWrite(data);
            response.End();

            Response.Redirect("CreateEvent.aspx");
        }
    }
}