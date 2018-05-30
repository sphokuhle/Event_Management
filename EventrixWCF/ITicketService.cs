using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;
using Eventrix_Client.Model.ClientDefinition;

namespace EventrixWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITicketService" in both code and config file together.
    [ServiceContract]
    public interface ITicketService
    {

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "createTicket", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        string createTicket(EventTicket _ticket);

        //Guest Purchases TIcket
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "purchaseTicket", ResponseFormat =
              WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        int purchaseTicket(EventTicket _ticket);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getTicketbyEventID/{EventID}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<EventTicket> getTicketbyEventID(string EventID);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getTicketByEventIDANDGuestID/{QRCOde}", ResponseFormat =
         WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        EventTicket getTicketByEventIDANDGuestID(string QRCOde);


        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getVIPTicket/{EventID}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        EventTicket getVIPTicket(string EventID);


        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getVVIPTicket/{EventID}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        EventTicket getVVIPTicket(string EventID);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getRegularTicket/{EventID}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        EventTicket getRegularTicket(string EventID);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getEarlyBirdTicket/{EventID}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        EventTicket getEarlyBirdTicket(string EventID);

        //Get Guest QR Code by event ID
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getQRCodeListByEventID/{evnetID}", ResponseFormat =
             WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<QRCodeImage> getQRCodeListByEventID(string evnetID);

        //Get Guest Ticket(Bridging table) by event ID
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getGuestTicketByEventID/{evnetID}", ResponseFormat =
             WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<GuestTicket_BT> getGuestTicketByEventID(string evnetID);

        //Get Ticket template(Bridging table) by event ID
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getTicketTemplateByEventID/{evnetID}", ResponseFormat =
             WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<EventTicket> getTicketTemplateByEventID(string evnetID);

        //Get Ticket template by QR Code ID
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getTicketByGuestID/{QRCOdeID}", ResponseFormat =
             WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        EventTicket getTicketByGuestID(string QRCOdeID);

        //Get Guest's Ticket for a specific event
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "GetGuestTicketForEvent/{GuestID},{EventID}", ResponseFormat =
             WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<EventTicket> GetGuestTicketForEvent(string GuestID, string EventID);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "EditTicket", ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        bool EditTicket(EventTicket _ticket);

        //PurchaseTicket
        //update
        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "UpdateTiket", ResponseFormat =
         WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        string UpdateTiket(EventTicket _ticket);

        //Update ticket credit
        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "UploadCredit", ResponseFormat =
                WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool UploadCredit(EventTicket _ticket);


        //Deletions
        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "deleteTicketByID/{eventID}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        string deleteTicketByID(string eventID);

        //delete QR Code by event ID
        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "deleteQRCodeByEventID/{eventID}", ResponseFormat =
             WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        string deleteQRCodeByEventID(string eventID);

        //delete ticket template
        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "deleteTicketTemplateByEventID/{EventID}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        string deleteTicketTemplateByEventID(string EventID);

        //Deletion guest_ticket bridging table
        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "delete_Guest_Ticket_ByEventID/{eventID}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        string delete_Guest_Ticket_ByEventID(string eventID);

        //Delete guest QR Code by BT_ID
        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "dl_BT_AND_QRCode/{G_ID},{EventID}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        int dl_BT_AND_QRCode(string G_ID, string EventID);
    }
}
