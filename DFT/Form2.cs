using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DFT
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void DrawTest()
        {
            const int N = 64;
            chart1.Series[0].BorderWidth = 2;
             chart2.Series[0].BorderWidth = 2;
            for (int i = 1; i < N; i++)
            {
                chart1.Series[0].Points.AddXY(i, Math.Sin((2 * Math.PI * i) / N));
                chart2.Series[0].Points.AddXY(i, Math.Cos((2 * Math.PI * i) / N));
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            DrawTest();
        }
    }
}
