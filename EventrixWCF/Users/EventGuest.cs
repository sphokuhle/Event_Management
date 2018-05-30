using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventrixWCF
{
    public class EventGuest : BaseUser
    {
        //int--0 is a public guest, 1== private guest
        public string TYPE
        {
            get;set;
        }
    }
}