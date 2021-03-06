using AutoMapper;
using BettingApp.Dtos.Requests;
using BettingApp.Dtos.Responses;
using BettingApp.Models;
using BettingApp.Repositories;
using BettingApp.Services;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        private static readonly BetReadResponse betReadResponse = BetHelper.BetReadResponseData(bet);
        private static readonly BetUpdateRequest betUpdateRequest = BetHelper.BetUpdateRequestData(bet);

        private readonly BetService _sut;

        public BetServiceUnitTests()
        {
            _sut = new BetService(_betRepositoryMock.Object,
                _loggerMock.Object,
                _mapperMock.Object);
        }

        [Fact]
        public async Task CreateBet_ValidInformation_BetCreated()
        {
            //Arrange
            _betRepositoryMock.Setup(x => x.CreateBet(It.IsAny<Bet>())).ReturnsAsync(bet);
            _mapperMock.Setup(x => x.Map<Bet>(It.IsAny<BetCreateRequest>())).Returns(bet);
            _mapperMock.Setup(x => x.Map<BetCreateResponse>(It.IsAny<Bet>())).Returns(betCreateResponse);

            //Act
            var result = await _sut.CreateBet(betCreateRequest);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(result, betCreateResponse);
        }

        [Fact]
        public async Task CreateBet_InvalidInformation_BetNotCreated()
        {
            //Arrange
            _betRepositoryMock.Setup(x => x.CreateBet(It.IsAny<Bet>())).ReturnsAsync((Bet)null);

            //Act
            var result = await _sut.CreateBet(betCreateRequest);

            //Assert
            Assert.Null(result);
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

        [Fact]
        public async Task GetBetById_ValidData_BetReturned()
        {
            //Arrange
            _mapperMock.Setup(x => x.Map<BetReadResponse>(It.IsAny<Bet>())).Returns(betReadResponse);
            _betRepositoryMock.Setup(x => x.GetBetById(It.IsAny<Guid>())).ReturnsAsync(bet);

            //Act
            var result = await _sut.GetBetById(betReadResponse.Id);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(result, betReadResponse);
        }

        [Fact]
        public async Task GetBetById_InvalidData_BetNotReturned()
        {
            //Arrange
            _mapperMock.Setup(x => x.Map<BetReadResponse>(It.IsAny<Bet>()));
            _betRepositoryMock.Setup(x => x.GetBetById(It.IsAny<Guid>())).ReturnsAsync(bet);

            //Act
            var result = await _sut.GetBetById(Guid.Empty);

            //Assert
            Assert.Null(result);
        }
        [Fact]

        public async Task DeleteBet_ValidData_BetDeleted()
        {
            //Arrange
            _betRepositoryMock.Setup(x => x.DeleteBet(It.IsAny<Bet>())).ReturnsAsync(true);
            _betRepositoryMock.Setup(x => x.GetBetById(It.IsAny<Guid>())).ReturnsAsync(bet);

            //Act
            var result = await _sut.DeleteBet(bet.Id);
            
            //Assert
            Assert.True(result);
        }

        [Fact]
        public async Task DeleteBet_InValidData_BetNotDeleted()
        {
            //Arrange
            _betRepositoryMock.Setup(x => x.GetBetById(It.IsAny<Guid>())).ReturnsAsync(() => null);
            
            //Act
            var result = await _sut.DeleteBet(bet.Id);
            
            //Assert
            Assert.False(result);
        }

        [Fact]
        public async Task UpdateBet_ValidData_BetUpdated()
        {
            //Arrange
            Bet newBet = new Bet();
            newBet.Amount = 123.3m;
            newBet.Id = bet.Id;
            newBet.LastUpdated = DateTime.UtcNow;

            _betRepositoryMock.Setup(x => x.UpdateBet(It.IsAny<Bet>())).ReturnsAsync(newBet);
            _betRepositoryMock.Setup(x => x.GetBetById(It.IsAny<Guid>())).ReturnsAsync(bet);
            
            BetUpdateResponse betUpdateResponse = BetHelper.BetUpdateResponseData(newBet);
            _mapperMock.Setup(x => x.Map<Bet>(It.IsAny<BetUpdateRequest>())).Returns(newBet);
            _mapperMock.Setup(x => x.Map<BetUpdateResponse>(It.IsAny<Bet>())).Returns(betUpdateResponse);

            //Act
            var result = await _sut.UpdateBet(bet.Id, betUpdateRequest);

            //Assert
            Assert.NotEqual(result.Amount, bet.Amount);
        }

        [Fact]
        public async Task UpdateBet_InvalidData_BetNotFound()
        {
            //Arrange
            _betRepositoryMock.Setup(x => x.GetBetById(It.IsAny<Guid>())).ReturnsAsync(() => null);

            //Act
            var result = await _sut.UpdateBet(bet.Id, betUpdateRequest);

            //Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task UpdateBet_InvalidData_NotTheSameId()
        {
            //Arrange
            BetCreateRequest betCreateRequest = BetHelper.BetCreateRequestData();
            Bet randomBet = BetHelper.BetData(betCreateRequest);
            BetUpdateRequest randomBetUpdateRequest = BetHelper.BetUpdateRequestData(randomBet);
            _betRepositoryMock.Setup(x => x.GetBetById(It.IsAny<Guid>())).ReturnsAsync(randomBet);

            //Act
            var result = await _sut.UpdateBet(bet.Id, randomBetUpdateRequest);

            //Assert
            Assert.Null(result);
        }
    }
}
