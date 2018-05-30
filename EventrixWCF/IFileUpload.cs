using Eventrix_Client.Model;
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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IFileUpload" in both code and config file together.
    [ServiceContract]
    public interface IFileUpload
    {        //[OperationContract]
        //[WebInvoke(Method = "GET", UriTemplate = "getAllApplicationFiles", ResponseFormat =
        //WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        //List<ApplicationFile> getAllAppicationFiles();

        //[OperationContract]
        //[WebInvoke(Method = "GET", UriTemplate = "getFileById/{fileId}", ResponseFormat =
        //    WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        //ApplicationFile getFileById(string fileId);


        ////Insertions
        //[OperationContract]
        //[WebInvoke(Method = "POST", UriTemplate = "saveMultiFiles", ResponseFormat =
        //    WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        //string saveMultiFiles(List<ApplicationFile> files);

        //[OperationContract]
        //[WebInvoke(Method = "POST", UriTemplate = "saveFile", ResponseFormat =
        //    WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        //string saveFile(ApplicationFile file);

        ////Deletions
        //[OperationContract]
        //[WebInvoke(Method = "DELETE", UriTemplate = "deleteFile/{id}", ResponseFormat =
        //    WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        //string deleteFile(string id);


        //Images
        //Getters 
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getAllImages", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<ImageFile> getAllImages();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getImageById/{strID}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        ImageFile getImageById(string strID);


        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getImageLocationByEventId/{strID}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        string getImageLocationByEventId(string strID);





        //    [OperationContract]
        //    [WebInvoke(Method = "GET", UriTemplate = "getMainImageByAccommoId/{accommoId}", ResponseFormat =
        //WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        //    ImageFile getMainImageByAccommoId(string accommoId);
        //getImageById

        //Insertions
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "saveImage", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        string saveImage(ImageFile image);


        //saveQRCodeImage
        //Insertions
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "saveQRCodeImage", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        int saveQRCodeImage(QRCodeImage image);

        //Update QRCode Image
        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "UpdateQRCode/{ID}", ResponseFormat =
        WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool UpdateQRCode(QRCodeImage image, string ID);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getMultipleImagesById/{eventID}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<ImageFile> getMultipleImagesById(string eventID);

        //Insertions
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "ImportData/{name},{surname},{email}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        string ImportData(string name, string surname, string email);


        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "saveMultipleImages", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        string saveMultipleImages(List<ImageFile> imagesToUpload);


        //Deletions
        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "deleteImageByEventID/{eventID}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        string deleteImageByEventID(string eventID);

        //Deletions
        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "deleteQRCodeFileByTicketID/{ID}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        string deleteQRCodeFileByTicketID(string ID);

    }
}
