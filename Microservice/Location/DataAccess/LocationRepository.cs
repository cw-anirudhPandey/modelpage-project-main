using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Location.DataAccess.Interfaces;
using Location.Entities;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace Location.DataAccess
{
  public class LocationRepository : ILocationRepository
  {

    private readonly IConfiguration _config;
    public LocationRepository(IConfiguration config)
    {
      _config = config;
    }

    public async Task<IEnumerable<CarCity>> GetAllCities()
    {
      var cityList = Enumerable.Empty<CarCity>();
      try
      {
        using (IDbConnection conn = new MySqlConnection(_config.GetConnectionString("modelPageDBString")))
        {
          string query = @"SELECT 
                          cityId as Id,
                          cityName as Name
                        FROM
                          _city;";
          cityList = (await conn.QueryAsync<CarCity>(query)).ToList();
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message + "GetAllCities method in DAL");
      }
      return cityList;
    }

  }
}