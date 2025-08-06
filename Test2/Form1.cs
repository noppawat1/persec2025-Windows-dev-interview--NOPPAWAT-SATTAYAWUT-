using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void btnCheck_Click(object sender, EventArgs e)
        {
            // สมมติ input เป็น string หลายคำ คั่นด้วย comma เช่น TH19,SG20,TH2
            string input = textBox1.Text.Trim();
            input = input.Trim('[', ']');
            string[] arr = input.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string[] sorted = CustomSort(arr);

            label1.Text = "ผลลัพธ์: [" + string.Join(", ", sorted) + "]";
        }
        public static string[] CustomSort(string[] arr)
        {//แบ่ง string ออกมา 2อันที่ต้อง sort 
            Array.Sort(arr, (a, b) =>
            {
                // เอาแค่ 2 ตัวอักษรแรก
                string prefixA = a.Length >= 2 ? a.Substring(0, 2) : a;
                string prefixB = b.Length >= 2 ? b.Substring(0, 2) : b;

                int cmpPrefix = string.Compare(prefixA, prefixB); //ใช้ string compare หาตัวอักษรที่มีค่ามากกว่าน้อยกว่า
                if (cmpPrefix != 0)
                    return cmpPrefix;

                // เอาเฉพาะตัวเลขที่อยู่หลัง prefix (ถ้ามี)
                int numA = ExtractNumber(a.Substring(prefixA.Length));
                int numB = ExtractNumber(b.Substring(prefixB.Length));

                return numA.CompareTo(numB);
            });

            return arr;
        }
        public static int ExtractNumber(string s)
        {
            var match = Regex.Match(s, @"\d+"); // 0-9
            if (match.Success)
                return int.Parse(match.Value);
            return 0;
        }
    }
}
