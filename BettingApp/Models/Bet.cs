namespace BettingApp.Models
{
    public class Bet
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime? LastUpdated { get; set; }
    }
}
