using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void btnCheck_Click(object sender, EventArgs e)
        {
            string input = textBox1.Text.Trim();
            string input2 = textBox2.Text.Trim();
            string input3 = textBox3.Text.Trim();
            string[] arr = input2.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            List<string> result = Autocomplete(input, arr, Convert.ToInt32( input3));
            label1.Text = string.Join(", ", result);  
            label2.Text = "ผลลัพธ์ : " + result.Count;
        }
        public static List<string> Autocomplete(string search, string[] items, int maxResult)
        {
            string lowerSearch = search.ToLower();
            var cleanItems = items.Select(item => item.Replace("[", "").Replace("]", "")).ToArray();
            var result = cleanItems
                .Where(item => item.ToLower().Contains(lowerSearch)) // เฉพาะคำที่มี search
                .OrderBy(item => item.ToLower().IndexOf(lowerSearch)) // ลำดับที่เจอ search
                .ThenBy(item => item) // ลำดับตัวอักษรกรณี Index เท่ากัน
                .Take(maxResult)
                .ToList();

            return result;
        }


        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;

            // ถ้าผู้ใช้ใส่อะไรที่ไม่ใช่ตัวเลข จะลบทิ้ง
            string onlyDigits = new string(tb.Text.Where(char.IsDigit).ToArray());

            if (tb.Text != onlyDigits)
            {
                int selectionStart = tb.SelectionStart - 1;
                tb.Text = onlyDigits;
                tb.SelectionStart = Math.Max(0, selectionStart); // ทำให้เคอร์เซอร์ไม่กระโดด
            }
        }

    }
}
