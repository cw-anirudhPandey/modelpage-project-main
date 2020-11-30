using Moq;
using Location.Business.Interfaces;
using Location.Service.Controller;

namespace UnitTests.Service
{
  public abstract class Base
  {
    protected Mock<ILocationLogic> _locationLogic;
    protected LocationService _locationService;

    protected Base()
    {
      _locationLogic = new Mock<ILocationLogic>();
      _locationService = new Location.Service.Controller.LocationService(_locationLogic.Object);
    }
  }
}