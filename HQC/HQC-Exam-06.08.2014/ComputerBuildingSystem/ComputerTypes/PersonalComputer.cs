namespace Computers.ComputerTypes
{
    using System.Collections.Generic;

    using global::Computers.Contracts;

    internal class PersonalComputer : Computer, IComputer
    {
        public PersonalComputer(CentralProcessingUnit cpu, RandomAcessMemory ram, IEnumerable<HardDriver> hardDrives, IVideoCard videoCard, IMotherboard motherBoard)
            : base(cpu, ram, hardDrives, videoCard, motherBoard)
        {
        }

        public override void Execute(int guessedNumber)
        {
            this.CentralProcessingUnit.GenerateRandomNumber(1, 10);
            var numberToGuess = this.RandomAcessMemory.LoadValue();
            if (numberToGuess != guessedNumber)
            {
                this.VideoCard.Draw(string.Format("You didn't guess the number {0}.", numberToGuess));
            }
            else
            {
                this.VideoCard.Draw("You win!");
            }
        }
    }
}
