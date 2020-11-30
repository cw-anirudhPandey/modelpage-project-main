using System.Collections.Generic;
using System.Threading.Tasks;
using UserReview.Entities;

namespace UserReview.DataAccess.Interfaces
{
  public interface IUserReviewRepository
  {
    Task<CarReview> GetReviewDetails(int modelId);
  }
}