using AEPLCore.Cache.Interfaces;
using Microservice.Business;
using Moq;

namespace UnitTests.Business.ModelDataLogic
{
  public abstract class Base
  {
    protected Mock<IModelDataRepository> _modelDataRepository;
    protected Mock<ICacheManager> _cacheProvider;
    protected IModelDataLogic _modelDataLogic;

    protected Base()
    {
      _modelDataRepository = new Mock<IModelDataRepository>();
      _cacheProvider = new Mock<ICacheManager>();
      _modelDataLogic = new Microservice.Business.ModelDataLogic(_modelDataRepository.Object, _cacheProvider.Object);
    }
  }
}