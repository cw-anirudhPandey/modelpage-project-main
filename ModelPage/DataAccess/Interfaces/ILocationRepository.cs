using System.Collections.Generic;
using System.Threading.Tasks;
using ModelPage.Entities;

namespace ModelPage.DataAccess.Interfaces
{
  public interface ILocationRepository
  {
    Task<IEnumerable<CarCity>> GetAllCities();
  }
}