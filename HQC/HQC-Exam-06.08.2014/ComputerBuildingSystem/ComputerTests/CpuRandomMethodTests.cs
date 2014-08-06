namespace ComputerTests
{
    using System;

    using global::Computers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CpuRandomMethodTests
    {
        private CentralProcessingUnit cpu;

        [TestInitialize]
        public void TestInitialize()
        {
            this.cpu = new CentralProcessingUnit(2, 32, new Motherboard(new RandomAcessMemory(2), new VideoCard(false)));
        }

        [TestMethod]
        public void RandomShoudReturnNumberInTheRange1To10()
        {
            this.cpu.GenerateRandomNumber(1, 10);
            bool isInTheRange = true;

            if (this.cpu.MotherBoard.LoadRamValue() > 10 || this.cpu.MotherBoard.LoadRamValue() < 1)
            {
                isInTheRange = false;
            }

            Assert.IsTrue(isInTheRange);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RandomShoudNotWorkWhenTheParametersAreSwitched()
        {
            this.cpu.GenerateRandomNumber(10, 1);
        }

        [TestMethod]
        public void RandomShoudReturnTheSameNumberWhenTheTwoParametersAreEqual()
        {
            this.cpu.GenerateRandomNumber(10, 10);
            var expectedNumber = 10;

            Assert.AreEqual(expectedNumber, this.cpu.MotherBoard.LoadRamValue());
        }
    }
}
