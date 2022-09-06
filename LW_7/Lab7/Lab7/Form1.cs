using System;
using System.Windows.Forms;

namespace Lab7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Random r = new Random();

        bool multipleNumbers = false;

        string maxElNumbers;

        double srZnach, sum, razn;

        // Количество элементов массива
        int n = 10, kolvoEl;

        private void Form1_Load(object sender, EventArgs e)
        {
            // Запрет на изменени размера окна формы
            FormBorderStyle = FormBorderStyle.FixedSingle;

            n = Convert.ToInt32(numericUpDown1.Value);

            // Количество столбиков
            dataGridView1.ColumnCount = n;
            // Количество строчек
            dataGridView1.RowCount = 1;

            // Заполнение таблицы при загрузке формы
            for (int i = 0; i < n; i++)
            {
                dataGridView1.Columns[i].Name = i.ToString();
                // Заполнение таблицы случайными числами
                dataGridView1.Rows[0].Cells[i].Value = Convert.ToDouble(r.Next(-100, 100)/10.0);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                dataGridView1.ReadOnly = false;

                for (int i = 0; i < n; i++)
                {
                    dataGridView1.Rows[0].Cells[i].Value = i.ToString();
                }
            }
            else
            {
                dataGridView1.ReadOnly = true;

                for (int i = 0; i < n; i++)
                {
                    dataGridView1.Columns[i].Name = i.ToString();
                    // Заполнение таблицы случайными числами
                    dataGridView1.Rows[0].Cells[i].Value = Convert.ToDouble(r.Next(-100, 100) / 10.0);
                }
            }
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress += new KeyPressEventHandler(dataGridView1_KeyPress);
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Задание допустимых символов ввода
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9')) return;
            if (e.KeyChar == '.') e.KeyChar = ',';
            if (e.KeyChar == ',') return;
            if (e.KeyChar == '-')
            {
                if (((TextBox)sender).Text.IndexOf('-') != -1)
                {
                    e.Handled = true;
                }
                return;
            }
            
            if (e.KeyChar == (char)Keys.Back) return;
            e.KeyChar = '\0';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            multipleNumbers = false;
            maxElNumbers = "";
            srZnach = sum = 0;
            // выделение памяти под динамический массив
            double[] array = new double[n];

            for (int i = 0; i < n; i++)
            {
                // значения из таблицы помещаем в массив
                array[i] = Convert.ToDouble(dataGridView1.Rows[0].Cells[i].Value);

                // Нахождение среднего арифметического
                sum += array[i];
            }

            srZnach = sum / n;

            razn = Math.Abs(srZnach)-Math.Abs(array[0]);

            SearchNumber(array);

            label2.Text = "Среднее арифметическое значение: " + srZnach + "\nИндекс числа, максимально близкого к среднему арифметическому: " + maxElNumbers;

            if (!multipleNumbers)
            {
                label2.Text = "Среднее арифметическое значение: " + srZnach + "\nИндекс числа, максимально близкого к среднему арифметическому: " + maxElNumbers;
            }
            else
            {
                label2.Text = "Среднее арифметическое значение: " + srZnach + "\nИндексы числел, максимально близких к среднему арифметическому: " + maxElNumbers;
            }            
        }

        private string SearchNumber(double[] array)
        {
            for (int i = 0; i < n; i++)
            {
                if(Math.Abs(razn) >= Math.Abs(Math.Abs(array[i]) - Math.Abs(srZnach)))
                {
                    razn = Math.Abs(srZnach) - Math.Abs(array[i]);
                    kolvoEl = array[i].ToString().Length;
                }
            }

            for (int i = 0; i < n; i++)
            {
                if (Math.Abs(razn) == Math.Abs(Math.Abs(array[i]) - Math.Abs(srZnach)))
                {
                    maxElNumbers += i.ToString() + " ";
                }
            }

            if(maxElNumbers.Length > (kolvoEl+1)) multipleNumbers = true;

            return maxElNumbers;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            n = Convert.ToInt32(numericUpDown1.Value);

            dataGridView1.ColumnCount = n;

            if (radioButton1.Checked)
            {
                for (int i = 0; i < n; i++)
                {
                    dataGridView1.Columns[i].Name = i.ToString();
                    if (dataGridView1.Rows[0].Cells[i].Value == null)
                    {
                        dataGridView1.Rows[0].Cells[i].Value = i.ToString();
                    }
                }
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    dataGridView1.Columns[i].Name = i.ToString();
                    // Заполнение таблицы случайными числами
                    dataGridView1.Rows[0].Cells[i].Value = Convert.ToDouble(r.Next(-100, 100) / 10.0);
                }
            }
        }
    }
}
