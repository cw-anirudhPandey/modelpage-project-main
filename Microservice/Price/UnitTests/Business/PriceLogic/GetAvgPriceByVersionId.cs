using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using Price.Entities;
using Xunit;

namespace UnitTests.Business.PriceLogic
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
    public async Task GetAvgPriceByVersionId_PriceNotEmpty_ReturnPriceNotEmpty()
    {
      var priceItem = GetMockPrice();
      _priceRepository.Setup(x => x.GetAvgPriceByVersionId(It.IsAny<int>())).ReturnsAsync(priceItem);
      _cacheProvider.Setup(x => x.GetFromCacheAsync<CarPrice>(It.IsAny<string>(),
        It.IsAny<TimeSpan>(), It.IsAny<Func<Task<CarPrice>>>())).ReturnsAsync(priceItem);
      var result = await _priceLogic.GetAvgPriceByVersionId(6);
      Assert.Equal(priceItem.Id, result.Id);
      Assert.Equal(priceItem.VersionId, result.VersionId);
      Assert.Equal(priceItem.CityId, result.CityId);
      Assert.NotNull(result.Value);
      Assert.Equal(priceItem.Value, result.Value);
    }

    [Fact]
    public async Task GetAvgPriceByVersionId_PriceDefaultObject_ReturnDefaultObject()
    {
      _priceRepository.Setup(x => x.GetAvgPriceByVersionId(It.IsAny<int>())).ReturnsAsync(new CarPrice());
      _cacheProvider.Setup(x => x.GetFromCacheAsync<CarPrice>(It.IsAny<string>(),
        It.IsAny<TimeSpan>(), It.IsAny<Func<Task<CarPrice>>>())).ReturnsAsync(new CarPrice());
      var result = await _priceLogic.GetAvgPriceByVersionId(6);
      Assert.Equal(0, result.Id);
      Assert.Equal(0, result.VersionId);
      Assert.Equal(0, result.CityId);
      Assert.Null(result.Value);
    }
  }
}