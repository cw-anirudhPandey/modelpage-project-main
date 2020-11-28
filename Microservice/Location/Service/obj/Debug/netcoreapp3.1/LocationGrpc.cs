// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Location.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace Location.Service.ProtoClass {
  public static partial class LocationService
  {
    static readonly string __ServiceName = "Location.LocationService";

    static readonly grpc::Marshaller<global::Location.Service.ProtoClass.HelloRequest> __Marshaller_Location_HelloRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Location.Service.ProtoClass.HelloRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Location.Service.ProtoClass.HelloReply> __Marshaller_Location_HelloReply = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Location.Service.ProtoClass.HelloReply.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Location.Service.ProtoClass.EmptyParam> __Marshaller_Location_EmptyParam = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Location.Service.ProtoClass.EmptyParam.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Location.Service.ProtoClass.CityListResponse> __Marshaller_Location_CityListResponse = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Location.Service.ProtoClass.CityListResponse.Parser.ParseFrom);

    static readonly grpc::Method<global::Location.Service.ProtoClass.HelloRequest, global::Location.Service.ProtoClass.HelloReply> __Method_SayHello = new grpc::Method<global::Location.Service.ProtoClass.HelloRequest, global::Location.Service.ProtoClass.HelloReply>(
        grpc::MethodType.Unary,
        __ServiceName,
        "SayHello",
        __Marshaller_Location_HelloRequest,
        __Marshaller_Location_HelloReply);

    static readonly grpc::Method<global::Location.Service.ProtoClass.EmptyParam, global::Location.Service.ProtoClass.CityListResponse> __Method_GetAllCities = new grpc::Method<global::Location.Service.ProtoClass.EmptyParam, global::Location.Service.ProtoClass.CityListResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetAllCities",
        __Marshaller_Location_EmptyParam,
        __Marshaller_Location_CityListResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::Location.Service.ProtoClass.LocationReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of LocationService</summary>
    [grpc::BindServiceMethod(typeof(LocationService), "BindService")]
    public abstract partial class LocationServiceBase
    {
      /// <summary>
      /// Sends a greeting
      /// </summary>
      /// <param name="request">The request received from the client.</param>
      /// <param name="context">The context of the server-side call handler being invoked.</param>
      /// <returns>The response to send back to the client (wrapped by a task).</returns>
      public virtual global::System.Threading.Tasks.Task<global::Location.Service.ProtoClass.HelloReply> SayHello(global::Location.Service.ProtoClass.HelloRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::Location.Service.ProtoClass.CityListResponse> GetAllCities(global::Location.Service.ProtoClass.EmptyParam request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(LocationServiceBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_SayHello, serviceImpl.SayHello)
          .AddMethod(__Method_GetAllCities, serviceImpl.GetAllCities).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static void BindService(grpc::ServiceBinderBase serviceBinder, LocationServiceBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_SayHello, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Location.Service.ProtoClass.HelloRequest, global::Location.Service.ProtoClass.HelloReply>(serviceImpl.SayHello));
      serviceBinder.AddMethod(__Method_GetAllCities, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Location.Service.ProtoClass.EmptyParam, global::Location.Service.ProtoClass.CityListResponse>(serviceImpl.GetAllCities));
    }

  }
}
#endregion