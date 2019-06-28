using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        double[] a;
        double[] b;
        double[] c;
        double[] d;
        double[] u;
        double[] v;
        double[] y;
        double h;
        int n;
        private void button1_Click(object sender, EventArgs e)
        {
            double h = Convert.ToDouble(textBox1.Text);
            massiv();//создание массивов и нахождение y
        }

        private void massiv()
        {
            double h = Convert.ToDouble(textBox1.Text);
            int n = Convert.ToInt32(1 / h)+1;
            double[] a = new double[n];
            double[] b = new double[n];
            double[] c = new double[n];
            double[] d = new double[n];
            double[] u = new double[n];
            double[] v = new double[n];
            double[] y = new double[n];
            double[] x = new double[n];
            double s = 0;
            for (int i = 0; i < n; i++)
            {
                x[i] = s;
                s += h;
            }
            a[0] = 1;
            a[n - 1] = 1;
            b[0] = 0;
            c[0] = 0;
            c[n - 1] = 0;
            d[0] = 0;
            d[n - 1] = -1;

            for (int i = 1; i < n - 1; i++)
            {
                a[i] = -2 - Math.Pow(h, 2);
                b[i] = 1;
                c[i] = 1;
                d[i] = 2 * Math.Pow(h, 3) * i ;
            }
            u[0] = b[0] / a[0] * (-1);
            v[0] = d[0] / a[0];
            for (int i = 1; i < n; i++)
            {
                u[i] = (-1) * b[i] / (c[i] * u[i - 1] + a[i]);
                v[i] = (d[i] - c[i] * v[i - 1]) / (c[i] * u[i - 1] + a[i]);
            }
            y[n - 1] = v[n - 1];
            for (int i = n - 2; i > -1; i--)
            {
                y[i] = u[i] * y[i + 1] + v[i];
            }
            chart1.Series[0].Points.Clear();
            for (int i = 0; i < n; i++)
            { 
                chart1.Series[0].Points.AddXY(x[i], y[i]);
                chart2.Series[0].Points.AddXY(x[i],Math.Sinh(x[i])/Math.Sinh(1)-2*x[i]);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
