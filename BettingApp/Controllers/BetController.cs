﻿using System.Net;
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
        /// Gets all available Bets
        /// </summary>
        /// <returns></returns>
        [HttpGet("getallbets/")]
        public async Task<IActionResult> GetAllBets()
        {
            var result = await _betService.GetAllBets();
            return (result != null) ? Ok(result) : NotFound();
        }

        /// <summary>
        /// Gets a Bet by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("getbet/{id}")]
        public async Task<IActionResult> GetBet(Guid id)
        {
            var result = await _betService.GetBetById(id);
            return (result != null) ? Ok(result) : NotFound();
        }

        /// <summary>
        /// Creates a Bet
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("createbet/")]
        public async Task<IActionResult> CreateBet([FromBody] BetCreateRequest request)
        {
            var result = await _betService.CreateBet(request);
            return Ok(result);
        }

        /// <summary>
        /// Updates a Bet
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("updatebet/{id}")]
        public async Task<IActionResult> UpdateBet(Guid id,[FromBody] BetUpdateRequest request)
        {
            var result = await _betService.UpdateBet(id, request);
            return (result != null) ? Ok(result) : NotFound();
        }

        /// <summary>
        /// Deletes a Bet based on id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("deletebet/{id}")]
        public async Task<IActionResult> DeleteBet(Guid id)
        {
            var result =  await _betService.DeleteBet(id);
            return (result) ? Ok(result) : NotFound(result);
        }
    }
}
