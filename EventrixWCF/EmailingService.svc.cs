using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EventrixWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "EmailingService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select EmailingService.svc or EmailingService.svc.cs at the Solution Explorer and start debugging.
    public class EmailingService : IEmailingService
    {
        public List<Guest> getGuestsForEvent(string eventID)
        {
            List<Guest> guests = new List<Guest>();

            return guests;
        }
    }
}
