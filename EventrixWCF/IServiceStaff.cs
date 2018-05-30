using Eventrix_Client.Model;
using EventrixWCF.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace EventrixWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceStaff" in both code and config file together.
    [ServiceContract]
    public interface IServiceStaff
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "findallstaff", ResponseFormat = WebMessageFormat.Json, 
            RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        List<StaffModel> findallstaff();

        //List<StaffModel> getAllStaffbyID(string id)
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getAllStaffbyID/{id}", ResponseFormat =
             WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<StaffModel> getAllStaffbyID(string id);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "findallstaffbyEventID/{id}", ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        List<StaffModel> findallstaffbyEventID(string id);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "findStaffbyID/{id}", ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        EventStaff findStaffbyID(string id);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "createStaff", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool createStaff(StaffModel _staff);


        //update
        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "updateSTaff/{id}", ResponseFormat =
         WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        EventStaff updateSTaff(string id, EventStaff _event);

        //deletions 
        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "deleteStaff", ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        bool deleteStaff(EventStaff _staff);

        //deleteStaffByEventID
        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "deleteStaffByEventID/{eventID}", ResponseFormat = WebMessageFormat.Json,
    RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        string deleteStaffByEventID(string eventID);

    }
}
