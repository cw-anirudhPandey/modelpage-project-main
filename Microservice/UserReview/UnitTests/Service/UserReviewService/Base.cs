using Moq;
using UserReview.Business.Interfaces;
using UserReview.Service.Controller;

namespace UnitTests.Service
{
  public abstract class Base
  {
    protected Mock<IUserReviewLogic> _userReviewLogic;
    protected UserReviewService _userReviewService;

    protected Base()
    {
      _userReviewLogic = new Mock<IUserReviewLogic>();
      _userReviewService = new UserReview.Service.Controller.UserReviewService(_userReviewLogic.Object);
    }
  }
}