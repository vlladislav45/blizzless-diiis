// Generated by ProtoGen, Version=2.4.1.473, Culture=neutral, PublicKeyToken=55f7125234beb589.  DO NOT EDIT!
#pragma warning disable 1591, 0612
#region Designer generated code

using pb = global::Google.ProtocolBuffers;
using pbc = global::Google.ProtocolBuffers.Collections;
using pbd = global::Google.ProtocolBuffers.Descriptors;
using scg = global::System.Collections.Generic;
namespace bgs.protocol.report.v1 {
  
  namespace Proto {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ProtoGen", "2.4.1.473")]
    public static partial class ReportService {
    
      #region Extension registration
      public static void RegisterAllExtensions(pb::ExtensionRegistry registry) {
      }
      #endregion
      #region Static variables
      internal static pbd::MessageDescriptor internal__static_bgs_protocol_report_v1_SendReportRequest__Descriptor;
      internal static pb::FieldAccess.FieldAccessorTable<global::bgs.protocol.report.v1.SendReportRequest, global::bgs.protocol.report.v1.SendReportRequest.Builder> internal__static_bgs_protocol_report_v1_SendReportRequest__FieldAccessorTable;
      internal static pbd::MessageDescriptor internal__static_bgs_protocol_report_v1_SubmitReportRequest__Descriptor;
      internal static pb::FieldAccess.FieldAccessorTable<global::bgs.protocol.report.v1.SubmitReportRequest, global::bgs.protocol.report.v1.SubmitReportRequest.Builder> internal__static_bgs_protocol_report_v1_SubmitReportRequest__FieldAccessorTable;
      #endregion
      #region Descriptor
      public static pbd::FileDescriptor Descriptor {
        get { return descriptor; }
      }
      private static pbd::FileDescriptor descriptor;
      
      static ReportService() {
        byte[] descriptorData = global::System.Convert.FromBase64String(
            "CiZiZ3MvbG93L3BiL2NsaWVudC9yZXBvcnRfc2VydmljZS5wcm90bxIWYmdz" + 
            "LnByb3RvY29sLnJlcG9ydC52MRolYmdzL2xvdy9wYi9jbGllbnQvYWNjb3Vu" + 
            "dF90eXBlcy5wcm90bxokYmdzL2xvdy9wYi9jbGllbnQvcmVwb3J0X3R5cGVz" + 
            "LnByb3RvGiFiZ3MvbG93L3BiL2NsaWVudC9ycGNfdHlwZXMucHJvdG8iSwoR" + 
            "U2VuZFJlcG9ydFJlcXVlc3QSNgoGcmVwb3J0GAEgAigLMh4uYmdzLnByb3Rv" + 
            "Y29sLnJlcG9ydC52MS5SZXBvcnRSBnJlcG9ydCKhAQoTU3VibWl0UmVwb3J0" + 
            "UmVxdWVzdBJFCghhZ2VudF9pZBgBIAEoCzIqLmJncy5wcm90b2NvbC5hY2Nv" + 
            "dW50LnYxLkdhbWVBY2NvdW50SGFuZGxlUgdhZ2VudElkEkMKC3JlcG9ydF90" + 
            "eXBlGAIgASgLMiIuYmdzLnByb3RvY29sLnJlcG9ydC52MS5SZXBvcnRUeXBl" + 
            "UgpyZXBvcnRUeXBlMvEBCg1SZXBvcnRTZXJ2aWNlElUKClNlbmRSZXBvcnQS" + 
            "KS5iZ3MucHJvdG9jb2wucmVwb3J0LnYxLlNlbmRSZXBvcnRSZXF1ZXN0GhQu" + 
            "YmdzLnByb3RvY29sLk5vRGF0YSIGgvkrAggBElkKDFN1Ym1pdFJlcG9ydBIr" + 
            "LmJncy5wcm90b2NvbC5yZXBvcnQudjEuU3VibWl0UmVwb3J0UmVxdWVzdBoU" + 
            "LmJncy5wcm90b2NvbC5Ob0RhdGEiBoL5KwIIAhougvkrJAoiYm5ldC5wcm90" + 
            "b2NvbC5yZXBvcnQuUmVwb3J0U2VydmljZYr5KwIQAUI1ChdibmV0LnByb3Rv" + 
            "Y29sLnJlcG9ydC52MUISUmVwb3J0U2VydmljZVByb3RvSAKAAQCIAQE=");
        pbd::FileDescriptor.InternalDescriptorAssigner assigner = delegate(pbd::FileDescriptor root) {
          descriptor = root;
          internal__static_bgs_protocol_report_v1_SendReportRequest__Descriptor = Descriptor.MessageTypes[0];
          internal__static_bgs_protocol_report_v1_SendReportRequest__FieldAccessorTable = 
              new pb::FieldAccess.FieldAccessorTable<global::bgs.protocol.report.v1.SendReportRequest, global::bgs.protocol.report.v1.SendReportRequest.Builder>(internal__static_bgs_protocol_report_v1_SendReportRequest__Descriptor,
                  new string[] { "Report", });
          internal__static_bgs_protocol_report_v1_SubmitReportRequest__Descriptor = Descriptor.MessageTypes[1];
          internal__static_bgs_protocol_report_v1_SubmitReportRequest__FieldAccessorTable = 
              new pb::FieldAccess.FieldAccessorTable<global::bgs.protocol.report.v1.SubmitReportRequest, global::bgs.protocol.report.v1.SubmitReportRequest.Builder>(internal__static_bgs_protocol_report_v1_SubmitReportRequest__Descriptor,
                  new string[] { "AgentId", "ReportType", });
          pb::ExtensionRegistry registry = pb::ExtensionRegistry.CreateInstance();
          RegisterAllExtensions(registry);
          global::bgs.protocol.account.v1.AccountTypes.RegisterAllExtensions(registry);
          global::bgs.protocol.report.v1.ReportTypes.RegisterAllExtensions(registry);
          global::bgs.protocol.RpcTypes.RegisterAllExtensions(registry);
          return registry;
        };
        pbd::FileDescriptor.InternalBuildGeneratedFileFrom(descriptorData,
            new pbd::FileDescriptor[] {
            global::bgs.protocol.account.v1.AccountTypes.Descriptor, 
            global::bgs.protocol.report.v1.ReportTypes.Descriptor, 
            global::bgs.protocol.RpcTypes.Descriptor, 
            }, assigner);
      }
      #endregion
      
    }
  }
  #region Messages
  
  [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
  [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ProtoGen", "2.4.1.473")]
  public sealed partial class SendReportRequest : pb::GeneratedMessage<SendReportRequest, SendReportRequest.Builder> {
    private SendReportRequest() { }
    private static readonly SendReportRequest defaultInstance = new SendReportRequest().MakeReadOnly();
    public static SendReportRequest DefaultInstance {
      get { return defaultInstance; }
    }
    
    public override SendReportRequest DefaultInstanceForType {
      get { return DefaultInstance; }
    }
    
    protected override SendReportRequest ThisMessage {
      get { return this; }
    }
    
    public static pbd::MessageDescriptor Descriptor {
      get { return global::bgs.protocol.report.v1.Proto.ReportService.internal__static_bgs_protocol_report_v1_SendReportRequest__Descriptor; }
    }
    
    protected override pb::FieldAccess.FieldAccessorTable<SendReportRequest, SendReportRequest.Builder> InternalFieldAccessors {
      get { return global::bgs.protocol.report.v1.Proto.ReportService.internal__static_bgs_protocol_report_v1_SendReportRequest__FieldAccessorTable; }
    }
    
    public const int ReportFieldNumber = 1;
    private bool hasReport;
    private global::bgs.protocol.report.v1.Report report_;
    public bool HasReport {
      get { return hasReport; }
    }
    public global::bgs.protocol.report.v1.Report Report {
      get { return report_ ?? global::bgs.protocol.report.v1.Report.DefaultInstance; }
    }
    
    public static SendReportRequest ParseFrom(pb::ByteString data) {
      return ((Builder) CreateBuilder().MergeFrom(data)).BuildParsed();
    }
    public static SendReportRequest ParseFrom(pb::ByteString data, pb::ExtensionRegistry extensionRegistry) {
      return ((Builder) CreateBuilder().MergeFrom(data, extensionRegistry)).BuildParsed();
    }
    public static SendReportRequest ParseFrom(byte[] data) {
      return ((Builder) CreateBuilder().MergeFrom(data)).BuildParsed();
    }
    public static SendReportRequest ParseFrom(byte[] data, pb::ExtensionRegistry extensionRegistry) {
      return ((Builder) CreateBuilder().MergeFrom(data, extensionRegistry)).BuildParsed();
    }
    public static SendReportRequest ParseFrom(global::System.IO.Stream input) {
      return ((Builder) CreateBuilder().MergeFrom(input)).BuildParsed();
    }
    public static SendReportRequest ParseFrom(global::System.IO.Stream input, pb::ExtensionRegistry extensionRegistry) {
      return ((Builder) CreateBuilder().MergeFrom(input, extensionRegistry)).BuildParsed();
    }
    public static SendReportRequest ParseDelimitedFrom(global::System.IO.Stream input) {
      return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
    }
    public static SendReportRequest ParseDelimitedFrom(global::System.IO.Stream input, pb::ExtensionRegistry extensionRegistry) {
      return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
    }
    public static SendReportRequest ParseFrom(pb::ICodedInputStream input) {
      return ((Builder) CreateBuilder().MergeFrom(input)).BuildParsed();
    }
    public static SendReportRequest ParseFrom(pb::ICodedInputStream input, pb::ExtensionRegistry extensionRegistry) {
      return ((Builder) CreateBuilder().MergeFrom(input, extensionRegistry)).BuildParsed();
    }
    private SendReportRequest MakeReadOnly() {
      return this;
    }
    
    public static Builder CreateBuilder() { return new Builder(); }
    public override Builder ToBuilder() { return CreateBuilder(this); }
    public override Builder CreateBuilderForType() { return new Builder(); }
    public static Builder CreateBuilder(SendReportRequest prototype) {
      return new Builder(prototype);
    }
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ProtoGen", "2.4.1.473")]
    public sealed partial class Builder : pb::GeneratedBuilder<SendReportRequest, Builder> {
      protected override Builder ThisBuilder {
        get { return this; }
      }
      public Builder() {
        result = DefaultInstance;
        resultIsReadOnly = true;
      }
      internal Builder(SendReportRequest cloneFrom) {
        result = cloneFrom;
        resultIsReadOnly = true;
      }
      
      private bool resultIsReadOnly;
      private SendReportRequest result;
      
      private SendReportRequest PrepareBuilder() {
        if (resultIsReadOnly) {
          SendReportRequest original = result;
          result = new SendReportRequest();
          resultIsReadOnly = false;
          MergeFrom(original);
        }
        return result;
      }
      
      public override bool IsInitialized {
        get { return result.IsInitialized; }
      }
      
      protected override SendReportRequest MessageBeingBuilt {
        get { return PrepareBuilder(); }
      }
      
      public override Builder Clear() {
        result = DefaultInstance;
        resultIsReadOnly = true;
        return this;
      }
      
      public override Builder Clone() {
        if (resultIsReadOnly) {
          return new Builder(result);
        } else {
          return new Builder().MergeFrom(result);
        }
      }
      
      public override pbd::MessageDescriptor DescriptorForType {
        get { return global::bgs.protocol.report.v1.SendReportRequest.Descriptor; }
      }
      
      public override SendReportRequest DefaultInstanceForType {
        get { return global::bgs.protocol.report.v1.SendReportRequest.DefaultInstance; }
      }
      
      public override SendReportRequest BuildPartial() {
        if (resultIsReadOnly) {
          return result;
        }
        resultIsReadOnly = true;
        return result.MakeReadOnly();
      }
      
      
      public bool HasReport {
       get { return result.hasReport; }
      }
      public global::bgs.protocol.report.v1.Report Report {
        get { return result.Report; }
        set { SetReport(value); }
      }
      public Builder SetReport(global::bgs.protocol.report.v1.Report value) {
        pb::ThrowHelper.ThrowIfNull(value, "value");
        PrepareBuilder();
        result.hasReport = true;
        result.report_ = value;
        return this;
      }
      public Builder SetReport(global::bgs.protocol.report.v1.Report.Builder builderForValue) {
        pb::ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
        PrepareBuilder();
        result.hasReport = true;
        result.report_ = builderForValue.Build();
        return this;
      }
      public Builder MergeReport(global::bgs.protocol.report.v1.Report value) {
        pb::ThrowHelper.ThrowIfNull(value, "value");
        PrepareBuilder();
        if (result.hasReport &&
            result.report_ != global::bgs.protocol.report.v1.Report.DefaultInstance) {
            result.report_ = global::bgs.protocol.report.v1.Report.CreateBuilder(result.report_).MergeFrom(value).BuildPartial();
        } else {
          result.report_ = value;
        }
        result.hasReport = true;
        return this;
      }
      public Builder ClearReport() {
        PrepareBuilder();
        result.hasReport = false;
        result.report_ = null;
        return this;
      }
    }
    static SendReportRequest() {
      object.ReferenceEquals(global::bgs.protocol.report.v1.Proto.ReportService.Descriptor, null);
    }
  }
  
  
  [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
  [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ProtoGen", "2.4.1.473")]
  public sealed partial class SubmitReportRequest : pb::GeneratedMessage<SubmitReportRequest, SubmitReportRequest.Builder> {
    private SubmitReportRequest() { }
    private static readonly SubmitReportRequest defaultInstance = new SubmitReportRequest().MakeReadOnly();
    public static SubmitReportRequest DefaultInstance {
      get { return defaultInstance; }
    }
    
    public override SubmitReportRequest DefaultInstanceForType {
      get { return DefaultInstance; }
    }
    
    protected override SubmitReportRequest ThisMessage {
      get { return this; }
    }
    
    public static pbd::MessageDescriptor Descriptor {
      get { return global::bgs.protocol.report.v1.Proto.ReportService.internal__static_bgs_protocol_report_v1_SubmitReportRequest__Descriptor; }
    }
    
    protected override pb::FieldAccess.FieldAccessorTable<SubmitReportRequest, SubmitReportRequest.Builder> InternalFieldAccessors {
      get { return global::bgs.protocol.report.v1.Proto.ReportService.internal__static_bgs_protocol_report_v1_SubmitReportRequest__FieldAccessorTable; }
    }
    
    public const int AgentIdFieldNumber = 1;
    private bool hasAgentId;
    private global::bgs.protocol.account.v1.GameAccountHandle agentId_;
    public bool HasAgentId {
      get { return hasAgentId; }
    }
    public global::bgs.protocol.account.v1.GameAccountHandle AgentId {
      get { return agentId_ ?? global::bgs.protocol.account.v1.GameAccountHandle.DefaultInstance; }
    }
    
    public const int ReportTypeFieldNumber = 2;
    private bool hasReportType;
    private global::bgs.protocol.report.v1.ReportType reportType_;
    public bool HasReportType {
      get { return hasReportType; }
    }
    public global::bgs.protocol.report.v1.ReportType ReportType {
      get { return reportType_ ?? global::bgs.protocol.report.v1.ReportType.DefaultInstance; }
    }
    
    public static SubmitReportRequest ParseFrom(pb::ByteString data) {
      return ((Builder) CreateBuilder().MergeFrom(data)).BuildParsed();
    }
    public static SubmitReportRequest ParseFrom(pb::ByteString data, pb::ExtensionRegistry extensionRegistry) {
      return ((Builder) CreateBuilder().MergeFrom(data, extensionRegistry)).BuildParsed();
    }
    public static SubmitReportRequest ParseFrom(byte[] data) {
      return ((Builder) CreateBuilder().MergeFrom(data)).BuildParsed();
    }
    public static SubmitReportRequest ParseFrom(byte[] data, pb::ExtensionRegistry extensionRegistry) {
      return ((Builder) CreateBuilder().MergeFrom(data, extensionRegistry)).BuildParsed();
    }
    public static SubmitReportRequest ParseFrom(global::System.IO.Stream input) {
      return ((Builder) CreateBuilder().MergeFrom(input)).BuildParsed();
    }
    public static SubmitReportRequest ParseFrom(global::System.IO.Stream input, pb::ExtensionRegistry extensionRegistry) {
      return ((Builder) CreateBuilder().MergeFrom(input, extensionRegistry)).BuildParsed();
    }
    public static SubmitReportRequest ParseDelimitedFrom(global::System.IO.Stream input) {
      return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
    }
    public static SubmitReportRequest ParseDelimitedFrom(global::System.IO.Stream input, pb::ExtensionRegistry extensionRegistry) {
      return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
    }
    public static SubmitReportRequest ParseFrom(pb::ICodedInputStream input) {
      return ((Builder) CreateBuilder().MergeFrom(input)).BuildParsed();
    }
    public static SubmitReportRequest ParseFrom(pb::ICodedInputStream input, pb::ExtensionRegistry extensionRegistry) {
      return ((Builder) CreateBuilder().MergeFrom(input, extensionRegistry)).BuildParsed();
    }
    private SubmitReportRequest MakeReadOnly() {
      return this;
    }
    
    public static Builder CreateBuilder() { return new Builder(); }
    public override Builder ToBuilder() { return CreateBuilder(this); }
    public override Builder CreateBuilderForType() { return new Builder(); }
    public static Builder CreateBuilder(SubmitReportRequest prototype) {
      return new Builder(prototype);
    }
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ProtoGen", "2.4.1.473")]
    public sealed partial class Builder : pb::GeneratedBuilder<SubmitReportRequest, Builder> {
      protected override Builder ThisBuilder {
        get { return this; }
      }
      public Builder() {
        result = DefaultInstance;
        resultIsReadOnly = true;
      }
      internal Builder(SubmitReportRequest cloneFrom) {
        result = cloneFrom;
        resultIsReadOnly = true;
      }
      
      private bool resultIsReadOnly;
      private SubmitReportRequest result;
      
      private SubmitReportRequest PrepareBuilder() {
        if (resultIsReadOnly) {
          SubmitReportRequest original = result;
          result = new SubmitReportRequest();
          resultIsReadOnly = false;
          MergeFrom(original);
        }
        return result;
      }
      
      public override bool IsInitialized {
        get { return result.IsInitialized; }
      }
      
      protected override SubmitReportRequest MessageBeingBuilt {
        get { return PrepareBuilder(); }
      }
      
      public override Builder Clear() {
        result = DefaultInstance;
        resultIsReadOnly = true;
        return this;
      }
      
      public override Builder Clone() {
        if (resultIsReadOnly) {
          return new Builder(result);
        } else {
          return new Builder().MergeFrom(result);
        }
      }
      
      public override pbd::MessageDescriptor DescriptorForType {
        get { return global::bgs.protocol.report.v1.SubmitReportRequest.Descriptor; }
      }
      
      public override SubmitReportRequest DefaultInstanceForType {
        get { return global::bgs.protocol.report.v1.SubmitReportRequest.DefaultInstance; }
      }
      
      public override SubmitReportRequest BuildPartial() {
        if (resultIsReadOnly) {
          return result;
        }
        resultIsReadOnly = true;
        return result.MakeReadOnly();
      }
      
      
      public bool HasAgentId {
       get { return result.hasAgentId; }
      }
      public global::bgs.protocol.account.v1.GameAccountHandle AgentId {
        get { return result.AgentId; }
        set { SetAgentId(value); }
      }
      public Builder SetAgentId(global::bgs.protocol.account.v1.GameAccountHandle value) {
        pb::ThrowHelper.ThrowIfNull(value, "value");
        PrepareBuilder();
        result.hasAgentId = true;
        result.agentId_ = value;
        return this;
      }
      public Builder SetAgentId(global::bgs.protocol.account.v1.GameAccountHandle.Builder builderForValue) {
        pb::ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
        PrepareBuilder();
        result.hasAgentId = true;
        result.agentId_ = builderForValue.Build();
        return this;
      }
      public Builder MergeAgentId(global::bgs.protocol.account.v1.GameAccountHandle value) {
        pb::ThrowHelper.ThrowIfNull(value, "value");
        PrepareBuilder();
        if (result.hasAgentId &&
            result.agentId_ != global::bgs.protocol.account.v1.GameAccountHandle.DefaultInstance) {
            result.agentId_ = global::bgs.protocol.account.v1.GameAccountHandle.CreateBuilder(result.agentId_).MergeFrom(value).BuildPartial();
        } else {
          result.agentId_ = value;
        }
        result.hasAgentId = true;
        return this;
      }
      public Builder ClearAgentId() {
        PrepareBuilder();
        result.hasAgentId = false;
        result.agentId_ = null;
        return this;
      }
      
      public bool HasReportType {
       get { return result.hasReportType; }
      }
      public global::bgs.protocol.report.v1.ReportType ReportType {
        get { return result.ReportType; }
        set { SetReportType(value); }
      }
      public Builder SetReportType(global::bgs.protocol.report.v1.ReportType value) {
        pb::ThrowHelper.ThrowIfNull(value, "value");
        PrepareBuilder();
        result.hasReportType = true;
        result.reportType_ = value;
        return this;
      }
      public Builder SetReportType(global::bgs.protocol.report.v1.ReportType.Builder builderForValue) {
        pb::ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
        PrepareBuilder();
        result.hasReportType = true;
        result.reportType_ = builderForValue.Build();
        return this;
      }
      public Builder MergeReportType(global::bgs.protocol.report.v1.ReportType value) {
        pb::ThrowHelper.ThrowIfNull(value, "value");
        PrepareBuilder();
        if (result.hasReportType &&
            result.reportType_ != global::bgs.protocol.report.v1.ReportType.DefaultInstance) {
            result.reportType_ = global::bgs.protocol.report.v1.ReportType.CreateBuilder(result.reportType_).MergeFrom(value).BuildPartial();
        } else {
          result.reportType_ = value;
        }
        result.hasReportType = true;
        return this;
      }
      public Builder ClearReportType() {
        PrepareBuilder();
        result.hasReportType = false;
        result.reportType_ = null;
        return this;
      }
    }
    static SubmitReportRequest() {
      object.ReferenceEquals(global::bgs.protocol.report.v1.Proto.ReportService.Descriptor, null);
    }
  }
  
  #endregion
  
  #region Services
  
  [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
  [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ProtoGen", "2.4.1.473")]
  public abstract class ReportService : pb::IService {
    public abstract void SendReport(
        pb::IRpcController controller,
        global::bgs.protocol.report.v1.SendReportRequest request,
        global::System.Action<global::bgs.protocol.NoData> done);
    public abstract void SubmitReport(
        pb::IRpcController controller,
        global::bgs.protocol.report.v1.SubmitReportRequest request,
        global::System.Action<global::bgs.protocol.NoData> done);
    
    public static pbd::ServiceDescriptor Descriptor {
      get { return Proto.ReportService.Descriptor.Services[0]; }
    }
    public pbd::ServiceDescriptor DescriptorForType {
      get { return Descriptor; }
    }
    
    public void CallMethod(
        pbd::MethodDescriptor method,
        pb::IRpcController controller,
        pb::IMessage request,
        global::System.Action<pb::IMessage> done) {
      if (method.Service != Descriptor) {
        throw new global::System.ArgumentException(
            "Service.CallMethod() given method descriptor for wrong service type.");
      }
      switch(method.Index) {
        case 0:
          this.SendReport(controller, (global::bgs.protocol.report.v1.SendReportRequest) request,
              pb::RpcUtil.SpecializeCallback<global::bgs.protocol.NoData>(
              done));
          return;
        case 1:
          this.SubmitReport(controller, (global::bgs.protocol.report.v1.SubmitReportRequest) request,
              pb::RpcUtil.SpecializeCallback<global::bgs.protocol.NoData>(
              done));
          return;
        default:
          throw new global::System.InvalidOperationException("Can't get here.");
      }
    }
    
    public pb::IMessage GetRequestPrototype(pbd::MethodDescriptor method) {
      if (method.Service != Descriptor) {
        throw new global::System.ArgumentException(
            "Service.GetRequestPrototype() given method descriptor for wrong service type.");
      }
      switch(method.Index) {
        case 0:
          return global::bgs.protocol.report.v1.SendReportRequest.DefaultInstance;
        case 1:
          return global::bgs.protocol.report.v1.SubmitReportRequest.DefaultInstance;
        default:
          throw new global::System.InvalidOperationException("Can't get here.");
      }
    }
    
    public pb::IMessage GetResponsePrototype(pbd::MethodDescriptor method) {
      if (method.Service != Descriptor) {
        throw new global::System.ArgumentException(
            "Service.GetResponsePrototype() given method descriptor for wrong service type.");
      }
      switch(method.Index) {
        case 0:
          return global::bgs.protocol.NoData.DefaultInstance;
        case 1:
          return global::bgs.protocol.NoData.DefaultInstance;
        default:
          throw new global::System.InvalidOperationException("Can't get here.");
      }
    }
    
    public static Stub CreateStub(pb::IRpcChannel channel) {
      return new Stub(channel);
    }
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ProtoGen", "2.4.1.473")]
    public class Stub : global::bgs.protocol.report.v1.ReportService {
      internal Stub(pb::IRpcChannel channel) {
        this.channel = channel;
      }
      
      private readonly pb::IRpcChannel channel;
      
      public pb::IRpcChannel Channel {
        get { return channel; }
      }
      
      public override void SendReport(
          pb::IRpcController controller,
          global::bgs.protocol.report.v1.SendReportRequest request,
          global::System.Action<global::bgs.protocol.NoData> done) {
        channel.CallMethod(Descriptor.Methods[0],
            controller, request, global::bgs.protocol.NoData.DefaultInstance,
            pb::RpcUtil.GeneralizeCallback<global::bgs.protocol.NoData, global::bgs.protocol.NoData.Builder>(done, global::bgs.protocol.NoData.DefaultInstance));
      }
      
      public override void SubmitReport(
          pb::IRpcController controller,
          global::bgs.protocol.report.v1.SubmitReportRequest request,
          global::System.Action<global::bgs.protocol.NoData> done) {
        channel.CallMethod(Descriptor.Methods[1],
            controller, request, global::bgs.protocol.NoData.DefaultInstance,
            pb::RpcUtil.GeneralizeCallback<global::bgs.protocol.NoData, global::bgs.protocol.NoData.Builder>(done, global::bgs.protocol.NoData.DefaultInstance));
      }
    }
  }
  #endregion
  
}

#endregion Designer generated code
