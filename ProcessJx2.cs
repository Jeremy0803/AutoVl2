// Decompiled with JetBrains decompiler
// Type: dorajx2.ProcessJx2
// Assembly: T2Auto, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3D2B1643-7C06-428B-9BDA-29369F42091D
// Assembly location: C:\Users\itoutsource06\Desktop\AutoT2\Auto Jx2\T2Auto.exe

using System;
using System.ComponentModel;

namespace dorajx2
{
  public class ProcessJx2 : IComparable
  {
    public IntPtr hWnd;
    public int PId;
    public long StartTime;

    public int CompareTo(object obj)
    {
      return DateTime.FromFileTime(this.StartTime).CompareTo(DateTime.FromFileTime(((ProcessJx2) obj).StartTime));
    }

    public void Kill()
    {
      if (!WinAPI.TerminateProcess(WinAPI.OpenProcess(ProcessAccessFlags.Terminate, true, this.PId), -1))
        throw new Win32Exception();
    }
  }
}
