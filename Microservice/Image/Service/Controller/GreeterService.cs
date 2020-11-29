using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Image.Service.ProtoClass;
using Image.Business;
using Microsoft.Extensions.Logging;
using Image.Entities;
using Image.Business.Interfaces;

namespace Image.Service.Controller
{
  public class ImageService : Image.Service.ProtoClass.ImageService.ImageServiceBase
  {
    private readonly IImageLogic _imageLogic;
    public ImageService(IImageLogic imageLogic)
    {
      _imageLogic = imageLogic;
    }

    public override async Task<ImageResponse> GetImage(GrpcInt request, ServerCallContext context)
    {
      ImageResponse result = new ImageResponse();
      var imageDetails = await _imageLogic.GetImage(request.Value);
      if (imageDetails != null)
      {
        result.Id = imageDetails.Id;
        result.ModelId = imageDetails.ModelId;
        result.ImageUrl = imageDetails.ImageUrl;
      }
      return result;
    }

  }
}
