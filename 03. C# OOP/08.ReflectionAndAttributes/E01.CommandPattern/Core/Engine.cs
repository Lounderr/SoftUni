using CommandPattern.Core.Contracts;
using CommandPattern.Core;
using System;

namespace CommandPattern.Core
{
    internal class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            while (true)
            {
                string input = Console.ReadLine();
                Console.WriteLine(commandInterpreter.Read(input));
            }
        }
    }
}