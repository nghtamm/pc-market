namespace pc_market.Forms
{
    partial class frm_GPU
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
            this.btnXuatexcel = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.btnHienthids = new System.Windows.Forms.Button();
            this.btnTimkiem = new System.Windows.Forms.Button();
            this.btnBoqua = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.dgridGPU = new System.Windows.Forms.DataGridView();
            this.txtTengpu = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMagpu = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtLoaigpu = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDungluong = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cboMahsx = new System.Windows.Forms.ComboBox();
            this.txtMota = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgridGPU)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnXuatexcel
            // 
            this.btnXuatexcel.Location = new System.Drawing.Point(940, 216);
            this.btnXuatexcel.Name = "btnXuatexcel";
            this.btnXuatexcel.Size = new System.Drawing.Size(91, 45);
            this.btnXuatexcel.TabIndex = 40;
            this.btnXuatexcel.Text = "Xuất excel";
            this.btnXuatexcel.UseVisualStyleBackColor = true;
            this.btnXuatexcel.Click += new System.EventHandler(this.btnXuatexcel_Click);
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(778, 217);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(91, 45);
            this.btnDong.TabIndex = 38;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // btnHienthids
            // 
            this.btnHienthids.Location = new System.Drawing.Point(677, 217);
            this.btnHienthids.Name = "btnHienthids";
            this.btnHienthids.Size = new System.Drawing.Size(100, 45);
            this.btnHienthids.TabIndex = 37;
            this.btnHienthids.Text = "Hiển thị DS";
            this.btnHienthids.UseVisualStyleBackColor = true;
            this.btnHienthids.Click += new System.EventHandler(this.btnHienthids_Click);
            // 
            // btnTimkiem
            // 
            this.btnTimkiem.Location = new System.Drawing.Point(585, 216);
            this.btnTimkiem.Name = "btnTimkiem";
            this.btnTimkiem.Size = new System.Drawing.Size(91, 45);
            this.btnTimkiem.TabIndex = 36;
            this.btnTimkiem.Text = "Tìm kiếm";
            this.btnTimkiem.UseVisualStyleBackColor = true;
            this.btnTimkiem.Click += new System.EventHandler(this.btnTimkiem_Click);
            // 
            // btnBoqua
            // 
            this.btnBoqua.Location = new System.Drawing.Point(494, 216);
            this.btnBoqua.Name = "btnBoqua";
            this.btnBoqua.Size = new System.Drawing.Size(91, 45);
            this.btnBoqua.TabIndex = 35;
            this.btnBoqua.Text = "Bỏ qua";
            this.btnBoqua.UseVisualStyleBackColor = true;
            this.btnBoqua.Click += new System.EventHandler(this.btnBoqua_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(404, 216);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(91, 45);
            this.btnLuu.TabIndex = 34;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(314, 216);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(91, 45);
            this.btnSua.TabIndex = 33;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(224, 216);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(91, 45);
            this.btnXoa.TabIndex = 32;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(134, 216);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(91, 45);
            this.btnThem.TabIndex = 31;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // dgridGPU
            // 
            this.dgridGPU.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgridGPU.Location = new System.Drawing.Point(136, 279);
            this.dgridGPU.Name = "dgridGPU";
            this.dgridGPU.RowHeadersWidth = 51;
            this.dgridGPU.RowTemplate.Height = 24;
            this.dgridGPU.Size = new System.Drawing.Size(895, 235);
            this.dgridGPU.TabIndex = 30;
            this.dgridGPU.Click += new System.EventHandler(this.dgridGPU_Click);
            // 
            // txtTengpu
            // 
            this.txtTengpu.Location = new System.Drawing.Point(176, 56);
            this.txtTengpu.Name = "txtTengpu";
            this.txtTengpu.Size = new System.Drawing.Size(250, 22);
            this.txtTengpu.TabIndex = 27;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(56, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 16);
            this.label4.TabIndex = 26;
            this.label4.Text = "Tên GPU";
            // 
            // txtMagpu
            // 
            this.txtMagpu.Location = new System.Drawing.Point(312, 69);
            this.txtMagpu.Name = "txtMagpu";
            this.txtMagpu.Size = new System.Drawing.Size(250, 22);
            this.txtMagpu.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 16);
            this.label2.TabIndex = 23;
            this.label2.Text = "Mã GPU";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(463, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(252, 26);
            this.label1.TabIndex = 22;
            this.label1.Text = "CARD ĐỒ HỌA - GPU";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtMota);
            this.groupBox1.Controls.Add(this.cboMahsx);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtDungluong);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtLoaigpu);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtTengpu);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(136, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(895, 156);
            this.groupBox1.TabIndex = 41;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin chung";
            // 
            // txtLoaigpu
            // 
            this.txtLoaigpu.Location = new System.Drawing.Point(176, 84);
            this.txtLoaigpu.Name = "txtLoaigpu";
            this.txtLoaigpu.Size = new System.Drawing.Size(250, 22);
            this.txtLoaigpu.TabIndex = 29;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(56, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 16);
            this.label3.TabIndex = 28;
            this.label3.Text = "Loại GPU";
            // 
            // txtDungluong
            // 
            this.txtDungluong.Location = new System.Drawing.Point(176, 112);
            this.txtDungluong.Name = "txtDungluong";
            this.txtDungluong.Size = new System.Drawing.Size(250, 22);
            this.txtDungluong.TabIndex = 31;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(56, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 16);
            this.label5.TabIndex = 30;
            this.label5.Text = "Dung lượng";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(471, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 16);
            this.label6.TabIndex = 32;
            this.label6.Text = "Hãng sản xuất";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(471, 59);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 16);
            this.label8.TabIndex = 44;
            this.label8.Text = "Mô tả";
            // 
            // cboMahsx
            // 
            this.cboMahsx.FormattingEnabled = true;
            this.cboMahsx.Location = new System.Drawing.Point(591, 26);
            this.cboMahsx.Name = "cboMahsx";
            this.cboMahsx.Size = new System.Drawing.Size(250, 24);
            this.cboMahsx.TabIndex = 48;
            // 
            // txtMota
            // 
            this.txtMota.Location = new System.Drawing.Point(591, 59);
            this.txtMota.Name = "txtMota";
            this.txtMota.Size = new System.Drawing.Size(250, 75);
            this.txtMota.TabIndex = 49;
            this.txtMota.Text = "";
            // 
            // frm_GPU
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1233, 542);
            this.Controls.Add(this.btnXuatexcel);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnHienthids);
            this.Controls.Add(this.btnTimkiem);
            this.Controls.Add(this.btnBoqua);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.dgridGPU);
            this.Controls.Add(this.txtMagpu);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Name = "frm_GPU";
            this.Text = "Card đồ họa - GPU";
            this.Load += new System.EventHandler(this.frm_GPU_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgridGPU)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnXuatexcel;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Button btnHienthids;
        private System.Windows.Forms.Button btnTimkiem;
        private System.Windows.Forms.Button btnBoqua;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.DataGridView dgridGPU;
        private System.Windows.Forms.TextBox txtTengpu;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMagpu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDungluong;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtLoaigpu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboMahsx;
        private System.Windows.Forms.RichTextBox txtMota;
    }
}