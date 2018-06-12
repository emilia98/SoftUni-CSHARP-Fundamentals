using System.Collections.Generic;

public class Trainer
{
    private string name;
    private int badgesCount;
    private List<Pokemon> pokemons;


    public List<Pokemon> Pokemons
    {
        get { return this.pokemons; }
        private set {; }
    }

    public int Badges
    {
        get { return this.badgesCount; }
        private set { ;}
    }

    public Trainer(string name)
    {
        this.name = name;
        this.badgesCount = 0;
        this.pokemons = new List<Pokemon>();
    }

    public void IncreaseBadges()
    {
        this.badgesCount++;
    }

    public void AddPokemon(Pokemon pokemon)
    {
        this.pokemons.Add(pokemon);
    }

    public void RemovePokemon(int index)
    {
        this.pokemons.RemoveAt(index);
    }
}