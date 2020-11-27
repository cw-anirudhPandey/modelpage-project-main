using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microservice.Entities;
using Moq;
using Xunit;

namespace UnitTests.Business.ModelDataLogic
{
  public class GetEmiDetails : Base
  {
    
    private Emi GetMockEmi()
    {
      return new Emi()
      {
        Id = 0,
        ModelId = 2,
        Cost = "10,416",
        Duration = "5 years"
      };
    }

    [Fact]
    public async Task GetEmiDetails_EmiNotNull_ReturnNotNull()
    {
      var emiItem = GetMockEmi();
      _modelDataRepository.Setup(x => x.GetEmiDetails(It.IsAny<int>())).ReturnsAsync(emiItem);
      _cacheProvider.Setup(x => x.GetFromCacheAsync<Emi>(It.IsAny<string>(),
                      It.IsAny<TimeSpan>(), It.IsAny<Func<Task<Emi>>>())).ReturnsAsync(emiItem);
      var result = await _modelDataLogic.GetEmiDetails(2);
      Assert.Equal(result.Id, emiItem.Id);
      Assert.Equal(result.ModelId, emiItem.ModelId);
      Assert.NotNull(result.Cost);
      Assert.Equal(result.Cost, emiItem.Cost);
      Assert.NotNull(result.Duration);
      Assert.Equal(result.Duration, emiItem.Duration);
    }

    [Fact]
    public async Task GetEmiDetails_EmiNull_ReturnNull()
    {
      
      _modelDataRepository.Setup(x => x.GetEmiDetails(It.IsAny<int>())).ReturnsAsync(new Emi());
      _cacheProvider.Setup(x => x.GetFromCacheAsync<Emi>(It.IsAny<string>(),
                      It.IsAny<TimeSpan>(), It.IsAny<Func<Task<Emi>>>())).ReturnsAsync(new Emi());
      var result = await _modelDataLogic.GetEmiDetails(2);
      Assert.Equal(result.Id, 0);
      Assert.Equal(result.ModelId, 0);
      Assert.Null(result.Cost);
      Assert.Null(result.Duration);
    }
  }
}