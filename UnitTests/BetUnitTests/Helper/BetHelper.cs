using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BettingApp.Models;
using Bogus;

namespace UnitTests.BetUnitTests.Helper
{
    public static class BetHelper
    {

        public static Bet BetData()
        {
            return new Faker<Bet>()
                .RuleFor(x => x.Id, Guid.NewGuid)
                .RuleFor(x => x.Amount, new Randomizer().Decimal(1,10))
                .RuleFor(x => x.LastUpdated, x => x.Date.Recent())
                .Generate();
        }
    }
}
