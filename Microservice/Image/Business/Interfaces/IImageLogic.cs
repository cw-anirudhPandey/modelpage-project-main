using System.Collections.Generic;
using System.Threading.Tasks;
using Image.Entities;

namespace Image.Business.Interfaces
{
  public interface IImageLogic
  { 
    Task<CarImage> GetImage(int modelId);
  }
}