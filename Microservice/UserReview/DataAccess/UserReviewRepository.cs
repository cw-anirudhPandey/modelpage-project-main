using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using UserReview.Entities;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

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
      try
      {
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
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message + "GetReviewDetails method in DAL for modelId = " + modelId);
      }
      return reviewDetails;
    }
  }
}