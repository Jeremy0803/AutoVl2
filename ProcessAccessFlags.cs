// Decompiled with JetBrains decompiler
// Type: dorajx2.ProcessAccessFlags
// Assembly: T2Auto, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3D2B1643-7C06-428B-9BDA-29369F42091D
// Assembly location: C:\Users\itoutsource06\Desktop\AutoT2\Auto Jx2\T2Auto.exe

using System;

namespace dorajx2
{
  [Flags]
  public enum ProcessAccessFlags : uint
  {
    Terminate = 1,
    CreateThread = 2,
    VirtualMemoryOperation = 8,
    VirtualMemoryRead = 16, // 0x00000010
    VirtualMemoryWrite = 32, // 0x00000020
    DuplicateHandle = 64, // 0x00000040
    CreateProcess = 128, // 0x00000080
    SetQuota = 256, // 0x00000100
    SetInformation = 512, // 0x00000200
    QueryInformation = 1024, // 0x00000400
    QueryLimitedInformation = 4096, // 0x00001000
    Synchronize = 1048576, // 0x00100000
    All = 2035711, // 0x001F0FFF
  }
}
