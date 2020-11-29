using System.Collections.Generic;
using System.Threading.Tasks;
using Price.Entities;

namespace Price.Business.Interfaces
{
  public interface IPriceLogic
  {
    Task<IEnumerable<CarPrice>> GetPriceListByCityId(int cityId);
    Task<CarPrice> GetPriceByCityVersion(int cityId, int versionId);
    Task<CarPrice> GetAvgPriceByVersionId(int versionId);
  }
}