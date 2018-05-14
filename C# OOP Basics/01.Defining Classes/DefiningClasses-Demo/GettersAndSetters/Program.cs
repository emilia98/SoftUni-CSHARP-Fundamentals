using System;

namespace GettersAndSetters
{
    class Program
    {
        static void Main()
        {
            var p = new Person();
            p.FirstName = "Pesho";
            p.LastName = "Peshev";

            // "age" is public -> so we can get and set it's value
            p.age = 15;
            Console.WriteLine(p.age);

            Console.WriteLine(p.FirstName);
            Console.WriteLine(p.LastName);
            // p.FullName = "Tosho Toshev"; -> CANNOT SET A VALUE
            Console.WriteLine(p.FullName);

            // p.Country = "Bulgaria"; -> CANNOT SET A VALUE -> Only in its class
            Console.WriteLine(p.Country);

            p.Format();
            // Here, the country is set
            Console.WriteLine(p.Country);
        }
    }
}
