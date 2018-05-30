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
    public partial class AAFReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string eventID = Request.QueryString["ev"];
            // GetNumViews(string eventID, string Type)
            EventServiceClient esv = new EventServiceClient();
            ReportServiceClient reportClient = new ReportServiceClient();
            EventModel myEvent = new EventModel();
            //Get Number of Event Vies
            int EventViews = esv.GetNumViews(eventID, "Views");
            int EventShares = esv.GetNumViews(eventID, "Shares");
            string RecentShareDate = reportClient.GetLatestView(eventID, "Shares");
            string RecentViewDate = reportClient.GetLatestView(eventID, "Views");
            numViews.InnerHtml = Convert.ToString(EventViews);
            numShares.InnerHtml = Convert.ToString(EventShares);
            ViewDate.InnerHtml = RecentViewDate;
            shareDate.InnerHtml = RecentShareDate;
            //Get Event Details
            myEvent = esv.findByEventID(eventID);

            //EventProduct
            //getProductByEventID(string EventID)
            ProductServiceClient psv = new ProductServiceClient();
            List<EventProduct> product = new List<EventProduct>();
            product = psv.getProductByEventID(eventID);
            if(product.Count() != 0)
            {
                string htmtag = "";
                int count = 1;
                foreach(EventProduct _prod in product)
                {
                    double productSold = _prod._Quantity - _prod.ProdRemaining;
                  
                    double half = Math.Round((double)(_prod._Quantity) / 2, 2);
                    double perc = Math.Round((productSold / _prod._Quantity) * 100);
                    htmtag += "<tr>";
                    htmtag += "<td scope ='row' style='text-align:center;'>" + count+"</td>";
                    htmtag += "<td style='text-align:center;'>" + _prod._Name+"</td>";
                    if(productSold > _prod.ProdRemaining)  //sold more than half of toltal product
                    {
                        htmtag += "<td style='text-align:center;'><span class='label label-success'>" + productSold + "</span></td>";
                        htmtag += "<td style='text-align:center;'><span class='label label-success'>" + _prod.ProdRemaining + "</span></td>";
                        htmtag += "<td style='text-align:center;'><h5>" + perc + "%<i class='fa fa-level-up'></i></h5></td></tr>";
                    }
                    else //Less than half of the product were sold
                    {
                        htmtag += "<td style='text-align:center;'><span class='label label-danger'>" + productSold + "</span></td>";
                        htmtag += "<td style='text-align:center;'><span class='label label-danger'>" + _prod.ProdRemaining + "</span></td>";
                        htmtag += "<td style='text-align:center;'><h5>" + perc + "%<i class='fa fa-level-down'></i></h5></td></tr>";
                    }
                    count++;
                }
                ProductRowDiv.InnerHtml = htmtag;


                //Number Scans Per Work Stations
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
               // string eventID = Request.QueryString["EventID"];
                List<StaffModel> StaffList = new List<StaffModel>();
                List<double> percentageList = new List<double>();
                ReportServiceClient _report = new ReportServiceClient();
                StaffList = _report.GetMostUsedWorkstation(eventID);
                if(StaffList != null)
                {
                    percentageList = calculatepercentage(StaffList);
                    string html = "";
                    for (int i = 0; i < percentageList.Count(); i++)
                    {
                        html += "<div class='col-md-3 col-sm-6'>";
                        html += "<div class='Number of Tickets by Type' >";
                        html += "<div class='chart' data-percent='" + percentageList[i] + "'>";
                        html += "<span class='percent'>" + percentageList[i] + "</span></div>";
                        html += "<span>" + StaffList[i].NAME + "</span>";
                        html += "<span>" + StaffList[i].WorkStation + "</span>";
                        html += "</div></div>";
                    }
                    piechart.InnerHtml = html;

                }
                //Track Most CHecked In Entrance
                List<StaffModel> ch_StaffList = new List<StaffModel>();
                List<double> ch_percentageList = new List<double>();
                ch_StaffList = _report.GetMostCheckedinEntrance(eventID);
                if (ch_StaffList != null)
                {
                    ch_percentageList = calculatepercentage(ch_StaffList);
                    string html = "";
                    for (int i = 0; i < ch_percentageList.Count(); i++)
                    {
                        html += "<div class='col-md-3 col-sm-6'>";
                        html += "<div class='Number of Tickets by Type' >";
                        html += "<div class='chart' data-percent='" + ch_percentageList[i] + "'>";
                        html += "<span class='percent'>" + ch_percentageList[i] + "</span></div>";
                        html += "<span>" + ch_StaffList[i].NAME + "</span>";
                        html += "<span>" + ch_StaffList[i].WorkStation + "</span>";
                        html += "</div></div>";
                    }
                    DivCheckedIn.InnerHtml = html;

                }

            }
            //Declined Guest
            List<GuestModel> Declinedguests = new List<GuestModel>();
            Declinedguests = reportClient.RSVPGuest(eventID, "Declined");
            //declinedRSVP.InnerHtml = Convert.ToString(Declinedguests.Count());
            //list of RSVP'd geust
            //RSVPd_Guest
            if (Declinedguests.Count() != 0)
            {
                string htmltage = "";
                foreach (GuestModel guest in Declinedguests)
                {
                    htmltage += "<li>Guest Name: " + guest.NAME + ", Email: " + guest.EMAIL + "</li>";
                }
                //Send to front End
            }


            //Get Number of RSVP'd guest
            List<GuestModel> Confirmedguests = new List<GuestModel>();
            Confirmedguests = reportClient.RSVPGuest(eventID, "Confirmed");
           // confirmedRSVP.InnerHtml = Convert.ToString(Confirmedguests.Count());
            //list of RSVP'd geust
            //RSVPd_Guest
            if (Confirmedguests.Count() != 0)
            {
                string htmltage = "";
                foreach (GuestModel guest in Confirmedguests)
                {
                    htmltage += "<li>Guest Name: " + guest.NAME + ", Email: " + guest.EMAIL + "</li>";
                }
                //Send to front End
                // RSVPd_Guest.InnerHtml = htmltage;
            }

        }

        //fucntion to calculate average for number of Scans  for each scanner 
        public List<double> calculatepercentage(List<StaffModel> staffList)
        {
            int Count = staffList.Count();
            int sum = staffList.Sum(pe => pe.NumScans);
            
            List<double> perc = new List<double>();
            for (int i = 0; i < Count; i++)
            {
                double percentage1 = (double)staffList.ElementAt(i).NumScans / sum;
                double finalPercentage = percentage1 * 100;
                perc.Add(finalPercentage);
            }
            return perc;
        }

    }
}