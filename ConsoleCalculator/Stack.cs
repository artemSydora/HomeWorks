using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalculator
{
    class Stack // Реализация стека операторов;
    {
        char[] stack;    // Ссылка на массив, содержащий стек;
        int stackTopIndex;    // Вершина стека;
        public Stack(int size)
        {
            stack = new char[size];  // Распределение памяти для стека; 
            stackTopIndex = 0;    // Инициализация вершины стека
        }

        // Помещение символа в стек;
        public void Push(char ch)
        {
            if (stackTopIndex == stack.Length)
            {
                Console.WriteLine("Стек заполнен");
                return;
            }
            stack[stackTopIndex] = ch;
            stackTopIndex++;
        }

        // Выталкивание символа из стека;
        public char Pop()
        {
            if (stackTopIndex == 0)
            {
                Console.WriteLine("Стек пуст");
                return (char)0;
            }
            stackTopIndex--;
            return stack[stackTopIndex];
        }

        // 
        public int GetStackTopIndex()
        {
            return stackTopIndex;
        }
        public char Peek()
        {
            return stack[stackTopIndex];
        }
    }
}
