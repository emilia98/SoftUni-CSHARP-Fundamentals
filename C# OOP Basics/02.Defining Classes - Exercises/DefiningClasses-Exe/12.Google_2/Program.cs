using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine();
        var peopleData = new Dictionary<string, Person>();

        while(input != "End")
        {
            var tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string personName = tokens[0];
            string inputType = tokens[1];

            Person person;

            if (!peopleData.ContainsKey(personName))
            {
                person = new Person();
                person.Name = personName;
                peopleData.Add(personName, person);
            }
            else
            {
                person = peopleData[personName];
            }
            
            var infoTokens = tokens.Skip(2).ToArray();

            if(inputType == "company")
            {
                AddCompany(person, infoTokens);
            }
            else if(inputType == "pokemon")
            {
                AddPokemon(person, infoTokens);
            }
            else if(inputType == "parents")
            {
                AddParent(person, infoTokens);
            }
            else if(inputType == "children")
            {
                AddChild(person, infoTokens);
            }
            else if(inputType == "car")
            {
                AddCar(person, infoTokens);
            }

            input = Console.ReadLine();
        }

        string personToFind = Console.ReadLine();

        if(peopleData.ContainsKey(personToFind))
        {
            var foundPerson = peopleData[personToFind];
            Console.WriteLine(foundPerson);
        }
    }

    static void AddCompany(Person person, string[] tokens)
    {
        var company = new Company();
        company.Name = tokens[0];
        company.Department = tokens[1];
        company.Salary = decimal.Parse(tokens[2]);

        person.Company = company;
    }

    static void AddPokemon(Person person, string[] tokens)
    {
        var pokemon = new Pokemon();
        pokemon.Name = tokens[0];
        pokemon.Type = tokens[1];

        person.RegisterPokemon(pokemon);
    }

    static void AddParent(Person person, string[] tokens)
    {
        var parent = new Parent();
        parent.Name = tokens[0];
        parent.Birthday = tokens[1];

        person.RegisterParent(parent);
    }

    static void AddChild(Person person, string[] tokens)
    {
        var child = new Child();
        child.Name = tokens[0];
        child.Birthday = tokens[1];

        person.RegisterChild(child);
    }

    static void AddCar(Person person, string[] tokens)
    {
        var car = new Car();
        car.Model = tokens[0];
        car.Speed = int.Parse(tokens[1]);

        person.Car = car;
    }
}