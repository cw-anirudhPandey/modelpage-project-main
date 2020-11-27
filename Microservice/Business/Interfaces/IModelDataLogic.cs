using System.Collections.Generic;
using System.Threading.Tasks;
using Microservice.Entities;

namespace Microservice.Business
{
  public interface IModelDataLogic
  {
    // Task<CarModelDetails> getModelData(int modelId);
    Task<Make> GetMake(int makeId);
    Task<Model> GetModel(int modelId);
    Task<Review> GetReviewDetails(int modelId);
    Task<Image> GetImage(int modelId);
    Task<IEnumerable<PriceDetails>> GetPriceDetails(int modelId);
    Task<IEnumerable<CarVersion>> GetVersionList(int modelId);
    Task<CarVersion> GetDefaultVersionByModelId(int modelId);
    Task<IEnumerable<CarCity>> GetAllCities();
    Task<IEnumerable<CarPrice>> GetPriceListByCityId(int cityId);
    Task<CarPrice> GetAvgPriceByVersionId(int versionId);
    Task<Emi> GetEmiDetails(int modelId);
  }
}