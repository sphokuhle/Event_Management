using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eventrix_Client.Model.ClientDefinition
{
    public class EventInfo
    {
        public int EventID
        {
            get; set;
        }
        public int HostID
        {
            get; set;
        }
        public int EventAddress
        {
            get; set;
        }
        public string Name
        {
            get; set;
        }
        public string Type
        {
            get; set;
        }
        public string Desc
        {
            get; set;
        }
        public int EB_Quantity
        {
            get; set;
        }
        public int Reg_Quantity
        {
            get; set;
        }
        public int VIP_Quantity
        {
            get; set;
        }
        public int VVIP_Quantity
        {
            get; set;
        }
        public int Product_Quantity
        {
            get; set;
        }
        public DateTime sDate
        {
            get; set;
        }
        public DateTime eDate
        {
            get; set;
        }
        public int EventStatus
        {
            get; set;
        }
    }
}