using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WordCount
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] file1 = File.ReadAllText(@"C:\Temp\text.txt").Split(new char[] { ' ', '\n'}, StringSplitOptions.TrimEntries);
            string[] file2 = File.ReadAllText(@"C:\Temp\words.txt").Split(new char[] { ' ', '\n' }, StringSplitOptions.TrimEntries);

            Dictionary<string, int> wordCount = new Dictionary<string, int>();

            foreach (var word in file1)
            {
                string wordLower = String.Join("", word.ToLower().Where(x => char.IsLetter(x)));
                if (file2.Contains(wordLower))
                {
                    if (!wordCount.ContainsKey(wordLower))
                    {
                        wordCount.Add(wordLower, 1);
                    }
                    else
                    {
                        wordCount[wordLower]++;
                    }
                }
            }

            string output = ""; 
            foreach (var (word, count) in wordCount.OrderByDescending(x => x.Value))
            {
                output += $"{word} - {count}\n";
            }
            File.WriteAllText("./results.txt", output);


        }
    }
}
