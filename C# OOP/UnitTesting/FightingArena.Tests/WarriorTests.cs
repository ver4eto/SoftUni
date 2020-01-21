using FightingArena;
using NUnit.Framework;
using System;

namespace Tests
{
    public class WarriorTests
    {
        private Warrior warrior;
        private readonly Warrior myWarrior = new Warrior("Name", 10, 50);

        [SetUp]
        public void Setup()
        {
            this.warrior = new Warrior("Name", 10, 50);
        }

        //[TearDown]
        //public void Clear()
        //{
        //    this.warrior = null;
        //}

        [Test]
        public void TestCtor()
        {
            Assert.AreEqual(this.warrior.Name, "Name");
            Assert.AreEqual(this.warrior.Damage, 10);
            Assert.AreEqual(this.warrior.HP, 50);
        }

        [Test]
        public void WarriorIsWithEmptyName()
        {
            Assert.Throws<ArgumentException>(()=> new Warrior(null, 10,10), "Name should not be empty or whitespace!");
        }
        [Test]
        public void WarriorIsWithNegativeDamage()
        {
            Assert.Throws<ArgumentException>(()=>new Warrior("Pesho", -2, 5), "Damage value should be positive!");
        }

        [Test]
        public void WarriorISWithNegativeHP()
        {
            Assert.Throws<ArgumentException>(()=> new Warrior("Pesho", 2, -2), "HP should not be negative!");
        }

        [Test]
        public void WarriorAttackWithLessThan30HP()
        {
            Assert.Throws<InvalidOperationException>(()=>new Warrior("Ivan", 20, 20).Attack(this.warrior),
                "Your HP is too low in order to attack other warriors!");
        }

        [Test]
        public void EnemyHPIsLowerThan30()
        {
            Assert.Throws<InvalidOperationException>(()=>myWarrior.Attack(new Warrior("Ivan", 10, 20)),
                string.Format($"Enemy HP must be greater than {0} in order to attack him!",20));
        }

        [Test]
        public void AttackerHPIsLowerThatEnemyDamage()
        {
            Assert.Throws<InvalidOperationException>(()=>myWarrior.Attack(new Warrior("Ivan",70,70)),
                "You are trying to attack too strong enemy");
        }

        [Test]
        public void TestAttack()
        {
            this.warrior.Attack(new Warrior("Ivan", 20, 40));
            Assert.AreEqual(30,this.warrior.HP);
        }

        [Test]
        public void AttackWithAttackerDamageGreaterThanEnemyHP()
        {

            Warrior current = new Warrior("Ivo", 5, 35);
            Warrior attacker = new Warrior("Sasho", 70, 50);
           attacker.Attack(current);
            Assert.AreEqual(0,current.HP);

        }

    }
}