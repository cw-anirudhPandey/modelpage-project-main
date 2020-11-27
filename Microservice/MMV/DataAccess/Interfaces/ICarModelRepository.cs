using System.Collections.Generic;
using System.Threading.Tasks;
using MMV.Entities;

namespace DataAccess.Interfaces
{
  public interface ICarModelRepository
  {
    Task<Make> GetMakeIdByModelId(int modelId);
    Task<Model> GetModel(int modelId);
  }
}