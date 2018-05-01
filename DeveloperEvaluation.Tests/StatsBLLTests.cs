using StatsApi.BLL;
using StatsApi.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeveloperEvaluation.Tests
{
    [TestClass]
    public class StatsBLLTests
    {
        private IStatsCalc _statsCalc;

        [TestInitialize]
        public void Setup()
        {
            _statsCalc = new StatsCalc();
        }

        [TestCleanup]
        public void CleanUp()
        {
            _statsCalc = null;
        }

        [TestMethod]
        public void Mean1()
        {

            List<decimal> nums = new List<decimal>
            {
                1M,
                4.556M,
                -4.56M
            };

            decimal res = _statsCalc.Mean(nums);

            Assert.AreEqual(res, 0.332M);

        }

        //all values appear once
        [TestMethod]
        public void Mode1()
        {
            List<decimal> nums = new List<decimal>
            {
                1M,
                4.556M,
                -4.56M
            };

            List<decimal> resultMock = new List<decimal>();
            List<decimal> res = _statsCalc.Mode(nums);

            CollectionAssert.AreEqual(res, resultMock);
        }

        //just one mode
        [TestMethod]
        public void Mode2()
        {
            List<decimal> nums = new List<decimal>
            {
                3M,
                4M,
                5M,
                1M,
                4M
            };

            List<decimal> resMock = new List<decimal>
            {
                4M
            };

            List<decimal> res = _statsCalc.Mode(nums);
            CollectionAssert.AreEqual(res, resMock);
        }

        //more than one mode
        [TestMethod]
        public void Mode3()
        {
            List<decimal> nums = new List<decimal>
            {
                3M,
                4M,
                5M,
                1M,
                4M,
                6M,
                5M
            };

            List<decimal> resultMock = new List<decimal>
            {
                4M,
                5M
            };

            List<decimal> res = _statsCalc.Mode(nums);
            CollectionAssert.AreEqual(res,resultMock);
        }

        //more than one mode and different numbers of frequncy over 1
        [TestMethod]
        public void Mode4()
        {
            List<decimal> nums = new List<decimal>
            {
                3M,
                4M,
                5M,
                1M,
                4M,
                6M,
                5M,
                1M,
                1M
            };
            List<decimal> resultMock = new List<decimal>
            {
                1M
            };

            List<decimal> res = _statsCalc.Mode(nums);
            CollectionAssert.AreEqual(res,resultMock);
        }

        [TestMethod]
        public void Median1()
        {
            List<decimal> nums = new List<decimal>
            {
                1M,
                4.556M,
                -4.56M
            };

            decimal res = _statsCalc.Median(nums);

            Assert.AreEqual(res, 1M);
        }

        [TestMethod]
        public void Median2()
        {
            List<decimal> nums = new List<decimal>
            {
                3.4445M,
                5M,
                6M,
                8M
            };

            decimal res = _statsCalc.Median(nums);

            Assert.AreEqual(res, 5.5M);
        }

        [TestMethod]
        public void CalcAsync1()
        {
            List<decimal> nums = new List<decimal>
            {
                1M,
                4.556M,
                -4.56M
            };

            Stats res = _statsCalc.CalcAsync(nums);

            Assert.AreEqual(res.Mean, 0.332M);
        }
    }
}
