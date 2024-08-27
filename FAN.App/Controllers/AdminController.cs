using FAN.Model.Requests.Event;
using FAN.Service.EventService;
using Microsoft.AspNetCore.Mvc;

namespace FAN.App.Controllers
{
    public class AdminController : Controller
    {
        private readonly IEventService _eventService;
        public AdminController(IEventService eventService)
        {
           _eventService = eventService;
        }

        public IActionResult CreateEvent()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvent([FromBody] CreateEventRequest req)
        {
            await _eventService.CreateEventAsync(req); 
            return View();
        }
    }
}
