using CarManager;
using NUnit.Framework;
using System;

namespace Tests
{
    public class CarTests
    {
        private Car car;
        private readonly Car myCar = new Car("Seat", "Leon", 10, 2);

        [SetUp]
        public void Setup()
        {
            this.car = myCar;
        }

        [Test]
        public void TestMake()
        {
            string make = this.car.Make;
            Assert.AreEqual("Seat", make);
        }

        [Test]
        public void TestEmptyMake()
        {
            var exMessage = Assert.Throws<ArgumentException>(() => new Car("", "Opel", 2.5, 1), "Make cannot be null or empty!");
        }

        [Test]
        public void TestModel()
        {
            string model = this.car.Model;
            Assert.AreEqual(model, this.car.Model);
        }
        [Test]
        public void TestEmptyModel()
        {
            var exMessage = Assert.Throws<ArgumentException>(() => new Car("Vw", "", 2.5, 1), "Model cannot be null or empty!");
        }

        [Test]
        public void TestFuelConsumption()
        {
            double fuelConsumption = this.car.FuelConsumption;
            Assert.AreEqual(fuelConsumption, this.car.FuelConsumption);
        }

        [Test]
        public void TestNegativeFuelConsumption()
        {
            var exMessage = Assert.Throws<ArgumentException>(() => new Car("Vw", "Golf", -2.5, 1), "Fuel consumption cannot be zero or negative!");
        }

        //[Test]
        //public void Test_Drive()
        //{
        //    this.car.Refuel(1);
        //    this.car.Drive(1);

        //    Assert.AreEqual(0.9, this.car.FuelAmount);
        //}

        [Test]
        public void TestNegativeRefuelAmount()
        {
            //this.car.Drive(50);
            Assert.Throws<ArgumentException>(()=>this.car.Refuel(-2), "Fuel amount cannot be negative!");
        }

        [Test]
        public void TestFuelCapacity()
        {
            double capacity = 2;
            Assert.AreEqual(capacity, this.car.FuelCapacity);
        }

        [Test]
        public void TestNegativeFuelCapacity()
        {
            Assert.Throws<ArgumentException>(()=>new Car("Vw","Up",4.7, -3), "Fuel capacity cannot be zero or negative!");
        }

        [Test]
        public void FuelAmountIsBiggerThanCapacity()
        {
            this.car.Refuel(6);
            Assert.AreEqual(2, this.car.FuelAmount);
        }

        [Test]
        public void TestDrive()
        {
            this.car.Drive(20);
            Assert.AreEqual(0,this.car.FuelAmount);
        }

        [Test]
        public void TestUnsufficientFuelAmount()
        {
            Assert.Throws<InvalidOperationException>(()=>this.car.Drive(50), "You don't have enough fuel to drive!");
        }

        //[Test]
        //public void NegativeFuelAmount()
        //{
        //    Car current = new Car("Opel", "Zafira", 10, 10);
        //    current.FuelAmount -= 2;
        //}
    }
}