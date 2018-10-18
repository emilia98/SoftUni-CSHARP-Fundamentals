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

            while(command != "End")
            {
                var tokens = command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string type = tokens[0];
                int id = int.Parse(tokens[1]);

                switch(type)
                {
                    case "Create":
                        {
                            Create(id);
                            break;
                        }
                    case "Deposit":
                        {
                            decimal amount = decimal.Parse(tokens[2]);
                            Deposit(id, amount);
                            break;
                        }
                    case "Withdraw":
                        {
                            decimal amount = decimal.Parse(tokens[2]);
                            Withdraw(id, amount);
                            break;
                        }
                    case "Print":
                        {
                            Print(id);
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
                command = Console.ReadLine();
            }
        }

        static void Create(int id)
        {
            if(accounts.ContainsKey(id))
            {
                Console.WriteLine("Account already exists");
                return;
            }

            var account = new BankAccount();
            account.Id = id;
            account.Balance = 0;

            accounts.Add(id, account);
        }

        static void Deposit(int id, decimal amount)
        {
            if(accounts.ContainsKey(id) == false)
            {
                Console.WriteLine("Account does not exist");
                return;
            }

            accounts[id].Balance += amount;
        }

        static void Withdraw(int id, decimal amount)
        {
            if (accounts.ContainsKey(id) == false)
            {
                Console.WriteLine("Account does not exist");
                return;
            }

            var account = accounts[id];

            if (account.Balance < amount)
            {
                Console.WriteLine("Insufficient balance");
                return;
            }

            accounts[id].Balance -= amount;
        }

        static void Print(int id)
        {
            if (accounts.ContainsKey(id) == false)
            {
                Console.WriteLine("Account does not exist");
                return;
            }

            Console.WriteLine(accounts[id]);
        }
    }
}
