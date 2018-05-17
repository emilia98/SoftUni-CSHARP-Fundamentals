using System.Collections.Generic;

public class Person
{
    private string name;
    private int age;
    private List<BankAccount> accounts;

    public Person(string name, int age)
    {
        this.name = name;
        this.age = age;
        this.accounts = new List<BankAccount>();
    }

    public Person(string name, int age, List<BankAccount> accountsList)
    {
        this.name = name;
        this.age = age;
        this.accounts = accountsList;
    }

    public decimal GetBalance()
    {
        var accountsList = this.accounts;
        decimal balance = 0;

        foreach(var account in accountsList)
        {
            balance += account.Balance;
        }
        return balance;
    }
}
