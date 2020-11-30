using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using MMV.Entities;
using Xunit;

namespace UnitTests.Business.CarVersionLogic
{
  public class GetVersionList : Base
  {
    private List<CarVersion> GetMockVersionList()
    {
      return new List<CarVersion>()
            {
              new CarVersion
              {
                Id = 1,
                ModelId = 4,
                Name = "GT"
              }
            };
    }

    [Fact]
    public async Task GetVersionList_PriceListNotEmpty_ReturnNotEmptyList()
    {
      var carVersionItem = GetMockVersionList();
      _carVersionRepository.Setup(x => x.GetVersionList(It.IsAny<int>())).ReturnsAsync(carVersionItem);
      _cacheProvider.Setup(x => x.GetFromCacheAsync<IEnumerable<CarVersion>>(It.IsAny<string>(),
        It.IsAny<TimeSpan>(), It.IsAny<Func<Task<IEnumerable<CarVersion>>>>())).ReturnsAsync(carVersionItem);
      var result = await _carVersionLogic.GetVersionList(2);
      Assert.NotEmpty(result);
      Assert.Equal(carVersionItem, result);
    }

    [Fact]
    public async Task GetVersionList_PriceListEmpty_ReturnEmptyList()
    {
      _carVersionRepository.Setup(x => x.GetVersionList(It.IsAny<int>())).ReturnsAsync(new List<CarVersion>());
      _cacheProvider.Setup(x => x.GetFromCacheAsync<IEnumerable<CarVersion>>(It.IsAny<string>(),
        It.IsAny<TimeSpan>(), It.IsAny<Func<Task<IEnumerable<CarVersion>>>>())).ReturnsAsync(new List<CarVersion>());
      var result = await _carVersionLogic.GetVersionList(2);
      Assert.Empty(result);
    }
  }
}