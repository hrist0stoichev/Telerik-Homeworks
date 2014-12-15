using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fire
{
    class Program
    {
        static void Main(string[] args)
        {
            var width = int.Parse(Console.ReadLine());
            for (int i = 0; i < width / 2; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (j == width / 2 - 1 - i || j == width / 2 + i) Console.Write('#');
                    else Console.Write('.');
                }

                Console.WriteLine();
            }

            for (int i = 0; i < width / 4; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (j == i || j == width - 1 - i) Console.Write('#');
                    else Console.Write('.');
                }

                Console.WriteLine();
            }

            Console.WriteLine(new String('-', width));

            for (int i = 0; i < width / 2; i++)
            {
                Console.Write(new String('.', i));
                Console.Write(new String('\\', width / 2 - i));
                Console.Write(new String('/', width / 2 - i));
                Console.Write(new String('.', i));
                Console.WriteLine();
            }
        }
    }
}