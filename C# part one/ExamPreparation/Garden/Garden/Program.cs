using System;
class Garden
{
    static void Main()
    {
        int tomatoAmount = int.Parse(Console.ReadLine());
        int tomatoArea = int.Parse(Console.ReadLine());
        int cucumberAmount = int.Parse(Console.ReadLine());
        int cucumberArea = int.Parse(Console.ReadLine());
        int potatoAmount = int.Parse(Console.ReadLine());
        int potatoArea = int.Parse(Console.ReadLine());
        int carrotAmount = int.Parse(Console.ReadLine());
        int carrotArea = int.Parse(Console.ReadLine());
        int cabbageAmount = int.Parse(Console.ReadLine());
        int cabbageArea = int.Parse(Console.ReadLine());
        int beensAmount = int.Parse(Console.ReadLine());
        double totalCost = (tomatoAmount * 0.5) + (cucumberAmount * 0.4) + (potatoAmount * 0.25) + (carrotAmount * 0.6) + (cabbageAmount * 0.3) + (beensAmount * 0.4);
        Console.WriteLine("Total costs: {0:f2}", totalCost);
        int totalArea = tomatoArea + cucumberArea + potatoArea + carrotArea + cabbageArea;
        if (totalArea < 250)
        {
            Console.WriteLine("Beans area: {0}", 250 - totalArea);
        }
        else if (totalArea == 250)
        {
            Console.WriteLine("No area for beans");
        }
        else
        {
            Console.WriteLine("Insufficient area");
        }
    }
}
