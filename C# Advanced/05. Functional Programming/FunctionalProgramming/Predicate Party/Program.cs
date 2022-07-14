using System;
using System.Collections.Generic;
using System.Linq;

namespace Predicate_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<string, string, bool> startsWith = (person, str) =>
            {
                if (str.Length > person.Length)
                    return false;
                for (int i = 0; i < str.Length; i++)
                {
                    if (person[i] != str[i])
                    {
                        return false;
                    }
                }
                return true;
            };

            Func<string, string, bool> endsWith = (person, str) =>
            {
                if (str.Length > person.Length)
                    return false;
                for (int i = str.Length - 1; i > 0; i--)
                {
                    if (person[i] != str[i])
                    {
                        return false;
                    }
                }
                return true;
            };

            Func<string, int, bool> hasLength = (person, length) => person.Length == length;



            List<string> people = Console.ReadLine().Split().ToList();

            while (true)
            {
                string[] cmd = Console.ReadLine().Split();
                if (cmd[0] == "Party!")
                {
                    break;
                }

                if (cmd[0] == "Remove")
                {
                    if (cmd[1] == "StartsWith")
                    {
                        people.RemoveAll(p => startsWith(p, cmd[2]));
                    }
                    else if (cmd[1] == "EndsWith")
                    {
                        people.RemoveAll(p => endsWith(p, cmd[2]));
                    }
                    else if (cmd[1] == "Length")
                    {
                        people.RemoveAll(p => hasLength(p, int.Parse(cmd[2])));
                    }
                }
                else if (cmd[0] == "Double")
                {
                    if (cmd[1] == "StartsWith")
                    {
                        for (int i = 0; i < people.Count; i++)
                        {
                            if (startsWith(people[i], cmd[2]))
                            {
                                people.Insert(i, people[i]);
                                i++;

                            }
                        }
                    }
                    else if (cmd[1] == "EndsWith")
                    {
                        for (int i = 0; i < people.Count; i++)
                        {
                            if (endsWith(people[i], cmd[2]))
                            {
                                people.Insert(i, people[i]);
                                i++;

                            }
                        }

                    }
                    else if (cmd[1] == "Length")
                    {
                        for (int i = 0; i < people.Count; i++)
                        {
                            if (hasLength(people[i], int.Parse(cmd[2])))
                            {
                                people.Insert(i, people[i]);
                                i++;
                            }
                        }

                    }
                }
            }

            if (people.Count == 0)
            {
                Console.WriteLine("Nobody is going to the party!");
            }
            else 
            Console.WriteLine(String.Join(", ", people) + " are going to the party!");
        }
    }
}
