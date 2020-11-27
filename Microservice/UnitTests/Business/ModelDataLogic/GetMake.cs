using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microservice.Entities;
using Moq;
using Xunit;

namespace UnitTests.Business.ModelDataLogic
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
    public async Task GetMake_MakeNotNull_ReturnNotNull()
    {
      var makeItem = GetMockMake();
      _modelDataRepository.Setup(x => x.GetMake(It.IsAny<int>())).ReturnsAsync(makeItem);
      _cacheProvider.Setup(x => x.GetFromCacheAsync<Make>(It.IsAny<string>(),
                      It.IsAny<TimeSpan>(), It.IsAny<Func<Task<Make>>>())).ReturnsAsync(makeItem);
      var result = await _modelDataLogic.GetMake(1);
      Assert.NotNull(result.MakeName);
      Assert.Equal(result.MakeName, makeItem.MakeName);
      Assert.Equal(result.Id, makeItem.Id);
    }


    [Fact]
    public async Task GetMake_MakeNull_ReturnNull()
    {
      var makeItem = GetMockMake();
      _modelDataRepository.Setup(x => x.GetMake(It.IsAny<int>())).ReturnsAsync(new Make());
      _cacheProvider.Setup(x => x.GetFromCacheAsync<Make>(It.IsAny<string>(),
                      It.IsAny<TimeSpan>(), It.IsAny<Func<Task<Make>>>())).ReturnsAsync(new Make());
      var result = await _modelDataLogic.GetMake(4);
      Assert.Null(result.MakeName);
      Assert.Equal(result.Id, 0);
    }
  }
}