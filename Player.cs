// Decompiled with JetBrains decompiler
// Type: dorajx2.Player
// Assembly: T2Auto, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3D2B1643-7C06-428B-9BDA-29369F42091D
// Assembly location: C:\Users\itoutsource06\Desktop\AutoT2\Auto Jx2\T2Auto.exe

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace dorajx2
{
  public class Player
  {
    public string Msg = "";
    public List<Player.Item> sellitemlist = new List<Player.Item>();
    public List<Player.Item> itemlistgd = new List<Player.Item>();
    public List<Player.NPCinfo> sellnpclist = new List<Player.NPCinfo>();
    public List<Player.NPCinfo> buffnpclist = new List<Player.NPCinfo>();
    public List<Player.NPCinfo> buffnpclistcosu = new List<Player.NPCinfo>();
    public List<Player.NPCinfo> buffnpclistkill = new List<Player.NPCinfo>();
    public List<Player.Item> setthaydo = new List<Player.Item>();
    public List<Player.Item> setthaydo2 = new List<Player.Item>();
    public List<Player.Item> setthaydo3 = new List<Player.Item>();
    public List<Player.Item> setthaydo4 = new List<Player.Item>();
    public Player.TrongCayinfo TrongCaylist = new Player.TrongCayinfo();
    public List<Player.NPCinfo> TaoNhomlist = new List<Player.NPCinfo>();
    public List<Player.Item> chatlist = new List<Player.Item>();
    public Player.TaoPT PT = new Player.TaoPT();
    public Player.BomMau SDBomMau = new Player.BomMau();
    public Player.PhoBan DiPhoBan = new Player.PhoBan();

    public int HpPercent()
    {
      return (int) ((double) this.Hp() / (double) this.HpMax() * 100.0);
    }

    public int MpPercent()
    {
      return (int) ((double) this.Mp() / (double) this.MpMax() * 100.0);
    }

    public IntPtr HProcess { get; set; }

    public IntPtr hWnd { get; set; }

    public int TexX { get; set; }

    public int TexY { get; set; }

    public int buffchedo { get; set; }

    public int buffchedo1 { get; set; }

    public int buffchedo2 { get; set; }

    public int TexMap { get; set; }

    public uint Address { get; set; }

    public string loichat { get; set; }

    public bool isChat { get; set; }

    public bool isxdame { get; set; }

    public bool minhgiaoanco { get; set; }

    public bool isthaydo { get; set; }

    public bool isSell { get; set; }

    public int skill1 { get; set; }

    public int skill2 { get; set; }

    public int skill3 { get; set; }

    public int skillcosu { get; set; }

    public bool isCosu { get; set; }

    public bool isKillquai { get; set; }

    public bool isGiaodich { get; set; }

    public bool isBuff { get; set; }

    public string Passruong { get; set; }

    public bool isBuffALL { get; set; }

    public bool isKsTui { get; set; }

    public bool isUseSkillCs { get; set; }

    public bool isBaoDanh { get; set; }

    public bool isTrongCay { get; set; }

    public bool isNhatAll { get; set; }

    public bool isUyHoLenh { get; set; }

    public string cbuyholenh { get; set; }

    public string tinhtrangnv { get; set; }

    public bool isTaoNhom { get; set; }

    public bool isNhanLM { get; set; }

    public bool isTruongNhom { get; set; }

    public bool isTheoSau { get; set; }

    public string TheoSau_Name { get; set; }

    public bool AutoPK { get; set; }

    public bool isDBCTC { get; set; }

    public string NPCBB_Name { get; set; }

    public string CTP_Name { get; set; }

    public int TimeDelayChat { get; set; }

    public string _Name { get; set; }

    public string cobophimanco { get; set; }

    public string cobophimanco1 { get; set; }

    public string cobophim1 { get; set; }

    public string cobophimxdame { get; set; }

    public int phatdongxdame { get; set; }

    public int xdame { get; set; }

    public int txdame { get; set; }

    public string cobophim2 { get; set; }

    public string cobophim3 { get; set; }

    public string cobophim4 { get; set; }

    public int timechat { get; set; }

    public bool isPhoBan { get; set; }

    public bool isThuongHoi { get; set; }

    public bool isBomMau { get; set; }

    public string playergd { get; set; }

    public string Itemgd { get; set; }

    public bool ischetao { get; set; }

    public string namechetao { get; set; }

    public int idchetao { get; set; }

    public string IDmap { get; set; }

    public Player(IntPtr hProcess, uint addr)
    {
      this.HProcess = hProcess;
      this.Address = addr;
      if (Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\Player"))
        return;
      Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "\\Player");
    }

    public Point ToaDo()
    {
      byte[] numArray = WinAPI.ReadProcessMemoryArrBytes(this.HProcess, this.Address + 8260U, 8);
      return new Point()
      {
        X = BitConverter.ToInt32(numArray, 0),
        Y = BitConverter.ToInt32(numArray, 4)
      };
    }

    public void SaveData()
    {
      this._Name = this.Name();
      File.WriteAllText(Directory.GetCurrentDirectory() + "\\Player\\" + this.Name() + ".json", JsonConvert.SerializeObject((object) this));
    }

    public int status()
    {
      return WinAPI.ReadProcessMemoryInt(this.HProcess, this.Address + 252U);
    }

    public int id()
    {
      return WinAPI.ReadProcessMemoryInt(this.HProcess, this.Address + 4U);
    }

    public int Hp()
    {
      return WinAPI.ReadProcessMemoryInt(this.HProcess, this.Address + 764U);
    }

    public int Mp()
    {
      return WinAPI.ReadProcessMemoryInt(this.HProcess, this.Address + 816U);
    }

    public int postx()
    {
      return WinAPI.ReadProcessMemoryInt(this.HProcess, this.Address + 8260U);
    }

    public int posty()
    {
      return WinAPI.ReadProcessMemoryInt(this.HProcess, this.Address + 8264U);
    }

    public int DiemLuyen()
    {
      return WinAPI.ReadProcessMemoryInt(this.HProcess, this.Address + 15444U);
    }

    public uint Iscosu()
    {
      return WinAPI.ReadProcessMemoryUint(this.HProcess, this.Address + 3748U);
    }

    public uint IsOnHorse()
    {
      return WinAPI.ReadProcessMemoryUint(this.HProcess, this.Address + 12664U);
    }

    public int Map()
    {
      return WinAPI.ReadProcessMemoryInt(this.HProcess, this.Address + 76U);
    }

    public int HePhai()
    {
      return (int) WinAPI.ReadProcessMemoryArrBytes(this.HProcess, this.Address + 170U, 1)[0];
    }

    public uint TuKhi()
    {
      return WinAPI.ReadProcessMemoryUint(this.HProcess, this.Address + 1512U);
    }

    public int EXP()
    {
      return WinAPI.ReadProcessMemoryInt(this.HProcess, this.Address + 13168U);
    }

    public int HpMax()
    {
      return WinAPI.ReadProcessMemoryInt(this.HProcess, this.Address + 760U);
    }

    public int MpMax()
    {
      return WinAPI.ReadProcessMemoryInt(this.HProcess, this.Address + 812U);
    }

    public string Name()
    {
      this._Name = CFont.TCVN3ToUnicode(WinAPI.ReadProcessMemoryString(this.HProcess, this.Address + 132U, 44));
      return CFont.TCVN3ToUnicode(WinAPI.ReadProcessMemoryString(this.HProcess, this.Address + 132U, 44));
    }

    public class Item
    {
      public string Duocpham { get; set; }

      public uint id { get; set; }

      public string Name { get; set; }

      public string chisoitem { get; set; }

      public int itemdongVK1 { get; set; }

      public int itemdongVK2 { get; set; }

      public int docuonghoa { get; set; }

      public int itemdongVK3 { get; set; }

      public int itemdongVK01 { get; set; }

      public int itemdongVK02 { get; set; }

      public int itemdongVK03 { get; set; }

      public uint cot { get; set; }

      public uint hang { get; set; }

      public uint type { get; set; }

      public uint soluong { get; set; }

      public string thanh { get; set; }

      public int cap { get; set; }

      public string capdo { get; set; }

      public string phuluc { get; set; }

      public string MTdong1 { get; set; }

      public string MTdong2 { get; set; }

      public string MTdong3 { get; set; }

      public string MTdong4 { get; set; }

      public string Cap { get; set; }

      public string noicong { get; set; }

      public string ngoaicong { get; set; }

      public uint offset { get; set; }

      public int itemdong1 { get; set; }

      public int itemdong2 { get; set; }

      public int itemdong3 { get; set; }

      public int itemdong4 { get; set; }

      public int itemdong5 { get; set; }

      public int itemdong6 { get; set; }

      public int itemdong1_O { get; set; }

      public int itemdong2_O { get; set; }

      public int itemdong3_O { get; set; }

      public int itemdong4_O { get; set; }

      public int itemdong5_O { get; set; }

      public int itemdong6_O { get; set; }
    }

    public class NameBuff
    {
      public string Name { get; set; }
    }

    public class NPCinfo
    {
      public Point ToaDo { get; set; }

      public uint cosu { get; set; }

      public uint id { get; set; }

      public uint map { get; set; }

      public uint idgd { get; set; }

      public uint postx { get; set; }

      public uint posty { get; set; }

      public string Name { get; set; }

      public uint status { get; set; }

      public uint type { get; set; }

      public uint address { get; set; }
    }

    public class TrongCayinfo
    {
      public bool HG { get; set; }

      public bool BNN { get; set; }

      public bool BNL { get; set; }
    }

    public class Menu
    {
      public string Name { get; set; }
    }

    public class TaoPT
    {
      public string nametheosau { get; set; }
    }

    public class BomMau
    {
      public string Do { get; set; }

      public string Xanh { get; set; }

      public string Vang { get; set; }

      public uint status { get; set; }

      public bool isdo { get; set; }

      public bool isxanh { get; set; }

      public bool isvang { get; set; }

      public int dopercent { get; set; }

      public int xanhpercent { get; set; }

      public int vangpercent { get; set; }
    }

    public class PhoBan
    {
      public bool isbatdaudi { get; set; }

      public string Name { get; set; }

      public string Map { get; set; }

      public string loaipb { get; set; }

      public string thanhvien { get; set; }

      public int KieuDiAi { get; set; }

      public int CheDo { get; set; }

      public bool isRuongDong { get; set; }

      public bool isRuongBac { get; set; }

      public bool isRuongVangMP { get; set; }

      public bool isRuongVangTP { get; set; }

      public bool isLatBaiMP { get; set; }

      public bool isLatBaiTP { get; set; }

      public bool isBanRac { get; set; }

      public int Speed { get; set; }
    }
  }
}
