using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AEPLCore.Cache.Interfaces;
using MMV.DataAccess.Interfaces;
using MMV.Business.Interfaces;
using MMV.Entities;

namespace MMV.Business
{
  public class CarModelLogic : ICarModelLogic
  {
    private string _key = "carModel-{0}-{1}";
    private readonly ICarModelRepository _carModelRepo;
    private readonly ICacheManager _cacheProvider;
    public CarModelLogic(ICarModelRepository carModelRepo, ICacheManager cacheProvider)
    {
      _carModelRepo = carModelRepo;
      _cacheProvider = cacheProvider;
    }

    public async Task<Model> GetModel(int modelId)
    {
      string cacheKey = string.Format(_key, "get-model", modelId);
      var details = await _cacheProvider.GetFromCacheAsync<Model>(cacheKey,
                  new TimeSpan(0, 5, 0),
                  async () => await _carModelRepo.GetModel(modelId));
      return details;
    }

  }
}