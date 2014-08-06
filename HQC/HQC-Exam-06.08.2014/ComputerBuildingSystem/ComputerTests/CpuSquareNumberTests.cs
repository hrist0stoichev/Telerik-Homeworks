namespace ComputerTests
{
    using global::Computers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CpuSquareNumberTests
    {
        private CentralProcessingUnit cpu;

        [TestInitialize]
        public void TestInitialize()
        {
            this.cpu = new CentralProcessingUnit(2, 32, new Motherboard(new RandomAcessMemory(2), new VideoCard(false)));
        }

        [TestMethod]
        public void MethodShouldNotWorkWithNegativeNumbers()
        {
            this.cpu.MotherBoard.SaveRamValue(-1);

            var expectedResult = "Number too low.";

            Assert.AreEqual(expectedResult, this.cpu.CalculateSquareNumber(500));
        }

        [TestMethod]
        public void MethodShouldNotWorkWithHigherNumbersThanParameter()
        {
            this.cpu.MotherBoard.SaveRamValue(1000);

            var expectedResult = "Number too high.";

            Assert.AreEqual(expectedResult, this.cpu.CalculateSquareNumber(500));
        }

        [TestMethod]
        public void MethodShoudWorkCorrectWithNumbersInTheRange()
        {
            this.cpu.MotherBoard.SaveRamValue(250);

            var expectedResult = "Square of 250 is 62500.";

            Assert.AreEqual(expectedResult, this.cpu.CalculateSquareNumber(500));
        }
    }
}
