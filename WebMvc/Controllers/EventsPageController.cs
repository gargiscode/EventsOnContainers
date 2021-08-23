using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMvc.Services;
using WebMvc.ViewModels;

namespace WebMvc.Controllers
{
    public class EventsPageController : Controller
    {
        private readonly IEventService _service;
        public EventsPageController(IEventService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index(int? page, int? locationFilterApplied, int? typeFilterApplied )
        {
            var itemsOnPage = 10;

            var eventList = await _service.GetAllEventsAsync(page ?? 0, itemsOnPage, typeFilterApplied, locationFilterApplied);
            var vm = new EventIndexViewModel
            {
                Locations = await _service.GetAllLocationsAsync(),
                Types = await _service.GetAllTypesAsync(),
                EventList = eventList.Data,
                PaginationInfo = new PaginationInfo
                {
                    TotalItems = eventList.Count,
                    ItemsPerPage = eventList.PageSize,
                    ActualPage = page ?? 0,
                    TotalPages = (int)Math.Ceiling((decimal)eventList.Count / itemsOnPage)
                },
                LocationFilterApplied = locationFilterApplied ?? 0,
                TypesFilterApplied = typeFilterApplied ?? 0
            };

            return View(vm);
        }

        /*
        public async Task<IActionResult> WeekendAsync(int? page)
        {
            var itemsOnPage = 10;
            var eventList = await _service.GetAllEventsAsync(page ?? 0, itemsOnPage);
            var vm = new EventIndexViewModel
            {
                Locations = await _service.GetAllLocationsAsync(),
                Types = await _service.GetAllTypesAsync(),
                EventList = eventList.Data,
                PaginationInfo = new PaginationInfo
                {
                    TotalItems = eventList.Count,
                    ItemsPerPage = eventList.PageSize,
                    ActualPage = page ?? 0,
                    TotalPages = (int)Math.Ceiling((decimal)eventList.Count / itemsOnPage)
                },
                //LocationFilterApplied = locationFilterApplied ?? 0,
                //TypesFilterApplied = typeFilterApplied ?? 0
            };

            return View(vm);
        }
        */

        [Authorize]
        public IActionResult About()
        {
            ViewData["Message"] = "Your Application description page.";

            return View();
        }
    }
}
