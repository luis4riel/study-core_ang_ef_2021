using Microsoft.AspNetCore.Mvc;
using study.API.Models;
using System.Collections.Generic;

namespace study.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventController : ControllerBase
    {
        public EventController()
        {
        }

        [HttpGet]
        public IEnumerable<Event> Get()
        {
            //request resource
            return new Event[]
            {
                new Event()
                {
                    EventId = 1,
                    EventDate = System.DateTime.Now.AddDays(5).ToShortDateString(),
                    Lote = "1° lote",
                    PeopleCount = 250,
                    Place = "Lages",
                    Theme = ".NET 5 and Angular 11",
                    ImageUrl = "https://angular.io/assets/images/logos/angular/logo-nav@2x.png"
                }
            };
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
