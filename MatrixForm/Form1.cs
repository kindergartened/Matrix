using MatrixExam;

namespace MatrixForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private dynamic matrix1;
        private dynamic matrix2;
        private dynamic result;
        private void parseMatrix_Click(object sender, EventArgs e)
        {
            try
            {
                string[] arr = thirdMatrix.Text.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                int rows = arr.Length;
                int cols = arr[0].Split(' ').Length;
                double[,] values = new double[rows, cols];
                for (int i = 0; i < rows; i++)
                {
                    string[] rowValues = arr[i].Split(' ');
                    for (int j = 0; j < cols; j++)
                    {
                        values[i, j] = double.Parse(rowValues[j]);
                    }
                }
                if (isFirst.Checked)
                {
                    if (isSquare.Checked)
                    {
                        matrix1 = new SquareMatrix(values);
                        firstMatrix.Text = matrix1.ToString();
                    }
                    else
                    {
                        matrix1 = new Matrix(values);
                        firstMatrix.Text = matrix1.ToString();
                    }
                }
                else
                {
                    if (isSquare.Checked)
                    {
                        matrix2 = new SquareMatrix(values);
                        secondMatrix.Text = matrix2.ToString();
                    }
                    else
                    {
                        matrix2 = new Matrix(values);
                        secondMatrix.Text = matrix2.ToString();
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void createMatrix1_Click(object sender, EventArgs e)
        {
            try
            {
                if (n1.Text == "" && m1.Text == "" && min1.Text == "" && max1.Text == "")
                {
                    if (isSquare.Checked)
                    {
                        matrix1 = new SquareMatrix();
                    }
                    else
                    {
                        matrix1 = new Matrix();
                    }
                    firstMatrix.Text = matrix1.ToString();
                    return;
                }
                else if (min1.Text == "" && max1.Text == "")
                {
                    if (isSquare.Checked)
                    {
                        matrix1 = new SquareMatrix(int.Parse(n1.Text), int.Parse(m1.Text));
                    }
                    else
                    {
                        matrix1 = new Matrix(int.Parse(n1.Text), int.Parse(m1.Text));
                    }
                    firstMatrix.Text = matrix1.ToString();
                    return;
                }
                else if (n1.Text != "" && m1.Text != "" && min1.Text != "" && max1.Text != "")
                {
                    if (isSquare.Checked)
                    {
                        matrix1 = new SquareMatrix(int.Parse(n1.Text), int.Parse(m1.Text), int.Parse(min1.Text), int.Parse(max1.Text));
                    }
                    else
                    {
                        matrix1 = new Matrix(int.Parse(n1.Text), int.Parse(m1.Text), int.Parse(min1.Text), int.Parse(max1.Text));
                    }
                    firstMatrix.Text = matrix1.ToString();
                    return;
                }
                else
                {
                    throw new Exception("Такого конструктора нету.");
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void createMatrix2_Click(object sender, EventArgs e)
        {
            try
            {
                if (n2.Text == "" && m2.Text == "" && min2.Text == "" && max2.Text == "")
                {
                    if (isSquare.Checked)
                    {
                        matrix2 = new SquareMatrix();
                    }
                    else
                    {
                        matrix2 = new Matrix();
                    }
                    secondMatrix.Text = matrix2.ToString();
                    return;
                }
                else if (min2.Text == "" && max2.Text == "")
                {
                    if (isSquare.Checked)
                    {
                        matrix2 = new SquareMatrix(int.Parse(n2.Text), int.Parse(m2.Text));
                    }
                    else
                    {
                        matrix2 = new Matrix(int.Parse(n2.Text), int.Parse(m2.Text));
                    }
                    secondMatrix.Text = matrix2.ToString();
                    return;
                }
                else if (n2.Text != "" && m2.Text != "" && min2.Text != "" && max2.Text != "")
                {
                    if (isSquare.Checked)
                    {
                        matrix2 = new SquareMatrix(int.Parse(n2.Text), int.Parse(m2.Text), int.Parse(min2.Text), int.Parse(max2.Text));
                    }
                    else
                    {
                        matrix2 = new Matrix(int.Parse(n2.Text), int.Parse(m2.Text), int.Parse(min2.Text), int.Parse(max2.Text));
                    }
                    secondMatrix.Text = matrix2.ToString();
                    return;
                }
                else
                {
                    throw new Exception("Такого конструктора нету.");
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void addition_Click(object sender, EventArgs e)
        {
            try
            {
                result = matrix1.MatMul(matrix2).ToString();
                resultMatrix.Text = result.ToString();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void multiply_Click(object sender, EventArgs e)
        {
            try
            {
                result = matrix1.MatMul(matrix2);
                resultMatrix.Text = result.ToString();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void substraction_Click(object sender, EventArgs e)
        {
            try
            {
                result = matrix1.MatSub(matrix2);
                resultMatrix.Text = result.ToString();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void isSymmetric_Click(object sender, EventArgs e)
        {
            try
            {
                if (isFirst.Checked)
                {
                    MessageBox.Show(matrix1.IsSymmetric() ? "Матрица симметрична." : "Матрица не симметрична.");
                }
                else
                {
                    MessageBox.Show(matrix2.IsSymmetric() ? "Матрица симметрична." : "Матрица не симметрична.");
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void determinant_Click(object sender, EventArgs e)
        {
            try
            {
                if (isFirst.Checked)
                {
                    MessageBox.Show("Детерминант матрицы 1: " + matrix1.Determinant().ToString());
                }
                else
                {
                    MessageBox.Show("Детерминант матрицы 2: " + matrix2.Determinant().ToString());
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void solve_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show(isFirst.Checked ? string.Join("\n", matrix1.SolveEquations()) : string.Join("\n", matrix2.SolveEquations()));
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double[] coefsArr;
                if (isFirst.Checked)
                {
                    coefsArr = Array.ConvertAll(freeCoefs.Text.Split(","), s => double.Parse(s));
                    if (matrix1.N != coefsArr.Length)
                    {
                        MessageBox.Show("Количество коэффициентов должно быть равно количеству строк матрицы.");
                    }
                    matrix1.Coefs = coefsArr;
                }
                else
                {
                    coefsArr = Array.ConvertAll(freeCoefs.Text.Split(","), s => double.Parse(s));
                    if (matrix2.N != coefsArr.Length)
                    {
                        MessageBox.Show("Количество коэффициентов должно быть равно количеству строк матрицы.");
                    }
                    matrix2.Coefs = coefsArr;
                }
                currentCoefs.Text = "Текущие коэффициенты: " + string.Join(", ", coefsArr);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void inverse_Click(object sender, EventArgs e)
        {
            try
            {
                if (isFirst.Checked)
                {
                    result = matrix1.InvertMatrix();
                    resultMatrix.Text = result.ToString();
                }
                else
                {
                    result = matrix2.InvertMatrix();
                    resultMatrix.Text = result.ToString();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void transpose_Click(object sender, EventArgs e)
        {
            try
            {
                if (isFirst.Checked)
                {
                    result = matrix1.Transpose();
                    resultMatrix.Text = result.ToString();
                }
                else
                {
                    result = matrix2.Transpose();
                    resultMatrix.Text = result.ToString();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void genCoefs_Click(object sender, EventArgs e)
        {
            try
            {
                if (coefCount.Text.Length == 0)
                {
                    MessageBox.Show("Введите количество коэффициентов");
                }
                Random random = new Random();
                double[] arr = Enumerable.Range(1, int.Parse(coefCount.Text)).Select(i => i * random.NextDouble() * Math.PI).ToArray();
                if (isFirst.Checked)
                {
                    matrix1.Coefs = arr;
                    currentCoefs.Text = "Текущие коэффициенты матрицы 1: " + string.Join(", ", arr);
                }
                else
                {
                    matrix2.Coefs = arr;
                    currentCoefs.Text = "Текущие коэффициенты матрицы 2: " + string.Join(", ", arr);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void moveToFirst_Click(object sender, EventArgs e)
        {
            matrix1 = result;
            firstMatrix.Text = matrix1.ToString();
        }

        private void moveToSecond_Click(object sender, EventArgs e)
        {
            matrix2 = result;
            secondMatrix.Text = matrix2.ToString();
        }
    }
}