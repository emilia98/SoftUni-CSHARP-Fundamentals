using CosmosX.Core;
using CosmosX.Core.Contracts;
using CosmosX.IO;
using CosmosX.IO.Contracts;
using System;

namespace CosmosX
{
    public class StartUp
    {
        static void Main()
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IManager reactorManager = new ReactorManager();

            ICommandParser commandParser = new CommandParser(reactorManager);
            IEngine engine = new Engine(reader, writer, commandParser);
            engine.Run();
        }
    }
}
