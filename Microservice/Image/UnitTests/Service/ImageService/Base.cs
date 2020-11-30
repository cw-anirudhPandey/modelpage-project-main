using Moq;
using Image.Business.Interfaces;
using Image.Service.Controller;

namespace UnitTests.Service
{
  public abstract class Base
  {
    protected Mock<IImageLogic> _imageLogic;
    protected ImageService _imageService;

    protected Base()
    {
      _imageLogic = new Mock<IImageLogic>();
      _imageService = new Image.Service.Controller.ImageService(_imageLogic.Object);
    }
  }
}