// Decompiled with JetBrains decompiler
// Type: HidSharp.Platform.Linux.LinuxHidDevice
// Assembly: HidSharpCore, Version=2.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B2D17963-6A43-4AF7-A433-8F7854504DE5
// Assembly location: /home/gohan/.nuget/packages/hidsharpcore/1.1.0/lib/net5.0/HidSharpCore.dll

using HidSharp.Exceptions;
using HidSharp.Reports;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace HidSharp.Platform.Linux
{
  internal sealed class LinuxHidDevice : HidDevice
  {
    private object _getInfoLock;
    private string _manufacturer;
    private string _productName;
    private string _serialNumber;
    private byte[] _reportDescriptor;
    private int _vid;
    private int _pid;
    private int _version;
    private int _maxInput;
    private int _maxOutput;
    private int _maxFeature;
    private bool _reportsUseID;
    private string _path;
    private string _fileSystemName;

    private LinuxHidDevice() => this._getInfoLock = new object();

    internal static LinuxHidDevice TryCreate(string path)
    {
      LinuxHidDevice linuxHidDevice = new LinuxHidDevice()
      {
        _path = path
      };
      IntPtr udev = NativeMethodsLibudev.Instance.udev_new();
      if (IntPtr.Zero != udev)
      {
        try
        {
          IntPtr device = NativeMethodsLibudev.Instance.udev_device_new_from_syspath(udev, linuxHidDevice._path);
          if (device != IntPtr.Zero)
          {
            try
            {
              string devnode = NativeMethodsLibudev.Instance.udev_device_get_devnode(device);
              if (devnode != null)
              {
                linuxHidDevice._fileSystemName = devnode;
                IntPtr subsystemDevtype = NativeMethodsLibudev.Instance.udev_device_get_parent_with_subsystem_devtype(device, "usb", "usb_device");
                if (IntPtr.Zero != subsystemDevtype)
                {
                  string sysattrValue1 = NativeMethodsLibudev.Instance.udev_device_get_sysattr_value(subsystemDevtype, "manufacturer");
                  string sysattrValue2 = NativeMethodsLibudev.Instance.udev_device_get_sysattr_value(subsystemDevtype, "product");
                  string sysattrValue3 = NativeMethodsLibudev.Instance.udev_device_get_sysattr_value(subsystemDevtype, "serial");
                  string sysattrValue4 = NativeMethodsLibudev.Instance.udev_device_get_sysattr_value(subsystemDevtype, "idVendor");
                  string sysattrValue5 = NativeMethodsLibudev.Instance.udev_device_get_sysattr_value(subsystemDevtype, "idProduct");
                  string sysattrValue6 = NativeMethodsLibudev.Instance.udev_device_get_sysattr_value(subsystemDevtype, "bcdDevice");
                  int result1;
                  int result2;
                  int result3;
                  if (NativeMethods.TryParseHex(sysattrValue4, out result1) && NativeMethods.TryParseHex(sysattrValue5, out result2) && NativeMethods.TryParseHex(sysattrValue6, out result3))
                  {
                    linuxHidDevice._vid = result1;
                    linuxHidDevice._pid = result2;
                    linuxHidDevice._version = result3;
                    linuxHidDevice._manufacturer = sysattrValue1;
                    linuxHidDevice._productName = sysattrValue2;
                    linuxHidDevice._serialNumber = sysattrValue3;
                    return linuxHidDevice;
                  }
                }
              }
            }
            finally
            {
              NativeMethodsLibudev.Instance.udev_device_unref(device);
            }
          }
        }
        finally
        {
          NativeMethodsLibudev.Instance.udev_unref(udev);
        }
      }
      return (LinuxHidDevice) null;
    }

    protected override DeviceStream OpenDeviceDirectly(OpenConfiguration openConfig)
    {
      this.RequiresGetInfo();
      LinuxHidStream linuxHidStream = new LinuxHidStream(this);
      try
      {
        linuxHidStream.Init(this._path);
        return (DeviceStream) linuxHidStream;
      }
      catch
      {
        linuxHidStream.Close();
        throw;
      }
    }

    public override string GetManufacturer() => this._manufacturer != null ? this._manufacturer : throw DeviceException.CreateIOException((Device) this, "Unnamed manufacturer.");

    public override string GetProductName() => this._productName != null ? this._productName : throw DeviceException.CreateIOException((Device) this, "Unnamed product.");

    public override string GetSerialNumber() => this._serialNumber != null ? this._serialNumber : throw DeviceException.CreateIOException((Device) this, "No serial number.");

    public override int GetMaxInputReportLength()
    {
      this.RequiresGetInfo();
      return this._maxInput;
    }

    public override int GetMaxOutputReportLength()
    {
      this.RequiresGetInfo();
      return this._maxOutput;
    }

    public override int GetMaxFeatureReportLength()
    {
      this.RequiresGetInfo();
      return this._maxFeature;
    }

    public override byte[] GetRawReportDescriptor()
    {
      this.RequiresGetInfo();
      return (byte[]) this._reportDescriptor.Clone();
    }

    public override unsafe string GetDeviceString(int index)
    {
      NativeMethods.usbfs_ctrltransfer usbfsCtrltransfer = new NativeMethods.usbfs_ctrltransfer()
      {
        bRequestType = 128,
        bRequest = 6,
        wValue = string_index((byte) 0),
        wIndex = 0,
        wLength = (ushort) byte.MaxValue
      };
      IntPtr udev = NativeMethodsLibudev.Instance.udev_new();
      IntPtr subsystemDevtype = NativeMethodsLibudev.Instance.udev_device_get_parent_with_subsystem_devtype(NativeMethodsLibudev.Instance.udev_device_new_from_syspath(udev, this._path), "usb", "usb_device");
      string sysattrValue = NativeMethodsLibudev.Instance.udev_device_get_sysattr_value(subsystemDevtype, "devnum");
      string filename = string.Format("/dev/bus/usb/{0:D3}/{1:D3}", (object) int.Parse(NativeMethodsLibudev.Instance.udev_device_get_sysattr_value(subsystemDevtype, "busnum")), (object) int.Parse(sysattrValue));
      try
      {
        fixed (char* chPtr = new char[(int) byte.MaxValue])
        {
          usbfsCtrltransfer.data = (void*) chPtr;
          int filedes = NativeMethods.open(filename, NativeMethods.oflag.RDWR | NativeMethods.oflag.NONBLOCK);
          if (NativeMethods.ioctl(filedes, NativeMethods.USBDEVFS_CONTROL, ref usbfsCtrltransfer) < 0)
          {
            NativeMethods.close(filedes);
            throw new DeviceIOException((Device) this, string.Format("Unable to retrieve device's supported langId: {0}", (object) (NativeMethods.error) Marshal.GetLastWin32Error()));
          }
          byte* data1 = (byte*) usbfsCtrltransfer.data;
          ushort num = (ushort) ((uint) data1[2] | (uint) data1[3] << 8);
          for (int index1 = 0; index1 < (int) byte.MaxValue; ++index1)
            data1[index1] = (byte) 0;
          usbfsCtrltransfer.wIndex = num;
          usbfsCtrltransfer.wValue = string_index((byte) index);
          if (NativeMethods.ioctl(filedes, NativeMethods.USBDEVFS_CONTROL, ref usbfsCtrltransfer) < 0)
          {
            NativeMethods.close(filedes);
            NativeMethods.error lastWin32Error = (NativeMethods.error) Marshal.GetLastWin32Error();
            throw new DeviceIOException((Device) this, string.Format("Unable to retrieve device string at index {0}: {1}", (object) index, (object) lastWin32Error));
          }
          NativeMethods.close(filedes);
          StringBuilder stringBuilder = new StringBuilder((int) byte.MaxValue);
          char* data2 = (char*) usbfsCtrltransfer.data;
          for (int index1 = 1; index1 < (int) byte.MaxValue; ++index1)
          {
            char ch = data2[index1];
            if (ch != char.MinValue)
              stringBuilder.Append(ch);
            else
              break;
          }
          return stringBuilder.ToString();
        }
      }
      catch
      {
        throw;
      }
      finally
      {
        NativeMethodsLibudev.Instance.udev_device_unref(subsystemDevtype);
        NativeMethodsLibudev.Instance.udev_unref(udev);
      }

      static ushort string_index(byte index) => (ushort) (768U | (uint) index);
    }

    private bool TryParseReportDescriptor(out ReportDescriptor parser, out byte[] reportDescriptor)
    {
      parser = (ReportDescriptor) null;
      reportDescriptor = (byte[]) null;
      int handle;
      try
      {
        handle = LinuxHidStream.DeviceHandleFromPath(this._path, (HidDevice) this, NativeMethods.oflag.NONBLOCK);
      }
      catch (FileNotFoundException ex)
      {
        throw DeviceException.CreateIOException((Device) this, "Failed to read report descriptor.");
      }
      try
      {
        uint num;
        if (NativeMethods.ioctl(handle, NativeMethods.HIDIOCGRDESCSIZE, out num) < 0 || num > 4096U)
          return false;
        NativeMethods.hidraw_report_descriptor reportDescriptor1 = new NativeMethods.hidraw_report_descriptor()
        {
          size = num
        };
        if (NativeMethods.ioctl(handle, NativeMethods.HIDIOCGRDESC, ref reportDescriptor1) < 0)
          return false;
        Array.Resize<byte>(ref reportDescriptor1.value, (int) num);
        parser = new ReportDescriptor(reportDescriptor1.value);
        reportDescriptor = reportDescriptor1.value;
        return true;
      }
      finally
      {
        NativeMethods.retry((Func<int>) (() => NativeMethods.close(handle)));
      }
    }

    private void RequiresGetInfo()
    {
      lock (this._getInfoLock)
      {
        if (this._reportDescriptor != null)
          return;
        ReportDescriptor parser;
        byte[] reportDescriptor;
        if (!this.TryParseReportDescriptor(out parser, out reportDescriptor))
          throw DeviceException.CreateIOException((Device) this, "Failed to read report descriptor.");
        this._maxInput = parser.MaxInputReportLength;
        this._maxOutput = parser.MaxOutputReportLength;
        this._maxFeature = parser.MaxFeatureReportLength;
        this._reportsUseID = parser.ReportsUseID;
        this._reportDescriptor = reportDescriptor;
      }
    }

    public override string GetFileSystemName() => this._fileSystemName;

    public override bool HasImplementationDetail(Guid detail) => base.HasImplementationDetail(detail) || detail == ImplementationDetail.Linux || detail == ImplementationDetail.HidrawApi;

    public override string DevicePath => this._path;

    public override int VendorID => this._vid;

    public override int ProductID => this._pid;

    public override int ReleaseNumberBcd => this._version;

    internal bool ReportsUseID => this._reportsUseID;
  }
}
