using System;

namespace PersonInfo
{
    public class StartUp
    {
        static void Main()
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            Citizen citizen = new Citizen(name, age);
            Console.WriteLine(citizen.Name);
            Console.WriteLine(citizen.Age);
        }
    }
}