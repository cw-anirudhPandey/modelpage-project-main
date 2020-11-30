using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MMV.Entities;
using Moq;
using Xunit;

namespace UnitTests.Business.CarModelLogic
{
  public class GetModel : Base
  {
    private Model GetMockModel()
    {
      return new Model()
      {
        Id = 2,
        ModelName = "AMG"
      };
    }

    [Fact]
    public async Task GetModel_ModelNotEmpty_ReturnNotEmpty()
    {
      var modelItem = GetMockModel();
      _carModelRepository.Setup(x => x.GetModel(It.IsAny<int>())).ReturnsAsync(modelItem);
      _cacheProvider.Setup(x => x.GetFromCacheAsync<Model>(It.IsAny<string>(),
                      It.IsAny<TimeSpan>(), It.IsAny<Func<Task<Model>>>())).ReturnsAsync(modelItem);
      var result = await _carModelLogic.GetModel(2);
      Assert.NotNull(result.ModelName);
      Assert.Equal(modelItem.ModelName, result.ModelName);
      Assert.Equal(modelItem.Id, result.Id);
    }

    [Fact]
    public async Task GetModel_ModelEmpty_ReturnEmpty()
    {
      _carModelRepository.Setup(x => x.GetModel(It.IsAny<int>())).ReturnsAsync(new Model());
      _cacheProvider.Setup(x => x.GetFromCacheAsync<Model>(It.IsAny<string>(),
                      It.IsAny<TimeSpan>(), It.IsAny<Func<Task<Model>>>())).ReturnsAsync(new Model());
      var result = await _carModelLogic.GetModel(2);
      Assert.Null(result.ModelName);
      Assert.Equal(0, result.Id);
    }
  }
}