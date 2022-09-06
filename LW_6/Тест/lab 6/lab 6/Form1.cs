using System;
using System.Windows.Forms;
using System.IO;

namespace lab_6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Тоонаж
        int KolvoTon;
        // Количество членов экипажа
        int KolvoEkipaje;

        private void button1_Click(object sender, EventArgs e)
        {
            // Проверка на пустоту текстовых полей
            if (comboBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                Class1 S = new Class1(comboBox1.Text, int.Parse(textBox2.Text), int.Parse(textBox3.Text));
                richTextBox1.Text += S.ToString();
                if (int.Parse(textBox2.Text) > KolvoTon || int.Parse(textBox3.Text) < KolvoEkipaje)
                {
                    KolvoTon = int.Parse(textBox2.Text);
                    KolvoEkipaje = int.Parse(textBox3.Text);
                    label4.Text = S.ToString();
                }
            }
            else
            {
                // Сообщение об ошибки
                MessageBox.Show("Все поля должны быть заполнены!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult d = MessageBox.Show("Сохранить ли список?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (d == DialogResult.Yes)
            {
                saveFileDialog1.ShowDialog();
                StreamWriter sw = new StreamWriter(saveFileDialog1.FileName+".txt");
                sw.Write(richTextBox1.Text);
                sw.Close();
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Контроль вводимых символов
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9')) return;
            if (e.KeyChar == '.') e.KeyChar = ',';
            if (e.KeyChar == ',') return;
            if (e.KeyChar == (char)Keys.Back) return;
            e.KeyChar = '\0';
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            // Контроль вводимых данных
            if(textBox2.Text == "0")
            {
                textBox2.Text = 1.ToString();
            }
            if (textBox3.Text == "0")
            {
                textBox3.Text = 1.ToString();
            }
        }
    }
}
