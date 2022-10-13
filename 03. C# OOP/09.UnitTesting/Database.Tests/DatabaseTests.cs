namespace Database.Tests
{
    using NUnit.Framework;
    using NUnit.Framework.Constraints;
    using System;
    using System.Linq;

    [TestFixture]
    public class DatabaseTests
    {
        [TestCase(new int[] { 2, 4, 6, 8, 10, 12, 14, 16, 9, 10, 11, 12, 13, 14, 15, 16 }, ExpectedResult = 16)]
        [TestCase(new int[] { -2, -4, -6, -8, 10, 12, 14, 16 }, ExpectedResult = 8)]
        [TestCase(new int[] { }, ExpectedResult = 0)]
        public int Init(int[] nums)
        {
            Database db = new Database(nums);
            return db.Count;
        }

        [Test]
        public void Fetch()
        {
            Database db = new Database(2, 4, 6);
            Assert.AreEqual(new int[] { 2, 4, 6 }, db.Fetch());
        }

        [Test]
        public void FetchEmpty()
        {
            Database db = new Database();
            Assert.AreEqual(new int[0], db.Fetch());
        }

        [Test]
        public void FetchFull()
        {
            int[] nums = new int[] { 2, 4, 6, 8, 10, 12, 14, 16, 9, 10, 11, 12, 13, 14, 15, 16 };
            Database db = new Database(nums);
            Assert.AreEqual(nums, db.Fetch());
        }

        [Test]
        public void CountAfterAdd()
        {
            Database db = new Database();

            db.Add(1);

            Assert.AreEqual(1, db.Count);
        }

        [Test]
        public void Add()
        {
            Database db = new Database();

            db.Add(1);

            Assert.AreEqual(new int[] { 1 }, db.Fetch());
        }

        [Test]
        public void AddNumberWhenFull()
        {
            int[] nums = new int[] { 2, 4, 6, 8, 10, 12, 14, 16, 9, 10, 11, 12, 13, 14, 15, 16 };

            Database db = new Database(nums);

            Assert.That(() => { db.Add(1); }, Throws.InvalidOperationException);
        }

        [Test]
        public void CountAfterRemove()
        {
            int[] nums = new int[] { 2, 4, 6, 8, 10, 12, 14, 16, 9, 10, 11, 12, 13, 14, 44, 16 };

            Database db = new Database(nums);

            db.Remove();
            Assert.AreEqual(15, db.Count);
        }

        [Test]
        public void Remove()
        {
            Database db = new Database(1, 2);

            db.Remove();

            Assert.AreEqual(new int[] { 1 }, db.Fetch());
        }

        [Test]
        public void RemoveEmpty()
        {
            Database db = new Database();

            Assert.That(() => { db.Remove(); }, Throws.InvalidOperationException);
        }
    }
}
