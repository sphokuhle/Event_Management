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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceGuest" in both code and config file together.
    [ServiceContract]
    public interface IServiceGuest
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "findallguest", ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        List<EventGuest> findallguest();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "findGuestbyID/{id}", ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        EventGuest findGuestbyID(string id);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "findGuestEventsByGuestID/{guest_ID}", ResponseFormat = WebMessageFormat.Json,
          RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        List<EventInfo> findGuestEventsByGuestID(string guest_ID);

        //Find All Guest Attennding event
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "findGuestAttendingEvent/{eventID}", ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json)]
        List<EventGuest> findGuestAttendingEvent(string eventID);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "createGuest", ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        bool createGuest(EventGuest _guest);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "editGuest", ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        bool editGuest(EventGuest _guest);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "deleteGuest", ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        bool deleteGuest(EventGuest _guest);
    }
}
