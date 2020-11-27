using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using MMV.Entities;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using MMV.DataAccess.Interfaces;

namespace MMV.DataAccess
{
  public class CarMakeRepository : ICarMakeRepository
  {
    private readonly IConfiguration _config;
    public CarMakeRepository(IConfiguration config)
    {
      _config = config;
    }
    public async Task<Make> GetMake(int makeId)
    {
      Make makeDetails = new Make();
      try
      {
        using (IDbConnection conn = new MySqlConnection(_config.GetConnectionString("modelPageDBString")))
        {
          string query = @"Select 
                            carMakeId as Id, 
                            carMakeName as MakeName
                        From 
                            _carMake
                        Where 
                            carMakeId = @MakeId;";
          makeDetails = (await conn.QueryAsync<Make>(query, new { MakeId = makeId })).FirstOrDefault();
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message + "GetMake method in DAL for makeId = " + makeId);
      }
      return makeDetails;
    }
  }
}