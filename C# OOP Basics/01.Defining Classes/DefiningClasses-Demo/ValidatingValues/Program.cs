using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidatingValues
{
    class Program
    {
        static void Main()
        {
            var p = new Person();

            p.name = "Pesho";
            p.Age = 25;

            Console.WriteLine(p.name);
            Console.WriteLine(p.Age);

            p.name = null;
            Console.WriteLine(p.name);

            p.Age = -1;
            Console.WriteLine(p.Age);

            p.Print();
        }
    }
}
