// Decompiled with JetBrains decompiler
// Type: dorajx2.UyHoLenh
// Assembly: T2Auto, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3D2B1643-7C06-428B-9BDA-29369F42091D
// Assembly location: C:\Users\itoutsource06\Desktop\AutoT2\Auto Jx2\T2Auto.exe

using System.Collections.Generic;
using System.Drawing;
using System.Threading;

namespace dorajx2
{
  public class UyHoLenh
  {
    public static int BaseMenu = 12079952;
    private Client client;
    private Thread _buffnm;

    public UyHoLenh(Client _client)
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
