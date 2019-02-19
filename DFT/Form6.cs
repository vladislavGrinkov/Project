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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }


        private void DrawRe(Complex[] X)// Real
        {
            chart1.ChartAreas[0].AxisY.ScaleView.Zoom(-0.6, 0.6);
            chart1.Series[0].BorderWidth = 5;
            for (int i = 1; i < X.Length; i++)
            {
                chart1.Series[0].Points.AddXY(i, X[i].Real);
            }
        }

        private void DrawIm(Complex[] X)//  Imaginary
        {
            chart2.ChartAreas[0].AxisY.ScaleView.Zoom(-0.6, 0.6);
            chart2.Series[0].BorderWidth = 2;
            for (int i = 1; i < X.Length; i++)
            {
                chart2.Series[0].Points.AddXY(i, X[i].Imaginary);
            }
        }

        private void DrawMg(Complex[] X) // Magnitude
        {
            chart3.ChartAreas[0].AxisY.ScaleView.Zoom(-0.6, 0.6);
            chart3.Series[0].BorderWidth = 3;
            for (int i = 1; i < X.Length; i++)
            {
                chart3.Series[0].Points.AddXY(i, X[i].Magnitude);
            }
        }

        private void DrawPh(Complex[] X) //Phase
        {
            chart4.ChartAreas[0].AxisY.ScaleView.Zoom(-0.6, 0.6);
            chart4.Series[0].BorderWidth = 1;
            for (int i = 1; i < X.Length; i++)
            {
                chart4.Series[0].Points.AddXY(i, X[i].Phase);
            }
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            const int N = 64;
            double[] foo = new double[N];
            //Формирование массива действительных чисел.
            for (int i = 0; i < N; i++)
            {
                foo[i] = Math.Sin((2 * Math.PI * i) / N);
            }

            Complex[] X = DFT.Calculate(foo);
            DrawRe(X);
            DrawIm(X);
            DrawMg(X);
            DrawPh(X);


        }
        public class Complex
        {
            public double Real;
            public double Imaginary;
            public double Magnitude;
            public double Phase;
            public override string ToString()
            {
                return $"({Real:N3}, {Imaginary:N3}), {Magnitude:N3}, {Phase:N3})";
            }
        }

        public class Parametres
        {
            public static int N;

            public static double[] Real(Complex[] x)
            {
                N = x.Length;
                double[] Re = new double[N];

                for (int i = 0; i < N; i++)
                {
                    Re[i] = x[i].Real;
                }

                return Re;
            }

            public static double[] Imaginary(Complex[] x)
            {
                N = x.Length;
                double[] Im = new double[N];

                for (int i = 0; i < N; i++)
                {
                    Im[i] = x[i].Imaginary;
                }

                return Im;
            }

            public static double[] Magnitude(Complex[] x)
            {
                N = x.Length;
                double[] M = new double[N];

                for (int i = 0; i < N; i++)
                {
                    M[i] = Math.Sqrt(x[i].Real * x[i].Real + x[i].Imaginary * x[i].Imaginary);
                }

                return M;
            }

            public static double[] Phase(Complex[] x) // Фаза
            {
                N = x.Length;
                double[] P = new double[N];

                for (int i = 0; i < N; i++)
                {
                    P[i] = Math.Atan2(x[i].Imaginary, x[i].Real);
                }

                return P;
            }
        }

        public class DFT
        {
            public static int N;

            public static Complex[] Calculate(double[] x)
            {
                int N = x.Length;
                Complex[] X = new Complex[N];

                for (int i = 0; i < N; i++)
                {
                    X[i] = new Complex();
                    X[i].Real = 0;
                    X[i].Imaginary = 0;
                    for (int j = 0; j < N; j++)
                    {
                        double power = 2 * Math.PI * i * j / N;
                        X[i].Real += x[j] * Math.Cos(power) / 64;
                        X[i].Imaginary += x[j] * Math.Sin(power) / 64;
                    }
                    X[i].Magnitude = (Math.Sqrt(Math.Pow(X[i].Real, 2) + Math.Pow(X[i].Imaginary, 2)));
                    if (X[i].Magnitude < 0.01)
                    {
                        X[i].Phase = 0;
                    }
                    else
                    {
                        X[i].Phase = Math.Atan(X[i].Imaginary / X[i].Real / Math.PI * 180);
                    }

                }

                return X;
            }
        }
    }
}
