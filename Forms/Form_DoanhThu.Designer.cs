namespace pc_market.Forms
{
    partial class Form_DoanhThu
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
        private void InitializeComponent() {
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.mskDen = new System.Windows.Forms.MaskedTextBox();
            this.mskTu = new System.Windows.Forms.MaskedTextBox();
            this.mskNgay = new System.Windows.Forms.MaskedTextBox();
            this.rdbKhoang = new System.Windows.Forms.RadioButton();
            this.rdbNgay = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.btnxem = new System.Windows.Forms.Button();
            this.btnxuatfile = new System.Windows.Forms.Button();
            this.btnthoat = new System.Windows.Forms.Button();
            this.txtdoanhthu = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label1.Location = new System.Drawing.Point(313, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(382, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "BÁO CÁO DOANH THU";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.mskDen);
            this.groupBox1.Controls.Add(this.mskTu);
            this.groupBox1.Controls.Add(this.mskNgay);
            this.groupBox1.Controls.Add(this.rdbKhoang);
            this.groupBox1.Controls.Add(this.rdbNgay);
            this.groupBox1.Location = new System.Drawing.Point(214, 91);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(578, 116);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm kiếm";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(348, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Đến";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(203, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Từ";
            // 
            // mskDen
            // 
            this.mskDen.Location = new System.Drawing.Point(381, 71);
            this.mskDen.Mask = "00/00/0000";
            this.mskDen.Name = "mskDen";
            this.mskDen.Size = new System.Drawing.Size(100, 20);
            this.mskDen.TabIndex = 4;
            this.mskDen.ValidatingType = typeof(System.DateTime);
            this.mskDen.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Validate_KeyPress);
            // 
            // mskTu
            // 
            this.mskTu.Location = new System.Drawing.Point(229, 71);
            this.mskTu.Mask = "00/00/0000";
            this.mskTu.Name = "mskTu";
            this.mskTu.Size = new System.Drawing.Size(100, 20);
            this.mskTu.TabIndex = 3;
            this.mskTu.ValidatingType = typeof(System.DateTime);
            this.mskTu.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Validate_KeyPress);
            // 
            // mskNgay
            // 
            this.mskNgay.Location = new System.Drawing.Point(203, 35);
            this.mskNgay.Mask = "00/00/0000";
            this.mskNgay.Name = "mskNgay";
            this.mskNgay.Size = new System.Drawing.Size(100, 20);
            this.mskNgay.TabIndex = 2;
            this.mskNgay.ValidatingType = typeof(System.DateTime);
            this.mskNgay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Validate_KeyPress);
            // 
            // rdbKhoang
            // 
            this.rdbKhoang.AutoSize = true;
            this.rdbKhoang.Location = new System.Drawing.Point(79, 72);
            this.rdbKhoang.Name = "rdbKhoang";
            this.rdbKhoang.Size = new System.Drawing.Size(96, 17);
            this.rdbKhoang.TabIndex = 1;
            this.rdbKhoang.TabStop = true;
            this.rdbKhoang.Text = "Theo Khoảng: ";
            this.rdbKhoang.UseVisualStyleBackColor = true;
            this.rdbKhoang.CheckedChanged += new System.EventHandler(this.rdbKhoang_CheckedChanged);
            // 
            // rdbNgay
            // 
            this.rdbNgay.AutoSize = true;
            this.rdbNgay.Location = new System.Drawing.Point(79, 36);
            this.rdbNgay.Name = "rdbNgay";
            this.rdbNgay.Size = new System.Drawing.Size(81, 17);
            this.rdbNgay.TabIndex = 0;
            this.rdbNgay.TabStop = true;
            this.rdbNgay.Text = "Theo Ngày:";
            this.rdbNgay.UseVisualStyleBackColor = true;
            this.rdbNgay.CheckedChanged += new System.EventHandler(this.rdbNgay_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(58, 417);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Tổng doanh thu:";
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(58, 223);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(879, 180);
            this.dataGridView.TabIndex = 5;
            // 
            // btnxem
            // 
            this.btnxem.BackgroundImage = global::pc_market.Properties.Resources.display;
            this.btnxem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnxem.Location = new System.Drawing.Point(644, 447);
            this.btnxem.Name = "btnxem";
            this.btnxem.Size = new System.Drawing.Size(75, 40);
            this.btnxem.TabIndex = 6;
            this.btnxem.Text = "Hiển thị";
            this.btnxem.UseVisualStyleBackColor = true;
            this.btnxem.Click += new System.EventHandler(this.btnxem_Click);
            // 
            // btnxuatfile
            // 
            this.btnxuatfile.Location = new System.Drawing.Point(740, 447);
            this.btnxuatfile.Name = "btnxuatfile";
            this.btnxuatfile.Size = new System.Drawing.Size(101, 40);
            this.btnxuatfile.TabIndex = 7;
            this.btnxuatfile.Text = "Xuất file Excel";
            this.btnxuatfile.UseVisualStyleBackColor = true;
            this.btnxuatfile.Click += new System.EventHandler(this.btnxuatfile_Click);
            // 
            // btnthoat
            // 
            this.btnthoat.BackgroundImage = global::pc_market.Properties.Resources.close;
            this.btnthoat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnthoat.Location = new System.Drawing.Point(862, 447);
            this.btnthoat.Name = "btnthoat";
            this.btnthoat.Size = new System.Drawing.Size(75, 40);
            this.btnthoat.TabIndex = 9;
            this.btnthoat.Text = "Thoát";
            this.btnthoat.UseVisualStyleBackColor = true;
            this.btnthoat.Click += new System.EventHandler(this.btnthoat_Click);
            // 
            // txtdoanhthu
            // 
            this.txtdoanhthu.Location = new System.Drawing.Point(150, 414);
            this.txtdoanhthu.Name = "txtdoanhthu";
            this.txtdoanhthu.ReadOnly = true;
            this.txtdoanhthu.Size = new System.Drawing.Size(183, 20);
            this.txtdoanhthu.TabIndex = 10;
            // 
            // Form_DoanhThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(999, 530);
            this.Controls.Add(this.txtdoanhthu);
            this.Controls.Add(this.btnthoat);
            this.Controls.Add(this.btnxuatfile);
            this.Controls.Add(this.btnxem);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form_DoanhThu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo cáo: Báo cáo doanh thu";
            this.Load += new System.EventHandler(this.FormDoanhthu_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox mskDen;
        private System.Windows.Forms.MaskedTextBox mskTu;
        private System.Windows.Forms.MaskedTextBox mskNgay;
        private System.Windows.Forms.RadioButton rdbKhoang;
        private System.Windows.Forms.RadioButton rdbNgay;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button btnxem;
        private System.Windows.Forms.Button btnxuatfile;
        private System.Windows.Forms.Button btnthoat;
        private System.Windows.Forms.TextBox txtdoanhthu;
    }
}