namespace TheTankGame.Tests
{
    using NUnit.Framework;
    using System.Collections.Generic;
    using TheTankGame.Entities.Miscellaneous;
    using TheTankGame.Entities.Parts;
    using TheTankGame.Entities.Parts.Contracts;
    using TheTankGame.Entities.Vehicles;

    [TestFixture]
    public class BaseVehicleTests
    {
        [Test]
        public void TestWithInvalidData()
        {
            string[] models = new string[] { "  ", null };
            double[] weight = new double[] { 0, -7 };
            decimal[] price = new decimal[] { 0, -7 };
            int[] attack = new int[] { -7 };
            int[] defense = new int[] { -7 };
            int[] hitPoints = new int[] { -7 };
            var assembler = new VehicleAssembler();

            string validModel = "valid";
            double validWeight = 150;
            decimal validPrice = 150;
            int validAttack = 16;
            int validDefence = 33;
            int validHitPoints = 42;

            Assert.That(() =>
            {
                new Revenger(models[0], validWeight, validPrice, validAttack, validDefence, validHitPoints, assembler);
            }, Throws.ArgumentException.With.Message.EqualTo("Model cannot be null or white space!"));

            Assert.That(() =>
            {
                new Vanguard(models[1], validWeight, validPrice, validAttack, validDefence, validHitPoints, assembler);
            }, Throws.ArgumentException.With.Message.EqualTo("Model cannot be null or white space!"));

            Assert.That(() =>
            {
                new Revenger(validModel, weight[0], validPrice, validAttack, validDefence, validHitPoints, assembler);
            }, Throws.ArgumentException.With.Message.EqualTo("Weight cannot be less or equal to zero!"));

            Assert.That(() =>
            {
                new Vanguard(validModel, weight[1], validPrice, validAttack, validDefence, validHitPoints, assembler);
            }, Throws.ArgumentException.With.Message.EqualTo("Weight cannot be less or equal to zero!"));

            Assert.That(() =>
            {
                new Vanguard(validModel, validWeight, price[0], validAttack, validDefence, validHitPoints, assembler);
            }, Throws.ArgumentException.With.Message.EqualTo("Price cannot be less or equal to zero!"));

            Assert.That(() =>
            {
                new Revenger(validModel, validWeight, price[1], validAttack, validDefence, validHitPoints, assembler);
            }, Throws.ArgumentException.With.Message.EqualTo("Price cannot be less or equal to zero!"));

            Assert.That(() =>
            {
                new Revenger(validModel, validWeight, validPrice, attack[0], validDefence, validHitPoints, assembler);
            }, Throws.ArgumentException.With.Message.EqualTo("Attack cannot be less than zero!"));

            Assert.That(() =>
            {
                new Revenger(validModel, validWeight, validPrice, validAttack, defense[0], validHitPoints, assembler);
            }, Throws.ArgumentException.With.Message.EqualTo("Defense cannot be less than zero!"));

            Assert.That(() =>
            {
                new Revenger(validModel, validWeight, validPrice, validAttack, validDefence, hitPoints[0], assembler);
            }, Throws.ArgumentException.With.Message.EqualTo("HitPoints cannot be less than zero!"));
        }

        [Test]
        public void TestMethods()
        {
            // All Valid
            var vehicle = new Vanguard("SA-203", 100, 300, 1000, 450, 2000, new VehicleAssembler());

           
            var arsenalPart = new ArsenalPart("Arsenal", 100, 300, 1000);
            var shellPart = new ShellPart("Shell", 100, 300, 1000);
            var shellTwoPart = new ShellPart("Shell2", 100, 300, 1000);
            var endurancePart = new EndurancePart("Endurance", 100, 300, 1000);

            // Test If AddArsenalPart adds new part
            vehicle.AddArsenalPart(arsenalPart);

            // Test If AddShellPart adds new part
            vehicle.AddShellPart(shellPart);
            vehicle.AddShellPart(shellTwoPart);

            // Test if AddEndurancePart adds new part
            vehicle.AddEndurancePart(endurancePart);


            var partsList = (List<IPart>)vehicle.Parts;
            string[] modelsList = new string[] { "Arsenal", "Shell", "Shell2", "Endurance" };
            var typesList = new string[] { "ArsenalPart", "ShellPart", "ShellPart", "EndurancePart" };

            for(int index = 0; index < partsList.Count; index++)
            {
                Assert.AreEqual(partsList[index].Model, modelsList[index]);
                Assert.AreEqual(partsList[index].GetType().Name, typesList[index], "Incorrect part type!");
            }
        }

        [Test]
        public void TestToString()
        {
            // Test if ToString() returns all the correct result
            var vehicle = new Vanguard("SA-203", 100, 300, 1000, 450, 2000, new VehicleAssembler());
            
            var arsenalPart = new ArsenalPart("Arsenal", 100, 300, 1000);
            var shellPart = new ShellPart("Shell", 100, 300, 1000);
            var shellTwoPart = new ShellPart("Shell2", 100, 300, 1000);
            var endurancePart = new EndurancePart("Endurance", 100, 300, 1000);
            
            vehicle.AddArsenalPart(arsenalPart);
            
            vehicle.AddShellPart(shellPart);
            vehicle.AddShellPart(shellTwoPart);
            
            vehicle.AddEndurancePart(endurancePart);
            
            var expectedResult = "Vanguard - SA-203\r\nTotal Weight: 500.000\r\nTotal Price: 1500.000\r\nAttack: 2000\r\nDefense: 2450\r\nHitPoints: 3000\r\nParts: Arsenal, Shell, Shell2, Endurance";
            var actualResult = vehicle.ToString();

            Assert.AreEqual(expectedResult, actualResult);
        }

        // TotalWeight
        // TotalPrice
        // TotalAttack
        // TotalDefense
        // TotalHitPoints
    }
}