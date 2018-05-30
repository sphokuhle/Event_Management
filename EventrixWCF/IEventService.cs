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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IEventService" in both code and config file together.
    [ServiceContract]
    public interface IEventService
    {
        //Setters
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "createEvent", ResponseFormat =
          WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        string createEvent(EventModel _event);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "RecordView", ResponseFormat =
        WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool RecordView(EventViews _views);


        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "findEventID", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        int findEventID(EventModel _event);

        //
        //Setters
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "RecordRSVP/{eventID},{GuestID},{Status}", ResponseFormat =
          WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool RecordRSVP(string eventID, string GuestID, string Status);
        //Get
        //Get All Event Views Per Event
        [OperationContract]
        //"hostlogin?email={email}&password={password}"
        [WebInvoke(Method = "GET", UriTemplate = "ViewsStat/{eventID},{Type}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        int ViewsStat(string eventID, string Type);

        // DateTime ViewsStatDate(string eventID)
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getAllEvents", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<EventModel> getAllEvents();


        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getAllEventsByHostID/{HostID},{Guest_ID}", ResponseFormat =
             WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<EventModel> getAllEventsByHostID(string HostID, string Guest_ID);

        //get guest's live events
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "GuestLiveEvent/{Guest_ID}", ResponseFormat =
             WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<EventModel> GuestLiveEvent(string Guest_ID);

        //Home Page Event List
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getHomeEvent/{UserID},{type}", ResponseFormat =
       WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<EventModel> getHomeEvent(string UserID, string type);

        //get guest's single events || to be called after scanning
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "EventByQRCodeID/{ID}", ResponseFormat =
             WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        EventModel EventByQRCodeID(string ID);

        //get guest's info || to be called after scanning
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "GuestByQRCodeID/{ID}", ResponseFormat =
             WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        GuestModel GuestByQRCodeID(string ID);

        //get guest event list along with ticket info
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "GuestEventTicketList/{Guest_ID}", ResponseFormat =
               WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<EventModel> GuestEventTicketList(string Guest_ID);


        //get guest event list along with ticket info
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "TestGustEventList/{Guest_ID}", ResponseFormat =
               WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<int> TestGustEventList(string Guest_ID);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getEventByEventID/{EventID}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        EventModel getEventByEventID(string EventID);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "findGuestEventsByGuestID/{guest_ID}", ResponseFormat = WebMessageFormat.Json,
             RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        List<EventModel> findGuestEventsByGuestID(string guest_ID);



        //Deletions
        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "deleteEventByID/{eventID}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        string deleteEventByID(string eventID);

        //Deletions
        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "dl_EnevtRSVP/{eventID}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool dl_EnevtRSVP(string eventID);


        //update
        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "updateEvent/{id}", ResponseFormat =
         WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        EventModel updateEvent(string id, EventModel _event);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "addEventView", ResponseFormat =
         WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        bool addEventView(EventModel _event);

    }
}
