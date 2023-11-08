namespace MatrixForm
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            firstMatrix = new RichTextBox();
            addition = new Button();
            isSquare = new CheckBox();
            substraction = new Button();
            multiply = new Button();
            secondMatrix = new RichTextBox();
            isSymmetric = new Button();
            determinant = new Button();
            solve = new Button();
            resultMatrix = new RichTextBox();
            freeCoefs = new TextBox();
            label1 = new Label();
            createMatrix1 = new Button();
            n1 = new TextBox();
            label2 = new Label();
            label3 = new Label();
            m1 = new TextBox();
            label4 = new Label();
            min1 = new TextBox();
            label5 = new Label();
            max1 = new TextBox();
            label6 = new Label();
            max2 = new TextBox();
            label7 = new Label();
            min2 = new TextBox();
            label8 = new Label();
            m2 = new TextBox();
            label9 = new Label();
            n2 = new TextBox();
            createMatrix2 = new Button();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            inverse = new Button();
            isFirst = new RadioButton();
            isSecond = new RadioButton();
            label13 = new Label();
            thirdMatrix = new RichTextBox();
            label14 = new Label();
            label15 = new Label();
            groupBox1 = new GroupBox();
            parseMatrix = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // firstMatrix
            // 
            firstMatrix.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            firstMatrix.Location = new Point(41, 53);
            firstMatrix.Name = "firstMatrix";
            firstMatrix.Size = new Size(460, 366);
            firstMatrix.TabIndex = 0;
            firstMatrix.Text = "";
            // 
            // addition
            // 
            addition.FlatStyle = FlatStyle.Popup;
            addition.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            addition.Location = new Point(525, 123);
            addition.Name = "addition";
            addition.Size = new Size(57, 51);
            addition.TabIndex = 1;
            addition.Text = "+";
            addition.UseVisualStyleBackColor = true;
            addition.Click += addition_Click;
            // 
            // isSquare
            // 
            isSquare.AutoSize = true;
            isSquare.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            isSquare.Location = new Point(1499, 145);
            isSquare.Name = "isSquare";
            isSquare.Size = new Size(239, 34);
            isSquare.TabIndex = 2;
            isSquare.Text = "Квадратная матрица";
            isSquare.UseVisualStyleBackColor = true;
            // 
            // substraction
            // 
            substraction.FlatStyle = FlatStyle.Popup;
            substraction.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            substraction.Location = new Point(525, 263);
            substraction.Name = "substraction";
            substraction.Size = new Size(57, 51);
            substraction.TabIndex = 3;
            substraction.Text = "-";
            substraction.UseVisualStyleBackColor = true;
            substraction.Click += substraction_Click;
            // 
            // multiply
            // 
            multiply.FlatStyle = FlatStyle.Popup;
            multiply.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            multiply.Location = new Point(525, 195);
            multiply.Name = "multiply";
            multiply.Size = new Size(57, 51);
            multiply.TabIndex = 4;
            multiply.Text = "*";
            multiply.UseVisualStyleBackColor = true;
            multiply.Click += multiply_Click;
            // 
            // secondMatrix
            // 
            secondMatrix.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            secondMatrix.Location = new Point(612, 53);
            secondMatrix.Name = "secondMatrix";
            secondMatrix.Size = new Size(448, 366);
            secondMatrix.TabIndex = 5;
            secondMatrix.Text = " ";
            // 
            // isSymmetric
            // 
            isSymmetric.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            isSymmetric.Location = new Point(1264, 753);
            isSymmetric.Name = "isSymmetric";
            isSymmetric.Size = new Size(464, 51);
            isSymmetric.TabIndex = 6;
            isSymmetric.Text = "Проверка на симметричность";
            isSymmetric.UseVisualStyleBackColor = true;
            isSymmetric.Click += isSymmetric_Click;
            // 
            // determinant
            // 
            determinant.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            determinant.Location = new Point(1264, 810);
            determinant.Name = "determinant";
            determinant.Size = new Size(196, 51);
            determinant.TabIndex = 7;
            determinant.Text = "Детерминант";
            determinant.UseVisualStyleBackColor = true;
            determinant.Click += determinant_Click;
            // 
            // solve
            // 
            solve.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            solve.Location = new Point(1532, 810);
            solve.Name = "solve";
            solve.Size = new Size(196, 51);
            solve.TabIndex = 8;
            solve.Text = "Решение СЛАУ";
            solve.UseVisualStyleBackColor = true;
            // 
            // resultMatrix
            // 
            resultMatrix.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            resultMatrix.Location = new Point(41, 624);
            resultMatrix.Name = "resultMatrix";
            resultMatrix.Size = new Size(1019, 388);
            resultMatrix.TabIndex = 9;
            resultMatrix.Text = " ";
            // 
            // freeCoefs
            // 
            freeCoefs.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            freeCoefs.Location = new Point(1251, 950);
            freeCoefs.Name = "freeCoefs";
            freeCoefs.Size = new Size(477, 32);
            freeCoefs.TabIndex = 10;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(1251, 912);
            label1.Name = "label1";
            label1.Size = new Size(453, 25);
            label1.TabIndex = 11;
            label1.Text = "Введите свободные коэффициенты через запятую:";
            // 
            // createMatrix1
            // 
            createMatrix1.BackColor = SystemColors.MenuHighlight;
            createMatrix1.FlatStyle = FlatStyle.Popup;
            createMatrix1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            createMatrix1.ForeColor = SystemColors.Window;
            createMatrix1.Location = new Point(141, 494);
            createMatrix1.Name = "createMatrix1";
            createMatrix1.Size = new Size(254, 51);
            createMatrix1.TabIndex = 12;
            createMatrix1.Text = "Создать матрицу";
            createMatrix1.UseVisualStyleBackColor = false;
            createMatrix1.Click += createMatrix1_Click;
            // 
            // n1
            // 
            n1.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            n1.Location = new Point(77, 456);
            n1.Name = "n1";
            n1.Size = new Size(86, 32);
            n1.TabIndex = 14;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(77, 428);
            label2.Name = "label2";
            label2.Size = new Size(26, 25);
            label2.TabIndex = 15;
            label2.Text = "N";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(179, 428);
            label3.Name = "label3";
            label3.Size = new Size(29, 25);
            label3.TabIndex = 17;
            label3.Text = "M";
            // 
            // m1
            // 
            m1.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            m1.Location = new Point(179, 456);
            m1.Name = "m1";
            m1.Size = new Size(86, 32);
            m1.TabIndex = 16;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(281, 428);
            label4.Name = "label4";
            label4.Size = new Size(48, 25);
            label4.TabIndex = 19;
            label4.Text = "MIN";
            // 
            // min1
            // 
            min1.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            min1.Location = new Point(281, 456);
            min1.Name = "min1";
            min1.Size = new Size(86, 32);
            min1.TabIndex = 18;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(383, 428);
            label5.Name = "label5";
            label5.Size = new Size(52, 25);
            label5.TabIndex = 21;
            label5.Text = "MAX";
            // 
            // max1
            // 
            max1.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            max1.Location = new Point(383, 456);
            max1.Name = "max1";
            max1.Size = new Size(86, 32);
            max1.TabIndex = 20;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(958, 428);
            label6.Name = "label6";
            label6.Size = new Size(52, 25);
            label6.TabIndex = 30;
            label6.Text = "MAX";
            // 
            // max2
            // 
            max2.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            max2.Location = new Point(958, 456);
            max2.Name = "max2";
            max2.Size = new Size(86, 32);
            max2.TabIndex = 29;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(856, 428);
            label7.Name = "label7";
            label7.Size = new Size(48, 25);
            label7.TabIndex = 28;
            label7.Text = "MIN";
            // 
            // min2
            // 
            min2.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            min2.Location = new Point(856, 456);
            min2.Name = "min2";
            min2.Size = new Size(86, 32);
            min2.TabIndex = 27;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(754, 428);
            label8.Name = "label8";
            label8.Size = new Size(29, 25);
            label8.TabIndex = 26;
            label8.Text = "M";
            // 
            // m2
            // 
            m2.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            m2.Location = new Point(754, 456);
            m2.Name = "m2";
            m2.Size = new Size(86, 32);
            m2.TabIndex = 25;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(652, 428);
            label9.Name = "label9";
            label9.Size = new Size(26, 25);
            label9.TabIndex = 24;
            label9.Text = "N";
            // 
            // n2
            // 
            n2.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            n2.Location = new Point(652, 456);
            n2.Name = "n2";
            n2.Size = new Size(86, 32);
            n2.TabIndex = 23;
            // 
            // createMatrix2
            // 
            createMatrix2.BackColor = SystemColors.MenuHighlight;
            createMatrix2.FlatStyle = FlatStyle.Popup;
            createMatrix2.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            createMatrix2.ForeColor = SystemColors.Window;
            createMatrix2.Location = new Point(716, 494);
            createMatrix2.Name = "createMatrix2";
            createMatrix2.Size = new Size(254, 51);
            createMatrix2.TabIndex = 22;
            createMatrix2.Text = "Создать матрицу";
            createMatrix2.UseVisualStyleBackColor = false;
            createMatrix2.Click += createMatrix2_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label10.Location = new Point(203, 25);
            label10.Name = "label10";
            label10.Size = new Size(105, 25);
            label10.TabIndex = 31;
            label10.Text = "Матрица 1";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label11.Location = new Point(790, 25);
            label11.Name = "label11";
            label11.Size = new Size(105, 25);
            label11.TabIndex = 32;
            label11.Text = "Матрица 2";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label12.Location = new Point(452, 586);
            label12.Name = "label12";
            label12.Size = new Size(239, 25);
            label12.TabIndex = 33;
            label12.Text = "Результирующая матрица";
            // 
            // inverse
            // 
            inverse.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            inverse.Location = new Point(1264, 696);
            inverse.Name = "inverse";
            inverse.Size = new Size(464, 51);
            inverse.TabIndex = 34;
            inverse.Text = "Обратная матрица";
            inverse.UseVisualStyleBackColor = true;
            // 
            // isFirst
            // 
            isFirst.AutoSize = true;
            isFirst.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            isFirst.Location = new Point(1246, 123);
            isFirst.Name = "isFirst";
            isFirst.Size = new Size(197, 34);
            isFirst.TabIndex = 35;
            isFirst.TabStop = true;
            isFirst.Text = "Первая матрица";
            isFirst.UseVisualStyleBackColor = true;
            // 
            // isSecond
            // 
            isSecond.AutoSize = true;
            isSecond.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            isSecond.Location = new Point(1246, 163);
            isSecond.Name = "isSecond";
            isSecond.Size = new Size(192, 34);
            isSecond.TabIndex = 36;
            isSecond.TabStop = true;
            isSecond.Text = "Вторая матрица";
            isSecond.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI Semibold", 22F, FontStyle.Bold, GraphicsUnit.Point);
            label13.Location = new Point(1296, 48);
            label13.Name = "label13";
            label13.Size = new Size(393, 41);
            label13.TabIndex = 37;
            label13.Text = "Операции над матрицами";
            // 
            // thirdMatrix
            // 
            thirdMatrix.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            thirdMatrix.Location = new Point(317, 47);
            thirdMatrix.Name = "thirdMatrix";
            thirdMatrix.Size = new Size(376, 326);
            thirdMatrix.TabIndex = 38;
            thirdMatrix.Text = "";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label14.Location = new Point(40, 92);
            label14.Name = "label14";
            label14.Size = new Size(225, 25);
            label14.TabIndex = 39;
            label14.Text = "Введите матрицу в виде:";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label15.Location = new Point(85, 154);
            label15.Name = "label15";
            label15.Size = new Size(127, 128);
            label15.TabIndex = 40;
            label15.Text = "0 1 2 3 4 5\r\n0 1 2 3 4 5\r\n0 1 2 3 4 5\r\n0 1 2 3 4 5\r\n";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(parseMatrix);
            groupBox1.Controls.Add(label14);
            groupBox1.Controls.Add(thirdMatrix);
            groupBox1.Controls.Add(label15);
            groupBox1.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox1.Location = new Point(1125, 224);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(727, 405);
            groupBox1.TabIndex = 41;
            groupBox1.TabStop = false;
            groupBox1.Text = "Парсинг матрицы";
            // 
            // parseMatrix
            // 
            parseMatrix.BackColor = SystemColors.MenuHighlight;
            parseMatrix.FlatStyle = FlatStyle.Popup;
            parseMatrix.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            parseMatrix.ForeColor = SystemColors.Window;
            parseMatrix.Location = new Point(50, 307);
            parseMatrix.Name = "parseMatrix";
            parseMatrix.Size = new Size(205, 51);
            parseMatrix.TabIndex = 42;
            parseMatrix.Text = "Создать";
            parseMatrix.UseVisualStyleBackColor = false;
            parseMatrix.Click += parseMatrix_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1904, 1041);
            Controls.Add(groupBox1);
            Controls.Add(label13);
            Controls.Add(isSecond);
            Controls.Add(isFirst);
            Controls.Add(inverse);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label6);
            Controls.Add(max2);
            Controls.Add(label7);
            Controls.Add(min2);
            Controls.Add(label8);
            Controls.Add(m2);
            Controls.Add(label9);
            Controls.Add(n2);
            Controls.Add(createMatrix2);
            Controls.Add(label5);
            Controls.Add(max1);
            Controls.Add(label4);
            Controls.Add(min1);
            Controls.Add(label3);
            Controls.Add(m1);
            Controls.Add(label2);
            Controls.Add(n1);
            Controls.Add(createMatrix1);
            Controls.Add(label1);
            Controls.Add(freeCoefs);
            Controls.Add(resultMatrix);
            Controls.Add(solve);
            Controls.Add(determinant);
            Controls.Add(isSymmetric);
            Controls.Add(secondMatrix);
            Controls.Add(multiply);
            Controls.Add(substraction);
            Controls.Add(isSquare);
            Controls.Add(addition);
            Controls.Add(firstMatrix);
            Name = "Form1";
            Text = "Проект - Матрицы";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox firstMatrix;
        private Button addition;
        private CheckBox isSquare;
        private Button substraction;
        private Button multiply;
        private RichTextBox secondMatrix;
        private Button isSymmetric;
        private Button determinant;
        private Button solve;
        private RichTextBox resultMatrix;
        private TextBox freeCoefs;
        private Label label1;
        private Button createMatrix1;
        private TextBox n1;
        private Label label2;
        private Label label3;
        private TextBox m1;
        private Label label4;
        private TextBox min1;
        private Label label5;
        private TextBox max1;
        private Label label6;
        private TextBox max2;
        private Label label7;
        private TextBox min2;
        private Label label8;
        private TextBox m2;
        private Label label9;
        private TextBox n2;
        private Button createMatrix2;
        private Label label10;
        private Label label11;
        private Label label12;
        private Button inverse;
        private RadioButton isFirst;
        private RadioButton isSecond;
        private Label label13;
        private RichTextBox thirdMatrix;
        private Label label14;
        private Label label15;
        private GroupBox groupBox1;
        private Button parseMatrix;
    }
}