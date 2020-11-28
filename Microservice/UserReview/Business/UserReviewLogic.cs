using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AEPLCore.Cache.Interfaces;
using UserReview.DataAccess;
using UserReview.Entities;

namespace UserReview.Business
{
  public class UserReviewLogic : IUserReviewLogic
  {
    private string _key = "userReview-{0}-{1}";
    private readonly IUserReviewRepository _userReviewRepo;
    private readonly ICacheManager _cacheProvider;
    public UserReviewLogic(IUserReviewRepository userReviewRepo, ICacheManager cacheProvider)
    {
      _userReviewRepo = userReviewRepo;
      _cacheProvider = cacheProvider;
    }

    public async Task<CarReview> GetReviewDetails(int modelId)
    {
      string cacheKey = string.Format(_key, "get-review", modelId);
      var details = await _cacheProvider.GetFromCacheAsync<CarReview>(cacheKey,
                  new TimeSpan(0, 5, 0),
                  async () => await _userReviewRepo.GetReviewDetails(modelId));
      return details;
    }
  }
}