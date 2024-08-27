using FAN.Infrastructure.Persistence.UOW;
using FAN.Model.Entities;
using FAN.Model.Requests.Event;
using FAN.Model.Responses.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace FAN.Service.EventService
{
    public class EventService : IEventService
    {
        private readonly IUnitOfWork _unitOfWork;
        public EventService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<CreateEventResponse> CreateEventAsync(CreateEventRequest req)
        {
            try
            {
                var response = new CreateEventResponse();

                var eventRepository = _unitOfWork.GetRepository<Event>();

                var eventToAdd = new Event()
                {
                    Name = req.Name,
                };

                eventRepository.Add(eventToAdd);

                await _unitOfWork.SaveChangesAsync();

                response.Id = eventToAdd.Id;
                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
