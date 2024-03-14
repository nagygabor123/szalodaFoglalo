namespace tesztCalendar
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.szabaszam = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.evek = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.felasdat2cimke = new System.Windows.Forms.Label();
            this.feladat2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.feladat4b = new System.Windows.Forms.Label();
            this.feladat4 = new System.Windows.Forms.Label();
            this.feladat4cimke = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.feladat3kis = new System.Windows.Forms.Label();
            this.feladat3 = new System.Windows.Forms.Label();
            this.feladat3cimke = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.statisztika = new System.Windows.Forms.Label();
            this.valasztopanel = new System.Windows.Forms.Panel();
            this.szobapanel = new System.Windows.Forms.Panel();
            this.evekpanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.valasztopanel.SuspendLayout();
            this.szobapanel.SuspendLayout();
            this.evekpanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.dataGridView1.Location = new System.Drawing.Point(249, 21);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1164, 267);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.cell_click);
            // 
            // szabaszam
            // 
            this.szabaszam.AutoSize = true;
            this.szabaszam.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.szabaszam.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(35)))), ((int)(((byte)(78)))));
            this.szabaszam.Location = new System.Drawing.Point(14, 10);
            this.szabaszam.Name = "szabaszam";
            this.szabaszam.Padding = new System.Windows.Forms.Padding(3);
            this.szabaszam.Size = new System.Drawing.Size(80, 32);
            this.szabaszam.TabIndex = 1;
            this.szabaszam.Text = "Szoba:";
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.comboBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(35)))), ((int)(((byte)(78)))));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(64, 54);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(54, 28);
            this.comboBox1.TabIndex = 2;
            // 
            // evek
            // 
            this.evek.AutoSize = true;
            this.evek.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.evek.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(35)))), ((int)(((byte)(78)))));
            this.evek.Location = new System.Drawing.Point(13, 13);
            this.evek.Name = "evek";
            this.evek.Padding = new System.Windows.Forms.Padding(3);
            this.evek.Size = new System.Drawing.Size(48, 32);
            this.evek.TabIndex = 3;
            this.evek.Text = "ÉV:";
            // 
            // comboBox2
            // 
            this.comboBox2.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.comboBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.comboBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(35)))), ((int)(((byte)(78)))));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(41, 48);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(54, 28);
            this.comboBox2.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.felasdat2cimke);
            this.panel1.Controls.Add(this.feladat2);
            this.panel1.Location = new System.Drawing.Point(295, 29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 199);
            this.panel1.TabIndex = 5;
            // 
            // felasdat2cimke
            // 
            this.felasdat2cimke.AutoSize = true;
            this.felasdat2cimke.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.felasdat2cimke.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(35)))), ((int)(((byte)(78)))));
            this.felasdat2cimke.Location = new System.Drawing.Point(13, 9);
            this.felasdat2cimke.Name = "felasdat2cimke";
            this.felasdat2cimke.Padding = new System.Windows.Forms.Padding(2, 2, 2, 3);
            this.felasdat2cimke.Size = new System.Drawing.Size(173, 61);
            this.felasdat2cimke.TabIndex = 5;
            this.felasdat2cimke.Text = "Leghosszabb \r\n   tartózkodás: ";
            // 
            // feladat2
            // 
            this.feladat2.AutoSize = true;
            this.feladat2.Location = new System.Drawing.Point(23, 103);
            this.feladat2.Name = "feladat2";
            this.feladat2.Size = new System.Drawing.Size(45, 13);
            this.feladat2.TabIndex = 0;
            this.feladat2.Text = "feladat2";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.feladat4b);
            this.panel2.Controls.Add(this.feladat4);
            this.panel2.Controls.Add(this.feladat4cimke);
            this.panel2.Location = new System.Drawing.Point(799, 29);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(337, 199);
            this.panel2.TabIndex = 6;
            // 
            // feladat4b
            // 
            this.feladat4b.AutoSize = true;
            this.feladat4b.Location = new System.Drawing.Point(190, 68);
            this.feladat4b.Name = "feladat4b";
            this.feladat4b.Size = new System.Drawing.Size(51, 13);
            this.feladat4b.TabIndex = 8;
            this.feladat4b.Text = "feladat4b";
            // 
            // feladat4
            // 
            this.feladat4.AutoSize = true;
            this.feladat4.Location = new System.Drawing.Point(29, 68);
            this.feladat4.Name = "feladat4";
            this.feladat4.Size = new System.Drawing.Size(45, 13);
            this.feladat4.TabIndex = 7;
            this.feladat4.Text = "feladat4";
            // 
            // feladat4cimke
            // 
            this.feladat4cimke.AutoSize = true;
            this.feladat4cimke.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.feladat4cimke.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(35)))), ((int)(((byte)(78)))));
            this.feladat4cimke.Location = new System.Drawing.Point(14, 9);
            this.feladat4cimke.Name = "feladat4cimke";
            this.feladat4cimke.Padding = new System.Windows.Forms.Padding(2, 2, 2, 3);
            this.feladat4cimke.Size = new System.Drawing.Size(238, 33);
            this.feladat4cimke.TabIndex = 6;
            this.feladat4cimke.Text = "Foglalások (havonta)";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.feladat3kis);
            this.panel3.Controls.Add(this.feladat3);
            this.panel3.Controls.Add(this.feladat3cimke);
            this.panel3.Location = new System.Drawing.Point(548, 29);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 199);
            this.panel3.TabIndex = 6;
            // 
            // feladat3kis
            // 
            this.feladat3kis.AutoSize = true;
            this.feladat3kis.Location = new System.Drawing.Point(30, 116);
            this.feladat3kis.Name = "feladat3kis";
            this.feladat3kis.Size = new System.Drawing.Size(58, 13);
            this.feladat3kis.TabIndex = 8;
            this.feladat3kis.Text = "feladat3kis";
            // 
            // feladat3
            // 
            this.feladat3.AutoSize = true;
            this.feladat3.Location = new System.Drawing.Point(30, 68);
            this.feladat3.Name = "feladat3";
            this.feladat3.Size = new System.Drawing.Size(45, 13);
            this.feladat3.TabIndex = 7;
            this.feladat3.Text = "feladat3";
            // 
            // feladat3cimke
            // 
            this.feladat3cimke.AutoSize = true;
            this.feladat3cimke.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.feladat3cimke.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(35)))), ((int)(((byte)(78)))));
            this.feladat3cimke.Location = new System.Drawing.Point(14, 9);
            this.feladat3cimke.Name = "feladat3cimke";
            this.feladat3cimke.Padding = new System.Windows.Forms.Padding(2, 2, 2, 3);
            this.feladat3cimke.Size = new System.Drawing.Size(145, 33);
            this.feladat3cimke.TabIndex = 6;
            this.feladat3cimke.Text = "Bevétel/év : ";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel2);
            this.panel4.Controls.Add(this.button1);
            this.panel4.Controls.Add(this.panel3);
            this.panel4.Controls.Add(this.statisztika);
            this.panel4.Controls.Add(this.panel1);
            this.panel4.Location = new System.Drawing.Point(249, 313);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1163, 258);
            this.panel4.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.Font = new System.Drawing.Font("Microsoft Tai Le", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Turquoise;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.Location = new System.Drawing.Point(45, 145);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(180, 83);
            this.button1.TabIndex = 10;
            this.button1.Text = "Mehet";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // statisztika
            // 
            this.statisztika.AutoSize = true;
            this.statisztika.BackColor = System.Drawing.Color.Transparent;
            this.statisztika.Font = new System.Drawing.Font("Microsoft YaHei", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.statisztika.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(35)))), ((int)(((byte)(78)))));
            this.statisztika.Location = new System.Drawing.Point(17, 15);
            this.statisztika.Name = "statisztika";
            this.statisztika.Padding = new System.Windows.Forms.Padding(3, 3, 3, 4);
            this.statisztika.Size = new System.Drawing.Size(169, 43);
            this.statisztika.TabIndex = 7;
            this.statisztika.Text = "Statisztika:";
            // 
            // valasztopanel
            // 
            this.valasztopanel.Controls.Add(this.evekpanel);
            this.valasztopanel.Controls.Add(this.szobapanel);
            this.valasztopanel.Location = new System.Drawing.Point(12, 21);
            this.valasztopanel.Name = "valasztopanel";
            this.valasztopanel.Size = new System.Drawing.Size(208, 267);
            this.valasztopanel.TabIndex = 6;
            // 
            // szobapanel
            // 
            this.szobapanel.Controls.Add(this.szabaszam);
            this.szobapanel.Controls.Add(this.comboBox1);
            this.szobapanel.Location = new System.Drawing.Point(53, 154);
            this.szobapanel.Name = "szobapanel";
            this.szobapanel.Size = new System.Drawing.Size(135, 92);
            this.szobapanel.TabIndex = 6;
            // 
            // evekpanel
            // 
            this.evekpanel.Controls.Add(this.evek);
            this.evekpanel.Controls.Add(this.comboBox2);
            this.evekpanel.Location = new System.Drawing.Point(12, 13);
            this.evekpanel.Name = "evekpanel";
            this.evekpanel.Size = new System.Drawing.Size(112, 88);
            this.evekpanel.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1424, 654);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.valasztopanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.valasztopanel.ResumeLayout(false);
            this.szobapanel.ResumeLayout(false);
            this.szobapanel.PerformLayout();
            this.evekpanel.ResumeLayout(false);
            this.evekpanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label szabaszam;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label evek;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label statisztika;
        private System.Windows.Forms.Label feladat2;
        private System.Windows.Forms.Label felasdat2cimke;
        private System.Windows.Forms.Label feladat4;
        private System.Windows.Forms.Label feladat4cimke;
        private System.Windows.Forms.Label feladat3;
        private System.Windows.Forms.Label feladat3cimke;
        private System.Windows.Forms.Label feladat3kis;
        private System.Windows.Forms.Label feladat4b;
        private System.Windows.Forms.Panel valasztopanel;
        private System.Windows.Forms.Panel evekpanel;
        private System.Windows.Forms.Panel szobapanel;
    }
}

