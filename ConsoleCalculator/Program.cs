using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            PostfixNotationExpression expression = new PostfixNotationExpression("3 + 4 * (2 - 1))");
            expression.ConvertToPostfixNotationExpression();
            expression.Show();
            Console.ReadKey();
        }
    }
}
