namespace Computers.AbstractFactory
{
    using global::Computers.ComputerTypes;

    internal abstract class ComputersFactory
    {
        public abstract PersonalComputer MakePersonalComputer();

        public abstract Server MakeServer();

        public abstract Laptop MakeLaptop();
    }
}
