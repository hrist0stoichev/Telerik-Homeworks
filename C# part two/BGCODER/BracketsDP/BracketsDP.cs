﻿namespace BracketsDP
{
    using System;
    using System.Numerics;

    internal class BracketsDP
    {
        private static void Main()
        {
            var input = Console.ReadLine();
            var solutions = new BigInteger[2, input.Length + 2];
            solutions[0, 0] = 1;
            for (var row = 0; row < input.Length; row++)
            {
                solutions[1, 0] = input[row] == '(' ? 0 : solutions[0, 1];
                for (var col = 1; col <= input.Length; col++)
                {
                    switch (input[row])
                    {
                        case '(':
                            solutions[1, col] = solutions[0, col - 1];
                            break;
                        case ')':
                            solutions[1, col] = solutions[0, col + 1];
                            break;
                        default:
                            solutions[1, col] = solutions[0, col + 1] + solutions[0, col - 1];
                            break;
                    }
                }

                for (var col = 0; col <= input.Length; col++)
                {
                    solutions[0, col] = solutions[1, col];
                }
            }

            Console.WriteLine(solutions[0, 0]);
        }
    }
}