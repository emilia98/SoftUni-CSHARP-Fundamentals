using System;

namespace Constructors
{
    class Puppy : Dog
    {
        public bool CanGoOut { get; set; }

        public Puppy(string name, int age) : base(name)
        {
            Console.WriteLine("Before: " + this.Name);
            this.Name = name + "- changhed";
            Console.WriteLine("After: " + this.Name);

            Age = age;
            CanGoOut = false;

            if(age > 5)
            {
                CanGoOut = true;
            }
        }

        public void Pee()
        {
            Console.WriteLine("peeing...");
        }
    }
}