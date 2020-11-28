using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Location.Service.ProtoClass;
using Location.Business;
using Microsoft.Extensions.Logging;
using Location.Entities;
using Location.Business.Interfaces;

namespace Location.Service.Controller
{
  public class LocationService : Location.Service.ProtoClass.LocationService.LocationServiceBase
  {
    private readonly ILogger<LocationService> _logger;
    private readonly ILocationLogic _locationLogic;
    public LocationService(ILogger<LocationService> logger, ILocationLogic locationLogic)
    {
      _logger = logger;
      _locationLogic = locationLogic;
    }

    public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
    {
      return Task.FromResult(new HelloReply
      {
        Message = "Hello " + request.Name
      });
    }

    public override async Task<CityListResponse> GetAllCities(EmptyParam request, ServerCallContext context)
    {
      var cityList = await _locationLogic.GetAllCities();
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

  }
}
