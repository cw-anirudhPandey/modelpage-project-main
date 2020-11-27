using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microservice.Entities;
using Moq;
using Xunit;

namespace UnitTests.Business.ModelDataLogic
{
  public class GetPriceDetails : Base
  {

    private List<PriceDetails> GetMockPriceDetailsList()
    {
      return new List<PriceDetails>()
            {
              new PriceDetails
              {
                Price = "2,40,54,900",
                Version = "GLC",
                City = "Hyderabad"
              }
            };
    }

    [Fact]
    public async Task GetPriceDetails_PriceDetailsNotEmpty_ReturnNotEmptyList()
    {
      var priceDetailsItem = GetMockPriceDetailsList();
      _modelDataRepository.Setup(x => x.GetPriceDetails(It.IsAny<int>())).ReturnsAsync(priceDetailsItem);
      _cacheProvider.Setup(x => x.GetFromCacheAsync<IEnumerable<PriceDetails>>(It.IsAny<string>(),
        It.IsAny<TimeSpan>(), It.IsAny<Func<Task<IEnumerable<PriceDetails>>>>())).ReturnsAsync(priceDetailsItem);
      var result = await _modelDataLogic.GetPriceDetails(2);
      Assert.NotEmpty(result);
      Assert.Equal(result, priceDetailsItem);
    }

    [Fact]
    public async Task GetPriceDetails_PriceDetailsEmpty_ReturnEmptyList()
    {

      _modelDataRepository.Setup(x => x.GetPriceDetails(It.IsAny<int>())).ReturnsAsync(new List<PriceDetails>());
      _cacheProvider.Setup(x => x.GetFromCacheAsync<IEnumerable<PriceDetails>>(It.IsAny<string>(),
        It.IsAny<TimeSpan>(), It.IsAny<Func<Task<IEnumerable<PriceDetails>>>>())).ReturnsAsync(new List<PriceDetails>());
      var result = await _modelDataLogic.GetPriceDetails(2);
      Assert.Empty(result);
    }
  }
}