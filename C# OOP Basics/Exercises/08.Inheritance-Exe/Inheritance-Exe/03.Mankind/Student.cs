using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _03.Mankind
{
    class Student : Human
    {
        private string facultyNumber;

        public Student(string firstName, string lastName, string facultyNumber) : base(firstName, lastName)
        {
            this.FacultyNumber = facultyNumber;
        }

        public string FacultyNumber
        {
            get { return this.facultyNumber; }
            set
            {
                if(value.Length < 5 || value.Length > 10 || Regex.IsMatch(value, @"^([0-9a-zA-Z]+)$") == false)
                {
                    throw new ArgumentException("Invalid faculty number!");
                }
                this.facultyNumber = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(base.ToString());
            sb.Append(String.Format("Faculty number: {0}", this.FacultyNumber));
            // sb.Append('\n');

            return sb.ToString();
        }
    }
}
