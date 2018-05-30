using Eventrix_Client.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace EventrixWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMappingService" in both code and config file together.
    [ServiceContract]
    public interface IMappingService
    {
        //Insertions
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "createAddress", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        int createAddress(EventAddress _Address);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getAddressById/{id}", ResponseFormat =
        WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        EventAddress getAddressById(string id);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getAddressByEventId/{eventid}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        EventAddress getAddressByEventId(string eventid);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getAllAddresses", ResponseFormat =
        WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<EventAddress> getAllAddresses();

        //Update
        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "updateAddress/{id}", ResponseFormat =
         WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        EventAddress updateAddress(string id, EventAddress _Address);

        // deleteAddressByID(string ID)

        //Deletions
        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "deleteAddressByID/{ID}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        string deleteAddressByID(string ID);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getLatLong/{street},{town},{city}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        List<string> getLatLong(string street, string town, string city);

    }
}
