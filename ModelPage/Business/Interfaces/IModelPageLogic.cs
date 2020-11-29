using System.Collections.Generic;
using System.Threading.Tasks;
using ModelPage.DTO;
using ModelPage.Entities;

namespace ModelPage.Business
{
  public interface IModelPageLogic
  {
    Task<CarModelDetails> GetModelPageData(int modelId);
    Task<IEnumerable<CarPrice>> GetPriceListByCityId(int modelId);
    Task debug(int cityId, int versionId);
  }
}