// Decompiled with JetBrains decompiler
// Type: dorajx2.AutoLogin
// Assembly: T2Auto, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3D2B1643-7C06-428B-9BDA-29369F42091D
// Assembly location: C:\Users\itoutsource06\Desktop\AutoT2\Auto Jx2\T2Auto.exe

using System.Collections.Generic;
using System.Xml.Serialization;

namespace dorajx2
{
  public class AutoLogin
  {
    [XmlElement("File")]
    public string FileGame { get; set; }

    public List<ThongTinDangNhap> ListDanhSach { get; set; }

    public AutoLogin()
    {
      this.ListDanhSach = new List<ThongTinDangNhap>();
    }
  }
}
