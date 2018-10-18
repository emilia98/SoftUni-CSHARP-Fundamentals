using System;
using System.Collections.Generic;

namespace BankAccount
{
    public class StartUp
    {
        static void Main()
        {
            var personA = new Person("John", 22);

            var acc_1 = new BankAccount();
            var acc_2 = new BankAccount();
            var accounts = new List<BankAccount>();
            acc_1.Deposit(250);
            acc_1.Withdraw(50);
            acc_2.Deposit(22.506m);

            accounts.Add(acc_1);
            accounts.Add(acc_2);

            var personB = new Person("Jane", 31, accounts);

            Console.WriteLine(personA.GetBalance());
            Console.WriteLine(personB.GetBalance());
        }
    }
}
