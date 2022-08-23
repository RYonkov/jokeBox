using FrontDeskApp;
using NUnit.Framework;
using System;

namespace BookigApp.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(3,5.5)]
        [TestCase(12, 3235.5)]
        public void TestRoomWorkingProperly(int capacity, double price)
        {
            var room = new Room(capacity, price);
            Assert.IsNotNull(room);
            Assert.AreEqual(capacity, room.BedCapacity);
            Assert.AreEqual(price, room.PricePerNight);
        }

        [Test]
        [TestCase(-3, 5.5)]
        [TestCase(-112, -3)]
        public void TestNegativeBedCapacity(int capacity, double price)
        {
            Assert.Throws<ArgumentException>(() => new Room(capacity, price));
        }

        [Test]
        [TestCase(3, -5.5)]
        [TestCase(112, -3)]
        public void TestNegativePrice(int capacity, double price)
        {
            Assert.Throws<ArgumentException>(() => new Room(capacity, price));
        }


        [Test]
        [TestCase("Bor", 5)]
        [TestCase("Marinella", 3)]
        public void TestHotelConstructor(string name, int category)
        {
            var hotel = new Hotel(name, category);
            Assert.IsNotNull(hotel);
            Assert.AreEqual(name, hotel.FullName);
            Assert.AreEqual(category, hotel.Category);
            Assert.IsEmpty(hotel.Rooms);
            Assert.IsEmpty(hotel.Bookings);
            Assert.AreEqual(0, hotel.Turnover);
        }


        [Test]
        [TestCase("", 5)]
        [TestCase(null, 3)]
        [TestCase("        ", 3)]
        public void TestHotelNameThrowsException(string name, int category)
        {
            Assert.Throws<ArgumentNullException>(()=>new Hotel(name, category));
        }

        [Test]
        [TestCase("Bor", 7)]
        [TestCase("Bor", 0)]
        [TestCase("Ela", -9)]
        public void TestHotelCategoryThrowsException(string name, int category)
        {
            Assert.Throws<ArgumentException>(() => new Hotel(name, category));
        }


        [Test]
        [TestCase("Bor", 3)]
        [TestCase("Bor", 4)]
        [TestCase("Ela", 5)]
        public void TestHotelAddsRoom(string name, int category)
        {
            var room = new Room(2, 20);
            var hotel = new Hotel(name, category);
            hotel.AddRoom(room);
            Assert.AreEqual(1, hotel.Rooms.Count);
            Assert.IsNotEmpty(hotel.Rooms);
        }

        [Test]
        [TestCase("Bor", 3)]
        [TestCase("Bor", 4)]
        [TestCase("Ela", 5)]
        public void TestBooking(string name, int category)
        {
            var room = new Room(2, 20);
            var hotel = new Hotel(name, category);
            hotel.AddRoom(room);

            var booking = new Booking(19, room, 5);
            Assert.AreEqual(19, booking.BookingNumber);
            Assert.AreEqual(room, booking.Room);
            Assert.AreEqual(5, booking.ResidenceDuration);
            
        }


        [Test]
        [TestCase(0, 1, 5, 1200.50)]
        [TestCase(-1, 0, 7, 2800.50)]
        [TestCase(-5, 1, 1, 1200.50)]
        public void TestBookRoomExceptionAdults(int adults, int children, int duration, double budget)
        {
            var room = new Room(2, 20);
            var hotel = new Hotel("Ela", 4);
            Assert.Throws<ArgumentException>(()=>hotel.BookRoom(adults, children, duration, budget));   
        }

        [Test]
        [TestCase(50, -1, 5, 1200.50)]
        [TestCase(3, -50, 7, 2800.50)]
        [TestCase(5, -1, 1, 1200.50)]
        public void TestBookRoomChildrenException(int adults, int children, int duration, double budget)
        {
            var room = new Room(2, 20);
            var hotel = new Hotel("Ela", 4);
            Assert.Throws<ArgumentException>(() => hotel.BookRoom(adults, children, duration, budget));
        }

        [Test]
        [TestCase(50, 1, -5, 1200.50)]
        [TestCase(3, 50, -1, 2800.50)]
        [TestCase(5, 1, 0, 1200.50)]
        public void TestBookRoomResidenceDurationException(int adults, int children, int duration, double budget)
        {
            var room = new Room(2, 20);
            var hotel = new Hotel("Ela", 4);
            Assert.Throws<ArgumentException>(() => hotel.BookRoom(adults, children, duration, budget));
        }

        [Test]
        [TestCase(3, 1, 1, 1200.50)]

        public void TestNecessaryBedCapacity(int adults, int children, int duration, double budget)
        {
            var room = new Room(2, 20);

            var hotel = new Hotel("Ela", 4);
            int bedCapacity = adults + children;
            hotel.AddRoom(room);
            hotel.BookRoom(adults, children, duration, budget);
            Assert.IsEmpty(hotel.Bookings);
            Assert.AreEqual(0, hotel.Bookings.Count);
        }   


        [Test]
        [TestCase(3, 1, 1, 1200.50)]

        public void TestRoomBooking(int adults, int children, int duration, double budget)
        {
            var room = new Room(7, 20);
            var hotel = new Hotel("Ela", 4);
            hotel.AddRoom(room);
            int bedCapacity = adults + children;
            hotel.BookRoom(adults, children, duration, budget);

            Assert.IsNotEmpty(hotel.Bookings);
            Assert.AreEqual(1, hotel.Bookings.Count);
            Assert.AreEqual(20, hotel.Turnover);

        }

        [Test]
        [TestCase(3, 1, 1, 12)]

        public void TestRoomBookingInsufficientBudget(int adults, int children, int duration, double budget)
        {
            var room = new Room(7, 20);
            var hotel = new Hotel("Ela", 4);
            hotel.AddRoom(room);           
            hotel.BookRoom(adults, children, duration, budget);

            Assert.IsEmpty(hotel.Bookings);
            Assert.AreEqual(0, hotel.Bookings.Count);
            Assert.AreEqual(0, hotel.Turnover);
        }
    }
}
