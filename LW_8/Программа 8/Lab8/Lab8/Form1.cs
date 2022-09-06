using System;
using System.Windows.Forms;
using System.Text;
using System.IO;
using System.Data;
using System.Text.RegularExpressions;

namespace Lab8
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Метод инициализирует форму.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        // Размерность матрицы
        int n = 2;

        // Номер строки с минимальным элементом
        int minElementRowIndex;

        // Номер столбца с максимальным элементом
        int maxElementColumnIndex;

        // Скалярное произведение
        double scalarProizv;

        Random r = new Random();

        /// <summary>
        /// Метод срабатывает при нажатии на кнопку. Производит заполнение массива данными из таблицы, вызывает функцию searchScalarProizv и выводит на экран скалярное произведение.
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            // Выделение памяти под динамический двумерный массив
            double[,] array = new double[n, n];

            label2.Text = "";

            // Заполняю массив данными из таблицы
            for (int j = 0; j < n; j++)
            {
                for (int i = 0; i < n; i++)
                {
                    array[i, j] = Convert.ToInt32(dataGridView1.Rows[i].Cells[j].Value);
                    dataGridView1.Rows[i].Cells[j].Value = array[i, j];
                }
            }

            searchScalarProizv(array, n);

            label2.Text = "Скалярное произведение строки " + (minElementRowIndex + 1) + "\nна столбец "+ (maxElementColumnIndex +1) + "\nравно " + scalarProizv;
        }

        /// <summary>
        /// Функция находит строку с минимальным элементом, столбце с максимальным элементом и вычисляет их скалярное произведение.
        /// </summary>
        /// <param name="array">Исходный, двумерный массив.</param>
        /// <param name="n">Размерность матрицы.</param> 
        /// <returns>Возвращает переменную вещественного типа, содержащюю скалярное произведение матрицы-строки на матрицу-столбец.</returns>
        public double searchScalarProizv(double[,] array, int n)
        {
            // Минимальный элемент строки
            double minElementRow;

            // Максимальный элемент столбца
            double maxElementColumn;

            minElementRow = array[0, 0];
            minElementRowIndex = 0;

            maxElementColumn = array[0, 0];
            maxElementColumnIndex = 0;

            scalarProizv = 0;

            for (int j = 0; j < n; j++)
            {
                for (int i = 0; i < n; i++)
                {
                    // Определяю номер строки с наименьшим элементом
                    if (array[i, j] <= minElementRow)
                    {
                        minElementRow = array[i, j];
                        minElementRowIndex = i;
                    }

                    // Определяю номер столбца с наибольшим элементом
                    if (array[j, i] >= maxElementColumn)
                    {
                        maxElementColumn = array[j, i];
                        maxElementColumnIndex = i;
                    }
                }
            }

            // Вычисление скалярно произведения
            for (int j = 0; j < n; j++)
            {
                scalarProizv += array[minElementRowIndex, j] * array[j, maxElementColumnIndex];
            }

            return scalarProizv;
        }

        /// <summary>
        /// Метод срабатывает при изменении числового значения компонента numericUpDown1.
        /// </summary>
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            n = Convert.ToInt32(numericUpDown1.Value);

            dataGridView1.DataSource = null;

            dataGridView1.RowCount = n;
            dataGridView1.ColumnCount = n;

            if (radioButton1.Checked)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int i = 0; i < n; i++)
                    {
                        if (dataGridView1.Rows[j].Cells[i].Value == null)
                        {
                            // Заполнение таблицы
                            dataGridView1.Rows[j].Cells[i].Value = 0.ToString();
                        }
                    }
                }
            }
            else if (radioButton2.Checked)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int i = 0; i < n; i++)
                    {
                        // Заполняет таблицу случайными целыми числами в указанном диапозоне 
                        dataGridView1.Rows[j].Cells[i].Value = r.Next(-99, 99);
                    }
                }
            }
            else
            {               
                for (int j = 0; j < n; j++)
                {
                    for (int i = 0; i < n; i++)
                    {
                        if (dataGridView1.Rows[j].Cells[i].Value == null)
                        {
                            // Заполнение таблицы
                            dataGridView1.Rows[j].Cells[i].Value = 0.ToString();
                        }
                    }
                }
            }
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress += new KeyPressEventHandler(dataGridView1_KeyPress);
        }

        private void numericUpDown1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9')) return;
            if (e.KeyChar == (char)Keys.Back) return;
            e.KeyChar = '\0';
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Задание допустимых символов ввода
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9')) return;
            if (e.KeyChar == '-' && ((TextBox)sender).Text.Length == 0)
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

        /// <summary>
        /// Метод срабатывает при загрузке формы.
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            // Запрет на изменени размера окна формы
            FormBorderStyle = FormBorderStyle.FixedSingle;

            n = Convert.ToInt32(numericUpDown1.Value);

            // Количество строчек
            dataGridView1.RowCount = n;
            // Количество столбиков
            dataGridView1.ColumnCount = n;

            // Заполнение таблицы при загрузке формы
            for (int j = 0; j < n; j++)
            {
                for (int i = 0; i < n; i++)
                {
                    dataGridView1.Rows[j].Cells[i].Value = 0.ToString();
                }
            }
        }

        /// <summary>
        /// Метод срабатывает при изменении активного зависимого переключателя.
        /// </summary>
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                dataGridView1.ReadOnly = false;

                for (int j = 0; j < n; j++)
                {
                    for (int i = 0; i < n; i++)
                    {
                        if (dataGridView1.Rows[j].Cells[i].Value == null)
                        {
                            // Заполнение таблицы
                            dataGridView1.Rows[j].Cells[i].Value = 0.ToString();
                        }
                    }
                }
            }
            else if (radioButton2.Checked)
            {
                dataGridView1.ReadOnly = true;

                for (int j = 0; j < n; j++)
                {
                    for (int i = 0; i < n; i++)
                    {
                        // Заполняет таблицу случайными целыми числами в указанном диапозоне 
                        dataGridView1.Rows[j].Cells[i].Value = r.Next(-99, 99);
                    }
                }
            }
            else
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    // Отчистка источника данных
                    dataGridView1.DataSource = null;

                    // Сброс размеров матрицы
                    dataGridView1.RowCount = 0;
                    dataGridView1.ColumnCount = 0;

                    dataGridView1.ReadOnly = true;

                    n = File.ReadAllLines(openFileDialog1.FileName).Length;

                    // Открытие окна с выбором файла
                    openFileDialog1.ShowDialog();

                    StreamReader sr = new StreamReader(openFileDialog1.FileName, Encoding.GetEncoding(1251));                 

                    DataSet ds = new DataSet();

                    // Создание таблицы, храняющую данные 
                    ds.Tables.Add("Matrix");

                    string header = sr.ReadLine();

                    ds.Tables[0].Columns.Clear();
                    
                    for (int i = 0; i < n; i++)
                    {                        
                        ds.Tables[0].Columns.Add("");
                    }

                    string row = sr.ReadLine();

                    // Заполняю первую строку
                    ds.Tables[0].Rows.Add(Regex.Split(header, " "));

                    // Заполняю остальные строки
                    while (row != null)
                    {
                        string[] rvalue = Regex.Split(row, " ");
                        ds.Tables[0].Rows.Add(rvalue);
                        row = sr.ReadLine();
                    }                    

                    // Указываю привязку к данным
                    dataGridView1.DataSource = ds.Tables[0];
                }
            }
        }
    }
}
