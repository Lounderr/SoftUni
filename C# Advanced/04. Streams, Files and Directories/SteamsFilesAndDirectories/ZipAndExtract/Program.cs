using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Collections;

namespace ZipAndExtract
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("./copyMe");
            string fileDir = Console.ReadLine();
            Console.WriteLine("./copyMe.zip");
            string zipDir = Console.ReadLine();
            Console.WriteLine("./Extract");
            string extractDir = Console.ReadLine();

            ZipFile.CreateFromDirectory(fileDir, zipDir);
            ZipFile.ExtractToDirectory(zipDir, extractDir);
        }
    }
}
