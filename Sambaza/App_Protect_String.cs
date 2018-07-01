using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Sambaza
{
    class App_Protect_String
    {
        public string EncryptString(String txt)
        {
            SecureString secure = new SecureString();
            foreach (char c in txt)
            {
                secure.AppendChar(c);
            }
            secure.MakeReadOnly();
            return Convert.ToString(secure);
        }
        public string DecryptString(String enctxt, String passkey = "P@S#RD")
        {
            string returnval = string.Empty;
            var secure = new SecureString();
            foreach (char c in enctxt)
            {
                secure.AppendChar(c);
            }
            IntPtr ptr = System.Runtime.InteropServices.Marshal.SecureStringToBSTR(secure);

            try
            {
                returnval = System.Runtime.InteropServices.Marshal.PtrToStringBSTR(ptr);
            }
            finally
            {
                System.Runtime.InteropServices.Marshal.ZeroFreeBSTR(ptr);
            }
            return returnval;
        }
    }
    class Protect_String_Old
    {
        public TripleDES createDes(String key)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            TripleDES des = new TripleDESCryptoServiceProvider();
            des.Key = md5.ComputeHash(Encoding.Unicode.GetBytes(key));
            des.IV = new byte[des.BlockSize / 8];
            return des;

        }
        public string EncryptString(String txt, String passkey = "P@S#RD")
        {
            if (string.IsNullOrEmpty(txt))
            {
                return txt;
            }
            else
            {
                byte[] plainTextbytes = Encoding.Unicode.GetBytes(txt);

                MemoryStream mystream = new MemoryStream();

                TripleDES des = createDes(passkey);

                CryptoStream cryptstream = new CryptoStream(mystream, des.CreateEncryptor(), CryptoStreamMode.Write);

                cryptstream.Write(plainTextbytes, 0, plainTextbytes.Length);
                cryptstream.FlushFinalBlock();

                return Convert.ToBase64String(mystream.ToArray());


            }
        }
        public string DecryptString(String enctxt, String passkey = "P@S#RD")
        {
            if (String.IsNullOrEmpty(enctxt))
            {
                return enctxt;
            }
            else
            {
                byte[] enctextbytes = Convert.FromBase64String(enctxt);

                MemoryStream mystream = new MemoryStream();

                TripleDES des = createDes(passkey);

                CryptoStream decryptstream = new CryptoStream(mystream, des.CreateDecryptor(), CryptoStreamMode.Write);

                decryptstream.Write(enctextbytes, 0, enctextbytes.Length);
                decryptstream.FlushFinalBlock();

                return Encoding.Unicode.GetString(mystream.ToArray());
            }
        }
    }
}