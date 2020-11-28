using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AEPLCore.Cache.Interfaces;
using Image.Business.Interfaces;
using Image.DataAccess.Interfaces;
using Image.Entities;

namespace Image.Business
{
  public class ImageLogic : IImageLogic
  {
    private string _key = "image-{0}-{1}";
    private readonly IImageRepository _imageRepo;
    private readonly ICacheManager _cacheProvider;
    public ImageLogic(IImageRepository imageRepo, ICacheManager cacheProvider)
    {
      _imageRepo = imageRepo;
      _cacheProvider = cacheProvider;
    }

    
    public async Task<CarImage> GetImage(int modelId)
    {
      string cacheKey = string.Format(_key, "get-image", modelId);
      var details = await _cacheProvider.GetFromCacheAsync<CarImage>(cacheKey,
                  new TimeSpan(0, 5, 0),
                  async () => await _imageRepo.GetImage(modelId));
      return details;
    }

  }
}