using Microsoft.AspNetCore.Mvc;
using study.Repository;
using study.Domain;
using System.Collections.Generic;
using System.Linq;

namespace study.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly EventsContext context;
        public EventsController(EventsContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<Event> Get()
        {
            //request resource
            return this.context.Events;
        }
        
        [HttpGet("{id}")]
        public Event GetById(int id)
        {
            //request resource by Id
            return this.context.Events.FirstOrDefault(evento => evento.Id == id);
        }

        [HttpPost]
        public string Post()
        {
            //create resource
            return "this is POST method";
        }

        [HttpPut("{id}")]
        public string Put(int id)
        {
            //update resource
            return $"this is PUT method and the ID is {id}";
        }

        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            //delete resource
            return $"this is DELETE method and the ID is {id}";
        }
    }
}
