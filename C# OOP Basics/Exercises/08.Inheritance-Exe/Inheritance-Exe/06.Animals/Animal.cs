using System;
using System.Text;

namespace _06.Animals
{
    class Animal
    {
        protected string name;
        protected int age;
        protected string gender;

        public Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if(String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid input!");
                }
                this.name = value;
            }
        }

        public int Age
        {
            get { return this.age; }
            set
            {
                if(String.IsNullOrEmpty(value.ToString()) ||  value <= 0)
                {
                    throw new ArgumentException("Invalid input!");
                }
                this.age = value;
            }
        }

        public virtual string Gender
        {
            get { return this.gender; }
            set
            {
                if(String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid input!");
                }
                this.gender = value;
            }
        }

        public virtual string ProduceSound()
        {
            return "";
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(String.Format("{0}", this.GetType().Name));
            sb.AppendLine(String.Format("{0} {1} {2}", this.Name, this.Age, this.Gender));
            sb.Append(String.Format("{0}", this.ProduceSound()));
            return sb.ToString();
        }
    }
}