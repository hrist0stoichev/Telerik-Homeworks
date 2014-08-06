namespace Computers
{
    using System;

    using global::Computers.Contracts;

    public class CentralProcessingUnit
    {
        private readonly Random random;

        private readonly byte numberOfBits;

        public CentralProcessingUnit(byte numberOfCores, byte numberOfBits, IMotherboard motherboard)
        {
            this.numberOfBits = numberOfBits;
            this.NumberOfCores = numberOfCores;
            this.MotherBoard = motherboard;
            this.random = new Random();
        }

        public IMotherboard MotherBoard { get; set; }

        private byte NumberOfCores { get; set; }

        public void SquareNumber()
        {
            var result = string.Empty;
            if (this.numberOfBits == 32)
            {
                result = this.CalculateSquareNumber(500);
                this.DrawOnVideoCard(result);
            }
            else if (this.numberOfBits == 64)
            {
                result = this.CalculateSquareNumber(1000);
                this.DrawOnVideoCard(result);
            }
            else if (this.numberOfBits == 128)
            {
                result = this.CalculateSquareNumber(2000);
                this.DrawOnVideoCard(result);
            }
        }

        public void GenerateRandomNumber(int minValue, int maxValue)
        {
            int randomNumber = this.random.Next(minValue, maxValue);
            this.MotherBoard.SaveRamValue(randomNumber);
        }

        public string CalculateSquareNumber(int maxAmount)
        {
            var data = this.MotherBoard.LoadRamValue();
            if (data < 0)
            {
                return "Number too low.";
            }
            else if (data > maxAmount)
            {
                return "Number too high.";
            }
            else
            {
                var squareNumber = data * data;
                var result = string.Format("Square of {0} is {1}.", data, squareNumber);
                return result;
            }
        }

        private void DrawOnVideoCard(string result)
        {
            this.MotherBoard.DrawOnVideoCard(result);
        }
    }
}