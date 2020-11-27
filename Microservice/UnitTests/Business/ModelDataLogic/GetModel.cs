using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microservice.Entities;
using Moq;
using Xunit;

namespace UnitTests.Business.ModelDataLogic
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
    public async Task GetModel_ModelNotNull_ReturnNotNull()
    {
      var modelItem = GetMockModel();
      _modelDataRepository.Setup(x => x.GetModel(It.IsAny<int>())).ReturnsAsync(modelItem);
      _cacheProvider.Setup(x => x.GetFromCacheAsync<Model>(It.IsAny<string>(),
                      It.IsAny<TimeSpan>(), It.IsAny<Func<Task<Model>>>())).ReturnsAsync(modelItem);
      var result = await _modelDataLogic.GetModel(2);
      Assert.NotNull(result.ModelName);
      Assert.Equal(result.ModelName, modelItem.ModelName);
      Assert.Equal(result.Id, modelItem.Id);
    }

    [Fact]
    public async Task GetModel_ModelNull_ReturnNull()
    {
      _modelDataRepository.Setup(x => x.GetModel(It.IsAny<int>())).ReturnsAsync(new Model());
      _cacheProvider.Setup(x => x.GetFromCacheAsync<Model>(It.IsAny<string>(),
                      It.IsAny<TimeSpan>(), It.IsAny<Func<Task<Model>>>())).ReturnsAsync(new Model());
      var result = await _modelDataLogic.GetModel(2);
      Assert.Null(result.ModelName);
      Assert.Equal(result.Id, 0);
    }
  }
}