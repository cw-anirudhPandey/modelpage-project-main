using System.Collections.Generic;
using System.Threading.Tasks;
using Image.Entities;

namespace Image.DataAccess.Interfaces
{
  public interface IImageRepository
  {
    Task<CarImage> GetImage(int modelId);
  }
}