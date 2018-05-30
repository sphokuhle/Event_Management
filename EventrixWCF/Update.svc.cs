using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Eventrix_Client.Model;

namespace EventrixWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Update" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Update.svc or Update.svc.cs at the Solution Explorer and start debugging.
    public class Update : IUpdate
    {
        public UpdateModel updateTester(string id, UpdateModel um)
        {
                using (EventrixDBDataContext db = new EventrixDBDataContext())
                {
                    var query = (from acc in db.UpdateTesters where acc.TesterID.Equals(Convert.ToInt32(id)) select acc);
                    if (query.Count() == 1)
                    {
                        UpdateTester acc = query.Single();
                       // acc.TesterID = um.ID;
                        acc.Name = um.Name;
                        acc.Surname = um.Surname;
                        db.SubmitChanges();
                    um = new UpdateModel()
                    {
                        ID = acc.TesterID,
                        Name = acc.Name,
                        Surname = acc.Surname,
                    };
                    // return accommo;
                    // string accName = um.Name;
                    return um;
                    }
                    else
                    {
                        return null;
                    }
                }
        }
    }
}
