using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Tourmine.Application.ExternalServices.Tournament;
using Tourmine.Application.Requests.Tournament;

namespace Tourmine.API.Controllers
{
    [ApiController]
    [Route("tournament")]
    public class TournamentController : ControllerBase
    {
        private readonly ITournamentService _tournamentService;

        public TournamentController(ITournamentService tournamentService)
        {
            _tournamentService = tournamentService;
        }

        // Endpoint para criar um torneio
        [HttpPost("v1/create")]
        public async Task<IActionResult> Create([FromBody] CreateTournamentRequest request)
        {
            try
            {
                var response = await _tournamentService.Register(request);

                if (response.IsSuccessStatusCode)
                {
                    return Ok("Tournament created successfully.");
                }

                return BadRequest(await response.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("v1/{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            try
            {
                var response = await _tournamentService.GetById(id);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return Ok(JsonConvert.SerializeObject(JsonConvert.DeserializeObject(content), Formatting.Indented));
                }

                return NotFound("Tournament not found.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("v1/{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateTournamentRequest request)
        {
            try
            {
                var response = await _tournamentService.Update(id, request);

                if (response.IsSuccessStatusCode)
                {
                    return Ok("Tournament updated successfully.");
                }

                return BadRequest(await response.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("v1/all")]
        public async Task<IActionResult> GetAll([FromQuery] GetTournamentAllRequest request, [FromQuery] int start = 0, [FromQuery] int limit = 25)
        {
            try
            {
                var response = await _tournamentService.GetAll(request, start, limit);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return Ok(JsonConvert.SerializeObject(JsonConvert.DeserializeObject(content), Formatting.Indented));
                }

                return BadRequest("Failed to retrieve tournaments.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
