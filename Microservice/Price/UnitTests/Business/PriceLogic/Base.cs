using AEPLCore.Cache.Interfaces;
using Moq;
using Price.Business.Interfaces;
using Price.DataAccess.Interfaces;

namespace UnitTests.Business.PriceLogic
{
  public abstract class Base
  {
    protected Mock<IPriceRepository> _priceRepository;
    protected Mock<ICacheManager> _cacheProvider;
    protected IPriceLogic _priceLogic;

    protected Base()
    {
      _priceRepository = new Mock<IPriceRepository>();
      _cacheProvider = new Mock<ICacheManager>();
      _priceLogic = new Price.Business.PriceLogic(_priceRepository.Object, _cacheProvider.Object);
    }
  }
}