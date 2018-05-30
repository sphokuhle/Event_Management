using Eventrix_Client.Model;
using Eventrix_Client.Model.ClientDefinition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace EventrixWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IReportingService" in both code and config file together.
    [ServiceContract]
    public interface IReportingService
    {
        //genderGroupings
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "GetTicketCountPerEvent/{eventID}", ResponseFormat =
             WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<int> GetTicketCountPerEvent(string eventID);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "GetNumberOfCheckedGuest/{eventID}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<int> GetNumberOfCheckedGuest(string eventID);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "GetProductStatus/{eventID}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<EventProduct> GetProductStatus(string eventID);

        [OperationContract] //Get most used worked stations
        [WebInvoke(Method = "GET", UriTemplate = "GetMostUsedWorkstation/{eventID}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<StaffModel> GetMostUsedWorkstation(string eventID);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "GetMostCheckedinEntrance/{eventID}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<StaffModel> GetMostCheckedinEntrance(string eventID);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "GetNumberOfShares{eventID}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<int> GetNumberOfShares(string eventID);



        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getAllEventsByHostID/{HostID}", ResponseFormat =
             WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<EventModel> getAllEventsByHostID(string HostID);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "findallProductByHostID/{id}", ResponseFormat = 
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<ProductInfo> findallProductByHostID(string id);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "findallstaffbyHostID/{id}", ResponseFormat =
             WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<StaffModel> findallstaffbyHostID(string id);

        //Range of event hours
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "findEventHours/{id}", ResponseFormat =
             WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<DateTime> findEventHours(string id);

        //Get checked in tickets in interval 1
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "TicketInIntervals/{eventID}/{myInerval}", ResponseFormat =
             WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<int> TicketInIntervals(string eventID, string myInerval);

        //List<int> findTime(string id)
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "HourlyInterVals/{id}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<string> HourlyInterVals(string id);

        //Get Latest View
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "GetLatestView/{eventID},{Type}", ResponseFormat =
             WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        string GetLatestView(string eventID, string Type);

        //Get Confirmed RSVP
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "RSVPGuest/{eventID},{Type}", ResponseFormat =
             WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<GuestModel> RSVPGuest(string eventID, string Type);

        //Get Declined RSVP
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "RSVPCount/{eventID}", ResponseFormat =
             WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<int> RSVPCount(string eventID);

    }
}
