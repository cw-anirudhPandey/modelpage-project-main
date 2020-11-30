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

      return priceList;
    }

    public async Task<CarPrice> GetPriceByCityVersion(int cityId, int versionId)
    {
      var price = new CarPrice();

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
                            cityId = @CityId
                          And
                            carVersionId = @VersionId";
        price = (await conn.QueryAsync<CarPrice>(query, new
        {
          CityId = cityId,
          VersionId = versionId
        })).FirstOrDefault();
      }

      return price;
    }

    public async Task<CarPrice> GetAvgPriceByVersionId(int versionId)
    {
      var priceDetails = new CarPrice();

      using (IDbConnection conn = new MySqlConnection(_config.GetConnectionString("modelPageDBString")))
      {
        string query = @"SELECT 
                            floor(avg(carPrice)) AS Value
                        FROM
                            _carPrice
                        WHERE
                            carVersionId = @VersionId;";
        priceDetails = (await conn.QueryAsync<CarPrice>(query, new { VersionId = versionId })).FirstOrDefault();
      }

      return priceDetails;
    }


  }
}