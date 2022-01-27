using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using BettingApp.Dtos.Requests;
using BettingApp.Dtos.Responses;
using BettingApp.Migrations;
using BettingApp.Models;
using Bogus;

namespace UnitTests.BetUnitTests.Helper
{
    public static class BetHelper
    {

        public static Bet BetData(BetCreateRequest betRequest)
        {
            return new Faker<Bet>()
                .RuleFor(x => x.Id, Guid.NewGuid)
                .RuleFor(x => x.Amount, betRequest.Amount)
                .RuleFor(x => x.LastUpdated, x => null)
                .Generate();
        }

        public static BetCreateResponse BetCreateResponseData(Bet bet)
        {
            return new BetCreateResponse()
            {
                Id = bet.Id,
                Amount = bet.Amount,
                LastUpdated = bet.LastUpdated
            };
        }

        public static BetCreateRequest BetCreateRequestData()
        {
            return new Faker<BetCreateRequest>()
                .RuleFor(x => x.Amount, new Randomizer().Decimal(1, 10))
                .Generate();
        }

        public static BetReadResponse BetReadResponseData(Bet bet)
        {
            return new BetReadResponse()
            {
                Id = bet.Id,
                Amount = bet.Amount,
                LastUpdated = bet.LastUpdated
            };
        }

        public static List<Bet> BetListData()
        {
            List<Bet> betList = new();
            for (int i = 0; i < 5; i++)
            {
                BetCreateRequest betCreateRequest = BetCreateRequestData();
                Bet bet = BetData(betCreateRequest);

                betList.Add(bet);
            }

            return betList;
        }

        public static List<BetReadResponse> BetReadResponseListData(List<Bet> betList)
        {
            List<BetReadResponse> betReadResponseList = new();
            for (int i = 0; i < 5; i++)
            {
                BetReadResponse betReadResponse = BetReadResponseData(betList[i]);

                betReadResponseList.Add(betReadResponse);
            }

            return betReadResponseList;
        }
    }
}
