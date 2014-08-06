namespace ComputerTests
{
    using global::Computers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class BatteryTests
    {
        private LaptopBattery battery;

        [TestInitialize]
        public void TestInitialize()
        {
            this.battery = new LaptopBattery();
        }

        [TestMethod]
        public void BatteryShoudHave50PercentChargeWhenCreated()
        {
            var expectedCharge = 50;

            Assert.AreEqual(expectedCharge, this.battery.ChargedPercentage);
        }

        [TestMethod]
        public void BothChargeAndDischargeShoudWorkCorrect()
        {
            this.battery.Charge(30);
            this.battery.Charge(-20);
            var expectedCharge = 60;

            Assert.AreEqual(expectedCharge, this.battery.ChargedPercentage);
        }

        [TestMethod]
        public void BatteryShouldNotHaveMoreThan100PercentCharge()
        {
            this.battery.Charge(200);
            var expectedCharge = 100;

            Assert.AreEqual(expectedCharge, this.battery.ChargedPercentage);
        }

        [TestMethod]
        public void BatteryShouldNotHaveLessThan0PercentCharge()
        {
            this.battery.Charge(-200);
            var expectedCharge = 0;

            Assert.AreEqual(expectedCharge, this.battery.ChargedPercentage);
        }
    }
}
