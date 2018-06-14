using System;
using System.Collections.Generic;
using System.Text;

public class Person
{
    private string name;
    private Company company;
    private Car car;
    private List<Parent> parents;
    private List<Child> children;
    private List<Pokemon> pokemons;

    public Person(string name)
    {
        this.name = name;
        this.parents = new List<Parent>();
        this.children = new List<Child>();
        this.pokemons = new List<Pokemon>();
        this.company = null;
        this.car = null;
    }

    public void RegisterCompany(Company company)
    {
        this.company = company;
    }

    public void RegisterCar(Car car)
    {
        this.car = car;
    }

    public void AddPokemon(Pokemon pokemon)
    {
        this.pokemons.Add(pokemon);
    }

    public void AddParent(Parent parent)
    {
        this.parents.Add(parent);
    }

    public void AddChild(Child child)
    {
        this.children.Add(child);
    }

    public override string ToString()
    {
        var result = new List<string>();
        result.Add(this.name);

        // Add all info about Company
        result.Add("Company:");
        if(this.company != null)
        {
            result.Add(this.company.ToString());
        }

        // Add all info about Car
        result.Add("Car:");
        if (this.car != null)
        {
            result.Add(this.car.ToString());
        }

        // Add all info about Pokemons
        result.Add("Pokemon:");
        foreach(var pokemon in this.pokemons)
        {
            result.Add(pokemon.ToString());
        }
        
        // Add all info about Parents
        result.Add("Parents:");
        foreach(var parent in this.parents)
        {
            result.Add(parent.ToString());
        }

        // Add all info about Children
        result.Add("Children:");
        foreach(var child in children)
        {
            result.Add(child.ToString());
        }
           
        return String.Join('\n', result);
    }

}

