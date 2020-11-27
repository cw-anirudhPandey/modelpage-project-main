using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using MMV.Entities;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using DataAccess.Interfaces;

namespace MMV.DataAccess
{
  public class CarModelRepository : ICarModelRepository
  {
    private readonly IConfiguration _config;
    public CarModelRepository(IConfiguration config)
    {
      _config = config;
    }

    public async Task<Make> GetMakeIdByModelId(int modelId)
    {
      Make makeDetails = new Make();
      try
      {
        using (IDbConnection conn = new MySqlConnection(_config.GetConnectionString("modelPageDBString")))
        {
          string query = @"Select 
                            carMakeId as Id
                        From 
                            _carModel
                        Where 
                            carModelId = @ModelId;";
          makeDetails = (await conn.QueryAsync<Make>(query, new { ModelId = modelId })).FirstOrDefault();
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message + "GetMakeIdByModelId method in DAL for modelId = " + modelId);
      }
      return makeDetails;
    }

    public async Task<Model> GetModel(int modelId)
    {
      Model modelDetails = new Model();
      try
      {
        using (IDbConnection conn = new MySqlConnection(_config.GetConnectionString("modelPageDBString")))
        {
          string query = @"Select 
                            carModelId as Id, 
                            carModelName as ModelName
                        From 
                            _carModel 
                        Where 
                            carModelId = @ModelId;";
          modelDetails = (await conn.QueryAsync<Model>(query, new { ModelId = modelId })).FirstOrDefault();
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message + "GetModel method in DAL for modelId = " + modelId);
      }
      return modelDetails;
    }

  }
}