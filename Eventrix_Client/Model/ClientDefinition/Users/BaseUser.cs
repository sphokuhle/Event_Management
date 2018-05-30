using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eventrix_Client.Model
{
    public class BaseUser
    {
        public int ID
        {
            get; set;
        }
        public string NAME
        {
            get; set;
        }
        public string SURNAME
        {
            get; set;
        }
        public string EMAIL
        {
            get; set;
        }
        public string PASS
        {
            get; set;
        }
    }
}