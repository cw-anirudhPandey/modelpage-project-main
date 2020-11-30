using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ModelPage.Entities;
using Grpc.Net.Client;
using ModelPage.DataAccess.Interfaces;
using Image;

namespace ModelPage.DataAccess
{

  public class ImageRepository : IImageRepository
  {
    private GrpcChannel _channel = GrpcChannel.ForAddress("https://localhost:5007");

    public async Task<CarImage> GetImage(int modelId)
    {
      CarImage imageDetails = new CarImage();

      var client = new Image.ImageService.ImageServiceClient(_channel);
      var details = await client.GetImageAsync(new GrpcInt { Value = modelId });
      imageDetails.Id = details.Id;
      imageDetails.ModelId = details.ModelId;
      imageDetails.ImageUrl = details.ImageUrl;

      return imageDetails;
    }

  }
}