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
    private GrpcChannel _channel = GrpcChannel.ForAddress("https://localhost:5008");

    public async Task<IEnumerable<CarPrice>> GetPriceListByCityId(int cityId)
    {
      var priceList = new List<CarPrice>();

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

      return priceList;
    }

    public async Task<CarPrice> GetPriceByCityVersion(int cityId, int versionId)
    {
      var price = new CarPrice();

      var client = new Price.PriceService.PriceServiceClient(_channel);
      var details = await client.GetPriceByCityVersionAsync(new GrpcTwoInt { CityId = cityId, VersionId = versionId });
      price.Id = details.Id;
      price.VersionId = details.VersionId;
      price.CityId = details.CityId;
      price.Value = details.Value;

      return price;
    }

    public async Task<CarPrice> GetAvgPriceByVersionId(int versionId)
    {
      var priceDetail = new CarPrice();

      var client = new Price.PriceService.PriceServiceClient(_channel);
      var details = await client.GetAvgPriceByVersionIdAsync(new GrpcInt { Value = versionId });
      priceDetail.Value = details.Value;

      return priceDetail;
    }

  }
}