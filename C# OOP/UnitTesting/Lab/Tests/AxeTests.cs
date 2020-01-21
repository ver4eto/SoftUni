using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skeleton.Tests
{
    public class AxeTests
    {
        private Axe axe;
        private Dummy dummy;

        [SetUp]
        public void CreateAxeAndDummy()
        {
            this.axe = new Axe(10, 2);
            this.dummy = new Dummy(20, 20);

        }

        [TearDown]
        public void ClearAxe()
        {
            this.axe = null;
            this.dummy = null;
        }

        [Test]
        public void AxeLoosesDurabilityAfterAttack()
        {
            axe = new Axe(10, 10);

            Dummy dummy = new Dummy(10, 10);

            axe.Attack(dummy);

            Assert.That(axe.DurabilityPoints, Is.EqualTo(9), "Axe Durability doesn`t change after attack.");
        }

        [Test]
        public void BrokenAxeCantAttack()
        {
            this.axe.Attack(this.dummy);
            this.axe.Attack(this.dummy);

            Assert.That(() => axe.Attack(dummy),
                Throws.InvalidOperationException
                .With.Message.EqualTo("Axe is broken."));
        }
    }
}
