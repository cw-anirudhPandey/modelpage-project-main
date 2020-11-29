using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ModelPage.Entities;
using Grpc.Net.Client;
using ModelPage.DataAccess.Interfaces;
using Location;

namespace ModelPage.DataAccess
{

  public class LocationRepository : ILocationRepository
  {
    // private readonly IConfiguration _config;
    private GrpcChannel _channel = GrpcChannel.ForAddress("https://localhost:5009");
    // public ModelPageRepository(IConfiguration config)
    // {
    //   _config = config;
    // }

    public async Task<IEnumerable<CarCity>> GetAllCities()
    {
      var cityList = new List<CarCity>();
      try
      {
        var client = new Location.LocationService.LocationServiceClient(_channel);
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

  }
}