// Decompiled with JetBrains decompiler
// Type: dorajx2.Client
// Assembly: T2Auto, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3D2B1643-7C06-428B-9BDA-29369F42091D
// Assembly location: C:\Users\itoutsource06\Desktop\AutoT2\Auto Jx2\T2Auto.exe

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace dorajx2
{
  public class Client
  {
    public int ProsX = 0;
    public int ProsY = 0;
    private int hKeyboardHook = 0;
    private bool isbatdau = true;
    public List<Thread> listthread = new List<Thread>();
    public int Pid;
    public Thread oPB;
    public uint _time;
    public Thread thread;
    public Thread trongcay;
    public Thread nhatall;
    public Thread chat;
    public Thread nmk;
    public int thutubuff;
    public SetupPhoBan setupPhoBan;
    public UyHoLenh uyHoLenh;
    private const int WH_KEYBOARD_LL = 13;
    private const int WM_KEYDOWN = 256;
    private const int WM_KEYUP = 257;
    private const int WM_SYSKEYDOWN = 260;
    private const int WM_SYSKEYUP = 261;
    private const byte VK_SHIFT = 16;
    private const byte VK_CONTROL = 17;
    private const byte VK_MENU = 18;
    private const byte VK_CAPITAL = 20;
    private const byte VK_NUMLOCK = 144;
    private static Client.HookProc KeyboardHookProcedure;

    public IntPtr hWnd { get; set; }

    public IntPtr Module { get; set; }

    public Player player { get; set; }

    public bool IsChecked { get; set; }

    public bool Exit { get; set; }

    public bool vip1 { get; set; }

    public bool vip2 { get; set; }

    public bool vip3 { get; set; }

    public string _licenseKey { get; set; }

    [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    private static extern int SetWindowsHookEx(
      int idHook,
      Client.HookProc lpfn,
      IntPtr hMod,
      int dwThreadId);

    [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    private static extern int UnhookWindowsHookEx(int idHook);

    [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    private static extern int CallNextHookEx(int idHook, int nCode, int wParam, IntPtr lParam);

    [DllImport("user32")]
    private static extern int ToAscii(
      int uVirtKey,
      int uScanCode,
      byte[] lpbKeyState,
      byte[] lpwTransKey,
      int fuState);

    [DllImport("user32")]
    private static extern int GetKeyboardState(byte[] pbKeyState);

    [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    private static extern short GetKeyState(int vKey);

    public void Start()
    {
      this.Start(true);
    }

    public void Start(bool InstallKeyboardHook)
    {
      if (!(this.hKeyboardHook == 0 & InstallKeyboardHook))
        return;
      Client.KeyboardHookProcedure = new Client.HookProc(this.KeyboardHookProc);
      this.hKeyboardHook = Client.SetWindowsHookEx(13, Client.KeyboardHookProcedure, Marshal.GetHINSTANCE(Assembly.GetExecutingAssembly().GetModules()[0]), 0);
      if (this.hKeyboardHook == 0)
      {
        Marshal.GetLastWin32Error();
        this.Stop(true, false);
      }
    }

    public void Stop()
    {
      this.Stop(true, true);
    }

    public void Stop(bool UninstallKeyboardHook, bool ThrowExceptions)
    {
      if (!((uint) this.hKeyboardHook > 0U & UninstallKeyboardHook))
        return;
      int num = Client.UnhookWindowsHookEx(this.hKeyboardHook);
      this.hKeyboardHook = 0;
      if (num == 0 & ThrowExceptions)
        throw new Win32Exception(Marshal.GetLastWin32Error());
    }

    private int KeyboardHookProc(int nCode, int wParam, IntPtr lParam)
    {
      bool flag = false;
      if (nCode >= 0)
      {
        Client.KeyboardHookStruct structure = (Client.KeyboardHookStruct) Marshal.PtrToStructure(lParam, typeof (Client.KeyboardHookStruct));
        if (wParam == 256 || wParam == 260)
        {
          Keys keyData = (Keys) (structure.vkCode | (((int) Client.GetKeyState(16) & 128) == 128 ? 65536 : 0) | (((int) Client.GetKeyState(17) & 128) == 128 ? 131072 : 0) | (((int) Client.GetKeyState(18) & 128) == 128 ? 18 : 0));
          Console.WriteLine((object) keyData);
          KeyEventArgs keyEventArgs = new KeyEventArgs(keyData);
          if (this.player.cobophimanco1 != null && keyEventArgs.KeyData.ToString() == this.player.cobophimanco1.ToString())
          {
            foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
            {
              if (npc.type == 5U && npc.status != 5U && npc.Name != this.player.Name())
                HookCall.Buffnpc(this.player.hWnd, npc.id, 590918U, this.player.Address);
            }
          }
          if (this.player.cobophim1 != null && keyEventArgs.KeyData.ToString() == this.player.cobophim1.ToString())
          {
            foreach (Player.Item obj1 in ReadMem.GetItemList(this.player.HProcess))
            {
              if (obj1.type == 2U)
              {
                foreach (Player.Item obj2 in this.player.setthaydo)
                {
                  if (obj2.Name == obj1.Name + obj1.chisoitem)
                  {
                    HookCall.PickNPutItem96(this.player.hWnd, 2U, obj1.cot, obj1.hang, 1U, 0U, 5U, ReadMem.AddressItemLocation(this.player.HProcess));
                    Thread.Sleep(50);
                    HookCall.UseItem96(this.player.hWnd, obj1.hang, obj1.cot);
                    break;
                  }
                }
              }
            }
          }
          if (this.player.cobophim2 != null && keyEventArgs.KeyData.ToString() == this.player.cobophim2.ToString())
          {
            foreach (Player.Item obj1 in ReadMem.GetItemList(this.player.HProcess))
            {
              if (obj1.type == 2U)
              {
                foreach (Player.Item obj2 in this.player.setthaydo2)
                {
                  if (obj2.Name == obj1.Name + obj1.chisoitem)
                  {
                    HookCall.PickNPutItem96(this.player.hWnd, 2U, obj1.cot, obj1.hang, 1U, 0U, 5U, ReadMem.AddressItemLocation(this.player.HProcess));
                    Thread.Sleep(50);
                    HookCall.UseItem96(this.player.hWnd, obj1.hang, obj1.cot);
                    break;
                  }
                }
              }
            }
          }
          if (this.player.cobophim3 != null && keyEventArgs.KeyData.ToString() == this.player.cobophim3.ToString())
          {
            foreach (Player.Item obj1 in ReadMem.GetItemList(this.player.HProcess))
            {
              if (obj1.type == 2U)
              {
                foreach (Player.Item obj2 in this.player.setthaydo3)
                {
                  if (obj2.Name == obj1.Name + obj1.chisoitem)
                  {
                    HookCall.PickNPutItem96(this.player.hWnd, 2U, obj1.cot, obj1.hang, 1U, 0U, 5U, ReadMem.AddressItemLocation(this.player.HProcess));
                    Thread.Sleep(50);
                    HookCall.UseItem96(this.player.hWnd, obj1.hang, obj1.cot);
                    break;
                  }
                }
              }
            }
          }
          if (this.player.cobophim4 != null && keyEventArgs.KeyData.ToString() == this.player.cobophim4.ToString())
          {
            foreach (Player.Item obj1 in ReadMem.GetItemList(this.player.HProcess))
            {
              if (obj1.type == 2U)
              {
                foreach (Player.Item obj2 in this.player.setthaydo4)
                {
                  if (obj2.Name == obj1.Name + obj1.chisoitem)
                  {
                    HookCall.PickNPutItem96(this.player.hWnd, 2U, obj1.cot, obj1.hang, 1U, 0U, 5U, ReadMem.AddressItemLocation(this.player.HProcess));
                    Thread.Sleep(50);
                    HookCall.UseItem96(this.player.hWnd, obj1.hang, obj1.cot);
                    break;
                  }
                }
              }
            }
          }
          if (this.player.cobophimxdame != null && keyEventArgs.KeyData.ToString() == this.player.cobophimxdame.ToString())
          {
            int int32_1 = Convert.ToInt32((uint) (this.player.postx() - 10));
            int int32_2 = Convert.ToInt32((uint) (this.player.posty() - 10));
            HookCall.skillxdame(this.player.hWnd, (uint) this.player.postx(), (uint) this.player.posty(), (uint) this.player.phatdongxdame, this.player.Address);
            Thread.Sleep(this.player.txdame);
            HookCall.LeftClick(this.player.hWnd, (uint) int32_1, (uint) int32_2, this.player.Address);
            HookCall.skillxdame(this.player.hWnd, (uint) this.player.postx(), (uint) this.player.posty(), (uint) this.player.xdame, this.player.Address);
            return 1;
          }
        }
      }
      if (flag)
        return 1;
      return Client.CallNextHookEx(this.hKeyboardHook, nCode, wParam, lParam);
    }

    public Client(IntPtr _hWnd, int pid, string lic)
    {
      this.hWnd = _hWnd;
      this.Pid = pid;
      IntPtr hProcess = WinAPI.OpenProcess(ProcessAccessFlags.All, false, pid);
      if (hProcess == IntPtr.Zero)
      {
        int num = (int) MessageBox.Show("Khong the doc duoc thong tin, chay lai auto voi quyen Admin", "Khong Auto duoc", MessageBoxButtons.OK);
      }
      else
      {
        this._licenseKey = lic;
        this.player = new Player(hProcess, ReadMem.AddressPlayer(hProcess));
        this.player.hWnd = _hWnd;
        this.setupPhoBan = new SetupPhoBan(this);
        this.uyHoLenh = new UyHoLenh(this);
        this.thread = new Thread(new ThreadStart(this.ThreadRunAutoClien));
        this.thread.IsBackground = true;
        this.thread.Start();
        this.listthread.Add(this.thread);
      }
    }

    public void ThreadRunAutoClien()
    {
      while (!this.Exit && WinAPI.IsWindow(this.hWnd))
      {
        this.player.Address = ReadMem.AddressPlayer(this.player.HProcess);
        if (this.player.Name() != "" && (uint) this.player.Hp() > 0U)
        {
          if (this.player.isSell && this.IsChecked && this.player.sellitemlist.Count > 0)
          {
            foreach (Player.Item obj1 in ReadMem.GetItemList(this.player.HProcess))
            {
              if (obj1.type == 2U)
              {
                foreach (Player.Item obj2 in this.player.sellitemlist)
                {
                  if (obj2.Name == obj1.Name)
                  {
                    HookCall.BanItem96(this.player.hWnd, obj1.id);
                    Thread.Sleep(20);
                    break;
                  }
                }
              }
            }
          }
          this.setupPhoBan.rao();
          if (this.IsChecked && this.player.isBomMau)
          {
            foreach (Player.Item obj in ReadMem.GetItemList(this.player.HProcess))
            {
              if (obj.type == 2U)
              {
                if (this.player.SDBomMau.isdo && this.player.HpPercent() < this.player.SDBomMau.dopercent && obj.Name == this.player.SDBomMau.Do)
                {
                  HookCall.UseItem96(this.player.hWnd, obj.hang, obj.cot);
                  Thread.Sleep(100);
                }
                if (this.player.SDBomMau.isxanh && this.player.MpPercent() < this.player.SDBomMau.xanhpercent && obj.Name == this.player.SDBomMau.Xanh)
                {
                  HookCall.UseItem96(this.player.hWnd, obj.hang, obj.cot);
                  Thread.Sleep(100);
                }
                if (this.player.SDBomMau.isvang && (this.player.HpPercent() < this.player.SDBomMau.vangpercent || this.player.MpPercent() < this.player.SDBomMau.vangpercent) && obj.Name == this.player.SDBomMau.Vang)
                {
                  HookCall.UseItem96(this.player.hWnd, obj.hang, obj.cot);
                  Thread.Sleep(100);
                }
              }
            }
          }
          if (this.player.isTaoNhom && this.player.status() == 0 && this.IsChecked)
          {
            foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
            {
              if (npc.Name == this.player.PT.nametheosau)
                HookCall.ShortMoveNPC(this.player.hWnd, npc.postx, npc.posty, this.player.Address);
            }
          }
          if (!this.player.isBuff || !this.IsChecked || (ulong) this._time % 15UL != 0UL)
            ;
          if (this.IsChecked)
            Thread.Sleep(10);
          if (this.IsChecked && this.player.isKsTui)
          {
            ReadMem.KsTui(this);
            Thread.Sleep(10);
          }
          if (this.IsChecked && this.player.isBaoDanh)
          {
            foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
              ;
          }
        }
        Thread.Sleep(1000);
      }
    }

    public void CoSu()
    {
      while (true)
      {
        this.setupPhoBan.buffcosu();
        Thread.Sleep(250);
      }
    }

    public void spam()
    {
      while (true)
        Thread.Sleep(250);
    }

    public void killplayer()
    {
      while (true)
      {
        this.setupPhoBan.killnpc();
        Thread.Sleep(250);
      }
    }

    public void AutoComBo()
    {
      while (true)
      {
        this.setupPhoBan.ComboPK();
        Thread.Sleep(250);
      }
    }

    public void pickupitem()
    {
      while (true)
      {
        this.setupPhoBan.pickup();
        Thread.Sleep(250);
      }
    }

    public void CodeUyHo()
    {
      Thread.Sleep(250);
    }

    public void killquai3(uint idskill)
    {
      foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
      {
        if (npc.type == 0U && npc.status != 5U)
        {
          if (Convert.ToInt32(ReadMem.Distance((float) this.player.postx(), (float) this.player.posty(), (float) npc.postx, (float) npc.posty)) < 100)
            HookCall.killboss(this.player.hWnd, npc.postx, npc.posty, idskill, this.player.Address);
          else if (this.player.status() == 0)
            HookCall.ShortMoveNPC(this.player.hWnd, npc.postx, npc.posty, this.player.Address);
        }
      }
    }

    public void killMGB()
    {
      foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
      {
        if (npc.type == 5U && npc.status != 5U && npc.Name != this.player.Name())
          HookCall.Buffnpc(this.player.hWnd, npc.id, 590918U, this.player.Address);
      }
    }

    public void killquai4(uint idskill)
    {
      foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
      {
        if (npc.type == 5U && npc.status != 5U)
        {
          if (Convert.ToInt32(ReadMem.Distance((float) this.player.postx(), (float) this.player.posty(), (float) npc.postx, (float) npc.posty)) < 100)
            HookCall.killboss(this.player.hWnd, npc.postx, npc.posty, idskill, this.player.Address);
          else if (this.player.status() == 0)
            HookCall.ShortMoveNPC(this.player.hWnd, npc.postx, npc.posty, this.player.Address);
        }
      }
    }

    public void killquai(string name, uint idskill)
    {
      foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
      {
        if (npc.type == 0U && npc.Name == name && npc.status != 5U)
          Convert.ToInt32(ReadMem.Distance((float) this.player.postx(), (float) this.player.posty(), (float) npc.postx, (float) npc.posty));
      }
    }

    public void killquai2(string name, uint idskill)
    {
      foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
      {
        if (npc.type == 5U && npc.Name == name && npc.status != 5U)
          Convert.ToInt32(ReadMem.Distance((float) this.player.postx(), (float) this.player.posty(), (float) npc.postx, (float) npc.posty));
      }
    }

    public void phobandhc()
    {
      while (true)
      {
        this.setupPhoBan.DanhPhoBan();
        Thread.Sleep(250);
      }
    }

    public void buffnmkpb()
    {
      while (true)
      {
        this.setupPhoBan.buff();
        Thread.Sleep(250);
      }
    }

    public void otrongcay()
    {
      while (this.player.isTrongCay)
      {
        List<Player.NPCinfo> npcList = ReadMem.GetNPCList(this.player.HProcess);
        bool hg = this.player.TrongCaylist.HG;
        bool bnn = this.player.TrongCaylist.BNN;
        bool bnl = this.player.TrongCaylist.BNL;
        if (!npcList.Exists((Predicate<Player.NPCinfo>) (x => x.Name.Contains(this.player.Name() + " trồng "))))
          ;
        Thread.Sleep(50);
        this.CloseMenu();
        Thread.Sleep(5000);
      }
    }

    public void onhatall()
    {
      while (this.player.isNhatAll)
        Thread.Sleep(100);
    }

    public void CloseMenu()
    {
      do
      {
        Thread.Sleep(100);
        WinAPI.PostMessage(this.player.hWnd, 256U, 13U, 0U);
      }
      while (ReadMem.BaseMenu(this.player.HProcess) > 0U);
    }

    public void Buffnpc()
    {
      switch (this.thutubuff)
      {
        case 0:
          HookCall.buffbanthan(this.player.hWnd, (uint) this.player.postx(), (uint) this.player.posty(), 262225U, this.player.Address);
          Thread.Sleep(50);
          if (this.player.status() != 0)
            break;
          this.thutubuff = 1;
          break;
        case 1:
          HookCall.buffbanthan(this.player.hWnd, (uint) this.player.postx(), (uint) this.player.posty(), 589907U, this.player.Address);
          Thread.Sleep(50);
          if (this.player.status() != 0)
            break;
          this.thutubuff = 2;
          break;
        case 2:
          HookCall.buffbanthan(this.player.hWnd, (uint) this.player.postx(), (uint) this.player.posty(), 327765U, this.player.Address);
          Thread.Sleep(50);
          if (this.player.status() != 0)
            break;
          this.thutubuff = 3;
          break;
        case 3:
          HookCall.buffbanthan(this.player.hWnd, (uint) this.player.postx(), (uint) this.player.posty(), 393303U, this.player.Address);
          Thread.Sleep(50);
          if (this.player.status() != 0)
            break;
          this.thutubuff = 4;
          break;
        case 4:
          HookCall.buffbanthan(this.player.hWnd, (uint) this.player.postx(), (uint) this.player.posty(), 393302U, this.player.Address);
          Thread.Sleep(50);
          if (this.player.status() != 0)
            break;
          this.thutubuff = 5;
          break;
        case 5:
          HookCall.buffbanthan(this.player.hWnd, (uint) this.player.postx(), (uint) this.player.posty(), 393300U, this.player.Address);
          Thread.Sleep(50);
          if (this.player.status() != 0)
            break;
          this.thutubuff = 6;
          break;
        case 6:
          HookCall.buffbanthan(this.player.hWnd, (uint) this.player.postx(), (uint) this.player.posty(), 393295U, this.player.Address);
          Thread.Sleep(50);
          if (this.player.status() != 0)
            break;
          for (int index = 0; index <= this.player.buffnpclist.Count; ++index)
          {
            int int32 = Convert.ToInt32(this.player.buffnpclist.Count);
            if (int32 == 0)
              this.thutubuff = 0;
            if (int32 == 1)
              this.thutubuff = 7;
            if (int32 == 2)
              this.thutubuff = 8;
            if (int32 == 3)
              this.thutubuff = 10;
            if (int32 == 4)
              this.thutubuff = 13;
            if (int32 == 5)
              this.thutubuff = 17;
            if (int32 == 6)
              this.thutubuff = 22;
            if (int32 == 7)
              this.thutubuff = 28;
            if (int32 == 8)
              this.thutubuff = 35;
            if (int32 == 9)
              this.thutubuff = 43;
            if (int32 == 10)
              this.thutubuff = 52;
            if (int32 == 11)
              this.thutubuff = 63;
            if (int32 == 12)
              this.thutubuff = 74;
            if (int32 == 13)
              this.thutubuff = 86;
            if (int32 == 14)
              this.thutubuff = 99;
            if (int32 == 15)
              this.thutubuff = 113;
          }
          break;
        case 7:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[0].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 0;
          break;
        case 8:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[0].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 9;
          break;
        case 9:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[1].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 0;
          break;
        case 10:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[0].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 11;
          break;
        case 11:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[1].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 12;
          break;
        case 12:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[2].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 0;
          break;
        case 13:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[0].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 14;
          break;
        case 14:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[1].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 15;
          break;
        case 15:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[2].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 16;
          break;
        case 16:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[3].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 0;
          break;
        case 17:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[0].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 18;
          break;
        case 18:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[1].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 19;
          break;
        case 19:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[2].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 20;
          break;
        case 20:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[3].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 21;
          break;
        case 21:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[4].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 0;
          break;
        case 22:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[0].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 23;
          break;
        case 23:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[1].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 24;
          break;
        case 24:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[2].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 25;
          break;
        case 25:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[3].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 26;
          break;
        case 26:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[4].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 27;
          break;
        case 27:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[5].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 0;
          break;
        case 28:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[0].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 29;
          break;
        case 29:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[1].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 30;
          break;
        case 30:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[2].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 31;
          break;
        case 31:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[3].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 32;
          break;
        case 32:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[4].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 33;
          break;
        case 33:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[5].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 34;
          break;
        case 34:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[6].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 0;
          break;
        case 35:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[0].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 36;
          break;
        case 36:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[1].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 37;
          break;
        case 37:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[2].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 38;
          break;
        case 38:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[3].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 39;
          break;
        case 39:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[4].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 40;
          break;
        case 40:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[5].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 41;
          break;
        case 41:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[6].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 42;
          break;
        case 42:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[7].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 0;
          break;
        case 43:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[0].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 44;
          break;
        case 44:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[1].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 45;
          break;
        case 45:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[2].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 46;
          break;
        case 46:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[3].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 47;
          break;
        case 47:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[4].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 48;
          break;
        case 48:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[5].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 49;
          break;
        case 49:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[6].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 50;
          break;
        case 50:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[7].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 51;
          break;
        case 51:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[8].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 0;
          break;
        case 52:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[0].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 53;
          break;
        case 53:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[1].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 54;
          break;
        case 54:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[2].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 55;
          break;
        case 55:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[3].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 56;
          break;
        case 56:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[4].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 57;
          break;
        case 57:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[5].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 58;
          break;
        case 58:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[6].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 59;
          break;
        case 59:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[7].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 60;
          break;
        case 61:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[8].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 62;
          break;
        case 62:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[9].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 0;
          break;
        case 63:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[0].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 64;
          break;
        case 64:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[1].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 65;
          break;
        case 65:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[2].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 66;
          break;
        case 66:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[3].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 67;
          break;
        case 67:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[4].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 68;
          break;
        case 68:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[5].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 69;
          break;
        case 69:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[6].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 70;
          break;
        case 70:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[7].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 71;
          break;
        case 71:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[8].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 72;
          break;
        case 72:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[9].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 73;
          break;
        case 73:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[10].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 0;
          break;
        case 74:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[0].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 75;
          break;
        case 75:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[1].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 76;
          break;
        case 76:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[2].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 77;
          break;
        case 77:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[3].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 78;
          break;
        case 78:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[4].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 79;
          break;
        case 79:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[5].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 80;
          break;
        case 80:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[6].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 81;
          break;
        case 81:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[7].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 82;
          break;
        case 82:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[8].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 83;
          break;
        case 83:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[9].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 84;
          break;
        case 84:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[10].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 85;
          break;
        case 85:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[11].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 0;
          break;
        case 86:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[0].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 87;
          break;
        case 87:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[1].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 88;
          break;
        case 88:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[2].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 89;
          break;
        case 89:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[3].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 90;
          break;
        case 90:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[4].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 91;
          break;
        case 91:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[5].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 92;
          break;
        case 92:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[6].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 93;
          break;
        case 93:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[7].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 94;
          break;
        case 94:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[8].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 95;
          break;
        case 95:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[9].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 96;
          break;
        case 96:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[10].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 97;
          break;
        case 97:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[11].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 98;
          break;
        case 98:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[12].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 0;
          break;
        case 99:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[0].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 100;
          break;
        case 100:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[1].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 101;
          break;
        case 101:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[2].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 102;
          break;
        case 102:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[3].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 103;
          break;
        case 103:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[4].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 104;
          break;
        case 104:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[5].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 105;
          break;
        case 105:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[6].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 106;
          break;
        case 106:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[7].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 107;
          break;
        case 107:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[8].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 108;
          break;
        case 108:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[9].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 109;
          break;
        case 109:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[10].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 110;
          break;
        case 110:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[11].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 111;
          break;
        case 111:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[12].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 112;
          break;
        case 112:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[13].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 0;
          break;
        case 113:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[0].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 114;
          break;
        case 114:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[1].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 115;
          break;
        case 115:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[2].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 116;
          break;
        case 116:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[3].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 117;
          break;
        case 117:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[4].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 118;
          break;
        case 118:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[5].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 119;
          break;
        case 119:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[6].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 120;
          break;
        case 120:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[7].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 121;
          break;
        case 121:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[8].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 122;
          break;
        case 122:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[9].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 123;
          break;
        case 123:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[10].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 124;
          break;
        case 124:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[11].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 125;
          break;
        case 125:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[12].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 126;
          break;
        case 126:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[13].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = (int) sbyte.MaxValue;
          break;
        case (int) sbyte.MaxValue:
          foreach (Player.NPCinfo npc in ReadMem.GetNPCList(this.player.HProcess))
          {
            if (npc.type == 5U && (this.player.buffnpclist[14].Name == npc.Name && (long) npc.id != (long) this.player.id()))
            {
              HookCall.Buffnpc(this.player.hWnd, npc.id, 262225U, this.player.Address);
              Thread.Sleep(100);
            }
          }
          if (this.player.status() != 0)
            break;
          this.thutubuff = 0;
          break;
      }
    }

    [StructLayout(LayoutKind.Sequential)]
    private class POINT
    {
      public int x;
      public int y;
    }

    [StructLayout(LayoutKind.Sequential)]
    private class MouseHookStruct
    {
      public Client.POINT pt;
      public int hwnd;
      public int wHitTestCode;
      public int dwExtraInfo;
    }

    [StructLayout(LayoutKind.Sequential)]
    private class MouseLLHookStruct
    {
      public Client.POINT pt;
      public int mouseData;
      public int flags;
      public int time;
      public int dwExtraInfo;
    }

    [StructLayout(LayoutKind.Sequential)]
    private class KeyboardHookStruct
    {
      public int vkCode;
      public int scanCode;
      public int flags;
      public int time;
      public int dwExtraInfo;
    }

    private delegate int HookProc(int nCode, int wParam, IntPtr lParam);
  }
}
