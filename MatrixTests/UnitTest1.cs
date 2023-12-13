using MatrixExam;
using System;

namespace MatrixTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMatAdd()
        {
            double[,] values = {
                {4,3,2,1},
                {4,3,2,1},
                {4,3,2,1}
            };
            double[,] arr = {
                {1,2,3,4},
                {1,2,3,4},
                {1,2,3,4}
            };

            double[,] excepted = {
                {5,5,5,5},
                {5,5,5,5},
                {5,5,5,5}
            };

            Matrix m1 = new Matrix(values);
            Matrix m2 = new Matrix(arr);
            Matrix act = m1.MatAdd(m2);
            Matrix exc = new(excepted);

            Assert.AreEqual(exc, act);
        }
        [TestMethod]
        public void TestMatAdd1()
        {
            double[,] values = {
                {4,3,2,1},
                {4,3,2,1},
                {4,3,2,1}
            };
            double[,] arr = {
                {0,0,0,0},
                {0,0,0,0},
                {0,0,0,0}
            };

            double[,] excepted = {
                {4,3,2,1},
                {4,3,2,1},
                {4,3,2,1}
            };

            Matrix m1 = new Matrix(values);
            Matrix m2 = new Matrix(arr);
            Matrix act = m1.MatAdd(m2);
            Matrix exc = new(excepted);

            Assert.AreEqual(exc, act);
        }
        [TestMethod]
        public void TestMatSub()
        {
            double[,] values = {
            { 5, 4, 3, 2 },
            { 5, 4, 3, 2 },
            { 5, 4, 3, 2 }
            };
            double[,] arr = {
            { 4, 3, 2, 1 },
            { 4, 3, 2, 1 },
            { 4, 3, 2, 1 }
            };

            double[,] excepted = {
            { 1, 1, 1, 1 },
            { 1, 1, 1, 1 },
            { 1, 1, 1, 1 }
            };

            Matrix m1 = new Matrix(values);
            Matrix m2 = new Matrix(arr);
            Matrix exc = new Matrix(excepted);
            Matrix act = m1.MatSub(m2);
            Assert.AreEqual(exc, act);
        }
        [TestMethod]
        public void TestMatSub1()
        {
            double[,] values = {
                { 0,0,0,0 },
                { 0,0,0,0 },
                { 0,0,0,0 }
            };
            double[,] arr = {
                { 4, 3, 2, 1 },
                { 4, 3, 2, 1 },
                { 4, 3, 2, 1 }
            };

            double[,] excepted = {
                { 4, 3, 2, 1 },
                { 4, 3, 2, 1 },
                { 4, 3, 2, 1 }
            };

            Matrix m1 = new Matrix(values);
            Matrix m2 = new Matrix(arr);
            Matrix exc = new Matrix(excepted);
            Matrix act = m1.MatSub(m2);
            Assert.AreEqual(exc, act);
        }

        [TestMethod]
        public void TestMatMulNum()
        {
            double[,] values = {
            { 4, 3, 2, 1 },
            { 4, 3, 2, 1 },
            { 4, 3, 2, 1 }
            };

            int num = 5;

            double[,] excepted = {
            { 20, 15, 10, 5 },
            { 20, 15, 10, 5 },
            { 20, 15, 10, 5 }
            };

            Matrix m = new Matrix(values);
            Matrix exc = new Matrix(excepted);
            Matrix act = m.MatMulNum(num);


            Assert.AreEqual(exc, act);
        }
        [TestMethod]
        public void TestMatMulNum1()
        {
            double[,] values = {
            { 4, 3, 2, 1 },
            { 4, 3, 2, 1 },
            { 4, 3, 2, 1 }
            };

            int num = 0;

            double[,] excepted = {
                { 0,0,0,0 },
                { 0,0,0,0 },
                { 0,0,0,0 }
            };

            Matrix m = new Matrix(values);
            Matrix exc = new Matrix(excepted);
            Matrix act = m.MatMulNum(num);


            Assert.AreEqual(exc, act);
        }
        [TestMethod]
        public void TestMatMul()
        {
            double[,] values = {
            { 4, 3, 2, 1 },
            { 4, 3, 2, 1 },
            { 4, 3, 2, 1 }
            };
            double[,] arr = {
            { 1, 2, 3},
            { 1, 2, 3},
            { 1, 2, 3},
            { 1, 2, 3}
            };

            double[,] excepted = {
            { 10, 20, 30 },
            { 10, 20, 30 },
            { 10, 20, 30 }
            };

            Matrix m1 = new Matrix(values);
            Matrix m2 = new Matrix(arr);
            Matrix exc = new Matrix(excepted);
            Matrix act = m1.MatMul(m2);

            Assert.AreEqual(exc, act);
        }
    }
}