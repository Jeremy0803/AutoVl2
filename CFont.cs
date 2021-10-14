// Decompiled with JetBrains decompiler
// Type: dorajx2.CFont
// Assembly: T2Auto, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3D2B1643-7C06-428B-9BDA-29369F42091D
// Assembly location: C:\Users\itoutsource06\Desktop\AutoT2\Auto Jx2\T2Auto.exe

namespace dorajx2
{
  public class CFont
  {
    private static string tcvntouni(string text)
    {
      if (text != null)
      {
        switch (text)
        {
          case "¡":
            return "Ă";
          case "¢":
            return "Â";
          case "£":
            return "Ê";
          case "¤":
            return "Ô";
          case "¥":
            return "Ơ";
          case "¦":
            return "Ư";
          case "§":
            return "Đ";
          case "¨":
            return "ă";
          case "©":
            return "â";
          case "ª":
            return "ê";
          case "«":
            return "ô";
          case "¬":
            return "ơ";
          case "\x00AD":
            return "ư";
          case "®":
            return "đ";
          case "µ":
            return "à";
          case "¶":
            return "ả";
          case "·":
            return "ã";
          case "¸":
            return "á";
          case "\x00B9":
            return "ạ";
          case "»":
            return "ằ";
          case "\x00BC":
            return "ẳ";
          case "\x00BD":
            return "ẵ";
          case "\x00BE":
            return "ắ";
          case "Æ":
            return "ặ";
          case "Ç":
            return "ầ";
          case "È":
            return "ẩ";
          case "É":
            return "ẫ";
          case "Ê":
            return "ấ";
          case "Ë":
            return "ậ";
          case "Ì":
            return "è";
          case "Î":
            return "ẻ";
          case "Ï":
            return "ẽ";
          case "Ð":
            return "é";
          case "Ñ":
            return "ẹ";
          case "Ò":
            return "ề";
          case "Ó":
            return "ể";
          case "Ô":
            return "ễ";
          case "Õ":
            return "ế";
          case "Ö":
            return "ệ";
          case "×":
            return "ì";
          case "Ø":
            return "ỉ";
          case "Ü":
            return "ĩ";
          case "Ý":
            return "í";
          case "Þ":
            return "ị";
          case "ß":
            return "ò";
          case "á":
            return "ỏ";
          case "â":
            return "õ";
          case "ã":
            return "ó";
          case "ä":
            return "ọ";
          case "å":
            return "ồ";
          case "æ":
            return "ổ";
          case "ç":
            return "ỗ";
          case "è":
            return "ố";
          case "é":
            return "ộ";
          case "ê":
            return "ờ";
          case "ë":
            return "ở";
          case "ì":
            return "ỡ";
          case "í":
            return "ớ";
          case "î":
            return "ợ";
          case "ï":
            return "ù";
          case "ñ":
            return "ủ";
          case "ò":
            return "ũ";
          case "ó":
            return "ú";
          case "ô":
            return "ụ";
          case "õ":
            return "ừ";
          case "ö":
            return "ử";
          case "÷":
            return "ữ";
          case "ø":
            return "ứ";
          case "ù":
            return "ự";
          case "ú":
            return "ỳ";
          case "û":
            return "ỷ";
          case "ü":
            return "ỹ";
          case "ý":
            return "ý";
          case "þ":
            return "ỵ";
        }
      }
      return text;
    }

    private static string tcvntono(string text)
    {
      if (text != null)
      {
        switch (text)
        {
          case "¡":
            return "A";
          case "¢":
            return "A";
          case "£":
            return "E";
          case "¤":
            return "O";
          case "¥":
            return "O";
          case "¦":
            return "U";
          case "§":
            return "D";
          case "¨":
            return "a";
          case "©":
            return "a";
          case "ª":
            return "e";
          case "«":
            return "o";
          case "¬":
            return "o";
          case "\x00AD":
            return "u";
          case "®":
            return "d";
          case "µ":
            return "a";
          case "¶":
            return "a";
          case "·":
            return "a";
          case "¸":
            return "a";
          case "\x00B9":
            return "a";
          case "»":
            return "a";
          case "\x00BC":
            return "a";
          case "\x00BD":
            return "a";
          case "\x00BE":
            return "a";
          case "Æ":
            return "a";
          case "Ç":
            return "a";
          case "È":
            return "a";
          case "É":
            return "a";
          case "Ê":
            return "a";
          case "Ë":
            return "a";
          case "Ì":
            return "e";
          case "Î":
            return "e";
          case "Ï":
            return "e";
          case "Ð":
            return "e";
          case "Ñ":
            return "e";
          case "Ò":
            return "e";
          case "Ó":
            return "e";
          case "Ô":
            return "e";
          case "Õ":
            return "e";
          case "Ö":
            return "e";
          case "×":
            return "i";
          case "Ø":
            return "i";
          case "Ü":
            return "i";
          case "Ý":
            return "i";
          case "Þ":
            return "i";
          case "ß":
            return "o";
          case "á":
            return "o";
          case "â":
            return "o";
          case "ã":
            return "o";
          case "ä":
            return "o";
          case "å":
            return "o";
          case "æ":
            return "o";
          case "ç":
            return "o";
          case "è":
            return "o";
          case "é":
            return "o";
          case "ê":
            return "o";
          case "ë":
            return "o";
          case "ì":
            return "o";
          case "í":
            return "o";
          case "î":
            return "o";
          case "ï":
            return "u";
          case "ñ":
            return "u";
          case "ò":
            return "u";
          case "ó":
            return "u";
          case "ô":
            return "u";
          case "õ":
            return "u";
          case "ö":
            return "u";
          case "÷":
            return "u";
          case "ø":
            return "u";
          case "ù":
            return "u";
          case "ú":
            return "y";
          case "û":
            return "y";
          case "ü":
            return "y";
          case "ý":
            return "y";
          case "þ":
            return "y";
        }
      }
      return text;
    }

    private static string unitotcvn(string text)
    {
      if (text != null)
      {
        switch (text)
        {
          case "Â":
            return "¢";
          case "Ê":
            return "£";
          case "Ô":
            return "¤";
          case "à":
            return "µ";
          case "á":
            return "¸";
          case "â":
            return "©";
          case "ã":
            return "·";
          case "è":
            return "Ì";
          case "é":
            return "Ð";
          case "ê":
            return "ª";
          case "ì":
            return "×";
          case "í":
            return "Ý";
          case "ò":
            return "ß";
          case "ó":
            return "ã";
          case "ô":
            return "«";
          case "õ":
            return "â";
          case "ù":
            return "ï";
          case "ú":
            return "ó";
          case "ý":
            return "ý";
          case "Ă":
            return "¡";
          case "ă":
            return "¨";
          case "Đ":
            return "§";
          case "đ":
            return "®";
          case "ĩ":
            return "Ü";
          case "ũ":
            return "ò";
          case "Ơ":
            return "¥";
          case "ơ":
            return "¬";
          case "Ư":
            return "¦";
          case "ư":
            return "\x00AD";
          case "ạ":
            return "\x00B9";
          case "ả":
            return "¶";
          case "ấ":
            return "Ê";
          case "ầ":
            return "Ç";
          case "ẩ":
            return "È";
          case "ẫ":
            return "É";
          case "ậ":
            return "Ë";
          case "ắ":
            return "\x00BE";
          case "ằ":
            return "»";
          case "ẳ":
            return "\x00BC";
          case "ẵ":
            return "\x00BD";
          case "ặ":
            return "Æ";
          case "ẹ":
            return "Ñ";
          case "ẻ":
            return "Î";
          case "ẽ":
            return "Ï";
          case "ế":
            return "Õ";
          case "ề":
            return "Ò";
          case "ể":
            return "Ó";
          case "ễ":
            return "Ô";
          case "ệ":
            return "Ö";
          case "ỉ":
            return "Ø";
          case "ị":
            return "Þ";
          case "ọ":
            return "ä";
          case "ỏ":
            return "á";
          case "ố":
            return "è";
          case "ồ":
            return "å";
          case "ổ":
            return "æ";
          case "ỗ":
            return "ç";
          case "ộ":
            return "é";
          case "ớ":
            return "í";
          case "ờ":
            return "ê";
          case "ở":
            return "ë";
          case "ỡ":
            return "ì";
          case "ợ":
            return "î";
          case "ụ":
            return "ô";
          case "ủ":
            return "ñ";
          case "ứ":
            return "ø";
          case "ừ":
            return "õ";
          case "ử":
            return "ö";
          case "ữ":
            return "÷";
          case "ự":
            return "ù";
          case "ỳ":
            return "ú";
          case "ỵ":
            return "þ";
          case "ỷ":
            return "û";
          case "ỹ":
            return "ü";
        }
      }
      return text;
    }

    public static string UnicodeToTCVN3(string value)
    {
      string str = "";
      for (int index = 0; index < value.Length; ++index)
        str += CFont.unitotcvn(value[index].ToString());
      return str;
    }

    public static string TCVN3ToNoMark(string value)
    {
      string str = "";
      for (int index = 0; index < value.Length; ++index)
        str += CFont.tcvntono(value[index].ToString());
      return str;
    }

    public static string TCVN3ToUnicode(string value)
    {
      string str = "";
      for (int index = 0; index < value.Length; ++index)
        str += CFont.tcvntouni(value[index].ToString());
      return str;
    }
  }
}
