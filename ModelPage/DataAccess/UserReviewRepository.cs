using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ModelPage.Entities;
using Grpc.Net.Client;
using UserReview;
using ModelPage.DataAccess.Interfaces;

namespace ModelPage.DataAccess
{
  public class UserReviewRepository : IUserReviewRepository
  {
    private GrpcChannel _channel = GrpcChannel.ForAddress("https://localhost:5006");

    public async Task<Review> GetReviewDetails(int modelId)
    {
      Review reviewDetails = new Review();

      var client = new UserReview.UserReviewService.UserReviewServiceClient(_channel);
      var details = await client.GetReviewAsync(new GrpcInt { Value = modelId });
      reviewDetails.ModelId = details.ModelId;
      reviewDetails.Count = details.Count;
      reviewDetails.Rating = details.Rating;

      return reviewDetails;
    }

  }
}