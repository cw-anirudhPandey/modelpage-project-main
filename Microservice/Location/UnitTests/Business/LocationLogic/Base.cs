using AEPLCore.Cache.Interfaces;
using Moq;
using Location.Business.Interfaces;
using Location.DataAccess.Interfaces;

namespace UnitTests.Business.LocationLogic
{
  public abstract class Base
  {
    protected Mock<ILocationRepository> _locationRepository;
    protected Mock<ICacheManager> _cacheProvider;
    protected ILocationLogic _locationLogic;

    protected Base()
    {
      _locationRepository = new Mock<ILocationRepository>();
      _cacheProvider = new Mock<ICacheManager>();
      _locationLogic = new Location.Business.LocationLogic(_locationRepository.Object, _cacheProvider.Object);
    }
  }
}