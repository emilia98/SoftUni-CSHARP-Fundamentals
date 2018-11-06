using System;
using System.Collections.Generic;
using System.Text;

namespace _08.MilitaryService
{
    public class Private : Soldier
    {
        public decimal Salary { get; private set; }

        public Private(int id, string firstName, string lastName, decimal salary) : base(id, firstName, lastName)
        {
            this.Salary = salary;
        }
    }
}
