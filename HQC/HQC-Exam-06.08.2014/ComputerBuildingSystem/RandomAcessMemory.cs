namespace Computers
{
    public class RandomAcessMemory
    {
        private int integerValue;

        public RandomAcessMemory(int amountRam)
        {
            this.Amount = amountRam;
        }

        private int Amount { get; set; }

        public void SaveValue(int newValue)
        {
            this.integerValue = newValue;
        }

        public int LoadValue()
        {
            return this.integerValue;
        }
    }
}