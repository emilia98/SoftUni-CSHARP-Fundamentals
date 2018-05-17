using System.Collections.Generic;
using System.Linq;

public class Person
{
    private string name;
    private int age;
    private List<BankAccount> accounts;

    public Person(string name, int age) : this(name, age, new List<BankAccount>())
    {
        
    }

    public Person(string name, int age, List<BankAccount> accountsList)
    {
        this.name = name;
        this.age = age;
        this.accounts = accountsList;
    }

    public decimal GetBalance()
    {
        return this.accounts.Select(a => a.Balance).Aggregate((a, b) => a + b);
    }
}