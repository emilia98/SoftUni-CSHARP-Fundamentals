using System;
using System.Collections.Generic;
using System.Text;

public class FakeWeapon : IWeapon
{
    public int AttackPoints => 10;

    public int DurabilityPoints { get; private set; } = 10;

    public void Attack(ITarget target)
    {
        if (this.DurabilityPoints <= 0)
        {
            throw new InvalidOperationException("Axe is broken.");
        }

        target.TakeAttack(this.AttackPoints);
        this.DurabilityPoints -= 1;
    }
}

