using System;
using System.Collections.Generic;
using System.Reflection;

public class Person
{
    private string name;
    private Company company = null;
    private List<Pokemon> pokemons = new List<Pokemon>();
    private List<Parent> parents = new List<Parent>();
    private List<Child> children = new List<Child>();
    private Car car = null;

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    public Company Company
    {
        get { return this.company; }
        set { this.company = value; }
    }

    public Car Car
    {
        get { return this.car; }
        set { this.car = value; }
    }

    public List<Pokemon> Pokemons
    {
        get { return this.pokemons; }
        private set {; }
    }

    public List<Parent> Parents
    {
        get { return this.parents; }
        private set {; }
    }

    public List<Child> Children
    {
        get {  return this.children; }
        private set {; }
    }

    public void RegisterPokemon(Pokemon pokemon)
    {
        this.Pokemons.Add(pokemon);
    }

    public void RegisterParent(Parent parent)
    {
        this.Parents.Add(parent);
    }

    public void RegisterChild(Child child)
    {
        this.Children.Add(child);
    }

    
    public override string ToString()
    {
        var result = new List<string>();
        
        result.Add(this.Name);

        result.Add("Company:");
        if(this.Company != null)
        {
            result.Add(IterateProps(this.Company));
        }

        result.Add("Car:");
        if (this.Car != null)
        {
            result.Add(IterateProps(this.Car));
        }

        result.Add("Pokemon:");
        foreach(var pokemon in this.Pokemons)
        {
            result.Add(IterateProps(pokemon));
        }

        result.Add("Parents:");
        foreach (var parent in this.Parents)
        {
            result.Add(IterateProps(parent));
        }

        result.Add("Children:");
        foreach (var child in this.Children)
        {
            result.Add(IterateProps(child));
        }

        return String.Join('\n', result);
    }
    
    private string IterateProps(Object obj)
    {
        var result = new List<string>();
        PropertyInfo[] props = obj.GetType().GetProperties();

        foreach (var prop in props)
        {
            var propName = prop.Name;
            var propVal = obj.GetType().GetProperty(propName).GetValue(obj, null);
            
            if(propName == "Salary")
            {
                propVal = String.Format("{0:f2}", decimal.Parse(propVal.ToString()));
            }
            result.Add(propVal.ToString());
        }

        return String.Join(" ", result);
    }
}