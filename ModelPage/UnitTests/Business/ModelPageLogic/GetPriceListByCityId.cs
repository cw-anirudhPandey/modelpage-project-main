using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using ModelPage.Entities;
using Xunit;

namespace ModelPage.UnitTests.ModelPageLogic
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
    public async Task GetPriceListByCityId_DataNotEmpty_ReturnNotEmpty()
    {
      var priceList = GetMockPriceList();
      _priceRepository.Setup(x => x.GetPriceListByCityId(It.IsAny<int>())).ReturnsAsync(GetMockPriceList());

      var result = await _modelPageLogic.GetPriceListByCityId(4);
      Assert.NotEmpty(result);
    }

    [Fact]
    public async Task GetPriceListByCityId_DataEmpty_ReturnEmpty()
    {      
      _priceRepository.Setup(x => x.GetPriceListByCityId(It.IsAny<int>())).ReturnsAsync(new List<CarPrice>());

      var result = await _modelPageLogic.GetPriceListByCityId(4);
      Assert.Empty(result);
    }
  }
}