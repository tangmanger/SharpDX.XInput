// Copyright (c) 2010-2014 SharpDX - Alexandre Mutel
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

namespace SharpDX.XInput
{
    public struct Gamepad
    {
        //
        // 摘要:
        //     Constant TriggerThreshold.
        public const byte TriggerThreshold = 30;

        //
        // 摘要:
        //     Constant LeftThumbDeadZone.
        public const short LeftThumbDeadZone = 7849;

        //
        // 摘要:
        //     Constant RightThumbDeadZone.
        public const short RightThumbDeadZone = 8689;

        //
        // 摘要:
        //     Bitmask of the device digital buttons, as follows. A set bit indicates that the
        //     corresponding button is pressed. Device buttonBitmask SharpDX.XInput.GamepadButtonFlags.DPadUp
        //     0x0001 SharpDX.XInput.GamepadButtonFlags.DPadDown 0x0002 SharpDX.XInput.GamepadButtonFlags.DPadLeft
        //     0x0004 SharpDX.XInput.GamepadButtonFlags.DPadRight 0x0008 SharpDX.XInput.GamepadButtonFlags.Start
        //     0x0010 SharpDX.XInput.GamepadButtonFlags.Back 0x0020 SharpDX.XInput.GamepadButtonFlags.LeftThumb
        //     0x0040 SharpDX.XInput.GamepadButtonFlags.RightThumb 0x0080 SharpDX.XInput.GamepadButtonFlags.LeftShoulder
        //     0x0100 SharpDX.XInput.GamepadButtonFlags.RightShoulder 0x0200 SharpDX.XInput.GamepadButtonFlags.A
        //     0x1000 SharpDX.XInput.GamepadButtonFlags.B 0x2000 SharpDX.XInput.GamepadButtonFlags.X
        //     0x4000 SharpDX.XInput.GamepadButtonFlags.Y 0x8000 ? Bits that are set but not
        //     defined above are reserved, and their state is undefined.
        //public GamepadButtonFlags Buttons;
        public ushort Buttons;
        //
        // 摘要:
        //     The current value of the left trigger analog control. The value is between 0
        //     and 255.
        public byte LeftTrigger;

        //
        // 摘要:
        //     The current value of the right trigger analog control. The value is between 0
        //     and 255.
        public byte RightTrigger;

        //
        // 摘要:
        //     Left thumbstick x-axis value. Each of the thumbstick axis members is a signed
        //     value between -32768 and 32767 describing the position of the thumbstick. A value
        //     of 0 is centered. Negative values signify down or to the left. Positive values
        //     signify up or to the right. The constants SharpDX.XInput.Gamepad.LeftThumbDeadZone
        //     or SharpDX.XInput.Gamepad.RightThumbDeadZone can be used as a positive and negative
        //     value to filter a thumbstick input.
        public short LeftThumbX;

        //
        // 摘要:
        //     Left thumbstick y-axis value. The value is between -32768 and 32767.
        public short LeftThumbY;

        //
        // 摘要:
        //     Right thumbstick x-axis value. The value is between -32768 and 32767.
        public short RightThumbX;

        //
        // 摘要:
        //     Right thumbstick y-axis value. The value is between -32768 and 32767.
        public short RightThumbY;

        public override string ToString()
        {
            return $"Buttons: {Buttons}, LeftTrigger: {LeftTrigger}, RightTrigger: {RightTrigger}, LeftThumbX: {LeftThumbX}, LeftThumbY: {LeftThumbY}, RightThumbX: {RightThumbX}, RightThumbY: {RightThumbY}";
        }
    }
}

