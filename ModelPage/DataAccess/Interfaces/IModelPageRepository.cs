using System.Collections.Generic;
using System.Threading.Tasks;
using ModelPage.Entities;

namespace ModelPage.DataAccess.Interfaces
{
  public interface IModelPageRepository
  {
    Task<Make> GetMake(int makeId);
    Task<Model> GetModel(int modelId);
    Task<CarImage> GetImage(int modelId);
    Task<Review> GetReviewDetails(int modelId);
    Task<IEnumerable<PriceDetails>> GetPriceDetails(int modelId);
    Task<IEnumerable<CarVersion>> GetVersionList(int modelId);
    Task<CarVersion> GetDefaultVersionByModelId(int modelId);
    Task<IEnumerable<CarCity>> GetAllCities();
    Task<IEnumerable<CarPrice>> GetPriceListByCityId(int cityId);
    Task<CarPrice> GetAvgPriceByVersionId(int versionId);
    Task<Emi> GetEmiDetails(int modelId);
  } 
}