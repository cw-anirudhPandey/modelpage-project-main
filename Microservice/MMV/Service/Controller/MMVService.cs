using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using MMV.Business.Interfaces;
using MMV.Entities;
using MMV.Service.ProtoClass;

namespace MMV.Service.Controller
{
  public class MMVService : MMV.Service.ProtoClass.MMVService.MMVServiceBase
  {
    private readonly ILogger<MMVService> _logger;
    private readonly ICarMakeLogic _carMakeLogic;
    private readonly ICarModelLogic _carModelLogic;
    private readonly ICarVersionLogic _carVersionLogic;

    public MMVService(ILogger<MMVService> logger, ICarMakeLogic carMakeLogic, ICarModelLogic carModelLogic,
       ICarVersionLogic carVersionLogic)
    {
      _logger = logger;
      _carMakeLogic = carMakeLogic;
      _carModelLogic = carModelLogic;
      _carVersionLogic = carVersionLogic;
    }

    public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
    {
      return Task.FromResult(new HelloReply
      {
        Message = "Hello " + request.Name
      });
    }


    public override async Task<MakeResponse> GetMake(GrpcInt request, ServerCallContext context)
    {
      var makeDetails = await _carMakeLogic.GetMake(request.Value);
      return new MakeResponse
      {
        Id = makeDetails.Id,
        Name = makeDetails.MakeName
      };
    }

    public override async Task<ModelResponse> GetModel(GrpcInt request, ServerCallContext context)
    {
      var modelDetails = await _carModelLogic.GetModel(request.Value);
      return new ModelResponse
      {
        Id = modelDetails.Id,
        MakeId = modelDetails.MakeId,
        Name = modelDetails.ModelName
      };
    }


    public override async Task<VersionListResponse> GetVersionList(GrpcInt request, ServerCallContext context)
    {
      var versionList = await _carVersionLogic.GetVersionList(request.Value);
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
      var details = await _carVersionLogic.GetDefaultVersionByModelId(request.Value);
      return new VersionResponse()
      {
        Id = details.Id,
        ModelId = details.ModelId,
        Name = details.Name
      };
    }
  }
}
