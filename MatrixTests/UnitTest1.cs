using MatrixExam;
namespace MatrixTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMatAdd()
        {
            int[,] values = {
                {4,3,2,1},
                {4,3,2,1},
                {4,3,2,1}
            };
            int[,] arr = {
                {1,2,3,4},
                {1,2,3,4},
                {1,2,3,4}
            };

            int[,] excepted = {
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
        public void TestMatSub()
        {
            int[,] values = {
            { 5, 4, 3, 2 },
            { 5, 4, 3, 2 },
            { 5, 4, 3, 2 }
            };
            int[,] arr = {
            { 4, 3, 2, 1 },
            { 4, 3, 2, 1 },
            { 4, 3, 2, 1 }
            };

            int[,] excepted = {
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
        public void TestMatMulNum()
        {
            int[,] values = {
            { 4, 3, 2, 1 },
            { 4, 3, 2, 1 },
            { 4, 3, 2, 1 }
            };

            int num = 5;

            int[,] excepted = {
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
        public void TestMatMul()
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

            int[,] excepted = {
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