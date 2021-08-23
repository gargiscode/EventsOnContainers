using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMvc.Models;
using WebMvc.Infrastructure;

namespace WebMvc.Services
{
    public interface IEventService
    {
        Task<PageViewModel> GetAllEventsAsync(int page, int size, int? city, int? type);
        Task<IEnumerable<SelectListItem>> GetAllTypesAsync();
        Task<IEnumerable<SelectListItem>> GetAllLocationsAsync();
    }
}
