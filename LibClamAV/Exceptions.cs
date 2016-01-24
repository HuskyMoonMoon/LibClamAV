using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibClamAV
{
    public class ClamEngineException : Exception
    {
        public ClamEngineException(string Message) : base(Message) { }

        public static string ReturnErrorDescription(ClamEngineResult Result)
        {
            return System.Runtime.InteropServices.Marshal.PtrToStringAnsi(NativeMethods.cl_strerror(Result));
        }
    }

    public class ClamEngineFileIOException : System.IO.IOException
    {
        public ClamEngineFileIOException(string Message) : base("FileIO : " + Message) { }
    }

    public class ClamEngineMemoryException : System.IO.IOException
    {
        public ClamEngineMemoryException(string Message) : base("MemoryIO : " + Message) { }
    }

}