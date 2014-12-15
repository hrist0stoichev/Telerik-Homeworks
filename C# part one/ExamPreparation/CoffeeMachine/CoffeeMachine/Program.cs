using System;

class CoffeeMachine
{
    static void Main()
    {
        int n1 = int.Parse(Console.ReadLine());
        int n2 = int.Parse(Console.ReadLine());
        int n3 = int.Parse(Console.ReadLine());
        int n4 = int.Parse(Console.ReadLine());
        int n5 = int.Parse(Console.ReadLine());
        float a = float.Parse(Console.ReadLine());
        float p = float.Parse(Console.ReadLine());
        float moneyInTheMachine = (float)((n1 * 0.05) + (n2 * 0.10) + (n3 * 0.20) + (n4 * 0.50) + n5);
        float change = (float)a - p;
        if (a >= p && moneyInTheMachine >= change)
        {
            Console.WriteLine("Yes {0:f2}", moneyInTheMachine - change);
        }
        else if (p > a)
        {
            Console.WriteLine("More {0:f2}", p - a);
        }
        else if (a >= p && moneyInTheMachine < change)
        {
            Console.WriteLine("No {0:f2}", change - moneyInTheMachine);
        }
    }
}