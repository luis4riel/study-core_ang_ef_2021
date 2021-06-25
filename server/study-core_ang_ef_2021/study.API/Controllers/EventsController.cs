using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using study.Application.Interfaces;
using study.Domain;
using System;
using System.Threading.Tasks;

namespace study.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly IEventService eventService;
        public EventsController(IEventService eventService)
        {
            this.eventService = eventService;
        }

        #region Get
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var events = await eventService.GetAllEventsAsync(true);

                if (events.Equals(null))
                    return NotFound("Not found events");

                return Ok(events);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error to get events: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var @event = await eventService.GetEventByIdAsync(id, true);

                if (@event.Equals(null))
                    return NotFound($"Not found event by id {id}");

                return Ok(@event);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error to get event: {ex.Message}");
            }
        }

        [HttpGet("theme/{theme}")]
        public async Task<IActionResult> GetByTheme(string theme)
        {
            try
            {
                var events = await eventService.GetAllEventsByThemeAsync(theme, true);

                if (events.Equals(null))
                    return NotFound($"Not found events by theme: {theme}");

                return Ok(events);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error to get events: {ex.Message}");
            }
        }
        #endregion

        [HttpPost]
        public async Task<IActionResult> Post(Event @event)
        {
            try
            {
                var events = await eventService.AddEvent(@event);

                if (events.Equals(null))
                    return BadRequest($"An error occurred when trying to add event.");

                return Ok(events);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred when trying to add event: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Event @event)
        {
            try
            {
                var events = await eventService.UpdateEvent(id, @event);

                if (events.Equals(null))
                    return BadRequest($"An error occurred when trying to update event.");

                return Ok(events);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred when trying to update event: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            //delete resource
            try
            {
                return await eventService.DeleteEvent(id) ? Ok("Success") : BadRequest("It was not possible to delete event");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred when trying to delete event: {ex.Message}");
            }
        }
    }
}
