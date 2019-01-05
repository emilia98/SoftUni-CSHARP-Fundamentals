
using System;
using System.Linq;
namespace FestivalManager.Core
{
    using System.Reflection;
    using Contracts;
    using Controllers.Contracts;
    using IO;
    using IO.Contracts;

    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;

        private IFestivalController festivalCоntroller;
        private ISetController setCоntroller;

        public Engine(IFestivalController festivalCоntroller, ISetController setCоntroller)
        {
            this.reader = new ConsoleReader();
            this.writer = new ConsoleWriter();

            this.festivalCоntroller = festivalCоntroller;
            this.setCоntroller = setCоntroller;
        }

        public void Run()
        {
            while (true) // for job security
            {
                var input = this.reader.ReadLine();

                if (input == "END")
                {
                    break;
                }

                try
                {
                    var result = this.ProcessCommand(input);
                    this.writer.WriteLine(result);
                }
                catch (Exception ex)
                {
                    this.writer.WriteLine("ERROR: " + ex.Message);
                }
            }

            var end = this.festivalCоntroller.ProduceReport();

            this.writer.WriteLine("Results:");
            this.writer.WriteLine(end);
        }

        public string ProcessCommand(string input)
        {
            string[] tokens = input.Split(" ".ToCharArray().First());

            var command = tokens.First();
            var parameters = tokens.Skip(1).ToArray();

            string output = String.Empty;

            switch (command)
            {
                case "RegisterSet":
                    output = festivalCоntroller.RegisterSet(parameters);
                    break;
                case "SignUpPerformer":
                    output = festivalCоntroller.SignUpPerformer(parameters);
                    break;
                case "RegisterSong":
                    output = festivalCоntroller.RegisterSong(parameters);
                    break;
                case "AddSongToSet":
                    output = festivalCоntroller.AddSongToSet(parameters);
                    break;
                case "AddPerformerToSet":
                    output = festivalCоntroller.AddPerformerToSet(parameters);
                    break;
                case "RepairInstruments":
                    output = festivalCоntroller.RepairInstruments();
                    break;
                case "LetsRock":
                    output = setCоntroller.PerformSets();
                    break;
            }

            return output;

            /*
            var festivalcontrolfunction = this.festivalController.GetType()
                .GetMethods()
                .FirstOrDefault(x => x.Name == purvoto);

            string a;

            try
            {
                a = (string)festivalcontrolfunction.Invoke(this.festivalController, new object[] { parametri });
            }
            catch (TargetInvocationException up)
            {
                throw up; // ha ha
            }

            return a;*/
        }
    }
}