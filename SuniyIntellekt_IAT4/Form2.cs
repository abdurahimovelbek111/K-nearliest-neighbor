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
        SortedDictionary<double, int> keyValues = new SortedDictionary<double, int>();
        List<List<int>> Qobiq_klass_indeks = new List<List<int>>();
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
            double s = 0;
            int a = 1;
            for (int i = 0; i <Sinf_obyekt.Count; i++)
            {
                List<int> indekss = new List<int>();
                //-----------------------------
                for (int k = 0; k < Sinf_obyekt[i].Count; k++)
                {
                    for (int j = 0; j < Sinf_obyekt[a].Count; j++)
                    {
                        string[] values1 = Sinf_obyekt[i][k].ToString().Split(' ');
                        string[] values2 = Sinf_obyekt[a][j].ToString().Split(' ');
                        for (int l = 0; l < dataGridView1.Columns.Count - 1; l++)
                        {
                            s += Math.Pow(double.Parse(values1[l]) - double.Parse(values2[l]), 2);
                        }
                        keyValues.Add(Math.Sqrt(s), j);
                        s = 0;
                    }
                    int indeks = 0;
                    foreach (var item in keyValues)
                    {
                        indeks = item.Value;
                        break;
                    }
                    keyValues.Clear();
                    //-----------------------
                    for (int j = 0; j < Sinf_obyekt[i].Count; j++)
                    {
                        string[] values2 = Sinf_obyekt[a][indeks].ToString().Split(' ');
                        string[] values1 = Sinf_obyekt[i][j].ToString().Split(' ');
                        for (int l = 0; l < dataGridView1.Columns.Count - 1; l++)
                        {
                            s += Math.Pow(double.Parse(values1[l]) - double.Parse(values2[l]), 2);
                        }
                        keyValues.Add(Math.Sqrt(s), j);
                        s = 0;
                    }
                    if(a==0)
                    {
                        foreach (var item in keyValues)
                        {
                            indekss.Add(item.Value+Sinf_obyekt[a].Count);
                            break;
                        }
                        keyValues.Clear();
                    }
                    else
                    {
                        foreach (var item in keyValues)
                        {
                            indekss.Add(item.Value);
                            break;
                        }
                        keyValues.Clear();
                    }                   
                }
                indekss.Sort();
                List<int> values = new List<int>();
                int ll = 0;
                mbox:
                if(ll<=indekss.Count)
                {
                    for (int kk = ll; kk < indekss.Count; kk++)
                    {
                        for (int j = 0; j < indekss.Count; j++)
                        {
                            if (indekss[kk] == indekss[j])
                            {
                                ll++;
                            }
                        }
                        values.Add(indekss[kk]);
                        goto mbox;
                    }
                }               
                indekss.Clear();
                a--;
                Qobiq_klass_indeks.Add(values);              
            }
            Chop_Etish();
        }
        public void Chop_Etish()
        {
            List<int> lll = new List<int>();            
            for (int i = 0; i < Qobiq_klass_indeks.Count; i++)
            {
                lll.Add(Qobiq_klass_indeks[i].Count);
            }
            lll.Sort();
            DataTable dataTable = new DataTable();
            string satr = "";
            int l = 1;
            for (int i = 0; i <=lll[lll.Count-1]; i++)
            {              
                if(i==0)
                {
                    satr += "№ ";
                }               
                else
                {
                   satr += $"{i} ";
                }               
            }
            string[] X = satr.Split(' ');
            for (int i = 0; i < X.Length; i++)
            {
                if(X[i]=="")
                {
                    continue;
                }
                dataTable.Columns.Add(X[i]);
            }
            List<int> vs = new List<int>();
            for (int i = 0; i < Qobiq_klass_indeks.Count; i++)
            {
                for (int j = 0; j < Qobiq_klass_indeks[i].Count; j++)
                {
                    vs.Add(Qobiq_klass_indeks[i][j]);
                }
                DataRow dataRow = dataTable.NewRow();
                int kk = 0;
                for (int g = 1; g <=lll[lll.Count - 1]; g++)
                {
                    if ((g - 1) == 0)
                    {
                        dataRow[g - 1] = $"{l}-Klass Qobiq elementlari";
                    }
                    if ((g) <= vs.Count)
                    {
                        dataRow[g] = vs[kk];
                        kk++;
                    }
                    else
                    {
                        dataRow[g] = null;
                    }
                }
                kk = 0;
                dataTable.Rows.Add(dataRow);
                vs.Clear();
                l++;
            }
            dataGridView2.DataSource = dataTable;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Qobiq_Element();
        }      
    }
}

