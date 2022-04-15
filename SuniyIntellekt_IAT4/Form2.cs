using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace SuniyIntellekt_IAT4
{
    public partial class Form2 : Form
    {
        string Path;
        List<List<object>> Sinf_obyekt = new List<List<object>>();
        List<string> Sinf_indeks = new List<string>();
        List<string> vs = new List<string>();
        SortedList<double, string> keyValues = new SortedList<double, string>();
        List<int> sinf = new List<int>();
        List<int> Qobiq_element_indeks = new List<int>();
        public Form2(string path)
        {
            InitializeComponent();
            Path = path;
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            Read();
        }
        public void Read()
        {            
            using (StreamReader reader = new StreamReader(Path))
            {
                string satr = reader.ReadLine();
                string[] qator = satr.Split(' ');
                string x = "";
                for (int i = 1; i <= qator.Length; i++)
                {
                    if (i == qator.Length)
                    {
                        x += $"Class";
                    }
                    else
                    {
                        x += $"{i}-Columns" + " ";
                    }
                }
                string[] qatorr = x.Split(' ');
                DataTable dataTable = new DataTable();
                foreach (var ustun in qatorr)
                {
                    dataTable.Columns.Add(ustun);
                }
                string newLine;
                using (StreamReader reader1 = new StreamReader(Path))
                {
                    while ((newLine = reader1.ReadLine()) != null)
                    {
                        DataRow dataRow = dataTable.NewRow();
                        string[] values = newLine.Split(' ');
                        for (int i = 0; i < values.Length; i++)
                        {
                            if (values[i] == "")
                            {
                                continue;
                            }
                            else
                            {
                                dataRow[i] = values[i];
                            }
                        }
                        dataTable.Rows.Add(dataRow);
                    }
                    reader1.Close();
                    dataGridView1.DataSource = dataTable;
                }
            }
        }
        public void Qobiq_Element()
        {
            int l = 1,ll=5;  
            mbox:
            if (l <= ll)
            {
                List<object> sinf = new List<object>(); 
                using (StreamReader reader = new StreamReader(Path))
                {
                    int row = dataGridView1.Rows.Count;
                    while (row != 0)
                    {
                        var qator = reader.ReadLine();
                        if (qator is null)
                            break;
                        else
                        {
                            string[] values = qator.Split(' ');
                            if (int.Parse(values[values.Length - 1]) == l)
                            {
                                sinf.Add(qator);
                            }
                        }
                        row--;
                    }
                    if(sinf.Count!=0)
                    {
                        Sinf_obyekt.Add(sinf);
                        l++;                    
                        goto mbox;
                    }
                }
            }
            Oby_Masofa();
        }
        public void Oby_Masofa()
        {
            int k = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                //    for (int z = 1; z < Sinf_obyekt.Count; z++)
                //    {
                if (k<45)
                    {
                        double s = 0;
                        List<double> qiymat = new List<double>();
                        string satr = (string)Sinf_obyekt[0][i];
                        string[] x = satr.Split(' ');
                        for (int f = 0; f < Sinf_obyekt[1].Count; f++)
                        {
                            string text = (string)Sinf_obyekt[1][f];
                            string[] X = text.Split(' ');
                            for (int j = 0; j < dataGridView1.Columns.Count - 1; j++)
                            {
                                s += Math.Pow((double.Parse(x[j].ToString()) - double.Parse(X[j].ToString())), 2);
                            }
                            qiymat.Add(Math.Sqrt(s));
                            s = 0;
                        }
                        using (StreamReader reader1 = new StreamReader(Path))
                        {
                            string newLine;
                            int h = 0;
                            while ((newLine = reader1.ReadLine()) != null)
                            {
                                string[] qator = newLine.Split(' ');
                                string xx = int.Parse(qator[qator.Length - 1]) + " " + h;
                                Sinf_indeks.Add(xx);
                                vs.Add(newLine);
                                h++;
                            }
                        }
                        int bir = 0;
                        foreach (var item in Sinf_indeks)
                        {
                            string[] sinff = item.Split(' ');
                            if (int.Parse(sinff[0]) == 1)
                            {
                                bir++;
                            }
                        }
                        for (int ff = 0; ff < qiymat.Count; ff++)
                        {
                            keyValues.Add(qiymat[ff], Sinf_indeks[45+ff]);
                          // bir++;
                        }
                        int g = 0;
                        foreach (var item in keyValues)
                        {
                            string[] A = item.Value.ToString().Split(' ');
                            if (int.Parse(A[0]) == 2)
                            {
                                g = int.Parse(A[1]);
                                break;
                            }
                        }
                        qiymat.Clear();
                        s = 0;
                        string ss = vs[g];
                        string[] xxx = ss.Split(' ');
                        for (int fff = 1; fff < Sinf_obyekt[0].Count; fff++)
                        {
                            string text = (string)Sinf_obyekt[0][fff];
                            string[] X = text.Split(' ');
                            for (int j = 0; j < dataGridView1.Columns.Count - 1; j++)
                            {
                                s += Math.Pow((double.Parse(xxx[j].ToString()) - double.Parse(X[j].ToString())), 2);
                            }
                            qiymat.Add(Math.Sqrt(s));
                            s = 0;
                        }
                        keyValues.Clear();
                        for (int ffff = 0; ffff < qiymat.Count; ffff++)
                        {
                            keyValues.Add(qiymat[ffff], Sinf_indeks[ffff]);
                        }
                        foreach (var item in keyValues)
                        {
                            string[] values = item.Value.ToString().Split(' ');
                            sinf.Add(int.Parse(values[0]));
                            Qobiq_element_indeks.Add(int.Parse(values[1]));
                            break;
                        }
                        k++;
                    }
                    //else
                    //{
                    //    double s = 0;
                    //    List<double> qiymat = new List<double>();
                    //    string satr = (string)Sinf_obyekt[z][k];
                    //    string[] x = satr.Split(' ');
                    //    for (int f = 0; f < Sinf_obyekt[z-1].Count; f++)
                    //    {
                    //        string text = (string)Sinf_obyekt[z-1][f];
                    //        string[] X = text.Split(' ');
                    //        for (int j = 0; j < dataGridView1.Columns.Count - 1; j++)
                    //        {
                    //            s += Math.Pow((double.Parse(x[j].ToString()) - double.Parse(X[j].ToString())), 2);
                    //        }
                    //        qiymat.Add(Math.Sqrt(s));
                    //        s = 0;
                    //    }
                    //    using (StreamReader reader1 = new StreamReader(Path))
                    //    {
                    //        string newLine;
                    //        int h = 0;
                    //        while ((newLine = reader1.ReadLine()) != null)
                    //        {
                    //            string[] qator = newLine.Split(' ');
                    //            string xx = int.Parse(qator[qator.Length - 1]) + " " + h;
                    //            Sinf_indeks.Add(xx);
                    //            vs.Add(newLine);
                    //            h++;
                    //        }
                    //    }
                    //    int birrr = 0;
                    //    foreach (var item in Sinf_indeks)
                    //    {
                    //        string[] sinff = item.Split(' ');
                    //        if (int.Parse(sinff[0]) == 2)
                    //        {
                    //            birrr++;
                    //        }
                    //    }
                    //    for (int ff = 0; ff < qiymat.Count; ff++)
                    //    {
                    //        keyValues.Add(qiymat[ff], Sinf_indeks[ff+birrr]);
                    //    }
                    //    int g = 0;
                    //    foreach (var item in keyValues)
                    //    {
                    //        string[] A = item.Value.ToString().Split(' ');
                    //        if (int.Parse(A[0]) == 2)
                    //        {
                    //            g = int.Parse(A[1]);
                    //            break;
                    //        }
                    //    }
                    //    qiymat.Clear();
                    //    s = 0;
                    //    string ss = vs[g];
                    //    string[] xxx = ss.Split(' ');
                    //    for (int fff = 1; fff < Sinf_obyekt[z - 1].Count; fff++)
                    //    {
                    //        string text = (string)Sinf_obyekt[z - 1][fff];
                    //        string[] X = text.Split(' ');
                    //        for (int j = 0; j < dataGridView1.Columns.Count - 1; j++)
                    //        {
                    //            s += Math.Pow((double.Parse(xxx[j].ToString()) - double.Parse(X[j].ToString())), 2);
                    //        }
                    //        qiymat.Add(Math.Sqrt(s));
                    //        s = 0;
                    //    }
                    //    keyValues.Clear();
                    //    for (int ffff = 0; ffff < qiymat.Count; ffff++)
                    //    {
                    //        keyValues.Add(qiymat[ffff], Sinf_indeks[ffff]);
                    //    }
                    //    foreach (var item in keyValues)
                    //    {
                    //        string[] values = item.Value.ToString().Split(' ');
                    //        sinf.Add(int.Parse(values[0]));
                    //        Qobiq_element_indeks.Add(int.Parse(values[1]));
                    //        break;
                    //    }
                    //    k++;
                    //}                    
               // }
            }
            MessageBox.Show("Zo'r");
            Chop_Etish();
        }
        public void Chop_Etish()
        {
            string[] qatorr = "№ Qobiq_element_indeks Sinf".Split(' ');
            DataTable dataTable = new DataTable();
            foreach (var ustun in qatorr)
            {
                dataTable.Columns.Add(ustun);
            }
            int soni = Qobiq_element_indeks.Count;
            while (soni != 0)
            {
                int j = 1, jj = 0;
                DataRow dataRow = dataTable.NewRow();
                for (int i = 0; i < 3; i++)
                {
                    if (i == 1)
                    {
                        dataRow[i] = Qobiq_element_indeks[jj];
                    }
                    if (i == 2)
                    {
                        dataRow[i] = sinf[jj];
                    }
                    if(i==0)
                    {
                        dataRow[i] = $"{j}";
                    }
                }
                j++;
                jj++;
                dataTable.Rows.Add(dataRow);
                soni--;
            }
            dataGridView1.DataSource = dataTable;
        }
      
        private void button1_Click(object sender, EventArgs e)
        {
            Qobiq_Element();          
        }
    }
}

