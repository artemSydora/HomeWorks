using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ConsoleCalculator
{
    class PostfixExpression
    {
        private Stack<char> _stack;
        public string postfixExpression, infixExpression;
        private char[] _operators = { '(', ')', '+', '-', '*', '/', '^'};

        private byte GetOperatorPriority(char symbol)
        {
            switch (symbol)
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

        //Метод возвращает true, если проверяемый символ - оператор
        public bool IsOperator(char symbol)
        {
            foreach(char oper in _operators)
            {
                if (oper == symbol)
                {
                    return true;
                }
            }
            return false;
        }

        //Метод возвращает true, если проверяемый символ - разделитель ("пробел" или "равно")
        public bool IsDelimeter(char symbol)
        {
            if(" =".IndexOf(symbol) != -1)
                return true;
            return false;
        }

        // Преобразование из префиксного в постфиксное выражение 
        public string ConvertToPostfixExpression (string infixExpression)   
        {
            this.infixExpression = infixExpression;
            postfixExpression = string.Empty;
            _stack = new Stack<char>();
            for (int i = 0; i < infixExpression.Length; i++) //Для каждого символа в входной строке
                {
                //Разделители пропускаем
                    if (IsDelimeter(infixExpression[i]))
                {
                    continue;
                }

                //Если символ - цифра, то считываем все число
                if (char.IsDigit(infixExpression[i]))
                {  
                    while (!IsDelimeter(infixExpression[i]) && !IsOperator(infixExpression[i]))
                    {
                        postfixExpression += infixExpression[i];
                        i++;
                        if (i == infixExpression.Length)
                            break;
                    }
                    postfixExpression += " ";
                    i--;
                }

                //Если символ - оператор
                if (IsOperator(infixExpression[i])) // Если оператор
                { 
                    if (infixExpression[i] == '(') //Если символ - открывающая скобка
                    {
                        _stack.Push(infixExpression[i]); //Записываем её в стек
                    }
                    else
                    if (infixExpression[i] == ')') //Если символ - закрывающая скобка
                    {
                        // Выписываем все операторы до открывающей скобки в строку
                        char s = (char)_stack.Pop();

                        while (s != '(')
                        {
                            postfixExpression += s.ToString() + ' ';
                            s = (char)_stack.Pop();
                        }

                    }
                    else //Если любой другой оператор
                    {      
                        if (_stack.Count > 0) //Если в стеке есть элементы
                            if (GetOperatorPriority(infixExpression[i]) <= GetOperatorPriority((char)_stack.Peek())) //И если приоритет нашего оператора меньше или равен приоритету оператора на вершине стека
                                postfixExpression += _stack.Pop().ToString() + " "; //То добавляем последний оператор из стека в строку с выражением

                        _stack.Push(char.Parse(infixExpression[i].ToString())); //Если стек пуст, или же приоритет оператора выше - добавляем операторов на вершину стека
                    } 
                }
            }
            //Когда прошли по всем символам, выкидываем из стека все оставшиеся там операторы в строку
            while (_stack.Count > 0)
            {
                postfixExpression += _stack.Pop() + " ";
            }
            return postfixExpression;
        }

        
    }
}
