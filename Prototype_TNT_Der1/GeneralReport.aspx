<%@ Page Title="" Language="C#" MasterPageFile="~/Eventrix.Master" AutoEventWireup="true" CodeBehind="GeneralReport.aspx.cs" Inherits="Prototype_TNT_Der1.GeneralReport" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <section class="page-header-wrapper">
					<div class="container">
						<div class="row">
							<div class="col-md-12">
								<div class="page-header">
								  <h1>Events</h1>
								</div>
								<ol class="breadcrumb">
								  <li><a href="#">Home</a></li>
								  <li class="active">Event Report</li>
								</ol>
							</div>
						</div><!-- /.row -->
					</div><!-- /.container-fluid -->
            
				</section>
    	        <h3>Skill Chart</h3>
    <br/> <br/>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="926px">
        <localreport reportpath="Reports\EventHostReport.rdlc">
        </localreport>
            </rsweb:ReportViewer>
    <br/><br/>
    <table  style="border: 1px solid black; font-family:Arial">
        <tr>
            <td>
                <h3>Select Chart Type</h3>
            </td>
            <td>
                <asp:DropDownList ID="drpChartType" AutoPostBack="true" runat="server" OnSelectedIndexChanged="drpChartType_SelectedIndexChanged"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td colspan="2">
            <asp:Chart ID="NumViewsChart" runat="server" Width="322px">
               <Titles>
                   <asp:Title Text="Eventrix: Number of Event Views"></asp:Title>
               </Titles>
                <Series>
                 <asp:Series Name="ChartSeries" ChartArea="NumViewsChartArea" ChartType="Pie">
                 </asp:Series>
                </Series>
             <ChartAreas>
                 <asp:ChartArea Name="NumViewsChartArea">
                     <AxisX Title="Event Name"></AxisX>
                     <AxisY Title="Numbere of Views"></AxisY>
                    
                 </asp:ChartArea>
                 
             </ChartAreas>
            </asp:Chart>
            </td>
        </tr>
        <tr>
            <td>
                <span>Keys:</span>
            </td>
        </tr>
        <tr>
           <td runat="server" id="tdKeys">
           </td>
        </tr>
    </table>


</asp:Content>
