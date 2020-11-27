using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace MMV.Service.Controller
{
  public class MMVService : MMV.Service.ProtoClass.MMVService.MMVServiceBase
  {
    private readonly ILogger<MMVService> _logger;
    public MMVService(ILogger<MMVService> logger)
    {
      _logger = logger;
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
  }
}
