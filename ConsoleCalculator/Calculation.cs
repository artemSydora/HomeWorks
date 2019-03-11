using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ConsoleCalculator
{
    class Calculation
    {
        Stack<double> stack;
        public string PostfixExpression { get; set; }
        double result = 0;
        PostfixNotationExpression expression = new PostfixNotationExpression();
        
        private double GetResult(string InfixExpression)
        {
            stack = new Stack<double> { };
            PostfixExpression = expression.ConvertToPostfixExpression(InfixExpression);
            
            try
            {
                for (int i = 0; i < PostfixExpression.Length; i++)
                {
                    if (expression.IsDelimeter(PostfixExpression[i]))
                        continue;
                    else          
                    if (char.IsDigit(PostfixExpression[i]))
                    {
                        string number = string.Empty;
                        while (!expression.IsDelimeter(PostfixExpression[i]) && !expression.IsOperator(PostfixExpression[i]))
                        {
                            number += PostfixExpression[i];
                            i++;
                            if (i == PostfixExpression.Length)
                                break;
                        }
                        stack.Push(Convert.ToDouble(number));
                        i--;
                    }
else
                    if (expression.IsOperator(PostfixExpression[i]))
                    {
                        switch (PostfixExpression[i])
                        {
                            case '+':
                                {
                                    double a = stack.Pop();
                                    double b = stack.Pop();
                                    result = a + b;
                                    break;
                                }
                            case '-':
                                {
                                    double a = stack.Pop();
                                    double b = stack.Pop();
                                    result = b - a;
                                    break;
                                }
                            case '*':
                                {
                                    double a = stack.Pop();
                                    double b = stack.Pop();
                                    result = a * b;
                                    break;
                                }
                            case '/':
                                {
                                    double a = stack.Pop();
                                    double b = stack.Pop();
                                    if (a == 0)
                                        throw new DivideByZeroException();
                                    result = b / a;
                                    break;
                                }
                            case '^':
                                {
                                    double a = stack.Pop();
                                    double b = stack.Pop();
                                    result = Math.Pow(b, a);
                                    break;
                                }
                        }
                        stack.Push(result);
                    } 
                }
            }
            catch (Exception e)
            {
                if (e is DivideByZeroException)
                    Console.WriteLine("Нельзя делить на ноль");
                if (e is FormatException)
                    Console.WriteLine("Неверные входные данные");
            }

            return result;
        }
       
        public void Show()
        {   
            
            while (expression.Input != "Exit")
            {
                Console.Write("Введите выражение: ");
                expression.Input = Console.ReadLine();
                GetResult(expression.Input);
                Console.WriteLine("Постфиксная форма выражения: {0}", PostfixExpression);
                Console.WriteLine("Результат: {0}", result);
                Console.WriteLine();
            }
        }
    }
}
