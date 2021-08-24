using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemicoClient.Utils
{
    internal static class Converter
    {
        public static string ConvertToBase64(string data)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(data));
        }

        public static string ConvertToBase64(byte[] data)
        {
            return Convert.ToBase64String(data);
        }

        public static string ConvertToBase64(Stream data)
        {
            return Convert.ToBase64String(StreamToByteArray(data));
        }

        public static byte[] ConvertToByteArray(string base64)
        {
            return Convert.FromBase64String(base64);
        }

        public static Stream ConvertToStream(string base64)
        {
            return new MemoryStream(Convert.FromBase64String(base64));
        }

        private static byte[] StreamToByteArray(Stream stream)
        {
            if (stream is MemoryStream)
            {
                return ((MemoryStream)stream).ToArray();
            }
            else
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    stream.CopyTo(ms);
                    return ms.ToArray();
                }
            }
        }


    }
}
