using System.Collections.Generic;
using System.Threading.Tasks;
using ModelPage.Entities;

namespace ModelPage.DataAccess.Interfaces
{
  public interface IPriceRepository
  {
    Task<IEnumerable<CarPrice>> GetPriceListByCityId(int cityId);
    Task<CarPrice> GetPriceByCityVersion(int cityId, int versionId);
    Task<CarPrice> GetAvgPriceByVersionId(int versionId);
  }
}