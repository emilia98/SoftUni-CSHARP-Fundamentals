using System;
using System.Collections.Generic;
using System.Text;


public class Pokemon
{
    private string name;
    private string type;

    public Pokemon(string name, string type)
    {
        this.name = name;
        this.type = type;
    }

    public override string ToString()
    {
        return String.Format("{0} {1}", this.name, this.type);
    }
}

