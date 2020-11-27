using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AEPLCore.Cache.Interfaces;
using MMV.Business.Interfaces;
using MMV.DataAccess.Interfaces;
using MMV.Entities;

namespace MMV.Business
{
  public class CarMakeLogic : ICarMakeLogic
  {
    private string _key = "carMake-{0}-{1}";
    private readonly ICarMakeRepository _carMakeRepo;
    private readonly ICacheManager _cacheProvider;
    public CarMakeLogic(ICarMakeRepository carMakeRepo, ICacheManager cacheProvider)
    {
      _carMakeRepo = carMakeRepo;
      _cacheProvider = cacheProvider;
    }

    public async Task<Make> GetMake(int makeId)
    {
      // Make makeId = await _modelDataRepo.GetMakeIdByModelId(modelId);
      string cacheKey = string.Format(_key, "get-make", makeId);
      var details = await _cacheProvider.GetFromCacheAsync<Make>(cacheKey,
                  new TimeSpan(0, 5, 0),
                  async () => await _carMakeRepo.GetMake(makeId));
      return details;
    }
  }
}