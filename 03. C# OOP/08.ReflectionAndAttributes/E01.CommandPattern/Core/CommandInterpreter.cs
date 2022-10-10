using CommandPattern.Core.Commands;
using CommandPattern.Core.Contracts;
using System.Linq;

namespace CommandPattern.Core
{
    internal class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] cmds = args.Split();

            string commandName = cmds[0];
            string[] commandArgs = cmds.Skip(1).ToArray();

            if (commandName == "Hello")
            {
                HelloCommand hello = new HelloCommand();
                return hello.Execute(commandArgs);
            }
            else if (commandName == "Exit")
            {
                ExitCommand exit = new ExitCommand();
                return exit.Execute(commandArgs);
            }

            return null;
        }
    }
}