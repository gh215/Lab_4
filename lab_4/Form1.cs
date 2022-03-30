using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab_4
{
    public partial class Form1 : Form
    { 
        Random rnd = new Random();
    
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.RowCount = 1;
            dataGridView1.ColumnCount = Convert.ToInt32(numericUpDown1.Value);

            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                dataGridView1.Rows[0].Cells[i].Value = 0;
            }
        }

        /// <summary>
        /// Метод для вычисления у по заданной формуле.
        /// </summary>
        /// <param name="array">double[] array исходный массив.</param>
        /// <returns>Для заданных значений вычислить значение величины Y по формуле:
        ///  Y = Xn* (Xn  + Xn-1) * (Xn  + Xn-1 + Xn-2) * … * (Xn  + Xn-1 + + Xn-2 … + X1 ).</returns>
        public double searchY(double[] array)
        {
            // создала новый массив, переменную для подсчета суммы и искомый Y
            double[] newArray = new double[array.Length];
            double sum = 0;
            double y = 1;


            // берем последнее число к нем прибавляем сумму последних двух чисел, потом к этому сумму трех и так далее из формулы
            // каждую новую сумму записываем в новый массив, каждую под своим индексом
            // Y = Xn * (Xn + Xn-1) * (Xn + Xn-1 + Xn-2) * … * (Xn + Xn-1 + + Xn-2 … + X1 )
            for (int i = array.Length - 1; i >= 0; i--)
            {
                sum = sum + array[i];
                newArray[i] = sum;
            }

            // перемножаем элементы нового массива как по формуле и получаем искомый Y
            for (int i = 0; i < newArray.Length; i++)
            {
                y = y * newArray[i];
            }

            // возращем искомый Y
            return y;
        }

        // Переключатель определяющий размер формулы
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            dataGridView1.RowCount = 1;
            dataGridView1.ColumnCount = Convert.ToInt32(numericUpDown1.Value);

            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                if (radioButton1.Checked)
                {
                    dataGridView1.Rows[0].Cells[i].Value = 0;
                }
                else
                {
                    dataGridView1.Rows[0].Cells[i].Value = (rnd.NextDouble() * 100 - 50).ToString("F1");
                }
            }
        }

        // Чекбокс позволяющий выбрать какими числами будет заполнена формула.
        // Вручную или автоматически - числа будут подобраны рандомно в зданном диапазоне
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.RowCount = 1;
            dataGridView1.ColumnCount = Convert.ToInt32(numericUpDown1.Value);

            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                if (radioButton1.Checked)
                {
                    dataGridView1.Rows[0].Cells[i].Value = 0;
                }
                else
                {
                    dataGridView1.Rows[0].Cells[i].Value = (rnd.NextDouble()*100 - 50).ToString("F1");
                }
            }
        }

        // Кнопка Рассчитать У по формуле
        private void button1_Click(object sender, EventArgs e)
        {
            // Создала массив, в котором будут лежать заданные значения Х
            double[] arr = new double[Convert.ToInt32(numericUpDown1.Value)];
           
            dataGridView1.RowCount = 1;
            dataGridView1.ColumnCount = Convert.ToInt32(numericUpDown1.Value);

            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                arr[i] = Convert.ToDouble(dataGridView1.Rows[0].Cells[i].Value);
            }
            double myY = searchY(arr);
            label3.Text = myY.ToString("F3");

        }
    }
}
