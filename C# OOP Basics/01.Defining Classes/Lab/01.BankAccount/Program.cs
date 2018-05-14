using System;

class Program
{
    static void Main()
    {
        var bankAccount = new BankAccount();

        bankAccount.Id = 1;
        bankAccount.Balance = 15;

        Console.WriteLine($"Account {bankAccount.Id}, balance {bankAccount.Balance}");
    }
}

