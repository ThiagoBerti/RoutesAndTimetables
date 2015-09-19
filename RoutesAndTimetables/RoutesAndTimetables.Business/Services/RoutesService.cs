using RestSharp;
using RoutesAndTimetables.Business.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoutesAndTimetables.Business.Services
{
    public class RoutesService
    {
        const string FindRoutesByStopNameRequest = "{ \"params\": { \"stopName\": \"%{0}%\" } }";
        private RestClient client;

        public RoutesService()
        {
            client = new RestClient(@"https://api.appglu.com/v1/queries/");
            client.AddDefaultHeader("X-AppGlu-Environment", "staging");
            client.Authenticator = new RestSharp.Authenticators.HttpBasicAuthenticator("WKD4N7YMA1uiM8V", "DtdTtzMLQlA0hk2C1Yi5pLyVIlAQ68");
            client.AddDefaultHeader("content-type", "application/json");
        }

        public Route[] GetRoutes(string stopName = "")
        {
            string request = FindRoutesByStopNameRequest.Replace("{0}", stopName);
            var response = client.Post<FindRoutesByStopNameResponse>(new RestRequest("findRoutesByStopName/run"));

            if (response.Data == null) return new Route[] { };
            return response.Data.Rows;
        }
    }
}
