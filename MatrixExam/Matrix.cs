using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace MatrixExam
{
    /// <summary>
    /// Класс Matrix создан для выполениния операций над матрицами (Сложение, вычитание, умножение)
    /// </summary>
    public class Matrix
    {
        protected int n, m;
        protected double[,] values;
        protected double[] coefs;

        /// <summary>
        /// пустой конструктор
        /// </summary>
        public Matrix()
        {
            Random rnd = new();
            this.n = rnd.Next(2, 6);
            this.m = rnd.Next(2, 6);
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
        /// Конструктор с фиксированной размерностью
        /// </summary>
        /// <param name="rows">Число строк</param>
        /// <param name="cols">Число столбцов</param>
        public Matrix(int rows, int cols)
        {
            Random rnd = new();
            this.n = rows;
            this.m = cols;
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
        /// Конструктор с фиксированой размерностью и диапазоном элементов
        /// </summary>
        /// <param name="rows">Число строк</param>
        /// <param name="cols">Число столбцов</param>
        /// <param name="min">Минимальное значение</param>
        /// <param name="max">Максимальное значение</param>
        public Matrix(int rows, int cols, int min, int max)
        {
            Random rnd = new();
            this.n = rows;
            this.m = cols;
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
        /// Количество строк матрицы
        /// </summary>
        public int N => n;

        /// <summary>
        /// Количество колонок матрицы
        /// </summary>
        public int M => m;

        /// <summary>
        /// Конструктор матрицы
        /// </summary>
        /// <param name="values"></param>
        public Matrix(double[,] values)
        {
            this.m = values.GetLength(1);
            this.n = values.GetLength(0);
            this.values = values;
        }

        /// <summary>
        /// Гетер и сетер для свободных коэффициентов матрицы
        /// </summary>
        public double[] Coefs
        {
            get
            {
                return coefs;
            }
            set
            {
                coefs = value;
            }
        }

        /// <summary>
        /// Проверка схожести матриц
        /// </summary>
        /// <param name="m">Передаваемая матрица</param>
        /// <returns></returns>
        private bool ErrorCheck(Matrix m)
        {
            return this.N == m.N && this.M == m.M;
        }

        /// <summary>
        /// Проверка матриц на выполенине схожести количества столбцов и строк исходной матрицы 
        /// и строк со столбцами передаваемой матрицы для выполенгия операции умножения
        /// </summary>
        /// <param name="m">Передаваемая матрица</param>
        /// <returns>Возвращает значение true или false в зависимости от выполнения условий сравнения</returns>
        private bool ErrorCheckMul(Matrix m)
        {
            return  (this.M == m.n );
        }

        /// <summary>
        /// Функция получения значения элемента матрицы по индексу
        /// </summary>
        /// <param name="i">Индекс 1</param>
        /// <param name="j">Индекс 2</param>
        /// <returns>Возвращает int</returns>
        public double GetElem(int i, int j)
        {
            return this.values[i, j];
        }

        /// <summary>
        /// Функция установки значения элементу матрицы по индексу
        /// </summary>
        /// <param name="i">Индекс 1</param>
        /// <param name="j">Индекс 2</param>
        /// <param name="value">Устанавливаемое значение</param>
        /// <returns>Возвращает int</returns>
        public double SetElem (int i, int j, double value)
        {
            return values[i, j] = value;
        }

        /// <summary>
        /// Функция умножения матрицы на число
        /// </summary>
        /// <param name="num">Число, на которое производится умножение</param>
        /// <returns>Возвращает матрицу с результатом умножения на число</returns>
        public Matrix MatMulNum(int num)
        {
            Matrix res = new(values);
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    res.SetElem(i, j, values[i, j] * num);
                }
            }
            return res;
        }

        /// <summary>
        /// Функция сложения матриц
        /// </summary>
        /// <param name="m">Передаваемая матрица (вторая)</param>
        /// <returns>Возвращает матрицу с результатом сложения 2-ух матриц</returns>
        public Matrix MatAdd(Matrix m)
        {
            if (!ErrorCheck(m))
                throw new Exception("Матрицы не схожи, сложение невозможно.");
            Matrix res = new(values);

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    res.SetElem(i, j, values[i, j] + m.GetElem(i, j));
                }
            }
            return res;
        }

        /// <summary>
        /// Функция вычитания матриц
        /// </summary>
        /// <param name="m">Передаваемая матрица (вторая)</param>
        /// <returns>Возвращает матрицу с результатом разности 2-ух матриц</returns>
        public Matrix MatSub(Matrix m)
        {
            if (!ErrorCheck(m))
                throw new Exception("Матрицы не схожи, вычитание невозможно.");

            Matrix res = new(values);

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    res.SetElem(i, j, values[i, j] - m.GetElem(i, j));
                }
            }
            return res;
        }

        /// <summary>
        /// Функция перемноржения матриц
        /// </summary>
        /// <param name="m">Передаваемая матрица (вторая)</param>
        /// <returns>Возвращает матрицу с результатом произведения 2-ух матриц</returns>
        public Matrix MatMul(Matrix m)
        {
            if (!ErrorCheckMul(m))
                throw new Exception("Перемножить матрицы нельзя, количество столбцов одной матрицы не равно количеству строк другой матрицы");
            double[,] res = new double[N, m.M];

            for (int i = 0; i < N; ++i)
            {
                for (int j = 0; j < m.M; ++j)
                {
                    res[i, j] = 0;
                    for (int k = 0; k < N; ++k)
                        res[i, j] += values[i, k] * m.GetElem(k, j);
                }
            }
            return new Matrix(res);
        }

        /// <summary>
        /// Проверка на симметричность матрицы
        /// </summary>
        /// <returns>True\false, симметричная или нет</returns>
        public bool IsSymmetric()
        {
            if (N != M)
            {
                return false; // Неквадратная матрица не может быть симметричной
            }

            for (int i = 0; i < N; i++)
            {
                for (int j = i + 1; j < M; j++)
                {
                    if (GetElem(i, j) != GetElem(j, i))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static Matrix operator *(Matrix m, int num)
        {
            return m.MatMulNum(num);
        }

        public static Matrix operator *(Matrix m1, Matrix m2)
        {
            return m1.MatMul(m2);
        }

        public static Matrix operator +(Matrix m1, Matrix m2)
        {
            return m1.MatAdd(m2);
        }

        public static Matrix operator -(Matrix m1, Matrix m2)
        {
            return m1.MatSub(m2);
        }


        /// <summary>
        /// Метод переопеределения Equals
        /// </summary>
        /// <param name="obj">Матрица для сравнения</param>
        /// <returns>Возвращает значение true или false в зависимости от выполнения условий сравнения</returns>
        public override bool Equals(object? obj)
        {
            if (obj is not Matrix m) return false;
            if (!ErrorCheck(m)) return false;

            for (int i = 0; i<N; i++)
            {
                for (int j = 0;j < M; j++)
                {
                    if ((m.GetElem(i, j) != this.GetElem(i, j)))
                        return false;
                }
            }

            return true;
        }

        public override string ToString()
        {
            int maxLength = values.Cast<double>().Max().ToString().Length;

            return string.Join("\n", Enumerable.Range(0, n)
                .Select(i => string.Join(" ", Enumerable.Range(0, m)
                .Select(j => Math.Round(values[i, j], 3).ToString().PadRight(maxLength)))));
        }

        /// <summary>
        /// Копирование матрицы и замена колонки на свободные коэффициенты
        /// </summary>
        /// <param name="Column">номер колонки</param>
        /// <returns>новая матрица</returns>
        public double[,] formTempMatrix(int Column)
        {
            double[,] tempMatrix = new double[N, N];
            Array.Copy(values, tempMatrix, values.Length);
            for (int i = 0; i < N; i++)
            {
                (tempMatrix[i, Column]) = (coefs[i]);
            }
            return tempMatrix;
        }

        /// <summary>
        /// Транспонирование матрицы
        /// </summary>
        /// <returns>Новая матрица</returns>
        public Matrix Transpose()
        {
            double[,] transposedMatrix = new double[m, n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    transposedMatrix[j, i] = values[i, j];
            return new Matrix(transposedMatrix);
        }
    }
}