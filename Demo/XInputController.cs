using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows;
using SharpDX.Win32;
using SharpDX;
using SharpDX.XInput;
using SharpDX.XInput.Enum;
using SharpDX.XInput.Struct;

namespace WpfXInput
{
    public class Controller
    {
        private readonly UserIndex userIndex;

        private static readonly IXInput xinput;

        //
        // 摘要:
        //     Gets the SharpDX.XInput.Controller.UserIndex associated with this controller.
        //
        //
        // 值:
        //     The index of the user.
        public UserIndex UserIndex => userIndex;

        //
        // 摘要:
        //     Gets a value indicating whether this instance is connected.
        //
        // 值:
        //     true if this instance is connected; otherwise, false.
        public bool IsConnected
        {
            get
            {
                State stateRef;
                return xinput.XInputGetState((int)userIndex, out stateRef) == 0;
            }
        }

        //
        // 摘要:
        //     Initializes a new instance of the SharpDX.XInput.Controller class.
        //
        // 参数:
        //   userIndex:
        //     Index of the user.
        public Controller(UserIndex userIndex = UserIndex.Any)
        {
            if (xinput == null)
            {
                throw new NotSupportedException("XInput 1.4 or 1.3 or 9.1.0 is not installed");
            }

            this.userIndex = userIndex;
        }

        //
        // 摘要:
        //     Gets the battery information.
        //
        // 参数:
        //   batteryDeviceType:
        //     Type of the battery device.
        public BatteryInformation GetBatteryInformation(BatteryDeviceType batteryDeviceType)
        {
            xinput.XInputGetBatteryInformation((int)userIndex, batteryDeviceType, out var batteryInformationRef);
            return batteryInformationRef;
        }

        //
        // 摘要:
        //     Gets the capabilities.
        //
        // 参数:
        //   deviceQueryType:
        //     Type of the device query.
        public Capabilities GetCapabilities(DeviceQueryType deviceQueryType)
        {
            xinput.XInputGetCapabilities((int)userIndex, deviceQueryType, out var capabilitiesRef);
            return capabilitiesRef;
        }

        //
        // 摘要:
        //     Gets the capabilities.
        //
        // 参数:
        //   deviceQueryType:
        //     Type of the device query.
        //
        //   capabilities:
        //     The capabilities of this controller.
        //
        // 返回结果:
        //     true if the controller is connected, false otherwise.
        public bool GetCapabilities(DeviceQueryType deviceQueryType, out Capabilities capabilities)
        {
            return xinput.XInputGetCapabilities((int)userIndex, deviceQueryType, out capabilities) == 0;
        }

        //
        // 摘要:
        //     Gets the keystroke.
        //
        // 参数:
        //   deviceQueryType:
        //     The flag.
        //
        //   keystroke:
        //     The keystroke.
        //public Result GetKeystroke(DeviceQueryType deviceQueryType, out Keystroke keystroke)
        //{
        //    return ErrorCodeHelper.ToResult(xinput.XInputGetKeystroke((int)userIndex, (int)deviceQueryType, out keystroke));
        //}

        //
        // 摘要:
        //     Gets the state.
        //
        // 返回结果:
        //     The state of this controller.
        public State GetState()
        {
            xinput.XInputGetState((int)userIndex, out var stateRef);
            return stateRef;
        }

        public Result GetKeystroke(DeviceQueryType deviceQueryType, out Keystroke keystroke)
        {
            var result = ErrorCodeHelper.ToResult(xinput.XInputGetKeystroke((int)userIndex, (int)deviceQueryType, out keystroke));
            return result;
        }
        //
        // 摘要:
        //     Gets the state.
        //
        // 参数:
        //   state:
        //     The state of this controller.
        //
        // 返回结果:
        //     true if the controller is connected, false otherwise.
        public bool GetState(out State state)
        {
            return xinput.XInputGetState((int)userIndex, out state) == 0;
        }

        //
        // 摘要:
        //     Sets the reporting.
        //
        // 参数:
        //   enableReporting:
        //     if set to true [enable reporting].
        public static void SetReporting(bool enableReporting)
        {
            if (xinput != null)
            {
                xinput.XInputEnable(enableReporting);
            }
        }

        //
        // 摘要:
        //     Sets the vibration.
        //
        // 参数:
        //   vibration:
        //     The vibration.
        //public Result SetVibration(Vibration vibration)
        //{
        //    Result result = ErrorCodeHelper.ToResult(xinput.XInputSetState((int)userIndex, vibration));
        //    result.CheckError();
        //    return result;
        //}

        static Controller()
        {
            if (LoadLibrary("xinput1_3.dll") != IntPtr.Zero)
            {
                xinput = new XInput13();
            }
            else if (LoadLibrary("xinput9_1_0.dll") != IntPtr.Zero)
            {
                xinput = new XInput910();
            }
        }

        [DllImport("kernel32", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern IntPtr LoadLibrary(string lpFileName);
    }
    class XInputController
    {
        private Controller controller;
        private Gamepad gamepad;
        public bool connected = false;
        public float deadband = 5;
        public Point leftThumb, rightThumb = new Point(0, 0);
        public float leftTrigger, rightTrigger;
        public bool ButtonStart, ButtonBack, ButtonDPadUp, ButtonDPadDown, ButtonDPadLeft, ButtonDPadRight,
            ButtonLeftThumb, ButtonRightThumb, ButtonLeftShoulder, ButtonRightShoulder, ButtonA, ButtonB, ButtonX, ButtonY;

        public bool Start
        {
            get { return ButtonStart; }
        }
        public bool Back
        {
            get { return ButtonBack; }
        }
        public bool DPadUp
        {
            get { return ButtonDPadUp; }
        }
        public bool DPadDown
        {
            get { return ButtonDPadDown; }
        }
        public bool DPadLeft
        {
            get { return ButtonDPadLeft; }
        }
        public bool DPadRight
        {
            get { return ButtonDPadRight; }
        }
        public bool LeftThumb
        {
            get { return ButtonLeftThumb; }
        }
        public bool RightThumb
        {
            get { return ButtonRightThumb; }
        }
        public bool LeftShoulder
        {
            get { return ButtonLeftShoulder; }
        }
        public bool RightShoulder
        {
            get { return ButtonRightShoulder; }
        }
        public bool A
        {
            get { return ButtonA; }
        }
        public bool B
        {
            get { return ButtonB; }
        }
        public bool X
        {
            get { return ButtonX; }
        }
        public bool Y
        {
            get { return ButtonY; }
        }

        public XInputController(UserIndex index = UserIndex.One)
        {
            controller = new Controller(index);
            connected = controller.IsConnected;
        }

        public bool Reconnect(UserIndex index = UserIndex.One)
        {
            controller = new Controller(index);
            connected = controller.IsConnected;
            return connected;
        }

        public void Update()
        {
            connected = controller.IsConnected;
            if (!connected)
                return;
            Keystroke keystroke;
            controller.GetKeystroke(DeviceQueryType.Gamepad, out keystroke);
            //Console.WriteLine(keystroke.Flags.ToString() + "=============" + keystroke.VirtualKey.ToString());
            gamepad = controller.GetState().Gamepad;
            GamepadButtonFlags flag = (GamepadButtonFlags)gamepad.Buttons;
            Console.WriteLine("-------------------"+ gamepad.Buttons.ToString());
            flag.HasFlag(GamepadButtonFlags.Start);
            ButtonStart = flag.HasFlag(GamepadButtonFlags.Start);
            ButtonBack = flag.HasFlag(GamepadButtonFlags.Back);
            ButtonDPadUp = flag.HasFlag(GamepadButtonFlags.DPadUp);
            ButtonDPadDown = flag.HasFlag(GamepadButtonFlags.DPadDown);
            ButtonDPadLeft = flag.HasFlag(GamepadButtonFlags.DPadLeft);
            ButtonDPadRight = flag.HasFlag(GamepadButtonFlags.DPadRight);
            ButtonLeftThumb = flag.HasFlag(GamepadButtonFlags.LeftThumb);
            ButtonRightThumb = flag.HasFlag(GamepadButtonFlags.RightThumb);
            ButtonLeftShoulder = flag.HasFlag(GamepadButtonFlags.LeftShoulder);
            ButtonRightShoulder = flag.HasFlag(GamepadButtonFlags.RightShoulder);
            ButtonA = flag.HasFlag(GamepadButtonFlags.A);
            ButtonB = flag.HasFlag(GamepadButtonFlags.B);
            ButtonX = flag.HasFlag(GamepadButtonFlags.X);
            ButtonY = flag.HasFlag(GamepadButtonFlags.Y);

            leftThumb.X = (Math.Abs((float)gamepad.LeftThumbX / short.MinValue * 100) < deadband) ? 0 : (float)gamepad.LeftThumbX / short.MaxValue * 100;
            leftThumb.Y = (Math.Abs((float)gamepad.LeftThumbY / short.MaxValue * 100) < deadband) ? 0 : (float)gamepad.LeftThumbY / short.MinValue * 100;
            rightThumb.X = (Math.Abs((float)gamepad.RightThumbX / short.MinValue * 100) < deadband) ? 0 : (float)gamepad.RightThumbX / short.MaxValue * 100;
            rightThumb.Y = (Math.Abs((float)gamepad.RightThumbY / short.MaxValue * 100) < deadband) ? 0 : (float)gamepad.RightThumbY / short.MinValue * 100;

            leftTrigger = gamepad.LeftTrigger;
            rightTrigger = gamepad.RightTrigger;
        }

        public override string ToString()
        {
            string str = "";
            str += Start ? "Start = True\n" : "Start = False\n";
            str += Back ? "Back = True\n" : "Back = False\n";
            str += DPadUp ? "DPadUp = True\n" : "DPadUp = False\n";
            str += DPadDown ? "DPadDown = True\n" : "DPadDown = False\n";
            str += DPadLeft ? "DPadLeft = True\n" : "DPadLeft = False\n";
            str += DPadRight ? "DPadRight = True\n" : "DPadRight = False\n";
            str += LeftThumb ? "LeftThumb = True\n" : "LeftThumb = False\n";
            str += RightThumb ? "RightThumb = True\n" : "RightThumb = False\n";
            str += LeftShoulder ? "LeftShoulder = True\n" : "LeftShoulder = False\n";
            str += RightShoulder ? "RightShoulder = True\n" : "RightShoulder = False\n";
            str += A ? "A = True\n" : "A = False\n";
            str += B ? "B = True\n" : "B = False\n";
            str += X ? "X = True\n" : "X = False\n";
            str += Y ? "Y = True" : "Y = False";
            return str;
        }
    }
}
