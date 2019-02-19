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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 Run = new Form2();
            Run.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 cos = new Form3();
            cos.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 gradational = new Form4();
            gradational.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form6 sin = new Form6();
            sin.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form5 chast = new Form5();
            chast.Show();
        }
    }
}


