using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Grpc.Core;
using Moq;
using MMV.Entities;
using MMV.Service.ProtoClass;
using Xunit;

namespace UnitTests.Service
{
  public class GetModel : Base
  {
    private Model GetMockModel()
    {
      return new Model()
      {
        Id = 1,
        MakeId = 3,
        ModelName = "AMG"
      };
    }

    [Fact]
    public async Task GetModel_ModelNotEmpty_ReturnImageNotEmpty()
    {
      var carModelItem = GetMockModel();
      _carModelLogic.Setup(x => x.GetModel(It.IsAny<int>())).ReturnsAsync(carModelItem);
      var result = await _mmvService.GetModel(new GrpcInt { Value = 1 }, It.IsAny<ServerCallContext>());
      Assert.Equal(carModelItem.ModelName, result.Name);
      Assert.Equal(carModelItem.MakeId, result.MakeId);
      Assert.Equal(carModelItem.Id, result.Id);
    }

    [Fact]
    public async Task GetModel_ModelDefaultObject_ReturnDefaultObject()
    {
      _carModelLogic.Setup(x => x.GetModel(It.IsAny<int>())).ReturnsAsync(new Model());
      var result = await _mmvService.GetModel(new GrpcInt { Value = 2 }, It.IsAny<ServerCallContext>());
      Assert.Empty(result.Name);
      Assert.Equal(0, result.Id);
      Assert.Equal(0, result.MakeId);
    }
  }
}