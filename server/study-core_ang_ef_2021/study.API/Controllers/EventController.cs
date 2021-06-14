using Microsoft.AspNetCore.Mvc;
using study.API.Data;
using study.API.Models;
using System.Collections.Generic;
using System.Linq;

namespace study.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventController : ControllerBase
    {
        private readonly DataContext context;
        public EventController(DataContext context)
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
            return this.context.Events.FirstOrDefault(evento => evento.EventId == id);
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
