// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Image.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace Image.Service.ProtoClass {
  public static partial class ImageService
  {
    static readonly string __ServiceName = "Image.ImageService";

    static readonly grpc::Marshaller<global::Image.Service.ProtoClass.GrpcInt> __Marshaller_Image_GrpcInt = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Image.Service.ProtoClass.GrpcInt.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Image.Service.ProtoClass.ImageResponse> __Marshaller_Image_ImageResponse = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Image.Service.ProtoClass.ImageResponse.Parser.ParseFrom);

    static readonly grpc::Method<global::Image.Service.ProtoClass.GrpcInt, global::Image.Service.ProtoClass.ImageResponse> __Method_GetImage = new grpc::Method<global::Image.Service.ProtoClass.GrpcInt, global::Image.Service.ProtoClass.ImageResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetImage",
        __Marshaller_Image_GrpcInt,
        __Marshaller_Image_ImageResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::Image.Service.ProtoClass.ImageReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of ImageService</summary>
    [grpc::BindServiceMethod(typeof(ImageService), "BindService")]
    public abstract partial class ImageServiceBase
    {
      public virtual global::System.Threading.Tasks.Task<global::Image.Service.ProtoClass.ImageResponse> GetImage(global::Image.Service.ProtoClass.GrpcInt request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(ImageServiceBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_GetImage, serviceImpl.GetImage).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static void BindService(grpc::ServiceBinderBase serviceBinder, ImageServiceBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_GetImage, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Image.Service.ProtoClass.GrpcInt, global::Image.Service.ProtoClass.ImageResponse>(serviceImpl.GetImage));
    }

  }
}
#endregion
