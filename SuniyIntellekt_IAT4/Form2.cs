using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuniyIntellekt_IAT4
{
    public partial class Form2 : Form
    {
        string Path;
        List<double> qiymat = new List<double>();
        List<int> Sinf = new List<int>();
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
                        x += $"Sinf";
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
        public void Yevkilid_Metirkasi()
        {
            double s = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 1; j < dataGridView1.Rows.Count; j++)
                {
                    for (int k = 0; k < dataGridView1.Columns.Count; k++)
                    {
                        s += Math.Pow(double.Parse(dataGridView1.Rows[i].Cells[k].Value.ToString()) - double.Parse(dataGridView1.Rows[j].Cells[k].Value.ToString()), 2);
                    }
                    qiymat.Add(s);
                    s = 0;
                }
            }
            
        }
        public void Chop_Etish()
        {
            string[] qatorr = "Masofa Sinf".Split(' ');
            DataTable dataTable = new DataTable();
            foreach (var ustun in qatorr)
            {
                dataTable.Columns.Add(ustun);
            }
            int soni = qiymat.Count, j = 0;
            while (soni != 0)
            {
                DataRow dataRow = dataTable.NewRow();
                for (int i = 0; i < 2; i++)
                {
                    if (i == 1)
                    {
                        dataRow[i] = Sinf[j];
                    }
                    else
                        dataRow[i] = qiymat[j];
                }
                j++;
                dataTable.Rows.Add(dataRow);
                soni--;
            }
            dataGridView1.DataSource = dataTable;
        }
    }
}

