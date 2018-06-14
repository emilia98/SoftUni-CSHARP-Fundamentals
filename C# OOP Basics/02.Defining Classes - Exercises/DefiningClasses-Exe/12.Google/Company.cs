using System;
using System.Collections.Generic;
using System.Text;


public class Company
{
    private string name;
    private string department;
    private decimal salary;

    public Company(string name, string department, decimal salary)
    {
        this.name = name;
        this.department = department;
        this.salary = salary;
    }

    public override string ToString()
    {
        return String.Format("{0} {1} {2:f2}", this.name, this.department, this.salary);
    }
}

