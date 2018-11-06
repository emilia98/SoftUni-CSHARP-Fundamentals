using System;
using System.Collections.Generic;
using System.Text;

namespace _05.BorderControl
{
    public class Citizen : Member
    {
        public string Name { get; private set; }

        //public string Id { get; private set; }

        public int Age { get; private set; }

        public Citizen(string name, int age, string id)
        {
            this.Name = name;
            this.Id = id;
            this.Age = age;
        }
    }
}
