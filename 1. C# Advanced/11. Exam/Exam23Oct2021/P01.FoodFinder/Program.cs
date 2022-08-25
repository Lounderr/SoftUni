using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Exam23Oct2021
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // vowels sequence
            // consonants sequence

            // check if the words {words} can be created
            // words = { "pear", "flour", "pork", "olive" }

            // vf = vowels.First(); cl = consonants.Last(); 
            // if (vf in words || cl in words) then store
            // repeat until consonants.Len = 0
            // letters can be in one or more words

            // print words found
            Queue<char> vowels = new Queue<char>(Console.ReadLine().Split(' ').Select(char.Parse));

            Stack<char> consonants = new Stack<char>(Console.ReadLine().Split(' ').Select(char.Parse));

            Stack<char> consonantsCopy = new Stack<char>(consonants);

            Dictionary<string, int> matchesByWords = new Dictionary<string, int>()
            {
                { "pear", 0 },
                { "flour", 0 },
                { "pork", 0 },
                { "olive", 0 }
            };

            List<string> matchingWords = new List<string>();


            foreach (var word in matchesByWords.Keys.ToArray())
            {
                for (int i = 0; i < word.Length; i++)
                {
                    while (consonants.Count() > 0)
                    {
                        if (word[i] == consonants.Peek() || word[i] == vowels.Peek())
                        {
                            //Console.WriteLine(word + "-" + word[i] + "#" + i + "$" + consonants.Peek() + "/" + vowels.Peek());
                            matchesByWords[word]++;
                            break;
                        }

                        vowels.Enqueue(vowels.Dequeue());
                        consonants.Pop();
                    }

                    consonants = new Stack<char>(consonantsCopy);
                }

                if (matchesByWords[word] == word.Length)
                {
                    matchingWords.Add(word);
                }
            }

            Console.WriteLine("Words found: " + matchingWords.Count);
            foreach (var word in matchingWords)
            {
                Console.WriteLine(word);
            }
        }
    }
}
