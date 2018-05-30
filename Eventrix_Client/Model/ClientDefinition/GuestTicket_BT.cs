using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eventrix_Client.Model.ClientDefinition
{
    public class GuestTicket_BT
    {
        public int guestticket_BT_ID
        {
            get;set;
        }
        public int Guest_ID
        {
            get;set;
        }
        public int ticket_template_id
        {
            get;set;
        }
        public int numTicket
        {
            get;set;
        }
    }
}