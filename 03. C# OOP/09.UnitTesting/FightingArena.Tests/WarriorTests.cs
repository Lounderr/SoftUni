namespace FightingArena.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class WarriorTests
    {
        [Test]
        public void CtorNormal()
        {
            Warrior warrior = new Warrior("Name", 35, 100);

            Assert.That(warrior.Name, Is.EqualTo("Name"));
            Assert.That(warrior.Damage, Is.EqualTo(35));
            Assert.That(warrior.HP, Is.EqualTo(100));

        }

        [Test]
        public void CtorNameEmptyOrNull()
        {
            Assert.That(() =>
            {
                Warrior warrior = new Warrior("", 35, 100);
            },
            Throws.ArgumentException);

            Assert.That(() =>
            {
                Warrior warrior = new Warrior(null, 35, 100);
            },
            Throws.ArgumentException);
        }

        [Test]
        public void CtorDamageZeroOrNegative()
        {
            Assert.That(() =>
            {
                Warrior warrior = new Warrior("Name", 0, 100);
            },
            Throws.ArgumentException);

            Assert.That(() =>
            {
                Warrior warrior = new Warrior("Name", -1, 100);
            },
            Throws.ArgumentException);
        }

        [Test]
        public void CtorHpNegative()
        {
            Assert.That(() =>
            {
                Warrior warrior = new Warrior("Name", 35, -1);
            },
            Throws.ArgumentException);
        }

        [Test]
        public void AttackWithLessThanMinHp()
        {
            Warrior warrior = new Warrior("Name", 35, 30);
            Warrior enemy = new Warrior("Name2", 40, 110);

            Assert.That(() => warrior.Attack(enemy), Throws.InvalidOperationException);
        }

        [Test]
        public void AttackEnemyWithLessThanMinHp()
        {
            Warrior warrior = new Warrior("Name", 35, 100);
            Warrior enemy = new Warrior("Name2", 40, 30);

            Assert.That(() => warrior.Attack(enemy), Throws.InvalidOperationException);
        }

        [Test]
        public void AttackEnemyWithMoreDmgThanWarriorHp()
        {
            Warrior warrior = new Warrior("Name", 35, 109);
            Warrior enemy = new Warrior("Name2", 110, 140);

            Assert.That(() => warrior.Attack(enemy), Throws.InvalidOperationException);
        }

        [Test]
        public void AttackKillEnemyDmgEqualToHp()
        {
            Warrior warrior = new Warrior("Name", 35, 109);
            Warrior enemy = new Warrior("Name2", 30, 35);

            warrior.Attack(enemy);

            Assert.That(enemy.HP, Is.EqualTo(0));
        }

        [Test]
        public void AttackKillEnemyDmgMoreThanHp()
        {
            Warrior warrior = new Warrior("Name", 36, 109);
            Warrior enemy = new Warrior("Name2", 30, 35);

            warrior.Attack(enemy);

            Assert.That(enemy.HP, Is.EqualTo(0));
        }

    }
}