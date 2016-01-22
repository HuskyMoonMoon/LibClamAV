using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibClamAV
{
    public enum ClamEngineResult
    {
        Clean = 0,
        Success = 0,
        Virus,
        Error_General_NullArgument,
        Error_General_Argument,
        Error_General_MalformedDatabase,
        Error_General_BrokenCVDFile,
        Error_General_CVDVerify,
        Error_General_CVDUnpack,
        Error_File_FileOpen,
        Error_File_FileCreate,
        Error_File_Unlink,
        Error_File_Status,
        Error_File_FileRead,
        Error_File_FileSeek,
        Error_File_FileWrite,
        Error_File_FileDuplicated,
        Error_File_AccessDenied,
        Error_File_TempFile,
        Error_File_TempDirectory,
        Error_Mem_MemoryMapping,
        Error_Mem_MemoryAlloc,
        Error_Mem_Timeout,
    }

    public enum ScanOptions : uint
    {
        Raw = 0x0,
        Archive = 0x1,
        Email = 0x2,
        Ole2 = 0x4,
        BlockEncrypted = 0x8,
        Html = 0x10,
        PortableExe = 0x20,
        BrokenBlock = 0x40,
        UrlInEmail = 0x80,
        MaxBlock = 0x100,
        Algorithmic = 0x200,
        Phishing_BlockSSL = 0x800, /* ssl mismatches, not ssl by itself*/
        Phishing_BlockCloak = 0x1000,
        Elf = 0x2000,
        Pdf = 0x4000,
        Structured = 0x8000,
        StructuredSsnNormal = 0x10000,
        StructuredSsnStripped = 0x20000,
        PartialMessage = 0x40000,
        HeuristicPrecedence = 0x80000,
        Macro = 0x100000,
        AllMatch = 0x200000,
        InternalCollectSHA = 0x80000000,
        StandardOption = (Archive | Email | Ole2 | Pdf | Html | PortableExe | Algorithmic | Elf)

    }
}