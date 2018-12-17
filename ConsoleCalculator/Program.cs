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
            PostfixNotationExpression expression = new PostfixNotationExpression();
            expression.ConvertToPostfixNotationExpressionstring("1 - 2 * (4 + 3)");
            expression.Show();
            Console.ReadKey();
        }
    }
}
