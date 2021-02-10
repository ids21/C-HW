using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassMatrix
{
    class Matrix
    {
        private int row;
        private int col;

      public double[,] M;

        public Matrix()
        {
            row = 1;
            col = 1;

            M = new double[row, col];
        }

        public Matrix(int row, int col)
        {
            this.row = row;
            this.col = col;

            M = new double[row, col];
        }

        public void SetData()
        {
            Random rand = new Random();
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    M[i, j] = Convert.ToDouble(rand.Next(0,15));
                }
            }
        }

        public void GetData()
        {
            Console.WriteLine("\nMatrix\n");
            int rows = Rows;
            int cols = Cols;
            for (int i = 0; i < rows; i++)
            {
                Console.Write("\t\t");

                for (int j = 0; j < cols; j++)
                {
                    Console.Write(M[i, j] + "\t\t");
                }

                Console.WriteLine("\n\n");
            }
        }

        public static Matrix operator +(Matrix a, Matrix b)
        {
            if (a.row == b.row && a.col == b.col)
            {
                Matrix c = new Matrix(a.row, a.col);

                for (int i = 0; i < c.row; i++)
                {
                    for (int j = 0; j < c.col; j++)
                    {
                        c.M[i, j] = a.M[i, j] + b.M[i, j];
                    }
                }

                return c;
            }

            else
            {
                Console.WriteLine("\n\nErrorException\n\n");
                Console.WriteLine("При сложение двух матриц строки и колонки обоих должны быть равны");
                Console.WriteLine("Из-за ошибки будет возвращена единичная матрица со значением 1");

                Matrix c = new Matrix();
                c.M[0, 0] = 1;

                return c;
            }

        }

        public static Matrix operator -(Matrix a, Matrix b)
        {
            if (a.row == b.row && a.col == b.col)
            {
                Matrix c = new Matrix(a.row, a.col);

                for (int i = 0; i < c.row; i++)
                {
                    for (int j = 0; j < c.col; j++)
                    {
                        c.M[i, j] = a.M[i, j] - b.M[i, j];
                    }
                }

                return c;
            }

            else
            {
                Console.WriteLine("\n\nErrorException\n\n");
                Console.WriteLine("При вычитании двух матриц строки и колонки обоих должны быть равны");
                Console.WriteLine("Из-за ошибки будет возвращена единичная матрица со значением 1");

                Matrix c = new Matrix();
                c.M[0, 0] = 1;

                return c;
            }
        }

        public static Matrix operator *(int value, Matrix a)
        {
            Matrix c = new Matrix(a.row, a.col);

            for (int i = 0; i < c.row; i++)
            {
                for (int j = 0; j < c.col; j++)
                {
                    c.M[i, j] = value * a.M[i, j];
                }
            }

            return c;
        }

        public static Matrix operator *(Matrix a, int value)
        {
            Matrix c = new Matrix(a.row, a.col);

            for (int i = 0; i < c.row; i++)
            {
                for (int j = 0; j < c.col; j++)
                {
                    c.M[i, j] = value * a.M[i, j];
                }
            }

            return c;
        }
        public static Matrix Transpose(Matrix m1)
        {
            Matrix temp = new Matrix(m1.col,m1.row);
            for (int i = 0; i < m1.row; i++)
                for (int j = 0; j < m1.col; j++)
                {
                    temp.M[j, i] = m1.M[i, j];
                }
            return temp;
        }

        public static Matrix operator *(Matrix a, Matrix b)
        {
            if (a.col == b.row)
            {

                Matrix c = new Matrix(a.row, b.col);

                double sum = 0;

                for (int i = 0; i < a.row; i++)
                {
                    for (int j = 0; j < b.col; j++)
                    {
                        sum = 0;

                        for (int k = 0; k < a.col; k++)
                        {
                            sum += a.M[i, k] * b.M[k, j];
                        }

                        c.M[i, j] = sum;
                    }
                }

                return c;
            }

            else

            {
                Console.WriteLine("\n\nErrorException\n\n");
                Console.WriteLine("Две матрицы можно перемножить если количество столбцов первой матрицы равно количеству строк второй матрицы");
                Console.WriteLine("Из-за ошибки будет возвращена единичная матрица со значением 1");

                Matrix c = new Matrix();
                c.M[0, 0] = 1;

                return c;
            }
        }
        public int Rows
        {
            get { return M.GetLength(0); }
        }
        public int Cols
        {
            get { return M.GetLength(1); }
        }
        public double this[int i, int j]
        {
            get
            {
                int rows = Rows, cols = Cols;
                if (i < 0 || i >= rows || j < 0 || j >= cols)
                    throw new Exception("Индексы выходят иp диапазона");
            return M[i, j];
            }
            set
            {
                int rows = Rows, cols = Cols;
                if (i < 0 || i >= rows || j < 0 || j >= cols)
                    throw new Exception("Индексы выходяn из диапазона");
                     M[i, j] = value;
            }
        }
        public SquareMatrix ToSquareMatrix()
        {
            int rows = Math.Min(Rows,Cols);
            SquareMatrix temp = new SquareMatrix(rows);
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < rows; j++)
                    temp[i, j] = M[i, j];
            return temp;
        }


    }
    class SquareMatrix : Matrix
    {
        public SquareMatrix(int rows) : base(rows, rows)
        {
        }
        public int CompareTo(SquareMatrix a,SquareMatrix b)
        {
            if (a.Opredelitel() > b.Opredelitel())
                return 1;
            else if (a.Opredelitel() > b.Opredelitel())
                return 2;
            else return 0;
        }
      

        SquareMatrix Minor(int i1, int j1)
        {
            int rows = Rows;
            SquareMatrix temp = new SquareMatrix(rows - 1);
            for (int i = 0; i < i1; i++)
            {
                for (int j = 0; j < j1; j++)
                    temp[i, j] = M[i, j];
                for (int j = j1 + 1; j < rows; j++)
                    temp[i, j - 1] = M[i, j];
            }
            for (int i = i1 + 1; i < rows; i++)
            {
                for (int j = 0; j < j1; j++)
                    temp[i - 1, j] = M[i, j];
                for (int j = j1 + 1; j < rows; j++)
                    temp[i - 1, j - 1] = M[i, j];
            }
            return temp;
        }
        public double Opredelitel()
        {
            double det = 0;
            int rows = Rows;
            if (rows == 1)
                return M[0, 0];
            SquareMatrix temp = new SquareMatrix(rows - 1);
            for (int j = 0; j < rows; j++)
            {
                temp = Minor(0, j);
                if (j % 2 == 0)
                    det += temp.Opredelitel() * M[0, j];
                else
                    det -= temp.Opredelitel() * M[0, j];
            }
            return det;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {

            for (; ; )
            {
                try
                {

                    int rowA, colA;
                    int rowB, colB;

                    Console.Write("Enter number rows first matrix: ");
                    rowA = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter number cols first matrix: ");
                    colA = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine();

                    Console.Write("Enter number rows second matrix: ");
                    rowB = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter number cols second matrix: ");
                    colB = Convert.ToInt32(Console.ReadLine());

                    Matrix A = new Matrix(rowA, colA);
                    Matrix B = new Matrix(rowB, colB);
                    Matrix C = new Matrix();

                    A.SetData();
                    A.GetData();

                    Console.WriteLine("\n\n");

                    B.SetData();
                    B.GetData();

                    C = A * B;

                    C.GetData();
                    Matrix D = Matrix.Transpose(B);
                    D.GetData();
                    Console.WriteLine("squuuaare");
                    SquareMatrix sqMatr = new SquareMatrix(3);
                    sqMatr=A.ToSquareMatrix();
                    sqMatr.GetData();
                    SquareMatrix sqMatr1 = new SquareMatrix(3);
                    Console.WriteLine("squuuaare");
                    sqMatr1=B.ToSquareMatrix();
                    sqMatr1.GetData();
                    
                    if (sqMatr.CompareTo(sqMatr, sqMatr1) == 1)
                        Console.WriteLine("ОПределитель 1 больше");
                    if (sqMatr.CompareTo(sqMatr, sqMatr1) == 2)
                        Console.WriteLine("ОПределитель 2 больше");
                    if (sqMatr.CompareTo(sqMatr, sqMatr1) == 0)
                        Console.WriteLine("ОПределители равны");
                    


                    break;
                }

                catch (FormatException)
                {
                    Console.WriteLine("\n\n!!! FormatException !!!\n\n");
                }

                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("\n\n!!! IndexOutOfRangeException !!!\n\n");
                }
            }

            Console.ReadLine();
        }
    }
}