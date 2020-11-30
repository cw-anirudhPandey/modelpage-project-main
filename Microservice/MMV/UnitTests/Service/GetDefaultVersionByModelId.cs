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
    public async Task GetDefaultVersionByModelId_VersionNotEmpty_ReturnImageNotEmpty()
    {
      var carVersionItem = GetMockVersion();
      _carVersionLogic.Setup(x => x.GetDefaultVersionByModelId(It.IsAny<int>())).ReturnsAsync(carVersionItem);
      var result = await _mmvService.GetDefaultVersionByModelId(new GrpcInt { Value = 1 }, It.IsAny<ServerCallContext>());
      Assert.Equal(carVersionItem.Name, result.Name);
      Assert.Equal(carVersionItem.ModelId, result.ModelId);
      Assert.Equal(carVersionItem.Id, result.Id);
    }

    [Fact]
    public async Task GetDefaultVersionByModelId_VersionDefaultObject_ReturnDefaultObject()
    {
      _carVersionLogic.Setup(x => x.GetDefaultVersionByModelId(It.IsAny<int>())).ReturnsAsync(new CarVersion());
      var result = await _mmvService.GetDefaultVersionByModelId(new GrpcInt { Value = 1 }, It.IsAny<ServerCallContext>());
      Assert.Empty(result.Name);
      Assert.Equal(0, result.ModelId);
      Assert.Equal(0, result.Id);
    }
  }
}