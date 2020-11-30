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
    public async Task GetVersionList_VersionNotEmpty_ReturnImageNotEmpty()
    {
      var versionList = GetMockVersionList();
      _carVersionLogic.Setup(x => x.GetVersionList(It.IsAny<int>())).ReturnsAsync(versionList);
      var result = await _mmvService.GetVersionList(new GrpcInt { Value = 1 }, It.IsAny<ServerCallContext>());
      Assert.NotNull(result.Version);
      Assert.NotNull(result.Version[0].Name);
      Assert.Equal(versionList[0].Id, result.Version[0].Id);
      Assert.Equal(versionList[0].ModelId, result.Version[0].ModelId);
      Assert.Equal(versionList[0].Name, result.Version[0].Name);
    }

    [Fact]
    public async Task GetVersionList_VersionDefaultObject_ReturnDefaultObject()
    {
      _carVersionLogic.Setup(x => x.GetVersionList(It.IsAny<int>())).ReturnsAsync(new List<CarVersion>());
      var result = await _mmvService.GetVersionList(new GrpcInt { Value = 1 }, It.IsAny<ServerCallContext>());
      Assert.Empty(result.Version);
    }
  }
}