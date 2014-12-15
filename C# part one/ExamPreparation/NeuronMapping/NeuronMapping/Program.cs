namespace NeuronMapping
{
    using System;
    using System.Text;

    class Program
    {
        static void Main(string[] args)
        {
            var input = long.Parse(Console.ReadLine());
            var isInsideNeuron = false;
            while(input != -1)
            {
                var inputToBinary = Convert.ToString(input, 2).PadLeft(32, '0');
                var resultToBinary = new StringBuilder(32);
                var indexOfLast1 = inputToBinary.LastIndexOf('1');
                for (int i = 0; i < 32; i++)
                {
                    var currentBit = inputToBinary[i];
                    if (currentBit == '0')
                    {
                        if (isInsideNeuron == false)
                        {
                            resultToBinary.Append(0);
                        }
                        else
                        {
                            resultToBinary.Append(1);
                        }
                    }
                    else
                    {
                        if (isInsideNeuron == false)
                        {
                            isInsideNeuron = true;
                            resultToBinary.Append(0);
                        }
                        else
                        {
                            if (i == indexOfLast1)
                            {
                                isInsideNeuron = false;
                                resultToBinary.Append('0', 32 - resultToBinary.Length);
                                break;
                            }
                            else
                            {
                                resultToBinary.Append('0');
                            }
                        }
                    }
                }

                Console.WriteLine(Convert.ToInt64(resultToBinary.ToString(), 2));
                input = long.Parse(Console.ReadLine());
            }
        }
    }
}