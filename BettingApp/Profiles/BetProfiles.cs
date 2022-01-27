using AutoMapper;
using BettingApp.Dtos.Requests;
using BettingApp.Dtos.Responses;
using BettingApp.Models;

namespace BettingApp.Profiles
{
    public class BetProfiles : Profile
    {
        public BetProfiles()
        {
            CreateMap<Bet, BetReadResponse>().ReverseMap();
            CreateMap<Bet, BetUpdateResponse>().ReverseMap();
            CreateMap<Bet, BetCreateResponse>().ReverseMap();
            CreateMap<Bet, BetCreateRequest>().ReverseMap();
            CreateMap<Bet, BetUpdateRequest>().ReverseMap();
        }
    }
}
