using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Mankind
{
    class Worker : Human
    {
        private decimal weekSalary;
        private double workingHours;

        public Worker(string firstName, string lastName,
            decimal weekSalary, double workingHours) : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkingHours = workingHours;
        }

        public decimal WeekSalary
        {
            get { return this.weekSalary; }
            set
            {
                if(value <= 10)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
                    // throw new ArgumentException("fuck");
                }
                this.weekSalary = value;
            }
        }

        public double WorkingHours
        {
            get { return this.workingHours; }
            set
            {
                if(value < 1 || value > 12)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
                    // throw new ArgumentException("fuck");
                }
                this.workingHours = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(base.ToString());

            sb.Append(String.Format("Week Salary: {0:f2}", this.WeekSalary));
            sb.Append('\n');
            sb.Append(String.Format("Hours per day: {0:f2}", this.WorkingHours));
            sb.Append('\n');
            sb.Append(String.Format("Salary per hour: {0:f2}", this.weekSalary / ((decimal)this.workingHours * 5.0m)));

            return sb.ToString();
        }
    }
}
