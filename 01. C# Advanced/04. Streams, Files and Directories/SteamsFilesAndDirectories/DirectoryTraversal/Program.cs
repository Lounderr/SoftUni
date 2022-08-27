using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace DirectoryTraversal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string dir = Console.ReadLine();
            string[] files = Directory.GetFiles(dir);
            Dictionary<string, List<string>> filesByExt = new Dictionary<string, List<string>>();


            foreach (string file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                if (filesByExt.ContainsKey(fileInfo.Extension))
                {
                    filesByExt[fileInfo.Extension].Add($"{fileInfo.Name} - {(double)fileInfo.Length / 1024:f3}kb");
                }
                else
                {
                    filesByExt.Add(fileInfo.Extension, new List<string>());
                    filesByExt[fileInfo.Extension].Add($"{fileInfo.Name} - {(double)fileInfo.Length / 1024:f3}kb");
                }
            }

            using StreamWriter sw = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/report.txt");
            foreach (var (ext, filesList) in filesByExt.OrderByDescending(x => x.Value.Count))
            {
                sw.WriteLine(ext);
                foreach (var file in filesList)
                {
                    sw.WriteLine($"--{file}");
                }
            }
        }
    }
}
