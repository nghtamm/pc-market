namespace pc_market.Forms
{
    partial class frm_NCC
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMancc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTenncc = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDiachi = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dgridNCC = new System.Windows.Forms.DataGridView();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnBoqua = new System.Windows.Forms.Button();
            this.btnTimkiem = new System.Windows.Forms.Button();
            this.btnHienthids = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.txtDienthoai = new System.Windows.Forms.TextBox();
            this.btnXuatexcel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgridNCC)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(425, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "NHÀ CUNG CẤP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(83, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mã NCC";
            // 
            // txtMancc
            // 
            this.txtMancc.Location = new System.Drawing.Point(187, 74);
            this.txtMancc.Name = "txtMancc";
            this.txtMancc.Size = new System.Drawing.Size(250, 22);
            this.txtMancc.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(491, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Điện thoại";
            // 
            // txtTenncc
            // 
            this.txtTenncc.Location = new System.Drawing.Point(187, 119);
            this.txtTenncc.Name = "txtTenncc";
            this.txtTenncc.Size = new System.Drawing.Size(250, 22);
            this.txtTenncc.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(83, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "Tên NCC";
            // 
            // txtDiachi
            // 
            this.txtDiachi.Location = new System.Drawing.Point(595, 74);
            this.txtDiachi.Name = "txtDiachi";
            this.txtDiachi.Size = new System.Drawing.Size(334, 22);
            this.txtDiachi.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(491, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 16);
            this.label5.TabIndex = 7;
            this.label5.Text = "Địa chỉ";
            // 
            // dgridNCC
            // 
            this.dgridNCC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgridNCC.Location = new System.Drawing.Point(51, 261);
            this.dgridNCC.Name = "dgridNCC";
            this.dgridNCC.RowHeadersWidth = 51;
            this.dgridNCC.RowTemplate.Height = 24;
            this.dgridNCC.Size = new System.Drawing.Size(931, 236);
            this.dgridNCC.TabIndex = 9;
            this.dgridNCC.Click += new System.EventHandler(this.dgridNCC_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(56, 197);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(91, 45);
            this.btnThem.TabIndex = 10;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(146, 197);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(91, 45);
            this.btnXoa.TabIndex = 11;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(236, 197);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(91, 45);
            this.btnSua.TabIndex = 12;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(326, 197);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(91, 45);
            this.btnLuu.TabIndex = 13;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnBoqua
            // 
            this.btnBoqua.Location = new System.Drawing.Point(416, 197);
            this.btnBoqua.Name = "btnBoqua";
            this.btnBoqua.Size = new System.Drawing.Size(91, 45);
            this.btnBoqua.TabIndex = 14;
            this.btnBoqua.Text = "Bỏ qua";
            this.btnBoqua.UseVisualStyleBackColor = true;
            this.btnBoqua.Click += new System.EventHandler(this.btnBoqua_Click);
            // 
            // btnTimkiem
            // 
            this.btnTimkiem.Location = new System.Drawing.Point(507, 197);
            this.btnTimkiem.Name = "btnTimkiem";
            this.btnTimkiem.Size = new System.Drawing.Size(91, 45);
            this.btnTimkiem.TabIndex = 15;
            this.btnTimkiem.Text = "Tìm kiếm";
            this.btnTimkiem.UseVisualStyleBackColor = true;
            this.btnTimkiem.Click += new System.EventHandler(this.btnTimkiem_Click);
            // 
            // btnHienthids
            // 
            this.btnHienthids.Location = new System.Drawing.Point(599, 198);
            this.btnHienthids.Name = "btnHienthids";
            this.btnHienthids.Size = new System.Drawing.Size(100, 45);
            this.btnHienthids.TabIndex = 16;
            this.btnHienthids.Text = "Hiển thị DS";
            this.btnHienthids.UseVisualStyleBackColor = true;
            this.btnHienthids.Click += new System.EventHandler(this.btnHienthids_Click);
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(700, 198);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(91, 45);
            this.btnDong.TabIndex = 17;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // txtDienthoai
            // 
            this.txtDienthoai.Location = new System.Drawing.Point(595, 121);
            this.txtDienthoai.Name = "txtDienthoai";
            this.txtDienthoai.Size = new System.Drawing.Size(334, 22);
            this.txtDienthoai.TabIndex = 18;
            // 
            // btnXuatexcel
            // 
            this.btnXuatexcel.Location = new System.Drawing.Point(891, 197);
            this.btnXuatexcel.Name = "btnXuatexcel";
            this.btnXuatexcel.Size = new System.Drawing.Size(91, 45);
            this.btnXuatexcel.TabIndex = 20;
            this.btnXuatexcel.Text = "Xuất excel";
            this.btnXuatexcel.UseVisualStyleBackColor = true;
            this.btnXuatexcel.Click += new System.EventHandler(this.btnXuatexcel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(51, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(931, 131);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin nhà cung cấp";
            // 
            // frm_NCC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1054, 533);
            this.Controls.Add(this.btnXuatexcel);
            this.Controls.Add(this.txtDienthoai);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnHienthids);
            this.Controls.Add(this.btnTimkiem);
            this.Controls.Add(this.btnBoqua);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.dgridNCC);
            this.Controls.Add(this.txtDiachi);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTenncc);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtMancc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Name = "frm_NCC";
            this.Text = "Nhà cung cấp";
            this.Load += new System.EventHandler(this.frm_NCC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgridNCC)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMancc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTenncc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDiachi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgridNCC;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnBoqua;
        private System.Windows.Forms.Button btnTimkiem;
        private System.Windows.Forms.Button btnHienthids;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.TextBox txtDienthoai;
        private System.Windows.Forms.Button btnXuatexcel;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}