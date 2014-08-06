namespace Computers.ComputerTypes
{
    using System.Collections.Generic;

    using global::Computers.Contracts;

    internal class Laptop : Computer, IComputer
    {
        public Laptop(CentralProcessingUnit cpu, RandomAcessMemory ram, IEnumerable<HardDriver> hardDrives, IVideoCard videoCard, IMotherboard motherBoard, LaptopBattery battery)
            : base(cpu, ram, hardDrives, videoCard, motherBoard)
        {
            this.LaptopBattery = battery;
        }

        public LaptopBattery LaptopBattery { get; set; }

        public override void Execute(int percentage)
        {
            this.LaptopBattery.Charge(percentage);

            var messageToShow = string.Format("Battery status: {0}", this.LaptopBattery.ChargedPercentage);
            this.VideoCard.Draw(messageToShow);
        }
    }
}
