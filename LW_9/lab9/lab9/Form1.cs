using System;
using System.Windows.Forms;

namespace lab9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime d;
            d = DateTime.Now;
            label1.Text = "Сегодняшняя дата: " + d.ToLongDateString();
            label2.Text = "Реальное время: " +  d.ToLongTimeString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime d_Now, d_User;

                // сегодняшняя дата
                d_Now = DateTime.Now;
                // ввод даты рождения 
                d_User = Convert.ToDateTime(maskedTextBox1.Text);

                if (d_Now < d_User)
                {
                    label3.Text = " Вы ещё не родились. Введите дату правильно!";
                }
                else
                {
                    // Проверка на возраст (в нынешнем году прошел день рождения, или нет)
                    if (d_Now.Month < d_User.Month)
                    {
                        if ((d_Now.Year - d_User.Year - 1)%10 == 1) label3.Text = "Пользователю " + (d_Now.Year - d_User.Year - 1).ToString() + " год";
                        else if ((d_Now.Year - d_User.Year - 1) % 10 > 1 && (d_Now.Year - d_User.Year - 1) % 10 < 5) label3.Text = "Пользователю " + (d_Now.Year - d_User.Year - 1).ToString() + " года";
                        else label3.Text = "Пользователю " + (d_Now.Year - d_User.Year - 1).ToString() + " лет";               
                    }
                    else if(d_Now.Month == d_User.Month)
                    {
                        if (d_Now.Day > d_User.Day)
                        {
                            if ((d_Now.Year - d_User.Year - 1) % 10 == 1) label3.Text = "Пользователю " + (d_Now.Year - d_User.Year).ToString() + " год";
                            else if ((d_Now.Year - d_User.Year - 1) % 10 > 1 && (d_Now.Year - d_User.Year - 1) % 10 < 5) label3.Text = "Пользователю " + (d_Now.Year - d_User.Year).ToString() + " года";
                            else label3.Text = "Пользователю " + (d_Now.Year - d_User.Year).ToString() + " лет";
                        }
                        else
                        {
                            if ((d_Now.Year - d_User.Year - 1) % 10 == 1) label3.Text = "Пользователю " + (d_Now.Year - d_User.Year - 1).ToString() + " год";
                            else if ((d_Now.Year - d_User.Year - 1) % 10 > 1 && (d_Now.Year - d_User.Year - 1) % 10 < 5) label3.Text = "Пользователю " + (d_Now.Year - d_User.Year - 1).ToString() + " года";
                            else label3.Text = "Пользователю " + (d_Now.Year - d_User.Year - 1).ToString() + " лет";
                        }
                    }
                    else
                    {
                        if ((d_Now.Year - d_User.Year - 1) % 10 == 1) label3.Text = "Пользователю " + (d_Now.Year - d_User.Year).ToString() + " год";
                        else if ((d_Now.Year - d_User.Year - 1) % 10 > 1 && d_Now.Year - d_User.Year < 5) label3.Text = "Пользователю " + (d_Now.Year - d_User.Year).ToString() + " года";
                        else label3.Text = "Пользователю " + (d_Now.Year - d_User.Year).ToString() + " лет";
                    }                     
                }
            }
            catch
            {
                MessageBox.Show("Ошибка ввода!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Запрет на изменени размера окна формы
            FormBorderStyle = FormBorderStyle.FixedSingle;
        }
    }
}
