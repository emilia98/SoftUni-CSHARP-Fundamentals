using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettersAndSetters
{
    class Person
    {
        string firstName;
        string lastName;
        public int age;
        //string country;

        public string Country
        {
            get; private set;
        }

        public string FirstName
        {
            // "this" is not a 
            get { return this.firstName; }
            set { this.firstName = value; }
        }

        public string LastName
        {
            get { return this.lastName; }
            set { this.lastName = value; }
        }

        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }

        public void Format()
        {
            this.Country = "Bulgaria";
        }
    }
}
