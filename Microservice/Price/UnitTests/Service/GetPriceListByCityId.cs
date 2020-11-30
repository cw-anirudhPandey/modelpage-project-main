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
  public class GetPriceListByCityId : Base
  {
    private List<CarPrice> GetMockPriceList()
    {
      return new List<CarPrice>()
            {
              new CarPrice
              {
                Id = 1,
                VersionId = 6,
                CityId = 12,
                Value = "530450"
              }
            };
    }

    [Fact]
    public async Task GetPriceListByCityId_PriceListNotEmpty_ReturnNotEmpty()
    {
      var priceList = GetMockPriceList();
      _priceLogic.Setup(x => x.GetPriceListByCityId(It.IsAny<int>())).ReturnsAsync(priceList);
      var result = await _priceService.GetPriceListByCityId(new GrpcInt { Value = 12 }, It.IsAny<ServerCallContext>());
      Assert.NotNull(result.Price);
      Assert.NotNull(result.Price[0]);
      Assert.Equal(priceList[0].Id, result.Price[0].Id);
      Assert.Equal(priceList[0].VersionId, result.Price[0].VersionId);
      Assert.Equal(priceList[0].CityId, result.Price[0].CityId);
      Assert.Equal(priceList[0].Value, result.Price[0].Value);
    }

    [Fact]
    public async Task GetPriceListByCityId_PriceListEmpty_ReturnEmpty()
    {
      _priceLogic.Setup(x => x.GetPriceListByCityId(It.IsAny<int>())).ReturnsAsync(new List<CarPrice>());
      var result = await _priceService.GetPriceListByCityId(new GrpcInt { Value = 12 }, It.IsAny<ServerCallContext>());
      Assert.Empty(result.Price);
    }
  }
}