using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.textBox1.TextChanged += textBox1_TextChanged;
            this.button1.Click += button1_Click;
        }
        public int SortDigitsDesc(int number)
        {
            if (number <= 0)
                throw new ArgumentOutOfRangeException("number", "Input must be a positive integer.");

            // แปลงตัวเลขเป็น string → ตัวอักษร → เรียงจากมากไปน้อย → รวมกลับ
            string sorted = new string(number
                                        .ToString()
                                        .OrderByDescending(c => c)
                                        .ToArray());

            return int.Parse(sorted);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text.Trim(), out int number))
            {
                try
                {
                    label1.Text = "=> " + SortDigitsDesc(number);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    label1.Text = ex.Message;
                }
            }
            else
            {
                label1.Text = "กรุณาใส่ตัวเลขจำนวนเต็มบวกเท่านั้น";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string text = textBox1.Text;
            string digitsOnly = new string(text.Where(char.IsDigit).ToArray());

            if (text != digitsOnly)
            {
                int selectionStart = textBox1.SelectionStart - (text.Length - digitsOnly.Length);
                if (selectionStart < 0) selectionStart = 0;

                textBox1.Text = digitsOnly;
                textBox1.SelectionStart = selectionStart;
            }
        }
    }

}
