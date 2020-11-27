using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AEPLCore.Cache.Interfaces;
using Microservice.Entities;

namespace Microservice.Business
{
  public class ModelDataLogic : IModelDataLogic
  {
    private string _key = "modelData-{0}-{1}";
    private readonly IModelDataRepository _modelDataRepo;
    private readonly ICacheManager _cacheProvider;
    public ModelDataLogic(IModelDataRepository modelDataRepo, ICacheManager cacheProvider)
    {
      _modelDataRepo = modelDataRepo;
      _cacheProvider = cacheProvider;
    }

    public async Task<Make> GetMake(int makeId)
    {
      // Make makeId = await _modelDataRepo.GetMakeIdByModelId(modelId);
      string cacheKey = string.Format(_key, "make", makeId);
      var details = await _cacheProvider.GetFromCacheAsync<Make>(cacheKey,
                  new TimeSpan(0, 5, 0),
                  async () => await _modelDataRepo.GetMake(makeId));
      return details;
    }

    public async Task<Model> GetModel(int modelId)
    {
      string cacheKey = string.Format(_key, "model", modelId);
      var details = await _cacheProvider.GetFromCacheAsync<Model>(cacheKey,
                  new TimeSpan(0, 5, 0),
                  async () => await _modelDataRepo.GetModel(modelId));
      return details;
    }

    public async Task<Image> GetImage(int modelId)
    {
      string cacheKey = string.Format(_key, "image", modelId);
      var details = await _cacheProvider.GetFromCacheAsync<Image>(cacheKey,
                  new TimeSpan(0, 5, 0),
                  async () => await _modelDataRepo.GetImage(modelId));
      return details;
    }

    public async Task<Review> GetReviewDetails(int modelId)
    {
      string cacheKey = string.Format(_key, "review", modelId);
      var details = await _cacheProvider.GetFromCacheAsync<Review>(cacheKey,
                  new TimeSpan(0, 5, 0),
                  async () => await _modelDataRepo.GetReviewDetails(modelId));
      return details;
    }

    public async Task<IEnumerable<PriceDetails>> GetPriceDetails(int modelId)
    {
      string cacheKey = string.Format(_key, "price-details", modelId);
      var details = await _cacheProvider.GetFromCacheAsync<IEnumerable<PriceDetails>>(cacheKey,
                  new TimeSpan(0, 5, 0),
                  async () => await _modelDataRepo.GetPriceDetails(modelId));
      return details;
    }

    public async Task<IEnumerable<CarVersion>> GetVersionList(int modelId)
    {
      string cacheKey = string.Format(_key, "version-list", modelId);
      var details = await _cacheProvider.GetFromCacheAsync<IEnumerable<CarVersion>>(cacheKey,
                  new TimeSpan(0, 5, 0),
                  async () => await _modelDataRepo.GetVersionList(modelId));
      return details;
    }

    public async Task<CarVersion> GetDefaultVersionByModelId(int modelId)
    {
      string cacheKey = string.Format(_key, "default-version", modelId);
      var details = await _cacheProvider.GetFromCacheAsync<CarVersion>(cacheKey,
                  new TimeSpan(0, 5, 0),
                  async () => await _modelDataRepo.GetDefaultVersionByModelId(modelId));
      return details;
    }

    public async Task<IEnumerable<CarCity>> GetAllCities()
    {
      string cacheKey = string.Format("modelData-{0}", "all-cities");
      var details = await _cacheProvider.GetFromCacheAsync<IEnumerable<CarCity>>(cacheKey,
                  new TimeSpan(0, 5, 0),
                  async () => await _modelDataRepo.GetAllCities());
      return details;
    }

    public async Task<IEnumerable<CarPrice>> GetPriceListByCityId(int cityId)
    {
      string cacheKey = string.Format(_key, "price-list", cityId);
      var details = await _cacheProvider.GetFromCacheAsync<IEnumerable<CarPrice>>(cacheKey,
                  new TimeSpan(0, 5, 0),
                  async () => await _modelDataRepo.GetPriceListByCityId(cityId));
      return details;
    }

    public async Task<CarPrice> GetAvgPriceByVersionId(int versionId)
    {
      string cacheKey = string.Format(_key, "avg-price", versionId);
      var details = await _cacheProvider.GetFromCacheAsync<CarPrice>(cacheKey,
                  new TimeSpan(0, 5, 0),
                  async () => await _modelDataRepo.GetAvgPriceByVersionId(versionId));
      return details;
    }

    public async Task<Emi> GetEmiDetails(int modelId)
    {
      string cacheKey = string.Format(_key, "emi", modelId);
      var details = await _cacheProvider.GetFromCacheAsync<Emi>(cacheKey,
                  new TimeSpan(0, 5, 0),
                  async () => await _modelDataRepo.GetEmiDetails(modelId));
      return details;
    }


  }
}