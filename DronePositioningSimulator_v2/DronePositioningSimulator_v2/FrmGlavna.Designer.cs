namespace DronePositioningSimulator_v2
{
    partial class FrmGlavna
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDodajDron = new System.Windows.Forms.Button();
            this.btnBoja = new System.Windows.Forms.Button();
            this.txtBrzina = new System.Windows.Forms.TextBox();
            this.txtSmjer = new System.Windows.Forms.TextBox();
            this.txtY = new System.Windows.Forms.TextBox();
            this.txtX = new System.Windows.Forms.TextBox();
            this.txtNaziv = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.dgvDronovi = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnKvadrat = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnStartStop = new System.Windows.Forms.Button();
            this.btnObrisi = new System.Windows.Forms.Button();
            this.btnCSV = new System.Windows.Forms.Button();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.txtBoja = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDronovi)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtBoja);
            this.groupBox1.Controls.Add(this.btnDodajDron);
            this.groupBox1.Controls.Add(this.btnBoja);
            this.groupBox1.Controls.Add(this.txtBrzina);
            this.groupBox1.Controls.Add(this.txtSmjer);
            this.groupBox1.Controls.Add(this.txtY);
            this.groupBox1.Controls.Add(this.txtX);
            this.groupBox1.Controls.Add(this.txtNaziv);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(29, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(453, 172);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Novi dron";
            // 
            // btnDodajDron
            // 
            this.btnDodajDron.Location = new System.Drawing.Point(310, 38);
            this.btnDodajDron.Name = "btnDodajDron";
            this.btnDodajDron.Size = new System.Drawing.Size(112, 104);
            this.btnDodajDron.TabIndex = 11;
            this.btnDodajDron.Text = "Dodaj dron";
            this.btnDodajDron.UseVisualStyleBackColor = true;
            this.btnDodajDron.Click += new System.EventHandler(this.btnDodajDron_Click);
            // 
            // btnBoja
            // 
            this.btnBoja.Location = new System.Drawing.Point(126, 134);
            this.btnBoja.Name = "btnBoja";
            this.btnBoja.Size = new System.Drawing.Size(27, 22);
            this.btnBoja.TabIndex = 10;
            this.btnBoja.UseVisualStyleBackColor = true;
            this.btnBoja.Click += new System.EventHandler(this.btnBoja_Click);
            // 
            // txtBrzina
            // 
            this.txtBrzina.Location = new System.Drawing.Point(126, 108);
            this.txtBrzina.Name = "txtBrzina";
            this.txtBrzina.Size = new System.Drawing.Size(143, 20);
            this.txtBrzina.TabIndex = 9;
            // 
            // txtSmjer
            // 
            this.txtSmjer.Location = new System.Drawing.Point(126, 82);
            this.txtSmjer.Name = "txtSmjer";
            this.txtSmjer.Size = new System.Drawing.Size(143, 20);
            this.txtSmjer.TabIndex = 8;
            // 
            // txtY
            // 
            this.txtY.Location = new System.Drawing.Point(207, 52);
            this.txtY.Name = "txtY";
            this.txtY.Size = new System.Drawing.Size(64, 20);
            this.txtY.TabIndex = 7;
            // 
            // txtX
            // 
            this.txtX.Location = new System.Drawing.Point(128, 52);
            this.txtX.Name = "txtX";
            this.txtX.Size = new System.Drawing.Size(64, 20);
            this.txtX.TabIndex = 6;
            // 
            // txtNaziv
            // 
            this.txtNaziv.Location = new System.Drawing.Point(128, 26);
            this.txtNaziv.Name = "txtNaziv";
            this.txtNaziv.Size = new System.Drawing.Size(143, 20);
            this.txtNaziv.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Brzina:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Smjer:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Boja:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Početno (X, Y):";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Naziv:";
            // 
            // dgvDronovi
            // 
            this.dgvDronovi.AllowUserToAddRows = false;
            this.dgvDronovi.AllowUserToDeleteRows = false;
            this.dgvDronovi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDronovi.Location = new System.Drawing.Point(29, 231);
            this.dgvDronovi.Name = "dgvDronovi";
            this.dgvDronovi.ReadOnly = true;
            this.dgvDronovi.Size = new System.Drawing.Size(680, 176);
            this.dgvDronovi.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnKvadrat);
            this.groupBox2.Location = new System.Drawing.Point(339, 432);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(370, 157);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Upravljanje formacijom";
            // 
            // btnKvadrat
            // 
            this.btnKvadrat.Location = new System.Drawing.Point(48, 39);
            this.btnKvadrat.Name = "btnKvadrat";
            this.btnKvadrat.Size = new System.Drawing.Size(95, 41);
            this.btnKvadrat.TabIndex = 0;
            this.btnKvadrat.Text = "Kvadrat";
            this.btnKvadrat.UseVisualStyleBackColor = true;
            this.btnKvadrat.Click += new System.EventHandler(this.btnKvadrat_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnReset);
            this.groupBox3.Controls.Add(this.btnStartStop);
            this.groupBox3.Location = new System.Drawing.Point(35, 432);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(275, 156);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Upravljanje simulacijom";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(37, 95);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(110, 41);
            this.btnReset.TabIndex = 1;
            this.btnReset.Text = "Resetiraj";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnStartStop
            // 
            this.btnStartStop.Location = new System.Drawing.Point(37, 37);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(110, 43);
            this.btnStartStop.TabIndex = 0;
            this.btnStartStop.Text = "Start";
            this.btnStartStop.UseVisualStyleBackColor = true;
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
            // 
            // btnObrisi
            // 
            this.btnObrisi.Location = new System.Drawing.Point(535, 172);
            this.btnObrisi.Name = "btnObrisi";
            this.btnObrisi.Size = new System.Drawing.Size(154, 29);
            this.btnObrisi.TabIndex = 4;
            this.btnObrisi.Text = "Obriši označenog";
            this.btnObrisi.UseVisualStyleBackColor = true;
            this.btnObrisi.Click += new System.EventHandler(this.btnObrisi_Click);
            // 
            // btnCSV
            // 
            this.btnCSV.Location = new System.Drawing.Point(535, 39);
            this.btnCSV.Name = "btnCSV";
            this.btnCSV.Size = new System.Drawing.Size(154, 33);
            this.btnCSV.TabIndex = 5;
            this.btnCSV.Text = "Učitaj CSV";
            this.btnCSV.UseVisualStyleBackColor = true;
            this.btnCSV.Click += new System.EventHandler(this.btnCSV_Click);
            // 
            // ofd
            // 
            this.ofd.DefaultExt = "csv";
            this.ofd.Filter = "CSV datoteka|*.csv";
            this.ofd.Title = "Učitaj datoteku dronova";
            this.ofd.FileOk += new System.ComponentModel.CancelEventHandler(this.ofd_FileOk);
            // 
            // txtBoja
            // 
            this.txtBoja.Location = new System.Drawing.Point(160, 135);
            this.txtBoja.Name = "txtBoja";
            this.txtBoja.Size = new System.Drawing.Size(109, 20);
            this.txtBoja.TabIndex = 12;
            // 
            // FrmGlavna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 615);
            this.Controls.Add(this.btnCSV);
            this.Controls.Add(this.btnObrisi);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dgvDronovi);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmGlavna";
            this.Text = "Glavna";
            this.Load += new System.EventHandler(this.FrmGlavna_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDronovi)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDodajDron;
        private System.Windows.Forms.Button btnBoja;
        private System.Windows.Forms.TextBox txtBrzina;
        private System.Windows.Forms.TextBox txtSmjer;
        private System.Windows.Forms.TextBox txtY;
        private System.Windows.Forms.TextBox txtX;
        private System.Windows.Forms.TextBox txtNaziv;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.DataGridView dgvDronovi;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnKvadrat;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnStartStop;
        private System.Windows.Forms.Button btnObrisi;
        private System.Windows.Forms.Button btnCSV;
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.TextBox txtBoja;
    }
}

