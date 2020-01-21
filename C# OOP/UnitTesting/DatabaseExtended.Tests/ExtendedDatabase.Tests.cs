using ExtendedDatabase;
using NUnit.Framework;
using System;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase.ExtendedDatabase database;
        
        private Person person ;
        private Person secondPerson;
        private readonly Person[] data ;

        [SetUp]
        public void Setup()
        {
            this.person = new Person(1, "Pesho");
            this.secondPerson = new Person(2, "Ivan");
            this.database = new ExtendedDatabase.ExtendedDatabase(person, secondPerson);
        }

        [Test]
        public void PersonUsernameWorksCorrectly()
        {
            string username = "Pesho";

            Assert.AreEqual(username, person.UserName);
        }
        [Test]
        public void TestIfCtorWorksCorrectly()
        {
            int expectedCount = 2;
            Assert.AreEqual(expectedCount, this.database.Count);
        }

        [Test]
        public void TestAddingCorrectly()
        {
            int expectedCount = 3;
            Person newPerson=new Person(3, "Gosho");
            this.database.Add(newPerson);

            Assert.AreEqual(expectedCount, this.database.Count);
        }

        [Test]
        public void AddingWhenFull()
        {
            for (int i = 3; i <= 16; i++)
            {
                this.database.Add(new Person(i,"userName"+i.ToString()));
            }
            var exMessage = Assert.Throws<InvalidOperationException>(() => this.database.Add(new Person(16, "User16")));
            Assert.That(exMessage.Message, Is.EqualTo("Array's capacity must be exactly 16 integers!"));
           
        }
        [Test]
        public void AddingUserWithExistingUsername()
        {
           
            var exMessage = Assert.Throws<InvalidOperationException>(() => this.database.Add(new Person(3, "Pesho")));
            Assert.That(exMessage.Message, Is.EqualTo("There is already user with this username!"));
        }

        [Test]
        public void AddingUserWithExistingID()
        {
            var exMessage = Assert.Throws<InvalidOperationException>(() => this.database.Add(new Person(2, "Iva")));
            Assert.That(exMessage.Message, Is.EqualTo("There is already user with this Id!"));
        }


        [Test]
        public void TestRemovingCorrectly()
        {
            int expectedCount = 1;
            this.database.Remove();
            Assert.AreEqual(expectedCount, this.database.Count);
        }

        [Test]
        public void TestRemovingWhenEmpty()
        {
            for (int i = 0; i < 2; i++)
            {
                this.database.Remove();
            }

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database.Remove();
            });
        }

        [Test]
        public void FindingUser()
        {
            string name = "Pesho";

            Assert.That(this.database.FindByUsername(name), Is.EqualTo(this.person));
        }

        [Test]
        public void FindingPersonWhoDoesNotExist()
        {
            string name = "Petar";
            var exMessage = Assert.Throws<InvalidOperationException>(() => this.database.FindByUsername(name));
            Assert.That(exMessage.Message, Is.EqualTo("No user is present by this username!"));
        }

        [Test]
        public void FindingPersonWhitEmptyName()
        {
            string name = string.Empty;

            var exMessage = Assert.Throws<ArgumentNullException>(() => this.database.FindByUsername(name), "Username parameter is null!");

        }

        [Test]
        public void FindUserIdNegativeNumber()
        {
            var exMessage = Assert.Throws<ArgumentOutOfRangeException>(() => this.database.FindById(-2), "Id should be a positive number!");
            //Assert.That(exMessage.Message, Is.EqualTo("Id should be a positive number!"));
        }

        [Test]
        public void FindUserByIDWithNotPresentId()
        {
            var exMessage = Assert.Throws<InvalidOperationException>(() => this.database.FindById(45), "No user is present by this ID!");
        }

        [Test]
        public void FindByIdTest()
        {
            Assert.That(this.database.FindById(1), Is.EqualTo(this.person));
        }
    }
}