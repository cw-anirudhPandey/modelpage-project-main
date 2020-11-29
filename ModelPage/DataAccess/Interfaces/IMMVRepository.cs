using System.Collections.Generic;
using System.Threading.Tasks;
using ModelPage.Entities;

namespace ModelPage.DataAccess.Interfaces
{
  public interface IMMVRepository
  {
    Task<Make> GetMake(int makeId);
    Task<Model> GetModel(int modelId);
    Task<IEnumerable<CarVersion>> GetVersionList(int modelId);
    Task<CarVersion> GetDefaultVersionByModelId(int modelId);
  }
}