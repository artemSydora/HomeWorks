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
        public string postfixExpression;
        double result = 0;
        PostfixExpression expression = new PostfixExpression();
        
        private double GetResult(string infixExpression)
        {
            stack = new Stack<double> { };
            postfixExpression = expression.ConvertToPostfixExpression(infixExpression);

            try
            {
                for (int i = 0; i < postfixExpression.Length; i++)
                {
                    if (expression.IsDelimeter(postfixExpression[i]))
                    {
                        continue;
                    }
                    else          
                    if (char.IsDigit(postfixExpression[i]))
                    {
                        string number = string.Empty;
                        while (!expression.IsDelimeter(postfixExpression[i]) && !expression.IsOperator(postfixExpression[i]))
                        {
                            number += postfixExpression[i];
                            i++;
                            if (i == postfixExpression.Length)
                                break;
                        }
                        stack.Push(Convert.ToDouble(number));
                        i--;
                    }
                    else
                    if (expression.IsOperator(postfixExpression[i]))
                    {
                        switch (postfixExpression[i])
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
                                    {
                                        throw new DivideByZeroException();
                                    }
                                    else
                                    {
                                        result = b / a;
                                    }
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
                {
                    Console.WriteLine("Нельзя делить на ноль");
                }
                if (e is FormatException)
                {
                    Console.WriteLine("Неверные входные данные");
                }
            }

            return result;
        }
       
        public void Show()
        {   
            
            while (expression.input != "Exit")
            {
                Console.Write("Введите выражение: ");
                expression.input = Console.ReadLine();
                GetResult(expression.input);
                Console.WriteLine("Постфиксная форма выражения: {0}", postfixExpression);
                Console.WriteLine("Результат: {0}", result);
                Console.WriteLine();
            }
        }
    }
}
