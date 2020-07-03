using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;


namespace wk8_9
{
    class Urav
    {
        public double[][] matr;
        public double[] m;
        public int s;
        public double[] x;
        public double del;

        public Urav(double[][] matr1, double[] m1, int s1)
        {
            try
            {
                s = s1;
                matr = new double[s][];
                for (int i = 0; i < s; i++)
                {
                    matr[i] = new double[s];
                }
                m = new double[s];

                for (int i = 0; i < s; i++)
                {
                    for (int j = 0; j < s; j++)
                    {
                        matr[i][j] = matr1[i][j];
                    }
                    m[i] = m1[i];
                }
                x = new double[s];

                del = Opredel(matr, s);



                for (int i = 0; i < s; i++)
                {
                    double[][] matrix2 = new double[s][];
                    for (int i2 = 0; i2 < s; i2++)
                    {
                        matrix2[i2] = new double[s];
                    }

                    for (int i3 = 0; i3 < s; i3++)
                    {
                        for (int j3 = 0; j3 < s; j3++)
                        {
                            matrix2[i3][j3] = matr[i3][j3];
                        }
                    }
                    for (int i4 = 0; i4 < s; i4++)
                    {
                        matrix2[i4][i] = m[i4];

                    }

                    x[i] = Opredel(matrix2, s);
                    if (del == 0)
                        throw new Exception("Ошибка деления на ноль");
                    else
                    x[i] = x[i] / del;


                }
            }
            catch(Exception E)
            {
                MessageBox.Show(E.Message);
            }
        }

        void DeletesString(double[][] matrix, int size, int row, int col, double[][] newMatrix)
        {
            int offsetRow = 0;
            int offsetCol = 0; 
            for (int i = 0; i < size - 1; i++)
            {
                if (i == row)
                {
                    offsetRow = 1;
                }

                offsetCol = 0; 
                for (int j = 0; j < size - 1; j++)
                {
                    if (j == col)
                    {
                        offsetCol = 1; 
                    }

                    newMatrix[i][j] = matrix[i + offsetRow][j + offsetCol];
                }
            }
        }

        //Вычисление определителя матрицы
        double Opredel(double[][] matrix, int size)
        {
            double det = 0;
            double degree = 1; 
            if (size == 1)
            {
                return matrix[0][0];
            }
            else if (size == 2)
            {
                return matrix[0][0] * matrix[1][1] - matrix[0][1] * matrix[1][0];
            }
            else
            {
                double[][] newMatrix = new double[size - 1][];
                for (int i = 0; i < size - 1; i++)
                {
                    newMatrix[i] = new double[size - 1];
                }
                
                for (int j = 0; j < size; j++)
                {
                    DeletesString(matrix, size, 0, j, newMatrix);
                    det = det + (degree * matrix[0][j] * Opredel(newMatrix, size - 1));
                    degree = -degree;
                }
            }

            return det;
        }
    }
}
