namespace Telecom.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
   

    public class Tests
    {
        private Phone phone;
        private Dictionary<string, string> phonebook;

        [SetUp]
        public void SetUp()
        {
            this.phone = new Phone("Make", "Model");
            this.phonebook = new Dictionary<string, string>();
        }

        [Test]
        public void TestCtor()
        {
            Assert.AreEqual("Make", this.phone.Make);
            Assert.AreEqual("Model", this.phone.Model);
            Assert.IsNotNull(this.phonebook);
        }

        [Test]
        public void TestNullMake()
        {
            Assert.Throws<ArgumentException>(() => new Phone("", "My"),"Invalid Make!");
        }

        [Test]
        public void TestNullModel()
        {
            Assert.Throws<ArgumentException>(() => new Phone("My", ""), "Invalid Model!");
        }

        [Test]
        public void AddContactToPhonebook()
        {
            this.phone.AddContact("Ivan", "0887929375");
            Assert.AreEqual(1, this.phone.Count);
            this.phonebook.Add("Ivan", "0887929375");
           
        }

        [Test]
        public void AddAlreadyExistingContact()
        {
            this.phone.AddContact("Pesho", "0887263859");
            Assert.Throws<InvalidOperationException>(()=>this.phone.AddContact("Pesho","08734629"), "Person already exists!");
        }

        [Test]
        public void TestCall()
        {
            this.phone.AddContact("Pesho", "0887263859");
            Assert.AreEqual("Calling Pesho - 0887263859...", this.phone.Call("Pesho"));
        }
        [Test]
        public void TestNonExistingNameCalling()
        {
            Assert.Throws<InvalidOperationException>(()=>this.phone.Call("Stoyan"), "Person doesn't exists!");
        }
    }
}