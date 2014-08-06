namespace Computers.AbstractFactory
{
    using global::Computers.ComputerTypes;

    internal class FactoryBuilder
    {
        private ComputersFactory factory;

        public FactoryBuilder(ComputersFactory factory)
        {
            this.factory = factory;
        }

        public PersonalComputer MakePersonalComputer()
        {
            return this.factory.MakePersonalComputer();
        }

        public Server MakeServer()
        {
            return this.factory.MakeServer();
        }

        public Laptop MakeLaptop()
        {
            return this.factory.MakeLaptop();
        }
    }
}
