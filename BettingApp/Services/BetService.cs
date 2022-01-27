using AutoMapper;
using BettingApp.Dtos.Requests;
using BettingApp.Dtos.Responses;
using BettingApp.Models;
using BettingApp.Repositories;

namespace BettingApp.Services
{
    public class BetService : IBetService
    {
        private readonly IBetRepository _betRepository;
        private readonly ILogger<BetService> _logger;
        private readonly IMapper _mapper;


        public BetService(IBetRepository betRepository, ILogger<BetService> logger, IMapper mapper)
        {
            _betRepository = betRepository;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<BetCreateResponse> CreateBet(BetCreateRequest bet)
        {
            try
            {
                var mappedBet = _mapper.Map<Bet>(bet);
                var result = await _betRepository.CreateBet(mappedBet);
                if (result != null)
                {
                    return _mapper.Map<BetCreateResponse>(result);
                }

                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError("Couldn't create bet: {ex}",ex.Message);
                throw;
            }
        }
        public async Task<bool> DeleteBet(Guid id)
        {
            try
            {
                var bet = await _betRepository.GetBetById(id);
                if(bet != null)
                {
                    return await _betRepository.DeleteBet(bet);
                }
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError("Couldn't delete bet: {ex}", ex.Message);
                throw;
            }
        }

        public async Task<List<BetReadResponse>> GetAllBets()
        {
            try
            {
                var betList = await _betRepository.GetAllBets();
                if (betList.Count() > 0)
                {
                    return _mapper.Map<List<BetReadResponse>>(betList);
                }

                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError("Couldn't get bets: {ex}", ex.Message);
                throw;
            }
        }

        public async Task<BetReadResponse> GetBetById(Guid id)
        {
            try
            {
                var bet = await _betRepository.GetBetById(id);
                if (bet != null)
                {
                    return _mapper.Map<BetReadResponse>(bet);
                }

                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError("Couldn't get bet: {ex}", ex);
                throw;
            }
        }

        public async Task<BetUpdateResponse> UpdateBet(BetCreateRequest bet)
        {
            try
            {
                var mappedBet = _mapper.Map<Bet>(bet);

                var result = await _betRepository.UpdateBet(mappedBet);
                return _mapper.Map<BetUpdateResponse>(result);
                //mir po doket mer!
            }
            catch (Exception ex)
            {
                _logger.LogError("Couldn't update bet: {ex}", ex);
                throw;
            }
        }
    }
}
