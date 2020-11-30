using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MMV.Entities;
using Moq;
using Xunit;

namespace UnitTests.Business.CarMakeLogic
{
  public class GetMake : Base
  {
    private Make GetMockMake()
    {
      return new Make()
      {
        Id = 1,
        MakeName = "Mercedes-Benz"
      };
    }

    [Fact]
    public async Task GetMake_MakeNotEmpty_ReturnNotEmpty()
    {
      var makeItem = GetMockMake();
      _carMakeRepository.Setup(x => x.GetMake(It.IsAny<int>())).ReturnsAsync(makeItem);
      _cacheProvider.Setup(x => x.GetFromCacheAsync<Make>(It.IsAny<string>(),
                      It.IsAny<TimeSpan>(), It.IsAny<Func<Task<Make>>>())).ReturnsAsync(makeItem);
      var result = await _carMakeLogic.GetMake(1);
      Assert.NotNull(result.MakeName);
      Assert.Equal(makeItem.MakeName, result.MakeName);
      Assert.Equal(makeItem.Id, result.Id);
    }


    [Fact]
    public async Task GetMake_MakeEmpty_ReturnEmpty()
    {
      var makeItem = GetMockMake();
      _carMakeRepository.Setup(x => x.GetMake(It.IsAny<int>())).ReturnsAsync(new Make());
      _cacheProvider.Setup(x => x.GetFromCacheAsync<Make>(It.IsAny<string>(),
                      It.IsAny<TimeSpan>(), It.IsAny<Func<Task<Make>>>())).ReturnsAsync(new Make());
      var result = await _carMakeLogic.GetMake(4);
      Assert.Null(result.MakeName);
      Assert.Equal(0, result.Id);
    }
  }
}