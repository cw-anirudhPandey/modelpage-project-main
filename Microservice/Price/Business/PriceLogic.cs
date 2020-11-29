using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AEPLCore.Cache.Interfaces;
using Price.Business.Interfaces;
using Price.DataAccess.Interfaces;
using Price.Entities;

namespace Price.Business
{
  public class PriceLogic : IPriceLogic
  {
    private string _key = "price-{0}-{1}";
    private readonly IPriceRepository _priceRepo;
    private readonly ICacheManager _cacheProvider;
    public PriceLogic(IPriceRepository priceRepo, ICacheManager cacheProvider)
    {
      _priceRepo = priceRepo;
      _cacheProvider = cacheProvider;
    }

    public async Task<IEnumerable<CarPrice>> GetPriceListByCityId(int cityId)
    {
      string cacheKey = string.Format(_key, "price-list", cityId);
      var details = await _cacheProvider.GetFromCacheAsync<IEnumerable<CarPrice>>(cacheKey,
                  new TimeSpan(0, 5, 0),
                  async () => await _priceRepo.GetPriceListByCityId(cityId));
      return details;
    }

    public async Task<CarPrice> GetPriceByCityVersion(int cityId, int versionId)
    {
      string cacheKey = string.Format(_key, "price-list", cityId);
      var details = await _cacheProvider.GetFromCacheAsync<CarPrice>(cacheKey,
                  new TimeSpan(0, 5, 0),
                  async () => await _priceRepo.GetPriceByCityVersion(cityId, versionId));
      return details;
    }

    public async Task<CarPrice> GetAvgPriceByVersionId(int versionId)
    {
      string cacheKey = string.Format(_key, "avg-price", versionId);
      var details = await _cacheProvider.GetFromCacheAsync<CarPrice>(cacheKey,
                  new TimeSpan(0, 5, 0),
                  async () => await _priceRepo.GetAvgPriceByVersionId(versionId));
      return details;
    }
  }
}