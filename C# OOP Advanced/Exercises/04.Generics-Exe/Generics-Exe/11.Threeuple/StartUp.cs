using System;

namespace _11.Threeuple
{
    public class StartUp
    {
        static void Main()
        {
            // Enter the first line
            string[] tokens = EnterData();
            string fullName = tokens[0] + " " + tokens[1];
            string address = tokens[2];
            string town = tokens[3];

            var threeuple1 = new Threeuple<string, string, string>(fullName, address, town);
            Console.WriteLine(threeuple1);

            // Enter the second line
            tokens = EnterData();
            string name = tokens[0];
            int litersOfBeer = int.Parse(tokens[1]);
            bool isDrunk = tokens[2] == "drunk" ? true : false;

            var threeuple2 = new Threeuple<string, int, bool>(name, litersOfBeer, isDrunk);
            Console.WriteLine(threeuple2);

            // Enter the third line
            tokens = EnterData();
            string personName = tokens[0];
            double balance = double.Parse(tokens[1]);
            string bankName = tokens[2];

            var threeuple3 = new Threeuple<string, double, string>(personName, balance, bankName);
            Console.WriteLine(threeuple3);
        }

        static string[] EnterData()
        {
            string input = Console.ReadLine();
            return input.Split(" ");
        }
    }
}