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
  public class GetImage : Base
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
    public async Task GetMake_MakeNotEmpty_ReturnImageNotEmpty()
    {
      var carMakeItem = GetMockMake();
      _carMakeLogic.Setup(x => x.GetMake(It.IsAny<int>())).ReturnsAsync(carMakeItem);
      var result = await _mmvService.GetMake(new GrpcInt { Value = 7 }, It.IsAny<ServerCallContext>());
      Assert.Equal(carMakeItem.MakeName, result.Name);
      Assert.Equal(carMakeItem.Id, result.Id);
    }

    [Fact]
    public async Task GetMake_MakeDefaultObject_ReturnDefaultObject()
    {
      _carMakeLogic.Setup(x => x.GetMake(It.IsAny<int>())).ReturnsAsync(new Make());
      var result = await _mmvService.GetMake(new GrpcInt { Value = 2 }, It.IsAny<ServerCallContext>());
      Assert.Empty(result.Name);
      Assert.Equal(0, result.Id);
    }
  }
}