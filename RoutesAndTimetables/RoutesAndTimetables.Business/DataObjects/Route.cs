using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoutesAndTimetables.Business.DataObjects
{
    public class Route
    {
        [DeserializeAs(Name="id")]
        int Id { get; set; }
        [DeserializeAs(Name = "shortName")]
        public string ShortName { get; set; }
        [DeserializeAs(Name = "longName")]
        public string LongName { get; set; }
        [DeserializeAs(Name = "lastModifiedDate")]
        public DateTime LastModifiedDate { get; set; }
        [DeserializeAs(Name = "agencyId")]
        public int AgencyId { get; set; }
    }
}
