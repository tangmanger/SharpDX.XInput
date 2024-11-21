using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using WpfXInput;

namespace Demo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        // 导入必要的Windows API函数和常量
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool RegisterRawInputDevices(RID_DEVICE_INFO[] pRawInputDevices, uint uiNumDevices, uint cbSize);

        [DllImport("user32.dll")]
        private static extern uint GetRawInputData(IntPtr hRawInput, uint uiCommand, IntPtr pData, ref uint pcbSize, uint cbSizeHeader);

        [DllImport("user32.dll")]
        private static extern IntPtr GetRawInputDeviceInfo(IntPtr hDevice, uint uiCommand, IntPtr pData, ref uint pcbSize);

        [DllImport("user32.dll")]
        private static extern uint GetRawInputDeviceList(IntPtr pData, ref uint puiNumDevices, uint cbSize);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool DefRawInputProc(IntPtr hRawInput, uint uiCommand, IntPtr pData, IntPtr pExtraInfo);

        [StructLayout(LayoutKind.Sequential)]
        private struct RID_DEVICE_INFO
        {
            public uint cbSize;
            public uint dwType;
            public ushort usUsagePage;
            public ushort usUsage;
            public uint dwFlags;
            public IntPtr hwndTarget;
        }
     

        // 其他必要的代码和结构体定义...

        [StructLayout(LayoutKind.Sequential)]
        private struct RAWINPUTHEADER
        {
            public uint dwType;
            public uint dwSize;
            public IntPtr hDevice;
            public IntPtr wParam;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct RAWINPUT
        {
            public RAWINPUTHEADER header;
            public union_RAWINPUT data;

            [StructLayout(LayoutKind.Explicit)]
            public struct union_RAWINPUT
            {
                [FieldOffset(0)]
                public RAWMOUSE mouse;
                [FieldOffset(0)]
                public RAWKEYBOARD keyboard;
                [FieldOffset(0)]
                public HIDRAWINPUT hid;
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct RAWMOUSE
            {
                // 鼠标输入结构体定义...
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct RAWKEYBOARD
            {
                // 键盘输入结构体定义...
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct HIDRAWINPUT
            {
                public ushort usUsagePage;
                public ushort usUsage;
                public uint dwFlags;
                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
                public short[] bRawData;
            }
        }
        private XInputController XI;
        DispatcherTimer dt, reconnect;

        public MainWindow()
        {
            InitializeComponent();
            XI = new XInputController();
            XI.deadband = 8;
            if (XI.connected == false)
            {
                Connect.Visibility = Visibility.Collapsed;
                return;
            }
            dt = new DispatcherTimer();
            dt.Tick += new EventHandler(flushXInput);
            dt.Interval = new TimeSpan(0, 0, 0, 0, 1000 / 144);
            dt.Start();
            reconnect = new DispatcherTimer();
            reconnect.Interval = new TimeSpan(0, 0, 1);
            reconnect.Tick += new EventHandler(Xreconnect);
        }
        private void Xreconnect(object sender, EventArgs e)
        {
            if (XI.Reconnect())
            {
                Connect.Visibility = Visibility.Visible;
                reconnect.Stop();
                dt.Start();
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if (XI != null)
            //    XI.Reconnect((XInput.UserIndex)((System.Windows.Controls.Primitives.Selector)sender).SelectedItem);
        }

        private void flushXInput(object sender, EventArgs e)
        {
            XI.Update();

            if (XI.connected == false)
            {
                Connect.Visibility = Visibility.Collapsed;
                dt.Stop();
                reconnect.Start();
                return;
            }
            pointl.ThumbPoint = XI.leftThumb;
            pointl.ButtonDown = XI.ButtonLeftThumb;
            pointr.ThumbPoint = XI.rightThumb;
            pointr.ButtonDown = XI.ButtonRightThumb;
            ButtonA_Back.Fill.Opacity = XI.ButtonA ? 0.6 : 0;
            ButtonB_Back.Fill.Opacity = XI.ButtonB ? 0.6 : 0;
            ButtonX_Back.Fill.Opacity = XI.ButtonX ? 0.6 : 0;
            ButtonY_Back.Fill.Opacity = XI.ButtonY ? 0.6 : 0;
            ButtonUP_Back.Visibility = XI.ButtonDPadUp ? Visibility.Visible : Visibility.Collapsed;
            ButtonDown_Back.Visibility = XI.ButtonDPadDown ? Visibility.Visible : Visibility.Collapsed;
            ButtonLeft_Back.Visibility = XI.ButtonDPadLeft ? Visibility.Visible : Visibility.Collapsed;
            ButtonRight_Back.Visibility = XI.ButtonDPadRight ? Visibility.Visible : Visibility.Collapsed;
            ButtonLB_Back.Visibility = XI.ButtonLeftShoulder ? Visibility.Visible : Visibility.Collapsed;
            ButtonRB_Back.Visibility = XI.ButtonRightShoulder ? Visibility.Visible : Visibility.Collapsed;
            ButtonStart_Back.Visibility = XI.ButtonStart ? Visibility.Visible : Visibility.Collapsed;
            ButtonBack_Back.Visibility = XI.ButtonBack ? Visibility.Visible : Visibility.Collapsed;
            LT_Trigger.Offset = 1 - ((XI.leftTrigger + 4) / 263);
            RT_Trigger.Offset = 1 - ((XI.rightTrigger + 4) / 263);
            //pointl.Margin = new Thickness(XI.leftThumb.X + Pgl.ActualWidth / 2, XI.leftThumb.Y + Pgl.ActualHeight / 2, 0, 0);
            //pointr.Margin = new Thickness(XI.rightThumb.X + Pgr.ActualWidth / 2, XI.rightThumb.Y + Pgr.ActualHeight / 2, 0, 0);
        }
    }
}
