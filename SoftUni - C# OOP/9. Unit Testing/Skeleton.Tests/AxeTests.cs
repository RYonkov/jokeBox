using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        //private Axe axe;
        //private Dummy target; 
        //[SetUp]
        //public void SetUp()
        //{
        //    Axe axe = new Axe(19, 1);
        //    Dummy target = new Dummy(100, 100);            
        //}
        [Test]
        public void Whether_Axe_Loose_Durability_After_Attack()
        {
            Axe axe = new Axe(19, 1);
            Dummy target = new Dummy(100, 100);
            axe.Attack(target);
            Assert.AreEqual(0, axe.DurabilityPoints);            
        }

        [Test]
        public void Whether_The_Attack_Is_With_Broken_Axe()
        {
            Axe axe = new Axe(19, 1);
            Dummy target = new Dummy(100, 100);
            axe.Attack(target);
            Assert.Throws<InvalidOperationException>(() =>
            {
                axe.Attack(target);
            });           
        }

        [Test]
        public void Whether_The_Attack_Is_With_Negative_Value()
        {
            Axe axe = new Axe(19, -19);
            Dummy target = new Dummy(100, 100);            
            Assert.Throws<InvalidOperationException>(() =>
            {
                axe.Attack(target);
            });
        }

    }
}