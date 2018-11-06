using System;

namespace _06.BirthdayCelebrations
{
    public class Pet : Birthdater
    {
        // public DateTime Birthday { get; private set; }

        public string Name { get; private set; }

        public Pet(string name, DateTime birthday)
        {
            this.Name = name;
            this.Birthday = birthday;
        }
    }
}