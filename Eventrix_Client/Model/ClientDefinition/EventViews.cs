using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Eventrix_Client.Model.ClientDefinition
{
    [DataContract]
    public class EventViews
    {
        [DataMember]
        public int PromoID
        {
            get;set;
        }

        [DataMember]
        public int E_ID
        {
            get;set;
        }

        [DataMember]
        public int G_ID
        {
            get; set;
        }

        [DataMember]
        public int EH_ID
        {
            get; set;
        }

        [DataMember]
        public DateTime Date
        {
            get;set;
        }
        [DataMember]
        public string Type
        {
            get;set;
        }
        [DataMember]
        public int count
        {
            get;set;
        }
    }
}