using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightmareOnCodeStreet
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var counter = 0;
            long result = 0;

            for (int i = 1; i < input.Length; i+= 2)
            {
                if (char.IsDigit(input[i]))
                {
                    counter++;
                    result += int.Parse(input[i].ToString());
                }
            }

            Console.WriteLine("{0} {1}", counter, result);
        }
    }
}
