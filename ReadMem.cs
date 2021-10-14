// Decompiled with JetBrains decompiler
// Type: dorajx2.ReadMem
// Assembly: T2Auto, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3D2B1643-7C06-428B-9BDA-29369F42091D
// Assembly location: C:\Users\itoutsource06\Desktop\AutoT2\Auto Jx2\T2Auto.exe

using System;
using System.Collections.Generic;
using System.Linq;

namespace dorajx2
{
  public class ReadMem : WinAPI
  {
    public static uint AddressPlayer(IntPtr hProcess)
    {
      uint num1 = WinAPI.ReadProcessMemoryUint(hProcess, 12334344U);
      uint lpBaseAddress = WinAPI.ReadProcessMemoryUint(hProcess, num1 + 3592912U);
      uint num2 = WinAPI.ReadProcessMemoryUint(hProcess, lpBaseAddress);
      uint num3 = WinAPI.ReadProcessMemoryUint(hProcess, num2 + 4U);
      return WinAPI.ReadProcessMemoryUint(hProcess, num3 + 248U);
    }

    public static uint MenuID(IntPtr hProcess)
    {
      uint num1 = WinAPI.ReadProcessMemoryUint(hProcess, 8883004U);
      uint num2 = WinAPI.ReadProcessMemoryUint(hProcess, num1 + 76U);
      return WinAPI.ReadProcessMemoryUint(hProcess, num2 + 304U);
    }

    public static uint AddressItemLocation(IntPtr hProcess)
    {
      uint num1 = WinAPI.ReadProcessMemoryUint(hProcess, 12334344U);
      uint lpBaseAddress = WinAPI.ReadProcessMemoryUint(hProcess, num1 + 3592912U);
      uint num2 = WinAPI.ReadProcessMemoryUint(hProcess, lpBaseAddress);
      return WinAPI.ReadProcessMemoryUint(hProcess, num2 + 4U);
    }

    public static uint AddressItemRac(IntPtr hProcess)
    {
      uint num1 = WinAPI.ReadProcessMemoryUint(hProcess, 8837316U);
      uint num2 = WinAPI.ReadProcessMemoryUint(hProcess, num1 + 2793484U);
      return WinAPI.ReadProcessMemoryUint(hProcess, num2 + 92U) + 2024U;
    }

    public static List<Player.Item> GetItemList(IntPtr hProcess)
    {
      List<Player.Item> source = new List<Player.Item>();
      uint num1 = ReadMem.AddressItemLocation(hProcess);
      uint num2 = WinAPI.ReadProcessMemoryUint(hProcess, 12334344U);
      uint lpBaseAddress = WinAPI.ReadProcessMemoryUint(hProcess, num2 + 3592956U);
      uint num3 = WinAPI.ReadProcessMemoryUint(hProcess, lpBaseAddress);
      int num4 = 0;
      for (int index = 0; index < 257; ++index)
      {
        uint num5 = (uint) (index * 4);
        uint num6 = WinAPI.ReadProcessMemoryUint(hProcess, num3 + num5);
        WinAPI.ReadProcessMemoryArrBytes(hProcess, num6 + 130U, 216);
        WinAPI.ReadProcessMemoryArrBytes(hProcess, num6 + 300U, 216);
        WinAPI.ReadProcessMemoryArrBytes(hProcess, num6 + 300U, 216);
        WinAPI.ReadProcessMemoryArrBytes(hProcess, num6 + 400U, 216);
        byte[] numArray1 = WinAPI.ReadProcessMemoryArrBytes(hProcess, num6 + 2360U, 8);
        byte[] numArray2 = WinAPI.ReadProcessMemoryArrBytes(hProcess, num6 + 2460U, 216);
        string unicode = CFont.TCVN3ToUnicode(WinAPI.ReadProcessMemoryString(hProcess, num6 + 4392U, 44));
        uint num7 = WinAPI.ReadProcessMemoryUint(hProcess, num6 + 4U);
        uint num8 = WinAPI.ReadProcessMemoryUint(hProcess, num6 + 8U);
        uint num9 = WinAPI.ReadProcessMemoryUint(hProcess, num6 + 114U);
        if (num7 != 0U && unicode != "")
        {
          int int32_1;
          int int32_2;
          int int32_3;
          while (true)
          {
            byte[] numArray3 = WinAPI.ReadProcessMemoryArrBytes(hProcess, num1 + (uint) (1152 + num4 * 20), 20);
            int int32_4 = BitConverter.ToInt32(numArray3, 4);
            int32_1 = BitConverter.ToInt32(numArray3, 8);
            int32_2 = BitConverter.ToInt32(numArray3, 12);
            int32_3 = BitConverter.ToInt32(numArray3, 16);
            if ((long) int32_4 != (long) num8)
              ++num4;
            else
              break;
          }
          num4 = 0;
          WinAPI.ReadProcessMemoryArrBytes(hProcess, num6 + 1240U, 8);
          WinAPI.ReadProcessMemoryArrBytes(hProcess, num6 + 12U, 8);
          WinAPI.ReadProcessMemoryArrBytes(hProcess, num6 + 16U, 8);
          WinAPI.ReadProcessMemoryArrBytes(hProcess, num6 + 1640U, 8);
          source.Add(new Player.Item()
          {
            Name = unicode.TrimEnd().Replace("ThiƠt", "Thiết"),
            id = num7,
            cot = (uint) int32_2,
            hang = (uint) int32_3,
            type = (uint) int32_1,
            soluong = num9,
            chisoitem = numArray2[8].ToString(),
            offset = num5,
            docuonghoa = (int) numArray1[4]
          });
        }
      }
      return source.OrderBy<Player.Item, string>((Func<Player.Item, string>) (z => z.Name)).ToList<Player.Item>();
    }

    public static List<Player.NPCinfo> GetNPCList(IntPtr hProcess)
    {
      List<Player.NPCinfo> npCinfoList = new List<Player.NPCinfo>();
      uint num1 = WinAPI.ReadProcessMemoryUint(hProcess, 12334344U);
      uint lpBaseAddress = WinAPI.ReadProcessMemoryUint(hProcess, num1 + 3592916U);
      uint num2 = WinAPI.ReadProcessMemoryUint(hProcess, lpBaseAddress);
      for (int index = 0; index < 257; ++index)
      {
        uint num3 = WinAPI.ReadProcessMemoryUint(hProcess, num2 + (uint) (index * 4));
        string unicode = CFont.TCVN3ToUnicode(WinAPI.ReadProcessMemoryString(hProcess, num3 + 132U, 44));
        uint num4 = WinAPI.ReadProcessMemoryUint(hProcess, num3 + 4U);
        uint num5 = WinAPI.ReadProcessMemoryUint(hProcess, num3 + 264U);
        uint num6 = WinAPI.ReadProcessMemoryUint(hProcess, num3 + 252U);
        uint num7 = WinAPI.ReadProcessMemoryUint(hProcess, num3 + 8260U);
        uint num8 = WinAPI.ReadProcessMemoryUint(hProcess, num3 + 8264U);
        uint num9 = WinAPI.ReadProcessMemoryUint(hProcess, num3 + 3748U);
        if (num4 != 0U && unicode != "")
          npCinfoList.Add(new Player.NPCinfo()
          {
            Name = unicode,
            id = num4,
            type = num5,
            status = num6,
            postx = num7,
            posty = num8,
            cosu = num9
          });
      }
      return npCinfoList;
    }

    public static void KsTui(Client client)
    {
      Player player = client.player;
      uint num1 = WinAPI.ReadProcessMemoryUint(player.HProcess, 12338440U);
      uint lpBaseAddress = WinAPI.ReadProcessMemoryUint(player.HProcess, num1 + 2562484U);
      uint num2 = WinAPI.ReadProcessMemoryUint(player.HProcess, lpBaseAddress);
      for (int index = 0; index < 257; ++index)
      {
        uint num3 = WinAPI.ReadProcessMemoryUint(player.HProcess, num2 + (uint) (index * 4));
        string unicode = CFont.TCVN3ToUnicode(WinAPI.ReadProcessMemoryString(player.HProcess, num3 + 68U, 44));
        WinAPI.ReadProcessMemoryUint(player.HProcess, num3 + 4U);
        uint num4 = WinAPI.ReadProcessMemoryUint(player.HProcess, num3 + 196U);
        if (!unicode.Contains("Túi trái cây") || num4 == 0U || num4 == 5U)
          ;
      }
    }

    public static uint DiemTu(IntPtr hProcess)
    {
      uint num1 = WinAPI.ReadProcessMemoryUint(hProcess, 12562512U);
      uint lpBaseAddress = WinAPI.ReadProcessMemoryUint(hProcess, num1 + 3592928U);
      uint num2 = WinAPI.ReadProcessMemoryUint(hProcess, lpBaseAddress);
      uint num3 = WinAPI.ReadProcessMemoryUint(hProcess, num2 + 4U);
      return WinAPI.ReadProcessMemoryUint(hProcess, num3 + 15444U);
    }

    public static uint Idskill(IntPtr hProcess)
    {
      uint num1 = WinAPI.ReadProcessMemoryUint(hProcess, 12558416U);
      uint lpBaseAddress = WinAPI.ReadProcessMemoryUint(hProcess, num1 + 3592912U);
      uint num2 = WinAPI.ReadProcessMemoryUint(hProcess, lpBaseAddress);
      uint num3 = WinAPI.ReadProcessMemoryUint(hProcess, num2 + 4U);
      return WinAPI.ReadProcessMemoryUint(hProcess, num3 + 15612U);
    }

    public static uint Lvskill(IntPtr hProcess)
    {
      uint num1 = WinAPI.ReadProcessMemoryUint(hProcess, 12558416U);
      uint lpBaseAddress = WinAPI.ReadProcessMemoryUint(hProcess, num1 + 3592912U);
      uint num2 = WinAPI.ReadProcessMemoryUint(hProcess, lpBaseAddress);
      uint num3 = WinAPI.ReadProcessMemoryUint(hProcess, num2 + 4U);
      return WinAPI.ReadProcessMemoryUint(hProcess, num3 + 15616U);
    }

    public static List<Player.Menu> GetMenuNameVN(IntPtr hProcess)
    {
      List<Player.Menu> menuList = new List<Player.Menu>();
      for (uint index = 0; index < 50U; ++index)
      {
        uint num1 = WinAPI.ReadProcessMemoryUint(hProcess, 12446132U);
        uint num2 = WinAPI.ReadProcessMemoryUint(hProcess, num1 + 112U);
        uint num3 = WinAPI.ReadProcessMemoryUint(hProcess, num2 + 108U);
        uint num4 = WinAPI.ReadProcessMemoryUint(hProcess, num3 + 108U);
        uint num5 = WinAPI.ReadProcessMemoryUint(hProcess, num4 + 108U);
        uint num6 = WinAPI.ReadProcessMemoryUint(hProcess, num5 + 112U);
        uint num7 = WinAPI.ReadProcessMemoryUint(hProcess, num6 + 204U);
        uint num8 = WinAPI.ReadProcessMemoryUint(hProcess, num7 + 4U * index);
        string unicode = CFont.TCVN3ToUnicode(WinAPI.ReadProcessMemoryString(hProcess, num8 + 56U, 44));
        if (unicode != "")
          menuList.Add(new Player.Menu() { Name = unicode });
      }
      return menuList;
    }

    public static List<Player.Item> GetItemListChest(IntPtr hProcess)
    {
      List<Player.Item> source = new List<Player.Item>();
      uint num1 = WinAPI.ReadProcessMemoryUint(hProcess, 268655096U);
      uint num2 = WinAPI.ReadProcessMemoryUint(hProcess, num1 + 28U);
      uint num3 = WinAPI.ReadProcessMemoryUint(hProcess, num2 + 40U);
      uint num4 = WinAPI.ReadProcessMemoryUint(hProcess, num3 + 748U);
      uint num5 = WinAPI.ReadProcessMemoryUint(hProcess, num4 + 8U);
      uint num6 = WinAPI.ReadProcessMemoryUint(hProcess, 12562512U);
      uint lpBaseAddress = WinAPI.ReadProcessMemoryUint(hProcess, num6 + 2562524U);
      uint num7 = WinAPI.ReadProcessMemoryUint(hProcess, lpBaseAddress);
      int num8 = 0;
      for (int index = 0; index < 257; ++index)
      {
        WinAPI.ReadProcessMemoryUint(hProcess, (uint) ((int) num5 + 1152 + index * 4));
        uint num9 = WinAPI.ReadProcessMemoryUint(hProcess, num7 + (uint) (index * 4));
        string unicode = CFont.TCVN3ToUnicode(WinAPI.ReadProcessMemoryString(hProcess, num9 + 2420U, 44));
        uint num10 = WinAPI.ReadProcessMemoryUint(hProcess, num7 + 4U);
        if (num10 != 0U && unicode != "")
        {
          byte[] numArray = WinAPI.ReadProcessMemoryArrBytes(hProcess, num5 + (uint) (1152 + num8 * 20), 20);
          BitConverter.ToInt32(numArray, 4);
          int int32_1 = BitConverter.ToInt32(numArray, 8);
          int int32_2 = BitConverter.ToInt32(numArray, 12);
          int int32_3 = BitConverter.ToInt32(numArray, 16);
          ++num8;
          source.Add(new Player.Item()
          {
            Name = unicode,
            id = num10,
            cot = (uint) int32_2,
            hang = (uint) int32_3,
            type = (uint) int32_1
          });
        }
      }
      return source.OrderBy<Player.Item, string>((Func<Player.Item, string>) (z => z.Name)).ToList<Player.Item>();
    }

    public new static float Distance(float posX1, float posY1, float posX2, float posY2)
    {
      return Convert.ToSingle(Math.Sqrt(Math.Pow((double) posX2 - (double) posX1, 2.0) + Math.Pow((double) posY2 - (double) posY1, 2.0)));
    }

    public static uint BaseMenu(IntPtr hProcess)
    {
      return WinAPI.ReadProcessMemoryUint(hProcess, 12446132U);
    }

    public static uint BaseServer(IntPtr hProcess)
    {
      return WinAPI.ReadProcessMemoryUint(hProcess, 8840692U);
    }

    public static uint GetBaseNhanVat96(IntPtr hProcess)
    {
      uint num = WinAPI.ReadProcessMemoryUint(hProcess, 8875944U);
      return WinAPI.ReadProcessMemoryUint(hProcess, num + 18044U);
    }

    public static uint BaseDong(IntPtr hProcess)
    {
      return WinAPI.ReadProcessMemoryUint(hProcess, 10917676U);
    }

    public static uint GetTotalDialogLines(IntPtr hProcess)
    {
      return WinAPI.ReadProcessMemoryUint(hProcess, 10917676U);
    }

    public static void ChonMenu(IntPtr hwnd, IntPtr HProcess, string Menu)
    {
      uint num1 = ReadMem.BaseDong(HProcess);
      for (uint menuxId = 0; menuxId < num1; ++menuxId)
      {
        uint num2 = WinAPI.ReadProcessMemoryUint(HProcess, 12446132U);
        uint num3 = WinAPI.ReadProcessMemoryUint(HProcess, num2 + 112U);
        uint num4 = WinAPI.ReadProcessMemoryUint(HProcess, num3 + 108U);
        uint num5 = WinAPI.ReadProcessMemoryUint(HProcess, num4 + 108U);
        uint num6 = WinAPI.ReadProcessMemoryUint(HProcess, num5 + 108U);
        uint num7 = WinAPI.ReadProcessMemoryUint(HProcess, num6 + 112U);
        uint num8 = WinAPI.ReadProcessMemoryUint(HProcess, num7 + 204U);
        uint num9 = WinAPI.ReadProcessMemoryUint(HProcess, num8 + 4U * menuxId);
        string unicode = CFont.TCVN3ToUnicode(WinAPI.ReadProcessMemoryString(HProcess, num9 + 56U, 1000));
        if (unicode != "" && unicode == Menu)
          HookCall.SelectMenu96(hwnd, menuxId, ReadMem.GetMenu96(HProcess));
      }
    }

    public static string GetMenuStringName(IntPtr hProcess)
    {
      string str = "";
      for (uint index = 0; index < 50U; ++index)
      {
        uint num1 = WinAPI.ReadProcessMemoryUint(hProcess, 12446132U);
        uint num2 = WinAPI.ReadProcessMemoryUint(hProcess, num1 + 112U);
        uint num3 = WinAPI.ReadProcessMemoryUint(hProcess, num2 + 108U);
        uint num4 = WinAPI.ReadProcessMemoryUint(hProcess, num3 + 108U);
        uint num5 = WinAPI.ReadProcessMemoryUint(hProcess, num4 + 108U);
        uint num6 = WinAPI.ReadProcessMemoryUint(hProcess, num5 + 112U);
        uint num7 = WinAPI.ReadProcessMemoryUint(hProcess, num6 + 204U);
        uint num8 = WinAPI.ReadProcessMemoryUint(hProcess, num7 + 4U * index);
        string unicode = CFont.TCVN3ToUnicode(WinAPI.ReadProcessMemoryString(hProcess, num8 + 56U, 44));
        if (unicode != "")
          str += unicode;
      }
      return str;
    }

    public static string GetMenuString(IntPtr hProcess)
    {
      uint num = WinAPI.ReadProcessMemoryUint(hProcess, 12446132U);
      string str = "";
      for (uint index = 0; index < 257U; ++index)
      {
        string unicode = CFont.TCVN3ToUnicode(WinAPI.ReadProcessMemoryString(hProcess, num + 1668U + index, 1));
        if (unicode != "")
          str += unicode;
      }
      return str.ToLower().Replace("\x0002", "").Replace("\x0003", "").Replace("ÿ", "").Replace("\n", "").Replace("\n", "").Replace("ấu Đồng".ToLower(), "Tiểu đồng".ToLower()).Replace("Xi Hỏa đường chủ".ToLower(), "Xi Hỏa đàn chủ".ToLower()).Replace("đà nhung thủ thao".ToLower(), "hộ uyển lông lạc đà".ToLower()).Replace("Nạn dân Bính".ToLower(), "Nạn dân_Bính".ToLower()).Replace("Nạn dân Đinh".ToLower(), "Nạn dân_Đinh".ToLower()).Replace("Nạn dân Giáp".ToLower(), "Nạn dân_Giáp".ToLower());
    }

    public static uint GetMenu96(IntPtr hProcess)
    {
      uint num = WinAPI.ReadProcessMemoryUint(hProcess, 12688788U);
      return WinAPI.ReadProcessMemoryUint(hProcess, num + 3292U);
    }

    public static bool FindItem(IntPtr hwnd, string itemName, int Location)
    {
      foreach (Player.Item obj in (IEnumerable<Player.Item>) ReadMem.GetItemList(hwnd).OrderByDescending<Player.Item, uint>((Func<Player.Item, uint>) (x => x.id)))
      {
        if (obj.Name == itemName && (long) obj.type == (long) Location)
          return true;
      }
      return false;
    }

    public static PlayerEnum.TeamStatus GroupStatus(IntPtr hProcess, uint address)
    {
      switch (WinAPI.ReadProcessMemoryArrBytes(hProcess, address + 12393U, 1)[0])
      {
        case 33:
          return PlayerEnum.TeamStatus.CoTeam;
        case 41:
          return PlayerEnum.TeamStatus.TeamLeader;
        default:
          return PlayerEnum.TeamStatus.KhongCoTeam;
      }
    }
  }
}
