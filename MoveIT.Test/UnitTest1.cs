using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoveIT.Controllers;
using MoveIT.Models;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace MoveIT.Test
{
    [TestFixture]
    public class UnitTest1
    {
        [TestCase(10, 1100)]
        [TestCase(49, 1490)]
        [TestCase(50, 5400)]
        [TestCase(51, 5408)]
        [TestCase(99, 5792)]
        [TestCase(100, 10700)]
        public void GivenDistanceCalculateCost(int distance, int expectedCost)
        {
            var controller = new HomeController();
            var res = controller.GetPriceBasedOnDistance(distance);
            Assert.AreEqual(expectedCost,res);
        }

        [TestCase(1100, 49, 0, 1100)]
        [TestCase(1100, 10, 25, 2200)]
        [TestCase(1100, 50, 0, 2200)]
        [TestCase(1100, 100, 0, 3300)]
        [TestCase(1100, 150, 0, 4400)]
        public void GivenAreaCalculateCost(int distancePrice, int mainArea, int extraArea, int expectedCost)
        {
            var controller = new HomeController();
            var res = controller.GetPriceBasedOnArea(mainArea, extraArea, distancePrice);
            Assert.AreEqual(expectedCost, res);
        }


        [TestCase(35, 30, true, 6350)]
        [TestCase(280, 135, false, 35880)]
        [TestCase(100, 250, true, 69200)]
        [TestCase(75, 95, false, 11200)]
        public void CalculaterCompleteExample(int distance, int area, bool piano, int expectedPrice)
        {
            var controller = new HomeController();
            var m = new PriceInfoViewModel {Distance = distance, MainArea = area, Piano = piano};
            var model = controller.GetOffer(m);
            Assert.AreEqual(expectedPrice, model.EstimatedPrice);
        }
    }
}
