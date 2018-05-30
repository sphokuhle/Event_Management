using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eventrix_Client.Model.ClientDefinition
{
    public class EventTicket
    {
        public int numTicket
        {
            get;set;
        }
        public int _BT
        {
            get;set;
        }
        public int _TicketID
        { get; set; }

        public int _EventID
        {
            get;set;
        }
        public int _GuestID
        {
            get;set;
        }
        public  string _Type
        {
            get;set;
        }
        public int _Credit
        {
            get;set;
        }
        public decimal _Price
        {
            get;set;
        }
        public string _Refund
        {
            get;set;
        }
        public DateTime _StartDate
        {
            get;set;
        }
        public DateTime _EndDate
        {
            get;set;
        }
        public int Checked_In
        {
            get;set;
        }
    }
}