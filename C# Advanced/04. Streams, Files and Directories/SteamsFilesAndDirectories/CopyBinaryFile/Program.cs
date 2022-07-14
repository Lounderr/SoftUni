using System;
using System.IO;

namespace CopyBinaryFile
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using FileStream fileStream = new FileStream(@"C:\Temp\copyMe.png", FileMode.Open);
            using FileStream writer = new FileStream(@"C:\Temp\newCopy.png", FileMode.OpenOrCreate);

            byte[] buffer = new byte[1024];

            for (int i = 0; i < Math.Ceiling((double)fileStream.Length / buffer.Length); i++)
            {
                fileStream.Read(buffer);
                writer.Write(buffer);
                buffer = new byte[buffer.Length];
            }




        }
    }
}
