using System;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace MatrixExam
{
    public class SquareMatrix : Matrix
    {
        private double[,] augmentedMatrix; // Расширенная матрица
        /// <summary>
        /// конструктор по умолчанию
        /// </summary>
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
        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="values"></param>
        /// <exception cref="ArgumentException"></exception>
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
        /// <summary>
        /// конструктор для создания случайной матрицы (элементы не заданы,поэтому мы их задаём сами)
        /// </summary>
        /// <param name="rows">ряды</param>
        /// <param name="cols">колонки</param>
        /// <exception cref="ArgumentException"></exception>
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
        /// <summary>
        /// конструктор для  создания случайной квадтратной матрицы
        /// </summary>
        /// <param name="rows">ряды</param>
        /// <param name="cols">колонки</param>
        /// <param name="min">минимальное значение</param>
        /// <param name="max">максимальное значение</param>
        /// <exception cref="ArgumentException"></exception>
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
        /// <summary>
        /// метод для вычисления детерминанта
        /// </summary>
        /// <returns></returns>
        public double Determinant()
        {
            return CalculateDeterminant(values, n);
        }
        /// <summary>
        /// решение СЛАУ
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// сравнение
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object? obj)
        {
            if (obj is not SquareMatrix sm) return false;

            // Вызов базовой реализации Equals для сравнения матрицы
            if (!base.Equals(sm)) return false;

            // Проверка симметрии
            if (!IsSymmetric() || !sm.IsSymmetric()) return false;

            return true;
        }
        /// <summary>
        /// метод для вычисления обратной матрицы
        /// </summary>
        /// <returns>обратную матрицу</returns>
        public SquareMatrix InvertMatrix()
        {
            InitializeAugmentedMatrix(); // Инициализация расширенной матрицы
            for (int i = 0; i < N; i++)
            {
                Transform_Line(i);
                Transform_Lines_Parallel(i);
            }

            // Применение обратного хода
            for (int i = N - 1; i > 0; i--)
            {
                Parallel.For(0, i, j =>
                {
                    double t = -augmentedMatrix[j, i];
                    for (int q = 0; q < N * 2; q++)
                    {
                        augmentedMatrix[j, q] = augmentedMatrix[j, q] + t * augmentedMatrix[i, q];
                    }
                });
            }

            // Приведение левой половины расширенной матрицы к единичной матрице
            Parallel.For(0, N, i =>
            {
                double t = augmentedMatrix[i, i];
                Parallel.For(0, N * 2, j =>
                {
                    augmentedMatrix[i, j] = augmentedMatrix[i, j] / t;
                });
            });

            // Извлечение обратной матрицы из правой половины расширенной матрицы
            double[,] inverseMatrix = new double[N, N];
            Parallel.For(0, N, i =>
            {
                for (int j = 0; j < N; j++)
                {
                    inverseMatrix[i, j] = augmentedMatrix[i, j + N];
                }
            });

            return new SquareMatrix(inverseMatrix);
        }

        // Инициализация расширенной матрицы
        private void InitializeAugmentedMatrix()
        {
            augmentedMatrix = new double[N, 2 * N];
            Parallel.For(0, N, i =>
            {
                for (int j = 0; j < N; j++)
                {
                    augmentedMatrix[i, j] = values[i, j];
                }

                augmentedMatrix[i, N + i] = 1.0;
            });
        }

        // Элементарное преобразование для i-той строки
        private void Transform_Line(int i)
        {
            double t = augmentedMatrix[i, i];
            Parallel.For(0, N * 2, j =>
            {
                augmentedMatrix[i, j] = augmentedMatrix[i, j] / t;
            });
        }

        // Элементарное преобразование для всех строк, кроме i-той (параллельная версия)
        private void Transform_Lines_Parallel(int i)
        {
            Parallel.For(0, N, j =>
            {
                if (j != i)
                {
                    double t = -augmentedMatrix[j, i];
                    for (int q = 0; q < N * 2; q++)
                    {
                        augmentedMatrix[j, q] = augmentedMatrix[j, q] + t * augmentedMatrix[i, q];
                    }
                }
            });
        }

        /// <summary>
        /// метод CalculateDeterminant для вычисления детерминанта
        /// </summary>
        /// <param name="matrix">матрица</param>
        /// <param name="n">размер матрицы</param>
        /// <returns></returns>
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
        /// <summary>
        /// смена рядов в заданной матрице
        /// </summary>
        /// <param name="matrix">матрицы</param>
        /// <param name="row1">ряд 1</param>
        /// <param name="row2">ряд 2</param>
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
        /// <summary>
        /// транспонирование квадратной матрицы
        /// </summary>
        /// <returns></returns>
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
