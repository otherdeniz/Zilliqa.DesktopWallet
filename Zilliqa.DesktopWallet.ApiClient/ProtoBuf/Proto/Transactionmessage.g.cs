// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: transactionmessage.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace MusZilCore.Proto {

  /// <summary>Holder for reflection information generated from transactionmessage.proto</summary>
  public static partial class TransactionmessageReflection {

    #region Descriptor
    /// <summary>File descriptor for transactionmessage.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static TransactionmessageReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "Chh0cmFuc2FjdGlvbm1lc3NhZ2UucHJvdG8SEU11c1ppbF9Db3JlLlByb3Rv",
            "IhkKCUJ5dGVBcnJheRIMCgRkYXRhGAEgASgMIoYCChRQcm90b1RyYW5zYWN0",
            "aW9uSW5mbxIPCgd2ZXJzaW9uGAEgASgNEg0KBW5vbmNlGAIgASgEEg4KBnRv",
            "YWRkchgDIAEoDBIyCgxzZW5kZXJwdWJrZXkYBCABKAsyHC5NdXNaaWxfQ29y",
            "ZS5Qcm90by5CeXRlQXJyYXkSLAoGYW1vdW50GAUgASgLMhwuTXVzWmlsX0Nv",
            "cmUuUHJvdG8uQnl0ZUFycmF5Ei4KCGdhc3ByaWNlGAYgASgLMhwuTXVzWmls",
            "X0NvcmUuUHJvdG8uQnl0ZUFycmF5EhAKCGdhc2xpbWl0GAcgASgEEgwKBGNv",
            "ZGUYCCABKAwSDAoEZGF0YRgJIAEoDCKKAQoQUHJvdG9UcmFuc2FjdGlvbhIO",
            "CgZ0cmFuaWQYASABKAwSNQoEaW5mbxgCIAEoCzInLk11c1ppbF9Db3JlLlBy",
            "b3RvLlByb3RvVHJhbnNhY3Rpb25JbmZvEi8KCXNpZ25hdHVyZRgDIAEoCzIc",
            "Lk11c1ppbF9Db3JlLlByb3RvLkJ5dGVBcnJheSI6ChdQcm90b1RyYW5zYWN0",
            "aW9uUmVjZWlwdBIPCgdyZWNlaXB0GAEgASgMEg4KBmN1bWdhcxgCIAEoBCKU",
            "AQobUHJvdG9UcmFuc2FjdGlvbldpdGhSZWNlaXB0EjgKC3RyYW5zYWN0aW9u",
            "GAEgASgLMiMuTXVzWmlsX0NvcmUuUHJvdG8uUHJvdG9UcmFuc2FjdGlvbhI7",
            "CgdyZWNlaXB0GAIgASgLMiouTXVzWmlsX0NvcmUuUHJvdG8uUHJvdG9UcmFu",
            "c2FjdGlvblJlY2VpcHRiBnByb3RvMw=="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::MusZilCore.Proto.ByteArray), global::MusZilCore.Proto.ByteArray.Parser, new[]{ "Data" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::MusZilCore.Proto.ProtoTransactionInfo), global::MusZilCore.Proto.ProtoTransactionInfo.Parser, new[]{ "Version", "Nonce", "Toaddr", "Senderpubkey", "Amount", "Gasprice", "Gaslimit", "Code", "Data" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::MusZilCore.Proto.ProtoTransaction), global::MusZilCore.Proto.ProtoTransaction.Parser, new[]{ "Tranid", "Info", "Signature" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::MusZilCore.Proto.ProtoTransactionReceipt), global::MusZilCore.Proto.ProtoTransactionReceipt.Parser, new[]{ "Receipt", "Cumgas" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::MusZilCore.Proto.ProtoTransactionWithReceipt), global::MusZilCore.Proto.ProtoTransactionWithReceipt.Parser, new[]{ "Transaction", "Receipt" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class ByteArray : pb::IMessage<ByteArray> {
    private static readonly pb::MessageParser<ByteArray> _parser = new pb::MessageParser<ByteArray>(() => new ByteArray());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<ByteArray> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::MusZilCore.Proto.TransactionmessageReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ByteArray() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ByteArray(ByteArray other) : this() {
      data_ = other.data_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ByteArray Clone() {
      return new ByteArray(this);
    }

    /// <summary>Field number for the "data" field.</summary>
    public const int DataFieldNumber = 1;
    private pb::ByteString data_ = pb::ByteString.Empty;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pb::ByteString Data {
      get { return data_; }
      set {
        data_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as ByteArray);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(ByteArray other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Data != other.Data) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Data.Length != 0) hash ^= Data.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Data.Length != 0) {
        output.WriteRawTag(10);
        output.WriteBytes(Data);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Data.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeBytesSize(Data);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(ByteArray other) {
      if (other == null) {
        return;
      }
      if (other.Data.Length != 0) {
        Data = other.Data;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            Data = input.ReadBytes();
            break;
          }
        }
      }
    }

  }

  public sealed partial class ProtoTransactionInfo : pb::IMessage<ProtoTransactionInfo> {
    private static readonly pb::MessageParser<ProtoTransactionInfo> _parser = new pb::MessageParser<ProtoTransactionInfo>(() => new ProtoTransactionInfo());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<ProtoTransactionInfo> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::MusZilCore.Proto.TransactionmessageReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ProtoTransactionInfo() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ProtoTransactionInfo(ProtoTransactionInfo other) : this() {
      version_ = other.version_;
      nonce_ = other.nonce_;
      toaddr_ = other.toaddr_;
      senderpubkey_ = other.senderpubkey_ != null ? other.senderpubkey_.Clone() : null;
      amount_ = other.amount_ != null ? other.amount_.Clone() : null;
      gasprice_ = other.gasprice_ != null ? other.gasprice_.Clone() : null;
      gaslimit_ = other.gaslimit_;
      code_ = other.code_;
      data_ = other.data_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ProtoTransactionInfo Clone() {
      return new ProtoTransactionInfo(this);
    }

    /// <summary>Field number for the "version" field.</summary>
    public const int VersionFieldNumber = 1;
    private uint version_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public uint Version {
      get { return version_; }
      set {
        version_ = value;
      }
    }

    /// <summary>Field number for the "nonce" field.</summary>
    public const int NonceFieldNumber = 2;
    private ulong nonce_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ulong Nonce {
      get { return nonce_; }
      set {
        nonce_ = value;
      }
    }

    /// <summary>Field number for the "toaddr" field.</summary>
    public const int ToaddrFieldNumber = 3;
    private pb::ByteString toaddr_ = pb::ByteString.Empty;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pb::ByteString Toaddr {
      get { return toaddr_; }
      set {
        toaddr_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "senderpubkey" field.</summary>
    public const int SenderpubkeyFieldNumber = 4;
    private global::MusZilCore.Proto.ByteArray senderpubkey_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::MusZilCore.Proto.ByteArray Senderpubkey {
      get { return senderpubkey_; }
      set {
        senderpubkey_ = value;
      }
    }

    /// <summary>Field number for the "amount" field.</summary>
    public const int AmountFieldNumber = 5;
    private global::MusZilCore.Proto.ByteArray amount_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::MusZilCore.Proto.ByteArray Amount {
      get { return amount_; }
      set {
        amount_ = value;
      }
    }

    /// <summary>Field number for the "gasprice" field.</summary>
    public const int GaspriceFieldNumber = 6;
    private global::MusZilCore.Proto.ByteArray gasprice_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::MusZilCore.Proto.ByteArray Gasprice {
      get { return gasprice_; }
      set {
        gasprice_ = value;
      }
    }

    /// <summary>Field number for the "gaslimit" field.</summary>
    public const int GaslimitFieldNumber = 7;
    private ulong gaslimit_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ulong Gaslimit {
      get { return gaslimit_; }
      set {
        gaslimit_ = value;
      }
    }

    /// <summary>Field number for the "code" field.</summary>
    public const int CodeFieldNumber = 8;
    private pb::ByteString code_ = pb::ByteString.Empty;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pb::ByteString Code {
      get { return code_; }
      set {
        code_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "data" field.</summary>
    public const int DataFieldNumber = 9;
    private pb::ByteString data_ = pb::ByteString.Empty;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pb::ByteString Data {
      get { return data_; }
      set {
        data_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as ProtoTransactionInfo);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(ProtoTransactionInfo other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Version != other.Version) return false;
      if (Nonce != other.Nonce) return false;
      if (Toaddr != other.Toaddr) return false;
      if (!object.Equals(Senderpubkey, other.Senderpubkey)) return false;
      if (!object.Equals(Amount, other.Amount)) return false;
      if (!object.Equals(Gasprice, other.Gasprice)) return false;
      if (Gaslimit != other.Gaslimit) return false;
      if (Code != other.Code) return false;
      if (Data != other.Data) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Version != 0) hash ^= Version.GetHashCode();
      if (Nonce != 0UL) hash ^= Nonce.GetHashCode();
      if (Toaddr.Length != 0) hash ^= Toaddr.GetHashCode();
      if (senderpubkey_ != null) hash ^= Senderpubkey.GetHashCode();
      if (amount_ != null) hash ^= Amount.GetHashCode();
      if (gasprice_ != null) hash ^= Gasprice.GetHashCode();
      if (Gaslimit != 0UL) hash ^= Gaslimit.GetHashCode();
      if (Code.Length != 0) hash ^= Code.GetHashCode();
      if (Data.Length != 0) hash ^= Data.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Version != 0) {
        output.WriteRawTag(8);
        output.WriteUInt32(Version);
      }
      if (Nonce != 0UL) {
        output.WriteRawTag(16);
        output.WriteUInt64(Nonce);
      }
      if (Toaddr.Length != 0) {
        output.WriteRawTag(26);
        output.WriteBytes(Toaddr);
      }
      if (senderpubkey_ != null) {
        output.WriteRawTag(34);
        output.WriteMessage(Senderpubkey);
      }
      if (amount_ != null) {
        output.WriteRawTag(42);
        output.WriteMessage(Amount);
      }
      if (gasprice_ != null) {
        output.WriteRawTag(50);
        output.WriteMessage(Gasprice);
      }
      if (Gaslimit != 0UL) {
        output.WriteRawTag(56);
        output.WriteUInt64(Gaslimit);
      }
      if (Code.Length != 0) {
        output.WriteRawTag(66);
        output.WriteBytes(Code);
      }
      if (Data.Length != 0) {
        output.WriteRawTag(74);
        output.WriteBytes(Data);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Version != 0) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(Version);
      }
      if (Nonce != 0UL) {
        size += 1 + pb::CodedOutputStream.ComputeUInt64Size(Nonce);
      }
      if (Toaddr.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeBytesSize(Toaddr);
      }
      if (senderpubkey_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Senderpubkey);
      }
      if (amount_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Amount);
      }
      if (gasprice_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Gasprice);
      }
      if (Gaslimit != 0UL) {
        size += 1 + pb::CodedOutputStream.ComputeUInt64Size(Gaslimit);
      }
      if (Code.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeBytesSize(Code);
      }
      if (Data.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeBytesSize(Data);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(ProtoTransactionInfo other) {
      if (other == null) {
        return;
      }
      if (other.Version != 0) {
        Version = other.Version;
      }
      if (other.Nonce != 0UL) {
        Nonce = other.Nonce;
      }
      if (other.Toaddr.Length != 0) {
        Toaddr = other.Toaddr;
      }
      if (other.senderpubkey_ != null) {
        if (senderpubkey_ == null) {
          Senderpubkey = new global::MusZilCore.Proto.ByteArray();
        }
        Senderpubkey.MergeFrom(other.Senderpubkey);
      }
      if (other.amount_ != null) {
        if (amount_ == null) {
          Amount = new global::MusZilCore.Proto.ByteArray();
        }
        Amount.MergeFrom(other.Amount);
      }
      if (other.gasprice_ != null) {
        if (gasprice_ == null) {
          Gasprice = new global::MusZilCore.Proto.ByteArray();
        }
        Gasprice.MergeFrom(other.Gasprice);
      }
      if (other.Gaslimit != 0UL) {
        Gaslimit = other.Gaslimit;
      }
      if (other.Code.Length != 0) {
        Code = other.Code;
      }
      if (other.Data.Length != 0) {
        Data = other.Data;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 8: {
            Version = input.ReadUInt32();
            break;
          }
          case 16: {
            Nonce = input.ReadUInt64();
            break;
          }
          case 26: {
            Toaddr = input.ReadBytes();
            break;
          }
          case 34: {
            if (senderpubkey_ == null) {
              Senderpubkey = new global::MusZilCore.Proto.ByteArray();
            }
            input.ReadMessage(Senderpubkey);
            break;
          }
          case 42: {
            if (amount_ == null) {
              Amount = new global::MusZilCore.Proto.ByteArray();
            }
            input.ReadMessage(Amount);
            break;
          }
          case 50: {
            if (gasprice_ == null) {
              Gasprice = new global::MusZilCore.Proto.ByteArray();
            }
            input.ReadMessage(Gasprice);
            break;
          }
          case 56: {
            Gaslimit = input.ReadUInt64();
            break;
          }
          case 66: {
            Code = input.ReadBytes();
            break;
          }
          case 74: {
            Data = input.ReadBytes();
            break;
          }
        }
      }
    }

  }

  public sealed partial class ProtoTransaction : pb::IMessage<ProtoTransaction> {
    private static readonly pb::MessageParser<ProtoTransaction> _parser = new pb::MessageParser<ProtoTransaction>(() => new ProtoTransaction());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<ProtoTransaction> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::MusZilCore.Proto.TransactionmessageReflection.Descriptor.MessageTypes[2]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ProtoTransaction() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ProtoTransaction(ProtoTransaction other) : this() {
      tranid_ = other.tranid_;
      info_ = other.info_ != null ? other.info_.Clone() : null;
      signature_ = other.signature_ != null ? other.signature_.Clone() : null;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ProtoTransaction Clone() {
      return new ProtoTransaction(this);
    }

    /// <summary>Field number for the "tranid" field.</summary>
    public const int TranidFieldNumber = 1;
    private pb::ByteString tranid_ = pb::ByteString.Empty;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pb::ByteString Tranid {
      get { return tranid_; }
      set {
        tranid_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "info" field.</summary>
    public const int InfoFieldNumber = 2;
    private global::MusZilCore.Proto.ProtoTransactionInfo info_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::MusZilCore.Proto.ProtoTransactionInfo Info {
      get { return info_; }
      set {
        info_ = value;
      }
    }

    /// <summary>Field number for the "signature" field.</summary>
    public const int SignatureFieldNumber = 3;
    private global::MusZilCore.Proto.ByteArray signature_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::MusZilCore.Proto.ByteArray Signature {
      get { return signature_; }
      set {
        signature_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as ProtoTransaction);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(ProtoTransaction other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Tranid != other.Tranid) return false;
      if (!object.Equals(Info, other.Info)) return false;
      if (!object.Equals(Signature, other.Signature)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Tranid.Length != 0) hash ^= Tranid.GetHashCode();
      if (info_ != null) hash ^= Info.GetHashCode();
      if (signature_ != null) hash ^= Signature.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Tranid.Length != 0) {
        output.WriteRawTag(10);
        output.WriteBytes(Tranid);
      }
      if (info_ != null) {
        output.WriteRawTag(18);
        output.WriteMessage(Info);
      }
      if (signature_ != null) {
        output.WriteRawTag(26);
        output.WriteMessage(Signature);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Tranid.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeBytesSize(Tranid);
      }
      if (info_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Info);
      }
      if (signature_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Signature);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(ProtoTransaction other) {
      if (other == null) {
        return;
      }
      if (other.Tranid.Length != 0) {
        Tranid = other.Tranid;
      }
      if (other.info_ != null) {
        if (info_ == null) {
          Info = new global::MusZilCore.Proto.ProtoTransactionInfo();
        }
        Info.MergeFrom(other.Info);
      }
      if (other.signature_ != null) {
        if (signature_ == null) {
          Signature = new global::MusZilCore.Proto.ByteArray();
        }
        Signature.MergeFrom(other.Signature);
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            Tranid = input.ReadBytes();
            break;
          }
          case 18: {
            if (info_ == null) {
              Info = new global::MusZilCore.Proto.ProtoTransactionInfo();
            }
            input.ReadMessage(Info);
            break;
          }
          case 26: {
            if (signature_ == null) {
              Signature = new global::MusZilCore.Proto.ByteArray();
            }
            input.ReadMessage(Signature);
            break;
          }
        }
      }
    }

  }

  public sealed partial class ProtoTransactionReceipt : pb::IMessage<ProtoTransactionReceipt> {
    private static readonly pb::MessageParser<ProtoTransactionReceipt> _parser = new pb::MessageParser<ProtoTransactionReceipt>(() => new ProtoTransactionReceipt());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<ProtoTransactionReceipt> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::MusZilCore.Proto.TransactionmessageReflection.Descriptor.MessageTypes[3]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ProtoTransactionReceipt() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ProtoTransactionReceipt(ProtoTransactionReceipt other) : this() {
      receipt_ = other.receipt_;
      cumgas_ = other.cumgas_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ProtoTransactionReceipt Clone() {
      return new ProtoTransactionReceipt(this);
    }

    /// <summary>Field number for the "receipt" field.</summary>
    public const int ReceiptFieldNumber = 1;
    private pb::ByteString receipt_ = pb::ByteString.Empty;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pb::ByteString Receipt {
      get { return receipt_; }
      set {
        receipt_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "cumgas" field.</summary>
    public const int CumgasFieldNumber = 2;
    private ulong cumgas_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ulong Cumgas {
      get { return cumgas_; }
      set {
        cumgas_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as ProtoTransactionReceipt);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(ProtoTransactionReceipt other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Receipt != other.Receipt) return false;
      if (Cumgas != other.Cumgas) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Receipt.Length != 0) hash ^= Receipt.GetHashCode();
      if (Cumgas != 0UL) hash ^= Cumgas.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Receipt.Length != 0) {
        output.WriteRawTag(10);
        output.WriteBytes(Receipt);
      }
      if (Cumgas != 0UL) {
        output.WriteRawTag(16);
        output.WriteUInt64(Cumgas);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Receipt.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeBytesSize(Receipt);
      }
      if (Cumgas != 0UL) {
        size += 1 + pb::CodedOutputStream.ComputeUInt64Size(Cumgas);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(ProtoTransactionReceipt other) {
      if (other == null) {
        return;
      }
      if (other.Receipt.Length != 0) {
        Receipt = other.Receipt;
      }
      if (other.Cumgas != 0UL) {
        Cumgas = other.Cumgas;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            Receipt = input.ReadBytes();
            break;
          }
          case 16: {
            Cumgas = input.ReadUInt64();
            break;
          }
        }
      }
    }

  }

  public sealed partial class ProtoTransactionWithReceipt : pb::IMessage<ProtoTransactionWithReceipt> {
    private static readonly pb::MessageParser<ProtoTransactionWithReceipt> _parser = new pb::MessageParser<ProtoTransactionWithReceipt>(() => new ProtoTransactionWithReceipt());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<ProtoTransactionWithReceipt> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::MusZilCore.Proto.TransactionmessageReflection.Descriptor.MessageTypes[4]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ProtoTransactionWithReceipt() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ProtoTransactionWithReceipt(ProtoTransactionWithReceipt other) : this() {
      transaction_ = other.transaction_ != null ? other.transaction_.Clone() : null;
      receipt_ = other.receipt_ != null ? other.receipt_.Clone() : null;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ProtoTransactionWithReceipt Clone() {
      return new ProtoTransactionWithReceipt(this);
    }

    /// <summary>Field number for the "transaction" field.</summary>
    public const int TransactionFieldNumber = 1;
    private global::MusZilCore.Proto.ProtoTransaction transaction_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::MusZilCore.Proto.ProtoTransaction Transaction {
      get { return transaction_; }
      set {
        transaction_ = value;
      }
    }

    /// <summary>Field number for the "receipt" field.</summary>
    public const int ReceiptFieldNumber = 2;
    private global::MusZilCore.Proto.ProtoTransactionReceipt receipt_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::MusZilCore.Proto.ProtoTransactionReceipt Receipt {
      get { return receipt_; }
      set {
        receipt_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as ProtoTransactionWithReceipt);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(ProtoTransactionWithReceipt other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (!object.Equals(Transaction, other.Transaction)) return false;
      if (!object.Equals(Receipt, other.Receipt)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (transaction_ != null) hash ^= Transaction.GetHashCode();
      if (receipt_ != null) hash ^= Receipt.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (transaction_ != null) {
        output.WriteRawTag(10);
        output.WriteMessage(Transaction);
      }
      if (receipt_ != null) {
        output.WriteRawTag(18);
        output.WriteMessage(Receipt);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (transaction_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Transaction);
      }
      if (receipt_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Receipt);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(ProtoTransactionWithReceipt other) {
      if (other == null) {
        return;
      }
      if (other.transaction_ != null) {
        if (transaction_ == null) {
          Transaction = new global::MusZilCore.Proto.ProtoTransaction();
        }
        Transaction.MergeFrom(other.Transaction);
      }
      if (other.receipt_ != null) {
        if (receipt_ == null) {
          Receipt = new global::MusZilCore.Proto.ProtoTransactionReceipt();
        }
        Receipt.MergeFrom(other.Receipt);
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            if (transaction_ == null) {
              Transaction = new global::MusZilCore.Proto.ProtoTransaction();
            }
            input.ReadMessage(Transaction);
            break;
          }
          case 18: {
            if (receipt_ == null) {
              Receipt = new global::MusZilCore.Proto.ProtoTransactionReceipt();
            }
            input.ReadMessage(Receipt);
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
