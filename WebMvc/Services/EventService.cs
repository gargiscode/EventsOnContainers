using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMvc.Infrastructure;
using WebMvc.Models;

namespace WebMvc.Services
{
    public class EventService : IEventService
    {
        private readonly string _baseUrl;
        private readonly IHttpClient _client;


        public EventService(IConfiguration config, IHttpClient client)
        {
            _baseUrl = $"{config["EventUrl"]}/api/event/";
            _client = client;
        }

        public async Task<PageViewModel> GetAllEventsAsync(int page, int size, int? type, int? city)
        {
            var eventsUri = ApiPaths.EventMap.GetAllEvents(_baseUrl, page, size, type, city);
            var dataString = await _client.GetStringAsync(eventsUri);
            return JsonConvert.DeserializeObject<PageViewModel>(dataString);
        }

        // Overloaded method to get all events for next weekend
        public async Task<PageViewModel> GetAllEventsAsync(int page, int size)
        {
            var eventsUri = ApiPaths.EventMap.GetNextWeekendEvents(_baseUrl);
            var dataString = await _client.GetStringAsync(eventsUri);
            return JsonConvert.DeserializeObject<PageViewModel>(dataString);
        }
        public async Task<IEnumerable<SelectListItem>> GetAllLocationsAsync()
        {
            var cityUri = ApiPaths.EventMap.GetAllCities(_baseUrl);
            var dataString = await _client.GetStringAsync(cityUri);
            var items = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Value=null,
                    Text="All",
                    Selected = true
                }
            };
            var cities = JArray.Parse(dataString);
            foreach (var city in cities)
            {
                items.Add(
                    new SelectListItem
                    {
                        Value = city.Value<string>("id"),
                        Text = city.Value<string>("city")
                    });
            }
            return items;
        }

        public async Task<IEnumerable<SelectListItem>> GetAllTypesAsync()
        {
            var typeUri = ApiPaths.EventMap.GetAllTypes(_baseUrl);
            var dataString = await _client.GetStringAsync(typeUri);
            var items = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Value=null,
                    Text="All",
                    Selected = true
                }
            };
            var types = JArray.Parse(dataString);
            foreach (var type in types)
            {
                items.Add(
                    new SelectListItem
                    {
                        Value = type.Value<string>("id"),
                        Text = type.Value<string>("typeName")
                    });
            }
            return items;
        }


    }
}
