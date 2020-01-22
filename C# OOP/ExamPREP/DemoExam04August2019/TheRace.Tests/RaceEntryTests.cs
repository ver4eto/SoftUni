using NUnit.Framework;
using System;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private RaceEntry raceEntry;
        [SetUp]
        public void Setup()
        {
            this.raceEntry = new RaceEntry();
        }

        [Test]
        public void TestCtor()
        {
            Assert.IsNotNull(raceEntry);
        }

        [Test]
        public void AddRiderTest()
        {
            UnitRider rider = new UnitRider("Ivan", new UnitMotorcycle("Model", 20, 200));
            this.raceEntry.AddRider(rider);
            Assert.That(this.raceEntry.Counter, Is.EqualTo(1));
        }

        [Test]
        public void AddNullRiderTest()
        {
            Assert.Throws<InvalidOperationException>(()=>this.raceEntry.AddRider(null), "Rider cannot be null.");
        }

        [Test]
        public void AddExistingRiderTest()
        {
            UnitRider rider = new UnitRider("Ivan", new UnitMotorcycle("Model", 20, 200));

            this.raceEntry.AddRider(rider);
            Assert.Throws<InvalidOperationException>(()=>this.raceEntry.AddRider(rider), "Rider Ivan is already added.");
        }

        [Test]
        public void CalculateAverageHorsePowerTestWorkingCorrectly()
        {
            UnitRider rider = new UnitRider("Ivan", new UnitMotorcycle("Model", 20, 200));
            UnitRider riderTwo = new UnitRider("Gosho", new UnitMotorcycle("Modelll", 50, 100));
            this.raceEntry.AddRider(rider);
            this.raceEntry.AddRider(riderTwo);
            double average = this.raceEntry.CalculateAverageHorsePower();

            Assert.AreEqual(35, average);
        }

        [Test]
        public void CalculateAverageWithLessthan2Participants()
        {
            UnitRider rider = new UnitRider("Ivan", new UnitMotorcycle("Model", 20, 200));
            this.raceEntry.AddRider(rider);
            Assert.Throws<InvalidOperationException>(()=>this.raceEntry.CalculateAverageHorsePower(), "The race cannot start with less than 2 participants.");
        }
    }
}