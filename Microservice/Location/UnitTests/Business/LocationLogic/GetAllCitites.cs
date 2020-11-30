using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using Location.Entities;
using Xunit;

namespace UnitTests.Business.LocationLogic
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
    public async Task GetAllCities_CityListNotEmpty_ReturnNotEmptyList()
    {
      var cityListItem = GetMockCityList();
      _locationRepository.Setup(x => x.GetAllCities()).ReturnsAsync(cityListItem);
      _cacheProvider.Setup(x => x.GetFromCacheAsync<IEnumerable<CarCity>>(It.IsAny<string>(),
        It.IsAny<TimeSpan>(), It.IsAny<Func<Task<IEnumerable<CarCity>>>>())).ReturnsAsync(cityListItem);
      var result = await _locationLogic.GetAllCities();
      Assert.NotEmpty(result);
      Assert.Equal(cityListItem, result);
    }

    [Fact]
    public async Task GetAllCities_CityListEmpty_ReturnEmptyList()
    {
      _locationRepository.Setup(x => x.GetAllCities()).ReturnsAsync(new List<CarCity>());
      _cacheProvider.Setup(x => x.GetFromCacheAsync<IEnumerable<CarCity>>(It.IsAny<string>(),
        It.IsAny<TimeSpan>(), It.IsAny<Func<Task<IEnumerable<CarCity>>>>())).ReturnsAsync(new List<CarCity>());
      var result = await _locationLogic.GetAllCities();
      Assert.Empty(result);
    }
  }
}