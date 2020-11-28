using System.Collections.Generic;
using System.Threading.Tasks;
using Location.Entities;

namespace Location.DataAccess.Interfaces
{
  public interface ILocationRepository
  {
    Task<IEnumerable<CarCity>> GetAllCities();
  }
}