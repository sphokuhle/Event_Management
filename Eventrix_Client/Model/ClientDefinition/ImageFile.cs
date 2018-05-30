using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Eventrix_Client.Model
{
    [DataContract]
    public class ImageFile
    {
        //
        [DataMember]
        public Stream StreamData
        {
            get;
            set;
        }
        //
        [DataMember]
        public string QRCodeImageID
        {
            get;
            set;
        }
        // //
        [DataMember]
        public int ticket_ID
        {
            get;
            set;
        }


        [DataMember]
        public int ImageId
        {
            get;
            set;
        }

        [DataMember]
        public string ImageName
        {
            get;
            set;
        }

        [DataMember]
        public string ContentType
        {
            get;
            set;
        }
        [DataMember]
        public long FileSize
        {
            get;
            set;
        }
        [DataMember]
        public byte[] Data
        {
            get;
            set;
        }
        [DataMember]
        public string Location
        {
            get;
            set;
        }
        [DataMember]
        public string DateUploaded
        {
            get;
            set;
        }
        [DataMember]
        public int EventID
        {
            get;
            set;
        }
    }
}