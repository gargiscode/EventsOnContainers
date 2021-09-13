using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMvc.Infrastructure
{
    public static class ApiPaths
    {
        public static class EventMap        {
            public static string GetAllTypes(string baseUri)
            {
                return $"{baseUri}eventtypes";
            }
            public static string GetAllCities(string baseUri)
            {
                return $"{baseUri}eventlocations";
            }
            public static string GetAllEvents(string baseUri, int page, int take, int? type, int? city)
            {
                var filterQs = string.Empty;
                // Creating dummy entries of 0 for type and city to avoid
                // Null exception error
                if (type == null)
                {
                    type = 0;
                }
                if (city == null)
                {
                    city = 0;
                }

                if (type.HasValue || city.HasValue)
                {
                    var typeQs = (type.HasValue) ? type.Value.ToString() : "null";  
                    var cityQs = (city.HasValue) ? city.Value.ToString() : "null";
                    filterQs = $"/type/{typeQs}/city/{cityQs}";
                }
                return $"{baseUri}items{filterQs}?pageIndex={page}&pageSize={take}";
                //return $"{baseUri}items{filterQs}";
            }
            public static string GetNextWeekendEvents(string baseUri)
            {
                return ("http://localhost:7004/API/EventsByDate/NextWeekend");
            }
        }

        public static class Basket
        {
            public static string GetBasket(string baseUri, string basketId)
            {
                return $"{baseUri}/{basketId}";
            }

            public static string UpdateBasket(string baseUri)
            {
                return baseUri;
            }

            public static string CleanBasket(string baseUri, string basketId)
            {
                return $"{baseUri}/{basketId}";
            }
        }
    }
}
