using System;

namespace MultiplicationTable
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Multiplicatiion Table Assignment!");

            // Initialize 2d Array Obj
            int num1 = 0;
            int num2 = 0;
            int [,] multArray = new int[10,10];
            
            for (int outer = 0; outer < 10; outer++)
            {
                num1++;
                num2 = 0;
                for (int inner = 0; inner < 10; inner++)
                {
                    num2++;
                    multArray[outer,inner] = num1*num2;
                }
            }

            for (int i = 0; i < multArray.GetLength(0); i++)
            {
                string innerList = "[";
                for (int j = 0; j < multArray.GetLength(1); j++)
                {
                    innerList += multArray[i,j];
                    if (j == 9)
                    {
                        continue;
                    }
                    else 
                    {
                        innerList += ",";
                    }
                }
                innerList += "]";
                System.Console.WriteLine(innerList);
            }
        }
    }
}
