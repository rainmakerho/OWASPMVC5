using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Web;

namespace MyStore.WebUI.ExtensionMethods
{
    public static class SecureStringExtension
    {
        public static SecureString ToSecureString(this char[] self)
        {
            var secureString = new SecureString();
            foreach (char c in self)
            {
                secureString.AppendChar(c);
            }
            return secureString;
        }

        public static SecureString ToSecureString(this string self)
        {
            var secureString = new SecureString();
            char[] chars = self.ToCharArray();
            foreach (char c in chars)
            {
                secureString.AppendChar(c);
            }
            return secureString;
        }

        public static string ToText(this SecureString self)
        {
            IntPtr bstr = Marshal.SecureStringToBSTR(self);
            try
            {
                return Marshal.PtrToStringBSTR(bstr);
            }
            finally
            {
                Marshal.FreeBSTR(bstr);
            }
        }
    }
}