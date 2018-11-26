using System;

namespace Basic_Inheritance
{
    abstract class Animal
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public virtual void Move()
        {
            Console.WriteLine("MOVING");
        }

        public static void Eat()
        {
            Console.WriteLine("Eating");
        }
    }
}