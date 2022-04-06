using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.ComponentModel;
using System.Data.Linq;

namespace SuniyIntellekt_IAT4
{
    public partial class Form1 : Form
    {
        public List<int> Sinf = new List<int>();
        public List<object> qiymat = new List<object>();
        public List<double> Max = new List<double>();
        public string path = "ABC.txt";
        public Form1()
        {
            InitializeComponent();
        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        

        private void Form1_Load(object sender, EventArgs e)
        {           
            label2.Visible = false;
            textBox3.Visible = false;
            dataGridView2.Visible = false;
            button3.Visible = false;
            Read();
        }
        public void Read()
        {
                     
            label2.Visible = false;
            textBox1.Visible = true;
            button1.Visible = true;
            


            using (StreamReader reader = new StreamReader(path))
            {
                string[] qator = reader.ReadLine().Split(' ');
                DataTable dataTable = new DataTable();
                foreach (var ustun in qator)
                {
                    dataTable.Columns.Add(ustun);
                }
                string newLine;
                while ((newLine = reader.ReadLine()) != null)
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
                reader.Close();
                dataGridView1.DataSource = dataTable;
            }
        }   
        public void Yevkilid_Metirkasi()
        {   
               
                double s = 0;                
                using (StreamReader reader = new StreamReader(path))
                {
                    string[] kor = textBox1.Text.Split(' ');

                    bool t = true;
                    while (t)
                    {
                        var qator = reader.ReadLine();
                        if (qator == null)
                        {
                            t = false;
                        }
                        else
                        {
                            string[] Satr_element = qator.Split(' ');
                            Sinf.Add(int.Parse(Satr_element[Satr_element.Length - 1].ToString()));
                            for (int i = 0; i < Satr_element.Length - 1; i++)
                            {
                                s += Math.Pow(double.Parse(Satr_element[i].ToString()) - double.Parse(kor[i].ToString()), 2);
                            }
                            qiymat.Add(Math.Sqrt(s));                         
                            s = 0;
                        }
                    }
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
        public void Chebishev()
        {   
            using (StreamReader reader = new StreamReader(path))
            {
                string[] kor = textBox1.Text.Split(' ');
                bool t = true;
                while (t)
                {
                    var qator = reader.ReadLine();
                    if (qator == null)
                    {
                        t = false;
                    }
                    else
                    {
                        string[] Satr_element = qator.Split(' ');
                        Sinf.Add(int.Parse(Satr_element[Satr_element.Length - 1].ToString()));
                        for (int i = 0; i < Satr_element.Length - 1; i++)
                        {
                            Max.Add(Math.Abs((double.Parse(Satr_element[i]) - double.Parse(kor[i]))));
                        }
                        Max.Sort();
                        qiymat.Add(Max[Max.Count-1]);              
                    }
                }
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
        public void Manxetton()
        {
            double s = 0;
            using (StreamReader reader = new StreamReader(path))
            {
                string[] kor = textBox1.Text.Split(' ');

                bool t = true;
                while (t)
                {
                    var qator = reader.ReadLine();
                    if (qator == null)
                    {
                        t = false;
                    }
                    else
                    {
                        string[] Satr_element = qator.Split(' ');
                        Sinf.Add(int.Parse(Satr_element[Satr_element.Length - 1].ToString()));
                        for (int i = 0; i < Satr_element.Length - 1; i++)
                        {
                           s+=Math.Abs((double.Parse(Satr_element[i]) - double.Parse(kor[i])));
                        }                        
                        qiymat.Add(s);
                        s = 0;
                    }
                }
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
        public void Normalashtirish()
        {
            double s = 0;
            using (StreamReader reader = new StreamReader(path))
            {
                string[] kor = textBox1.Text.Split(' ');

                bool t = true;
                while (t)
                {
                    var qator = reader.ReadLine();
                    if (qator == null)
                    {
                        t = false;
                    }
                    else
                    {
                        string[] Satr_element = qator.Split(' ');
                        Sinf.Add(int.Parse(Satr_element[Satr_element.Length - 1].ToString()));
                        for (int i = 0; i < Satr_element.Length - 1; i++)
                        {
                            s += Math.Abs((double.Parse(Satr_element[i]) - double.Parse(kor[i])));
                        }
                        qiymat.Add(s);
                        s = 0;
                    }
                }               
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Visible = false;
            button1.Visible = false;            
            label2.Visible = false;
           
            switch (comboBox1.Text)
            {
                case"Yevkilid":                   
                      Yevkilid_Metirkasi();                    
                    break;
                case"Chebishev":
                    Chebishev();
                    break;
                case "Manxetton":
                    Manxetton();
                    break;
                default:
                    break;
            }
            Sort(); dataGridView2.Visible = true;
            button3.Visible = true;
            label2.Visible = true;
            label3.Visible = false;
            comboBox1.Visible = false;
            button1.Visible = false;
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            var dvg = sender as DataGridView;
            var row = dvg.Rows[e.RowIndex];
            var movie = row.DataBoundItem;
            if (movie != null)
            {
                string x = "";
                for (int i = 0; i < dataGridView1.Columns.Count - 1; i++)
                {
                    x += dataGridView1.Rows[e.RowIndex].Cells[i].Value.ToString() + " ";
                }
                textBox1.Text = x;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            #region Vaqtinchalik
            //int f = 0;
            //foreach (var item in qiy_sinf)
            //{
            //    string[] row = item.ToString().Split(' ', ']', '[', '}', '{');
            //    for (int i = 0; i < row.Length; i++)
            //    {
            //        if (row[i] == "")
            //        {
            //            continue;
            //        }
            //        else
            //        {
            //            string x = row[i];
            //            if (x[x.Length - 1] == ',')
            //            {
            //                var qat = x.Remove(x.Length - 1, 1);
            //                stack.Push(qat);
            //            }
            //            else
            //            {
            //                stack.Push(x);
            //            }
            //        }
            //    }
            //    List<object> vs = new List<object>();
            //    while (stack.Count != 0)
            //    {
            //        vs.Add(stack.Pop());
            //    }
            //    dataRow[0] = qiymat[f];
            //    //dataRow[0] = Sinf[f];
            //    f++;
            //    dataTable.Rows.Add(dataRow);
            //break;
            //}
            #endregion
            string x = textBox1.Text;
            textBox1.Text = "";
            try
            {
                var qatot = x.Remove(x.Length - 2, 2);
                //textBox2.Text = qatot;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Xatolik turi : {ex}");
            }
        }       
        public void Sort()
        {
           
            dataGridView1.Sort(dataGridView1.Columns["Masofa"], ListSortDirection.Ascending);
            textBox3.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();           
            int k = int.Parse(textBox3.Text),bir=0,ikki=0;
            if(k%2!=0 && k<=45)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    int i = dataGridView2.Rows.Add();

                    foreach (DataGridViewColumn col in dataGridView1.Columns)
                    {
                        dataGridView2.Rows[i].Cells[col.Index].Value = dataGridView1.Rows[row.Index].Cells[col.Index].Value.ToString();
                        if (double.Parse(dataGridView2.Rows[row.Index].Cells[col.Index].Value.ToString()) == 1)
                        {
                            bir++;
                        }
                        if (double.Parse(dataGridView2.Rows[row.Index].Cells[col.Index].Value.ToString()) == 2)
                        {
                            ikki++;
                        }
                    }
                    if (k == 1)
                    {
                        break;
                    }
                    k--;
                }
                if (bir > ikki)
                {
                    MessageBox.Show("Obyekt 1-sinfga tegishli");
                }
                else
                {
                    MessageBox.Show("Obyekt 2-sinfga tegishli");
                }
                textBox3.Text = "";
            }
            else
            {
                MessageBox.Show($"Kiritgan {k}--> sonimiz juft bulishi mumkin emas . Iltimos k ni qaytadan kiriting!!!");
            }
           
           
           
          
           
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

