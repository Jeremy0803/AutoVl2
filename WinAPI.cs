// Decompiled with JetBrains decompiler
// Type: dorajx2.WinAPI
// Assembly: T2Auto, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3D2B1643-7C06-428B-9BDA-29369F42091D
// Assembly location: C:\Users\itoutsource06\Desktop\AutoT2\Auto Jx2\T2Auto.exe

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Management;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

namespace dorajx2
{
  public class WinAPI
  {
    public static float Distance(float posX1, float posY1, float posX2, float posY2)
    {
      return Convert.ToSingle(Math.Sqrt(Math.Pow((double) posX2 - (double) posX1, 2.0) + Math.Pow((double) posY2 - (double) posY1, 2.0)));
    }

    public static string getSN()
    {
      string str = string.Empty;
      ManagementScope scope = new ManagementScope("\\\\" + Environment.MachineName + "\\root\\cimv2");
      scope.Connect();
      foreach (PropertyData property in new ManagementObject(scope, new ManagementPath("Win32_BaseBoard.Tag=\"Base Board\""), new ObjectGetOptions()).Properties)
      {
        if (property.Name == "SerialNumber")
          str = string.Format("{0,-25}", (object) Convert.ToString(property.Value));
      }
      return str;
    }

    public static string GetCPUId2()
    {
      string str = string.Empty;
      ManagementScope scope = new ManagementScope("\\\\" + Environment.MachineName + "\\root\\cimv2");
      scope.Connect();
      foreach (PropertyData property in new ManagementObject(scope, new ManagementPath("Win32_BaseBoard.Tag=\"Base Board\""), new ObjectGetOptions()).Properties)
      {
        if (property.Name == "Name")
          str = string.Format("{0,-25}", (object) Convert.ToString(property.Value));
      }
      return str;
    }

    public static string GetCPUId()
    {
      ManagementObject managementObject = new ManagementObject("win32_logicaldisk.deviceid=\"C:\"");
      managementObject.Get();
      return managementObject["VolumeSerialNumber"].ToString();
    }

    public static bool WriteString(IntPtr handle, int address, string value)
    {
      int lpNumberOfBytesWritten = 0;
      byte[] bytes = Encoding.Default.GetBytes(value + "\0");
      return WinAPI.WriteProcessMemory(handle, (uint) address, bytes, bytes.Length, ref lpNumberOfBytesWritten);
    }

    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern bool WriteProcessMemory(
      IntPtr hProcess,
      uint lpBaseAddress,
      byte[] lpBuffer,
      int dwSize,
      ref int lpNumberOfBytesWritten);

    [DllImport("athook.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    public static extern uint GetMsg();

    [DllImport("athook.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    public static extern int InjectDll(IntPtr hwnd);

    [DllImport("athook.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    public static extern int UnmapDll(IntPtr hwnd);

    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern bool ReadProcessMemory(
      IntPtr hProcess,
      uint lpBaseAddress,
      [Out] byte[] lpBuffer,
      int dwSize,
      IntPtr lpNumberOfBytesRead);

    public static IntPtr ReadProcessMemoryIntPtr(IntPtr hProcess, uint lpBaseAddress)
    {
      byte[] lpBuffer = new byte[4];
      WinAPI.ReadProcessMemory(hProcess, lpBaseAddress, lpBuffer, lpBuffer.Length, IntPtr.Zero);
      return (IntPtr) ((long) BitConverter.ToUInt32(lpBuffer, 0));
    }

    public static string ReadProcessMemoryString(IntPtr hProcess, uint lpBaseAddress, int size)
    {
      byte[] numArray = new byte[size];
      WinAPI.ReadProcessMemory(hProcess, lpBaseAddress, numArray, size, IntPtr.Zero);
      return Encoding.Default.GetString(numArray, 0, size).Split(new char[1])[0];
    }

    public static uint ReadProcessMemoryUint(IntPtr hProcess, uint lpBaseAddress)
    {
      byte[] lpBuffer = new byte[4];
      WinAPI.ReadProcessMemory(hProcess, lpBaseAddress, lpBuffer, lpBuffer.Length, IntPtr.Zero);
      return BitConverter.ToUInt32(lpBuffer, 0);
    }

    public static int ReadProcessMemoryInt(IntPtr hProcess, uint lpBaseAddress)
    {
      byte[] lpBuffer = new byte[4];
      WinAPI.ReadProcessMemory(hProcess, lpBaseAddress, lpBuffer, lpBuffer.Length, IntPtr.Zero);
      return BitConverter.ToInt32(lpBuffer, 0);
    }

    public static byte[] ReadProcessMemoryArrBytes(IntPtr hProcess, uint lpBaseAddress, int size)
    {
      byte[] lpBuffer = new byte[size];
      WinAPI.ReadProcessMemory(hProcess, lpBaseAddress, lpBuffer, size, IntPtr.Zero);
      return lpBuffer;
    }

    public static byte[] ReadProcessMemoryArrBytes(IntPtr hProcess, IntPtr lpBaseAddress, int size)
    {
      byte[] lpBuffer = new byte[size];
      WinAPI.ReadProcessMemory(hProcess, (uint) (int) lpBaseAddress, lpBuffer, size, IntPtr.Zero);
      return lpBuffer;
    }

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    public static extern IntPtr SendMessage(
      IntPtr hWnd,
      uint msg,
      IntPtr wParam,
      uint lParam);

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    public static extern IntPtr SendMessage(
      IntPtr hWnd,
      uint msg,
      IntPtr wParam,
      StringBuilder lParam);

    public static IntPtr SendMessage(IntPtr hWnd, uint msg, uint wParam, uint lParam)
    {
      return WinAPI.SendMessage(hWnd, msg, (IntPtr) ((long) wParam), lParam);
    }

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool PostMessage(IntPtr hWnd, uint msg, IntPtr wParam, uint lParam);

    public static bool PostMessage(IntPtr hWnd, uint msg, uint wParam, uint lParam)
    {
      return WinAPI.PostMessage(hWnd, msg, (IntPtr) ((long) wParam), lParam);
    }

    [DllImport("user32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool SendMessage(IntPtr hWnd, uint msg, int wParam, int lParam);

    [DllImport("user32.dll")]
    public static extern bool IsWindowVisible(IntPtr hWnd);

    [DllImport("user32.dll")]
    public static extern bool IsWindow(IntPtr hWnd);

    [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
    [SuppressUnmanagedCodeSecurity]
    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern bool CloseHandle(IntPtr hObject);

    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern IntPtr OpenProcess(
      ProcessAccessFlags processAccess,
      bool bInheritHandle,
      int processId);

    public static IntPtr OpenProcess(Process proc, ProcessAccessFlags flags)
    {
      return WinAPI.OpenProcess(flags, false, proc.Id);
    }

    [DllImport("user32.dll")]
    public static extern bool SetForegroundWindow(IntPtr hWnd);

    [DllImport("kernel32.dll")]
    public static extern uint SetThreadExecutionState(uint esFlags);

    [DllImport("user32.dll")]
    public static extern bool ShowWindow(IntPtr hWnd, WinAPI.ShowWindowCommands nCmdShow);

    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern bool TerminateProcess(IntPtr hProcess, int uExitCode);

    [DllImport("kernel32.dll")]
    public static extern uint GetLastError();

    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool EnumWindows(WinAPI.EnumWindowsProc lpEnumFunc, IntPtr lParam);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern int InternalGetWindowText(
      IntPtr hWnd,
      StringBuilder lpString,
      int nMaxCount);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

    [DllImport("user32.dll", SetLastError = true)]
    public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

    [DllImport("user32.dll", SetLastError = true)]
    private static extern IntPtr GetWindow(IntPtr hWnd, WinAPI.GetWindowType uCmd);

    [DllImport("kernel32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool GetProcessTimes(
      IntPtr hProcess,
      out long lpCreationTime,
      out long lpExitTime,
      out long lpKernelTime,
      out long lpUserTime);

    public static ProcessJx2[] GetListjx2()
    {
      List<ProcessJx2> _list = new List<ProcessJx2>();
      WinAPI.EnumWindows((WinAPI.EnumWindowsProc) ((hwnd, param) =>
      {
        if (WinAPI.GetWindow(hwnd, WinAPI.GetWindowType.GwOwner) == IntPtr.Zero)
        {
          StringBuilder lpString = new StringBuilder(100);
          WinAPI.InternalGetWindowText(hwnd, lpString, 100);
          if (lpString.ToString().Contains("Vâ L©m 2 ()"))
          {
            uint lpdwProcessId;
            int windowThreadProcessId = (int) WinAPI.GetWindowThreadProcessId(hwnd, out lpdwProcessId);
            ProcessJx2 processJx2 = new ProcessJx2()
            {
              hWnd = hwnd,
              PId = (int) lpdwProcessId
            };
            IntPtr num = WinAPI.OpenProcess(ProcessAccessFlags.All, false, (int) lpdwProcessId);
            long lpCreationTime = 0;
            long lpExitTime;
            long lpKernelTime;
            long lpUserTime;
            if (num != IntPtr.Zero && WinAPI.GetProcessTimes(num, out lpCreationTime, out lpExitTime, out lpKernelTime, out lpUserTime))
            {
              processJx2.StartTime = lpCreationTime;
              WinAPI.CloseHandle(num);
              _list.Add(processJx2);
            }
          }
        }
        return true;
      }), IntPtr.Zero);
      _list.Sort();
      return _list.ToArray();
    }

    public static IntPtr getmodule(int pid)
    {
      foreach (Process process in Process.GetProcessesByName("so2game"))
      {
        if (process.Id == pid)
        {
          foreach (ProcessModule module in (ReadOnlyCollectionBase) process.Modules)
          {
            if (module.ModuleName.ToLower().Contains("engine.dll"))
              return module.BaseAddress;
          }
        }
      }
      return IntPtr.Zero;
    }

    public static IntPtr getmodule(IntPtr hWnd, string module)
    {
      foreach (Process process in Process.GetProcessesByName("so2game"))
      {
        if (process.MainWindowHandle == hWnd)
        {
          foreach (ProcessModule module1 in (ReadOnlyCollectionBase) process.Modules)
          {
            if (module1.ModuleName.ToLower().Contains(module.ToLower()))
              return module1.BaseAddress;
          }
        }
      }
      return IntPtr.Zero;
    }

    public static uint getmodule()
    {
      foreach (Process process in Process.GetProcessesByName("so2game"))
      {
        foreach (ProcessModule module in (ReadOnlyCollectionBase) process.Modules)
        {
          if (module.ModuleName.ToLower().Contains("engine.dll"))
            return (uint) (int) module.BaseAddress;
        }
      }
      return 0;
    }

    public enum ShowWindowCommands
    {
      Hide = 0,
      Normal = 1,
      ShowMinimized = 2,
      Maximize = 3,
      ShowMaximized = 3,
      ShowNoActivate = 4,
      Show = 5,
      Minimize = 6,
      ShowMinNoActive = 7,
      ShowNa = 8,
      Restore = 9,
      ShowDefault = 10, // 0x0000000A
      ForceMinimize = 11, // 0x0000000B
    }

    public delegate bool EnumWindowsProc(IntPtr hwnd, IntPtr lParam);

    private enum GetWindowType : uint
    {
      GwHwndfirst,
      GwHwndlast,
      GwHwndnext,
      GwHwndprev,
      GwOwner,
      GwChild,
      GwEnabledpopup,
    }

    public enum Keyvisual : uint
    {
      WM_SENDTEXT = 12, // 0x0000000C
      WM_KEYDOWN = 256, // 0x00000100
      WM_KEYUP = 257, // 0x00000101
      WM_CHAR = 258, // 0x00000102
    }

    public enum keyflag
    {
      NULL = 0,
      KEY_LBUTTON = 1,
      KEY_RBUTTON = 2,
      KEY_CANCEL = 3,
      KEY_MBUTTON = 4,
      KEY_BACK = 8,
      KEY_TAB = 9,
      KEY_CLEAR = 12, // 0x0000000C
      KEY_RETURN = 13, // 0x0000000D
      KEY_SHIFT = 16, // 0x00000010
      KEY_CONTROL = 17, // 0x00000011
      KEY_MENU = 18, // 0x00000012
      KEY_PAUSE = 19, // 0x00000013
      KEY_CAPITAL = 20, // 0x00000014
      KEY_ESCAPE = 27, // 0x0000001B
      KEY_SPACE = 32, // 0x00000020
      KEY_PRIOR = 33, // 0x00000021
      KEY_NEXT = 34, // 0x00000022
      KEY_END = 35, // 0x00000023
      KEY_HOME = 36, // 0x00000024
      KEY_LEFT = 37, // 0x00000025
      KEY_UP = 38, // 0x00000026
      KEY_RIGHT = 39, // 0x00000027
      KEY_DOWN = 40, // 0x00000028
      KEY_SELECT = 41, // 0x00000029
      KEY_PRINT = 42, // 0x0000002A
      KEY_EXECUTE = 43, // 0x0000002B
      KEY_SNAPSHOT = 44, // 0x0000002C
      KEY_INSERT = 45, // 0x0000002D
      KEY_DELETE = 46, // 0x0000002E
      KEY_HELP = 47, // 0x0000002F
      KEY_0 = 48, // 0x00000030
      KEY_1 = 49, // 0x00000031
      KEY_2 = 50, // 0x00000032
      KEY_3 = 51, // 0x00000033
      KEY_4 = 52, // 0x00000034
      KEY_5 = 53, // 0x00000035
      KEY_6 = 54, // 0x00000036
      KEY_7 = 55, // 0x00000037
      KEY_8 = 56, // 0x00000038
      KEY_9 = 57, // 0x00000039
      KEY_A = 65, // 0x00000041
      KEY_B = 66, // 0x00000042
      KEY_C = 67, // 0x00000043
      KEY_D = 68, // 0x00000044
      KEY_E = 69, // 0x00000045
      KEY_F = 70, // 0x00000046
      KEY_G = 71, // 0x00000047
      KEY_H = 72, // 0x00000048
      KEY_I = 73, // 0x00000049
      KEY_J = 74, // 0x0000004A
      KEY_K = 75, // 0x0000004B
      KEY_L = 76, // 0x0000004C
      KEY_M = 77, // 0x0000004D
      KEY_N = 78, // 0x0000004E
      KEY_O = 79, // 0x0000004F
      KEY_P = 80, // 0x00000050
      KEY_Q = 81, // 0x00000051
      KEY_R = 82, // 0x00000052
      KEY_S = 83, // 0x00000053
      KEY_T = 84, // 0x00000054
      KEY_U = 85, // 0x00000055
      KEY_V = 86, // 0x00000056
      KEY_W = 87, // 0x00000057
      KEY_X = 88, // 0x00000058
      KEY_Y = 89, // 0x00000059
      KEY_Z = 90, // 0x0000005A
      KEY_NUMPAD0 = 96, // 0x00000060
      KEY_NUMPAD1 = 97, // 0x00000061
      KEY_NUMPAD2 = 98, // 0x00000062
      KEY_NUMPAD3 = 99, // 0x00000063
      KEY_NUMPAD4 = 100, // 0x00000064
      KEY_NUMPAD5 = 101, // 0x00000065
      KEY_NUMPAD6 = 102, // 0x00000066
      KEY_NUMPAD7 = 103, // 0x00000067
      KEY_NUMPAD8 = 104, // 0x00000068
      KEY_NUMPAD9 = 105, // 0x00000069
      KEY_SEPARATOR = 108, // 0x0000006C
      KEY_SUBTRACT = 109, // 0x0000006D
      KEY_DECIMAL = 110, // 0x0000006E
      KEY_DIVIDE = 111, // 0x0000006F
      KEY_F1 = 112, // 0x00000070
      KEY_F2 = 113, // 0x00000071
      KEY_F3 = 114, // 0x00000072
      KEY_F4 = 115, // 0x00000073
      KEY_F5 = 116, // 0x00000074
      KEY_F6 = 117, // 0x00000075
      KEY_F7 = 118, // 0x00000076
      KEY_F8 = 119, // 0x00000077
      KEY_F9 = 120, // 0x00000078
      KEY_F10 = 121, // 0x00000079
      KEY_F11 = 122, // 0x0000007A
      KEY_F12 = 123, // 0x0000007B
      KEY_SCROLL = 145, // 0x00000091
      KEY_LSHIFT = 160, // 0x000000A0
      KEY_RSHIFT = 161, // 0x000000A1
      KEY_LCONTROL = 162, // 0x000000A2
      KEY_RCONTROL = 163, // 0x000000A3
      KEY_LMENU = 164, // 0x000000A4
      KEY_RMENU = 165, // 0x000000A5
      KEY_PLUS = 187, // 0x000000BB
      KEY_COMMA = 188, // 0x000000BC
      KEY_MINUS = 189, // 0x000000BD
      KEY_PERIOD = 190, // 0x000000BE
      KEY_PLAY = 250, // 0x000000FA
      KEY_ZOOM = 251, // 0x000000FB
    }
  }
}
