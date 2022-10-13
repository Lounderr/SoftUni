namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        [Test]
        public void CreatePerson()
        {
            Person p = new Person(33, "Mark");
            Assert.Multiple(() =>
            {
                Assert.AreEqual(33, p.Id);
                Assert.True(p.UserName == "Mark");
            });
        }

        [Test]
        public void CreatePersonWithNegativeId()
        {
            Assert.That(() =>
            {
                Person p = new Person(-33, "Mark");
            }, Throws.InvalidOperationException);
        }

        [Test]
        public void Init()
        {
            var person = new Person(0, "Mark");
            Database db = new Database(person);
            Assert.AreEqual(1, db.Count);
        }

        [Test]
        public void InitMoreThanMax()
        {
            Person[] people = new Person[17];

            for (int i = 0; i < 17; i++)
            {
                people[i] = new Person(i, $"Mark{i}");
            }

            Assert.That(() =>
            {
                Database db = new Database(people);
            }, Throws.ArgumentException);
        }

        [Test]
        public void CountWhenAdding()
        {
            Database db = new Database();
            db.Add(new Person(0, "Mark"));
            Assert.AreEqual(1, db.Count);
        }

        [Test]
        public void Add()
        {
            Person person = new Person(0, "Mark");
            Database db = new Database();
            db.Add(person);
            Assert.AreEqual(person, db.FindById(0));
        }

        [Test]
        public void AddSameId()
        {
            Database db = new Database();
            db.Add(new Person(0, "Mark"));

            Assert.That(() => { db.Add(new Person(0, "Jeff")); }, Throws.InvalidOperationException);
        }

        [Test]
        public void AddSameUsername()
        {
            Database db = new Database();
            db.Add(new Person(0, "Mark"));

            Assert.That(() => { db.Add(new Person(1, "Mark")); }, Throws.InvalidOperationException);
        }

        [Test]
        public void AddMoreThanMax()
        {
            Database db = new Database();
            for (int i = 0; i < 16; i++)
            {
                db.Add(new Person(i, $"Mark{i}"));
            }

            Assert.That(() => { db.Add(new Person(15, "Tony")); }, Throws.InvalidOperationException);
        }

        [Test]
        public void CountWhenRemoving()
        {
            Database db = new Database(new Person(1, "Mark"), new Person(2, "Tony"));
            db.Remove();
            Assert.AreEqual(1, db.Count);
        }

        [Test]
        public void Remove()
        {
            Person person = new Person(1, "Mark");
            Database db = new Database(person, new Person(2, "Tony"));
            db.Remove();
            Assert.AreEqual(person, db.FindById(1));
        }

        [Test]
        public void RemoveNonExistant()
        {
            Database db = new Database();

            Assert.That(() => { db.Remove(); }, Throws.InvalidOperationException);
        }

        [Test]
        public void FindByUsername()
        {
            Person person = new Person(0, "Mark");
            Database db = new Database(person);
            Assert.AreEqual(person, db.FindByUsername("Mark"));
        }

        [Test]
        public void FindByNonExistantUsername()
        {
            Database db = new Database();

            Assert.That(() =>
            {
                db.FindByUsername("Mark");
            }, Throws.InvalidOperationException);
        }

        [Test]
        public void FindByNullUsername()
        {
            Database db = new Database();

            Assert.That(() =>
            {
                db.FindByUsername(null);
            }, Throws.ArgumentNullException);
        }

        [Test]
        public void FindById()
        {
            Person person = new Person(0, "Mark");
            Database db = new Database(person);
            Assert.AreEqual(person, db.FindById(0));
        }

        [Test]
        public void FindByNegativeId()
        {
            Database db = new Database();

            Assert.That(() =>
            {
                db.FindById(-5);
            }, Throws.ArgumentException);
        }

        [Test]
        public void FindByNonExistantId()
        {
            Database db = new Database();

            Assert.That(() =>
            {
                db.FindById(99);
            }, Throws.InvalidOperationException);
        }
    }
}