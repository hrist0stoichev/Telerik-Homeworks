namespace BullsAndCows
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        const int n = 10;
        const int k = 4;
        static int[] arr = new int[k];
        static List<string> combinations = new List<string>();
        static int bulls;
        static int cows;

        static void Main()
        {
            var number = Console.ReadLine();
            bulls = int.Parse(Console.ReadLine());
            cows = int.Parse(Console.ReadLine());

            var possibleCombinations = new List<string>();

            GenerateVariationsWithRepetitions(0);

            for (int i = 0; i < combinations.Count; i++)
            {
                if (CheckIfCompatible(number, combinations[i]))
                {
                    possibleCombinations.Add(combinations[i]);
                }
            }

            Console.WriteLine(possibleCombinations.Count == 0 ? "No" : string.Join(" ", possibleCombinations));
        }

        private static bool CheckIfCompatible(string number, string secondNumber)
        {
            var currentBulls = 0;
            var currentCows = 0;
            var boolArray = new bool[4];
            var boolArrayCows = new bool[4];

            for (int i = 0; i < 4; i++)
            {
                if (number[i] == secondNumber[i])
                {
                    currentBulls++;
                    boolArray[i] = true;
                }
            }

            for (int i = 0; i < 4; i++)
            {
                if (boolArray[i]) continue;
                for (int j = 0; j < 4; j++)
                {
                    if (boolArray[j] || boolArrayCows[j]) continue;
                    if (number[i] == secondNumber[j])
                    {
                        currentCows++;
                        boolArrayCows[j] = true;
                        break;
                    }
                }
            }

            return bulls == currentBulls && cows == currentCows;
        }

        static void GenerateVariationsWithRepetitions(int index)
        {
            if (index >= k)
            {
                AddCombination();
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    arr[index] = i;
                    if (i == 0) continue;
                    GenerateVariationsWithRepetitions(index + 1);
                }
            }
        }

        static void AddCombination()
        {
            combinations.Add(String.Join("", arr));
        }
    }
}
