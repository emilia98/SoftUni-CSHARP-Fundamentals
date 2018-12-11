using System;
using System.Linq;

namespace _01.ListyIterator
{
    public class StartUp
    {
        public static ListyIterator<string> list;

        static void Main()
        {
            string command = Console.ReadLine();
            
            while (command != "END")
            {
                string[] tokens = command.Split(" ");
                string commandType = tokens[0];

                switch (commandType)
                {
                    case "Create":
                        {
                            list = new ListyIterator<string>(tokens.Skip(1).ToArray());
                            break;
                        }
                    case "Move":
                        {
                            Console.WriteLine(list.Move());
                            break;
                        }
                    case "HasNext":
                        {
                            Console.WriteLine(list.HasNext());
                            break;
                        }
                    case "Print":
                        {
                            try
                            {
                                list.Print();
                            }
                            catch (ArgumentException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            break;
                        }
                }

                command = Console.ReadLine();
            }
        }
    }
}