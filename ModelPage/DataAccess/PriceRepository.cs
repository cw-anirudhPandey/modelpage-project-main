using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ModelPage.Entities;
using Grpc.Net.Client;
using ModelPage.DataAccess.Interfaces;
using Price;

namespace ModelPage.DataAccess
{

  public class PriceRepository : IPriceRepository
  {
    // private readonly IConfiguration _config;
    private GrpcChannel _channel = GrpcChannel.ForAddress("https://localhost:5008");
    // public ModelPageRepository(IConfiguration config)
    // {
    //   _config = config;
    // }

    public async Task<IEnumerable<CarPrice>> GetPriceListByCityId(int cityId)
    {
      var priceList = new List<CarPrice>();
      try
      {
        var client = new Price.PriceService.PriceServiceClient(_channel);
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

    public async Task<CarPrice> GetPriceByCityVersion(int cityId, int versionId)
    {
      var price = new CarPrice();
      try
      {
        var client = new Price.PriceService.PriceServiceClient(_channel);
        var details = await client.GetPriceByCityVersionAsync(new GrpcTwoInt { CityId = cityId, VersionId = versionId });
        price.Id = details.Id;
        price.VersionId = details.VersionId;
        price.CityId = details.CityId;
        price.Value = details.Value;
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message + "GetPriceByCityVersion method in DAL of API for cityId = " + cityId);
      }
      return price;
    }

    public async Task<CarPrice> GetAvgPriceByVersionId(int versionId)
    {
      var priceDetail = new CarPrice();
      try
      {
        var client = new Price.PriceService.PriceServiceClient(_channel);
        var details = await client.GetAvgPriceByVersionIdAsync(new GrpcInt { Value = versionId });
        priceDetail.Value = details.Value;
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message + "GetAvgPriceByVersionId method in DAL of API for versionId = " + versionId);
      }
      return priceDetail;
    }

  }
}