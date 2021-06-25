using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using study.Application.Interfaces;
using study.Domain;
using System;
using System.Threading.Tasks;

namespace study.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpeakerController : ControllerBase
    {
        private readonly ISpeakerService _speakerService;
        public SpeakerController(ISpeakerService speakerService)
        {
            _speakerService = speakerService;
        }

        #region Get
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var speaker = await _speakerService.GetAllSpeakersAsync(true);

                if (speaker.Equals(null))
                    return NotFound("Not found Speaker");

                return Ok(speaker);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error to get Speaker: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var speaker = await _speakerService.GetSpeakerByIdAsync(id, true);

                if (speaker.Equals(null))
                    return NotFound($"Not found speaker by id {id}");

                return Ok(speaker);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error to get speaker: {ex.Message}");
            }
        }

        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            try
            {
                var Speaker = await _speakerService.GetAllSpeakerByNameAsync(name, true);

                if (Speaker.Equals(null))
                    return NotFound($"Not found Speaker by name: {name}");

                return Ok(Speaker);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error to get Speaker: {ex.Message}");
            }
        }
        #endregion

        [HttpPost]
        public async Task<IActionResult> Post(Speaker speaker)
        {
            try
            {
                var Speaker = await _speakerService.AddSpeaker(speaker);

                if (Speaker.Equals(null))
                    return BadRequest($"An error occurred when trying to add speaker.");

                return Ok(Speaker);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred when trying to add speaker: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Speaker speaker)
        {
            try
            {
                var Speaker = await _speakerService.UpdateSpeaker(id, speaker);

                if (Speaker.Equals(null))
                    return BadRequest($"An error occurred when trying to update speaker.");

                return Ok(Speaker);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred when trying to update speaker: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return await _speakerService.DeleteSpeaker(id) ? Ok("Success") : BadRequest("It was not possible to delete speaker");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred when trying to delete speaker: {ex.Message}");
            }
        }
    }
}
