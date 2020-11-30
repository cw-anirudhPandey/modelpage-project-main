using AEPLCore.Cache.Interfaces;
using Moq;
using MMV.Business.Interfaces;
using MMV.DataAccess.Interfaces;

namespace UnitTests.Business.CarVersionLogic
{
  public abstract class Base
  {
    protected Mock<ICarVersionRepository> _carVersionRepository;
    protected Mock<ICacheManager> _cacheProvider;
    protected ICarVersionLogic _carVersionLogic;

    protected Base()
    {
      _carVersionRepository = new Mock<ICarVersionRepository>();
      _cacheProvider = new Mock<ICacheManager>();
      _carVersionLogic = new MMV.Business.CarVersionLogic(_carVersionRepository.Object, _cacheProvider.Object);
    }
  }
}