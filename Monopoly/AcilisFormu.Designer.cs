namespace Monopoly
{
    partial class AcilisFormu
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.txtOyuncu2 = new System.Windows.Forms.TextBox();
            this.lblOyuncu2 = new System.Windows.Forms.Label();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.button5 = new System.Windows.Forms.Button();
            this.txtOyuncu1 = new System.Windows.Forms.TextBox();
            this.lblOyuncu1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.oyuncuAdiDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oyuncuPuanDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.puanBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.veritabaniDataSet = new Monopoly.veritabaniDataSet();
            this.puanTableAdapter = new Monopoly.veritabaniDataSetTableAdapters.PuanTableAdapter();
            this.btndatagridkapat = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.puanBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.veritabaniDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(239)))), ((int)(((byte)(203)))));
            this.label2.Location = new System.Drawing.Point(441, 453);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 17);
            this.label2.TabIndex = 7;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(239)))), ((int)(((byte)(203)))));
            this.pictureBox1.Image = global::Monopoly.Properties.Resources._82;
            this.pictureBox1.Location = new System.Drawing.Point(444, 386);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(110, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = global::Monopoly.Properties.Resources.yenioyun;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(410, 59);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(200, 50);
            this.button1.TabIndex = 11;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::Monopoly.Properties.Resources.puantablosu;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(225, 146);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 50);
            this.button2.TabIndex = 12;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackgroundImage = global::Monopoly.Properties.Resources.yardım;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(721, 146);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 50);
            this.button3.TabIndex = 13;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.txtOyuncu2);
            this.panel1.Controls.Add(this.lblOyuncu2);
            this.panel1.Controls.Add(this.radioButton2);
            this.panel1.Controls.Add(this.radioButton1);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.txtOyuncu1);
            this.panel1.Controls.Add(this.lblOyuncu1);
            this.panel1.Location = new System.Drawing.Point(358, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(334, 184);
            this.panel1.TabIndex = 14;
            this.panel1.Visible = false;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // button4
            // 
            this.button4.BackgroundImage = global::Monopoly.Properties.Resources.basla;
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(3, 108);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(80, 40);
            this.button4.TabIndex = 8;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // txtOyuncu2
            // 
            this.txtOyuncu2.Location = new System.Drawing.Point(172, 80);
            this.txtOyuncu2.Name = "txtOyuncu2";
            this.txtOyuncu2.Size = new System.Drawing.Size(100, 22);
            this.txtOyuncu2.TabIndex = 7;
            // 
            // lblOyuncu2
            // 
            this.lblOyuncu2.AutoSize = true;
            this.lblOyuncu2.Location = new System.Drawing.Point(54, 80);
            this.lblOyuncu2.Name = "lblOyuncu2";
            this.lblOyuncu2.Size = new System.Drawing.Size(101, 17);
            this.lblOyuncu2.TabIndex = 6;
            this.lblOyuncu2.Text = "2.Oyuncu İsmi:";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("Jokerman", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton2.Location = new System.Drawing.Point(170, 3);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(119, 29);
            this.radioButton2.TabIndex = 5;
            this.radioButton2.Text = "2 Oyuncu";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged_1);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Font = new System.Drawing.Font("Jokerman", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton1.Location = new System.Drawing.Point(45, 3);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(116, 29);
            this.radioButton1.TabIndex = 4;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "1 Oyuncu";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged_1);
            // 
            // button5
            // 
            this.button5.BackgroundImage = global::Monopoly.Properties.Resources.iptal;
            this.button5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Location = new System.Drawing.Point(247, 108);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(80, 40);
            this.button5.TabIndex = 3;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click_1);
            // 
            // txtOyuncu1
            // 
            this.txtOyuncu1.Location = new System.Drawing.Point(172, 45);
            this.txtOyuncu1.Name = "txtOyuncu1";
            this.txtOyuncu1.Size = new System.Drawing.Size(100, 22);
            this.txtOyuncu1.TabIndex = 2;
            // 
            // lblOyuncu1
            // 
            this.lblOyuncu1.AutoSize = true;
            this.lblOyuncu1.Location = new System.Drawing.Point(51, 45);
            this.lblOyuncu1.Name = "lblOyuncu1";
            this.lblOyuncu1.Size = new System.Drawing.Size(101, 17);
            this.lblOyuncu1.TabIndex = 1;
            this.lblOyuncu1.Text = "1.Oyuncu İsmi:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.oyuncuAdiDataGridViewTextBoxColumn,
            this.oyuncuPuanDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.puanBindingSource;
            this.dataGridView1.Enabled = false;
            this.dataGridView1.Location = new System.Drawing.Point(225, 45);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.ShowCellErrors = false;
            this.dataGridView1.ShowCellToolTips = false;
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.ShowRowErrors = false;
            this.dataGridView1.Size = new System.Drawing.Size(627, 286);
            this.dataGridView1.TabIndex = 15;
            this.dataGridView1.Visible = false;
            // 
            // oyuncuAdiDataGridViewTextBoxColumn
            // 
            this.oyuncuAdiDataGridViewTextBoxColumn.DataPropertyName = "OyuncuAdi";
            this.oyuncuAdiDataGridViewTextBoxColumn.HeaderText = "OyuncuAdi";
            this.oyuncuAdiDataGridViewTextBoxColumn.Name = "oyuncuAdiDataGridViewTextBoxColumn";
            // 
            // oyuncuPuanDataGridViewTextBoxColumn
            // 
            this.oyuncuPuanDataGridViewTextBoxColumn.DataPropertyName = "OyuncuPuan";
            this.oyuncuPuanDataGridViewTextBoxColumn.HeaderText = "OyuncuPuan";
            this.oyuncuPuanDataGridViewTextBoxColumn.Name = "oyuncuPuanDataGridViewTextBoxColumn";
            // 
            // puanBindingSource
            // 
            this.puanBindingSource.DataMember = "Puan";
            this.puanBindingSource.DataSource = this.veritabaniDataSet;
            // 
            // veritabaniDataSet
            // 
            this.veritabaniDataSet.DataSetName = "veritabaniDataSet";
            this.veritabaniDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // puanTableAdapter
            // 
            this.puanTableAdapter.ClearBeforeFill = true;
            // 
            // btndatagridkapat
            // 
            this.btndatagridkapat.BackgroundImage = global::Monopoly.Properties.Resources.kapat;
            this.btndatagridkapat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btndatagridkapat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btndatagridkapat.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btndatagridkapat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btndatagridkapat.Location = new System.Drawing.Point(788, 25);
            this.btndatagridkapat.Name = "btndatagridkapat";
            this.btndatagridkapat.Size = new System.Drawing.Size(64, 24);
            this.btndatagridkapat.TabIndex = 17;
            this.btndatagridkapat.UseVisualStyleBackColor = true;
            this.btndatagridkapat.Visible = false;
            this.btndatagridkapat.Click += new System.EventHandler(this.btndatagridkapat_Click);
            // 
            // AcilisFormu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleGreen;
            this.BackgroundImage = global::Monopoly.Properties.Resources.giris;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1006, 553);
            this.Controls.Add(this.btndatagridkapat);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1024, 600);
            this.MinimumSize = new System.Drawing.Size(1024, 600);
            this.Name = "AcilisFormu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AcilisFormu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AcilisFormu_FormClosing);
            this.Load += new System.EventHandler(this.AcilisFormu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.puanBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.veritabaniDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox txtOyuncu2;
        private System.Windows.Forms.Label lblOyuncu2;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox txtOyuncu1;
        private System.Windows.Forms.Label lblOyuncu1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private veritabaniDataSet veritabaniDataSet;
        private System.Windows.Forms.BindingSource puanBindingSource;
        private veritabaniDataSetTableAdapters.PuanTableAdapter puanTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn oyuncuAdiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn oyuncuPuanDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btndatagridkapat;

       
    }
}