using AEPLCore.Cache.Interfaces;
using Moq;
using MMV.Business.Interfaces;
using MMV.DataAccess.Interfaces;

namespace UnitTests.Business.CarModelLogic
{
  public abstract class Base
  {
    protected Mock<ICarModelRepository> _carModelRepository;
    protected Mock<ICacheManager> _cacheProvider;
    protected ICarModelLogic _carModelLogic;

    protected Base()
    {
      _carModelRepository = new Mock<ICarModelRepository>();
      _cacheProvider = new Mock<ICacheManager>();
      _carModelLogic = new MMV.Business.CarModelLogic(_carModelRepository.Object, _cacheProvider.Object);
    }
  }
}