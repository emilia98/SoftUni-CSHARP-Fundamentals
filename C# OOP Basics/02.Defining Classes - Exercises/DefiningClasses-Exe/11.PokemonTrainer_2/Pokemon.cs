﻿public class Pokemon
{
    private string name;
    private string element;
    private int health;

    public Pokemon(string name, string element, int health)
    {
        this.name = name;
        this.element = element;
        this.health = health;
    }

    public string Element
    {
        get { return this.element; }
    }

    public int ReduceHealth()
    {
        this.health -= 10;
        return this.health;
    }
}