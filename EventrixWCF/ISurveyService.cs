using Eventrix_Client.Model.ClientDefinition;
using Eventrix_Client.Model.ClientDefinition.Survey;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace EventrixWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISurveyService" in both code and config file together.
    [ServiceContract]
    public interface ISurveyService
    {
    //================-----------INSERT-------------=============================================
        //Setters
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "createAnswers", ResponseFormat =
          WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        int createAnswers(Survey _surv);

        //================-----------UPDATE-------------=============================================
        //Insert answers for the survey
        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "Rec_Date", ResponseFormat =
        WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool Rec_Date(Survey _surv);

        //Insert answers for the survey
        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "Rec_FirstTime", ResponseFormat =
        WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool Rec_FirstTime(Survey _surv);

        //Insert answers for the survey
        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "Rec_FutureAttendence", ResponseFormat =
        WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool Rec_FutureAttendence(Survey _surv);

        //Insert answers for the survey
        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "Rec_Food", ResponseFormat =
        WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool Rec_Food(Survey _surv);

        //Insert answers for the survey
        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "Rec_Location", ResponseFormat =
        WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool Rec_Location(Survey _surv);

        //Insert answers for the survey
        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "Rec_Long_Quiz", ResponseFormat =
        WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool Rec_Long_Quiz(Survey _surv);

        //Insert answers for the survey
        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "Rec_Overall_Satisfaction", ResponseFormat =
        WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool Rec_Overall_Satisfaction(Survey _surv);

        //Insert answers for the survey
        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "Rec_Recommendation", ResponseFormat =
        WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool Rec_Recommendation(Survey _surv);


        //Insert answers for the survey
        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "Rec_Session", ResponseFormat =
        WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool Rec_Session(Survey _surv);

        //Insert answers for the survey
        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "Rec_Speaker", ResponseFormat =
        WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool Rec_Speaker(Survey _surv);

        //Insert answers for the survey
        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "Rec_Vendor", ResponseFormat =
        WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool Rec_Vendor(Survey _surv);

        //=====================---------Get Records--------==========================================================================
        //    [OperationContract]
        //    [WebInvoke(Method = "GET", UriTemplate = "ViewsStat/{eventID},{Type}", ResponseFormat =
        //WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        //    int ViewsStat(string eventID, string Type);


        //Get survey ID by event ID
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "GetSurveyID/{eventID}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        int GetSurveyID(string eventID);

        //Get Survey Responses by event ID and Survey ID
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "GetAnswer/{type},{eventID}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<int> GetAnswer(string type, string eventID);

        //=====================----------Delete--------=======================================================

        //Deletions
        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "dl_Survey/{eventID}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool dl_Survey(string eventID);
    }
}
