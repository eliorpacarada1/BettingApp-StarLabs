﻿namespace BettingApp.Dtos.Responses
{
    public class BetReadResponse
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime? LastUpdated { get; set; }
    }
}
