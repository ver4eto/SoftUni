namespace ParkingSystem.Tests
{
    using NUnit.Framework;
    using System;

    public class SoftParkTest
    {
        private Car car;
        private SoftPark parking;

        [SetUp]
        public void Setup()
        {
            this.car = new Car("Make", "CA2034KT");
            this.parking = new SoftPark();

        }

        [Test]
        public void TestCtorCar()
        {
            Assert.AreEqual("Make", this.car.Make);
            Assert.AreEqual("CA2034KT", this.car.RegistrationNumber);
        }

        [Test]
        public void TestCtorSoftPark()
        {
            Assert.IsNotNull(this.parking);
        }
        [Test]
        public void TestNumberOfParkinPlaces()
        {
            Assert.AreEqual(12,this.parking.Parking.Count);
        }

        [Test]
        public void TestParkCar()
        {
            SoftPark parking = new SoftPark();
            Assert.That(parking.ParkCar("A1", this.car),Is.EqualTo("Car:CA2034KT parked successfully!"));
        }

        [Test]
        public void TestCarIsAlreadyParked()
        {
            SoftPark parking = new SoftPark();
            parking.ParkCar("A1", this.car);
            Assert.Throws<InvalidOperationException>(()=>parking.ParkCar("A2", this.car), "Car is already parked!");
        }

       [Test]
       public void ParkOnNonExistingParkPlace()
        {
            SoftPark park = new SoftPark();
            Assert.Throws<ArgumentException>(()=> park.ParkCar("A0",null), "Parking spot doesn't exists!");
        }

        [Test]
        public void ParkingSpotIsTakenAlready()
        {
            SoftPark park = new SoftPark();
            park.ParkCar("A1", this.car);
            Assert.Throws<ArgumentException>(()=>park.ParkCar("A1",new Car("Make","CA234")), "Parking spot is already taken!");
        }

        [Test]
        public void TestRemoving()
        {
            this.parking.ParkCar("A1", this.car);
            this.parking.ParkCar("A2", new Car("Vw", "123"));
            Assert.That(this.parking.RemoveCar("A1", this.car), 
                Is.EqualTo(string.Format("Remove car:{0} successfully!", this.car.RegistrationNumber)));
        }

        [Test]
        public void TestRemoveNonExistingCarSpot()
        {
            //SoftPark softPark = new SoftPark();
            Assert.Throws<ArgumentException>(()=>this.parking.RemoveCar("ZZ",this.car), "Parking spot doesn't exists!");
        }

        [Test]
        public void TestRemoveNonExistingCarOnSpot()
        {
            SoftPark softPark = new SoftPark();
            Car current = new Car("Bently", "975");
            softPark.ParkCar("A1", new Car("Lada", "293746"));
            Assert.Throws<ArgumentException>(()=>softPark.RemoveCar("A1",current), "Car for that spot doesn't exists!");
        }
    }
}