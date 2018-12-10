using NUnit.Framework;
using System;

[TestFixture]
public class TestHero
{
    [Test]
    public void TestIfHeroGainXP()
    {
        IWeapon weapon = new FakeWeapon();
        ITarget target = new FakeTarget();

        Hero hero = new Hero("Pesho", weapon);

        hero.Attack(target);

        int expectedResult = 10;
        int actualResult = hero.Experience;

        Assert.AreEqual(expectedResult, actualResult, "The value of gained XP is not correct!");
    }
}

