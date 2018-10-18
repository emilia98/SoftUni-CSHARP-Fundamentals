using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccount
{
    class Person
    {
        private string name;
        private int age;
        private List<BankAccount> accounts;

        public Person(string name, int age) :this(name, age, new List<BankAccount>())
        { }

        public Person(string name, int age, List<BankAccount> accounts)
        {
            this.name = name;
            this.age = age;
            this.accounts = accounts;
        }

        public decimal GetBalance()
        {
            decimal total = 0;

            foreach(var account in this.accounts)
            {
                total += account.Balance;
            }

            return total;
        }
    }
}
