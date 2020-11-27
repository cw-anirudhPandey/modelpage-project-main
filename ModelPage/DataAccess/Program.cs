using System;
using Grpc.Net.Client;
using GrpcModelPage;

namespace DataAccess
{
  class Program
  {
    static void Main(string[] args)
    {
      using var channel = GrpcChannel.ForAddress("https://localhost:5001");
      var client = new Greeter.GreeterClient(channel);
      // var reply = client.SayHello(
      //   new HelloRequest { Name = "Anirudh" }
      // );
      GrpcInt makeId = new GrpcInt { Value = 0 };
      GrpcInt modelId = new GrpcInt { Value = 4 };
      var reply = client.GetMakeAsync(makeId);
      Console.WriteLine(reply);
      var reply3 = client.GetModelAsync(modelId);
      Console.WriteLine(reply3);
      var reply4 = client.GetImageAsync(modelId);
      Console.WriteLine(reply4);
      var reply5 = client.GetReviewAsync(modelId);
      Console.WriteLine(reply5);
      var reply6 = client.GetEmiAsync(modelId);
      Console.WriteLine(reply6);
      var reply7 = client.GetPriceDetailsAsync(modelId);
      Console.WriteLine(reply7);
    }
  }
}
