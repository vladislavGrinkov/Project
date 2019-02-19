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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        
        private void DrawTest(double[] foo)
        {
            const int N = 64;
            chart1.Series[0].BorderWidth = 2;
            for (int i = 0; i < N; i++)
            {
                chart1.Series[0].Points.AddXY(i, foo[i]);
            }
        }
        
        private void Form4_Load(object sender, EventArgs e)
        {
            const int N = 64;
            double[] foo = new double[N];
            for (int i = 0; i < N; i++)
            {
                if (i < 32)
                {
                    foo[i] = 1;
                }
                else
                {
                    foo[i] = -1;
                }
            }

            DrawTest(foo);

        }

    }
}
