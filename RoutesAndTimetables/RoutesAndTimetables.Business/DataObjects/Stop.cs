using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoutesAndTimetables.Business.DataObjects
{
    public class Stop
    {
        [DeserializeAs(Name = "id")]
        public int Id { get; set; }
        [DeserializeAs(Name = "name")]
        public string Name {get;set;}
        [DeserializeAs(Name = "sequence")]
        public int Sequence { get; set; }
        [DeserializeAs(Name = "route_id")]
        public int RouteId { get; set; }
    }
}
