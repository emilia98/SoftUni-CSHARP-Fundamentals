using System;

namespace _07.EqualityLogic
{
    public class Person : IPerson
    {
        public string Name { get; }

        public int Age { get; }

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public override bool Equals(object other)
        {
            return this.GetHashCode().Equals(other.GetHashCode());
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode() * 7 - this.Age.GetHashCode() * 17;
        }

        /*
        public int CompareTo(Person other)
        {
            int nameComparison = this.Name.CompareTo(other.Name);
            int ageComparison = this.Age.CompareTo(other.Age);
            
            if(nameComparison == 0 && ageComparison == 0)
            {
                return 0;
            }
            return 1;
        }
        */
    }
}