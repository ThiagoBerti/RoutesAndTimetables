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
            client.Authenticator = new RestSharp.Authenticators.HttpBasicAuthenticator("WKD4N7YMA1uiM8V", "DtdTtzMLQlA0hk2C1Yi5pLyVIlAQ68");
        }
        private void AddHeaders(RestRequest request)
        {
            request.AddHeader("X-AppGlu-Environment", "staging");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Cache-Control", "no-cache");
        }

        public List<Route> GetRoutes(string stopName = "")
        {
            string requestBody = FindRoutesByStopNameRequest.Replace("{0}", stopName);
            RestRequest request = new RestRequest("findRoutesByStopName/run");
            AddHeaders(request);

            request.AddJsonBody(new { @params = new { stopName = string.Format("%{0}%", stopName)} });

            var response = client.Post<FindRoutesByStopNameResponse>(request);
            
            if (response.Data!=null)    
                return response.Data.Rows ?? new List<Route>();

            return new List<Route>();
        }
    }
}
