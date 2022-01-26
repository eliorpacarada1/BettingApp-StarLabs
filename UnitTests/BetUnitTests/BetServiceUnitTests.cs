using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BettingApp.Repositories;
using BettingApp.Services;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace UnitTests.BetUnitTests
{
    public class BetServiceUnitTests
    {
        private readonly Mock<IBetRepository> _betRepositoryMock = new();
        private readonly Mock<ILogger<BetService>> _loggerMock = new();
        private readonly Mock<IMapper> _mapperMock = new();
        private readonly BetService _sut;

        public BetServiceUnitTests()
        {
            _sut = new BetService(_betRepositoryMock.Object,
                _loggerMock.Object,
                _mapperMock.Object);

        }
    }
}
