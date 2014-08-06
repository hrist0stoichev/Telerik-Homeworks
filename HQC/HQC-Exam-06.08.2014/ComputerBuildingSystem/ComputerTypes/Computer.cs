namespace Computers.ComputerTypes
{
    using System.Collections.Generic;

    using global::Computers.Contracts;

    internal abstract class Computer : IComputer
    {
        protected Computer(CentralProcessingUnit cpu, RandomAcessMemory ram, IEnumerable<HardDriver> hardDrives, IVideoCard videoCard, IMotherboard motherBoard)
        {
            this.CentralProcessingUnit = cpu;
            this.RandomAcessMemory = ram;
            this.HardDrives = hardDrives;
            this.VideoCard = videoCard;
            this.MotherBoard = motherBoard;
        }

        public CentralProcessingUnit CentralProcessingUnit { get; set; }

        public RandomAcessMemory RandomAcessMemory { get; set; }

        public IEnumerable<HardDriver> HardDrives { get; set; }

        public IVideoCard VideoCard { get; private set; }

        public IMotherboard MotherBoard { get; set; }

        public abstract void Execute(int parameter);
    }
}
