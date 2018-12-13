using System;

namespace Constructors
{
    public class Cat
    {
        public string Name { get; set; }

        public int Age { get; set; }

        // This constructor is called ONLY the first time the class is called
        static Cat()
        {
            Console.WriteLine("Static Constructor");
        }

        public Cat()
        {
            this.Name = "Pesho";
        }

        public Cat(string name)
        {
            this.Name = name;
        }

        public Cat(string name, int age) : this(name)
        {
            this.Age = age;
        }
    }
}