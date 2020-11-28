using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using UserReview.Business;
using UserReview.Service.ProtoClass;

namespace UserReview.Service.Controller
{
  public class UserReviewService : UserReview.Service.ProtoClass.UserReviewService.UserReviewServiceBase
  {
    private readonly ILogger<UserReviewService> _logger;
    private readonly IUserReviewLogic _userReviewLogic;
    public UserReviewService(ILogger<UserReviewService> logger, IUserReviewLogic userReviewLogic)
    {
      _logger = logger;
      _userReviewLogic = userReviewLogic;
    }

    public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
    {
      return Task.FromResult(new HelloReply
      {
        Message = "Hello " + request.Name
      });
    }

    public override async Task<ReviewResponse> GetReview(GrpcInt request, ServerCallContext context)
    {
      var reviewDetails = await _userReviewLogic.GetReviewDetails(request.Value);
      return new ReviewResponse
      {
        ModelId = reviewDetails.ModelId,
        Rating = reviewDetails.Rating,
        Count = reviewDetails.Count
      };
    }
  }
}
