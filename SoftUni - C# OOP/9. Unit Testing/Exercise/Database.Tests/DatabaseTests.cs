namespace Database.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DatabaseTests
    {
        [Test]
        public void Whether_New_Element_Is_Added_Propertly()
        {
            Database db = new Database();
            int n = db.Count;
            if (n != 16)
            {
                db.Add(1);
            }
            Assert.AreEqual(n + 1, db.Count);
        }
        [Test]
        public void Whether_Exception_Is_Thrown_When_New_Element_Is_Added_To_Position_17()
        {
            Database db = new Database();
            for (int i = 0; i < 16; i++)
            {
                db.Add(i);
            }
            int n = db.Count;
            if (n == 16)
            {
                Assert.Throws<InvalidOperationException>(() => db.Add(1));
            }
        }
        [Test]
        public void Whether_Last_Element_Is_Removed()
        {
            Database db = new Database();
            for (int i = 0; i < 3; i++)
            {
                db.Add(i);
            }
            int n = db.Count;
            db.Remove();
            Assert.AreEqual(n - 1, db.Count);

        }
        [Test]
        public void Whether_Last_Element_Is_Tried_To_Removed_From_Empty_DB()
        {
            Database db = new Database();
            int n = db.Count;
            for (int i = 0; i < n; i++)
            {
                db.Remove();
            }
            if (n == 0)
            {
                Assert.Throws<InvalidOperationException>(() => db.Remove());
            }
        }
        [Test]
        public void Whether_The_Constructor_Takes_Only_Integers()
        {
            int[] initialArray = new int[] { 1, 3, 6 };
            Database db = new Database(initialArray);
        }
        [Test]
        public void Whether_The_Fetch_Command_Works()
        {
            int[] initialArray = new int[] { 1, 3, 6 };
            Database db = new Database(initialArray);
            int[] copyArray = db.Fetch();
            //Assert.AreEqual(initialArray, copyArray);
            CollectionAssert.AreEqual(initialArray, copyArray);
        }

        [TestCase(new int[] { })]
        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 3, 6 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void Whether_The_Constructior_Adds_16_Elements(int[] data)
        {
            Database db = new Database(data);
            int[] actualData = db.Fetch();
            int[] expectedData = data;
            int actualCount = db.Count;
            int expectedCount = data.Length;

            CollectionAssert.AreEqual(actualData, expectedData, "Database constructor should initialize data fields correctly");
            Assert.AreEqual(expectedCount, actualCount, "Constructor should set initial value for count field");

        }


        //[TestCase(new double[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 })]        
        //public void Whether_The_Constructior_Cannot_Receive_Parameters_In_Double(double[] data)
        //{

        //    Assert.Throws<Exception>(() =>
        //    {
        //        Database db = new Database(data);
        //    });

        //}
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 })]
        public void Whether_The_Constructior_Throws_Exception_When_More_Than_16_Elements_Are_Provided(int[] data)
        {

            Assert.Throws<InvalidOperationException>(() =>
            {
                Database db = new Database(data);
            });
        }
    }
}
