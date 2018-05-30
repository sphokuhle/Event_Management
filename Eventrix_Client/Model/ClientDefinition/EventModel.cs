using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Eventrix_Client.Model.ClientDefinition
{
    [DataContract]
    public class EventModel
    {
        [DataMember]
        public EventTicket Ticket
        {
            get; set;
        }
        [DataMember]
        public List<EventTicket> eventTicket
        {
            get;set;
        }
        [DataMember]
        public string Category
        {
            get;set;
        }
        [DataMember]
        public ImageFile EventImage
        {
            get;set;
        }
        [DataMember]
        public string ImageLocation
        {
            get;set;
        }

        [DataMember]
        public int EventID
        {
            get;set;
        }
        [DataMember]
        public int HostID
        {
            get;set;
        }
        [DataMember]
        public int EventAddress
        {
            get;set;
        }
        [DataMember]
        public string Name
        {
            get;set;
        }
        [DataMember]
        public string Type
        {
            get;set;
        }
        [DataMember]
        public string Desc
        {
            get;set;
        }
        [DataMember]
        public int EB_Quantity
        {
            get;set;
        }
        [DataMember]
        public int Reg_Quantity
        {
            get;set;
        }
        [DataMember]
        public int VIP_Quantity
        {
            get;set;
        }
        [DataMember]
        public int VVIP_Quantity
        {
            get;set;
        }
        [DataMember]
        public int Product_Quantity
        {
            get; set;
        }
        [DataMember]
        public string sDate
        {
            get;set;
        }
        [DataMember]
        public string eDate
        {
            get;set;
        }
        [DataMember]
        public EventAddress Address
        {
            get; set;
        }

        [DataMember]
        public string City
        {
            get;set;
        }
        [DataMember]
        public string Province
        {
            get; set;
        }
        [DataMember]
        public string Street
        {
            get; set;
        }
        [DataMember]
        public int EventView
        {
            get; set;
        }
        [DataMember]
        public int EventStatus
        {
            get; set;
        }
        [DataMember]
        public int RSVP_Coming
        {
            get; set;
        }

        [DataMember]
        public int RSVP_NotComing
        {
            get; set;
        }


        ////EventSharing
        [DataMember]
        public int GuestID
        {
            get; set;
        }
        [DataMember]
        public int mycount
        {
            get; set;
        }
        [DataMember]
        public DateTime Start_Date
        {
            get; set;
        }
    }
}