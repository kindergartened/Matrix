﻿using System.Text.Json;

namespace MatrixExam
{
    /// <summary>
    /// Класс Matrix создан для выполениния операций над матрицами (Сложение, вычитание, умножение)
    /// </summary>
    public class Matrix
    {
        private int n, m;
        private int[,] values;

        /// <summary>
        /// пустой конструктор
        /// </summary>
        public Matrix() 
        {
            this.n = 2;
            this.m = 3;
            this.values = new int[n, m];
        }
        public int N => n;
        public int M => m;

        /// <summary>
        /// Конструктор матрицы
        /// </summary>
        /// <param name="values"></param>
        public Matrix(int[,] values)
        {
            this.m = values.GetLength(1);
            this.n = values.GetLength(0);
            this.values = values;
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
            return (this.N == m.M && this.M == m.N) || (this.M == m.n && this.N == m.M);
        }

        /// <summary>
        /// Функция получения значения элемента матрицы по индексу
        /// </summary>
        /// <param name="i">Индекс 1</param>
        /// <param name="j">Индекс 2</param>
        /// <returns>Возвращает int</returns>
        public int GetElem(int i, int j)
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
        public int SetElem (int i, int j, int value)
        {
            return values[i, j] = value;
        }

        public Matrix CreateMatrix(int N, int M, int min, int max)
        {
            Matrix NewMat = new(values);
            Random r = new Random();
            for (int i = 0; i<N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    NewMat.SetElem(i, j, r.Next(min, max));
                }
            }
            return NewMat;
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
            int[,] res = new int[M, N];

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    res[i, j] = 0;
                    for (int k = 0; k < M; k++)
                    {
                        res[i, j] = res[i,j] + values[i,k]*m.GetElem(k,j);
                    }
                }
            }

            return new Matrix(res);
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
    }
}