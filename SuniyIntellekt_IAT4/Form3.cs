using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace SuniyIntellekt_IAT4
{
    public partial class Form3 : Form
    {
        public string path;
       public  int k = 0;
      public  List<List<int>> groups = new List<List<int>>();
       public double[,] centers;
        public Form3(string Path)
        {
            InitializeComponent();
            path = Path;
        }
        private void Form3_Load(object sender, System.EventArgs e)
        {
            Read();
        }
        public void Read()
        {
            int j = 0;
            using (StreamReader reader = new StreamReader(path))
            {
                string ss = reader.ReadLine();
                string[] arr;
                string satr = "";
                arr = ss.Split(' ');
                for (int i = 0; i < arr.Length + 1; i++)
                {
                    if (i == 0)
                    {
                        satr += "№ ";
                    }
                    else
                    {
                        satr += i + "-index ";
                    }
                }
                string[] qatorr = satr.Split(' ');
                DataTable dataTable = new DataTable();
                foreach (var ustun in qatorr)
                {
                    if (ustun == "")
                    {
                        continue;
                    }
                    dataTable.Columns.Add(ustun);
                }
                string newLine;
                using (StreamReader reader1 = new StreamReader(path))
                {
                    while ((newLine = reader1.ReadLine()) != null)
                    {
                        newLine = j.ToString() + " " + newLine;
                        j++;
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
        public void Hisobla()
        {
            Klaster();
            Markaz();
        }
        public double Masofa(int group, int tanlanma)
        {
            double s = 0;
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                s += Math.Pow(double.Parse(dataGridView1.Rows[tanlanma].Cells[i].Value.ToString()) - centers[group, i], 2);
            }
            return Math.Sqrt(s);
        }
        public void Markaz()
        {
            for (int i = 0; i < k; i++)
            {
                for (int j = 0; j < dataGridView1.Rows.Count; j++)
                {
                    centers[i, j] = 0;
                }
            }
            for (int j = 0; j < groups.Count; j++)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (i < dataGridView1.Columns.Count)
                        centers[groups[j][0], groups[j][1]] += (double.Parse(dataGridView1.Rows[groups[j][0]].Cells[i].Value.ToString()) + centers[groups[j][0], groups[j][1]]) / 2;
                }
            }
        }
        public void Klaster()
        {
            groups.Clear();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                List<int> te = new List<int>();
                int x = 0;
                double mas = 0;
                for (int j = 0; j < k; j++)
                {
                    if (j == 0)
                    {
                        x = 0;
                        mas = Masofa(j, i);
                    }
                    else
                        if (mas > Masofa(j, i))
                    {
                        mas = Masofa(j, i);
                        x = j;
                    }
                }
                te.Add(x);
                te.Add(i);
                groups.Add(te);
            }

        }
        public void Chiqar()
        {
            DataTable dataTable = new DataTable();
            string satr = "";
            for (int i = 1; i <= dataGridView1.Rows.Count; i++)
            {
                if(i==1)
                {
                    satr += "№ ";
                }
                else
                {
                    satr += $"{i-1}-Indeks ";
                }
            }
            string[] X = satr.Split(' ');
            foreach (var item in X)
            {
                dataTable.Columns.Add(item);
            }
            List<int> vs = new List<int>();
            int s = dataGridView1.Rows.Count;
            for (int i = 0; i < k; i++)
            {
                for (int j = 0; j < groups.Count; j++)
                {
                    if (i == groups[j][0])
                        vs.Add(groups[j][1]);
                }
                DataRow dataRow = dataTable.NewRow();
                int kk = 0;
                for (int g = 1; g < s; g++)
                {
                    if ((g - 1) == 0)
                    {
                        dataRow[g - 1] = $"{i+1}-guruh";
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
            }
            dataGridView2.DataSource = dataTable;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            if (textBox3.Text == "")
                MessageBox.Show("K kiritilmadi.");
            else
            {
                k = int.Parse(textBox3.Text);
                if (k < dataGridView1.Rows.Count)
                {
                    centers = new double[k, dataGridView1.Rows.Count];
                    for (int i = 0; i < k; i++)
                    {
                        for (int j = 0; j < dataGridView1.Rows.Count; j++)
                        {
                            if (j < dataGridView1.Columns.Count)
                                centers[i, j] = double.Parse(dataGridView1.Rows[i].Cells[j].Value.ToString());
                        }
                    }
                    Hisobla();
                    Chiqar();
                }
                else
                    MessageBox.Show("K kichik bo'lsin tanlanmalar sonidan!!!");
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
