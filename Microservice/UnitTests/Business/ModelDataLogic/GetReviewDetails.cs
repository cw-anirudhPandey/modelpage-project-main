using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microservice.Entities;
using Moq;
using Xunit;

namespace UnitTests.Business.ModelDataLogic
{
  public class GetReviewDetails : Base
  {
    private Review GetMockReview()
    {
      return new Review()
      {
        ModelId = 2,
        Rating = 4.33,
        Count = 55
      };
    }

    [Fact]
    public async Task GetReviewDetails_ReviewNotNull_ReturnNotNull()
    {
      var reviewItem = GetMockReview();
      _modelDataRepository.Setup(x => x.GetReviewDetails(It.IsAny<int>())).ReturnsAsync(reviewItem);
      _cacheProvider.Setup(x => x.GetFromCacheAsync<Review>(It.IsAny<string>(),
                      It.IsAny<TimeSpan>(), It.IsAny<Func<Task<Review>>>())).ReturnsAsync(reviewItem);
      var result = await _modelDataLogic.GetReviewDetails(2);
      Assert.Equal(result.ModelId, reviewItem.ModelId);
      Assert.Equal(result.Rating, reviewItem.Rating);
      Assert.Equal(result.Count, reviewItem.Count);
    }

    [Fact]
    public async Task GetReviewDetails_ReviewNull_ReturnNull()
    {
      _modelDataRepository.Setup(x => x.GetReviewDetails(It.IsAny<int>())).ReturnsAsync(new Review());
      _cacheProvider.Setup(x => x.GetFromCacheAsync<Review>(It.IsAny<string>(),
                      It.IsAny<TimeSpan>(), It.IsAny<Func<Task<Review>>>())).ReturnsAsync(new Review());
      var result = await _modelDataLogic.GetReviewDetails(2);
      Assert.Equal(result.ModelId, 0);
      Assert.Equal(result.Rating, 0);
      Assert.Equal(result.Count, 0);
    }
  }
}