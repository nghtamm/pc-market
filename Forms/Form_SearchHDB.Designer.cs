namespace pc_market.Forms
{
    partial class Form_SearchHDB
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
            this.btnDong = new System.Windows.Forms.Button();
            this.btnTimlai = new System.Windows.Forms.Button();
            this.btnTimkiem = new System.Windows.Forms.Button();
            this.DataGridView = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.txtThang = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtManhanvien = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtMakhach = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtMaHDBan1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTongtien = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtNam = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDong
            // 
            this.btnDong.BackgroundImage = global::pc_market.Properties.Resources.close;
            this.btnDong.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDong.Location = new System.Drawing.Point(435, 362);
            this.btnDong.Margin = new System.Windows.Forms.Padding(2);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(80, 37);
            this.btnDong.TabIndex = 65;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // btnTimlai
            // 
            this.btnTimlai.BackgroundImage = global::pc_market.Properties.Resources.skip;
            this.btnTimlai.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnTimlai.Location = new System.Drawing.Point(351, 362);
            this.btnTimlai.Margin = new System.Windows.Forms.Padding(2);
            this.btnTimlai.Name = "btnTimlai";
            this.btnTimlai.Size = new System.Drawing.Size(80, 37);
            this.btnTimlai.TabIndex = 64;
            this.btnTimlai.Text = "Tìm lại";
            this.btnTimlai.UseVisualStyleBackColor = true;
            this.btnTimlai.Click += new System.EventHandler(this.btnTimlai_Click);
            // 
            // btnTimkiem
            // 
            this.btnTimkiem.BackgroundImage = global::pc_market.Properties.Resources.search;
            this.btnTimkiem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnTimkiem.Location = new System.Drawing.Point(263, 362);
            this.btnTimkiem.Margin = new System.Windows.Forms.Padding(2);
            this.btnTimkiem.Name = "btnTimkiem";
            this.btnTimkiem.Size = new System.Drawing.Size(84, 37);
            this.btnTimkiem.TabIndex = 63;
            this.btnTimkiem.Text = "Tìm kiếm";
            this.btnTimkiem.UseVisualStyleBackColor = true;
            this.btnTimkiem.Click += new System.EventHandler(this.btnTimkiem_Click);
            // 
            // DataGridView
            // 
            this.DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView.Location = new System.Drawing.Point(111, 179);
            this.DataGridView.Margin = new System.Windows.Forms.Padding(2);
            this.DataGridView.Name = "DataGridView";
            this.DataGridView.RowHeadersWidth = 51;
            this.DataGridView.RowTemplate.Height = 24;
            this.DataGridView.Size = new System.Drawing.Size(560, 149);
            this.DataGridView.TabIndex = 58;
            this.DataGridView.DoubleClick += new System.EventHandler(this.DataGridView_DoubleClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(144, 92);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 33;
            this.label6.Text = "Mã hóa đơn";
            // 
            // txtThang
            // 
            this.txtThang.Location = new System.Drawing.Point(219, 115);
            this.txtThang.Margin = new System.Windows.Forms.Padding(2);
            this.txtThang.Name = "txtThang";
            this.txtThang.Size = new System.Drawing.Size(52, 20);
            this.txtThang.TabIndex = 34;
            this.txtThang.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTongtien_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(144, 118);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 35;
            this.label7.Text = "Tháng";
            // 
            // txtManhanvien
            // 
            this.txtManhanvien.Location = new System.Drawing.Point(480, 90);
            this.txtManhanvien.Margin = new System.Windows.Forms.Padding(2);
            this.txtManhanvien.Name = "txtManhanvien";
            this.txtManhanvien.Size = new System.Drawing.Size(153, 20);
            this.txtManhanvien.TabIndex = 36;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(398, 92);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 13);
            this.label8.TabIndex = 37;
            this.label8.Text = "Mã nhân viên";
            // 
            // txtMakhach
            // 
            this.txtMakhach.Location = new System.Drawing.Point(480, 115);
            this.txtMakhach.Margin = new System.Windows.Forms.Padding(2);
            this.txtMakhach.Name = "txtMakhach";
            this.txtMakhach.Size = new System.Drawing.Size(153, 20);
            this.txtMakhach.TabIndex = 38;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(398, 118);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 13);
            this.label9.TabIndex = 39;
            this.label9.Text = "Mã khách hàng";
            // 
            // txtMaHDBan1
            // 
            this.txtMaHDBan1.Location = new System.Drawing.Point(219, 89);
            this.txtMaHDBan1.Margin = new System.Windows.Forms.Padding(2);
            this.txtMaHDBan1.Name = "txtMaHDBan1";
            this.txtMaHDBan1.Size = new System.Drawing.Size(150, 20);
            this.txtMaHDBan1.TabIndex = 42;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(398, 144);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 69;
            this.label1.Text = "Tổng tiền";
            // 
            // txtTongtien
            // 
            this.txtTongtien.Location = new System.Drawing.Point(480, 141);
            this.txtTongtien.Margin = new System.Windows.Forms.Padding(2);
            this.txtTongtien.Name = "txtTongtien";
            this.txtTongtien.Size = new System.Drawing.Size(119, 20);
            this.txtTongtien.TabIndex = 68;
            this.txtTongtien.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTongtien_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(286, 118);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 13);
            this.label10.TabIndex = 71;
            this.label10.Text = "Năm";
            // 
            // txtNam
            // 
            this.txtNam.Location = new System.Drawing.Point(321, 115);
            this.txtNam.Margin = new System.Windows.Forms.Padding(2);
            this.txtNam.Name = "txtNam";
            this.txtNam.Size = new System.Drawing.Size(48, 20);
            this.txtNam.TabIndex = 70;
            this.txtNam.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTongtien_KeyPress);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(108, 338);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(246, 13);
            this.label12.TabIndex = 61;
            this.label12.Text = "Kích đúp một hóa đơn để hiển thị thông tin chi tiết";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label2.Location = new System.Drawing.Point(173, 20);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(412, 37);
            this.label2.TabIndex = 72;
            this.label2.Text = "TÌM KIẾM HÓA ĐƠN BÁN";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(603, 144);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 73;
            this.label3.Text = "VNĐ";
            // 
            // Form_SearchHDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 430);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtNam);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTongtien);
            this.Controls.Add(this.txtMaHDBan1);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnTimlai);
            this.Controls.Add(this.txtMakhach);
            this.Controls.Add(this.btnTimkiem);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtManhanvien);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtThang);
            this.Controls.Add(this.DataGridView);
            this.Controls.Add(this.label6);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Form_SearchHDB";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tìm kiếm: Hóa đơn bán";
            this.Load += new System.EventHandler(this.Form_TimHDB_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label label3;

        #endregion
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Button btnTimlai;
        private System.Windows.Forms.Button btnTimkiem;
        private System.Windows.Forms.DataGridView DataGridView;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtThang;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtManhanvien;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtMakhach;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtMaHDBan1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTongtien;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtNam;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label2;
    }
}