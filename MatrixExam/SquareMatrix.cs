using System;

namespace MatrixExam
{
    public class SquareMatrix : Matrix
    {
        public SquareMatrix() : base()
        {
            Random rnd = new();
            this.n = rnd.Next(2, 6);
            this.m = this.n;
            this.values = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    values[i, j] = rnd.Next(10, 100);
                }
            }
        }

        public SquareMatrix(int[,] values) : base(values)
        {
            if (values.GetLength(0) != values.GetLength(1))
            {
                throw new ArgumentException("Квадратная матрица должна иметь одинаковое количество строк и столбцов.");
            }
            this.m = values.GetLength(1);
            this.n = values.GetLength(0);
            this.values = values;
        }

        public SquareMatrix(int rows, int cols) : base(rows, cols)
        {
            Random rnd = new();
            this.n = rows;
            this.m = cols;
            if (n != m)
            {
                throw new ArgumentException("Квадратная матрица должна иметь одинаковое количество строк и столбцов.");
            }
            this.values = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    values[i, j] = rnd.Next(10, 100);
                }
            }
        }

        public SquareMatrix(int rows, int cols, int min, int max) : base(rows, cols, min, max)
        {
            Random rnd = new();
            this.n = rows;
            this.m = cols;
            if (n != m)
            {
                throw new ArgumentException("Квадратная матрица должна иметь одинаковое количество строк и столбцов.");
            }
            this.values = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    values[i, j] = rnd.Next(min, max);
                }
            }
        }

        public int Determinant()
        {
            return MatrixDeterminant(values);
        }

        int MatrixDeterminant(int[,] matrix)
        {
            if (matrix.GetLength(0) == 1) return matrix[0, 0];
            if (matrix.GetLength(0) == 2) return (matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0]);
            int Determinant = 0;
            int[,] TempMatrix;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                TempMatrix = SpliceMatrix(matrix, 0, i);
                Determinant += (int)Math.Pow(-1, i) * matrix[0, i] * MatrixDeterminant(TempMatrix);
            }
            return Determinant;

            int[,] SpliceMatrix(int[,] matrix, int Column, int Row)
            {
                int[,] NewMatrix = new int[matrix.GetLength(0) - 1, matrix.GetLength(0) - 1];
                int m = 0, n = 0;
                for (int i = 0; i < matrix.GetLength(0); i++, m++)
                {
                    if (i != Column)
                    {
                        n = 0;
                        for (int j = 0; j < matrix.GetLength(0); j++)
                        {
                            if (j != Row)
                            {
                                NewMatrix[m, n] = matrix[i, j];
                                n++;
                            }
                        }
                    }
                    else
                        m--;
                }
                return NewMatrix;
            }
        }

        public double[] solveEquations()
        {
            double[] result = new double[N];
            long determinant = MatrixDeterminant(values);
            for (int i = 0; i < N; i++)
            {
                System.Console.WriteLine($"{(double)MatrixDeterminant(formTempMatrix(i)) / determinant}");
                result[i] = Math.Round((double)MatrixDeterminant(formTempMatrix(i)) / determinant, 3);
            }
            return result;
        }

        public override bool Equals(object? obj)
        {
            if (obj is not SquareMatrix sm) return false;

            // Вызов базовой реализации Equals для сравнения матрицы
            if (!base.Equals(sm)) return false;

            // Проверка симметрии
            if (!IsSymmetric() || !sm.IsSymmetric()) return false;

            return true;
        }
    }
}
