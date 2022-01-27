using BettingApp.Dtos.Requests;
using BettingApp.Dtos.Responses;
using BettingApp.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BettingApp.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class BetController : ControllerBase
    {
        private readonly IBetService _betService;

        public BetController(IBetService betService)
        {
            _betService = betService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("getallbets/")]
        public async Task<List<BetReadResponse>> GetAllBets()
        {
            return await _betService.GetAllBets();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("getbet/{id}")]
        public async Task<BetReadResponse> GetBet(Guid id)
        {
            return await _betService.GetBetById(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("createbet/")]
        public async Task<BetCreateResponse> CreateBet([FromBody] BetCreateRequest request)
        {
            return await _betService.CreateBet(request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("updatebet/{id}")]
        public async Task<BetUpdateResponse> UpdateBet(Guid id,[FromBody] BetUpdateRequest request)
        {
            return await _betService.UpdateBet(id, request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("deletebet/{id}")]
        public async Task<bool> DeleteBet(Guid id)
        {
            return await _betService.DeleteBet(id);
        }
    }
}
