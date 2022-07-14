using System;
using System.IO;
using System.Text;

namespace SliceFile
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using FileStream reader = new FileStream(@"C:\Temp\data.txt", FileMode.Open);
            byte[] data = new byte[reader.Length];
            reader.Read(data);

            for (int i = 0; i < 4; i++)
            {
                using FileStream writer = new FileStream(@$"C:\Temp\Part-{i + 1}.txt", FileMode.OpenOrCreate);
                writer.Write(data, data.Length / 4 * i, data.Length / 4);
            }


        }
    }
}
