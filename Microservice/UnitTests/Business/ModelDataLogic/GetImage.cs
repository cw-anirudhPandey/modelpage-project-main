using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microservice.Entities;
using Moq;
using Xunit;

namespace UnitTests.Business.ModelDataLogic
{
  public class GetImage : Base
  {

    private Image GetMockImage()
    {
      return new Image()
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
      _modelDataRepository.Setup(x => x.GetImage(It.IsAny<int>())).ReturnsAsync(imageItem);
      _cacheProvider.Setup(x => x.GetFromCacheAsync<Image>(It.IsAny<string>(),
                      It.IsAny<TimeSpan>(), It.IsAny<Func<Task<Image>>>())).ReturnsAsync(imageItem);
      var result = await _modelDataLogic.GetImage(2);
      Assert.NotNull(result.ImageUrl);
      Assert.Equal(result.Id, imageItem.Id);
      Assert.Equal(result.ModelId, imageItem.ModelId);
      Assert.Equal(result.ImageUrl, imageItem.ImageUrl);
    }

    [Fact]
    public async Task GetImage_ImageNull_ReturnNull()
    {
      _modelDataRepository.Setup(x => x.GetImage(It.IsAny<int>())).ReturnsAsync(new Image());
      _cacheProvider.Setup(x => x.GetFromCacheAsync<Image>(It.IsAny<string>(),
                      It.IsAny<TimeSpan>(), It.IsAny<Func<Task<Image>>>())).ReturnsAsync(new Image());
      var result = await _modelDataLogic.GetImage(2);
      Assert.Equal(result.Id, 0);
      Assert.Equal(result.ModelId, 0);
      Assert.Null(result.ImageUrl);
    }
  }
}