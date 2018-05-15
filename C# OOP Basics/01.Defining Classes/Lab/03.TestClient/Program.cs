using System;
using System.Collections.Generic;

class Program
{
    public static Dictionary<int, BankAccount> bankSystem;
    static void Main()
    {
        bankSystem = new Dictionary<int, BankAccount>();
        string command = Console.ReadLine();

        while (command != "End")
        {
            var tokens = command.Split(" ");
            int id = int.Parse(tokens[1]);
            var account = SearchForAccount(id);

            if (tokens[0] == "Create")
            {
                if (bankSystem.ContainsKey(id))
                {
                    Console.WriteLine("Account already exists");
                }
                else
                {
                    var newAccount = new BankAccount();
                    newAccount.Id = id;
                    newAccount.Balance = 0m;
                    bankSystem.Add(id, newAccount);
                }
            }
            else if (tokens[0] == "Deposit")
            {
                if (account == null)
                {
                    PrintForNonExistingAccount();
                }
                else
                {
                    decimal amount = decimal.Parse(tokens[2]);
                    account.Balance += amount;
                }
            }
            else if (tokens[0] == "Withdraw")
            {
                if (account == null)
                {
                    PrintForNonExistingAccount();
                }
                else
                {
                    decimal amount = decimal.Parse(tokens[2]);

                    if (amount > account.Balance)
                    {
                        Console.WriteLine("Insufficient balance");
                    }
                    else
                    {
                        account.Balance -= amount;
                    }
                }
            }
            else if (tokens[0] == "Print")
            {
                if (account == null)
                {
                    PrintForNonExistingAccount();
                }
                else
                {
                    Console.WriteLine(account);
                }
            }
            command = Console.ReadLine();
        }
    }

    static BankAccount SearchForAccount(int id)
    {
        if (bankSystem.ContainsKey(id))
        {
            return bankSystem[id];
        }
        return null;
    }

    static void PrintForNonExistingAccount()
    {
        Console.WriteLine("Account does not exist");
    }
}