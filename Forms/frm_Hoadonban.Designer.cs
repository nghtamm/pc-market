namespace pc_market.Forms
{
    partial class frm_Hoadonban
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
            this.txtMahdb = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTenmayvt = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSoluong = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDongia = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtThanhtien = new System.Windows.Forms.TextBox();
            this.dgridHoadonban = new System.Windows.Forms.DataGridView();
            this.label11 = new System.Windows.Forms.Label();
            this.txtTongtien = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtManv = new System.Windows.Forms.ComboBox();
            this.cboMakhach = new System.Windows.Forms.ComboBox();
            this.cboMamayvt = new System.Windows.Forms.ComboBox();
            this.mskNgayban = new System.Windows.Forms.MaskedTextBox();
            this.txtTimkiem = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.btnTimkiem = new System.Windows.Forms.Button();
            this.btnThemhd = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnHuyhd = new System.Windows.Forms.Button();
            this.btnInhd = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgridHoadonban)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(549, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(253, 26);
            this.label1.TabIndex = 23;
            this.label1.Text = "HÓA ĐƠN BÁN HÀNG";
            // 
            // txtMahdb
            // 
            this.txtMahdb.Location = new System.Drawing.Point(123, 29);
            this.txtMahdb.Name = "txtMahdb";
            this.txtMahdb.Size = new System.Drawing.Size(232, 22);
            this.txtMahdb.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 16);
            this.label2.TabIndex = 25;
            this.label2.Text = "Mã hóa đơn";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.mskNgayban);
            this.groupBox1.Controls.Add(this.cboMakhach);
            this.groupBox1.Controls.Add(this.txtManv);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtMahdb);
            this.groupBox1.Location = new System.Drawing.Point(51, 68);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(397, 184);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin chung";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 16);
            this.label3.TabIndex = 27;
            this.label3.Text = "Ngày bán";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 16);
            this.label4.TabIndex = 29;
            this.label4.Text = "Mã NV";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 132);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 16);
            this.label5.TabIndex = 31;
            this.label5.Text = "Mã khách";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cboMamayvt);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtThanhtien);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtDongia);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtSoluong);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtTenmayvt);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(52, 273);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(396, 204);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin các mặt hàng";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(32, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 16);
            this.label6.TabIndex = 33;
            this.label6.Text = "Mã máy VT";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(32, 63);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 16);
            this.label7.TabIndex = 35;
            this.label7.Text = "Tên máy VT";
            // 
            // txtTenmayvt
            // 
            this.txtTenmayvt.Location = new System.Drawing.Point(125, 60);
            this.txtTenmayvt.Name = "txtTenmayvt";
            this.txtTenmayvt.Size = new System.Drawing.Size(226, 22);
            this.txtTenmayvt.TabIndex = 34;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(32, 95);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 16);
            this.label8.TabIndex = 37;
            this.label8.Text = "Số lượng";
            // 
            // txtSoluong
            // 
            this.txtSoluong.Location = new System.Drawing.Point(125, 92);
            this.txtSoluong.Name = "txtSoluong";
            this.txtSoluong.Size = new System.Drawing.Size(223, 22);
            this.txtSoluong.TabIndex = 36;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(32, 126);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 16);
            this.label9.TabIndex = 39;
            this.label9.Text = "Đơn giá";
            // 
            // txtDongia
            // 
            this.txtDongia.Location = new System.Drawing.Point(125, 123);
            this.txtDongia.Name = "txtDongia";
            this.txtDongia.Size = new System.Drawing.Size(223, 22);
            this.txtDongia.TabIndex = 38;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(32, 157);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 16);
            this.label10.TabIndex = 41;
            this.label10.Text = "Thành tiền";
            // 
            // txtThanhtien
            // 
            this.txtThanhtien.Location = new System.Drawing.Point(125, 154);
            this.txtThanhtien.Name = "txtThanhtien";
            this.txtThanhtien.Size = new System.Drawing.Size(223, 22);
            this.txtThanhtien.TabIndex = 40;
            // 
            // dgridHoadonban
            // 
            this.dgridHoadonban.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgridHoadonban.Location = new System.Drawing.Point(500, 100);
            this.dgridHoadonban.Name = "dgridHoadonban";
            this.dgridHoadonban.RowHeadersWidth = 51;
            this.dgridHoadonban.RowTemplate.Height = 24;
            this.dgridHoadonban.Size = new System.Drawing.Size(763, 256);
            this.dgridHoadonban.TabIndex = 28;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(1055, 381);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 16);
            this.label11.TabIndex = 43;
            this.label11.Text = "Tổng tiền";
            // 
            // txtTongtien
            // 
            this.txtTongtien.Location = new System.Drawing.Point(1124, 378);
            this.txtTongtien.Name = "txtTongtien";
            this.txtTongtien.Size = new System.Drawing.Size(135, 22);
            this.txtTongtien.TabIndex = 42;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(497, 384);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(161, 16);
            this.label12.TabIndex = 44;
            this.label12.Text = "Kích đúp một dòng để xóa";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(497, 408);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(66, 16);
            this.label13.TabIndex = 45;
            this.label13.Text = "Bằng chữ:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(569, 408);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(14, 16);
            this.label14.TabIndex = 46;
            this.label14.Text = "0";
            // 
            // txtManv
            // 
            this.txtManv.FormattingEnabled = true;
            this.txtManv.Location = new System.Drawing.Point(123, 97);
            this.txtManv.Name = "txtManv";
            this.txtManv.Size = new System.Drawing.Size(229, 24);
            this.txtManv.TabIndex = 47;
            // 
            // cboMakhach
            // 
            this.cboMakhach.FormattingEnabled = true;
            this.cboMakhach.Location = new System.Drawing.Point(123, 129);
            this.cboMakhach.Name = "cboMakhach";
            this.cboMakhach.Size = new System.Drawing.Size(229, 24);
            this.cboMakhach.TabIndex = 48;
            // 
            // cboMamayvt
            // 
            this.cboMamayvt.FormattingEnabled = true;
            this.cboMamayvt.Location = new System.Drawing.Point(125, 29);
            this.cboMamayvt.Name = "cboMamayvt";
            this.cboMamayvt.Size = new System.Drawing.Size(226, 24);
            this.cboMamayvt.TabIndex = 48;
            // 
            // mskNgayban
            // 
            this.mskNgayban.Location = new System.Drawing.Point(123, 61);
            this.mskNgayban.Name = "mskNgayban";
            this.mskNgayban.Size = new System.Drawing.Size(232, 22);
            this.mskNgayban.TabIndex = 47;
            // 
            // txtTimkiem
            // 
            this.txtTimkiem.FormattingEnabled = true;
            this.txtTimkiem.Location = new System.Drawing.Point(649, 63);
            this.txtTimkiem.Name = "txtTimkiem";
            this.txtTimkiem.Size = new System.Drawing.Size(172, 24);
            this.txtTimkiem.TabIndex = 50;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(497, 68);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(134, 16);
            this.label15.TabIndex = 49;
            this.label15.Text = "Tìm kiếm mã máy VT";
            // 
            // btnTimkiem
            // 
            this.btnTimkiem.Location = new System.Drawing.Point(837, 63);
            this.btnTimkiem.Name = "btnTimkiem";
            this.btnTimkiem.Size = new System.Drawing.Size(86, 24);
            this.btnTimkiem.TabIndex = 51;
            this.btnTimkiem.Text = "Tìm kiếm";
            this.btnTimkiem.UseVisualStyleBackColor = true;
            // 
            // btnThemhd
            // 
            this.btnThemhd.Location = new System.Drawing.Point(705, 442);
            this.btnThemhd.Name = "btnThemhd";
            this.btnThemhd.Size = new System.Drawing.Size(106, 46);
            this.btnThemhd.TabIndex = 52;
            this.btnThemhd.Text = "Thêm hóa đơn";
            this.btnThemhd.UseVisualStyleBackColor = true;
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(817, 442);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(106, 46);
            this.btnLuu.TabIndex = 53;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            // 
            // btnHuyhd
            // 
            this.btnHuyhd.Location = new System.Drawing.Point(929, 442);
            this.btnHuyhd.Name = "btnHuyhd";
            this.btnHuyhd.Size = new System.Drawing.Size(106, 46);
            this.btnHuyhd.TabIndex = 54;
            this.btnHuyhd.Text = "Hủy hóa đơn";
            this.btnHuyhd.UseVisualStyleBackColor = true;
            // 
            // btnInhd
            // 
            this.btnInhd.Location = new System.Drawing.Point(1041, 442);
            this.btnInhd.Name = "btnInhd";
            this.btnInhd.Size = new System.Drawing.Size(106, 46);
            this.btnInhd.TabIndex = 55;
            this.btnInhd.Text = "In hóa đơn";
            this.btnInhd.UseVisualStyleBackColor = true;
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(1153, 442);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(106, 46);
            this.btnDong.TabIndex = 56;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            // 
            // frm_Hoadonban
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1315, 500);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnInhd);
            this.Controls.Add(this.btnHuyhd);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnThemhd);
            this.Controls.Add(this.btnTimkiem);
            this.Controls.Add(this.txtTimkiem);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.dgridHoadonban);
            this.Controls.Add(this.txtTongtien);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Name = "frm_Hoadonban";
            this.Text = "frm_Hoadonban";
            this.Load += new System.EventHandler(this.frm_Hoadonban_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgridHoadonban)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMahdb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtThanhtien;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtDongia;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSoluong;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTenmayvt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgridHoadonban;
        private System.Windows.Forms.MaskedTextBox mskNgayban;
        private System.Windows.Forms.ComboBox cboMakhach;
        private System.Windows.Forms.ComboBox txtManv;
        private System.Windows.Forms.ComboBox cboMamayvt;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtTongtien;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox txtTimkiem;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnTimkiem;
        private System.Windows.Forms.Button btnThemhd;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnHuyhd;
        private System.Windows.Forms.Button btnInhd;
        private System.Windows.Forms.Button btnDong;
    }
}