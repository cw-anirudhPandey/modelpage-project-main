using AEPLCore.Cache.Interfaces;
using Moq;
using Image.Business.Interfaces;
using Image.DataAccess.Interfaces;

namespace UnitTests.Business.ImageLogic
{
  public abstract class Base
  {
    protected Mock<IImageRepository> _imageRepository;
    protected Mock<ICacheManager> _cacheProvider;
    protected IImageLogic _imageLogic;

    protected Base()
    {
      _imageRepository = new Mock<IImageRepository>();
      _cacheProvider = new Mock<ICacheManager>();
      _imageLogic = new Image.Business.ImageLogic(_imageRepository.Object, _cacheProvider.Object);
    }
  }
}