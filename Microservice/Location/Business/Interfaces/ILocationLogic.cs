using System.Collections.Generic;
using System.Threading.Tasks;
using Location.Entities;

namespace Location.Business.Interfaces
{
  public interface ILocationLogic
  {
    Task<IEnumerable<CarCity>> GetAllCities();
  }
}