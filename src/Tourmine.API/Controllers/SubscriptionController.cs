using Microsoft.AspNetCore.Mvc;
using Tourmine.Application.ExternalServices.Subscription;
using Tourmine.Application.Requests.Subscription;
namespace Tourmine.API.Controllers
{
    [ApiController]
    [Route("subscription")]
    public class SubscriptionController : ControllerBase
    {
        private readonly ISubscriptionService _subscriptionService;

        public SubscriptionController(ISubscriptionService subscriptionService)
        {
            _subscriptionService = subscriptionService;
        }

        [HttpPost("v1/create")]
        public async Task<IActionResult> Create([FromBody] CreateSubscriptionRequest request)
        {
            try
            {
                var response = await _subscriptionService.Create(request);

                if (response.IsSuccessStatusCode)
                {
                    return Ok("Subscription created successfully.");
                }

                return BadRequest(await response.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("v1/{UserId}")]
        public async Task<IActionResult> GetAllByUserId([FromRoute] Guid UserId, [FromQuery] int start = 0, [FromQuery] int limit = 25)
        {
            try
            {
                var response = await _subscriptionService.GetAllByUserId(UserId, start, limit);

                if (response.IsSuccessStatusCode)
                {
                    return Ok(await response.Content.ReadAsStringAsync());
                }

                return NotFound("No subscriptions found for this user.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("v1/{UserId}/{TournamentId}")]
        public async Task<IActionResult> Update([FromRoute] Guid UserId, [FromRoute] Guid TournamentId, [FromBody] UpdateSubscriptionRequest request)
        {
            try
            {
                var response = await _subscriptionService.Update(UserId, TournamentId, request);

                if (response.IsSuccessStatusCode)
                {
                    return Ok("Subscription updated successfully.");
                }

                return BadRequest(await response.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("v1/get-by-tournamentId/{tournamentId}")]
        public async Task<IActionResult> GetAllByTournamentId([FromRoute] Guid tournamentId, [FromQuery] GetAllSubscriptionByTournamentIdRequest request)
        {
            try
            {
                var response = await _subscriptionService.GetAll(tournamentId, request);

                if (response.IsSuccessStatusCode)
                {
                    return Ok(await response.Content.ReadAsStringAsync());
                }

                return NotFound("No subscriptions found for this tournament.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("v1/cancel-subscription/{UserId}/{TournamentId}")]
        public async Task<IActionResult> CancelSubscription([FromRoute] Guid UserId, [FromRoute] Guid TournamentId)
        {
            try
            {
                var response = await _subscriptionService.CancelSubscription(UserId, TournamentId);

                if (response.IsSuccessStatusCode)
                {
                    return Ok("Subscription canceled successfully.");
                }

                return BadRequest(await response.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
