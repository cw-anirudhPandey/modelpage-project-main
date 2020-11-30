using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ModelPage.Business.Interfaces;
using ModelPage.DataAccess.Interfaces;
using ModelPage.Entities;

namespace ModelPage.Business
{
  public class ModelPageLogic : IModelPageLogic
  {
    private readonly IUserReviewRepository _userReviewRepository;
    private readonly IMMVRepository _mmvRepository;
    private readonly IImageRepository _imageRepository;
    private readonly IPriceRepository _priceRepository;
    private readonly ILocationRepository _locationRepository;
    public ModelPageLogic(IUserReviewRepository userReviewRepository,
          IMMVRepository mmvRepository, IImageRepository imageRepository, IPriceRepository priceRepository,
          ILocationRepository locationRepository)
    {
      _userReviewRepository = userReviewRepository;
      _mmvRepository = mmvRepository;
      _imageRepository = imageRepository;
      _priceRepository = priceRepository;
      _locationRepository = locationRepository;
    }

    public async Task<CarModelDetails> GetModelPageData(int modelId)
    {
      var carModel = await _mmvRepository.GetModel(modelId);
      var carMake = await _mmvRepository.GetMake(carModel.MakeId);
      IEnumerable<CarVersion> versionSet = await _mmvRepository.GetVersionList(modelId);
      CarVersion version = await _mmvRepository.GetDefaultVersionByModelId(modelId);
      var carImage = await _imageRepository.GetImage(modelId);
      var carReview = await _userReviewRepository.GetReviewDetails(modelId);
      IEnumerable<CarCity> citySet = await _locationRepository.GetAllCities();
      List<CarPrice> priceOfVersionList = new List<CarPrice>();
      foreach (var item in versionSet)
      {
        var priceDetail = await _priceRepository.GetAvgPriceByVersionId(item.Id);
        priceDetail.VersionId = item.Id;
        priceOfVersionList.Add(priceDetail);
      }
      CarModelDetails result = new CarModelDetails()
      {
        MakeDetail = carMake,
        ModelDetail = carModel,
        ImageDetail = carImage,
        ReviewDetail = carReview,
        CitySet = citySet,
        VersionSet = versionSet,
        PriceDetailList = priceOfVersionList
      };
      return result;
    }

    public async Task<IEnumerable<CarPrice>> GetPriceListByCityId(int cityId)
    {
      return await _priceRepository.GetPriceListByCityId(cityId);
    }
  }
}