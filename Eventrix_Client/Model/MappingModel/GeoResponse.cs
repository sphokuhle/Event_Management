using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF_SERVICE_CLIENT_HOST.Models.MappingModels
{
   public class GeoResponse
    {
        public string Status { get; set; }

        public GeoResult[] Results { get; set; }
    }
}
