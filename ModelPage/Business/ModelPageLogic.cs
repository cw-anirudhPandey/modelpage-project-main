using System.Collections.Generic;
using System.Threading.Tasks;
using ModelPage.DTO;
using ModelPage.Entities;

namespace ModelPage.Business
{
  public class ModelPageLogic : IModelPageLogic
  {
    private readonly IModelPageRepository _modelPageRepository;
    public ModelPageLogic(IModelPageRepository modelPageRepository)
    {
      _modelPageRepository = modelPageRepository;
    }

    public async Task<CarModelDetails> GetModelPageData(int modelId)
    {
      // int makeId = await _modelPageRepository.GetMakeIdByModelId(modelId);
      var carMake = await _modelPageRepository.GetMake(0);
      var carModel = await _modelPageRepository.GetModel(modelId);
      var carImage = await _modelPageRepository.GetImage(modelId);
      var carReview = await _modelPageRepository.GetReviewDetails(modelId);
      var carEmi = await _modelPageRepository.GetEmiDetails(modelId);
      IEnumerable<CarCity> citySet = await _modelPageRepository.GetAllCities();
      IEnumerable<CarVersion> versionSet = await _modelPageRepository.GetVersionList(modelId);
      CarVersion version = await _modelPageRepository.GetDefaultVersionByModelId(modelId);
      CarPrice price = await _modelPageRepository.GetAvgPriceByVersionId(version.Id);
      CarModelDetails result = new CarModelDetails()
      {
        MakeDetail = carMake,
        ModelDetail = carModel,
        ImageDetail = carImage,
        ReviewDetail = carReview,
        EmiDetail = carEmi,
        CitySet = citySet,
        VersionSet = versionSet,
        PriceDetail = price
      };
      return result;
    }

    public async Task<IEnumerable<CarPrice>> GetPriceListByCityId(int cityId)
    {
      return await _modelPageRepository.GetPriceListByCityId(cityId);
    }
  }
}