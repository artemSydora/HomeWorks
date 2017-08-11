using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalculator
{
    class PostfixNotationExpression
    {
        Stack stack;
        string postfixNotationExpression;
        char[] infixNotationExpression, operators = { '(', ')', '+', '-', '*', '/', '^'};

        public PostfixNotationExpression(string infixNotationExpression)
        {
            this.infixNotationExpression = infixNotationExpression.ToCharArray();
            postfixNotationExpression = null;
            stack = new Stack(infixNotationExpression.Length);
        }

        
        private byte GetPriority(char oper)
        {
            switch (oper)
            {
                case '(':
                case ')':
                    return 0;
                case '+':
                case '-':
                    return 1;
                case '*':
                case '/':
                    return 2;
                case '^':
                    return 3;
                default:
                    return 4;

            }
        }
        private bool IsOperator(char symbol)
        {
            foreach(char oper in operators)
            {
                if (symbol == oper)
                {
                    return true;
                }
            }
            return false;
        }

        // Преобразование из префиксного в постфиксное выражение 
        public string ConvertToPostfixNotationExpression()
        {
            
            foreach(char symbol in infixNotationExpression)
            {
                // Если символ является числом, добавляем его к выходной строке;
                if (char.IsDigit(symbol))
                {
                    postfixNotationExpression += symbol;
                } else

                //Если символ является символом функции, помещаем его в стек;
                if (IsOperator(symbol))
                {
                    
                    //Если символ является закрывающей скобкой:
                    /*До тех пор, пока верхним элементом стека не станет открывающая скобка, выталкиваем элементы из стека 
                    в выходную строку. При этом открывающая скобка удаляется из стека, но в выходную строку не добавляется. 
                    Если стек закончился раньше, чем мы встретили открывающую скобку, это означает, что в выражении либо 
                    неверно поставлен разделитель, либо не согласованы скобки.*/
                    if (symbol == ')')
                    {
                        //Если символ является открывающей скобкой, помещаем его в стек;
                        while (stack.Peek() != '(')
                        {
                            postfixNotationExpression += stack.Pop();
                            
                        }
                    }

                    else
                    {
                        stack.Push(symbol);
                    }
                    
                }// else
               // if ()
            }
            while(stack.GetStackTopIndex() != 0)
            {
                postfixNotationExpression += stack.Pop();
            }
            return postfixNotationExpression;
        }
        
                   
                    
                    
                   
                   
                //for(int y = 0; y < digits.Length; y++)
                 
                    
                   

        

        public void Show()
        {
            
                Console.Write(postfixNotationExpression);
           
            
        }
    }
}
