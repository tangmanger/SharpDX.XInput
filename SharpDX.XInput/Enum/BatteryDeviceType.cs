using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpDX.XInput.Enum
{
    public enum BatteryDeviceType
    {
        //
        // 摘要:
        //     Index of the signed-in gamer associated with the device. Can be a value in the
        //     range 0?XUSER_MAX_COUNT ? 1.
        Gamepad,
        //
        // 摘要:
        //     Specifies which device associated with this user index should be queried. Must
        //     be SharpDX.XInput.BatteryDeviceType.Gamepad or SharpDX.XInput.BatteryDeviceType.Headset.
        Headset
    }
}
