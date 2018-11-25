using System;

namespace _09.CustomListIterator
{
    public class StartUp
    {
        static void Main()
        {
            string command = Console.ReadLine();
            CustomList<string> clist = new CustomList<string>();

            while (command != "END")
            {
                var tokens = command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string commandType = tokens[0];

                switch (commandType)
                {
                    case "Add":
                        {
                            string value = tokens[1];
                            clist.Add(value);
                            break;
                        }
                    case "Remove":
                        {
                            int index = int.Parse(tokens[1]);
                            clist.Remove(index);
                            break;
                        }
                    case "Contains":
                        {
                            string element = tokens[1];
                            Console.WriteLine(clist.Contains(element));
                            break;
                        }
                    case "Swap":
                        {
                            int index1 = int.Parse(tokens[1]);
                            int index2 = int.Parse(tokens[2]);
                            clist.Swap(index1, index2);
                            break;
                        }
                    case "Greater":
                        {
                            string element = tokens[1];
                            Console.WriteLine(clist.CountGreaterThan(element));
                            break;
                        }
                    case "Max":
                        {
                            Console.WriteLine(clist.Max());
                            break;
                        }
                    case "Min":
                        {
                            Console.WriteLine(clist.Min());
                            break;
                        }
                    case "Sort":
                        {
                            clist.Sort();
                            break;
                        }
                    case "Print":
                        {
                            foreach(var element in clist)
                            {
                                Console.WriteLine(element);
                            }
                            //
                            // clist.Print();
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
                command = Console.ReadLine();
            }
        }
    }
}
