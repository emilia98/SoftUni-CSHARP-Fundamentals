using System;

namespace SystemSplit
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();

            var ph = new PowerHardware(name);
            ph.PrintName();

            //ph.Name = "Daniel";
            //ph.PrintName();

        }
    }
}
