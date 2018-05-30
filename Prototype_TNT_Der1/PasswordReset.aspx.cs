using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Prototype_TNT_Der1
{
    public partial class PasswordReset : System.Web.UI.Page
    {
        WebClient proxy = new WebClient();
        char quote;
        protected void Page_Load(object sender, EventArgs e)
        {
            quote = '"';
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            string userUrl =
                string.Format("http://localhost:53056/GuestEdit.svc/requestPassword/{0}", txtEmail.Text);
            byte[] _data = proxy.DownloadData(userUrl);
            Stream memory = new MemoryStream(_data);
            var reader = new StreamReader(memory);
            string result = reader.ReadToEnd().Replace("requestPassword", "").Replace("Result", "").
                Replace(quote + "", "").Replace("{", "").Replace("}", "").Replace(":", "");
            lblResponse.Text = result;
            lblResponse.Visible = true;
        }
    }
}