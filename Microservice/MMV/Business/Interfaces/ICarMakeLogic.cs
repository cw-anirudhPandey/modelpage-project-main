using System.Collections.Generic;
using System.Threading.Tasks;
using MMV.Entities;

namespace MMV.Business.Interfaces
{
  public interface ICarMakeLogic
  {
    Task<Make> GetMake(int makeId);
  }
}