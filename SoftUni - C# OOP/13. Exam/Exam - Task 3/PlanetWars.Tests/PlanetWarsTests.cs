using NUnit.Framework;
using System;
using System.Linq;

namespace PlanetWars.Tests
{
    public class Tests
    {
        [TestFixture]
        public class PlanetWarsTests
        {

            [Test]
            [TestCase("Rado", 100.2, 19)]
            [TestCase("Tsveta", 3.2, 100)]

            public void WhetherWeaponConstructorIsWorkingProperly(string name, double price, int destruction)
            {
                var weapon = new Weapon(name, price, destruction);
                Assert.IsNotNull(weapon);
                Assert.AreEqual(name, weapon.Name);
                Assert.AreEqual(price, weapon.Price);
                Assert.AreEqual(destruction, weapon.DestructionLevel);
                weapon.Name = "Ivan";
                weapon.DestructionLevel = 5;
                weapon.Price = 26.5;
                Assert.IsNotNull(weapon);
                Assert.AreEqual("Ivan", weapon.Name);
                Assert.AreEqual(26.5, weapon.Price);
                Assert.AreEqual(5, weapon.DestructionLevel);
            }

            [Test]
            [TestCase("Rado", -100.2, 19)]
            [TestCase("Tsveta", -3.2, 100)]

            public void WhetherExceptionIsThrownInCaseOfNegativePrice(string name, double price, int destruction)
            {
                Assert.Throws<ArgumentException>(() => { new Weapon(name, price, destruction); }, "Price cannot be negative.");                 
            }

            [Test]
            [TestCase("Rado", 100.2, 19)]
            [TestCase("Tsveta", 3.2, 100)]

            public void WhetherDestructionLevelIsIncreased(string name, double price, int destruction)
            {
                var weapon = new Weapon(name, price, destruction);
                weapon.IncreaseDestructionLevel();
                Assert.AreEqual(destruction+1, weapon.DestructionLevel);               
            }


            [Test]
            [TestCase("Rado", 100.2, 1)]
            [TestCase("Rado", 100.2, 9)]         

            public void WhetherDestructionLevelIsNotNuclear(string name, double price, int destruction)
            {
                var weapon = new Weapon(name, price, destruction);
                Assert.IsFalse(weapon.IsNuclear);               
            }

            [Test]
       
            [TestCase("Tsveta", 3.2, 100)]
            [TestCase("Tsveta", 3.2, 10)]

            public void WhetherDestructionLevelIsNuclear(string name, double price, int destruction)
            {
                var weapon = new Weapon(name, price, destruction);
                Assert.IsTrue(weapon.IsNuclear);
            }

            [Test]
            [TestCase("Rado", 100.2)]
            [TestCase("Tsveta", 3.2)]

            public void WhetherPlanetConstructorIsWorkingProperly(string name, double budget)
            {
                var planet = new Planet(name, budget);
                var weapon = new Weapon("Tsveta", 50, 150);
                Assert.IsNotNull(planet);
                Assert.AreEqual(name, planet.Name);
                Assert.AreEqual(budget, planet.Budget);
                Assert.IsNotNull(planet.Weapons);
                int numberOfWeapons = planet.Weapons.Count;
                Assert.That(0, Is.EqualTo(planet.Weapons.Count));
                planet.AddWeapon(weapon);
                Assert.That(1, Is.EqualTo(planet.Weapons.Count));
            }

            [Test]
            [TestCase("", 100.2)]
            [TestCase(null, 3.2)]
           
            public void WhetherExpectionIsThrownInCaseOfNullOrEmptpyPlanetName(string name, double budget)
            {
                Assert.Throws<ArgumentException>(() => {new Planet(name, budget); }, "Invalid planet Name");                
            }

            [Test]
            [TestCase("Rado", -5)]
            [TestCase("Rado", -1)]

            public void WhetherExpectionIsThrownInCaseOfNegativeBudget(string name, double budget)
            {
                Assert.Throws<ArgumentException>(() => { new Planet(name, budget); }, "Budget cannot drop below Zero!");                
            }

            [Test]
            [TestCase("Rado", 100)]
            [TestCase("Tsveta", 50)]
            [TestCase("Ivan", 20)]

            public void WhetherSpendingOfBudgetWorksProperly(string name, double budget)
            {
                Planet planet = new Planet(name, budget);
                planet.SpendFunds(20);
                Assert.AreEqual(budget-20, planet.Budget);
            }

            [Test]
            [TestCase("Rado", 100)]
            [TestCase("Tsveta", 50)]

            public void WhetherExceptionsIsThrownInCaseOfInsufficientBudget(string name, double budget)
            {
                Planet planet = new Planet(name, budget);

                Assert.Throws<InvalidOperationException>(() => { planet.SpendFunds(120); }, $"Not enough funds to finalize the deal.");
            }

            [Test]
            [TestCase("Rado", 100)]
            [TestCase("Tsveta", 50)]

            public void WhetherWeaponIsProperlyAdded(string name, double budget)
            {
                Planet planet = new Planet(name, budget);
                Weapon weapon = new Weapon("NUKE", 100, 100);
                Weapon weapon2 = new Weapon("NUKE1", 150, 150);
                planet.AddWeapon(weapon);
                Assert.That(1, Is.EqualTo(planet.Weapons.Count));
                planet.AddWeapon(weapon2);
                Assert.That(2, Is.EqualTo(planet.Weapons.Count));

            }


            [Test]
            [TestCase("Rado", 100)]
            [TestCase("Tsveta", 50)]

            public void WhetherExceptionIsThrownInCaseOfExistingWeapon(string name, double budget)
            {
                Planet planet = new Planet(name, budget);
                Weapon weapon = new Weapon("NUKE", 100, 100);                
                planet.AddWeapon(weapon);
                Assert.Throws<InvalidOperationException>(() => { planet.AddWeapon(weapon); }, $"There is already a {weapon.Name} weapon.");
            }

            [Test]
            [TestCase("Rado", 100)]
            [TestCase("Tsveta", 50)]

            public void WhetherRemoveWeaponIsWorkingProperly(string name, double budget)
            {
                Planet planet = new Planet(name, budget);
                Weapon weapon = new Weapon("NUKE", 100, 100);
                planet.AddWeapon(weapon);
                Assert.That(1, Is.EqualTo(planet.Weapons.Count));
                planet.RemoveWeapon(weapon.Name);
                Assert.That(0, Is.EqualTo(planet.Weapons.Count));                
            }

            [Test]
            [TestCase("Rado", 100)]
            [TestCase("Tsveta", 50)]

            public void WhetherExceptionIsThrownInCaseOfNonExistingWeaponUpgrade(string name, double budget)
            {
                Planet planet = new Planet(name, budget);
                Weapon weapon = new Weapon("NUKE", 100, 100);
                
                Assert.Throws<InvalidOperationException>(() => { planet.UpgradeWeapon(weapon.Name); }, $"{weapon.Name} does not exist in the weapon repository of {planet.Name}");
            }


            [Test]
            [TestCase("Rado", 100)]
            [TestCase("Tsveta", 50)]

            public void WhetherPlanetWeaponIsProperlyUpgraded(string name, double budget)
            {
                Planet planet = new Planet(name, budget);
                Weapon weapon = new Weapon("NUKE", 100, 100);
                planet.AddWeapon(weapon);
                planet.UpgradeWeapon(weapon.Name);
                Weapon upgradedWeapon = planet.Weapons.FirstOrDefault(w => w.Name == "NUKE");
                Assert.That(101, Is.EqualTo(upgradedWeapon.DestructionLevel));
            }

            [Test]
            [TestCase("Rado", 100)]
            [TestCase("Tsveta", 50)]
            public void WhetherExceptionIsThrownInCaseOfTooStrongOpponent(string name, double budget)
            {
                Planet planet = new Planet(name, budget);
                Weapon weapon = new Weapon("NUKE", 100, 100);
                Weapon weapon2 = new Weapon("NUKE2", 150, 150);
                planet.AddWeapon(weapon);
              
                Planet opponent = new Planet("ZZ", 1000);
                opponent.AddWeapon(weapon);
                opponent.AddWeapon(weapon2);
                
                Assert.Throws<InvalidOperationException>(() => { planet.DestructOpponent(opponent); }, $"{opponent.Name} is too strong to declare war to!");
            }

            [Test]
            [TestCase("Rado", 100)]
            [TestCase("Tsveta", 50)]
            public void WhetherOpponentIsProperlyDestroyed(string name, double budget)
            {
                Planet planet = new Planet(name, budget);
                Weapon weapon = new Weapon("NUKE", 100, 100);
                Weapon weapon2 = new Weapon("NUKE2", 150, 150);
                planet.AddWeapon(weapon);
                planet.AddWeapon(weapon2);
                Assert.AreEqual(250, planet.MilitaryPowerRatio);

                Planet opponent = new Planet("ZZ", 1000);
                opponent.AddWeapon(weapon);

                Assert.AreEqual($"{opponent.Name} is destructed!", planet.DestructOpponent(opponent));
            }


            [Test]
            [TestCase("Rado", 100)]
            [TestCase("Tsveta", 50)]
            [TestCase("Ivan", 20)]

            public void WhetherProfitWorksProperly(string name, double budget)
            {
                Planet planet = new Planet(name, budget);
                planet.Profit(20);
                Assert.AreEqual(budget + 20, planet.Budget);
            }

        }
    }
}
