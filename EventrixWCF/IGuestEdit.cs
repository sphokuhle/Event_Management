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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IGuestEdit" in both code and config file together.
    [ServiceContract]
    public interface IGuestEdit
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "requestPassword/{email}", RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        string requestPassword(string email);


        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "editGuest/{guestId},{name},{surname},{email},{oldPassword},{newPassword},{confrmNewPassword}", RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        string editGuest(string guestId, string name, string surname, string email, string oldPassword, string newPassword, string confrmNewPassword);

        //update
        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "updateGuest/{id}", ResponseFormat =
         WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        GuestModel updateGuest(string id, GuestModel eventGuest);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getGuestByGuestID/{guestID}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        GuestModel getGuestByGuestID(string guestID);

        //Save image in a client directory & WCF database
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "saveImage", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        string saveImage(ImageFile image);

        //Retrieve the image from WCF database
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getImageById/{strID}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        ImageFile getImageById(string strID);

        //Deletions
        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "deleteImageByGuestID/{guestID}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        string deleteImageByGuestID(string guestID);

        /*
        ImageId = eventID,
                            EventID = eventID,
                            ImageName = filename,
                            FileSize = fileSize,
                            Location = "1/Prototype_TNT_Der1/Prototype_TNT_Der1/Events/" + eventID.ToString() + "/" + subfolder + "/" + filename,
                            ContentType = fileExtention,
                            DateUploaded = DateTime.Now.ToString(),
        */
        //Edit Profile Picture in a client directory & WCF database
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "editProfilePic/{guestId},{ImageName},{fileSize},{location},{fileExtention}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        string editProfilePic(string guestId, string ImageName, string fileSize, string location, string fileExtention);
    }
}
