using NUnit.Framework;
using System;

namespace TestAxe.Tests
{
    [TestFixture]
    public class AxeTests
    {
        private Dummy dummy;

        [SetUp]
        public void SetUp()
        {
            this.dummy = new Dummy(25, 20);
        }

        [Test]
        public void TestIfWeaponLosesDurabilityAfterAttack()
        {
            // Dummy dummy = new Dummy(25, 20);
            Axe axe = new Axe(10, 20);

            axe.Attack(this.dummy);
            axe.Attack(this.dummy);

            int expectedResult = 18;
            int actualResult = axe.DurabilityPoints;
            Assert.AreEqual(expectedResult, actualResult, "Wrong value of the durablity of a weapon after an attack!");
        }

        [Test]
        public void TestAttackingWithBrokenWeapon()
        {
            // Dummy dummy = new Dummy(25, 20);
            Axe axe = new Axe(10, 1);

            Assert.Throws<InvalidOperationException>(() =>
            {
                axe.Attack(this.dummy);
                axe.Attack(this.dummy);
            }, "When attacking with a broken weapon, an InvalidOperationException should be thrown");
        }

        [TestCase(10, -1)]
        [TestCase(10, 0)]
        public void TestAttackingWithBrokenWeaponAtTheInit(int axeAttack, int axeDurability)
        {
            // Dummy dummy = new Dummy(25, 20);
            Axe axe = new Axe(axeAttack, axeDurability);

            Assert.Throws(typeof(InvalidOperationException), () =>
            {
                axe.Attack(this.dummy);
            }, "When attacking with a broken weapon, an InvalidOperationException should be thrown");
        }
    }
}
