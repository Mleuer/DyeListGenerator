using System;
using System.IO;
using System.Text;

namespace DyeListGenerator
{
    public static class Util
    {
        public static Stream CreateStreamFromString(String str)
        {
            byte[] byteArray = Encoding.UTF8.GetBytes(str); 
            MemoryStream stream = new MemoryStream(byteArray);
            return stream;
        }
    }
}