using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eventrix_Client.Model
{
    public class StaffModel : BaseUser
    {
        public string Occupation
        {
            get;set;
        }
        public int EventID
        {
            get;set;
        }
        public string WorkStation
        {
            get;set;
        }
        public int NumScans
        {
            get;set;
        }
    }
}