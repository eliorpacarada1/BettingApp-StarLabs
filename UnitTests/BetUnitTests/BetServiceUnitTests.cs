﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BettingApp.Dtos.Requests;
using BettingApp.Dtos.Responses;
using BettingApp.Models;
using BettingApp.Repositories;
using BettingApp.Services;
using Microsoft.Extensions.Logging;
using Moq;
using UnitTests.BetUnitTests.Helper;
using Xunit;

namespace UnitTests.BetUnitTests
{
    public class BetServiceUnitTests
    {
        private readonly Mock<IBetRepository> _betRepositoryMock = new();
        private readonly Mock<ILogger<BetService>> _loggerMock = new();
        private readonly Mock<IMapper> _mapperMock = new();
        private static readonly BetCreateRequest betCreateRequest = BetHelper.BetCreateRequestData();
        private static readonly Bet bet = BetHelper.BetData(betCreateRequest);
        private static readonly BetCreateResponse betCreateResponse = BetHelper.BetCreateResponseData(bet);
        private static readonly List<Bet> betList = BetHelper.BetListData();
        private static readonly List<BetReadResponse> betReadResponseList = BetHelper.BetReadResponseListData(betList);

        private readonly BetService _sut;

        public BetServiceUnitTests()
        {
            _sut = new BetService(_betRepositoryMock.Object,
                _loggerMock.Object,
                _mapperMock.Object);
        }

        public async void EmriMetodes_Scenario_Result()
        {

        }

        //For example qekjo. Ju shtohet FACT per me kallzu qe esht unit test
        [Fact]
        public async Task CreateBet_ValidInformation_BetCreated()
        {
            //Ni unit test i ka 3 pjes -  Arrange, Act, Assert

            //Arrange - Bahen setup mocks se qka ka me kthy secila
            //Qekjo It.IsAny<T> esht metod jo gjenerike qe metodes ja lejon qe nsecilen rast qe ka ni bet, ka me kthy betin e specifikum
            _betRepositoryMock.Setup(x => x.CreateBet(It.IsAny<Bet>())).ReturnsAsync(bet);
            _mapperMock.Setup(x => x.Map<Bet>(It.IsAny<BetCreateRequest>())).Returns(bet);
            _mapperMock.Setup(x => x.Map<BetCreateResponse>(It.IsAny<Bet>())).Returns(betCreateResponse);
            
            //Act - Qetu thirret metoda e service. Kthen resultin qe nbaz qysh i kena mock na senet na nbaz tlogjikes ka me kthy diqka
            var result = await _sut.CreateBet(betCreateRequest);

            //Assert - Assertimet nese kan ba pass unit testet
            Assert.NotNull(result);
            Assert.Equal(result, betCreateResponse);
        }

        [Fact]
        public async Task CreateBet_InvalidInformation_BetNotCreated()
        {
            //Arrange
           
            //Act

            //Assert
            
        }

        [Fact]
        public async Task GetAllBets_AvailableBets_BetsReturned()
        {
            //Arrange
            _mapperMock.Setup(x => x.Map<List<BetReadResponse>>(It.IsAny<List<Bet>>())).Returns(betReadResponseList);
            _betRepositoryMock.Setup(x => x.GetAllBets()).ReturnsAsync(betList);

            //Act
            var result = await _sut.GetAllBets();

            //Assert
            Assert.NotEmpty(result);
            Assert.Equal(betReadResponseList, result);
        }

        [Fact]
        public async Task GetAllBets_UnavailableBets_NoBetsReturned()
        {
            //Arrange
            _betRepositoryMock.Setup(x => x.GetAllBets()).ReturnsAsync(new List<Bet>());

            //Act
            var result = await _sut.GetAllBets();

            //Assert
            Assert.Null(result);
        }
    }
}
