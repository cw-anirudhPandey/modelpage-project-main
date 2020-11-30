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
  public class CarVersionRepository : ICarVersionRepository
  {
    private readonly IConfiguration _config;
    public CarVersionRepository(IConfiguration config)
    {
      _config = config;
    }

    public async Task<IEnumerable<CarVersion>> GetVersionList(int modelId)
    {
      var versionList = Enumerable.Empty<CarVersion>();

      using (IDbConnection conn = new MySqlConnection(_config.GetConnectionString("modelPageDBString")))
      {
        string query = @"SELECT 
                            carVersionId as Id,
                            carModelId as ModelId,
                            carVersionName as Name
                        FROM
                            _carVersion
                        WHERE
                            carModelId = @ModelId;";
        versionList = (await conn.QueryAsync<CarVersion>(query, new { ModelId = modelId })).ToList();
      }

      return versionList;
    }

    public async Task<CarVersion> GetDefaultVersionByModelId(int modelId)
    {
      var versionDetail = new CarVersion();

      using (IDbConnection conn = new MySqlConnection(_config.GetConnectionString("modelPageDBString")))
      {
        string query = @"SELECT
                          carVersionId as Id,
                          carModelId as ModelId,
                          carVersionName as Name
                        FROM
                            _carVersion
                        WHERE
                            carModelId = @ModelId;";
        versionDetail = (await conn.QueryAsync<CarVersion>(query, new { ModelId = modelId })).FirstOrDefault();
      }

      return versionDetail;
    }
  }
}