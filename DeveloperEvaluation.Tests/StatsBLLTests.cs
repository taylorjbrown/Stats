using DeveloperEvaluation.BLL;
using DeveloperEvaluation.Model;
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
        public void mean1()
        {
            
            List<decimal> nums = new List<decimal>();
            nums.Add(1M);
            nums.Add(4.556M);
            nums.Add(-4.56M);
          
            Task<decimal> res = _statsCalc.mean(nums);

            Assert.AreEqual(res.Result, 0.332M);

        }

        //all values appear once
        [TestMethod]
        public void mode1()
        {
            List<decimal> nums = new List<decimal>();
            nums.Add(1M);
            nums.Add(4.556M);
            nums.Add(-4.56M);

            List<decimal> resultMock = new List<decimal>();
            Task<List<decimal>> res = _statsCalc.mode(nums);

            CollectionAssert.AreEqual(res.Result, resultMock);
        }

        //just one mode
        [TestMethod]
        public void mode2()
        {
            List<decimal> nums = new List<decimal>();
            nums.Add(3M);
            nums.Add(4M);
            nums.Add(5M);
            nums.Add(1M);
            nums.Add(4M);

            List<decimal> resMock = new List<decimal>();
            resMock.Add(4M);

            Task<List<decimal>> res = _statsCalc.mode(nums);
            CollectionAssert.AreEqual(res.Result, resMock);
        }

        //more than one mode
        [TestMethod]
        public void mode3()
        {
            List<decimal> nums = new List<decimal>();
            nums.Add(3M);
            nums.Add(4M);
            nums.Add(5M);
            nums.Add(1M);
            nums.Add(4M);
            nums.Add(6M);
            nums.Add(5M);

            List<decimal> resultMock = new List<decimal>();
            resultMock.Add(4M);
            resultMock.Add(5M);

            Task<List<decimal>> res = _statsCalc.mode(nums);
            CollectionAssert.AreEqual(res.Result,resultMock);
        }

        //more than one mode and different numbers of frequncy over 1
        [TestMethod]
        public void mode4()
        {
            List<decimal> nums = new List<decimal>();
            nums.Add(3M);
            nums.Add(4M);
            nums.Add(5M);
            nums.Add(1M);
            nums.Add(4M);
            nums.Add(6M);
            nums.Add(5M);
            nums.Add(1M);
            nums.Add(1M);
            List<decimal> resultMock = new List<decimal>();
            resultMock.Add(1M);

            Task<List<decimal>> res = _statsCalc.mode(nums);
            CollectionAssert.AreEqual(res.Result,resultMock);
        }

        [TestMethod]
        public void median1()
        {
            List<decimal> nums = new List<decimal>();
            nums.Add(1M);
            nums.Add(4.556M);
            nums.Add(-4.56M);

            Task<decimal> res = _statsCalc.median(nums);

            Assert.AreEqual(res.Result, 1M);
        }

        [TestMethod]
        public void median2()
        {
            List<decimal> nums = new List<decimal>();
            nums.Add(3.4445M);
            nums.Add(5M);
            nums.Add(6M);
            nums.Add(8M);

            Task<decimal> res = _statsCalc.median(nums);

            Assert.AreEqual(res.Result, 5.5M);
        }

        [TestMethod]
        public void CalcAsync1()
        {
            List<decimal> nums = new List<decimal>();
            nums.Add(1M);
            nums.Add(4.556M);
            nums.Add(-4.56M);

            Task<Stats> res = _statsCalc.CalcAsync(nums);

           // Assert.AreEqual(res.Result, 0.332M);
        }
    }
}
