using System;


class Program
{
    static void Main()
    {
        string input = Console.ReadLine();
        var tokens = input.Split(' ');

        int rectanglesCount = int.Parse(tokens[0]);
        int checksCount = int.Parse(tokens[1]);

        for(int lines = 1; lines <= rectanglesCount; lines++)
        {
            input = Console.ReadLine();
            tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string id = tokens[0];
            double width = double.Parse(tokens[1]);
            double height = double.Parse(tokens[2]);

            double y = double.Parse(tokens[3]);
            double x = double.Parse(tokens[4]);


        }
    }
}

