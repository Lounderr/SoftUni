using System;
using System.IO;
using System.Linq;

namespace FileStreams
{
    internal class Program
    {
        static void Main(string[] args)
        {
            byte[] myBuffer = new byte[1024];

            DoStuff(buffer: myBuffer);
        }




        static void DoStuff(byte[] buffer)
        {
            using var fileStream = new FileStream("console.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);

            if (fileStream.CanWrite)
            {
                fileStream.Seek(2, SeekOrigin.Begin);
                fileStream.Read(buffer, 0, 100);
                byte[] data = buffer;

                //for (int i = 0; i < byte.MaxValue; i++)
                //{
                //    data[i] += Convert.ToByte(i);
                //}

                fileStream.Write(data);
            }
        }
    }
}
