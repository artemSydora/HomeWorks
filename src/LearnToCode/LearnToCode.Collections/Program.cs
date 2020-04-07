using System;
using System.Collections.Generic;
using System.Text;

namespace LearnToCode.Collections
{
    class Program
    {
        public static void Main()
        {
            MyList<int> myInt = new MyList<int>(5) {};
            MyList<string> myString = new MyList<string>(5) { };
            myInt[0] = 0;
            myInt[1] = 1;
            myInt[3] = 3;
            Console.WriteLine();
            for (int i = 0; i < myInt.Count; i++)
            {
                Console.Write(myInt[i] + " ");
            }
            Console.WriteLine();

            myInt.Remove(3);
            for (int i = 0; i < myInt.Count; i++)
            {
                Console.Write(myInt[i] + " ");
            }
            Console.WriteLine( );
            Console.WriteLine(myInt.Count);



            myString[0] = "zero";
            myString[1] = "one";
            myString[3] = "three";
            Console.WriteLine();
            for (int i = 0; i < myString.Count; i++)
            {
                Console.Write(myString[i] + " ");
            }
            Console.WriteLine();

            myString.Remove("three");
            for (int i = 0; i < myString.Count; i++)
            {
                Console.Write(myString[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine(myString.Count);

            Console.ReadKey();
        }
    }
}
