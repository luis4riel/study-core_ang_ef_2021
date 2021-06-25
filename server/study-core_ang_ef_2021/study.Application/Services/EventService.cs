using study.Application.Interfaces;
using study.Domain;
using study.Repository.Interfaces;
using System;
using System.Threading.Tasks;

namespace study.Application.Services
{
    public class EventService : IEventService
    {
        private readonly IBaseRepository _baseRepository;
        private readonly IEventRepository _eventRepository;

        public EventService(IBaseRepository baseRepository, IEventRepository eventRepository)
        {
            _baseRepository = baseRepository;
            _eventRepository = eventRepository;
        }

        public async Task<Event> AddEvent(Event model)
        {
            try
            {
                _baseRepository.Add(model);

                if (await _baseRepository.SaveChangesAsync())
                    return await _eventRepository.GetEventByIdAsync(model.Id);

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Event> UpdateEvent(int eventId, Event model)
        {
            try
            {
                var @event = _eventRepository.GetEventByIdAsync(eventId);
                if (@event.Equals(null)) return null;

                model.Id = @event.Result.Id;

                _baseRepository.Update(model);

                if (await _baseRepository.SaveChangesAsync())
                    return await _eventRepository.GetEventByIdAsync(model.Id);

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteEvent(int eventId)
        {
            try
            {
                var @event = _eventRepository.GetEventByIdAsync(eventId);
                if (@event.Equals(null))
                    throw new Exception("Event not found");

                _baseRepository.Delete(@event.Result);

                return await _baseRepository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Event[]> GetAllEventsAsync(bool includeSpeaker = false)
        {
            try
            {
                var events = await _eventRepository.GetAllEventsAsync(includeSpeaker);

                if (events.Equals(null))
                    return null;

                return events;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Event[]> GetAllEventsByThemeAsync(string theme, bool includeSpeaker = false)
        {
            try
            {
                var events = await _eventRepository.GetAllEventsByThemeAsync(theme, includeSpeaker);

                if (events.Equals(null))
                    return null;

                return events;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Event> GetEventByIdAsync(int eventId, bool includeSpeaker = false)
        {
            try
            {
                var events = await _eventRepository.GetEventByIdAsync(eventId, includeSpeaker);

                if (events.Equals(null))
                    return null;

                return events;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}