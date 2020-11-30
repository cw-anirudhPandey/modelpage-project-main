using AEPLCore.Cache.Interfaces;
using Moq;
using MMV.Business.Interfaces;
using MMV.DataAccess.Interfaces;

namespace UnitTests.Business.CarMakeLogic
{
  public abstract class Base
  {
    protected Mock<ICarMakeRepository> _carMakeRepository;
    protected Mock<ICacheManager> _cacheProvider;
    protected ICarMakeLogic _carMakeLogic;

    protected Base()
    {
      _carMakeRepository = new Mock<ICarMakeRepository>();
      _cacheProvider = new Mock<ICacheManager>();
      _carMakeLogic = new MMV.Business.CarMakeLogic(_carMakeRepository.Object, _cacheProvider.Object);
    }
  }
}