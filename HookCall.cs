// Decompiled with JetBrains decompiler
// Type: dorajx2.HookCall
// Assembly: T2Auto, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3D2B1643-7C06-428B-9BDA-29369F42091D
// Assembly location: C:\Users\itoutsource06\Desktop\AutoT2\Auto Jx2\T2Auto.exe

using System;
using System.Text;

namespace dorajx2
{
  public class HookCall : WinAPI
  {
    public static string MsgScrip = "";
    public static uint Msg;

    public static void LatBai(IntPtr hWnd, uint the)
    {
      WinAPI.PostMessage(hWnd, HookCall.Msg, 1000U, 8020U);
      WinAPI.PostMessage(hWnd, HookCall.Msg, 1002U, the);
      WinAPI.PostMessage(hWnd, HookCall.Msg, 1001U, 0U);
    }

    public static void MoRuong(IntPtr hWnd, uint the)
    {
      WinAPI.PostMessage(hWnd, HookCall.Msg, 1000U, 8028U);
      WinAPI.PostMessage(hWnd, HookCall.Msg, 1002U, the);
      WinAPI.PostMessage(hWnd, HookCall.Msg, 1001U, 0U);
    }

    public static void MoveTo(IntPtr hWnd, uint posX, uint posY, uint mapID)
    {
      WinAPI.PostMessage(hWnd, HookCall.Msg, 1000U, 8000U);
      WinAPI.PostMessage(hWnd, HookCall.Msg, 1002U, posX * 256U);
      WinAPI.PostMessage(hWnd, HookCall.Msg, 1002U, posY * 512U);
      WinAPI.PostMessage(hWnd, HookCall.Msg, 1002U, mapID);
      WinAPI.PostMessage(hWnd, HookCall.Msg, 1001U, 0U);
    }

    public static void MoveToGD(IntPtr hWnd, uint posX, uint posY, uint mapID)
    {
      WinAPI.PostMessage(hWnd, HookCall.Msg, 1000U, 8000U);
      WinAPI.PostMessage(hWnd, HookCall.Msg, 1002U, posX);
      WinAPI.PostMessage(hWnd, HookCall.Msg, 1002U, posY);
      WinAPI.PostMessage(hWnd, HookCall.Msg, 1002U, mapID);
      WinAPI.PostMessage(hWnd, HookCall.Msg, 1001U, 0U);
    }

    public static void EntityInteract(
      IntPtr hWnd,
      uint type,
      uint param1,
      uint param2,
      uint param3,
      uint param4,
      uint param5,
      uint param6,
      uint PlayerAddr)
    {
      WinAPI.PostMessage(hWnd, HookCall.Msg, 1000U, 8001U);
      WinAPI.PostMessage(hWnd, HookCall.Msg, 1002U, type);
      WinAPI.PostMessage(hWnd, HookCall.Msg, 1002U, param1);
      WinAPI.PostMessage(hWnd, HookCall.Msg, 1002U, param2);
      WinAPI.PostMessage(hWnd, HookCall.Msg, 1002U, param3);
      WinAPI.PostMessage(hWnd, HookCall.Msg, 1002U, param4);
      WinAPI.PostMessage(hWnd, HookCall.Msg, 1002U, param5);
      WinAPI.PostMessage(hWnd, HookCall.Msg, 1002U, param6);
      WinAPI.PostMessage(hWnd, HookCall.Msg, 1002U, PlayerAddr);
      WinAPI.PostMessage(hWnd, HookCall.Msg, 1001U, 0U);
    }

    public static void ClickNPC96(IntPtr hWnd, uint entityID, uint PlayerAddr)
    {
      HookCall.EntityInteract(hWnd, 4U, entityID, 0U, 0U, 0U, 0U, 0U, PlayerAddr);
    }

    public static void UseItem96(IntPtr hWnd, uint colIndex, uint rowIndex)
    {
      WinAPI.PostMessage(hWnd, HookCall.Msg, 1000U, 8007U);
      WinAPI.PostMessage(hWnd, HookCall.Msg, 1002U, colIndex);
      WinAPI.PostMessage(hWnd, HookCall.Msg, 1002U, rowIndex);
      WinAPI.PostMessage(hWnd, HookCall.Msg, 1001U, 0U);
    }

    public static void CloseMenu96(IntPtr hWnd, uint basemanu, uint menuxId)
    {
      WinAPI.PostMessage(hWnd, HookCall.Msg, 1000U, 8010U);
      WinAPI.PostMessage(hWnd, HookCall.Msg, 1002U, basemanu);
      WinAPI.PostMessage(hWnd, HookCall.Msg, 1002U, menuxId);
      WinAPI.PostMessage(hWnd, HookCall.Msg, 1001U, 0U);
    }

    public static void PickNPutItem96(
      IntPtr hWnd,
      uint locationPick,
      uint colPick,
      uint rowPick,
      uint locationPut,
      uint colPut,
      uint rowPut,
      uint ItemAddr)
    {
      WinAPI.PostMessage(hWnd, HookCall.Msg, 1000U, 8009U);
      WinAPI.PostMessage(hWnd, HookCall.Msg, 1002U, locationPick);
      WinAPI.PostMessage(hWnd, HookCall.Msg, 1002U, colPick);
      WinAPI.PostMessage(hWnd, HookCall.Msg, 1002U, rowPick);
      WinAPI.PostMessage(hWnd, HookCall.Msg, 1002U, locationPut);
      WinAPI.PostMessage(hWnd, HookCall.Msg, 1002U, colPut);
      WinAPI.PostMessage(hWnd, HookCall.Msg, 1002U, rowPut);
      WinAPI.PostMessage(hWnd, HookCall.Msg, 1002U, ItemAddr);
      WinAPI.PostMessage(hWnd, HookCall.Msg, 1001U, 0U);
    }

    public static void KimXa96(IntPtr hWnd, uint iditem, uint hanhdong)
    {
      WinAPI.PostMessage(hWnd, HookCall.Msg, 1000U, 8034U);
      WinAPI.PostMessage(hWnd, HookCall.Msg, 1002U, iditem);
      WinAPI.PostMessage(hWnd, HookCall.Msg, 1002U, hanhdong);
      WinAPI.PostMessage(hWnd, HookCall.Msg, 1001U, 0U);
    }

    public static void XoaKX96(IntPtr hWnd, uint iditem)
    {
      WinAPI.PostMessage(hWnd, HookCall.Msg, 1000U, 8039U);
      WinAPI.PostMessage(hWnd, HookCall.Msg, 1002U, iditem);
      WinAPI.PostMessage(hWnd, HookCall.Msg, 1001U, 0U);
    }

    public static void BanItem96(IntPtr hWnd, uint iditem)
    {
      WinAPI.PostMessage(hWnd, HookCall.Msg, 1000U, 8019U);
      WinAPI.PostMessage(hWnd, HookCall.Msg, 1002U, iditem);
      WinAPI.PostMessage(hWnd, HookCall.Msg, 1001U, 0U);
    }

    public static void SelectMenu96(IntPtr hWnd, uint menuxId, uint basemenu)
    {
      WinAPI.PostMessage(hWnd, HookCall.Msg, 1000U, 8038U);
      WinAPI.PostMessage(hWnd, HookCall.Msg, 1002U, menuxId);
      WinAPI.PostMessage(hWnd, HookCall.Msg, 1002U, basemenu);
      WinAPI.PostMessage(hWnd, HookCall.Msg, 1001U, 0U);
    }

    public static void CuongHoaItem(IntPtr hwnd, uint hanhdong, uint basemenu, uint iditem)
    {
      WinAPI.PostMessage(hwnd, HookCall.Msg, 1000U, 8033U);
      WinAPI.PostMessage(hwnd, HookCall.Msg, 1002U, hanhdong);
      WinAPI.PostMessage(hwnd, HookCall.Msg, 1002U, basemenu);
      WinAPI.PostMessage(hwnd, HookCall.Msg, 1002U, iditem);
      WinAPI.PostMessage(hwnd, HookCall.Msg, 1001U, 0U);
    }

    public static void ChonNhanVat(IntPtr hwnd, uint hanhdong)
    {
      WinAPI.PostMessage(hwnd, HookCall.Msg, 1000U, 8032U);
      WinAPI.PostMessage(hwnd, HookCall.Msg, 1002U, hanhdong);
      WinAPI.PostMessage(hwnd, HookCall.Msg, 1001U, 0U);
    }

    public static void Doscrip(IntPtr hwnd, string msg)
    {
      WinAPI.PostMessage(hwnd, HookCall.Msg, 1000U, 8011U);
      if (!msg.Equals(HookCall.MsgScrip))
      {
        byte[] bytes = Encoding.Default.GetBytes(CFont.UnicodeToTCVN3(msg));
        WinAPI.PostMessage(hwnd, HookCall.Msg, 1004U, 0U);
        for (int index = 0; index < bytes.Length; ++index)
        {
          byte num = bytes[index];
          WinAPI.PostMessage(hwnd, HookCall.Msg, 1003U, (uint) num);
        }
        HookCall.MsgScrip = msg;
      }
      WinAPI.PostMessage(hwnd, HookCall.Msg, 1001U, 8011U);
    }

    public static void killboss(IntPtr hwnd, uint posX, uint posY, uint skillID, uint PlayerAddr)
    {
      HookCall.EntityInteract(hwnd, 3U, posX, posY, skillID, 0U, 0U, 0U, PlayerAddr);
    }

    public static void skillxdame(
      IntPtr hwnd,
      uint posX,
      uint posY,
      uint skillID,
      uint PlayerAddr)
    {
      HookCall.EntityInteract(hwnd, 3U, posX, posY, skillID, 0U, 0U, 0U, PlayerAddr);
    }

    public static void ShortMove(IntPtr hwnd, uint posX, uint posY, uint PlayerAddr)
    {
      HookCall.EntityInteract(hwnd, 2U, posX * 256U, posY * 512U, 0U, 0U, 0U, 0U, PlayerAddr);
    }

    public static void ShortMoveNPC(IntPtr hwnd, uint posX, uint posY, uint PlayerAddr)
    {
      HookCall.EntityInteract(hwnd, 2U, posX, posY, 0U, 0U, 0U, 0U, PlayerAddr);
    }

    public static void LeftClick(IntPtr hwnd, uint posX, uint posY, uint PlayerAddr)
    {
      HookCall.EntityInteract(hwnd, 2U, posX, posY, 0U, 0U, 0U, 0U, PlayerAddr);
    }

    public static void buffbanthan(
      IntPtr hwnd,
      uint posX,
      uint posY,
      uint skillID,
      uint PlayerAddr)
    {
      HookCall.EntityInteract(hwnd, 3U, posX, posY, skillID, 0U, 0U, 0U, PlayerAddr);
    }

    public static void Buffnpc(IntPtr hwnd, uint VictimID, uint skillID, uint PlayerAddr)
    {
      HookCall.EntityInteract(hwnd, 3U, uint.MaxValue, VictimID, skillID, 0U, 0U, 0U, PlayerAddr);
    }

    public static void CheItem(IntPtr hwnd, uint itemId)
    {
      WinAPI.PostMessage(hwnd, HookCall.Msg, 1000U, 8006U);
      WinAPI.PostMessage(hwnd, HookCall.Msg, 1002U, itemId);
      WinAPI.PostMessage(hwnd, HookCall.Msg, 1001U, 0U);
    }

    public static void ChonSever(IntPtr hwnd, uint idcum, uint idserver, uint Base)
    {
      WinAPI.PostMessage(hwnd, HookCall.Msg, 1000U, 8030U);
      WinAPI.PostMessage(hwnd, HookCall.Msg, 1002U, idcum);
      WinAPI.PostMessage(hwnd, HookCall.Msg, 1002U, idserver);
      WinAPI.PostMessage(hwnd, HookCall.Msg, 1002U, Base);
      WinAPI.PostMessage(hwnd, HookCall.Msg, 1001U, 0U);
    }

    public static void GiaoDich(IntPtr hwnd, uint Loai, uint Basegd)
    {
      WinAPI.PostMessage(hwnd, HookCall.Msg, 1000U, 8022U);
      WinAPI.PostMessage(hwnd, HookCall.Msg, 1002U, Loai);
      WinAPI.PostMessage(hwnd, HookCall.Msg, 1002U, Basegd);
      WinAPI.PostMessage(hwnd, HookCall.Msg, 1001U, 0U);
    }

    public static void MoiGiaoDich(IntPtr hwnd, uint idplayer)
    {
      WinAPI.PostMessage(hwnd, HookCall.Msg, 1000U, 8050U);
      WinAPI.PostMessage(hwnd, HookCall.Msg, 1002U, idplayer);
      WinAPI.PostMessage(hwnd, HookCall.Msg, 1001U, 0U);
    }

    public static void DongYGiaoDich(IntPtr hwnd, uint idplayer)
    {
      WinAPI.PostMessage(hwnd, HookCall.Msg, 1000U, 8051U);
      WinAPI.PostMessage(hwnd, HookCall.Msg, 1002U, idplayer);
      WinAPI.PostMessage(hwnd, HookCall.Msg, 1001U, 0U);
    }

    public static void BatDau(IntPtr hwnd)
    {
      WinAPI.PostMessage(hwnd, HookCall.Msg, 1000U, 8031U);
      WinAPI.PostMessage(hwnd, HookCall.Msg, 1001U, 0U);
    }

    public static void XuongNgua(IntPtr hwnd, uint PlayerAddr, uint use)
    {
      WinAPI.PostMessage(hwnd, HookCall.Msg, 1000U, 8004U);
      WinAPI.PostMessage(hwnd, HookCall.Msg, 1002U, PlayerAddr);
      WinAPI.PostMessage(hwnd, HookCall.Msg, 1002U, use);
      WinAPI.PostMessage(hwnd, HookCall.Msg, 1001U, 0U);
    }

    public static void Luyenmt(IntPtr hwnd, uint diemluyen)
    {
      WinAPI.PostMessage(hwnd, HookCall.Msg, 1000U, 8040U);
      WinAPI.PostMessage(hwnd, HookCall.Msg, 1002U, diemluyen);
      WinAPI.PostMessage(hwnd, HookCall.Msg, 1001U, 0U);
    }

    public static void HuyMenuTC(IntPtr hwnd)
    {
      WinAPI.PostMessage(hwnd, HookCall.Msg, 1000U, 8022U);
      WinAPI.PostMessage(hwnd, HookCall.Msg, 1001U, 0U);
    }

    public static void Mualtcap7(IntPtr hwnd)
    {
      WinAPI.PostMessage(hwnd, HookCall.Msg, 1000U, 8041U);
      WinAPI.PostMessage(hwnd, HookCall.Msg, 1001U, 0U);
    }

    public static void MuaDNS(IntPtr hwnd)
    {
      WinAPI.PostMessage(hwnd, HookCall.Msg, 1000U, 8050U);
      WinAPI.PostMessage(hwnd, HookCall.Msg, 1001U, 0U);
    }

    public static void Dungltcap7(IntPtr hwnd)
    {
      WinAPI.PostMessage(hwnd, HookCall.Msg, 1000U, 8042U);
      WinAPI.PostMessage(hwnd, HookCall.Msg, 1001U, 0U);
    }

    public static void Rutltcap7(IntPtr hwnd)
    {
      WinAPI.PostMessage(hwnd, HookCall.Msg, 1000U, 8043U);
      WinAPI.PostMessage(hwnd, HookCall.Msg, 1001U, 0U);
    }

    public static void Muahkdnp(IntPtr hwnd, uint menu)
    {
      WinAPI.PostMessage(hwnd, HookCall.Msg, 1000U, 8044U);
      WinAPI.PostMessage(hwnd, HookCall.Msg, 1002U, menu);
      WinAPI.PostMessage(hwnd, HookCall.Msg, 1001U, 0U);
    }

    public static void Muatangruong(IntPtr hwnd)
    {
      WinAPI.PostMessage(hwnd, HookCall.Msg, 1000U, 8045U);
      WinAPI.PostMessage(hwnd, HookCall.Msg, 1001U, 0U);
    }

    public static void Doiknd(IntPtr hwnd, uint id)
    {
      WinAPI.PostMessage(hwnd, HookCall.Msg, 1000U, 8046U);
      WinAPI.PostMessage(hwnd, HookCall.Msg, 1002U, id);
      WinAPI.PostMessage(hwnd, HookCall.Msg, 1001U, 0U);
    }

    public static void Menutiepnhan(IntPtr hwnd)
    {
      WinAPI.PostMessage(hwnd, HookCall.Msg, 1000U, 8048U);
      WinAPI.PostMessage(hwnd, HookCall.Msg, 1001U, 0U);
    }

    public static void Tiepnhankx(IntPtr hwnd)
    {
      WinAPI.PostMessage(hwnd, HookCall.Msg, 1000U, 8047U);
      WinAPI.PostMessage(hwnd, HookCall.Msg, 1001U, 0U);
    }

    public static void MaiItem(IntPtr hwnd, uint item)
    {
      WinAPI.PostMessage(hwnd, HookCall.Msg, 1000U, 8052U);
      WinAPI.PostMessage(hwnd, HookCall.Msg, 1002U, item);
      WinAPI.PostMessage(hwnd, HookCall.Msg, 1001U, 0U);
    }

    public static void ThuatToan(IntPtr hwnd, uint Menu, uint tinhtoan)
    {
      WinAPI.PostMessage(hwnd, HookCall.Msg, 1000U, 8053U);
      WinAPI.PostMessage(hwnd, HookCall.Msg, 1002U, Menu);
      WinAPI.PostMessage(hwnd, HookCall.Msg, 1002U, tinhtoan);
      WinAPI.PostMessage(hwnd, HookCall.Msg, 1001U, 0U);
    }

    public static void Muangucaclt7(IntPtr hwnd)
    {
      WinAPI.PostMessage(hwnd, HookCall.Msg, 1000U, 8049U);
      WinAPI.PostMessage(hwnd, HookCall.Msg, 1001U, 0U);
    }

    public static void Group(IntPtr hwnd, uint param1, uint param2, uint param3, uint PlayerAddr)
    {
      WinAPI.PostMessage(hwnd, HookCall.Msg, 1000U, 8016U);
      WinAPI.PostMessage(hwnd, HookCall.Msg, 1002U, param1);
      WinAPI.PostMessage(hwnd, HookCall.Msg, 1002U, param2);
      WinAPI.PostMessage(hwnd, HookCall.Msg, 1002U, param3);
      WinAPI.PostMessage(hwnd, HookCall.Msg, 1002U, PlayerAddr);
      WinAPI.PostMessage(hwnd, HookCall.Msg, 1001U, 0U);
    }

    public static void laptodoi(IntPtr hwnd, uint PlayerAddr)
    {
      HookCall.Group(hwnd, 0U, 0U, 0U, PlayerAddr);
    }

    public static void giaitantodoi(IntPtr hwnd, uint PlayerAddr)
    {
      HookCall.Group(hwnd, 0U, 0U, 2U, PlayerAddr);
    }

    public static void nhanloimoitodoi(IntPtr hwnd, uint IDplayer, uint PlayerAddr)
    {
      HookCall.Group(hwnd, 1U, IDplayer, 6U, PlayerAddr);
    }

    public static void xinnhaptodoi(IntPtr hwnd, uint IDplayer, uint PlayerAddr)
    {
      HookCall.Group(hwnd, 0U, IDplayer, 4U, PlayerAddr);
    }

    public static void moitodoi(IntPtr hwnd, uint IDplayer, uint PlayerAddr)
    {
      HookCall.Group(hwnd, 0U, IDplayer, 3U, PlayerAddr);
    }

    public static void chapnhanchonhaptodoi(IntPtr hwnd, uint IDplayer, uint PlayerAddr)
    {
      HookCall.Group(hwnd, 1U, IDplayer, 7U, PlayerAddr);
    }
  }
}
