using NUnit.Framework;
using System;

namespace TestDummy.Tests
{
    [TestFixture]
    public class TestDummy
    {
        [Test]
        public void IfDummyLosesHealthWhenAttacked()
        {
            Dummy dummy = new Dummy(20, 10);
            
            dummy.TakeAttack(5);

            int expectedResult = 15;
            int actualResult = dummy.Health;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(20, 10)]
        [TestCase(-20, 10)]
        public void DeadDummyShouldThrowExceptionIfAttacked(int health, int experience)
        {
            Dummy dummy = new Dummy(health, experience);

            Assert.That(() =>
            {
                dummy.TakeAttack(25);
                dummy.TakeAttack(5);
            }, Throws.InvalidOperationException.With.Message.EqualTo("Dummy is dead."));
        }

        [Test]
        public void DeadDummyCanGetXP()
        {
            Dummy dummy = new Dummy(-20, 10);

            int expectedResult = 10;
            int actualResult = dummy.GiveExperience();

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void AliveDummyCannotGetXP()
        {
            Dummy dummy = new Dummy(20, 10);

            Assert.Throws<InvalidOperationException>(() =>
            {
                dummy.GiveExperience();
            });
        }
    }
}
