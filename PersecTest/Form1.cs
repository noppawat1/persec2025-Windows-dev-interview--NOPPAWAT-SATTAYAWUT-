using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersecTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label1.Text = ""; // เคลียร์ผลลัพธ์เริ่มต้น
        }

        public void btnCheck_Click(object sender, EventArgs e)
        {
            string input = textBox1.Text.Trim();
            bool result = IsBalanced(input);
            label1.Text = result ? "ผลลัพธ์: True ✅" : "ผลลัพธ์: False ❌";
        }
        private bool IsBalanced(string input)
        {
            //**เงื่อนไข วงเล็ปต้องมีครบคู่ วงเล็ปไม่ซ้ำกัน และ เปิดปิดต้องไม่ซ้ำกัน  เปิดแล้วต้องปิด
            Stack<char> stack = new Stack<char>();

            foreach (char ch in input)
            {
                if (ch == '(' || ch == '[' || ch == '{') //เริ่มจากเช็ค วงเล็บเปิด ถ้าถูก stack เก็บไว้
                {
                    stack.Push(ch);
                }
                else if (ch == ')' || ch == ']' || ch == '}')//เช็ตวงเล็ปปิดต่อ
                {
                    if (stack.Count == 0)//ต้องมีวงเล็บเปิด
                        return false;

                    char top = stack.Pop();

                    if ((ch == ')' && top != '(') || //ต้องเป็นวงเล็ปปิด ไม่ต้องเปิดซ้ำ
                        (ch == ']' && top != '[') ||
                        (ch == '}' && top != '{'))
                    {
                        return false;
                    }
                }
                else
                {
                    // ถ้ามีตัวอักษรอื่น ๆ นอกจากวงเล็บ ให้ return false
                    return false;
                }
            }

            return stack.Count == 0;
        }

    }
}
