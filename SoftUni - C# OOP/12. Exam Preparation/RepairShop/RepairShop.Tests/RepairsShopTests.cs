using NUnit.Framework;
using System;

namespace RepairShop.Tests
{
    public class Tests
    {
        public class RepairsShopTests
        {
            [Test]
            public void WhetherTheContructorIsCorrect()
            {
                //Arrange
                const string GARAGE_NAME = "Yassen";
                const int NUMBER_OF_MECHANICS = 5;
                
                //Act               
                Garage garage = new Garage(GARAGE_NAME, NUMBER_OF_MECHANICS);

                //Assert
                Assert.AreEqual(GARAGE_NAME, garage.Name);
                Assert.That(garage.Name, Is.EqualTo(GARAGE_NAME));


                Assert.AreEqual(NUMBER_OF_MECHANICS, garage.MechanicsAvailable);
                Assert.AreEqual(0, garage.CarsInGarage);                
            }

            [Test]
            public void WhetherExceptionsIsThrownIfGarageNameIsNullOrEmpty()
            {             
                //Assert
                Assert.Throws<ArgumentNullException>(() =>
                {
                    var garage1 = new Garage(null, 10);
                }, "Invalid garage name.");

                Assert.Throws<ArgumentNullException>(() =>
                {
                    var garage1 = new Garage(String.Empty, 10);
                }, "Invalid garage name.");

            }

            [Test]
            public void WhetherExceptionIsThrownInCaseNoAvailableMechanics()
            {
                //Assert
                Assert.Throws<ArgumentException>(() =>
                {
                    var garage = new Garage("Yassen", 0);
                }, "At least one mechanic must work in the garage.");
                
            }

            [Test]
            public void WhetherExceptionIsThrownInCaseOfNoAvailableMechanics()
            {
                
                //Arrange
                Car car = new Car("Skoda", 3);
                Car secondCar = new Car("BMW", 5);
                Garage garage = new Garage("Yassen", 1);

                //Act
                garage.AddCar(car);

                //Assert               
                Assert.Throws<InvalidOperationException>(() =>
                {
                    garage.AddCar(secondCar);
                }, "No mechanic available.");
            }

            [Test]
            public void WhetherAddingACarIncrementCounter()
            {

                //Arrange
                Car car = new Car("Skoda", 3);
                Car secondCar = new Car("BMW", 5);
                Garage garage = new Garage("Yassen", 1);

                //Act
                garage.AddCar(car);

                //Assert
                Assert.AreEqual(1, garage.CarsInGarage);

            }

            [Test]
            public void WhetherExceptionIsThrownInCaseNoSuchACar()
            {

                //Arrange
                Car car = new Car("Skoda", 3);
                Car secondCar = new Car("BMW", 5);
                Garage garage = new Garage("Yassen", 3);
                string model = "Opel";

                //Act
                garage.AddCar(car);
                garage.AddCar(secondCar);

                //Assert       
                Assert.Throws<InvalidOperationException>(() =>
                {
                    garage.FixCar(model);
                }, $"The car {model} doesn't exist.");

            }

            [Test]
            public void WhetherTheCarIsFixed()
            {

                //Arrange
                Car car = new Car("Skoda", 3);
                Car secondCar = new Car("BMW", 5);
                Garage garage = new Garage("Yassen", 3);
                string model = "Skoda";

                //Act
                garage.AddCar(car);
                garage.AddCar(secondCar);
                garage.FixCar(model);

                //Assert

                var fixedCar = garage.FixCar(model);
                Assert.That(fixedCar.IsFixed, Is.True);
                Assert.That(fixedCar.CarModel, Is.EqualTo(model));
                Assert.AreEqual(0, fixedCar.NumberOfIssues);
                
            }

            [Test]
            public void WhetherExceptionsIsThrownInCaseOfNoFixedCar()
            {

                //Arrange
                Car car = new Car("Skoda", 3);
                Car secondCar = new Car("BMW", 5);
                Garage garage = new Garage("Yassen", 3);
                string model = "Skoda";

                //Act
                garage.AddCar(car);
                garage.AddCar(secondCar);                            

                //Assert
                Assert.Throws<InvalidOperationException>(() =>
                {
                    garage.RemoveFixedCar();
                }, $"No fixed cars available.");                

            }

            [Test]
            public void WhetherFixedCarIsRemoved()
            {

                //Arrange
                Car car = new Car("Skoda", 3);
                Car secondCar = new Car("BMW", 5);
                Car thirdCar = new Car("Dacia", 10);
                Garage garage = new Garage("Yassen", 3);
                string model = "Skoda";

                //Act
                garage.AddCar(car);
                garage.AddCar(secondCar);
                garage.AddCar(thirdCar);
                garage.FixCar(model);
                var fixedCars = garage.RemoveFixedCar();

                //Assert
                Assert.That(garage.CarsInGarage, Is.EqualTo(2));
                Assert.That(fixedCars, Is.EqualTo(1));
            }

            [Test]
            public void WhetherReportsProvideCorrectResults()
            {

                //Arrange
                Car car = new Car("Skoda", 3);
                Car secondCar = new Car("BMW", 5);
                Car thirdCar = new Car("Dacia", 10);
                Car car4 = new Car("Ford", 15);
                Garage garage = new Garage("Yassen", 5);
                string model = "Skoda";

                //Act
                garage.AddCar(car);
                garage.AddCar(secondCar);
                garage.AddCar(thirdCar);
                garage.AddCar(car4);
                garage.FixCar(model);
                var report = garage.Report();

                //Assert
                Assert.That(report, Is.EqualTo($"There are 3 which are not fixed: BMW, Dacia, Ford."));
               
            }

        }

    }
    
}