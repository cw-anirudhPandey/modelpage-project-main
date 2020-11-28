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
    private readonly ILogger<PriceService> _logger;
    private readonly IPriceLogic _priceLogic;
    public PriceService(ILogger<PriceService> logger, IPriceLogic priceLogic)
    {
      _logger = logger;
      _priceLogic = priceLogic;
    }

    public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
    {
      return Task.FromResult(new HelloReply
      {
        Message = "Hello " + request.Name
      });
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

    public override async Task<GrpcString> GetAvgPriceByVersionId(GrpcInt request, ServerCallContext context)
    {
      var details = await _priceLogic.GetAvgPriceByVersionId(request.Value);
      return new GrpcString()
      {
        Value = details.Value
      };
    }


  }
}
