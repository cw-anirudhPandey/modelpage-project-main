using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AEPLCore.Cache.Interfaces;
using Location.Business.Interfaces;
using Location.DataAccess.Interfaces;
using Location.Entities;

namespace Location.Business
{
  public class LocationLogic : ILocationLogic
  {
    private string _key = "location-{0}";
    private readonly ILocationRepository _locationRepo;
    private readonly ICacheManager _cacheProvider;
    public LocationLogic(ILocationRepository locationRepo, ICacheManager cacheProvider)
    {
      _locationRepo = locationRepo;
      _cacheProvider = cacheProvider;
    }

    public async Task<IEnumerable<CarCity>> GetAllCities()
    {
      string cacheKey = string.Format(_key, "all-cities");
      var details = await _cacheProvider.GetFromCacheAsync<IEnumerable<CarCity>>(cacheKey,
                  new TimeSpan(0, 5, 0),
                  async () => await _locationRepo.GetAllCities());
      return details;
    }
  }
}