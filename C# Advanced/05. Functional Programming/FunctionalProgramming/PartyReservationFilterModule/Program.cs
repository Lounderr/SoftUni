using System;
using System.Collections.Generic;
using System.Linq;

namespace PartyReservationFilterModule
{
    public static class PRFM
    {
        private static Dictionary<string, Predicate<string>> filters = new Dictionary<string, Predicate<string>>();

        public static Predicate<string> allFiltersPassed = (person) =>
        {
            return filters.All(filter => !filter.Value(person));
        };

        public static void AddFilter(string filterType, string filterParameter)
        {
            if (filterType == "Starts with")
            {
                Predicate<string> filter = (person) => person.StartsWith(filterParameter);
                filters.Add(filterType + filterParameter, filter);
            }
            else if (filterType == "Ends with")
            {
                Predicate<string> filter = (person) => person.EndsWith(filterParameter);
                filters.Add(filterType + filterParameter, filter);
            }
            else if (filterType == "Length")
            {
                Predicate<string> filter = (person) => person.Length == int.Parse(filterParameter);
                filters.Add(filterType + filterParameter, filter);
            }
            else if (filterType == "Contains")
            {
                Predicate<string> filter = (person) => person.Contains(filterParameter);
                filters.Add(filterType + filterParameter, filter);
            }
        }
        public static void RemoveFilter(string filterType, string filterParameter)
        {
            if (filterType == "Starts with")
            {
                filters.Remove(filterType + filterParameter);
            }
            else if (filterType == "Ends with")
            {
                filters.Remove(filterType + filterParameter);
            }
            else if (filterType == "Length")
            {
                filters.Remove(filterType + filterParameter);
            }
            else if (filterType == "Contains")
            {
                filters.Remove(filterType + filterParameter);
            }
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> people = Console.ReadLine().Split().ToList();

            while (true)
            {
                string[] cmd = Console.ReadLine().Split(';');

                if (cmd[0] == "Print")
                {
                    Console.WriteLine(String.Join(' ', people.Where(person => PRFM.allFiltersPassed(person))));
                    break;
                }
                else if (cmd[0] == "Add filter")
                {
                    PRFM.AddFilter(cmd[1], cmd[2]);
                }
                else if (cmd[0] == "Remove filter")
                {
                    PRFM.RemoveFilter(cmd[1], cmd[2]);
                }
            }
        }
    }
}
