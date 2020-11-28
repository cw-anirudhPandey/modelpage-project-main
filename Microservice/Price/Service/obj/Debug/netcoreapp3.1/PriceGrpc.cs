// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Price.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace Price.Service.ProtoClass {
  public static partial class PriceService
  {
    static readonly string __ServiceName = "Price.PriceService";

    static readonly grpc::Marshaller<global::Price.Service.ProtoClass.HelloRequest> __Marshaller_Price_HelloRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Price.Service.ProtoClass.HelloRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Price.Service.ProtoClass.HelloReply> __Marshaller_Price_HelloReply = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Price.Service.ProtoClass.HelloReply.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Price.Service.ProtoClass.GrpcInt> __Marshaller_Price_GrpcInt = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Price.Service.ProtoClass.GrpcInt.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Price.Service.ProtoClass.PriceListResponse> __Marshaller_Price_PriceListResponse = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Price.Service.ProtoClass.PriceListResponse.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Price.Service.ProtoClass.GrpcString> __Marshaller_Price_GrpcString = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Price.Service.ProtoClass.GrpcString.Parser.ParseFrom);

    static readonly grpc::Method<global::Price.Service.ProtoClass.HelloRequest, global::Price.Service.ProtoClass.HelloReply> __Method_SayHello = new grpc::Method<global::Price.Service.ProtoClass.HelloRequest, global::Price.Service.ProtoClass.HelloReply>(
        grpc::MethodType.Unary,
        __ServiceName,
        "SayHello",
        __Marshaller_Price_HelloRequest,
        __Marshaller_Price_HelloReply);

    static readonly grpc::Method<global::Price.Service.ProtoClass.GrpcInt, global::Price.Service.ProtoClass.PriceListResponse> __Method_GetPriceListByCityId = new grpc::Method<global::Price.Service.ProtoClass.GrpcInt, global::Price.Service.ProtoClass.PriceListResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetPriceListByCityId",
        __Marshaller_Price_GrpcInt,
        __Marshaller_Price_PriceListResponse);

    static readonly grpc::Method<global::Price.Service.ProtoClass.GrpcInt, global::Price.Service.ProtoClass.GrpcString> __Method_GetAvgPriceByVersionId = new grpc::Method<global::Price.Service.ProtoClass.GrpcInt, global::Price.Service.ProtoClass.GrpcString>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetAvgPriceByVersionId",
        __Marshaller_Price_GrpcInt,
        __Marshaller_Price_GrpcString);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::Price.Service.ProtoClass.PriceReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of PriceService</summary>
    [grpc::BindServiceMethod(typeof(PriceService), "BindService")]
    public abstract partial class PriceServiceBase
    {
      /// <summary>
      /// Sends a greeting
      /// </summary>
      /// <param name="request">The request received from the client.</param>
      /// <param name="context">The context of the server-side call handler being invoked.</param>
      /// <returns>The response to send back to the client (wrapped by a task).</returns>
      public virtual global::System.Threading.Tasks.Task<global::Price.Service.ProtoClass.HelloReply> SayHello(global::Price.Service.ProtoClass.HelloRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::Price.Service.ProtoClass.PriceListResponse> GetPriceListByCityId(global::Price.Service.ProtoClass.GrpcInt request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::Price.Service.ProtoClass.GrpcString> GetAvgPriceByVersionId(global::Price.Service.ProtoClass.GrpcInt request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(PriceServiceBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_SayHello, serviceImpl.SayHello)
          .AddMethod(__Method_GetPriceListByCityId, serviceImpl.GetPriceListByCityId)
          .AddMethod(__Method_GetAvgPriceByVersionId, serviceImpl.GetAvgPriceByVersionId).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static void BindService(grpc::ServiceBinderBase serviceBinder, PriceServiceBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_SayHello, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Price.Service.ProtoClass.HelloRequest, global::Price.Service.ProtoClass.HelloReply>(serviceImpl.SayHello));
      serviceBinder.AddMethod(__Method_GetPriceListByCityId, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Price.Service.ProtoClass.GrpcInt, global::Price.Service.ProtoClass.PriceListResponse>(serviceImpl.GetPriceListByCityId));
      serviceBinder.AddMethod(__Method_GetAvgPriceByVersionId, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Price.Service.ProtoClass.GrpcInt, global::Price.Service.ProtoClass.GrpcString>(serviceImpl.GetAvgPriceByVersionId));
    }

  }
}
#endregion
