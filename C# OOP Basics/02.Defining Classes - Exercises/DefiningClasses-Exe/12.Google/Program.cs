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
            string infoType = tokens[1];

            if(!peopleData.ContainsKey(personName))
            {
                var person = new Person(personName);
                peopleData.Add(personName, person);
            }

            var infoTokens = tokens.Skip(2).ToArray();
            // Console.WriteLine(infoType);
            if (infoType == "company")
            {

                var company = CreateCompany(infoTokens);
                peopleData[personName].RegisterCompany(company);
            }
            else if (infoType == "pokemon")
            {
                var pokemon = CreatePokemon(infoTokens);
                peopleData[personName].AddPokemon(pokemon);
            }
            else if (infoType == "parents")
            {
                var parent = CreateParent(infoTokens);
                peopleData[personName].AddParent(parent);
            }
            else if (infoType == "children")
            {
                var child = CreateChild(infoTokens);
                peopleData[personName].AddChild(child);
            }
            else if(infoType == "car")
            {
                var car = CreateCar(infoTokens);
                peopleData[personName].RegisterCar(car);
            }
            input = Console.ReadLine();
        }

        string nameToSearch = Console.ReadLine();

        var personToDisplay = peopleData[nameToSearch];
        Console.WriteLine(personToDisplay.ToString());
    }

    static Company CreateCompany(string[] tokens)
    {
        string companyName = tokens[0];
        string department = tokens[1];
        decimal salary = decimal.Parse(tokens[2]);

        var company = new Company(companyName, department, salary);
        return company;
    }

    static Pokemon CreatePokemon(string[] tokens)
    {
        string pokemonName = tokens[0];
        string pokemonType = tokens[1];

        var pokemon = new Pokemon(pokemonName, pokemonType);
        return pokemon;
    }

    static Parent CreateParent(string[] tokens)
    {
        string parentName = tokens[0];
        string parentBirthday = tokens[1];

        var parent = new Parent(parentName, parentBirthday);
        return parent;
    }

    static Child CreateChild(string[] tokens)
    {
        string childName = tokens[0];
        string childBirthday = tokens[1];

        var child = new Child(childName, childBirthday);
        return child;
    }

    static Car CreateCar(string[] tokens)
    {
        string model = tokens[0];
        int speed = int.Parse(tokens[1]);

        var car = new Car(model, speed);
        return car;
    }
}

