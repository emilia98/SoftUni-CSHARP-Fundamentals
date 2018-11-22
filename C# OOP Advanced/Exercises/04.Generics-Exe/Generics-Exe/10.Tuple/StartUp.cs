using System;

namespace _10.Tuple
{
    public class StartUp
    {
        static void Main()
        {
            // Enter the first line
            string[] tokens = EnterData();
            string fullName = tokens[0] + " " + tokens[1];
            string address = tokens[2];

            var tuple1 = new Tuple<string, string>(fullName, address);
            Console.WriteLine(tuple1);

            // Enter the second line
            tokens = EnterData();
            string name = tokens[0];
            int litersOfBeer = int.Parse(tokens[1]);

            var tuple2 = new Tuple<string, int>(name, litersOfBeer);
            Console.WriteLine(tuple2);

            // Enter the third line
            tokens = EnterData();
            int item_int = int.Parse(tokens[0]);
            double item_double = double.Parse(tokens[1]);

            var tuple3 = new Tuple<int, double>(item_int, item_double);
            Console.WriteLine(tuple3);
        }

        static string[] EnterData()
        {
            string input = Console.ReadLine();
            //string[] tokens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string[] tokens = input.Split(" ");

            return tokens;
        }
    }
}