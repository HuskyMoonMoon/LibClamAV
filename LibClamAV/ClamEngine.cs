using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace LibClamAV
{
    public class ClamEngine : IDisposable
    {
        const uint DefaultEngineInit = 0x0;
        protected IntPtr NativeEngine;
        protected uint SignatureCount;

        public ClamEngine(string DatabaseDirectory)
        {
            ExceptionThrower(NativeMethods.cl_init(DefaultEngineInit));
            NativeEngine = Marshal.AllocHGlobal(64);
            NativeEngine = NativeMethods.cl_engine_new();
            ExceptionThrower(
                NativeMethods.cl_load(
                    DatabaseDirectory,
                    NativeEngine, 
                    ref SignatureCount, 
                    (uint)DatabaseOptions.StandardOption));
            ExceptionThrower(NativeMethods.cl_engine_compile(NativeEngine));
        }

        public bool IsFileInfected(string FilePath, out string VirusName)
        {
            ulong ByteScanned = 0;

            IntPtr VirusNamePtr = Marshal.AllocHGlobal(52);
            ClamEngineResult CurrentStatus = ExceptionThrower(
                NativeMethods.cl_scanfile(
                    FilePath, ref VirusNamePtr, 
                    ref ByteScanned, 
                    NativeEngine, 
                    (uint)ScanOptions.StandardOption));

            VirusName = Marshal.PtrToStringAnsi(VirusNamePtr);

            if (CurrentStatus == ClamEngineResult.Clean)
                return false;
            return true;
        }

        private ClamEngineResult ExceptionThrower(ClamEngineResult Result)
        {
            switch (Result)
            {
                case ClamEngineResult.Clean : return ClamEngineResult.Clean;
                case ClamEngineResult.Virus : return ClamEngineResult.Virus;
                default:
                {
                        string StatusName = Result.ToString();
                        string ExceptionDetail = ClamEngineException.ReturnErrorDescription(Result);
                        Exception ex = null;
                        if (StatusName.Contains("_General_"))
                            ex = new ClamEngineException(ExceptionDetail);
                        else if (StatusName.Contains("_File_"))
                            ex = new ClamEngineFileIOException(ExceptionDetail);
                        else if (StatusName.Contains("_Mem_"))
                            ex = new ClamEngineMemoryException(ExceptionDetail);
                        throw ex;
                }
            }            
        }

        #region "IDisposable Support"

        private bool IsDisposed = false;

        private void FreeUnmanagedResource()
        {
            NativeMethods.cl_engine_free(NativeEngine);
        }

        protected virtual void Dispose(bool Disposing)
        {
            if (!IsDisposed)
            {
                if (Disposing)
                {
                    FreeUnmanagedResource();
                    System.GC.SuppressFinalize(this);
                }

                NativeEngine = IntPtr.Zero;
                IsDisposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

        ~ClamEngine()
        {
            Dispose(false);
        }

        #endregion
    }
}
