using System;
using System.Collections.Generic;

namespace _03.TestClient_2
{
    class Program
    {
        static void Main()
        {
            var bankSystem = new Dictionary<int, BankAccount>();
            string command = Console.ReadLine();

            while (command != "End")
            {
                var tokens = command.Split(' ');
                string commandName = tokens[0];
                int id = int.Parse(tokens[1]);

                switch (commandName)
                {
                    case "Create":
                        {
                            if (IsExisting(id, bankSystem, false))
                            {
                                Console.WriteLine("Account already exists");
                            }
                            else
                            {
                                bankSystem.Add(id, new BankAccount() { Id = id });
                            }
                            break;
                        }
                    case "Deposit":
                        {
                            decimal amount = decimal.Parse(tokens[2]);
                            if(IsExisting(id, bankSystem, true))
                            {
                                bankSystem[id].Deposit(amount);
                            }
                            break;
                        }
                    case "Withdraw":
                        {
                            decimal amount = decimal.Parse(tokens[2]);
                            if (IsExisting(id, bankSystem, true))
                            {
                                bankSystem[id].Withdraw(amount);
                            }
                            break;
                        }
                    case "Print":
                        {
                            if (IsExisting(id, bankSystem, true))
                            {
                                Console.WriteLine(bankSystem[id]);
                            }
                            break;
                        }
                }
                command = Console.ReadLine();
            }
        }


        static bool IsExisting(int accountId, Dictionary<int, BankAccount> accounts, bool toPrint)
        {
            bool isAccountExisting = accounts.ContainsKey(accountId);

            if(!isAccountExisting && toPrint)
            {
                Console.WriteLine("Account does not exist");
            }

            return isAccountExisting;
        }
    }
}
