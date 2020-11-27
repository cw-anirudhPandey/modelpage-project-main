using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microservice.Entities;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

public class ModelDataRepository : IModelDataRepository
{

  private readonly IConfiguration _config;
  public ModelDataRepository(IConfiguration config)
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

  public async Task<Image> GetImage(int modelId)
  {
    Image imageDetails = new Image();
    try
    {
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
        imageDetails = (await conn.QueryAsync<Image>(query, new { ModelId = modelId })).FirstOrDefault();
      }
    }
    catch (Exception ex)
    {
      Console.WriteLine(ex.Message + "GetImage method in DAL for modelId = " + modelId);
    }
    return imageDetails;
  }

  public async Task<Review> GetReviewDetails(int modelId)
  {
    Review reviewDetails = new Review();
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
        reviewDetails = (await conn.QueryAsync<Review>(query, new { ModelId = modelId })).FirstOrDefault();
      }
    }
    catch (Exception ex)
    {
      Console.WriteLine(ex.Message + "GetReviewDetails method in DAL for modelId = " + modelId);
    }
    return reviewDetails;
  }

  public async Task<IEnumerable<PriceDetails>> GetPriceDetails(int modelId)
  {
    var priceDetails = Enumerable.Empty<PriceDetails>();
    try
    {
      using (IDbConnection conn = new MySqlConnection(_config.GetConnectionString("modelPageDBString")))
      {
        string query = @"Select 
                            _carVersion.carVersionName as Version,
                            _carPrice.carPrice as Price,
                            _city.cityName as City
                        From
                            _carVersion 
                                inner join 
                            _carPrice on _carVersion.carVersionId = _carPrice.carVersionId
                                inner join 
                            _city on _carPrice.cityId = _city.cityId
                        Where 
                            _carVersion.carModelId = @ModelId;";
        priceDetails = (await conn.QueryAsync<PriceDetails>(query, new { ModelId = modelId })).ToList();
      }
    }
    catch (Exception ex)
    {
      Console.WriteLine(ex.Message + "GetPriceDetails method in DAL for modelId = " + modelId);
    }
    return priceDetails;
  }
//-------------------------------------------------------------------------------------------------------
  public async Task<IEnumerable<CarVersion>> GetVersionList(int modelId) {
    var versionList = Enumerable.Empty<CarVersion>();
    try
    {
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
    }
    catch (Exception ex)
    {
      Console.WriteLine(ex.Message + "GetVersionList method in DAL for modelId = " + modelId);
    }
    return versionList;
  }

  public async Task<CarVersion> GetDefaultVersionByModelId(int modelId) {
    var versionDetail = new CarVersion();
    try
    {
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
    }
    catch (Exception ex)
    {
      Console.WriteLine(ex.Message + "GetDefaultVersionByModelId method in DAL for modelId = " + modelId);
    }
    return versionDetail;
  }

  public async Task<IEnumerable<CarCity>> GetAllCities() {
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

  public async Task<IEnumerable<CarPrice>> GetPriceListByCityId(int cityId) {
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
      Console.WriteLine(ex.Message + "GetPriceListByCityId method in DAL of cityId = "+ cityId);
    }
    return priceList;
  }

  public async Task<CarPrice> GetAvgPriceByVersionId(int versionId) {
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
      Console.WriteLine(ex.Message + "GetPriceByVersionId method in DAL of versionId = "+ versionId);
    }
    return priceDetails;
  }

  public async Task<Emi> GetEmiDetails(int modelId)
  {
    return new Emi
    {
      Id = 0,
      ModelId = modelId,
      Cost = "10,719",
      Duration = "5 years"
    };
  }

  // public async Task<MakeModel> GetMakeModelDetails(int modelId)
  // {
  //   using (IDbConnection conn = new MySqlConnection(_connection))
  //   {
  //     string query = @"Select _carMake.carMakeId as MakeId, 
  //                     _carModel.carModelId as ModelId, 
  //                     _carMake.carMakeName as MakeName,
  //                     _carModel.carModelName as ModelName
  //                     From
  //                     _carMake inner join _carModel 
  //                     on _carMake.carMakeId = _carModel.carMakeId
  //                     Where 
  //                     _carModel.carModelId = @ModelId;";
  //     var details = (await conn.QueryAsync<MakeModel>(query, new { ModelId = modelId })).FirstOrDefault();
  //     return details;
  //   }
  // }



  // string query = @"Select _carMake.carMakeName as MakeName,
  //                             _carModel.carModelName as ModelName,
  //                             _carImage.carImage as ImageUrl
  //                               From
  //                             _carMake inner join _carModel 
  //                               on _carMake.carMakeId = _carModel.carMakeId
  //                                     inner join _carImage
  //                               on _carModel.carModelId = _carImage.carModelId
  //                             Where 
  //                               _carModel.carModelId = @ModelId;";

  /* public async Task<CarDetails> getCarDataAsync(int modelId)
  {
    CarDetails details;
    try
    {
      using (IDbConnection conn = new MySqlConnection(_connection))
      {
        string query = @"Select _carMake.carMakeName as MakeName,
                        _carModel.carModelName as ModelName,
                            _carImage.carImage as ImageUrl,
                        avg(_carReview.carRating) as Rating,
                            count(_carReview.carRating) as ReviewCount
                            From
                            _carMake inner join _carModel 
                            on _carMake.carMakeId = _carModel.carMakeId
                                    inner join _carImage
                                    on _carModel.carModelId = _carImage.carModelId
                                    inner join _carReview
                                    on _carImage.carModelId = _carReview.carModelId
                        Where 
                            _carMake.carMakeId = 0
                                And
                            _carModel.carModelId = 4
                        group by 
                            _carImage.carImage;";
        details = (await conn.QueryAsync<CarDetails>(query)).FirstOrDefault();
        query = @"Select _carVersion.carVersionName as Version,
                        _carPrice.carPrice as Price,
                            _city.cityName as City
                            From
                            _carVersion inner join _carPrice
                                    on _carVersion.carVersionId = _carPrice.carVersionId
                                    inner join _city
                                    on _carPrice.cityId = _city.cityId
                        Where 
                          _carVersion.carModelId = 4;
                            ";
        List<ModelPriceDetails> priceVersionDetailList = (await conn.QueryAsync<PriceVersionDetail>(query)).ToList();
        HashSet<string> citySet = new HashSet<string>(),
                        versionSet = new HashSet<string>(); 
        priceVersionDetailList.ForEach(detail=>{
          citySet.Add(detail.City);
          versionSet.Add(detail.Version);
        });
        details.CitySet = citySet;
        details.VersionSet = versionSet;
        details.PriceDetailsList = priceVersionDetailList;
        details.EmiDetail = new EmiDetails
        {
          cost = "10,719",
          duration = "5 years"
        };
        return details;
      }
    }
    catch (Exception e)
    {
      Console.WriteLine("Exception Occured: " + e.Message);
      return null;
    }
  }
  */

}