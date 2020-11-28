using System.Collections.Generic;
using System.Threading.Tasks;
using UserReview.Entities;

namespace UserReview.Business
{
  public interface IUserReviewLogic
  {
    
    Task<CarReview> GetReviewDetails(int modelId);
  }
}