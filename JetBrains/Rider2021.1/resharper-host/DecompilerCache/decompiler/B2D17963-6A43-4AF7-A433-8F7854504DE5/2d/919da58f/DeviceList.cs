// Decompiled with JetBrains decompiler
// Type: HidSharp.DeviceList
// Assembly: HidSharpCore, Version=2.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B2D17963-6A43-4AF7-A433-8F7854504DE5
// Assembly location: /home/gohan/.nuget/packages/hidsharpcore/1.1.0/lib/net5.0/HidSharpCore.dll

using HidSharp.Experimental;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;

namespace HidSharp
{
  [ComVisible(true)]
  [Guid("80614F94-0742-4DE4-8AE9-DF9D55F870F2")]
  public abstract class DeviceList
  {
    [Obsolete]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static event EventHandler<DeviceListChangedEventArgs> DeviceListChanged;

    public event EventHandler<DeviceListChangedEventArgs> Changed;

    static DeviceList() => DeviceList.Local = (DeviceList) new LocalDeviceList();

    public virtual IEnumerable<Device> GetDevices(DeviceTypes types) => this.GetAllDevices().Where<Device>((Func<Device, bool>) (device => device is HidDevice && (uint) (types & DeviceTypes.Hid) > 0U || device is SerialDevice && (uint) (types & DeviceTypes.Serial) > 0U || device is BleDevice && (uint) (types & DeviceTypes.Ble) > 0U));

    public IEnumerable<Device> GetDevices(DeviceTypes types, DeviceFilter filter)
    {
      Throw.If.Null<DeviceFilter>(filter, nameof (filter));
      return this.GetDevices(types).Where<Device>((Func<Device, bool>) (device => filter(device)));
    }

    public IEnumerable<BleDevice> GetBleDevices() => this.GetDevices(DeviceTypes.Ble).Cast<BleDevice>();

    public IEnumerable<HidDevice> GetHidDevices() => this.GetDevices(DeviceTypes.Hid).Cast<HidDevice>();

    public IEnumerable<HidDevice> GetHidDevices(
      int? vendorID = null,
      int? productID = null,
      int? releaseNumberBcd = null,
      string serialNumber = null)
    {
      return this.GetDevices(DeviceTypes.Hid, (DeviceFilter) (d => DeviceFilterHelper.MatchHidDevices(d, vendorID, productID, releaseNumberBcd, serialNumber))).Cast<HidDevice>();
    }

    public IEnumerable<SerialDevice> GetSerialDevices() => this.GetDevices(DeviceTypes.Serial).Cast<SerialDevice>();

    public abstract IEnumerable<Device> GetAllDevices();

    public IEnumerable<Device> GetAllDevices(DeviceFilter filter)
    {
      Throw.If.Null<DeviceFilter>(filter, nameof (filter));
      return this.GetAllDevices().Where<Device>((Func<Device, bool>) (device => filter(device)));
    }

    public HidDevice GetHidDeviceOrNull(
      int? vendorID = null,
      int? productID = null,
      int? releaseNumberBcd = null,
      string serialNumber = null)
    {
      return this.GetHidDevices(vendorID, productID, releaseNumberBcd, serialNumber).FirstOrDefault<HidDevice>();
    }

    public bool TryGetHidDevice(
      out HidDevice device,
      int? vendorID = null,
      int? productID = null,
      int? releaseNumberBcd = null,
      string serialNumber = null)
    {
      device = this.GetHidDeviceOrNull(vendorID, productID, releaseNumberBcd, serialNumber);
      return device != null;
    }

    public SerialDevice GetSerialDeviceOrNull(string portName) => this.GetSerialDevices().Where<SerialDevice>((Func<SerialDevice, bool>) (d =>
    {
      if (d.DevicePath == portName)
        return true;
      try
      {
        if (d.GetFileSystemName() == portName)
          return true;
      }
      catch
      {
      }
      return false;
    })).FirstOrDefault<SerialDevice>();

    public bool TryGetSerialDevice(out SerialDevice device, string portName)
    {
      device = this.GetSerialDeviceOrNull(portName);
      return device != null;
    }

    public void RaiseChanged()
    {
      EventHandler<DeviceListChangedEventArgs> changed = this.Changed;
      if (changed != null)
        changed((object) this, new DeviceListChangedEventArgs());
      EventHandler<DeviceListChangedEventArgs> deviceListChanged = DeviceList.DeviceListChanged;
      if (deviceListChanged == null)
        return;
      deviceListChanged((object) this, new DeviceListChangedEventArgs());
    }

    public abstract bool AreDriversBeingInstalled { get; }

    public static DeviceList Local { get; private set; }
  }
}
