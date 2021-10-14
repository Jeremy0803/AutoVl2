// Decompiled with JetBrains decompiler
// Type: dorajx2.Decrypt
// Assembly: T2Auto, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3D2B1643-7C06-428B-9BDA-29369F42091D
// Assembly location: C:\Users\itoutsource06\Desktop\AutoT2\Auto Jx2\T2Auto.exe

using System;
using System.Security.Cryptography;
using System.Text;

namespace dorajx2
{
  public class Decrypt
  {
    public static string DecryptData(string EncryptedText, string Encryptionkey = "xxjx")
    {
      RijndaelManaged rijndaelManaged = new RijndaelManaged();
      rijndaelManaged.Mode = CipherMode.CBC;
      rijndaelManaged.Padding = PaddingMode.PKCS7;
      rijndaelManaged.KeySize = 1;
      rijndaelManaged.BlockSize = 1;
      byte[] inputBuffer = Convert.FromBase64String(EncryptedText);
      byte[] bytes = Encoding.UTF8.GetBytes(Encryptionkey);
      byte[] numArray = new byte[16];
      int length = bytes.Length;
      if (length > numArray.Length)
        length = numArray.Length;
      Array.Copy((Array) bytes, (Array) numArray, length);
      rijndaelManaged.Key = numArray;
      rijndaelManaged.IV = numArray;
      return Encoding.UTF8.GetString(rijndaelManaged.CreateDecryptor().TransformFinalBlock(inputBuffer, 0, inputBuffer.Length));
    }
  }
}
