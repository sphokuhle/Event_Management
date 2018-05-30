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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IScanningService" in both code and config file together.
    [ServiceContract]
    public interface IScanningService
    {
        //updating the ticket template table after scanning qr code
        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "updateTicket",
            ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool updateQRCode(QRCodeImage image);

        //Get User's Event
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "GetEventByGuestID/{G_ID}", ResponseFormat =
             WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<EventModel> GetEventByProductID(string G_ID);

        //Get User's Event
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "CheckInGuest/{QR_ID},{S_ID}", ResponseFormat =
             WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool CheckInGuest(string QR_ID, string S_ID);

        //Get User's Event
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "PurchaseProduct/{QR_ID},{ProductID},{quantity},{str_StaffID}", ResponseFormat =
             WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        string PurchaseProduct(string QR_ID, string ProductID, string quantity, string str_StaffID);
    }
}
