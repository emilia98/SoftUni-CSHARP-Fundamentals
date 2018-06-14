using System;
using System.Collections.Generic;
using System.Text;

public class Child
{
    private string name;
    private string birthday;

    public Child(string name, string birthday)
    {
        this.name = name;
        this.birthday = birthday;
    }

    public override string ToString()
    {
        return String.Format("{0} {1}", this.name, this.birthday);
    }
}