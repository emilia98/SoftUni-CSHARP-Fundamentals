using System;

namespace TestClient
{
    class BankAccount
    {
        private int id;
        private decimal balance;

        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public decimal Balance
        {
            get { return this.balance; }
            set { this.balance = value; }
        }

        /*
        public void Deposit(decimal amount)
        {
            this.Balance += amount;
        }


        public void Withdraw(decimal amount)
        {
            /*
            if(this.Balance < amount)
            {
                Console.WriteLine("Insufficient balance");
                return;
            }
            
            this.Balance -= amount;
        }
    */

        public override string ToString()
        {
            return $"Account ID{this.Id}, balance {this.Balance:f2}";
        }
    }
}
