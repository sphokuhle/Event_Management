using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace EventrixWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceHost" in both code and config file together.
    [ServiceContract]
    public interface IServiceHost
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "findallhost", ResponseFormat = WebMessageFormat.Json
            , RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        List<Host> findallhost();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "findHostbyID/{id}", ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        Host findHostbyID(string id);
        

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "createHost", ResponseFormat = WebMessageFormat.Json
            , RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        bool createHost(Host _host);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "editHost", ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        bool editHost(Host _host);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "deleteHost", ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        bool deleteHost(Host _host);
    }
}
