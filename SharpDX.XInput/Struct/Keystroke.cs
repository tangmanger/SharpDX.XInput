using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpDX.XInput.Struct
{
    public struct Keystroke
    {
        //
        // 摘要:
        //     No documentation.
        public GamepadKeyCode VirtualKey;

        //
        // 摘要:
        //     No documentation.
        public char Unicode;

        //
        // 摘要:
        //     No documentation.
        public KeyStrokeFlags Flags;

        //
        // 摘要:
        //     No documentation.
        public UserIndex UserIndex;

        //
        // 摘要:
        //     No documentation.
        public byte HidCode;
    }
}
