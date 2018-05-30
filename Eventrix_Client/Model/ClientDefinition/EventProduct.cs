using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eventrix_Client.Model.ClientDefinition
{
    public class EventProduct
    {
        public int _ID
        {
            get;set;
        }
        public string _Name
        {
            get;set;
        }
        public string _Desc
        {
            get;set;
        }
        public int _Quantity
        {
            get;set;
        }
        public int _Price
        {
            get;set;
        }
        public int EventID
        {
            get;set;
        }
        public int ProdRemaining
        {
            get;set;
        }
    }
}