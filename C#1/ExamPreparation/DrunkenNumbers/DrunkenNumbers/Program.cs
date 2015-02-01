using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrunkenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputRows = int.Parse(Console.ReadLine());
            var vladoBeers = 0;
            var mitkoBeers = 0;

            for (int i = 0; i < inputRows; i++)
            {
                var number = Console.ReadLine().TrimStart('-').TrimStart('0');
                for (int j = 0; j < number.Length; j++)
                {
                    if (j < number.Length / (float)2)
                    {
                        if (j + 0.5 == number.Length / (float)2)
                        {
                            vladoBeers += number[j] - '0';
                        }

                        mitkoBeers += number[j] - '0';
                    }
                    else
                    {
                        vladoBeers += number[j] - '0';
                    }
                }
            }

            Console.WriteLine(vladoBeers == mitkoBeers ? "No " + vladoBeers * 2 : vladoBeers > mitkoBeers ? "V " + (vladoBeers - mitkoBeers) : "M " + (mitkoBeers - vladoBeers));
        }
    }
}
