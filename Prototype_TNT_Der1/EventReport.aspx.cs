using Eventrix_Client.Model.ServiceClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Prototype_TNT_Der1
{
    public partial class EventReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                //string html = "";
                //int count = 0;
                //for (int i = 0; i < 4; i++)
                //{
                //    count = i + 50;
                //    html += "<div class='col-md-3 col-sm-6'>";
                //    html += "<div class='our-progress' >";
                //    html += "<div class='chart' data-percent='" + count + "'>";
                //    html += "<span class='percent'>" + count + "</span>";
                //    html += "</div></div></div>";
                //    count += 20;
                //}
                //piechart.InnerHtml = html;
              //  String request = (Request.QueryString["EventID"]);
                string eventID = Request.QueryString["EventID"];
                List<int> ticketList = new List<int>();
                List<double> percentageList = new List<double>();
                ReportServiceClient _report = new ReportServiceClient();
                ticketList = _report.GetTicketCountPerEvent(eventID);
                percentageList = calculatepercentage(ticketList);
                string html = "";
                for(int i = 0; i < percentageList.Count(); i++)
                {
                    html += "<div class='col-md-3 col-sm-6'>";
                    html += "<div class='Number of Tickets by Type' >";
                    html += "<div class='chart' data-percent='" + percentageList[i] + "'>";
                    html += "<span class='percent'>" + percentageList[i] + "</span>";
                    html += "</div></div></div>";
                }
                piechart.InnerHtml = html;
            }
        }

        //fucntion to calculate average for number ofticket for each ticket type
        public List<double> calculatepercentage(List<int> ticketList)
        {
            int var1 = ticketList[0];
            int var2 = ticketList[1];
            int var3 = ticketList[2];
            int var4 = ticketList[3];

            if(var1 == 0)
            {
                var1 = 1;
            }
            if(var2 == 0)
            {
                var2 = 1;
            }
            if(var3 == 0)
            {
                var3 = 1;
            }
            if(var4 == 0)
            {
                var4 = 1;
            }
            int total = ticketList.Sum();
            double perc1 = (double)var1 /total;
            double perc2 = (double)var2 / total;
            double perc3 = (double)var3 / total;
            double perc4 = (double)var4 / total;

            double finalPercentage1 = perc1 * 100;
            double finalPercentage2 = perc2 * 100;
            double finalPercentage3 = perc3 * 100;
            double finalPercentage4 = perc4 * 100;

            List<double> percList = new List<double>();
            percList.Add(finalPercentage1);
            percList.Add(finalPercentage2);
            percList.Add(finalPercentage3);
            percList.Add(finalPercentage4);
            return percList;
        }

    }
}