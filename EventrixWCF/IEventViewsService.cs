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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IEventViewsService" in both code and config file together.
    [ServiceContract]
    public interface IEventViewsService
    {        
        //Get All Event Views Per Event
        [OperationContract]
        //"hostlogin?email={email}&password={password}"
        [WebInvoke(Method = "GET", UriTemplate = "ViewsStat/{eventID}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        EventModel ViewsStat(string eventID);


        ////Get checked in tickets in interval 1
        //[OperationContract]
        //[WebInvoke(Method = "GET", UriTemplate = "TicketInIntervals/{eventID}/{myInerval}", ResponseFormat =
        //     WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        //List<int> TicketInIntervals(string eventID, string myInerval);
    }
}
