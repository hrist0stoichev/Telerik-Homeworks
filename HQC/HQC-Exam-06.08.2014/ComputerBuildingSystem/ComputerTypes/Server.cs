namespace Computers.ComputerTypes
{
    using System.Collections.Generic;

    using global::Computers.Contracts;

    internal class Server : Computer, IComputer
    {
        public Server(CentralProcessingUnit cpu, RandomAcessMemory ram, IEnumerable<HardDriver> hardDrives, IVideoCard videoCard, IMotherboard motherBoard)
            : base(cpu, ram, hardDrives, videoCard, motherBoard)
        {
            this.CheckIfVideoCardIsMonochrome();
        }

        public override void Execute(int number)
        {
            this.RandomAcessMemory.SaveValue(number);
            this.CentralProcessingUnit.SquareNumber();
        }

        private void CheckIfVideoCardIsMonochrome()
        {
            if (!this.VideoCard.IsMonochrome)
            {
                this.VideoCard.IsMonochrome = true;
            }
        }
    }
}
