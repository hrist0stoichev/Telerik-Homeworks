namespace Computers
{
    using System;

    using global::Computers.AbstractFactory;
    using global::Computers.ComputerTypes;
    using global::Computers.Exceptions;
    
    internal class ComputersEntryPoint
    {
        private static Computer pc, laptop, server;

        public static void Main()
        {
            var manufacturer = Console.ReadLine();
            if (manufacturer == "HP")
            {
                var hp = new HpFactory();
                var factoryBuilder = new FactoryBuilder(hp);
                pc = factoryBuilder.MakePersonalComputer();
                laptop = factoryBuilder.MakeLaptop();
                server = factoryBuilder.MakeServer();
            }
            else if (manufacturer == "Dell")
            {
                var dell = new DellFactory();
                var factoryBuilder = new FactoryBuilder(dell);
                pc = factoryBuilder.MakePersonalComputer();
                laptop = factoryBuilder.MakeLaptop();
                server = factoryBuilder.MakeServer();
            }
            else if (manufacturer == "Lenovo")
            {
                var lenovo = new LenovoFactory();
                var factoryBuilder = new FactoryBuilder(lenovo);
                pc = factoryBuilder.MakePersonalComputer();
                laptop = factoryBuilder.MakeLaptop();
                server = factoryBuilder.MakeServer();
            }
            else
            {
                throw new InvalidArgumentException("Invalid manufacturer!");
            }

            while (true)
            {
                var inputLine = Console.ReadLine();
                if (inputLine == null || inputLine.StartsWith("Exit"))
                {
                    break;
                }

                var commandParameters = inputLine.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (commandParameters.Length != 2)
                {
                    throw new ArgumentException("Invalid command, command should consist of two parameters");
                }

                var command = commandParameters[0];
                var parameter = int.Parse(commandParameters[1]);

                if (command == "Charge")
                {
                    laptop.Execute(parameter);
                }
                else if (command == "Process")
                {
                    server.Execute(parameter);
                }
                else if (command == "Play")
                {
                    pc.Execute(parameter);
                }
                else
                {
                    Console.WriteLine("Invalid command, there are three types of commands - Play, Charge, Process");
                }
            }
        }
    }
}