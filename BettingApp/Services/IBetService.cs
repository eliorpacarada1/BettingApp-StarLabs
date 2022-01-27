using BettingApp.Dtos.Requests;
using BettingApp.Dtos.Responses;
using BettingApp.Models;

namespace BettingApp.Services
{
    public interface IBetService
    {
        Task<List<BetReadResponse>> GetAllBets();
        Task<BetReadResponse> GetBetById(Guid id);
        Task<BetCreateResponse> CreateBet(BetCreateRequest bet);
        Task<BetUpdateResponse> UpdateBet(Guid Id, BetUpdateRequest bet);
        Task<bool> DeleteBet(Guid id);
    }
}
