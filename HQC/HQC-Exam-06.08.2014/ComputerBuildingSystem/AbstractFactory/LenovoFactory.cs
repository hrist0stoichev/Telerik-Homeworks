namespace Computers.AbstractFactory
{
    using System.Collections.Generic;

    using global::Computers.ComputerTypes;

    internal class LenovoFactory : ComputersFactory
    {
        private const int PersonalComputerNumberOfCores = 2;

        private const int PersonalComputerBits = 64;

        private const int PersonalComputerRam = 4;

        private const int PersonalComputerHardDriveCapacity = 2000;

        private const bool PersonalComputerMonochromeVideoCard = true;

        private const int ServerNumberOfCores = 2;

        private const int ServerBits = 128;

        private const int ServerRam = 8;

        private const int ServerHardDriveCapacity = 1000;

        private const bool ServerMonochromeVideoCard = true;

        private const int LaptopNumberOfCores = 2;

        private const int LaptopBits = 64;

        private const int LaptopRam = 16;

        private const int LaptopHardDriveCapacity = 1000;

        private const bool LaptopMonochromeVideoCard = false;

        public override PersonalComputer MakePersonalComputer()
        {
            var ram = new RandomAcessMemory(PersonalComputerRam);
            var videoCard = new VideoCard(PersonalComputerMonochromeVideoCard);
            var motherBoard = new Motherboard(ram, videoCard);
            var cpu = new CentralProcessingUnit(PersonalComputerNumberOfCores, PersonalComputerBits, motherBoard);
            var hardDrive = new HardDriver(PersonalComputerHardDriveCapacity, false, 0);

            var lenovoPersonalComputer = new PersonalComputer(
                cpu,
                ram,
                new List<HardDriver> { hardDrive },
                videoCard,
                motherBoard);
            return lenovoPersonalComputer;
        }

        public override Server MakeServer()
        {
            // TODO:make raid
            var ram = new RandomAcessMemory(ServerRam);
            var videoCard = new VideoCard(ServerMonochromeVideoCard);
            var motherBoard = new Motherboard(ram, videoCard);
            var cpu = new CentralProcessingUnit(ServerNumberOfCores, ServerBits, motherBoard);
            var hardDrive = new HardDriver(ServerHardDriveCapacity, false, 0);

            var lenovoServer = new Server(
                cpu,
                ram,
                new List<HardDriver> { hardDrive },
                videoCard,
                motherBoard);
            return lenovoServer;
        }

        public override Laptop MakeLaptop()
        {
            var ram = new RandomAcessMemory(LaptopRam);
            var videoCard = new VideoCard(LaptopMonochromeVideoCard);
            var motherBoard = new Motherboard(ram, videoCard);
            var cpu = new CentralProcessingUnit(LaptopNumberOfCores, LaptopBits, motherBoard);
            var hardDrive = new HardDriver(LaptopHardDriveCapacity, false, 0);
            var battery = new LaptopBattery();

            var lenovoLaptop = new Laptop(
                cpu,
                ram,
                new List<HardDriver> { hardDrive },
                videoCard,
                motherBoard,
                battery);
            return lenovoLaptop;
        }
    }
}