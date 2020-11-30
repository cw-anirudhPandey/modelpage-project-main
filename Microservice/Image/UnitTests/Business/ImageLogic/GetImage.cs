using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Image.Entities;
using Moq;
using Xunit;

namespace UnitTests.Business.ImageLogic
{
  public class GetImage : Base
  {

    private CarImage GetMockImage()
    {
      return new CarImage()
      {
        Id = 0,
        ModelId = 2,
        ImageUrl = "https://images.unsplash.com/photo-1553440569-bcc63803a83d?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=711&q=80"
      };
    }

    [Fact]
    public async Task GetImage_ImageNotNull_ReturnNotNull()
    {
      var imageItem = GetMockImage();
      _imageRepository.Setup(x => x.GetImage(It.IsAny<int>())).ReturnsAsync(imageItem);
      _cacheProvider.Setup(x => x.GetFromCacheAsync<CarImage>(It.IsAny<string>(),
                      It.IsAny<TimeSpan>(), It.IsAny<Func<Task<CarImage>>>())).ReturnsAsync(imageItem);
      var result = await _imageLogic.GetImage(2);
      Assert.NotNull(result.ImageUrl);
      Assert.Equal(imageItem.Id, result.Id);
      Assert.Equal(imageItem.ModelId, result.ModelId);
      Assert.Equal(imageItem.ImageUrl, result.ImageUrl);
    }

    [Fact]
    public async Task GetImage_ImageNull_ReturnNull()
    {
      _imageRepository.Setup(x => x.GetImage(It.IsAny<int>())).ReturnsAsync(new CarImage());
      _cacheProvider.Setup(x => x.GetFromCacheAsync<CarImage>(It.IsAny<string>(),
                      It.IsAny<TimeSpan>(), It.IsAny<Func<Task<CarImage>>>())).ReturnsAsync(new CarImage());
      var result = await _imageLogic.GetImage(2);
      Assert.Equal(0, result.Id);
      Assert.Equal(0, result.ModelId);
      Assert.Null(result.ImageUrl);
    }
  }
}