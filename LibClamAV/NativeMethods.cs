using System;
using System.Runtime.InteropServices;

namespace LibClamAV
{
    static class NativeMethods
    {
        const string DllFileName = "libclamav.dll";

        [DllImport(DllFileName,CallingConvention=CallingConvention.Cdecl)]
        public static extern ClamEngineResult cl_init(uint Options);

        [DllImport(DllFileName,CallingConvention=CallingConvention.Cdecl)]
        public static extern IntPtr cl_engine_new();

        [DllImport(DllFileName,CallingConvention=CallingConvention.Cdecl)]
        public static extern ClamEngineResult cl_engine_free(IntPtr Engine);

        [DllImport(DllFileName,CallingConvention=CallingConvention.Cdecl)]
        public static extern IntPtr cl_retdbdir();

        [DllImport(DllFileName,CallingConvention=CallingConvention.Cdecl)]
        public static extern ClamEngineResult cl_load(string DatabaseDirectory, IntPtr Engine, ref uint NumberOfSignature, uint DatabaseOptions);

        [DllImport(DllFileName,CallingConvention=CallingConvention.Cdecl)]
        public static extern ClamEngineResult cl_scanfile(string FilePath, ref IntPtr VirusName, ref ulong Scanned, IntPtr Engine, uint ScanOptions);

        [DllImport(DllFileName,CallingConvention=CallingConvention.Cdecl)]
        public static extern ClamEngineResult cl_engine_compile(IntPtr Engine);

        [DllImport(DllFileName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cl_strerror(ClamEngineResult Error);
    }
}
