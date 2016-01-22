using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibClamAV
{
    public enum DatabaseOptions : uint
    {
        Phishing = 0x2,
        PhishingURL = 0x8,
        PUA = 0x10,
        LoadWithoutUnpacking = 0x20,
        Official = 0x40,
        PUAMode = 0x80,
        PUAInclude = 0x100,
        PUAExclude = 0x200,
        Compiled = 0x400,
        Directory = 0x800,
        OfficialOnly = 0x1000,
        Bytecode = 0x2000,
        Signed = 0x4000,
        BytecodeUnsigned = 0x8000,
        StandardOption = (LoadWithoutUnpacking |Phishing | PhishingURL | Bytecode)
    }

    class Database
    {
        
    }
}
