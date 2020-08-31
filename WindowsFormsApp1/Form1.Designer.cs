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
            this.lstListe = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudAy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudYil)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbIl
            // 
            this.cmbIl.FormattingEnabled = true;
            this.cmbIl.Location = new System.Drawing.Point(94, 40);
            this.cmbIl.Name = "cmbIl";
            this.cmbIl.Size = new System.Drawing.Size(121, 21);
            this.cmbIl.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "İL";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "AY";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "YIL";
            // 
            // nudAy
            // 
            this.nudAy.Location = new System.Drawing.Point(94, 79);
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
            this.nudYil.Location = new System.Drawing.Point(94, 115);
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
            this.btnAl.Location = new System.Drawing.Point(94, 156);
            this.btnAl.Name = "btnAl";
            this.btnAl.Size = new System.Drawing.Size(120, 33);
            this.btnAl.TabIndex = 8;
            this.btnAl.Text = "E-ICMAL NOLARI AL";
            this.btnAl.UseVisualStyleBackColor = true;
            this.btnAl.Click += new System.EventHandler(this.btnAl_Click_1);
            // 
            // lstListe
            // 
            this.lstListe.FormattingEnabled = true;
            this.lstListe.Location = new System.Drawing.Point(230, 40);
            this.lstListe.Name = "lstListe";
            this.lstListe.Size = new System.Drawing.Size(500, 381);
            this.lstListe.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 434);
            this.Controls.Add(this.lstListe);
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
        private System.Windows.Forms.ListBox lstListe;
    }
}

