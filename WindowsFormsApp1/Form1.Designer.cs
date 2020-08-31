namespace WindowsFormsApp1
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
            this.cmbIl = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nudAy = new System.Windows.Forms.NumericUpDown();
            this.nudYil = new System.Windows.Forms.NumericUpDown();
            this.btnAl = new System.Windows.Forms.Button();
            this.dgvListe = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.cmbIlceListesi = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudAy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudYil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListe)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbIl
            // 
            this.cmbIl.FormattingEnabled = true;
            this.cmbIl.Location = new System.Drawing.Point(71, 157);
            this.cmbIl.Name = "cmbIl";
            this.cmbIl.Size = new System.Drawing.Size(121, 21);
            this.cmbIl.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 160);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "İL";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 196);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "AY";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 232);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "YIL";
            // 
            // nudAy
            // 
            this.nudAy.Location = new System.Drawing.Point(71, 196);
            this.nudAy.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.nudAy.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudAy.Name = "nudAy";
            this.nudAy.Size = new System.Drawing.Size(120, 20);
            this.nudAy.TabIndex = 6;
            this.nudAy.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudYil
            // 
            this.nudYil.Location = new System.Drawing.Point(71, 232);
            this.nudYil.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.nudYil.Minimum = new decimal(new int[] {
            2020,
            0,
            0,
            0});
            this.nudYil.Name = "nudYil";
            this.nudYil.Size = new System.Drawing.Size(120, 20);
            this.nudYil.TabIndex = 7;
            this.nudYil.Value = new decimal(new int[] {
            2020,
            0,
            0,
            0});
            // 
            // btnAl
            // 
            this.btnAl.Location = new System.Drawing.Point(71, 273);
            this.btnAl.Name = "btnAl";
            this.btnAl.Size = new System.Drawing.Size(120, 33);
            this.btnAl.TabIndex = 8;
            this.btnAl.Text = "SERİ NOLARI GETİR";
            this.btnAl.UseVisualStyleBackColor = true;
            this.btnAl.Click += new System.EventHandler(this.btnAl_Click_1);
            // 
            // dgvListe
            // 
            this.dgvListe.AllowUserToAddRows = false;
            this.dgvListe.AllowUserToDeleteRows = false;
            this.dgvListe.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvListe.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvListe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListe.Location = new System.Drawing.Point(220, 40);
            this.dgvListe.MultiSelect = false;
            this.dgvListe.Name = "dgvListe";
            this.dgvListe.ReadOnly = true;
            this.dgvListe.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListe.Size = new System.Drawing.Size(328, 453);
            this.dgvListe.TabIndex = 12;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(768, 208);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 65);
            this.button1.TabIndex = 14;
            this.button1.Text = "E-İCMAL NOLARI ATA";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmbIlceListesi
            // 
            this.cmbIlceListesi.FormattingEnabled = true;
            this.cmbIlceListesi.Location = new System.Drawing.Point(565, 230);
            this.cmbIlceListesi.Name = "cmbIlceListesi";
            this.cmbIlceListesi.Size = new System.Drawing.Size(197, 21);
            this.cmbIlceListesi.TabIndex = 15;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 521);
            this.Controls.Add(this.cmbIlceListesi);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvListe);
            this.Controls.Add(this.btnAl);
            this.Controls.Add(this.nudYil);
            this.Controls.Add(this.nudAy);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbIl);
            this.Name = "Form1";
            this.Text = "E-İCMAL NO";
            ((System.ComponentModel.ISupportInitialize)(this.nudAy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudYil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListe)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbIl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudAy;
        private System.Windows.Forms.NumericUpDown nudYil;
        private System.Windows.Forms.Button btnAl;
        private System.Windows.Forms.DataGridView dgvListe;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cmbIlceListesi;
    }
}

