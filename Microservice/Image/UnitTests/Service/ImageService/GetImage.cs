using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Grpc.Core;
using Moq;
using Image.Entities;
using Image.Service.ProtoClass;
using Xunit;

namespace UnitTests.Service
{
  public class GetImage : Base
  {
    private CarImage GetMockImage()
    {
      return new CarImage()
      {
        Id = 0,
        ModelId = 1,
        ImageUrl = "https://images.unsplash.com/photo-1553440569-bcc63803a83d?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=711&q=80"
      };
    }

    [Fact]
    public async Task GetImage_ImageNotEmpty_ReturnImageNotEmpty()
    {
      var imageItem = GetMockImage();
      _imageLogic.Setup(x => x.GetImage(It.IsAny<int>())).ReturnsAsync(imageItem);
      var result = await _imageService.GetImage(new GrpcInt { Value = 7 }, It.IsAny<ServerCallContext>());
      Assert.Equal(imageItem.ModelId, result.ModelId);
      Assert.Equal(imageItem.Id, result.Id);
      Assert.Equal(imageItem.ImageUrl, result.ImageUrl);
    }

    [Fact]
    public async Task GetImage_ImageDefaultObject_ReturnDefaultObject()
    {
      _imageLogic.Setup(x => x.GetImage(It.IsAny<int>())).ReturnsAsync(new CarImage());
      var result = await _imageService.GetImage(new GrpcInt { Value = 7 }, It.IsAny<ServerCallContext>());
      Assert.Equal(0, result.Id);
      Assert.Equal(0, result.ModelId);
      Assert.Empty(result.ImageUrl);
    }
  }
}