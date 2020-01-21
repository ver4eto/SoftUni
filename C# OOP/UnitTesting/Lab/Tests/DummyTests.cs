using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skeleton.Tests
{
   public class DummyTests
    {
        private Dummy dummy;
        private Axe axe;


        [SetUp]
        public void CreateDummy()
        {
            this.axe = new Axe(5, 2);
            this.dummy = new Dummy(10, 10);
        }

        [TearDown]
        public void TestCleanUp()
        {
            this.dummy = null;
            this.axe = null;
        }

        [Test]
        public void DummyLoosesHealthIfAttacked()
        {
            axe.Attack(dummy);
            Assert.That(dummy.Health, Is.EqualTo(5));
        }

        [Test]
        public void DeadDummyAfterAttack()
        {
            this.dummy.TakeAttack(10);
            Assert.That(()=>this.dummy.TakeAttack(10),
                Throws.InvalidOperationException.
                With.Message.EqualTo("Dummy is dead."));
        }

        [Test]
        public void DeadDummyCanGiveExperience()
        {
            this.dummy.TakeAttack(10);
            Assert.That(this.dummy.GiveExperience(), Is.EqualTo(10));
        }

        [Test]
        public void AliveDummyCanNotGiveExperience()
        {
            this.dummy.TakeAttack(2);


            Assert.That(()=>this.dummy.GiveExperience(),
                Throws.InvalidOperationException.
                With.Message.EqualTo("Target is not dead."));
        }
    }
}
