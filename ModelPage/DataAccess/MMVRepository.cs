using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ModelPage.Entities;
using Grpc.Net.Client;
using ModelPage.DataAccess.Interfaces;
using MMV;

namespace ModelPage.DataAccess
{

  public class MMVRepository : IMMVRepository
  {
    private GrpcChannel _channel = GrpcChannel.ForAddress("https://localhost:5005");

    public async Task<Make> GetMake(int makeId)
    {
      Make makeDetails = new Make();

      var client = new MMV.MMVService.MMVServiceClient(_channel);
      var details = await client.GetMakeAsync(new GrpcInt { Value = makeId });
      makeDetails.Id = details.Id;
      makeDetails.MakeName = details.Name;

      return makeDetails;
    }

    public async Task<Model> GetModel(int modelId)
    {
      Model modelDetails = new Model();

      var client = new MMV.MMVService.MMVServiceClient(_channel);
      var details = await client.GetModelAsync(new GrpcInt { Value = modelId });
      modelDetails.Id = details.Id;
      modelDetails.MakeId = details.MakeId;
      modelDetails.ModelName = details.Name;

      return modelDetails;
    }
    public async Task<IEnumerable<CarVersion>> GetVersionList(int modelId)
    {
      var versionList = new List<CarVersion>();

      var client = new MMV.MMVService.MMVServiceClient(_channel);
      var details = await client.GetVersionListAsync(new GrpcInt { Value = modelId });
      foreach (var item in details.Version)
      {
        versionList.Add(new CarVersion
        {
          Id = item.Id,
          ModelId = item.ModelId,
          Name = item.Name,
        });
      }

      return versionList;
    }

    public async Task<CarVersion> GetDefaultVersionByModelId(int modelId)
    {
      var versionDetail = new CarVersion();

      var client = new MMV.MMVService.MMVServiceClient(_channel);
      var details = await client.GetDefaultVersionByModelIdAsync(new GrpcInt { Value = modelId });
      versionDetail.Id = details.Id;
      versionDetail.ModelId = details.ModelId;
      versionDetail.Name = details.Name;

      return versionDetail;
    }

  }
}