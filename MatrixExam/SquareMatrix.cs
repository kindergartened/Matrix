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
            this.values = new double[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    values[i, j] = rnd.Next(10, 100);
                }
            }
        }

        public SquareMatrix(double[,] values) : base(values)
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
            this.values = new double[n, m];
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
            this.values = new double[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    values[i, j] = rnd.Next(min, max);
                }
            }
        }

        public double Determinant()
        {
            return MatrixDeterminant(values);
        }

        double MatrixDeterminant(double[,] matrix)
        {
            if (matrix.GetLength(0) == 1) return matrix[0, 0];
            if (matrix.GetLength(0) == 2) return (matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0]);
            double Determinant = 0;
            double[,] TempMatrix;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                TempMatrix = SpliceMatrix(matrix, 0, i);
                Determinant += Math.Pow(-1, i) * matrix[0, i] * MatrixDeterminant(TempMatrix);
            }
            return Determinant;

            double[,] SpliceMatrix(double[,] matrix, int Column, int Row)
            {
                double[,] NewMatrix = new double[matrix.GetLength(0) - 1, matrix.GetLength(0) - 1];
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

        public double[] SolveEquations()
        {
            double[] result = new double[n];
            double determinant = MatrixDeterminant(values);
            for (int i = 0; i < n; i++)
            {
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

        public Matrix Inverse()
        {
            if (N != M)
            {
                throw new InvalidOperationException("Матрица должна быть квадратной для вычисления обратной матрицы.");
            }

            int n = N;
            double[,] inverseMatrix = new double[n, n];
            double determinant = CalculateDeterminant(values, n);

            if (n == 2 && m == 2)
            {
                inverseMatrix[0, 0] = values[1, 1] / determinant;
                inverseMatrix[0, 1] = -values[0, 1] / determinant;
                inverseMatrix[1, 0] = -values[1, 0] / determinant;
                inverseMatrix[1, 1] = values[0, 0] / determinant;
                return new Matrix(inverseMatrix);
            }

            if (determinant == 0)
            {
                throw new InvalidOperationException("Матрица не имеет обратной матрицы (определитель равен нулю).");
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    double cofactor = CalculateCofactor(values, n, i, j);
                    inverseMatrix[j, i] = cofactor / determinant;
                }
            }

            return new Matrix(inverseMatrix);
        }

        private double CalculateDeterminant(double[,] matrix, int n)
        {
            if (n == 2)
            {
                return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
            }

            double determinant = 0;
            int sign = 1;

            for (int i = 0; i < n; i++)
            {
                double[,] submatrix = new double[n - 1, n - 1];
                for (int j = 1; j < n; j++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        if (k < i)
                        {
                            submatrix[j - 1, k] = matrix[j, k];
                        }
                        else if (k > i)
                        {
                            submatrix[j - 1, k - 1] = matrix[j, k];
                        }
                    }
                }
                determinant += sign * matrix[0, i] * CalculateDeterminant(submatrix, n - 1);
                sign = -sign;
            }

            return determinant;
        }

        private double CalculateCofactor(double[,] matrix, int n, int row, int col)
        {
            double[,] submatrix = new double[n - 1, n - 1];
            int subrow = 0;
            for (int i = 0; i < n; i++)
            {
                if (i == row)
                {
                    continue;
                }
                int subcol = 0;
                for (int j = 0; j < n; j++)
                {
                    if (j == col)
                    {
                        continue;
                    }
                    submatrix[subrow, subcol] = matrix[i, j];
                    subcol++;
                }
                subrow++;
            }
            int sign = ((row + col) % 2 == 0) ? 1 : -1;
            return sign * CalculateDeterminant(submatrix, n - 1);
        }

    }
}
