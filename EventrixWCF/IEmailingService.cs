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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IEmailingService" in both code and config file together.
    [ServiceContract]
    public interface IEmailingService
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getGuestsForEvent/{eventID}", ResponseFormat =
             WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<Guest> getGuestsForEvent(string eventID);
    }
}
