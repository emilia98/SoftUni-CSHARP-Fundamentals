namespace TheTankGame.Core
{
    using System;
    using System.Linq;
    using Contracts;
    using IO.Contracts;

    public class Engine : IEngine
    {
        private bool isRunning;
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(
            IReader reader, 
            IWriter writer, 
            ICommandInterpreter commandInterpreter)
        {
            this.reader = reader;
            this.writer = writer;
            this.commandInterpreter = commandInterpreter;

            this.isRunning = false;
        }

        public void Run()
        {
            string command = String.Empty;
            

            while ((command = this.reader.ReadLine()) != "Terminate")
            {
                var tokens = command.Split(' ').ToList();
                var commandType = tokens[0];

                if(commandType == "Vehicle" || commandType == "Part")
                {
                    tokens[0] = "Add" + commandType;
                }
                
                try
                {
                    this.writer.WriteLine(this.commandInterpreter.ProcessInput(tokens));
                }
                catch (ArgumentException e)
                {
                    this.writer.WriteLine(e.Message);
                }
                catch (InvalidOperationException e)
                {
                    this.writer.WriteLine(e.Message);
                }
            }

            this.writer.WriteLine(this.commandInterpreter.ProcessInput("Terminate".Split(' ').ToList()));
        }
    }
}