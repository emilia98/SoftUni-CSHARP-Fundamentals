﻿using System;
using System.Text;

namespace _01.Person
{
    public class Person
    {
        protected string name;
        protected int age;

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        
        public virtual string Name
        {
            get { return this.name; }
            set
            {
                if(String.IsNullOrWhiteSpace(value) ||  value.Length < 3)
                {
                    throw new ArgumentException("Name's length should not be less than 3 symbols!");
                }
                this.name = value;
            }
        }

        public virtual int Age
        {
            get { return this.age; }
            set
            {
                if(value < 0)
                {
                    throw new ArgumentException("Age must be positive!");
                }
                this.age = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(String.Format("Name: {0}, Age: {1}", this.Name, this.Age));

            return sb.ToString();
        }
    }
}