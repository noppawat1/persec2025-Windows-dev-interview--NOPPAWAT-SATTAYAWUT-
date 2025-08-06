using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Test4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.textBox1.TextChanged += textBox1_TextChanged;
            this.button1.Click += button1_Click;

            this.textBox2.TextChanged += textBox2_TextChanged;
            this.button2.Click += button2_Click;
        }

        public static string IntToRoman(int num)
        {
            if (num <= 0 || num > 3999)
                throw new ArgumentOutOfRangeException("num", "Input must be between 1 and 3999");

            var result = new StringBuilder();
            var romanNumerals = new[]
            {
                new { Value = 1000, Symbol = "M" },
                new { Value = 900, Symbol = "CM" },
                new { Value = 500, Symbol = "D" },
                new { Value = 400, Symbol = "CD" },
                new { Value = 100, Symbol = "C" },
                new { Value = 90, Symbol = "XC" },
                new { Value = 50, Symbol = "L" },
                new { Value = 40, Symbol = "XL" },
                new { Value = 10, Symbol = "X" },
                new { Value = 9, Symbol = "IX" },
                new { Value = 5, Symbol = "V" },
                new { Value = 4, Symbol = "IV" },
                new { Value = 1, Symbol = "I" }
            };

            foreach (var item in romanNumerals)
            {
                while (num >= item.Value)
                {
                    result.Append(item.Symbol);
                    num -= item.Value;
                }
            }

            return result.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text.Trim(), out int number))
            {
                try
                {
                    label1.Text = "=> " + IntToRoman(number);
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

        public static int RomanToInt(string s)
        {
            if (string.IsNullOrEmpty(s))
                throw new ArgumentException("Input cannot be null or empty");

            var map = new Dictionary<char, int>
            {
                {'I', 1},
                {'V', 5},
                {'X', 10},
                {'L', 50},
                {'C', 100},
                {'D', 500},
                {'M', 1000}
            };

            int result = 0;
            int prevValue = 0;

            // อ่านจากขวาไปซ้าย (หรือตั้งแต่ตัวสุดท้ายไปตัวแรก)
            for (int i = s.Length - 1; i >= 0; i--)
            {
                char c = char.ToUpper(s[i]);
                if (!map.ContainsKey(c))
                    throw new ArgumentException($"Invalid Roman numeral character: {c}");

                int current = map[c];

                // ถ้าค่าตัวก่อนหน้าน้อยกว่า ตัวนี้ - ให้ลบออก (เช่น IV = 5 - 1)
                if (current < prevValue)
                    result -= current;
                else
                    result += current;

                prevValue = current;
            }

            return result;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string roman = textBox2.Text.Trim().ToUpper();

            if (!string.IsNullOrEmpty(roman))
            {
                try
                {
                    int number = RomanToInt(roman);
                    label2.Text = "=> " + number.ToString();
                }
                catch (Exception ex)
                {
                    label2.Text = "Invalid Roman numeral";
                }
            }
            else
            {
                label2.Text = "กรุณาใส่เลขโรมันที่ถูกต้อง";
            }
        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string text = textBox2.Text;
            string lettersOnly = new string(text.Where(char.IsLetter).ToArray());

            if (text != lettersOnly)
            {
                int selectionStart = textBox2.SelectionStart - (text.Length - lettersOnly.Length);
                if (selectionStart < 0) selectionStart = 0;

                textBox2.Text = lettersOnly;
                textBox2.SelectionStart = selectionStart;
            }
        }



    }
}
