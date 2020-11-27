using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AEPLCore.Cache.Interfaces;
using MMV.Business.Interfaces;
using MMV.DataAccess.Interfaces;
using MMV.Entities;

namespace MMV.Business
{
  public class CarVersionLogic : ICarVersionLogic
  {
    private string _key = "carVersion-{0}-{1}";
    private readonly ICarVersionRepository _carVersionRepo;
    private readonly ICacheManager _cacheProvider;
    public CarVersionLogic(ICarVersionRepository carVersionRepo, ICacheManager cacheProvider)
    {
      _carVersionRepo = carVersionRepo;
      _cacheProvider = cacheProvider;
    }

    public async Task<IEnumerable<CarVersion>> GetVersionList(int modelId)
    {
      string cacheKey = string.Format(_key, "version-list", modelId);
      var details = await _cacheProvider.GetFromCacheAsync<IEnumerable<CarVersion>>(cacheKey,
                  new TimeSpan(0, 5, 0),
                  async () => await _carVersionRepo.GetVersionList(modelId));
      return details;
    }

    public async Task<CarVersion> GetDefaultVersionByModelId(int modelId)
    {
      string cacheKey = string.Format(_key, "default-version", modelId);
      var details = await _cacheProvider.GetFromCacheAsync<CarVersion>(cacheKey,
                  new TimeSpan(0, 5, 0),
                  async () => await _carVersionRepo.GetDefaultVersionByModelId(modelId));
      return details;
    }
  }
}