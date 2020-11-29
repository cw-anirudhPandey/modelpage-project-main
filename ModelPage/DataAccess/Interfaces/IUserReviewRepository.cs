using System.Collections.Generic;
using System.Threading.Tasks;
using ModelPage.Entities;

namespace ModelPage.DataAccess.Interfaces
{
  public interface IUserReviewRepository
  {
    Task<Review> GetReviewDetails(int modelId);
  }
}