namespace pc_market.Forms
{
    partial class Form_RAM
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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.txtMaRam = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTenRam = new System.Windows.Forms.TextBox();
            this.txtloaiRam = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMota = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDungluong = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtbus = new System.Windows.Forms.TextBox();
            this.cboMaHsx = new System.Windows.Forms.ComboBox();
            this.btnhienthids = new System.Windows.Forms.Button();
            this.btntimkiem = new System.Windows.Forms.Button();
            this.btnthoat = new System.Windows.Forms.Button();
            this.btnboqua = new System.Windows.Forms.Button();
            this.btnluu = new System.Windows.Forms.Button();
            this.btnxoa = new System.Windows.Forms.Button();
            this.btnsua = new System.Windows.Forms.Button();
            this.btnthem = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(65, 205);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(890, 225);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.Click += new System.EventHandler(this.dataGridView_Click);
            // 
            // txtMaRam
            // 
            this.txtMaRam.Location = new System.Drawing.Point(192, 76);
            this.txtMaRam.Name = "txtMaRam";
            this.txtMaRam.Size = new System.Drawing.Size(190, 20);
            this.txtMaRam.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkOrchid;
            this.label1.Location = new System.Drawing.Point(472, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 50);
            this.label1.TabIndex = 8;
            this.label1.Text = "RAM";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(123, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Mã RAM:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(119, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Tên RAM:";
            // 
            // txtTenRam
            // 
            this.txtTenRam.Location = new System.Drawing.Point(192, 114);
            this.txtTenRam.Name = "txtTenRam";
            this.txtTenRam.Size = new System.Drawing.Size(190, 20);
            this.txtTenRam.TabIndex = 11;
            // 
            // txtloaiRam
            // 
            this.txtloaiRam.Location = new System.Drawing.Point(735, 111);
            this.txtloaiRam.Name = "txtloaiRam";
            this.txtloaiRam.Size = new System.Drawing.Size(192, 20);
            this.txtloaiRam.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(662, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Loại RAM:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(441, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Bus:";
            // 
            // txtMota
            // 
            this.txtMota.Location = new System.Drawing.Point(735, 155);
            this.txtMota.Name = "txtMota";
            this.txtMota.Size = new System.Drawing.Size(192, 20);
            this.txtMota.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(440, 154);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Dung lượng:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(125, 160);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Mã HSX:";
            // 
            // txtDungluong
            // 
            this.txtDungluong.Location = new System.Drawing.Point(511, 151);
            this.txtDungluong.Name = "txtDungluong";
            this.txtDungluong.Size = new System.Drawing.Size(100, 20);
            this.txtDungluong.TabIndex = 23;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(673, 158);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "Mô tả:";
            // 
            // txtbus
            // 
            this.txtbus.Location = new System.Drawing.Point(511, 111);
            this.txtbus.Name = "txtbus";
            this.txtbus.Size = new System.Drawing.Size(100, 20);
            this.txtbus.TabIndex = 20;
            // 
            // cboMaHsx
            // 
            this.cboMaHsx.FormattingEnabled = true;
            this.cboMaHsx.Location = new System.Drawing.Point(192, 156);
            this.cboMaHsx.Name = "cboMaHsx";
            this.cboMaHsx.Size = new System.Drawing.Size(190, 21);
            this.cboMaHsx.TabIndex = 26;
            // 
            // btnhienthids
            // 
            this.btnhienthids.BackgroundImage = global::pc_market.Properties.Resources.display;
            this.btnhienthids.Location = new System.Drawing.Point(701, 450);
            this.btnhienthids.Name = "btnhienthids";
            this.btnhienthids.Size = new System.Drawing.Size(75, 34);
            this.btnhienthids.TabIndex = 25;
            this.btnhienthids.Text = "Hiển thị DS";
            this.btnhienthids.UseVisualStyleBackColor = true;
            this.btnhienthids.Click += new System.EventHandler(this.btnhienthids_Click);
            // 
            // btntimkiem
            // 
            this.btntimkiem.BackgroundImage = global::pc_market.Properties.Resources.search;
            this.btntimkiem.Location = new System.Drawing.Point(607, 450);
            this.btntimkiem.Name = "btntimkiem";
            this.btntimkiem.Size = new System.Drawing.Size(75, 34);
            this.btntimkiem.TabIndex = 24;
            this.btntimkiem.Text = "Tìm kiếm";
            this.btntimkiem.UseVisualStyleBackColor = true;
            this.btntimkiem.Click += new System.EventHandler(this.btntimkiem_Click);
            // 
            // btnthoat
            // 
            this.btnthoat.BackgroundImage = global::pc_market.Properties.Resources.close;
            this.btnthoat.Location = new System.Drawing.Point(793, 450);
            this.btnthoat.Name = "btnthoat";
            this.btnthoat.Size = new System.Drawing.Size(75, 34);
            this.btnthoat.TabIndex = 6;
            this.btnthoat.Text = "Thoát";
            this.btnthoat.UseVisualStyleBackColor = true;
            this.btnthoat.Click += new System.EventHandler(this.btnthoat_Click);
            // 
            // btnboqua
            // 
            this.btnboqua.BackgroundImage = global::pc_market.Properties.Resources.skip;
            this.btnboqua.Location = new System.Drawing.Point(511, 450);
            this.btnboqua.Name = "btnboqua";
            this.btnboqua.Size = new System.Drawing.Size(75, 34);
            this.btnboqua.TabIndex = 5;
            this.btnboqua.Text = "Bỏ qua";
            this.btnboqua.UseVisualStyleBackColor = true;
            this.btnboqua.Click += new System.EventHandler(this.btnboqua_Click);
            // 
            // btnluu
            // 
            this.btnluu.BackgroundImage = global::pc_market.Properties.Resources.save;
            this.btnluu.Location = new System.Drawing.Point(418, 450);
            this.btnluu.Name = "btnluu";
            this.btnluu.Size = new System.Drawing.Size(75, 34);
            this.btnluu.TabIndex = 4;
            this.btnluu.Text = "Lưu";
            this.btnluu.UseVisualStyleBackColor = true;
            this.btnluu.Click += new System.EventHandler(this.btnluu_Click);
            // 
            // btnxoa
            // 
            this.btnxoa.BackgroundImage = global::pc_market.Properties.Resources.delete;
            this.btnxoa.Location = new System.Drawing.Point(228, 450);
            this.btnxoa.Name = "btnxoa";
            this.btnxoa.Size = new System.Drawing.Size(75, 34);
            this.btnxoa.TabIndex = 3;
            this.btnxoa.Text = "Xoá";
            this.btnxoa.UseVisualStyleBackColor = true;
            this.btnxoa.Click += new System.EventHandler(this.btnxoa_Click);
            // 
            // btnsua
            // 
            this.btnsua.BackgroundImage = global::pc_market.Properties.Resources.edit;
            this.btnsua.Location = new System.Drawing.Point(322, 450);
            this.btnsua.Name = "btnsua";
            this.btnsua.Size = new System.Drawing.Size(75, 34);
            this.btnsua.TabIndex = 2;
            this.btnsua.Text = "Sửa";
            this.btnsua.UseVisualStyleBackColor = true;
            this.btnsua.Click += new System.EventHandler(this.btnsua_Click);
            // 
            // btnthem
            // 
            this.btnthem.BackgroundImage = global::pc_market.Properties.Resources.add;
            this.btnthem.Location = new System.Drawing.Point(113, 450);
            this.btnthem.Name = "btnthem";
            this.btnthem.Size = new System.Drawing.Size(83, 34);
            this.btnthem.TabIndex = 1;
            this.btnthem.Text = "Thêm ";
            this.btnthem.UseVisualStyleBackColor = true;
            this.btnthem.Click += new System.EventHandler(this.btnthem_Click_1);
            // 
            // FormRAM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(1016, 519);
            this.Controls.Add(this.cboMaHsx);
            this.Controls.Add(this.btnhienthids);
            this.Controls.Add(this.btntimkiem);
            this.Controls.Add(this.txtDungluong);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtbus);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtloaiRam);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtMota);
            this.Controls.Add(this.txtTenRam);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMaRam);
            this.Controls.Add(this.btnthoat);
            this.Controls.Add(this.btnboqua);
            this.Controls.Add(this.btnluu);
            this.Controls.Add(this.btnxoa);
            this.Controls.Add(this.btnsua);
            this.Controls.Add(this.btnthem);
            this.Controls.Add(this.dataGridView);
            this.Name = "Form_RAM";
            this.Text = "FormRAM";
            this.Load += new System.EventHandler(this.FormRAM_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button btnthem;
        private System.Windows.Forms.Button btnsua;
        private System.Windows.Forms.Button btnxoa;
        private System.Windows.Forms.Button btnthoat;
        private System.Windows.Forms.Button btnboqua;
        private System.Windows.Forms.Button btnluu;
        private System.Windows.Forms.TextBox txtMaRam;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTenRam;
        private System.Windows.Forms.TextBox txtloaiRam;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMota;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDungluong;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtbus;
        private System.Windows.Forms.Button btntimkiem;
        private System.Windows.Forms.Button btnhienthids;
        private System.Windows.Forms.ComboBox cboMaHsx;
    }
}