﻿namespace PersonInfo
{
    public class Citizen : IPerson
    {
        public string Name { get; private set; }

        public int Age { get; private set; }

        public Citizen(string name, int age)
        {
            this.Age = age;
            this.Name = name;
        }
    }
}