using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ModelPage.Entities;
using Grpc.Net.Client;
using GrpcModelPage;
using ModelPage.DataAccess.Interfaces;

namespace ModelPage.DataAccess
{
    
public class ModelPageRepository : IModelPageRepository
{
  // private readonly IConfiguration _config;

  private GrpcChannel _channel = GrpcChannel.ForAddress("https://localhost:5001");
  // public ModelPageRepository(IConfiguration config)
  // {
  //   _config = config;
  // }
  public async Task<Make> GetMake(int makeId)
  {
    Make makeDetails = new Make();
    try
    {
      var client = new Greeter.GreeterClient(_channel);
      var details = await client.GetMakeAsync(new GrpcInt { Value = makeId });
      makeDetails.Id = details.Id;
      makeDetails.MakeName = details.Name;
    }
    catch (Exception ex)
    {
      Console.WriteLine(ex.Message + "GetMake method in DAL for makeId = " + makeId);
    }
    return makeDetails;
  }

  public async Task<Model> GetModel(int modelId)
  {
    Model modelDetails = new Model();
    try
    {
      var client = new Greeter.GreeterClient(_channel);
      var details = await client.GetModelAsync(new GrpcInt { Value = modelId });
      modelDetails.Id = details.Id;
      modelDetails.ModelName = details.Name;
    }
    catch (Exception ex)
    {
      Console.WriteLine(ex.Message + "GetModel method in DAL of API for modelId = " + modelId);
    }
    return modelDetails;
  }

  public async Task<CarImage> GetImage(int modelId)
  {
    CarImage imageDetails = new CarImage();
    try
    {
      var client = new Greeter.GreeterClient(_channel);
      var details = await client.GetImageAsync(new GrpcInt { Value = modelId });
      imageDetails.Id = details.Id;
      imageDetails.ModelId = details.ModelId;
      imageDetails.ImageUrl = details.ImageUrl;
    }
    catch (Exception ex)
    {
      Console.WriteLine(ex.Message + "GetImage method in DAL of API for modelId = " + modelId);
    }
    return imageDetails;
  }

  public async Task<Review> GetReviewDetails(int modelId)
  {
    Review reviewDetails = new Review();
    try
    {
      var client = new Greeter.GreeterClient(_channel);
      var details = await client.GetReviewAsync(new GrpcInt { Value = modelId });
      reviewDetails.ModelId = details.ModelId;
      reviewDetails.Count = details.Count;
      reviewDetails.Rating = details.Rating;
    }
    catch (Exception ex)
    {
      Console.WriteLine(ex.Message + "GetReviewDetails method in DAL of API for modelId = " + modelId);
    }
    return reviewDetails;
  }

  public async Task<IEnumerable<CarVersion>> GetVersionList(int modelId)
  {
    var versionList = new List<CarVersion>();
    try
    {
      var client = new Greeter.GreeterClient(_channel);
      var details = await client.GetVersionListAsync(new GrpcInt { Value = modelId });
      foreach (var item in details.Version)
      {
        versionList.Add(new CarVersion
        {
          Id = item.Id,
          ModelId = item.ModelId,
          Name = item.Name,
        });
      }
    }
    catch (Exception ex)
    {
      Console.WriteLine(ex.Message + "GetVersionList method in DAL of API for modelId = " + modelId);
    }
    return versionList;
  }

  public async Task<CarVersion> GetDefaultVersionByModelId(int modelId)
  {
    var versionDetail = new CarVersion();
    try
    {
      var client = new Greeter.GreeterClient(_channel);
      var details = await client.GetDefaultVersionByModelIdAsync(new GrpcInt { Value = modelId });
      versionDetail.Id = details.Id;
      versionDetail.ModelId = details.ModelId;
      versionDetail.Name = details.Name;
    }
    catch (Exception ex)
    {
      Console.WriteLine(ex.Message + "GetDefaultVersionByModelId method in DAL of API for modelId = " + modelId);
    }
    return versionDetail;
  }

  public async Task<IEnumerable<CarCity>> GetAllCities()
  {
    var cityList = new List<CarCity>();
    try
    {
      AppContext.SetSwitch(
"System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
      var client = new Greeter.GreeterClient(_channel);
      var details = await client.GetAllCitiesAsync(new EmptyParam());
      foreach (var item in details.City)
      {
        cityList.Add(new CarCity
        {
          Id = item.Id,
          Name = item.Name,
        });
      }
    }
    catch (Exception ex)
    {
      Console.WriteLine(ex.Message + "GetAllCities method in DAL of API");
    }
    return cityList;
  }


  public async Task<IEnumerable<CarPrice>> GetPriceListByCityId(int cityId)
  {
    var priceList = new List<CarPrice>();
    try
    {
      var client = new Greeter.GreeterClient(_channel);
      var details = await client.GetPriceListByCityIdAsync(new GrpcInt { Value = cityId });
      foreach (var item in details.Price)
      {
        priceList.Add(new CarPrice
        {
          Id = item.Id,
          VersionId = item.VersionId,
          CityId = item.CityId,
          Value = item.Value
        });
      }
    }
    catch (Exception ex)
    {
      Console.WriteLine(ex.Message + "GetPriceListByCityId method in DAL of API for cityId = " + cityId);
    }
    return priceList;
  }

  public async Task<CarPrice> GetAvgPriceByVersionId(int versionId)
  {
    var priceDetail = new CarPrice();
    try
    {
      var client = new Greeter.GreeterClient(_channel);
      var details = await client.GetAvgPriceByVersionIdAsync(new GrpcInt { Value = versionId });
      priceDetail.Value = details.Value;
    }
    catch (Exception ex)
    {
      Console.WriteLine(ex.Message + "GetAvgPriceByVersionId method in DAL of API for versionId = " + versionId);
    }
    return priceDetail;
  }

  public async Task<IEnumerable<PriceDetails>> GetPriceDetails(int modelId)
  {
    var priceDetailsList = new List<PriceDetails>();
    try
    {
      var client = new Greeter.GreeterClient(_channel);
      var details = await client.GetPriceDetailsAsync(new GrpcInt { Value = modelId });
      foreach (var item in details.PriceDetails)
      {
        priceDetailsList.Add(new PriceDetails
        {
          Price = item.Price,
          Version = item.Version,
          City = item.City,
        });
      }
    }
    catch (Exception ex)
    {
      Console.WriteLine(ex.Message + "GetPriceDetails method in DAL of API for modelId = " + modelId);
    }
    return priceDetailsList;
  }

  public async Task<Emi> GetEmiDetails(int modelId)
  {
    Emi emiDetails = new Emi();
    try
    {
      var client = new Greeter.GreeterClient(_channel);
      var details = await client.GetEmiAsync(new GrpcInt { Value = modelId });
      emiDetails.Id = details.Id;
      emiDetails.ModelId = details.ModelId;
      emiDetails.Cost = details.Cost;
      emiDetails.Duration = details.Duration;
    }
    catch (Exception ex)
    {
      Console.WriteLine(ex.Message + "GetEmiDetails method in DAL of API for modelId = " + modelId);
    }
    return emiDetails;
  }
}
}