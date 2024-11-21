using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpDX.XInput.Struct
{
    [Flags]
    public enum KeyStrokeFlags : short
    {
        //
        // 摘要:
        //     No documentation.
        KeyDown = 1,
        //
        // 摘要:
        //     No documentation.
        KeyUp = 2,
        //
        // 摘要:
        //     No documentation.
        Repeat = 4,
        //
        // 摘要:
        //     None.
        None = 0
    }
}
