using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Grpc.Core;
using Moq;
using UserReview.Entities;
using UserReview.Service.ProtoClass;
using Xunit;

namespace UnitTests.Service
{
  public class GetReview : Base
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
    public async Task GetReview_ReviewNotEmpty_ReturnPriceNotEmpty()
    {
      var reviewItem = GetMockReview();
      _userReviewLogic.Setup(x => x.GetReviewDetails(It.IsAny<int>())).ReturnsAsync(reviewItem);
      var result = await _userReviewService.GetReview(new GrpcInt { Value = 7 }, It.IsAny<ServerCallContext>());
      Assert.Equal(reviewItem.ModelId, result.ModelId);
      Assert.Equal(reviewItem.Rating, result.Rating);
      Assert.Equal(reviewItem.Count, result.Count);
    }

    [Fact]
    public async Task GetReview_ReviewDefaultObject_ReturnDefaultObject()
    {
      _userReviewLogic.Setup(x => x.GetReviewDetails(It.IsAny<int>())).ReturnsAsync(new CarReview());
      var result = await _userReviewService.GetReview(new GrpcInt { Value = 7 }, It.IsAny<ServerCallContext>());
      Assert.Equal(0, result.ModelId);
      Assert.Equal(0, result.Rating);
      Assert.Equal(0, result.Count);
    }
  }
}