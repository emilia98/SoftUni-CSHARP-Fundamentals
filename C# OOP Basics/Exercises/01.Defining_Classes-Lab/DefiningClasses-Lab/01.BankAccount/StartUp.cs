using System;

namespace BankAccount
{
    public class StartUp
    {
        static void Main()
        {
            BankAccount acc = new BankAccount();

            acc.Id = 1;
            acc.Balance = 500;

            Console.WriteLine($"Account {acc.Id}, Balance = {acc.Balance}");
        }
    }
}
