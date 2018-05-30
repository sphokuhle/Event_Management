using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eventrix_Client.Model.ClientDefinition
{
    public class QRCodeImage
    {
        public int QRCodeID
        {
            get;set;
        }
        public string Name
        {
            get;set;
        }
        public int ticket_ID
        {
            get;set;
        }
        public string Location
        {
            get;set;
        }

        public int Checked_in
        {
            get;set;
        }
        public DateTime EntranceTime
        {
            get;set;
        }
        public int Credit
        {
            get;set;
        }
    }
}