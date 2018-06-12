using System.Collections.Generic;

public class Trainer
{
    private string name;
    private int badgesCount = 0;
    private List<Pokemon> pokemons = new List<Pokemon>();

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    public int Badges
    {
        get { return this.badgesCount; }
        set { this.badgesCount = value; }
    }

    public List<Pokemon> Pokemons
    {
        get { return this.pokemons; }
        private set {; }
    }

    public void AddPokemon(Pokemon pokemon)
    {
        this.pokemons.Add(pokemon);
    }
}