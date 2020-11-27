using System.Collections.Generic;
using System.Threading.Tasks;
using MMV.Entities;

namespace MMV.Business.Interfaces
{
  public interface ICarVersionLogic
  {
    Task<IEnumerable<CarVersion>> GetVersionList(int modelId);
    Task<CarVersion> GetDefaultVersionByModelId(int modelId);
  }
}