using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidatingValues
{
    class Person
    {

        // If we want to have a name, with length > 0 or not a null value,
        // we cannot validate it.
        public string name;
        int age;
        public string country;

        // Validating age - check if the value is > 0
        public int Age
        {
            get { return this.age; }
            set
            {
                if(value < 0)
                {
                    // throw new Exception("The age cannot be a negative number!");
                    Console.WriteLine("The age cannot be a negative number!");
                    return;
                }
                this.age = value;
            }
        }

        public string Country
        {
            get; private set;
        }

        public void Print()
        {
            // There are two kinds of setting a new value for a field;
            // -> from a property or from a field
            country = "Macedonia";
            Console.WriteLine(country);
            Console.WriteLine("Just kidding!");
            Country = "Bulgaria";
            Console.WriteLine(Country);
        }
    }
}
