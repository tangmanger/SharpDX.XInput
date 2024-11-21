using SharpDX.XInput.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpDX.XInput.Struct
{
    public struct Capabilities
    {
        //
        // 摘要:
        //     No documentation.
        public DeviceType Type;

        //
        // 摘要:
        //     No documentation.
        public DeviceSubType SubType;

        //
        // 摘要:
        //     No documentation.
        public CapabilityFlags Flags;

        //
        // 摘要:
        //     No documentation.
        public Gamepad Gamepad;

        //
        // 摘要:
        //     No documentation.
        public Vibration Vibration;
    }
}
