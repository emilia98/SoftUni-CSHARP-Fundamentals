using CosmosX.Core.Contracts;
using CosmosX.IO.Contracts;
using System;
using System.Linq;

namespace CosmosX.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private ICommandParser commandParser;
        private bool isRunning;

        public Engine(IReader reader, IWriter writer, ICommandParser commandParser)
        {
            this.reader = reader;
            this.writer = writer;
            this.commandParser = commandParser;
            this.isRunning = false;
        }

        public void Run()
        {
            string command = this.reader.ReadLine();
            
            while (command != "Exit")
            {
                var tokens = command.Split(' ').ToList();
                /*
                if (commandType == "Vehicle" || commandType == "Part")
                {
                    tokens[0] = "Add" + commandType;
                }
                */

                this.writer.WriteLine(this.commandParser.Parse(tokens));
                /*
                try
                {
                    this.writer.WriteLine(this.commandParser.Parse(parameters));
                }
                catch (ArgumentException e)
                {

                    this.writer.WriteLine(e.Message);
                }
                catch (InvalidOperationException e)
                {
                    this.writer.WriteLine(e.Message);
                }
                */
                command = this.reader.ReadLine();
            }

            this.writer.WriteLine(this.commandParser.Parse("Exit".Split(' ').ToArray()));
        }
    }
}