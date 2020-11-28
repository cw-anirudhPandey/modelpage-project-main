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
    private readonly ILogger<ImageService> _logger;
    private readonly IImageLogic _imageLogic;
    public ImageService(ILogger<ImageService> logger, IImageLogic imageLogic)
    {
      _logger = logger;
      _imageLogic = imageLogic;
    }

    public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
    {
      return Task.FromResult(new HelloReply
      {
        Message = "Hello " + request.Name
      });
    }

    public override async Task<ImageResponse> GetImage(GrpcInt request, ServerCallContext context)
    {
      var imageDetails = await _imageLogic.GetImage(request.Value);
      return new ImageResponse
      {
        Id = imageDetails.Id,
        ModelId = imageDetails.ModelId,
        ImageUrl = imageDetails.ImageUrl
      };
    }

  }
}
