using BettingApp.Data;
using BettingApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BettingApp.Repositories
{
    public class BetRepository : IBetRepository
    {
        private readonly MyWebApiContext _context;

        public BetRepository(MyWebApiContext context)
        {
            _context = context;
        }
        public async Task<Bet> CreateBet(Bet bet)
        {
            await _context.AddAsync(bet);
            await _context.SaveChangesAsync();
            return bet;
        }

        public async Task<bool> DeleteBet(Bet bet)
        {
            _context.Remove(bet);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Bet>> GetAllBets()
        {
            return await _context.Bets.ToListAsync();
        }

        public async Task<Bet> GetBetById(Guid id)
        {
            return await _context.Bets.FindAsync(id);
        }

        public async Task<Bet> UpdateBet(Bet bet)
        {
            bet.LastUpdated = DateTime.UtcNow;
            _context.Update(bet);
            await _context.SaveChangesAsync();
            return bet;
        }
    }
}
