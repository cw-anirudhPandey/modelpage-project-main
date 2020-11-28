using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Price.DataAccess.Interfaces;
using Price.Entities;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace Price.DataAccess
{
  public class PriceRepository : IPriceRepository
  {

    private readonly IConfiguration _config;
    public PriceRepository(IConfiguration config)
    {
      _config = config;
    }

    public async Task<IEnumerable<CarPrice>> GetPriceListByCityId(int cityId)
    {
      var priceList = Enumerable.Empty<CarPrice>();
      try
      {
        using (IDbConnection conn = new MySqlConnection(_config.GetConnectionString("modelPageDBString")))
        {
          string query = @"SELECT 
                            carPriceId AS Id, 
                            carVersionId as VersionId, 
                            cityId as CityId,
                            carPrice AS Value
                        FROM
                            _carPrice
                        WHERE
                            cityId = @CityId";
          priceList = (await conn.QueryAsync<CarPrice>(query, new { CityId = cityId })).ToList();
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message + "GetPriceListByCityId method in DAL of cityId = " + cityId);
      }
      return priceList;
    }

    public async Task<CarPrice> GetAvgPriceByVersionId(int versionId)
    {
      var priceDetails = new CarPrice();
      try
      {
        using (IDbConnection conn = new MySqlConnection(_config.GetConnectionString("modelPageDBString")))
        {
          string query = @"SELECT 
                            avg(carPrice) AS Value
                        FROM
                            _carPrice
                        WHERE
                            carVersionId = @VersionId;";
          priceDetails = (await conn.QueryAsync<CarPrice>(query, new { VersionId = versionId })).FirstOrDefault();
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message + "GetPriceByVersionId method in DAL of versionId = " + versionId);
      }
      return priceDetails;
    }


  }
}