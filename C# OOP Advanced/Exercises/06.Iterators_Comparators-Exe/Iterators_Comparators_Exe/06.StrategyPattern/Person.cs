namespace _06.StrategyPattern
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
    }
}
