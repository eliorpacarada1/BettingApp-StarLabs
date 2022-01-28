namespace BettingApp.Dtos.Requests
{
    public class BetUpdateRequest
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }

    }
}
