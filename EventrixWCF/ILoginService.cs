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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ILoginService" in both code and config file together.
    [ServiceContract]
    public interface ILoginService
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "hostlogin?email={email}&password={password}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Host HostLogin(string email, string password);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "stafflogin?email={email}&password={password}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        EventStaff StaffLogin(string email, string password);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "guestlogin?email={email}&password={password}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        EventGuest GuestLogin(string email, string password);
    }
}
