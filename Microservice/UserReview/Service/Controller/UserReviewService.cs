using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using UserReview.Business;
using UserReview.Business.Interfaces;
using UserReview.Service.ProtoClass;

namespace UserReview.Service.Controller
{
  public class UserReviewService : UserReview.Service.ProtoClass.UserReviewService.UserReviewServiceBase
  {
    private readonly IUserReviewLogic _userReviewLogic;
    public UserReviewService(IUserReviewLogic userReviewLogic)
    {
      _userReviewLogic = userReviewLogic;
    }

    public override async Task<ReviewResponse> GetReview(GrpcInt request, ServerCallContext context)
    {
      ReviewResponse result = new ReviewResponse();
      var reviewDetails = await _userReviewLogic.GetReviewDetails(request.Value);
      if(reviewDetails != null) {
        result.ModelId = reviewDetails.ModelId;
        result.Rating = reviewDetails.Rating;
        result.Count = reviewDetails.Count;
      }
      return result;
    }
  }
}
