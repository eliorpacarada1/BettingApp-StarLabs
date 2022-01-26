using BettingApp.Models;

namespace BettingApp.Services
{
    public interface IBetService
    {
        Task<List<Bet>> GetAllBets();
        Task<Bet> GetBetById(Guid id);
        Task<Bet> CreateBet(Bet bet);
        Task<Bet> UpdateBet(Bet bet);
        Task<bool> DeleteBet(Guid id);
    }
}
