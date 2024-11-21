using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpDX.XInput.Enum
{
    [Flags]
    public enum CapabilityFlags : short
    {
        //
        // 摘要:
        //     No documentation.
        VoiceSupported = 4,
        //
        // 摘要:
        //     No documentation.
        FfbSupported = 1,
        //
        // 摘要:
        //     No documentation.
        Wireless = 2,
        //
        // 摘要:
        //     No documentation.
        PmdSupported = 8,
        //
        // 摘要:
        //     No documentation.
        NoNavigation = 0x10,
        //
        // 摘要:
        //     None.
        None = 0
    }
}
