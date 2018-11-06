using System;

namespace _06.BirthdayCelebrations
{
    public class Citizen : Birthdater, IMember
    {
        public string Id { get; private set; }

       //  public DateTime Birthday { get; private set; }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public Citizen(string name, int age, string id, DateTime birthday)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthday = birthday;
        }
    }
}