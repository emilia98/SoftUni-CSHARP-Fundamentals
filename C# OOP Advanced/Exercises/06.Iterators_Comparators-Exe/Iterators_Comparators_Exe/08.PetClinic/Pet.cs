namespace _08.PetClinic
{
    public class Pet : IPet
    {
        public string Name { get; }

        public int Age { get; }

        public string Kind { get; }

        public Pet(string name, int age, string kind)
        {
            this.Name = name;
            this.Age = age;
            this.Kind = kind;
        }
    }
}
