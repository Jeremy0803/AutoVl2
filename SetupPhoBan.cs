// Decompiled with JetBrains decompiler
// Type: dorajx2.SetupPhoBan
// Assembly: T2Auto, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3D2B1643-7C06-428B-9BDA-29369F42091D
// Assembly location: C:\Users\itoutsource06\Desktop\AutoT2\Auto Jx2\T2Auto.exe

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;

namespace dorajx2
{
  public class SetupPhoBan
  {
    public static int BaseMenu = VNG.BASEMENU;
    public string[] NPCLSB = new string[22]
    {
      "Song Tiên Hô Diên Chước",
      "Báo Tử Đầu Lâm Xung",
      "Nhất Trượng Thanh Hổ Tam Nương",
      "Hành Giả Võ Tòng",
      "Thanh Diện Thú Dương Trí",
      "Hắc Toàn Phong Lý Quỳ",
      "Tri Đa Tinh Ngô Dụng",
      "Ma Vân Kim Sí Âu Bằng",
      "Bệnh Quan Sác Dương Hùng",
      "Đại Đao Quan Thắng",
      "Tích Lịch Hỏa Tần Minh",
      "Song Thương Tướng Đổng Bình",
      "Nhập Vân Long Công Tôn Thắng",
      "Tiểu Tuyền Phong Sài Tiến",
      "Hỏa Nhãn Toan Nghê Trịnh Phi",
      "Cập Thời Vũ Tống Giang",
      "Hoa Hòa Thượng Lỗ Trí Thâm",
      "Cửu Văn Long Sử Tiến",
      "Túy Bán Tiên Phong Nhất Phàm",
      "Phanh Mệnh Tam Lang Thạch Tú",
      "Kim Rương",
      "Rương Hảo Hán"
    };
    private Client client;
    private Thread _dlsb;
    private Thread _spamn;
    private Thread _nhat;
    private Thread _kill;
    private Thread _buffcosu;
    private Thread _buffnm;

    public SetupPhoBan(Client _client)
    {
      this.client = _client;
    }

    public void CaiDatHoatDong(
      Pho_Ban danhphoban,
      Point point,
      string loaiHd,
      List<Client> _listClient)
    {
      if (this.client == null || !this.client.IsChecked)
        return;
      this.client.player.DiPhoBan.Name = loaiHd;
      int x = point.X - danhphoban.Width;
      Point point1 = point;
      danhphoban.Location = new Point(x, point1.Y);
      danhphoban.Show();
    }

    public void DanhPhoBan()
    {
      if (this.client == null || !this.client.IsChecked || !this.client.player.isPhoBan)
      {
        if (this._dlsb == null)
          return;
        this._dlsb.Abort();
        this._dlsb = (Thread) null;
      }
      else if (this._dlsb != null && this._dlsb.IsAlive && this._dlsb.ThreadState != ThreadState.Aborted)
        ;
    }

    public void AutoPK()
    {
      if (this.client == null || !this.client.IsChecked || !this.client.player.AutoPK)
      {
        if (this._buffnm == null)
          return;
        this._buffnm.Abort();
        this._buffnm = (Thread) null;
      }
      else if (this._buffnm == null || !this._buffnm.IsAlive || this._buffnm.ThreadState == ThreadState.Aborted)
      {
        this._buffnm = new Thread(new ThreadStart(this.ComboPK));
        this._buffnm.Start();
      }
    }

    public void buff()
    {
      if (this.client == null || !this.client.IsChecked || !this.client.player.isBuff)
      {
        if (this._buffnm == null)
          return;
        this._buffnm.Abort();
        this._buffnm = (Thread) null;
      }
      else if (this._buffnm == null || !this._buffnm.IsAlive || this._buffnm.ThreadState == ThreadState.Aborted)
      {
        this._buffnm = new Thread(new ThreadStart(this.buffnmk));
        this._buffnm.Start();
      }
    }

    public void buffCoSu()
    {
      if (this.client == null || !this.client.IsChecked || !this.client.player.isCosu)
      {
        if (this._buffcosu == null)
          return;
        this._buffcosu.Abort();
        this._buffcosu = (Thread) null;
      }
      else if (this._buffcosu == null || !this._buffcosu.IsAlive || this._buffcosu.ThreadState == ThreadState.Aborted)
      {
        this._buffcosu = new Thread(new ThreadStart(this.buffcosu));
        this._buffcosu.Start();
      }
    }

    public void rao()
    {
      if (this.client == null || !this.client.IsChecked || !this.client.player.isChat)
      {
        if (this._spamn == null)
          return;
        this._spamn.Abort();
        this._spamn = (Thread) null;
      }
      else if (this._spamn == null || !this._spamn.IsAlive || this._spamn.ThreadState == ThreadState.Aborted)
      {
        this._spamn = new Thread(new ThreadStart(this.chatchit));
        this._spamn.Start();
      }
    }

    public void kill()
    {
      if (this.client == null || !this.client.IsChecked || !this.client.player.isChat)
      {
        if (this._kill == null)
          return;
        this._kill.Abort();
        this._kill = (Thread) null;
      }
      else if (this._kill == null || !this._kill.IsAlive || this._kill.ThreadState == ThreadState.Aborted)
      {
        this._kill = new Thread(new ThreadStart(this.killnpc));
        this._kill.Start();
      }
    }

    public void pickup()
    {
      if (this.client == null || !this.client.IsChecked || !this.client.player.isNhatAll)
      {
        if (this._nhat == null)
          return;
        this._nhat.Abort();
        this._nhat = (Thread) null;
      }
      else if (this._nhat == null || !this._nhat.IsAlive || this._nhat.ThreadState == ThreadState.Aborted)
      {
        this._nhat = new Thread(new ThreadStart(this.nhatitem));
        this._nhat.Start();
      }
    }

    public void nhatitem()
    {
      while (true)
      {
        Thread.Sleep(250);
        Player player = this.client.player;
        if (player.isNhatAll && this.client.IsChecked)
        {
          int lpNumberOfBytesWritten = 0;
          for (int index = 0; index < 50; ++index)
          {
            IntPtr num1 = IntPtr.Add(WinAPI.ReadProcessMemoryIntPtr(player.HProcess, VNG.BASEADRESS), 3824700);
            IntPtr num2 = IntPtr.Add(WinAPI.ReadProcessMemoryIntPtr(player.HProcess, (uint) (int) num1), 92);
            IntPtr pointer = IntPtr.Add(WinAPI.ReadProcessMemoryIntPtr(player.HProcess, (uint) (int) num2), 2024 * index);
            string str = WinAPI.ReadProcessMemoryString(player.HProcess, (uint) (int) IntPtr.Add(pointer, 64), 32);
            WinAPI.ReadProcessMemoryInt(player.HProcess, (uint) (int) IntPtr.Add(pointer, 108));
            int num3 = WinAPI.ReadProcessMemoryInt(player.HProcess, (uint) (int) IntPtr.Add(pointer, 0));
            WinAPI.ReadProcessMemoryInt(player.HProcess, (uint) (int) IntPtr.Add(pointer, 7));
            int num4 = WinAPI.ReadProcessMemoryInt(player.HProcess, (uint) (int) IntPtr.Add(pointer, 12));
            if (str != "")
            {
              IntPtr num5 = IntPtr.Add(WinAPI.ReadProcessMemoryIntPtr(player.HProcess, 11964080U), 3592920);
              IntPtr num6 = IntPtr.Add(WinAPI.ReadProcessMemoryIntPtr(player.HProcess, (uint) (int) num5), 0);
              IntPtr num7 = IntPtr.Add(WinAPI.ReadProcessMemoryIntPtr(player.HProcess, (uint) (int) num6), 4);
              IntPtr num8 = IntPtr.Add(WinAPI.ReadProcessMemoryIntPtr(player.HProcess, (uint) (int) num7), 248);
              IntPtr num9 = IntPtr.Add(WinAPI.ReadProcessMemoryIntPtr(player.HProcess, (uint) (int) num8), 3004);
              IntPtr num10 = IntPtr.Add(WinAPI.ReadProcessMemoryIntPtr(player.HProcess, (uint) (int) num8), 3008);
              WinAPI.WriteProcessMemory(player.HProcess, (uint) (int) num9, BitConverter.GetBytes(num3), BitConverter.GetBytes(num3).Length, ref lpNumberOfBytesWritten);
              WinAPI.WriteProcessMemory(player.HProcess, (uint) (int) num10, BitConverter.GetBytes(num4), BitConverter.GetBytes(num4).Length, ref lpNumberOfBytesWritten);
            }
          }
        }
      }
    }

    public void chatchit()
    {
      Player player;
      while (true)
      {
        Thread.Sleep(250);
        player = this.client.player;
        if (this.client.IsChecked && player.isChat)
        {
          switch (new Random().Next(1, 6))
          {
            case 1:
              goto label_2;
            case 2:
              goto label_3;
            case 3:
              goto label_4;
            case 4:
              goto label_5;
            case 5:
              goto label_6;
            case 6:
              goto label_7;
            default:
              Thread.Sleep(player.TimeDelayChat * 1000);
              break;
          }
        }
      }
label_2:
      string str1 = "<bclr=Red>";
      HookCall.Doscrip(player.hWnd, "Chat(\"GÇn\",\"" + str1 + player.loichat + "\")");
      Thread.Sleep(7000);
      return;
label_3:
      string str2 = "<bclr=Blue>";
      HookCall.Doscrip(player.hWnd, "Chat(\"GÇn\",\"" + str2 + player.loichat + "\")");
      Thread.Sleep(7000);
      return;
label_4:
      string str3 = "<color=yellow>";
      HookCall.Doscrip(player.hWnd, "Chat(\"GÇn\",\"" + str3 + player.loichat + "\")");
      Thread.Sleep(7000);
      return;
label_5:
      string str4 = "<color=green>";
      HookCall.Doscrip(player.hWnd, "Chat(\"GÇn\",\"" + str4 + player.loichat + "\")");
      Thread.Sleep(7000);
      return;
label_6:
      string str5 = "<bclr=Pink>";
      HookCall.Doscrip(player.hWnd, "Chat(\"GÇn\",\"" + str5 + player.loichat + "\")");
      Thread.Sleep(7000);
      return;
label_7:
      string str6 = "<color=gold>";
      HookCall.Doscrip(player.hWnd, "Chat(\"GÇn\",\"" + str6 + player.loichat + "\")");
      Thread.Sleep(7000);
    }

    public void buffnmk()
    {
      while (true)
      {
        Thread.Sleep(250);
        Player player = this.client.player;
        if (player.isBuff && this.client.IsChecked && player.HePhai() == 8)
        {
          if (player.IsOnHorse() != 1U)
          {
            HookCall.XuongNgua(player.hWnd, player.Address, 6U);
            Thread.Sleep(100);
          }
          this.client.Buffnpc();
        }
      }
    }

    public void buffcosu()
    {
      while (true)
      {
        Thread.Sleep(250);
        Player player = this.client.player;
        if (player.isCosu && this.client.IsChecked)
        {
          if (player.IsOnHorse() != 1U)
          {
            HookCall.XuongNgua(player.hWnd, player.Address, 6U);
            Thread.Sleep(100);
          }
          if (player.buffchedo == 0)
          {
            foreach (Player.NPCinfo npc in ReadMem.GetNPCList(player.HProcess))
            {
              if (npc.type == 5U)
              {
                if (player.Iscosu() < 10000U)
                {
                  HookCall.Buffnpc(player.hWnd, (uint) player.id(), (uint) player.skillcosu, player.Address);
                  Thread.Sleep(100);
                }
                if (npc.Name != player.Name() && npc.cosu < 1000U && (long) npc.id != (long) player.id() && Convert.ToInt32(ReadMem.Distance((float) player.postx(), (float) player.posty(), (float) npc.postx, (float) npc.posty)) < 1200)
                {
                  HookCall.Buffnpc(player.hWnd, npc.id, (uint) player.skillcosu, player.Address);
                  Thread.Sleep(200);
                }
              }
            }
          }
          else
          {
            foreach (Player.NPCinfo npc in ReadMem.GetNPCList(player.HProcess))
            {
              if (npc.type == 5U)
              {
                if (player.Iscosu() < 10000U)
                {
                  HookCall.Buffnpc(player.hWnd, (uint) player.id(), (uint) player.skillcosu, player.Address);
                  Thread.Sleep(100);
                }
                foreach (Player.NPCinfo npCinfo in player.buffnpclistcosu)
                {
                  if (npCinfo.Name == npc.Name && (long) npc.id != (long) player.id() && npc.cosu < 1000U && Convert.ToInt32(ReadMem.Distance((float) player.postx(), (float) player.posty(), (float) npc.postx, (float) npc.posty)) < 1200)
                  {
                    HookCall.Buffnpc(player.hWnd, npc.id, (uint) player.skillcosu, player.Address);
                    Thread.Sleep(100);
                  }
                }
              }
            }
          }
        }
      }
    }

    public void killnpc()
    {
      while (true)
      {
        Thread.Sleep(250);
        Player player = this.client.player;
        if (player.isKillquai && this.client.IsChecked)
        {
          if (player.IsOnHorse() > 0U)
          {
            HookCall.XuongNgua(player.hWnd, player.Address, 6U);
            Thread.Sleep(100);
          }
          if (player.buffchedo1 == 0 && player.buffchedo2 == 0)
          {
            this.client.killquai3((uint) player.skill1);
            Thread.Sleep(200);
            if (player.status() == 0)
            {
              this.client.killquai3((uint) player.skill2);
              Thread.Sleep(200);
            }
            if (player.status() == 0)
            {
              this.client.killquai3((uint) player.skill3);
              Thread.Sleep(200);
            }
          }
          if (player.buffchedo1 == 0 && player.buffchedo2 == 1)
          {
            this.client.killquai4((uint) player.skill1);
            Thread.Sleep(200);
            if (player.status() == 0)
            {
              this.client.killquai4((uint) player.skill2);
              Thread.Sleep(200);
            }
            if (player.status() == 0)
            {
              this.client.killquai4((uint) player.skill3);
              Thread.Sleep(200);
            }
          }
          if (player.buffchedo1 == 1 && player.buffchedo2 == 0)
          {
            foreach (Player.NPCinfo npCinfo in player.buffnpclistkill)
            {
              this.client.killquai(npCinfo.Name, (uint) player.skill1);
              Thread.Sleep(200);
              if (player.status() == 0)
              {
                this.client.killquai(npCinfo.Name, (uint) player.skill2);
                Thread.Sleep(200);
              }
              if (player.status() == 0)
              {
                this.client.killquai(npCinfo.Name, (uint) player.skill3);
                Thread.Sleep(200);
              }
            }
          }
          if (player.buffchedo1 == 1 && player.buffchedo2 == 1)
          {
            foreach (Player.NPCinfo npCinfo in player.buffnpclistkill)
            {
              this.client.killquai2(npCinfo.Name, (uint) player.skill1);
              Thread.Sleep(200);
            }
          }
        }
      }
    }

    public void ComboPK()
    {
      while (true)
      {
        Thread.Sleep(250);
        Player player = this.client.player;
        if (!player.AutoPK || !this.client.IsChecked || !player.minhgiaoanco)
          ;
      }
    }

    private int XacDinhAiTnt(Point l)
    {
      int num1 = l.X / 256;
      int num2 = l.Y / 512;
      int num3;
      if (num1 < 176 || num1 > 187 || num2 < 177 || num2 > 184)
      {
        if (num1 >= 198 && num1 <= 208 && num2 >= 178 && num2 <= 185)
        {
          if (l.X < 53094 && l.Y < 93897 && l.X > 50600 && l.Y > 91271)
            return 2;
        }
        else
        {
          if (num1 >= 198 && num1 <= 208 && num2 >= 197 && num2 <= 203)
            return 3;
          if (num1 >= 149 && num1 <= 165 && num2 >= 210 && num2 <= 220)
            return 4;
          if (num1 >= 172 && num1 <= 184 && num2 >= 214 && num2 <= 222)
            return 5;
          if (num1 >= 196 && num1 <= 212 && num2 >= 210 && num2 <= 222)
            return 6;
        }
        num3 = 0;
      }
      else
        num3 = 1;
      return num3;
    }
  }
}
