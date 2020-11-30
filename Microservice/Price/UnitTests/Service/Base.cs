using Moq;
using Price.Business.Interfaces;
using Price.Service.Controller;

namespace UnitTests.Service
{
  public abstract class Base
  {
    protected Mock<IPriceLogic> _priceLogic;
    protected PriceService _priceService;

    protected Base()
    {
      _priceLogic = new Mock<IPriceLogic>();
      _priceService = new Price.Service.Controller.PriceService(_priceLogic.Object);
    }
  }
}