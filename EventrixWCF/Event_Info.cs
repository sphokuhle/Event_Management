using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventrixWCF
{
    public class Event_Info
    {
        public int eventid
        {
            get; set;
        }
        public string name
        {
            get; set;
        }
        public string desc
        {
            get; set;
        }
        public string type
        {
            get; set;
        }
        public int hostid
        {
            get; set;
        }
        public int address
        {
            get; set;
        }
        public int eb_ticket
        {
            get; set;
        }
        public int rg_ticket
        {
            get; set;
        }
        public int vip_ticket
        {
            get; set;
        }
        public int vvip_ticket
        {
            get; set;
        }
        public int num_product
        {
            get; set;
        }
        public DateTime sdate
        {
            get; set;
        }
        public DateTime edate
        {
            get; set;
        }
    }
}