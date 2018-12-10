using System;
using System.Collections.Generic;
using System.Text;

public class FakeTarget : ITarget
{
    public int Health { get; private set; } = 8;

    public int GiveExperience() => 10;

    public bool IsDead()
    {
        return this.Health <= 0;
    }

    public void TakeAttack(int attackPoints)
    {
        if (this.IsDead())
        {
            throw new InvalidOperationException("Dummy is dead.");
        }

        this.Health -= attackPoints;
    }
}

