using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Derby
{
    internal class Program
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        private const int SW_HIDE = 0;

        static void Main()
        {
            IntPtr handle = GetConsoleWindow();
            ShowWindow(handle, SW_HIDE);

            GC.Collect(0);
            Process process = Process.GetCurrentProcess();
            SetProcessWorkingSetSize(process.Handle, -1, -1);
             while (true)
            {
                System.Threading.Thread.Sleep(int.MaxValue); 
       
            }
        }
        [DllImport("kernel32.dll")]
        private static extern bool SetProcessWorkingSetSize(IntPtr process, int minSize, int maxSize);

    }
}
