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

        public async Task<List<Route>> GetRoutes(string stopName = "")
        {
            RestRequest request = new RestRequest("findRoutesByStopName/run");
            AddHeaders(request);

            request.AddJsonBody(new { @params = new { stopName = string.Format("%{0}%", stopName)} });

            var response = client.Post<FindRoutesByStopNameResponse>(request);
            
            if (response.Data!=null)    
                return response.Data.Rows ?? new List<Route>();

            return new List<Route>();
        }

        public async Task<List<Stop>> GetStops(int id)
        {
            RestRequest request = new RestRequest("findStopsByRouteId/run");
            AddHeaders(request);

            request.AddJsonBody(new { @params = new { routeId = id } });

            var response = client.Post<FindStopsByRouteIdResponse>(request);

            if (response.Data != null)
                return response.Data.Rows ?? new List<Stop>();

            return new List<Stop>();
        }

        public async Task<List<Departure>> GetDepartures(int id)
        {
            RestRequest request = new RestRequest("findDeparturesByRouteId/run");
            AddHeaders(request);

            request.AddJsonBody(new { @params = new { routeId = id } });

            var response = client.Post<FindDeparturesByRouteIdResponse>(request);

            if (response.Data != null)
                return response.Data.Rows ?? new List<Departure>();

            return new List<Departure>();
        }
    }
}
