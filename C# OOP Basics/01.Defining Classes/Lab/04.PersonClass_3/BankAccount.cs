using System;

public class BankAccount
{
    private int id;

    public int Id
    {
        get { return id; }
        set { id = value; }
    }

    private decimal balance;

    public decimal Balance
    {
        get { return balance; }
        set { balance = value; }
    }

    public void Deposit(decimal amount)
    {
        this.Balance += amount;
    }

    public bool Withdraw(decimal amount)
    {
        if (this.Balance < amount)
        {
            Console.WriteLine("Insufficient balance");
            return false;
        }
        this.Balance -= amount;
        return true;
    }

    public override string ToString()
    {
        return $"Account ID{this.Id}, balance {this.Balance:F2}";
    }
}