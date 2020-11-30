using System.Collections.Generic;
using System.Threading.Tasks;
using ModelPage.DTO;
using ModelPage.Entities;

namespace ModelPage.Business.Interfaces
{
  public interface IModelPageLogic
  {
    Task<CarModelDetails> GetModelPageData(int modelId);
    Task<IEnumerable<CarPrice>> GetPriceListByCityId(int modelId);
  }
}