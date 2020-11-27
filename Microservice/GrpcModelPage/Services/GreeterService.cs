using System.Collections.Generic;
using System.Threading.Tasks;
using Grpc.Core;
using Microservice.Business;
using Microservice.Entities;
using Microsoft.Extensions.Logging;

namespace GrpcModelPage
{
  public class GreeterService : Greeter.GreeterBase
  {
    private readonly ILogger<GreeterService> _logger;
    private readonly IModelDataLogic _modelDataLogic;
    public GreeterService(ILogger<GreeterService> logger, IModelDataLogic modelDataLogic)
    {
      _logger = logger;
      _modelDataLogic = modelDataLogic;
    }

    public override async Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
    {
      var make = await _modelDataLogic.GetMake(0);
      var model = await _modelDataLogic.GetModel(4);
      var image = await _modelDataLogic.GetImage(4);
      var emi = await _modelDataLogic.GetEmiDetails(4);
      var review = await _modelDataLogic.GetReviewDetails(4);
      var list = await _modelDataLogic.GetPriceDetails(4);
      return new HelloReply
      {
        Message = "Hello " + request.Name
      };
    }

    public override async Task<MakeResponse> GetMake(GrpcInt request, ServerCallContext context)
    {
      var makeDetails = await _modelDataLogic.GetMake(request.Value);
      return new MakeResponse
      {
        Id = makeDetails.Id,
        Name = makeDetails.MakeName
      };
    }

    public override async Task<ModelResponse> GetModel(GrpcInt request, ServerCallContext context)
    {
      var modelDetails = await _modelDataLogic.GetModel(request.Value);
      return new ModelResponse
      {
        Id = modelDetails.Id,
        Name = modelDetails.ModelName
      };
    }

    public override async Task<ImageResponse> GetImage(GrpcInt request, ServerCallContext context)
    {
      var imageDetails = await _modelDataLogic.GetImage(request.Value);
      return new ImageResponse
      {
        Id = imageDetails.Id,
        ModelId = imageDetails.ModelId,
        ImageUrl = imageDetails.ImageUrl
      };
    }

    public override async Task<ReviewResponse> GetReview(GrpcInt request, ServerCallContext context)
    {
      var reviewDetails = await _modelDataLogic.GetReviewDetails(request.Value);
      return new ReviewResponse
      {
        ModelId = reviewDetails.ModelId,
        Rating = reviewDetails.Rating,
        Count = reviewDetails.Count
      };
    }

    public override async Task<VersionListResponse> GetVersionList(GrpcInt request, ServerCallContext context)
    {
      var versionList = await _modelDataLogic.GetVersionList(request.Value);
      return getVersionListProto(versionList);
    }

    private VersionListResponse getVersionListProto(IEnumerable<CarVersion> versionList)
    {
      VersionListResponse versionListProto = new VersionListResponse();
      foreach (var versionItem in versionList)
      {
        versionListProto.Version.Add(new VersionResponse
        {
          Id = versionItem.Id,
          ModelId = versionItem.ModelId,
          Name = versionItem.Name
        });
      }
      return versionListProto;
    }

    public override async Task<VersionResponse> GetDefaultVersionByModelId(GrpcInt request, ServerCallContext context)
    {
      var details = await _modelDataLogic.GetDefaultVersionByModelId(request.Value);
      return new VersionResponse()
      {
        Id = details.Id,
        ModelId = details.ModelId,
        Name = details.Name
      };
    }

    public override async Task<CityListResponse> GetAllCities(EmptyParam request, ServerCallContext context)
    {
      var cityList = await _modelDataLogic.GetAllCities();
      return getCityListProto(cityList);
    }

    private CityListResponse getCityListProto(IEnumerable<CarCity> cityList)
    {
      CityListResponse cityListProto = new CityListResponse();
      foreach (var cityItem in cityList)
      {
        cityListProto.City.Add(new CityResponse
        {
          Id = cityItem.Id,
          Name = cityItem.Name
        });
      }
      return cityListProto;
    }

    public override async Task<PriceListResponse> GetPriceListByCityId(GrpcInt request, ServerCallContext context)
    {
      var priceList = await _modelDataLogic.GetPriceListByCityId(request.Value);
      return getPriceListProto(priceList);
    }

    private PriceListResponse getPriceListProto(IEnumerable<CarPrice> priceList)
    {
      PriceListResponse priceListProto = new PriceListResponse();
      foreach (var priceItem in priceList)
      {
        priceListProto.Price.Add(new PriceResponse
        {
          Id = priceItem.Id,
          VersionId = priceItem.VersionId,
          CityId = priceItem.CityId,
          Value = priceItem.Value,
        });
      }
      return priceListProto;
    }
    
    public override async Task<GrpcString> GetAvgPriceByVersionId(GrpcInt request, ServerCallContext context)
    {
      var details = await _modelDataLogic.GetAvgPriceByVersionId(request.Value);
      return new GrpcString()
      {
        Value = details.Value
      };
    }

    public override async Task<EmiResponse> GetEmi(GrpcInt request, ServerCallContext context)
    {
      var emiDetails = await _modelDataLogic.GetEmiDetails(request.Value);
      return new EmiResponse
      {
        Id = emiDetails.Id,
        ModelId = emiDetails.ModelId,
        Cost = emiDetails.Cost,
        Duration = emiDetails.Duration
      };
    }

    public override async Task<PriceDetailsListResponse> GetPriceDetails(GrpcInt request, ServerCallContext context) {
      var priceDetails = await _modelDataLogic.GetPriceDetails(request.Value);
      return getPriceDetailsList(priceDetails);
    }


    // public override async Task<ModelDataReply> GetModelDataByModelIdAsync(GrpcInt request, ServerCallContext context)
    // {
    //   var details = await _modelDataLogic.getModelData(request.Value);
    //   // string key = "CarModel_{0}";
    //   // string cacheKey = string.Format(key, request.Value);
    //   // var details = await _cacheManager.GetFromCacheAsync<CarDetails>(cacheKey,
    //   //             new TimeSpan(0, 5, 0),
    //   //             async () => await _dataAccess.getCarDataAsync(request.Value));

    //   CityList cityList = new CityList();
    //   foreach (var cityItem in details.CitySet)
    //   {
    //       cityList.Cities.Add(new GrpcString{
    //         Value = cityItem
    //       });
    //   }
    //   return await Task.FromResult(new ModelDataReply
    //   {
    //     MakeName = details.MakeName,
    //     ModelName = details.ModelName,
    //     ImageUrl = details.ImageUrl,
    //     Rating = details.Rating,
    //     ReviewCount = details.ReviewCount,
    //     EmiDetail = (new EmiDetails
    //     {
    //       Cost = details.EmiDetail.cost,
    //       Duration = details.EmiDetail.duration
    //     }),
    //     CityList = getCityList(details.CitySet),
    //     VersionList = getVersionList(details.VersionSet),
    //     PriceDetailsList = getPriceDetailsList(details.PriceDetailsList)
    //   });
    // }

    // public CityList getCityList(HashSet<string> citySet) {
    //   CityList cityList = new CityList();
    //   foreach (var cityItem in citySet)
    //   {
    //       cityList.Cities.Add(new GrpcString{
    //         Value = cityItem
    //       });
    //   }
    //   return cityList;
    // }



    public PriceDetailsListResponse getPriceDetailsList(IEnumerable<Microservice.Entities.PriceDetails> priceDetailsList)
    {
      PriceDetailsListResponse priceDetailsProto = new PriceDetailsListResponse();
      foreach (var priceDetailItem in priceDetailsList)
      {
        priceDetailsProto.PriceDetails.Add(new PriceDetailsResponse
        {
          Price = priceDetailItem.Price,
          Version = priceDetailItem.Version,
          City = priceDetailItem.City
        });
      }
      return priceDetailsProto;
    }
  }
}
