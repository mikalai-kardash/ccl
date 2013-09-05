using System;
using ccl.Framework.Commands;
using ccl.Framework.Commands.Attributes;
using ccl.Framework.Commands.Attributes.Class;

namespace ccl.Commands.Common
{
    [RegisterAs("repl")]
    public class ReplCommand : CommandBase
    {
        public override void Execute()
        {
            Console.WriteLine("Welcome to REPL!");
            Console.WriteLine("Here you can enter different commands registered within you application.");
            Console.WriteLine("To exit, type 'exit' or 'quit'.");
            Console.WriteLine("");

            while (true)
            {
                var command = Console.ReadLine();
                if (string.IsNullOrEmpty(command))
                {
                    continue;
                }
                CommandLine.Run(command.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries));
            }
        }
    }
}