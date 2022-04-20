
namespace SuniyIntellekt_IAT4
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.vazifaniTanlangToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kyaqinQushniToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.qobiqToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.klasterlashToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vaznToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.Distance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Class = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vazifaniTanlangToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1035, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // vazifaniTanlangToolStripMenuItem
            // 
            this.vazifaniTanlangToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kyaqinQushniToolStripMenuItem,
            this.qobiqToolStripMenuItem,
            this.klasterlashToolStripMenuItem,
            this.vaznToolStripMenuItem});
            this.vazifaniTanlangToolStripMenuItem.Name = "vazifaniTanlangToolStripMenuItem";
            this.vazifaniTanlangToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.vazifaniTanlangToolStripMenuItem.Text = "Select a task";
            this.vazifaniTanlangToolStripMenuItem.Click += new System.EventHandler(this.vazifaniTanlangToolStripMenuItem_Click);
            // 
            // kyaqinQushniToolStripMenuItem
            // 
            this.kyaqinQushniToolStripMenuItem.Name = "kyaqinQushniToolStripMenuItem";
            this.kyaqinQushniToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.kyaqinQushniToolStripMenuItem.Text = "K-close bird";
            this.kyaqinQushniToolStripMenuItem.Click += new System.EventHandler(this.kyaqinQushniToolStripMenuItem_Click);
            // 
            // qobiqToolStripMenuItem
            // 
            this.qobiqToolStripMenuItem.Name = "qobiqToolStripMenuItem";
            this.qobiqToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.qobiqToolStripMenuItem.Text = "The shell";
            this.qobiqToolStripMenuItem.Click += new System.EventHandler(this.qobiqToolStripMenuItem_Click);
            // 
            // klasterlashToolStripMenuItem
            // 
            this.klasterlashToolStripMenuItem.Name = "klasterlashToolStripMenuItem";
            this.klasterlashToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.klasterlashToolStripMenuItem.Text = "Clustering";
            this.klasterlashToolStripMenuItem.Click += new System.EventHandler(this.klasterlashToolStripMenuItem_Click);
            // 
            // vaznToolStripMenuItem
            // 
            this.vaznToolStripMenuItem.Name = "vaznToolStripMenuItem";
            this.vaznToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.vaznToolStripMenuItem.Text = "Weight";
            this.vaznToolStripMenuItem.Click += new System.EventHandler(this.vaznToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Location = new System.Drawing.Point(0, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1031, 551);
            this.panel1.TabIndex = 1;
            this.panel1.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel2.Controls.Add(this.dataGridView2);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.textBox3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(398, 89);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(331, 439);
            this.panel2.TabIndex = 31;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.Location = new System.Drawing.Point(181, 7);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(111, 32);
            this.button3.TabIndex = 11;
            this.button3.Text = "Result";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox3.Location = new System.Drawing.Point(70, 9);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(91, 32);
            this.textBox3.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(29, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 26);
            this.label2.TabIndex = 8;
            this.label2.Text = "K:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(111, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 24);
            this.label1.TabIndex = 30;
            this.label1.Text = "Normalization";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(354, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 26);
            this.label3.TabIndex = 29;
            this.label3.Text = "Select metric:";
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Yevkilid",
            "Chebishev",
            "Manxetton"});
            this.comboBox1.Location = new System.Drawing.Point(538, 15);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(177, 32);
            this.comboBox1.TabIndex = 28;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged_1);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 80);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1004, 460);
            this.dataGridView1.TabIndex = 27;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.HotPink;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(754, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(182, 37);
            this.button1.TabIndex = 26;
            this.button1.Text = "Next";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(12, 51);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(1004, 23);
            this.textBox1.TabIndex = 25;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Distance,
            this.Class});
            this.dataGridView2.Location = new System.Drawing.Point(3, 47);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(325, 389);
            this.dataGridView2.TabIndex = 12;
            // 
            // Distance
            // 
            this.Distance.HeaderText = "Distance";
            this.Distance.Name = "Distance";
            // 
            // Class
            // 
            this.Class.HeaderText = "Class";
            this.Class.Name = "Class";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1035, 579);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem vazifaniTanlangToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kyaqinQushniToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem qobiqToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem klasterlashToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vaznToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Distance;
        private System.Windows.Forms.DataGridViewTextBoxColumn Class;
    }
}

