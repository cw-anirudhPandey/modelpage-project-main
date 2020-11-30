using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Grpc.Core;
using Moq;
using Location.Entities;
using Location.Service.ProtoClass;
using Xunit;

namespace UnitTests.Service
{
  public class GetAllCities : Base
  {
    private List<CarCity> GetMockCityList()
    {
      return new List<CarCity>()
            {
              new CarCity
              {
                Id = 1,
                Name = "Mumbai"
              }
            };
    }

    [Fact]
    public async Task GetAllCities_ImageNotEmpty_ReturnImageNotEmpty()
    {
      var cityList = GetMockCityList();
      _locationLogic.Setup(x => x.GetAllCities()).ReturnsAsync(cityList);
      var result = await _locationService.GetAllCities(new EmptyParam { }, It.IsAny<ServerCallContext>());
      Assert.NotNull(result.City);
      Assert.NotNull(result.City[0].Name);
      Assert.Equal(1, result.City[0].Id);
      Assert.Equal("Mumbai", result.City[0].Name);
    }

    [Fact]
    public async Task GetAllCities_ImageDefaultObject_ReturnDefaultObject()
    {
      _locationLogic.Setup(x => x.GetAllCities()).ReturnsAsync(new List<CarCity>());
      var result = await _locationService.GetAllCities(new EmptyParam { }, It.IsAny<ServerCallContext>());
      Assert.Empty(result.City);
    }
  }
}