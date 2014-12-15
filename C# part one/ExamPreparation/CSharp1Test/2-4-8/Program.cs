namespace _2_4_8
{
    using System;

    class Program
    {
        static void Main()
        {
            long A = int.Parse(Console.ReadLine());
            long B = int.Parse(Console.ReadLine());
            long C = int.Parse(Console.ReadLine());

            decimal result = 0;
            switch (B)
            {
                case 2:
                    result = A % C;
                    break;
                case 4:
                    result = A + C;
                    break;
                case 8:
                    result = A * C;
                    break;
                default:
                    break;
            }

            if (result % 4 == 0)
            {
                Console.WriteLine(result / 4);
            }
            else
            {
                Console.WriteLine(result % 4);
            }

            Console.WriteLine(result);
        }
    }
}
