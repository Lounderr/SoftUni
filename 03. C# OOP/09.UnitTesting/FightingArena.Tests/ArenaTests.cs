namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System.Linq;

    [TestFixture]
    public class ArenaTests
    {
        [Test]
        public void EnrollNormal()
        {
            Warrior warrior = new Warrior("Name", 35, 100);

            var arena = new Arena();
            arena.Enroll(warrior);
            Assert.AreEqual(arena.Warriors.First(), warrior);
        }

        [Test]
        public void CountTest()
        {
            Warrior warrior = new Warrior("Name", 35, 100);
            var arena = new Arena();

            arena.Enroll(warrior);

            Assert.That(arena.Count == 1);
        }

        [Test]
        public void EnrollAlreadyEnrolled()
        {
            Warrior warrior = new Warrior("Name", 35, 100);

            var arena = new Arena();
            arena.Enroll(warrior);

            Assert.That(() => arena.Enroll(warrior), Throws.InvalidOperationException);
        }

        [Test]
        public void FightNullWarrior()
        {
            Warrior warrior = new Warrior("Name", 35, 100);
            var arena = new Arena();

            arena.Enroll(warrior);

            Assert.That(() => arena.Fight("Name", "Missing"), Throws.InvalidOperationException);
        }

    }
}
