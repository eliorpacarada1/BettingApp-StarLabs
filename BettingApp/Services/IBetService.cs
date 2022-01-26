using BettingApp.Dtos.Responses;
using BettingApp.Models;

namespace BettingApp.Services
{
    public interface IBetService
    {
        Task<List<BetReadResponse>> GetAllBets();
        Task<BetReadResponse> GetBetById(Guid id);
        Task<BetCreateResponse> CreateBet(Bet bet);
        Task<BetUpdateResponse> UpdateBet(Bet bet);
        Task<bool> DeleteBet(Guid id);
    }
}
