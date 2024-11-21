using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpDX.XInput.Struct
{
    public struct Vibration
    {
        //
        // 摘要:
        //     Speed of the left motor. Valid values are in the range 0 to 65,535. Zero signifies
        //     no motor use; 65,535 signifies 100 percent motor use.
        public ushort LeftMotorSpeed;

        //
        // 摘要:
        //     Speed of the right motor. Valid values are in the range 0 to 65,535. Zero signifies
        //     no motor use; 65,535 signifies 100 percent motor use.
        public ushort RightMotorSpeed;
    }
}
