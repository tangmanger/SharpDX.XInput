using SharpDX.XInput;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//
// 摘要:
//     Represents the state of a controller.
//
// 言论：
//     The dwPacketNumber member is incremented only if the status of the controller
//     has changed since the controller was last polled.
public struct State
{
    //
    // 摘要:
    //     State packet number. The packet number indicates whether there have been any
    //     changes in the state of the controller. If the dwPacketNumber member is the same
    //     in sequentially returned SharpDX.XInput.State structures, the controller state
    //     has not changed.
    public int PacketNumber;

    //
    // 摘要:
    //     SharpDX.XInput.Gamepad structure containing the current state of an Xbox 360
    //     Controller.
    public Gamepad Gamepad;
}
