using System;
using System.Collections.Generic;

namespace _03.StudentSystem
{
    public class StudentSystem
    {
        private Dictionary<string, Student> repo;

        public StudentSystem()
        {
            this.Repo = new Dictionary<string, Student>();
        }

        public Dictionary<string, Student> Repo
        {
            get { return repo; }
            private set { repo = value; }
        }

        public void ParseCommand()
        {
            string[] args = Console.ReadLine().Split();

            if (args[0] == "Create")
            {
                CreateStudent(args);
            }
            else if (args[0] == "Show")
            {
                ShowStudent(args);
            }
            else if (args[0] == "Exit")
            {
                Exit();
            }
        }

        public void CreateStudent(string[] args)
        {
            var name = args[1];
            var age = int.Parse(args[2]);
            var grade = double.Parse(args[3]);

            if (!this.Repo.ContainsKey(name))
            {
                var student = new Student(name, age, grade);
                this.Repo[name] = student;
            }
        }

        public void ShowStudent(string[] args)
        {
            var name = args[1];
            if (this.Repo.ContainsKey(name))
            {
                var student = this.Repo[name];
                string view = $"{student.Name} is {student.Age} years old. {GetComment(student)}";
                Console.WriteLine(view);
            }
        }

        public string GetComment(Student student)
        {
            if (student.Grade >= 5.00)
            {
                return "Excellent student.";
            }
            else if (student.Grade < 5.00 && student.Grade >= 3.50)
            {
                return "Average student.";
            }
            else
            {
                return "Very nice person.";
            }
        }

        public void Exit()
        {
            Environment.Exit(0);
        }
    }
}
