using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ConsoleCalculator
{
    class PostfixNotationExpression
    {
        private Stack<char> _stack;
        private string _postfixNotationExpression;
        private char[] _operators = { '(', ')', '+', '-', '*', '/', '^'};

        //Метод возвращает приоритет оператора
        private byte _GetPriority(char symbol)
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
        private bool _IsOperator(char symbol)
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
        private bool _IsDelimeter(char symbol)
        {
            if(" =".IndexOf(symbol) != -1)
                return true;
            return false;
        }

        // Преобразование из префиксного в постфиксное выражение 
        public string ConvertToPostfixNotationExpressionstring (string infixNotationExpression)   
        {
            _postfixNotationExpression = string.Empty;
            _stack = new Stack<char>();
            for (int i = 0; i < infixNotationExpression.Length; i++) //Для каждого символа в входной строке
                {
                //Разделители пропускаем
                    if (_IsDelimeter(infixNotationExpression[i]))
                {
                    continue;
                }

                //Если символ - цифра, то считываем все число
                if (char.IsDigit(infixNotationExpression[i]))
                {
                    while (!_IsDelimeter(infixNotationExpression[i]) && !_IsOperator(infixNotationExpression[i]))
                    {
                        _postfixNotationExpression += infixNotationExpression[i];
                        i++;
                        if (i == infixNotationExpression.Length)
                            break;
                    }
                    _postfixNotationExpression += " ";
                    i--;
                }

                //Если символ - оператор
                if (_IsOperator(infixNotationExpression[i])) // Если оператор
                {
                    if (infixNotationExpression[i] == '(') //Если символ - открывающая скобка
                    {
                        _stack.Push(infixNotationExpression[i]); //Записываем её в стек
                    }
                    else
                    if (infixNotationExpression[i] == ')') //Если символ - закрывающая скобка
                    {
                        // Выписываем все операторы до открывающей скобки в строку
                        char s = (char)_stack.Pop();

                        while (s != '(')
                        {
                            _postfixNotationExpression += s.ToString() + ' ';
                            s = (char)_stack.Pop();
                        }

                    }
                    else //Если любой другой оператор
                    {      
                        if (_stack.Count > 0) //Если в стеке есть элементы
                            if (_GetPriority(infixNotationExpression[i]) <= _GetPriority((char)_stack.Peek())) //И если приоритет нашего оператора меньше или равен приоритету оператора на вершине стека
                                _postfixNotationExpression += _stack.Pop().ToString() + " "; //То добавляем последний оператор из стека в строку с выражением

                        _stack.Push(char.Parse(infixNotationExpression[i].ToString())); //Если стек пуст, или же приоритет оператора выше - добавляем операторов на вершину стека
                    } 
                }
            }
            //Когда прошли по всем символам, выкидываем из стека все оставшиеся там операторы в строку
            while (_stack.Count > 0)
            {
                _postfixNotationExpression += _stack.Pop() + " ";
            }
            return _postfixNotationExpression;
        }
        public void Show()
        {   
                Console.Write(_postfixNotationExpression);
        }
    }
}
