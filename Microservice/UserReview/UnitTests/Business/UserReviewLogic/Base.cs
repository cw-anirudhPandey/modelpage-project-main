using AEPLCore.Cache.Interfaces;
using Moq;
using UserReview.Business.Interfaces;
using UserReview.DataAccess.Interfaces;

namespace UnitTests.Business.UserReviewLogic
{
  public abstract class Base
  {
    protected Mock<IUserReviewRepository> _userReviewRepository;
    protected Mock<ICacheManager> _cacheProvider;
    protected IUserReviewLogic _userReviewLogic;

    protected Base()
    {
      _userReviewRepository = new Mock<IUserReviewRepository>();
      _cacheProvider = new Mock<ICacheManager>();
      _userReviewLogic = new UserReview.Business.UserReviewLogic(_userReviewRepository.Object, _cacheProvider.Object);
    }
  }
}