using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoutesAndTimetables.Business.DataObjects
{
    public class Departure
    {
        //        id: 472
        //calendar: "WEEKDAY"
        //time: "06:00"
        [DeserializeAs(Name = "id")]
        public int Id { get; set; }
        [DeserializeAs(Name = "calendar")]
        public string Calendar { get; set; }
        [DeserializeAs(Name = "time")]
        public string Time { get; set; }
    }
}
