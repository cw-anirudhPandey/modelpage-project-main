using System.Collections.Generic;
using System.Threading.Tasks;
using UserReview.Entities;

namespace UserReview.DataAccess
{
  public interface IUserReviewRepository
  {
    Task<CarReview> GetReviewDetails(int modelId);
  }
}