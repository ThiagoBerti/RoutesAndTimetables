using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoutesAndTimetables.Business.DataObjects
{
    public class FindDeparturesByRouteIdResponse
    {
        [DeserializeAs(Name = "rowsAffected")]
        public int RowsAffected { get; set; }
        [DeserializeAs(Name = "rows")]
        public List<Departure> Rows { get; set; }
    }
}
