using System;
using System.Collections.Generic;

namespace TestClient
{
    public class StartUp
    {
        static Dictionary<int, BankAccount> accounts = new Dictionary<int, BankAccount>();

        static void Main()
        {
            string command = Console.ReadLine();

            while (command != "End")
            {
                var tokens = command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string type = tokens[0];
                int id = int.Parse(tokens[1]);


                if(type == "Create")
                {
                    Create(id);
                }
                else if(type == "Deposit")
                {
                    decimal amount = decimal.Parse(tokens[2]);
                    Deposit(id, amount);
                }
                else if(type == "Withdraw")
                {
                    decimal amount = decimal.Parse(tokens[2]);
                    Withdraw(id, amount);
                }
                else if(type == "Print")
                {
                    Print(id);
                }

                command = Console.ReadLine();
            }
        }

        static bool IsExistent(int id)
        {
            if(accounts.ContainsKey(id) == false)
            {
                Console.WriteLine("Account does not exist");
                return false;
            }
            
            return true;
        }

        static void Create(int id)
        {
            if(accounts.ContainsKey(id))
            {
                Console.WriteLine("Account already exists");
                return;
            }

            var account = new BankAccount(id);
            accounts.Add(id, account);
        }

        static void Deposit(int id, decimal amount)
        {
            if (IsExistent(id) == true)
            {
                accounts[id].Deposit(amount);
            }
        }

        static void Withdraw(int id, decimal amount)
        {
            if (IsExistent(id) == true)
            {
                accounts[id].Withdraw(amount);
            }
        }

        static void Print(int id)
        {
            if (IsExistent(id) == true)
            {
                Console.WriteLine(accounts[id]);
            }
        }
    }
}
