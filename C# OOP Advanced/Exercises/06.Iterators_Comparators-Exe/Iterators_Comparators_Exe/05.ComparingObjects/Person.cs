using System;

namespace _05.ComparingObjects
{
    public class Person : IComparable<Person>, IPerson
    {
        public string Name { get; }

        public int Age { get; }

        public string Town { get; }

        public Person(string name, int age, string town)
        {
            this.Name = name;
            this.Age = age;
            this.Town = town;
        }

        public int CompareTo(Person other)
        {
            var nameComparison = this.Name.CompareTo(other.Name);

            if (nameComparison != 0)
            {
                return nameComparison;
            }

            var ageComparison = this.Age.CompareTo(other.Age);

            if(ageComparison != 0)
            {
                return ageComparison;
            }

            var townComparison = this.Town.CompareTo(other.Town);
            return townComparison;
        }
    }
}