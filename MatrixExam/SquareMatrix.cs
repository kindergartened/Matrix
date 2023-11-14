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
            return CalculateDeterminant(values, n);
        }
        public double[] SolveEquations()
        {
            double[] result = new double[n];
            double determinant = CalculateDeterminant(values, n);
            for (int i = 0; i < n; i++)
            {
                result[i] = Math.Round((double)CalculateDeterminant(formTempMatrix(i), n) / determinant, 3);
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

        public SquareMatrix Inverse()
        {
            if (N != M)
            {
                throw new InvalidOperationException("Матрица должна быть квадратной для вычисления обратной матрицы.");
            }

            double[,] augmentedMatrix = new double[n, 2 * n];
            double determinant = CalculateDeterminant(values, n);
            double[,] inverseMatrix;

            if (determinant == 0)
            {
                throw new InvalidOperationException("Матрица не имеет обратной матрицы (определитель равен нулю).");
            }

            if (n == 2 && m == 2)
            {
                inverseMatrix = new double[n, m];
                inverseMatrix[0, 0] = values[1, 1] / determinant;
                inverseMatrix[0, 1] = -values[0, 1] / determinant;
                inverseMatrix[1, 0] = -values[1, 0] / determinant;
                inverseMatrix[1, 1] = values[0, 0] / determinant;
                return new SquareMatrix(inverseMatrix);
            }

            // Создаем расширенную матрицу [A | I]
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    augmentedMatrix[i, j] = values[i, j];
                    augmentedMatrix[i, j + n] = (i == j) ? 1.0 : 0.0;
                }
            }

            // Приводим к верхнетреугольному виду
            for (int i = 0; i < n; i++)
            {
                // Находим главный элемент в текущем столбце
                int pivotRow = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (Math.Abs(augmentedMatrix[j, i]) > Math.Abs(augmentedMatrix[pivotRow, i]))
                    {
                        pivotRow = j;
                    }
                }

                // Обмениваем строки
                for (int k = 0; k < 2 * n; k++)
                {
                    double temp = augmentedMatrix[i, k];
                    augmentedMatrix[i, k] = augmentedMatrix[pivotRow, k];
                    augmentedMatrix[pivotRow, k] = temp;
                }

                // Обнуляем элементы под главным элементом
                for (int j = i + 1; j < n; j++)
                {
                    double factor = augmentedMatrix[j, i] / augmentedMatrix[i, i];
                    for (int k = 0; k < 2 * n; k++)
                    {
                        augmentedMatrix[j, k] -= factor * augmentedMatrix[i, k];
                    }
                }
            }

            // Приводим к диагональному виду
            for (int i = n - 1; i >= 0; i--)
            {
                double pivot = augmentedMatrix[i, i];
                if (pivot == 0.0)
                {
                    throw new InvalidOperationException("Матрица не имеет обратной матрицы (определитель равен нулю).");
                }

                // Нормализуем строку
                for (int k = 0; k < 2 * n; k++)
                {
                    augmentedMatrix[i, k] /= pivot;
                }

                // Обнуляем элементы над главным элементом
                for (int j = i - 1; j >= 0; j--)
                {
                    double factor = augmentedMatrix[j, i];
                    for (int k = 0; k < 2 * n; k++)
                    {
                        augmentedMatrix[j, k] -= factor * augmentedMatrix[i, k];
                    }
                }
            }

            // Извлекаем обратную матрицу из правой части расширенной матрицы
            inverseMatrix = new double[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    inverseMatrix[i, j] = augmentedMatrix[i, j + n];
                }
            }

            return new SquareMatrix(inverseMatrix);
        }

        private double CalculateDeterminant(double[,] matrix, int n)
        {
            double[,] triangularMatrix = new double[n, n];
            Array.Copy(matrix, triangularMatrix, n * n);

            double determinant = 1;

            for (int i = 0; i < n; i++)
            {
                int pivotRow = i;

                // Поиск максимального элемента в столбце для выбора ведущего элемента
                for (int j = i + 1; j < n; j++)
                {
                    if (Math.Abs(triangularMatrix[j, i]) > Math.Abs(triangularMatrix[pivotRow, i]))
                    {
                        pivotRow = j;
                    }
                }

                if (triangularMatrix[pivotRow, i] == 0)
                {
                    return 0; // Если встречается нулевой ведущий элемент, то матрица вырожденная
                }

                // Обмен строк для улучшения стабильности вычислений
                if (pivotRow != i)
                {
                    SwapRows(triangularMatrix, i, pivotRow);
                    determinant = -determinant;
                }

                determinant *= triangularMatrix[i, i];

                // Обнуление элементов под ведущим элементом
                for (int j = i + 1; j < n; j++)
                {
                    double factor = triangularMatrix[j, i] / triangularMatrix[i, i];
                    for (int k = i; k < n; k++)
                    {
                        triangularMatrix[j, k] -= factor * triangularMatrix[i, k];
                    }
                }
            }

            return determinant;
        }

        private void SwapRows(double[,] matrix, int row1, int row2)
        {
            int cols = matrix.GetLength(1);
            for (int i = 0; i < cols; i++)
            {
                double temp = matrix[row1, i];
                matrix[row1, i] = matrix[row2, i];
                matrix[row2, i] = temp;
            }
        }

        public SquareMatrix Transpose()
        {
            int size = values.GetLength(0);

            // Оптимизированный цикл для транспонирования
            for (int i = 0; i < size; i++)
            {
                for (int j = i + 1; j < size; j++)
                {
                    // Меняем местами элементы выше и ниже главной диагонали
                    (values[i, j], values[j, i]) = (values[j, i], values[i, j]);
                }
            }
            return this;
        }
    }
}
