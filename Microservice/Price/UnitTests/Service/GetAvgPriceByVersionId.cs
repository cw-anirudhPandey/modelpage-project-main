using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Grpc.Core;
using Moq;
using Price.Entities;
using Price.Service.ProtoClass;
using Xunit;

namespace UnitTests.Service
{
  public class GetAvgPriceByVersionId : Base
  {
    private CarPrice GetMockPrice()
    {
      return new CarPrice()
      {
        Id = 1,
        VersionId = 6,
        CityId = 12,
        Value = "530450"
      };
    }

    [Fact]
    public async Task GetAvgPriceByVersionId_PriceNotEmpty_ReturnNotEmpty()
    {
      var priceItem = GetMockPrice();
      _priceLogic.Setup(x => x.GetAvgPriceByVersionId(It.IsAny<int>())).ReturnsAsync(priceItem);
      var result = await _priceService.GetAvgPriceByVersionId(new GrpcInt { Value = 12 }, It.IsAny<ServerCallContext>());
      Assert.NotEmpty(result.Value);
      Assert.Equal(priceItem.Value, result.Value);
    }

    [Fact]
    public async Task GetAvgPriceByVersionId_PriceNull_ReturnNull()
    {
      _priceLogic.Setup(x => x.GetAvgPriceByVersionId(It.IsAny<int>())).ReturnsAsync(new CarPrice());
      var result = await _priceService.GetAvgPriceByVersionId(new GrpcInt { Value = 12 }, It.IsAny<ServerCallContext>());
      Assert.Empty(result.Value);
    }
  }
}