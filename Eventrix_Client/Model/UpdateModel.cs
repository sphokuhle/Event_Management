using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Eventrix_Client.Model
{
    [DataContract]
    public class UpdateModel
    {
        [DataMember]
        public int ID
        {
            get;set;
        }
        [DataMember]
        public string Name
        {
            get;set;
        }
        [DataMember]
        public string Surname
        {
            get;set;
        }
    }
}