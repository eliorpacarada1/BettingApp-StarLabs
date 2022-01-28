using BettingApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BettingApp.Data
{
    public class MyWebApiContext : DbContext
    {
        public MyWebApiContext(DbContextOptions<MyWebApiContext> options) : base(options) { }

        public DbSet<Bet> Bets { get; set; }
    }
}
