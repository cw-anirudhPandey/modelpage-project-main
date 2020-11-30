using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using UserReview.Entities;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using UserReview.DataAccess.Interfaces;

namespace UserReview.DataAccess
{
  public class UserReviewRepository : IUserReviewRepository
  {
    private readonly IConfiguration _config;
    public UserReviewRepository(IConfiguration config)
    {
      _config = config;
    }

    public async Task<CarReview> GetReviewDetails(int modelId)
    {
      CarReview reviewDetails = new CarReview();

      using (IDbConnection conn = new MySqlConnection(_config.GetConnectionString("modelPageDBString")))
      {
        string query = @"Select 
                            carModelId as ModelId,
                            avg(carRating) as Rating,
                            count(userId) as Count
                        From
                            _carReview
                        Where
                            carModelId = @ModelId;";
        reviewDetails = (await conn.QueryAsync<CarReview>(query, new { ModelId = modelId })).FirstOrDefault();
      }

      return reviewDetails;
    }
  }
}