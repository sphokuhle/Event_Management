using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Eventrix_Client.Model.ClientDefinition
{
    [DataContract]
    public class ProductInfo
    {
        [DataMember]
        public int ID
        {
            get; set;
        }
        [DataMember]
        public string Name
        {
            get; set;
        }
        [DataMember]
        public string Desc
        {
            get; set;
        }
        [DataMember]
        public int Quantity
        {
            get; set;
        }
        [DataMember]
        public int Price
        {
            get; set;
        }
        [DataMember]
        public int EventID
        {
            get; set;
        }
    }
}