using AEPLCore.Cache.Interfaces;
using Moq;
using ModelPage.Business.Interfaces;
using ModelPage.DataAccess.Interfaces;

namespace ModelPage.UnitTests.ModelPageLogic
{
  public abstract class Base
  {
    protected Mock<IUserReviewRepository> _userReviewRepository;
    protected Mock<IMMVRepository> _mmvRepository;
    protected Mock<IImageRepository> _imageRepository;
    protected Mock<IPriceRepository> _priceRepository;
    protected Mock<ILocationRepository> _locationRepository;
    protected IModelPageLogic _modelPageLogic;

    protected Base()
    {
      _userReviewRepository = new Mock<IUserReviewRepository>();
      _mmvRepository = new Mock<IMMVRepository>();
      _imageRepository = new Mock<IImageRepository>();
      _priceRepository = new Mock<IPriceRepository>();
      _locationRepository = new Mock<ILocationRepository>();
      _modelPageLogic = new ModelPage.Business.ModelPageLogic(_userReviewRepository.Object,
       _mmvRepository.Object, _imageRepository.Object, _priceRepository.Object, _locationRepository.Object);
    }
  }
}