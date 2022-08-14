using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

public class Program
{
    public static void Main()
    {
        string[] cmd = Console.ReadLine().Split();

        List<string> items = cmd.Skip(1).ToList();
        ListyIterator<string> li = new ListyIterator<string>(items);

        while (cmd[0] != "END")
        {
            if (cmd[0] == "Move")
            {
                Console.WriteLine(  li.Move() );
            }
            else if (cmd[0] == "Print")
            {
                try
                {
                    li.Print();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else if (cmd[0] == "HasNext")
            {
                Console.WriteLine(li.HasNext());
            }

            cmd = Console.ReadLine().Split();
        }
    }
}
