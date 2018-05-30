using Eventrix_Client.Model;
using Eventrix_Client.Model.ClientDefinition;
using Eventrix_Client.Model.ServiceClient;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

namespace Prototype_TNT_Der1
{
    public partial class GeneralReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string HostID = "";
            HostID = Convert.ToString(Session["ID"]);
            if (!IsPostBack)
            {
                populateReportData(HostID);
                //Creating chart
                GetChartData();
                GetChartType();
            }
        }

        //GetChartType
        private void GetChartType()
        {
            foreach(int chartType in Enum.GetValues(typeof(SeriesChartType)))
            {
                ListItem li = new ListItem(Enum.GetName(typeof(SeriesChartType), chartType), chartType.ToString());
                drpChartType.Items.Add(li);

            }
        }

        //populate report
        private void populateReportData(string HostID)
        {
            List<EventModel> eventlist = new List<EventModel>();
            List<StaffModel> stafflist = new List<StaffModel>();
            List<ProductInfo> productlist = new List<ProductInfo>();
            ReportServiceClient report = new ReportServiceClient();
            eventlist = report.findEventbyID(HostID);
            stafflist = report.findallstaffbyHostID(HostID);
            productlist = report.findallProductByHostID(HostID);
            if (eventlist == null && stafflist == null && productlist == null)
            {
                //Load new Reports
                ReportViewer1.LocalReport.DataSources.Clear();
                Response.Write("<script>alert('Report not found.');</script>");
            }
            else if (eventlist == null && stafflist == null && productlist != null)
            {
                //Load new Reports
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportDataSource rd3 = new ReportDataSource("EventProduct", productlist);
                ReportViewer1.LocalReport.DataSources.Add(rd3);
                ReportViewer1.LocalReport.Refresh();
            }
            else if (eventlist == null && stafflist != null && productlist == null)
            {
                //Load new Reports
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportDataSource rd2 = new ReportDataSource("EventStaff", stafflist);
                ReportViewer1.LocalReport.DataSources.Add(rd2);
                ReportViewer1.LocalReport.Refresh();
            }
            else if (eventlist != null && stafflist == null && productlist == null)
            {
                //Load new Reports
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportDataSource rd1 = new ReportDataSource("HostEvents", eventlist);
                ReportViewer1.LocalReport.DataSources.Add(rd1);
                ReportViewer1.LocalReport.Refresh();
            }
            else if (eventlist != null && stafflist == null && productlist != null)
            {
                //Load new Reports
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportDataSource rd1 = new ReportDataSource("HostEvents", eventlist);
                ReportDataSource rd3 = new ReportDataSource("EventProduct", productlist);
                ReportViewer1.LocalReport.DataSources.Add(rd1);
                ReportViewer1.LocalReport.DataSources.Add(rd3);
                ReportViewer1.LocalReport.Refresh();
            }
            else if (eventlist != null && stafflist != null && productlist == null)
            {
                //Load new Reports
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportDataSource rd1 = new ReportDataSource("HostEvents", eventlist);
                ReportDataSource rd2 = new ReportDataSource("EventStaff", stafflist);
                ReportViewer1.LocalReport.DataSources.Add(rd1);
                ReportViewer1.LocalReport.DataSources.Add(rd2);
                ReportViewer1.LocalReport.Refresh();
            }
            else if (eventlist != null && stafflist != null && productlist != null)
            {
                //Load new Reports
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportDataSource rd1 = new ReportDataSource("HostEvents", eventlist);
                ReportDataSource rd2 = new ReportDataSource("EventStaff", stafflist);
                ReportDataSource rd3 = new ReportDataSource("EventProduct", productlist);
                ReportViewer1.LocalReport.DataSources.Add(rd1);
                ReportViewer1.LocalReport.DataSources.Add(rd2);
                ReportViewer1.LocalReport.DataSources.Add(rd3);
                ReportViewer1.LocalReport.Refresh();
            }
        }

        protected void drpChartType_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetChartData();
            NumViewsChart.Series["ChartSeries"].ChartType = (SeriesChartType)Enum.Parse(typeof(SeriesChartType), drpChartType.SelectedValue);
        }
        private void GetChartData()
        {
            string _hostID = "";
            string htmltag = "";
            _hostID = Convert.ToString(Session["ID"]);
            Series series = NumViewsChart.Series["ChartSeries"];
            List<EventModel> eventList = new List<EventModel>();
            ReportServiceClient _chartReport = new ReportServiceClient();
            eventList = _chartReport.findEventbyID(_hostID);
            foreach(EventModel _list in eventList)
            {
                series.Points.AddXY(_list.EventID.ToString(), _list.EventView);
                htmltag += "<h4>" +  _list.EventID + " = " + _list.Name + "</h4>";
            }
            tdKeys.InnerHtml = htmltag;
        }
    }
}