using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventrixWCF.Users
{
    public class EventStaff : BaseUser
    {
        public string Occupation
        {
            get; set;
        }
        public int EventID
        {
            get; set;
        }
    }
}