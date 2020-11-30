using Moq;
using MMV.Business.Interfaces;
using MMV.Service.Controller;

namespace UnitTests.Service
{
  public abstract class Base
  {
    protected Mock<ICarMakeLogic> _carMakeLogic;
    protected Mock<ICarModelLogic> _carModelLogic;
    protected Mock<ICarVersionLogic> _carVersionLogic;
    protected MMVService _mmvService;

    protected Base()
    {
      _carMakeLogic = new Mock<ICarMakeLogic>();
      _carModelLogic = new Mock<ICarModelLogic>();
      _carVersionLogic = new Mock<ICarVersionLogic>();
      _mmvService = new MMV.Service.Controller.MMVService(_carMakeLogic.Object, _carModelLogic.Object,
        _carVersionLogic.Object);
    }
  }
}