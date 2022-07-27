using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void Whether_Dummy_Losses_Health_When_Attacked()
        {           
            Dummy dummy = new Dummy(38, 38);
            dummy.TakeAttack(10);
            Assert.AreEqual(28, dummy.Health);
        }

        [Test]
        public void Whether_Dead_Dummy_throws_an_Exception_If_Attacked()
        {            
            Dummy dummy = new Dummy(38, 38);
            dummy.TakeAttack(40);
            Assert.Throws<InvalidOperationException>(() =>
            {
                dummy.TakeAttack(19);
            });
        }
        [Test]
        public void Whether_Dead_Dummy_Can_Give_XP()
        {
            Dummy dummy = new Dummy(38, 38);
            dummy.TakeAttack(40);
            int xp = dummy.GiveExperience();
            Assert.AreEqual(38, xp);            
        }
        [Test]
        public void Whether_Alive_Dummy_Cannot_Give_XP()
        {
            Dummy dummy = new Dummy(38, 38);
            dummy.TakeAttack(20);           
            Assert.Throws<InvalidOperationException>(() =>
            {
                dummy.GiveExperience();
            });
        }

       
    }
}