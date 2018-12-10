using Moq;
using NUnit.Framework;

[TestFixture]
public class MockingTest
{
    [Test]
    public void TestIfHeroGainXP()
    {
        Mock<IWeapon> fakeWeapon = new Mock<IWeapon>();
        Mock<ITarget> fakeTarget = new Mock<ITarget>();

        fakeWeapon.Setup(x => x.AttackPoints).Returns(10);
        fakeWeapon.Setup(x => x.DurabilityPoints).Returns(10);

        fakeTarget.Setup(x => x.Health).Returns(10);
        fakeTarget.Setup(x => x.GiveExperience()).Returns(10);
        fakeTarget.Setup(x => x.IsDead()).Returns(true);

        var hero = new Hero("Pesho", fakeWeapon.Object);
        hero.Attack(fakeTarget.Object);

        int expectedResult = 10;
        int actualResult = hero.Experience;

        Assert.AreEqual(expectedResult, actualResult, "The value of gained XP is not correct!");

    }
}