using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Image.DataAccess.Interfaces;
using Image.Entities;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace Image.DataAccess
{
  public class ImageRepository : IImageRepository
  {

    private readonly IConfiguration _config;
    public ImageRepository(IConfiguration config)
    {
      _config = config;
    }

    public async Task<CarImage> GetImage(int modelId)
    {
      CarImage imageDetails = new CarImage();
      using (IDbConnection conn = new MySqlConnection(_config.GetConnectionString("modelPageDBString")))
      {
        string query = @"SELECT 
                            carImageId AS Id,
                            carModelId AS ModelId,
                            carImage AS ImageUrl
                        FROM
                            _carImage
                        WHERE
                            carModelId = @ModelId;";
        imageDetails = (await conn.QueryAsync<CarImage>(query, new { ModelId = modelId })).FirstOrDefault();
      }
      return imageDetails;
    }
  }
}