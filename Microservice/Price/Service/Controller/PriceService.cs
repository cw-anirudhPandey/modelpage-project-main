using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Price.Service.ProtoClass;
using Price.Business;
using Microsoft.Extensions.Logging;
using Price.Entities;
using Price.Business.Interfaces;

namespace Price.Service.Controller
{
  public class PriceService : Price.Service.ProtoClass.PriceService.PriceServiceBase
  {
    private readonly IPriceLogic _priceLogic;
    public PriceService(IPriceLogic priceLogic)
    {
      _priceLogic = priceLogic;
    }

    public override async Task<PriceListResponse> GetPriceListByCityId(GrpcInt request, ServerCallContext context)
    {
      var priceList = await _priceLogic.GetPriceListByCityId(request.Value);
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

    public override async Task<PriceResponse> GetPriceByCityVersion(GrpcTwoInt request, ServerCallContext context)
    {
      PriceResponse result = new PriceResponse();
      var price = await _priceLogic.GetPriceByCityVersion(request.CityId, request.VersionId);
      if (price != null)
      {
        result.Id = price.Id;
        result.VersionId = price.VersionId;
        result.CityId = price.CityId;
        result.Value = price.Value;
      }
      return result;
    }

    public override async Task<GrpcString> GetAvgPriceByVersionId(GrpcInt request, ServerCallContext context)
    {
      GrpcString result = new GrpcString();
      var details = await _priceLogic.GetAvgPriceByVersionId(request.Value);
      if (details != null)
      {
        result.Value = details.Value;
      }
      return result;
    }


  }
}
