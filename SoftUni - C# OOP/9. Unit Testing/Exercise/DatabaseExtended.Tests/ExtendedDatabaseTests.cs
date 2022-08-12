namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Text;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Database twoPeopleInDatabase;
        private Database fullDatabase;
        private double i;

        [SetUp]
        public void Init()
        {
            Person[] twoPeopleList = new Person[2];

            for (int i = 0; i < 2; i++)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Iva");
                sb.Append(i.ToString());

                twoPeopleList[i] = new Person(1234 + i, sb.ToString());
            }

            twoPeopleInDatabase = new Database(twoPeopleList);

            Person[] sixteenPeopleList = new Person[16];

            for (int i = 0; i < 16; i++)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Iva");
                sb.Append(i.ToString());

                sixteenPeopleList[i] = new Person(1234 + i, sb.ToString());
            }

            fullDatabase = new Database(sixteenPeopleList);
        }

        [Test]
        [TestCase("Rado", 19)]
        [TestCase("Ivan", 6)]
        [TestCase("", 19)]
        [TestCase("Rado", null)]
        public void WhetherPersonConstructorWorkProperly(string username, long id)
        {
            Person person = new Person(id, username);
            Assert.IsNotNull(person);
            Assert.AreEqual(id, person.Id);
            Assert.AreEqual(username, person.UserName);
        }

        [Test]
        [TestCase("Rado", 19)]       
        public void WhetherOnlyUniqueUsernamesAreAdded(string username, long id)
        {
            //Arrange
            long[] idNumbers = new long[16] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            List<Person> people = new List<Person>();
            Database db = new Database();
            
            //Act & Assert
            for (int i = 0; i < 16; i++)
            {
                Person currentPerson = new Person(idNumbers[i], idNumbers[i].ToString());
                db.Add(currentPerson);
                Assert.AreEqual(i + 1, db.Count);
            }

            //Assert
            Assert.Throws<InvalidOperationException>(() => { db.Add(new Person(19, "Rado"));}, "Array's capacity must be exactly 16 integers!");
            db.Remove();            
            Assert.Throws<InvalidOperationException>(() => { db.Add(new Person(67, "2")); }, "There is already user with this username!");
            Assert.Throws<InvalidOperationException>(() => { db.Add(new Person(8, "Tsv")); }, "There is already user with this Id!");
        }

        [Test]
        public void WhetherOnlyUniqueUsernamesAreAdded()
        {
            //Arrange
            long[] idNumbers = new long[16] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            List<Person> people = new List<Person>();
            Database db = new Database();

            //Act & Assert
            for (int i = 0; i < 16; i++)
            {
                Person currentPerson = new Person(idNumbers[i], idNumbers[i].ToString());
                db.Add(currentPerson);                              
            }
            for (int i = 15; i >= 0; i--);
            {
                db.Remove();
                Assert.AreEqual(i, people.Count);
            }

        }

        [Test]
        [TestCase("Rado", 19)]        
        public void WhetherNewElementIsAddedPropertly(string username, long id)
        {
            Person person = new Person(id, username);
            
            Database db = new Database();
            int n = db.Count;
            if (n != 16)
            {
                db.Add(person);
            }
            Assert.AreEqual(n + 1, db.Count);
        }

        [Test]

        public void RemoveMethodShouldThrowExceptionIfDatabaseIsEmpty()
        {
            Database database = new Database();

            Assert.That(() => database.Remove(), Throws.InvalidOperationException);
        }

        [Test]

        public void RemoveMethodShouldRemoveElementsFromDatabase()
        {
            fullDatabase.Remove();
            fullDatabase.Remove();

            Assert.That(fullDatabase.Count, Is.EqualTo(14));
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void FindByUsernameMethodShouldThrowExceptionIfInvalidUsername(string name)
        {
            Assert.That(() => fullDatabase.FindByUsername(name),
                Throws.ArgumentNullException);
        }
        [Test]
        public void FindByUsernameMethodShouldThrowExceptionIfLowercaseName()
        {
            Assert.That(() => fullDatabase.FindByUsername("iva0"),
                Throws.InvalidOperationException);
        }

        [Test]
        public void FindByUsernameMethodShouldThrowExceptionIfUsernameDoesNotExist()
        {
            Assert.That(() => fullDatabase.FindByUsername("Marina"), Throws.InvalidOperationException.With.Message.EqualTo("No user is present by this username!"));
        }

        [Test]
        public void FindByUsernameShouldReturnPersonWithThatUsername()
        {
            Person result = fullDatabase.FindByUsername("Iva0");
            Person expected = new Person(1234, "Iva0");

            Assert.AreEqual((result.UserName, result.Id), (expected.UserName, expected.Id));
        }

        [Test]
        public void FindByIdMethodShouldThrowExceptionIfNoUserWithThatIdInDatabase()
        {
            Assert.That(() => fullDatabase.FindById(1), Throws.InvalidOperationException.With.Message.EqualTo("No user is present by this ID!"));
        }

        [Test]
        public void FindByIdMethodShouldThrowExceptionIfNegativeIdIsProvided()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => fullDatabase.FindById(-1));
        }
        [Test]
        public void FindByIdShouldReturnPersonWithThatId()
        {
            Person result = fullDatabase.FindById(1235);
            Person expected = new Person(1235, "Iva1");
            Assert.AreEqual((result.Id, result.UserName),
                (expected.Id, expected.UserName));
        }
    }
}

