using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _03.Mankind
{
    class Human
    {
        protected string firstName;
        protected string lastName;

        public Human(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public virtual string FirstName
        {
            get { return this.firstName; }
            set
            {
                // CheckForCapitalLetter(value, "firstName");
                // CheckForValueLength(value, 4, "firstName");

                if (Regex.IsMatch(value, @"^[A-Z]") == false)
                {
                    throw new ArgumentException("Expected upper case letter! Argument: firstName");
                    // throw new ArgumentException($"Fuck");
                }

                if (value.Length < 4)
                {
                    throw new ArgumentException("Expected length at least 4 symbols! Argument: firstName");
                    // throw new ArgumentException($"Fuck");
                }


                this.firstName = value;
            }
        }

        public virtual string LastName
        {
            get { return this.lastName; }
            set
            {
                // CheckForCapitalLetter(value, "lastName");
                // CheckForValueLength(value, 3, "lastName");

                if (Regex.IsMatch(value, @"^[A-Z]") == false)
                {
                    throw new ArgumentException("Expected upper case letter! Argument: lastName");
                    // throw new ArgumentException($"Fuck");
                }

                if (value.Length < 3)
                {
                    throw new ArgumentException("Expected length at least 3 symbols! Argument: lastName");
                    // throw new ArgumentException($"Fuck");
                }

                this.lastName = value;
            }
        }

        private void CheckForCapitalLetter(string value, string argumentType)
        {
            if (Regex.IsMatch(value, @"^[A-Z]") == false)
            {
                throw new ArgumentException($"Expected upper case letter! Argument: {argumentType}");
                // throw new ArgumentException($"Fuck");
            }
        }

        private void CheckForValueLength(string value, int symbols, string argumentType)
        {
            if (value.Length < symbols)
            {
                // throw new ArgumentException($"Expected length at least {symbols} symbols! Argument: {argumentType}");
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(String.Format("First Name: {0}", this.FirstName));
            sb.Append('\n');
            sb.Append(String.Format("Last Name: {0}", this.LastName));
            sb.Append('\n');

            return sb.ToString();
        }
    }
}
