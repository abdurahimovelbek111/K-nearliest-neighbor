using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.ComponentModel;
namespace SuniyIntellekt_IAT4
{
    public partial class Form1 : Form
    {
        public List<int> Sinf = new List<int>();
        public List<object> qiymat = new List<object>();
        public List<double> Max = new List<double>();   
        public string path;
        public Form1()
        {
            InitializeComponent();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text|*.txt|All|*.*";
            openFileDialog.Title = "Text faylni tanlang";
            openFileDialog.InitialDirectory = @"C:\Users\Downloads";
            openFileDialog.ShowDialog();
            path = openFileDialog.FileName;
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
            dataGridView3.Visible = false;
            
            Read();            
        }
        public void Read()
        {                     
            label2.Visible = false;
            textBox1.Visible = true;
            button1.Visible = true;
            using (StreamReader reader = new StreamReader(path))
            {
                string satr = reader.ReadLine();                         
                string[] qator = satr.Split(' ');
                string x = "";
                for (int i = 1; i <=qator.Length; i++)
                {
                    if(i==qator.Length)
                    {
                        x +=$"Class";                      
                    }
                    else
                    {
                         x += $"{i}-Columns"+" ";
                    }
                }
                string[] qatorr = x.Split(' ');
                DataTable dataTable = new DataTable();
                foreach (var ustun in qatorr)
                {
                    dataTable.Columns.Add(ustun);
                }
                string newLine;
                using(StreamReader reader1=new StreamReader(path))
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
                using (StreamReader reader = new StreamReader(path))
                {
                    string[] kor = textBox1.Text.Split(' ');

                    string qator;
                    while ((qator=reader.ReadLine())!=null)
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
                   Chop_Etish();
                }       
        }
        public void Chop_Etish()
        {
            string[] qatorr = "Distance Class".Split(' ');
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
            dataGridView3.DataSource = dataTable;
        }
        public void Chebishev()
        {   
            using (StreamReader reader = new StreamReader(path))
            {
                string[] kor = textBox1.Text.Split(' ');
                string qator;
                while ((qator = reader.ReadLine())!=null)
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
                Chop_Etish();
            }
        }
        public void Manxetton()
        {
            double s = 0;
            using (StreamReader reader = new StreamReader(path))
            {
                string[] kor = textBox1.Text.Split(' ');
                string qator;
                while ((qator = reader.ReadLine())!=null)
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
                Chop_Etish();
            }
        }
        public void Normalashtirish()
        {
            List<double> qator = new List<double>();
            string[] X = textBox1.Text.Split(' ');
            int ustun = dataGridView1.Columns.Count - 1;
            //if (ustun > X.Length)
            //{
            //    MessageBox.Show("Mantiqsiz yechim . Siz kam raqam kiritdiz . Iltimos yana kiriting !!!");
            //}
            //if(ustun==X.Length || ustun<X.Length)
            //{              
            for (int i = 0; i < ustun; i++)
                {
                    for (int j = 0; j < dataGridView1.Rows.Count; j++)
                    {
                        qator.Add(double.Parse(dataGridView1.Rows[j].Cells[i].Value.ToString()));
                    }
                    qator.Sort();
                    for (int k = 0; k < qator.Count; k++)
                    {
                        dataGridView1.Rows[k].Cells[i].Value = (double.Parse(dataGridView1.Rows[k].Cells[i].Value.ToString()) - qator[0]) / (qator[qator.Count - 1] - qator[0]);
                    }
                    qator.Clear();
                }                    
            
        }
        public void Nuqta_Vergul()
        {
            List<string> vergul = new List<string>();
            using (StreamReader reader = new StreamReader(path))
            {
                string satr;
                while ((satr = reader.ReadLine()) != null)
                {
                    string x = "";
                    for (int i = 0; i < satr.Length; i++)
                    {
                        if (satr[i] == '.')
                        {
                            x += ",";
                        }
                        else
                        {
                            x += satr[i];
                        }
                     }
                    vergul.Add(x);
                    x = "";
                 }
            }
            File.WriteAllText(path,"");
            for (int i = 0; i < vergul.Count; i++)
            {
                File.AppendAllText(path, $"{vergul[i]}\n");
            }
          //  MessageBox.Show("Zo'r Maladess");
            Read();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {            
            dataGridView3.Visible = true;
            textBox1.Visible = false;
            button1.Visible = false;            
            label2.Visible = false;
            dataGridView1.Visible = false;
            label5.Visible = false;
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
            Sort(); 
            dataGridView2.Visible = true;
            button3.Visible = true;
            label2.Visible = true;
            label4.Visible = false;
            label1.Visible = false;
            comboBox1.Visible = false;
            label3.Visible = false;
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

        #region Vaqtinchalik
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
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Xatolik turi : {ex}");
            }
        }
        #endregion
        public void Sort()
        {           
            dataGridView3.Sort(dataGridView3.Columns["Distance"], ListSortDirection.Ascending);
            textBox3.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            int birr = 0, ikkii = 0;
            for (int i = 0; i < Sinf.Count; i++)
            {
                if(Sinf[i]==1)
                {
                    birr++;
                }
                else
                {
                    ikkii++;
                }
            }
            int l = 0;
            if (birr > ikkii)
                l = 2 * ikkii - 1;
            else
                l = 2 * birr - 1;

             MessageBox.Show($"1-Sinf elementlar soni : {birr} , 2-Sinf elementlar soni : {ikkii}");
            int k = int.Parse(textBox3.Text),bir=0,ikki=0;
            if (k <= l)
            {
                if (k % 2 != 0)
                {
                    foreach (DataGridViewRow row in dataGridView3.Rows)
                    {
                        int i = dataGridView2.Rows.Add();

                        foreach (DataGridViewColumn col in dataGridView3.Columns)
                        {
                            dataGridView2.Rows[i].Cells[col.Index].Value = dataGridView3.Rows[row.Index].Cells[col.Index].Value.ToString();
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
            else
            {
                if(k%2==0)
                {
                    MessageBox.Show($"Kiritgan {k}--> sonimiz juft bulishi mumkin emas . Iltimos k ni qaytadan kiriting!!!");
                }
                MessageBox.Show($"Kiritgan {k} -- miz  {l++} -- dan kichik son kiriting . Iltimos k ni qaytadan kiriting!!!");
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
            if (comboBox1.Text == "Yevkilid" || comboBox1.Text == "Chebishev" || comboBox1.Text == "Manxetton")
            {
                dataGridView1.Visible = true;
                button1.Visible = true;
                textBox1.Visible = true;
                dataGridView2.Visible = false;
                label2.Visible = false;
                textBox3.Visible = false;
                button3.Visible = false;                
               // Read(); 
                dataGridView3.Visible = false;
                label1.Visible = true;
                label4.Visible = true;                
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {
           // Nuqta_Vergul();
            Normalashtirish();
        }

        private void label4_Click(object sender, EventArgs e)
        {         
            Read();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2(path);
            form.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
           
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

