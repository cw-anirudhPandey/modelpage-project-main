using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using MMV.Entities;
using Xunit;

namespace UnitTests.Business.CarVersionLogic
{
  public class GetDefaultVersionByModelId : Base
  {
    private CarVersion GetMockVersion()
    {
      return new CarVersion()
      {
        Id = 1,
        ModelId = 4,
        Name = "GT"
      };
    }

    [Fact]
    public async Task GetDefaultVersionByModelId_VersionNotEmpty_ReturnNotEmpty()
    {
      var carVersionItem = GetMockVersion();
      _carVersionRepository.Setup(x => x.GetDefaultVersionByModelId(It.IsAny<int>())).ReturnsAsync(carVersionItem);
      _cacheProvider.Setup(x => x.GetFromCacheAsync<CarVersion>(It.IsAny<string>(),
        It.IsAny<TimeSpan>(), It.IsAny<Func<Task<CarVersion>>>())).ReturnsAsync(carVersionItem);
      var result = await _carVersionLogic.GetDefaultVersionByModelId(2);
      Assert.Equal(carVersionItem.Id, result.Id);
      Assert.Equal(carVersionItem.ModelId, result.ModelId);
      Assert.NotNull(result.Name);
      Assert.Equal(carVersionItem.Name, result.Name);
    }

    [Fact]
    public async Task GetDefaultVersionByModelId_VersionEmpty_ReturnEmpty()
    {
      _carVersionRepository.Setup(x => x.GetDefaultVersionByModelId(It.IsAny<int>())).ReturnsAsync(new CarVersion());
      _cacheProvider.Setup(x => x.GetFromCacheAsync<CarVersion>(It.IsAny<string>(),
        It.IsAny<TimeSpan>(), It.IsAny<Func<Task<CarVersion>>>())).ReturnsAsync(new CarVersion());
      var result = await _carVersionLogic.GetDefaultVersionByModelId(2);
      Assert.Equal(0, result.Id);
      Assert.Equal(0, result.ModelId);
      Assert.Null(result.Name);
    }
  }
}