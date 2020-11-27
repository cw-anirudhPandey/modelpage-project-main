using System.Collections.Generic;
using System.Threading.Tasks;
using MMV.Entities;

namespace MMV.DataAccess.Interfaces
{

  public interface ICarVersionRepository
  {
    Task<IEnumerable<CarVersion>> GetVersionList(int modelId);
    Task<CarVersion> GetDefaultVersionByModelId(int modelId);
  }
}