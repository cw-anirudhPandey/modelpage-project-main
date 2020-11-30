using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using Price.Entities;
using Xunit;

namespace UnitTests.Business.PriceLogic
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
    public async Task GetPriceListByCityId_PriceListNotEmpty_ReturnNotEmptyList()
    {
      var priceListItem = GetMockPriceList();
      _priceRepository.Setup(x => x.GetPriceListByCityId(It.IsAny<int>())).ReturnsAsync(priceListItem);
      _cacheProvider.Setup(x => x.GetFromCacheAsync<IEnumerable<CarPrice>>(It.IsAny<string>(),
        It.IsAny<TimeSpan>(), It.IsAny<Func<Task<IEnumerable<CarPrice>>>>())).ReturnsAsync(priceListItem);
      var result = await _priceLogic.GetPriceListByCityId(2);
      Assert.NotEmpty(result);
      Assert.Equal(priceListItem, result);
    }

    [Fact]
    public async Task GetPriceListByCityId_PriceListEmpty_ReturnEmptyList()
    {
      _priceRepository.Setup(x => x.GetPriceListByCityId(It.IsAny<int>())).ReturnsAsync(new List<CarPrice>());
      _cacheProvider.Setup(x => x.GetFromCacheAsync<IEnumerable<CarPrice>>(It.IsAny<string>(),
        It.IsAny<TimeSpan>(), It.IsAny<Func<Task<IEnumerable<CarPrice>>>>())).ReturnsAsync(new List<CarPrice>());
      var result = await _priceLogic.GetPriceListByCityId(2);
      Assert.Empty(result);
    }
  }
}