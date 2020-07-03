using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wk8_9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int s = Convert.ToInt32(numericUpDown1.Value);


                double[][] matrix = new double[s][];
                for (int i = 0; i < s; i++)
                {
                    matrix[i] = new double[s];
                }

                for (int i = 0; i < s; i++)
                {
                    for (int j = 0; j < s; j++)
                    {
                        matrix[i][j] = Convert.ToInt32(dataGridView1[j, i].Value);
                    }
                }

                double[] b = new double[s];
                //  double[] x = new double[s];
                for (int i = 0; i < s; i++)
                {
                    b[i] = Convert.ToDouble(dataGridView2[0, i].Value);

                }

                Urav u = new Urav(matrix, b, s);
                for (int i = 0; i < s; i++)
                {

                    dataGridView3[0, i].Value = u.x[i].ToString();

                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Введены некоректные данные");
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }
         
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount = 2;
            dataGridView1.RowCount = 2;
            dataGridView2.ColumnCount = 1;
            dataGridView2.RowCount = 2;
            dataGridView3.ColumnCount = 1;
            dataGridView3.RowCount = 2;

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount = Convert.ToInt32(numericUpDown1.Value);
            dataGridView1.RowCount = Convert.ToInt32(numericUpDown1.Value);
            dataGridView2.RowCount = Convert.ToInt32(numericUpDown1.Value);
            dataGridView3.RowCount = Convert.ToInt32(numericUpDown1.Value);


        }

        private void button2_Click(object sender, EventArgs e)
        {
          
            dataGridView3.ColumnCount = 1;
            dataGridView3.RowCount = 2;
           
            for (int i = 0; i < 2; i++)
            {
               
                dataGridView3[0, i].Value = "";
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount = 2;
            dataGridView1.RowCount = 2;
            dataGridView2.ColumnCount = 1;
            dataGridView2.RowCount = 2;
          
            numericUpDown1.Value = 2;
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    dataGridView1[i, j].Value = "";
                }
                dataGridView2[0, i].Value = "";
                
            }
        }
    }
}
