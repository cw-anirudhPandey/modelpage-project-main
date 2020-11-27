using System.Collections.Generic;
using System.Threading.Tasks;
using MMV.Entities;

namespace MMV.Business.Interfaces
{
  public interface ICarModelLogic
  {
    Task<Model> GetModel(int modelId);
  }
}