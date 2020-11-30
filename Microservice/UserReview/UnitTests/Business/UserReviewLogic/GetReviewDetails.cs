using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using UserReview.Entities;
using Xunit;

namespace UnitTests.Business.UserReviewLogic
{
  public class GetReviewDetails : Base
  {
    private CarReview GetMockReview()
    {
      return new CarReview()
      {
        ModelId = 1,
        Rating = 3.5,
        Count = 12,
      };
    }

    [Fact]
    public async Task GetReviewDetails_ReviewNotEmpty_ReturnPriceNotEmpty()
    {
      var reviewItem = GetMockReview();
      _userReviewRepository.Setup(x => x.GetReviewDetails(It.IsAny<int>())).ReturnsAsync(reviewItem);
      _cacheProvider.Setup(x => x.GetFromCacheAsync<CarReview>(It.IsAny<string>(),
        It.IsAny<TimeSpan>(), It.IsAny<Func<Task<CarReview>>>())).ReturnsAsync(reviewItem);
      var result = await _userReviewLogic.GetReviewDetails(6);
      Assert.Equal(reviewItem.ModelId, result.ModelId);
      Assert.Equal(reviewItem.Rating, result.Rating);
      Assert.Equal(reviewItem.Count, result.Count);
    }

    [Fact]
    public async Task GetReviewDetails_ReviewDefaultObject_ReturnDefaultObject()
    {
      _userReviewRepository.Setup(x => x.GetReviewDetails(It.IsAny<int>())).ReturnsAsync(new CarReview());
      _cacheProvider.Setup(x => x.GetFromCacheAsync<CarReview>(It.IsAny<string>(),
        It.IsAny<TimeSpan>(), It.IsAny<Func<Task<CarReview>>>())).ReturnsAsync(new CarReview());
      var result = await _userReviewLogic.GetReviewDetails(6);
      Assert.Equal(0, result.ModelId);
      Assert.Equal(0, result.Rating);
      Assert.Equal(0, result.Count);
    }
  }
}