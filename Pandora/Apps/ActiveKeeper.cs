using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandora.Apps
{
    public class Win32
    {
        [System.Runtime.InteropServices.DllImport("user32")]
        public static extern int mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

        //移动鼠标 
        const int MOUSEEVENTF_MOVE = 0x0001;
        //模拟鼠标左键按下 
        const int MOUSEEVENTF_LEFTDOWN = 0x0002;
        //模拟鼠标左键抬起 
        const int MOUSEEVENTF_LEFTUP = 0x0004;
        //模拟鼠标右键按下 
        const int MOUSEEVENTF_RIGHTDOWN = 0x0008;
        //模拟鼠标右键抬起 
        const int MOUSEEVENTF_RIGHTUP = 0x0010;
        //模拟鼠标中键按下 
        const int MOUSEEVENTF_MIDDLEDOWN = 0x0020;
        //模拟鼠标中键抬起 
        const int MOUSEEVENTF_MIDDLEUP = 0x0040;
        //标示是否采用绝对坐标 
        const int MOUSEEVENTF_ABSOLUTE = 0x8000;
        //模拟鼠标滚轮滚动操作，必须配合dwData参数
        const int MOUSEEVENTF_WHEEL = 0x0800;


        public static void MoveMouse()
        {
            mouse_event(MOUSEEVENTF_MOVE, 1, 1, 0, 0); //相对当前鼠标位置x轴和y轴分别移动50像素
        }
    }

    public class ActiveKeeper
    {
        private bool _exit = false;
        private bool _started = false;

        public void Begin()
        {
            if (_started) return;
            _started = true;

            Task.Run(() =>
            {
                while (true)
                {
                    if (_exit)
                    {
                        _started = false;
                        return;
                    }
                    Win32.MoveMouse();
                    System.Threading.Thread.Sleep(120 * 1000);
                }
               
            });
        }

        public void Stop()
        {
            _exit = true;
        }
    }
}
