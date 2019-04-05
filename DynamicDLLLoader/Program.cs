using System;
using System.IO;
using System.Runtime.InteropServices;

namespace DynamicDLLLoader
{
    internal class Program
    {
        //[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        //public delegate void SomeExportedFunctionInTheDll();
        
        [DllImport("kernel32.dll", CharSet=CharSet.Auto)]
        public static extern IntPtr GetModuleHandle(string lpModuleName);

        static unsafe void Main(string[] args)
        {
            byte[] dat = File.ReadAllBytes(Directory.GetCurrentDirectory() + "\\mono.dll");

            DynamicDllLoader loader = new DynamicDllLoader();
            // LoadLibrary accepts a byte array.
            bool loaded = loader.LoadLibrary(dat);
            Console.WriteLine("Loaded: " + loaded);

            if (loaded)
            {
                //....
                uint xd = loader.GetProcAddress("mono_trace");
                Console.WriteLine("Handle: " + xd); // > 0, means that our dll loaded correctly.
            }

            Console.ReadKey();

            //uint addr = loader.GetProcAddress("SomeExportedFunction");

            //SomeExportedFunctionInTheDll invoke =
            //    (SomeExportedFunctionInTheDll)Marshal.GetDelegateForFunctionPointer((IntPtr)addr, typeof(SomeExportedFunctionInTheDll));
            //invoke();
        }
    }
}