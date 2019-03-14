using System;

namespace ConsoleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = null;
            var calc = new Calculator.Calculator(); 

            while (!string.Equals(input, "exit", StringComparison.OrdinalIgnoreCase))
            {
                Console.Write("input expression: ");
                input = Console.ReadLine();
                double result;

                try
                {
                    result = calc.Calculate(input);
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error > " + ex.Message);
                    Console.ResetColor();

                    continue;
                }

                Console.WriteLine("> " + result);
            }
        }
    }
}
