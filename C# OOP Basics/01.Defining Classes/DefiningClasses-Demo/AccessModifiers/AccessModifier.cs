using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessModifiers
{
    class AccessModifier
    {
        static void Main()
        {
            var country = new Country();

            Console.WriteLine(country.Name);
            // country.Name = "Bulgaria"; // -> CANNOT SET A VALUE

            /*
             The name was set via Initialize method, 
             which has an access to settery of Country class instance
             * */
            country.Initialize("Bulgaria");
            Console.WriteLine(country.Name);

            // We have no access to this method. We could call in the class
            // country.SaySomething(); 

            // var town = new Town(); // We have no access to this class
            country.NewTown();
        }
    }
}
