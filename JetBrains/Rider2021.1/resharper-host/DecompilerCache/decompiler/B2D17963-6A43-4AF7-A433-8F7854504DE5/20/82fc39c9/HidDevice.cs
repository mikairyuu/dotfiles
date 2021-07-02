// Decompiled with JetBrains decompiler
// Type: HidSharp.HidDevice
// Assembly: HidSharpCore, Version=2.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B2D17963-6A43-4AF7-A433-8F7854504DE5
// Assembly location: /home/gohan/.nuget/packages/hidsharpcore/1.1.0/lib/net5.0/HidSharpCore.dll

using HidSharp.Reports;
using HidSharp.Utility;
using System;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;

namespace HidSharp
{
  [ComVisible(true)]
  [Guid("4D8A9A1A-D5CC-414e-8356-5A025EDA098D")]
  public abstract class HidDevice : Device
  {
    public HidStream Open() => (HidStream) base.Open();

    public HidStream Open(OpenConfiguration openConfig) => (HidStream) base.Open(openConfig);

    public override string GetFriendlyName() => this.GetProductName();

    public abstract string GetManufacturer();

    public abstract string GetProductName();

    public abstract string GetSerialNumber();

    public abstract int GetMaxInputReportLength();

    public abstract int GetMaxOutputReportLength();

    public abstract int GetMaxFeatureReportLength();

    public ReportDescriptor GetReportDescriptor() => new ReportDescriptor(this.GetRawReportDescriptor());

    public virtual byte[] GetRawReportDescriptor() => throw new NotSupportedException();

    public abstract string GetDeviceString(int index);

    public virtual string[] GetSerialPorts() => throw new NotSupportedException();

    public override string ToString()
    {
      string str1 = "(unnamed manufacturer)";
      try
      {
        str1 = this.GetManufacturer();
      }
      catch
      {
      }
      string str2 = "(unnamed product)";
      try
      {
        str2 = this.GetProductName();
      }
      catch
      {
      }
      string str3 = "(no serial number)";
      try
      {
        str3 = this.GetSerialNumber();
      }
      catch
      {
      }
      return string.Format((IFormatProvider) CultureInfo.InvariantCulture, "{0} {1} {2} (VID {3}, PID {4}, version {5})", (object) str1, (object) str2, (object) str3, (object) this.VendorID, (object) this.ProductID, (object) this.ReleaseNumber);
    }

    public bool TryOpen(out HidStream stream) => this.TryOpen((OpenConfiguration) null, out stream);

    public bool TryOpen(OpenConfiguration openConfig, out HidStream stream)
    {
      DeviceStream stream1;
      bool flag = this.TryOpen(openConfig, out stream1);
      stream = (HidStream) stream1;
      return flag;
    }

    public override bool HasImplementationDetail(Guid detail) => base.HasImplementationDetail(detail) || detail == ImplementationDetail.HidDevice;

    public abstract int ProductID { get; }

    public Version ReleaseNumber => BcdHelper.ToVersion(this.ReleaseNumberBcd);

    public abstract int ReleaseNumberBcd { get; }

    [Obsolete("Use ReleaseNumberBcd instead.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual int ProductVersion => this.ReleaseNumberBcd;

    public abstract int VendorID { get; }

    [Obsolete]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual string Manufacturer
    {
      get
      {
        try
        {
          return this.GetManufacturer() ?? "";
        }
        catch (IOException ex)
        {
          return "";
        }
        catch (UnauthorizedAccessException ex)
        {
          return "";
        }
      }
    }

    [Obsolete]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual string ProductName
    {
      get
      {
        try
        {
          return this.GetProductName() ?? "";
        }
        catch (IOException ex)
        {
          return "";
        }
        catch (UnauthorizedAccessException ex)
        {
          return "";
        }
      }
    }

    [Obsolete]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual string SerialNumber
    {
      get
      {
        try
        {
          return this.GetSerialNumber() ?? "";
        }
        catch (IOException ex)
        {
          return "";
        }
        catch (UnauthorizedAccessException ex)
        {
          return "";
        }
      }
    }

    [Obsolete]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual int MaxInputReportLength
    {
      get
      {
        try
        {
          return this.GetMaxInputReportLength();
        }
        catch (IOException ex)
        {
          return 0;
        }
        catch (UnauthorizedAccessException ex)
        {
          return 0;
        }
      }
    }

    [Obsolete]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual int MaxOutputReportLength
    {
      get
      {
        try
        {
          return this.GetMaxOutputReportLength();
        }
        catch (IOException ex)
        {
          return 0;
        }
        catch (UnauthorizedAccessException ex)
        {
          return 0;
        }
      }
    }

    [Obsolete]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual int MaxFeatureReportLength
    {
      get
      {
        try
        {
          return this.GetMaxFeatureReportLength();
        }
        catch (IOException ex)
        {
          return 0;
        }
        catch (UnauthorizedAccessException ex)
        {
          return 0;
        }
      }
    }
  }
}
