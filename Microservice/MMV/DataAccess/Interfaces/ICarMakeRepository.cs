using System.Collections.Generic;
using System.Threading.Tasks;
using MMV.Entities;

namespace MMV.DataAccess.Interfaces
{
  public interface ICarMakeRepository
  {
    Task<Make> GetMake(int makeId);
  }
}