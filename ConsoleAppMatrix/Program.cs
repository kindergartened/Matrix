using System;
using MatrixExam;

namespace ConsoleAppMatrix
{
    class Program
    {
        static void Main()
        {
            int[,] values = {
            { 4, 3, 2, 1 },
            { 4, 3, 2, 1 },
            { 4, 3, 2, 1 }
            };
            int[,] arr = {
            { 1, 2, 3},
            { 1, 2, 3},
            { 1, 2, 3},
            { 1, 2, 3}
            };

            Matrix m1 = new Matrix(values);
            Matrix m2 = new Matrix(arr);
            Matrix act = m1.MatMul(m2);

            for (int i = 0; i < act.N; i++)
            {
                for (int j = 0; j < act.M; j++)
                {
                    Console.Write(act.GetElem(i, j) + "\t");
                }
                Console.WriteLine();
            }

        }
    }
}