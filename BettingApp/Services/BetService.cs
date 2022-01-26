using BettingApp.Models;

namespace BettingApp.Services
{
    public class BetService : IBetService
    {
        public Task<Bet> CreateBet(Bet bet)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteBet(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Bet>> GetAllBets()
        {
            throw new NotImplementedException();
        }

        public Task<Bet> GetBetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Bet> UpdateBet(Bet bet)
        {
            throw new NotImplementedException();
        }
    }
}
