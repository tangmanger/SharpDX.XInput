using SharpDX.XInput.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpDX.XInput.Struct
{
    public struct BatteryInformation
    {
        //
        // 摘要:
        //     The type of battery. BatteryType will be one of the following values. ValueDescription
        //     SharpDX.XInput.BatteryType.DisconnectedThe device is not connected.? SharpDX.XInput.BatteryType.WiredThe
        //     device is a wired device and does not have a battery.? SharpDX.XInput.BatteryType.AlkalineThe
        //     device has an alkaline battery.? SharpDX.XInput.BatteryType.NimhThe device has
        //     a nickel metal hydride battery.? SharpDX.XInput.BatteryType.UnknownThe device
        //     has an unknown battery type.? ?
        public BatteryType BatteryType;

        //
        // 摘要:
        //     The charge state of the battery. This value is only valid for wireless devices
        //     with a known battery type. BatteryLevel will be one of the following values.
        //     Value SharpDX.XInput.BatteryLevel.Empty SharpDX.XInput.BatteryLevel.Low SharpDX.XInput.BatteryLevel.Medium
        //     SharpDX.XInput.BatteryLevel.Full ?
        public BatteryLevel BatteryLevel;
    }
}
