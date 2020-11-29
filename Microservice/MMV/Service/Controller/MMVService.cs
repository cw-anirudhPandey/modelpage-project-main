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
    private readonly ICarMakeLogic _carMakeLogic;
    private readonly ICarModelLogic _carModelLogic;
    private readonly ICarVersionLogic _carVersionLogic;

    public MMVService(ICarMakeLogic carMakeLogic, ICarModelLogic carModelLogic,
       ICarVersionLogic carVersionLogic)
    {
      _carMakeLogic = carMakeLogic;
      _carModelLogic = carModelLogic;
      _carVersionLogic = carVersionLogic;
    }

    public override async Task<MakeResponse> GetMake(GrpcInt request, ServerCallContext context)
    {
      MakeResponse result = new MakeResponse();
      var makeDetails = await _carMakeLogic.GetMake(request.Value);
      if(makeDetails != null) {
        result.Id = makeDetails.Id;
        result.Name = makeDetails.MakeName;
      }
      return result;
    }

    public override async Task<ModelResponse> GetModel(GrpcInt request, ServerCallContext context)
    {
      ModelResponse result = new ModelResponse();
      var modelDetails = await _carModelLogic.GetModel(request.Value);
      if (modelDetails != null)
      {
        result.Id = modelDetails.Id;
        result.MakeId = modelDetails.MakeId;
        result.Name = modelDetails.ModelName;
      }
      return result;
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
      VersionResponse result = new VersionResponse();
      var details = await _carVersionLogic.GetDefaultVersionByModelId(request.Value);
      if (details != null)
      {
        result.Id = details.Id;
        result.ModelId = details.ModelId;
        result.Name = details.Name;
      }
      return result;
    }
  }
}
