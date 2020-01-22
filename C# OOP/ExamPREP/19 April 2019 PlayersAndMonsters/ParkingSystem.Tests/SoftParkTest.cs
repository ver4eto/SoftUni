namespace ParkingSystem.Tests
{
    using NUnit.Framework;
    using System.Collections.Generic;

    public class SoftParkTest
    {
        private Car car;
        private readonly Car myCar = new Car("Make", "string");
        private SoftPark park;
        private Dictionary<string, Car> parkPlaces = new Dictionary<string, Car>
        {
            { "1",null },
            { "2",null},
            { "3",null}

        };


        [SetUp]
        public void Setup()
        {
            this.car = myCar;
            this.park = new SoftPark();
        }

        [Test]
        public void TestConstructorOfCar()
        {
            Assert.AreEqual("Make", this.car.Make);
            Assert.AreEqual("string", this.car.RegistrationNumber);
        }

        [Test]
       


    }
}