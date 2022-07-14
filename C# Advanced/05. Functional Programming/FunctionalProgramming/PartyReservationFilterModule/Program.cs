using System;
using System.Collections.Generic;

namespace PartyReservationFilterModule
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> people = new List<string>();

            while (true)
            {
                string[] cmd = Console.ReadLine().Split();

                if (cmd[0] == "Print")
                {
                    // TODO: Print
                    break;
                }

                else if (cmd[0] == "Add filter")
                {
                    // TODO: Add filter
                }
                else if (cmd[0] == "Remove filter")
                {
                    // TODO: Remove filter
                }
            }
        }
    }
}
