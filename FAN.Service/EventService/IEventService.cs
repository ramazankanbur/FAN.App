using FAN.Model.Requests.Event;
using FAN.Model.Responses.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAN.Service.EventService
{
    public interface IEventService
    {
       Task<CreateEventResponse> CreateEventAsync(CreateEventRequest req);
    }
}
