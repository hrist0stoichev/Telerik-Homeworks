namespace Computers
{
    public class LaptopBattery
    {
        private const int DefaultChargedValue = 50;

        public LaptopBattery()
        {
            this.ChargedPercentage = DefaultChargedValue;
        }

        public int ChargedPercentage { get; set; }

        public void Charge(int percentageToCharge)
        {
            this.ChargedPercentage += percentageToCharge;
            if (this.ChargedPercentage > 100)
            {
                this.ChargedPercentage = 100;
            }

            if (this.ChargedPercentage < 0)
            {
                this.ChargedPercentage = 0;
            }
        }
    }
}