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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUpdate" in both code and config file together.
    [ServiceContract]
    public interface IUpdate
    {
        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "updateTester/{id}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        UpdateModel updateTester(string id, UpdateModel um);
        // TODO: Add your service operations here
    }
}
