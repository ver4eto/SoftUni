using FightingArena;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Tests
{
    public class ArenaTests
    {

        private Arena arena;
        private Warrior one = new Warrior("One", 50, 70);
        private Warrior two = new Warrior("Two", 60, 80);
        private Warrior three = new Warrior("Three", 70, 90);
        private Warrior four = new Warrior("Four", 80, 100);
        private Warrior five = new Warrior("Five", 90, 90);

        private readonly List<Warrior> warriors = new List<Warrior>()/* { one, two, three, four, five }*/;

        [SetUp]
        public void Setup()
        {

            this.arena = new Arena();

        }

        [Test]
        public void TestCtor()
        {
            Assert.IsNotNull(this.arena);
            //Assert.AreEqual("One", this.warriors[0].Name);
            //Assert.AreEqual("Two", this.warriors[1].Name);
            //Assert.AreEqual("Three", this.warriors[2].Name);
            //Assert.AreEqual("Four", this.warriors[3].Name);
            //Assert.AreEqual("Five", this.warriors[4].Name);
        }

        //[Test]
        //public void ISREadOnlyCollection()
        //{
        //    Assert.Throws<Exception>(() => this.warriors.Add(new Warrior("Pesho", 10, 30)));
        //}

        [Test]
        public void TestEnrollWorksCorrectly()
        {
            this.arena.Enroll(one);
            this.arena.Enroll(two);

            Assert.AreEqual(2, this.arena.Count);
        }

        [Test]
        public void EnrollThrowException()
        {
            this.arena.Enroll(one);
            this.arena.Enroll(two);
            Assert.Throws<InvalidOperationException>(() => this.arena.Enroll(new Warrior("One", 40, 50)), "Warrior is already enrolled for the fights!");
        }

        [Test]
        public void FightWorksCorrectly()
        {
            this.arena.Enroll(one);
            this.arena.Enroll(two);

            this.arena.Fight("One", "Two");
            //this.HP -= warrior.Damage;
            //    private Warrior one = new Warrior("One", 50, 70);
            //private Warrior two = new Warrior("Two", 60, 80);

            Assert.AreEqual(10, one.HP);

        }

        [Test]
        public void FightExceptionMissingAttacker()
        {
            this.arena.Enroll(one);
            this.arena.Enroll(two);
            string attacker = "Three";
            string defender = "Two";

            Assert.Throws<InvalidOperationException>(() => this.arena.Fight(attacker,defender ),
                string.Format($"There is no fighter with name {0} enrolled for the fights!",attacker));
           
        }

        [Test]
        public void FightExceptionMissingDefender()
        {
            this.arena.Enroll(one);
            this.arena.Enroll(two);
            string attacker = "One";
            string defender = "Three";

            Assert.Throws<InvalidOperationException>(() => this.arena.Fight(attacker, defender),
                string.Format($"There is no fighter with name {0} enrolled for the fights!", defender));

        }
    }
}
