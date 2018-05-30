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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IProductService" in both code and config file together.
    [ServiceContract]
    public interface IProductService
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "createProduct", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        string createProduct(EventProduct product);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "findallproduct", ResponseFormat = WebMessageFormat.Json
             , RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        List<EventProduct> findallproduct();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getProductByEventID/{EventID}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<EventProduct> getProductByEventID(string EventID);


        //update Product Credit
        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "updateProduct/{id}", ResponseFormat =
         WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        EventModel updateProduct(string id, EventModel _event);

        //Deletions
        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "deleteProductByID/{eventID}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        string deleteProductByID(string eventID);

    }
}
