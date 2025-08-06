using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Test6
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
                // อ่านค่าจาก textBox1 แล้วแยกด้วย ,
                string input = textBox1.Text.Trim();
                List<int> start = input
                    .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => int.Parse(s.Trim()))
                    .ToList();
                if (start.Count > 3)
                {
                    label1.Text = "ใส่ค่าตั้งต้นได้สูงสุด 3 ตัวเท่านั้น";
                    return;
                }
                // อ่านจำนวนที่ต้องการจาก textBox2
                int count = int.Parse(textBox2.Text.Trim());

                // คำนวณ Tribonacci
                var result = Tribonacci(start, count);

                // แสดงผลลัพธ์
                label1.Text = "=> [" + string.Join(", ", result) + "]";
            }
            catch
            {
                label1.Text = "ข้อมูลไม่ถูกต้อง โปรดใส่ตัวเลขที่ถูกต้อง";
            }
        }

        public List<int> Tribonacci(List<int> start, int n)
        {
            var result = new List<int>(start);

            while (result.Count < 3)
            {
                result.Add(0);
            }

            if (n <= result.Count)
            {
                return result.Take(n).ToList();
            }

            for (int i = result.Count; i < n; i++)
            {
                int next = result[i - 1] + result[i - 2] + result[i - 3];
                result.Add(next);
            }

            return result;
        }

    }
}
