using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuniyIntellekt_IAT4
{
    public partial class Form4 : Form
    {        
        
        string[] lines, line;
        double[,] matrix, temp;
        int n, m;
        double[,] asosiyArr;
        string path;
        public Form4(string Path)
        {
            InitializeComponent();
            path = Path;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            lines = System.IO.File.ReadAllLines(path);   
            line = lines[0].Split(' ');
            //n va m obyektlar va xususiyatlar soni;
            n = lines.Length;
            m = line.Length;
            dataGridView1.RowCount = n;
            dataGridView1.ColumnCount = m;


            //asosiy matritsa xamma asosiy natijalar bor
            asosiyArr = new double[m - 1, 4];

            //matrix asosiy matritsa
            matrix = new double[n, m];
            //temp 2 ulchovli matritsa bu bitta ustunni va oxirgi klasni olib ketadi///
            temp = new double[n, 2];

            for (int i = 0; i < n; i++)
            {
                line = lines[i].Split(' ');
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = Convert.ToDouble(line[j]);
                }
            }

            //uqish tugadi
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = matrix[i, j];
                }
            }
            //tartiblash ustun buyicha
            for (int j = 0; j < m - 1; j++)
            {
                for (int i = 0; i < n; i++)
                {
                    temp[i, 0] = matrix[i, j];
                    temp[i, 1] = matrix[i, m - 1];

                }
                string[] natija = firstFunc(temp, n).Split(' ');

                for (int i = 0; i < 4; i++)
                {
                    asosiyArr[j, i] = Convert.ToDouble(natija[i]);
                }
            }
            dataGridView2.RowCount = m - 1;
            dataGridView2.ColumnCount = 4;
            for (int i = 0; i < m - 1; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    dataGridView2.Rows[i].Cells[j].Value = asosiyArr[i, j];
                }
            }
            //asosiy matritsani formula natijasi buyicha tartiblab chiqamiz!!!
            //for (int i = 0; i < m - 1; i++)
            //{
            //    for (int j = i; j < m - 1; j++)
            //    {
            //        if (asosiyArr[i, 3] < asosiyArr[j, 3])
            //        {
            //            double c0 = asosiyArr[i, 0];
            //            asosiyArr[i, 0] = asosiyArr[j, 0];
            //            asosiyArr[j, 0] = c0;

            //            double c1 = asosiyArr[i, 1];
            //            asosiyArr[i, 1] = asosiyArr[j, 1];
            //            asosiyArr[j, 1] = c1;

            //            double c2 = asosiyArr[i, 2];
            //            asosiyArr[i, 2] = asosiyArr[j, 2];
            //            asosiyArr[j, 2] = c2;

            //            double forNat = asosiyArr[i, 3];
            //            asosiyArr[i, 3] = asosiyArr[j, 3];
            //            asosiyArr[j, 3] = forNat;
            //        }
            //    }
            //}
        }
        static string firstFunc(double[,] a, int n)
        {

            int k1 = 0, k2 = 0, u11 = 0, u12 = 0, u21 = 0, u22 = 0;
            double formulaNatija = 0;
            string natija = "";
            double c0, c1 = 0, c2;
            double[,] oraliq;
            double[] temp;

            oraliq = new double[n - 2, 2];
            temp = new double[n];
            for (int i = 0; i < n; i++)
            {
                for (int j = i; j < n; j++)
                {
                    if (a[i, 0] > a[j, 0])
                    {
                        double k = a[i, 0];
                        a[i, 0] = a[j, 0];
                        a[j, 0] = k;
                        double sinf = a[i, 1];
                        a[i, 1] = a[j, 1];
                        a[j, 1] = sinf;
                    }
                }
            }

            //tartiblash tugadi
            c0 = a[0, 0];//min qiymat
            c2 = a[n - 1, 0];//max qiymat

            //Console.WriteLine(c0 + " " + c2);

            //temp-> massivda birxillik qiymatlarni olib tashlab quyilgan
            int sanagich = 1;
            temp[0] = a[0, 0];

            bool t = false;
            for (int i = 0; i < n; i++)
            {
                if (a[i, 1] == 1)
                {
                    k1++;//bu 1-sinflar soni
                }
                else
                {
                    k2++;//2-siniflar soni
                }
                t = false;
                for (int j = 0; j < sanagich; j++)
                {
                    if (a[i, 0] == temp[j])
                    {
                        t = true;
                        break;
                    }
                    else
                    {
                        t = false;
                        continue;
                    }
                }
                if (!t)
                {
                    temp[sanagich] = a[i, 0];
                    sanagich++;
                }
            }
            //temp->massivni hosil qildik;
            for (int ii = 0; ii < sanagich - 2; ii++)
            {
                u11 = 0; u12 = 0; u21 = 0; u22 = 0;
                for (int i = 0; i < n; i++)
                {

                    if (temp[ii] >= a[i, 0])
                    {
                        if (a[i, 1] == 1)
                        {
                            u11 = u11 + 1;
                        }
                        else
                        {
                            u21 = u21 + 1;
                        }
                    }
                    else
                    {
                        if (u12 == 0 && u22 == 0)
                        {
                            c1 = a[i, 0];
                        }
                        if (a[i, 1] == 1)
                        {
                            u12 = u12 + 1;
                        }
                        else
                        {
                            u22 = u22 + 1;
                        }
                    }
                }
                //Console.WriteLine("k1=" + k1);
                //Console.WriteLine("k2=" + k2);
                //Console.WriteLine("u11=" + u11);
                //Console.WriteLine("u12=" + u12);
                //Console.WriteLine("u21=" + u21);
                //Console.WriteLine("u22=" + u22);
                //Console.WriteLine("c1=" + c1);
                //Console.WriteLine("c0=" + c0);
                //Console.WriteLine("c2=" + c2);
                double surat1 = u11 * (u11 - 1) + u12 * (u12 - 1) + u21 * (u21 - 1) + u22 * (u22 - 1);
                double maxraj1 = k1 * (k1 - 1) + k2 * (k2 - 1);
                double surat2 = u11 * (k2 - u21) + u21 * (k1 - u11) + u12 * (k2 - u22) + u22 * (k1 - u12);
                double maxraj2 = 2 * k1 * k2;
                formulaNatija = surat1 * surat2 / (maxraj1 * maxraj2);
                oraliq[ii, 0] = formulaNatija;
                //Console.WriteLine("formulaNatijasi=" + formulaNatija);

                oraliq[ii, 1] = c1;
            }
            for (int i = 0; i < n - 2; i++)
            {
                for (int j = i; j < n - 2; j++)
                {
                    if (oraliq[i, 0] > oraliq[j, 0])
                    {
                        double formulaNat = oraliq[i, 0];
                        oraliq[i, 0] = oraliq[j, 0];
                        oraliq[j, 0] = formulaNat;
                        double sinf = oraliq[i, 1];
                        oraliq[i, 1] = oraliq[j, 1];
                        oraliq[j, 1] = sinf;
                    }
                }
            }
            //for (int i = 0; i < n; i++)
            //{
            //    for (int j = 0; j < 2; j++)
            //    {
            //        Console.Write(a[i, j] + " ");
            //    } Console.WriteLine("");
            ////}
            //for (int i = 0; i < n - 2; i++)
            //{
            //    Console.WriteLine(oraliq[i,0] + " "+oraliq[i,1]);

            //}
            natija = c0 + " " + oraliq[n - 3, 1] + " " + c2 + " " + oraliq[n - 3, 0];
            //  Console.WriteLine(natija);
            return natija;
        }
    }
}
