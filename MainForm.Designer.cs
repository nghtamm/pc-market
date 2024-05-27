using System.ComponentModel;

namespace pc_market
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.categoriesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.categoryPC = new System.Windows.Forms.ToolStripMenuItem();
            this.categoryPCParts = new System.Windows.Forms.ToolStripMenuItem();
            this.PCParts_Mainboard = new System.Windows.Forms.ToolStripMenuItem();
            this.PCParts_CPU = new System.Windows.Forms.ToolStripMenuItem();
            this.PCParts_RAM = new System.Windows.Forms.ToolStripMenuItem();
            this.PCParts_GPU = new System.Windows.Forms.ToolStripMenuItem();
            this.PCParts_DiskDrive = new System.Windows.Forms.ToolStripMenuItem();
            this.categoryEmployee = new System.Windows.Forms.ToolStripMenuItem();
            this.categoryCustomer = new System.Windows.Forms.ToolStripMenuItem();
            this.categoryProvider = new System.Windows.Forms.ToolStripMenuItem();
            this.categoryOthers = new System.Windows.Forms.ToolStripMenuItem();
            this.Others_MonitorDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.Others_Manufacturers = new System.Windows.Forms.ToolStripMenuItem();
            this.receiptMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.receiptBuy = new System.Windows.Forms.ToolStripMenuItem();
            this.receiptSell = new System.Windows.Forms.ToolStripMenuItem();
            this.reportMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportBuy = new System.Windows.Forms.ToolStripMenuItem();
            this.reportSell = new System.Windows.Forms.ToolStripMenuItem();
            this.reportIncome = new System.Windows.Forms.ToolStripMenuItem();
            this.searchMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchBuyReceipt = new System.Windows.Forms.ToolStripMenuItem();
            this.searchSellReceipt = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutUsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.categoriesMenuItem,
            this.receiptMenuItem,
            this.reportMenuItem,
            this.searchMenuItem,
            this.aboutUsMenuItem,
            this.exitMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1699, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // categoriesMenuItem
            // 
            this.categoriesMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.categoryPC,
            this.categoryPCParts,
            this.categoryEmployee,
            this.categoryCustomer,
            this.categoryProvider,
            this.categoryOthers});
            this.categoriesMenuItem.Name = "categoriesMenuItem";
            this.categoriesMenuItem.Size = new System.Drawing.Size(90, 24);
            this.categoriesMenuItem.Text = "Danh mục";
            // 
            // categoryPC
            // 
            this.categoryPC.Name = "categoryPC";
            this.categoryPC.Size = new System.Drawing.Size(211, 26);
            this.categoryPC.Text = "Máy tính";
            // 
            // categoryPCParts
            // 
            this.categoryPCParts.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PCParts_Mainboard,
            this.PCParts_CPU,
            this.PCParts_RAM,
            this.PCParts_GPU,
            this.PCParts_DiskDrive});
            this.categoryPCParts.Name = "categoryPCParts";
            this.categoryPCParts.Size = new System.Drawing.Size(211, 26);
            this.categoryPCParts.Text = "Linh kiện máy tính";
            this.categoryPCParts.Click += new System.EventHandler(this.categoryPCParts_Click);
            // 
            // PCParts_Mainboard
            // 
            this.PCParts_Mainboard.Name = "PCParts_Mainboard";
            this.PCParts_Mainboard.Size = new System.Drawing.Size(216, 26);
            this.PCParts_Mainboard.Text = "Mainboard";
            // 
            // PCParts_CPU
            // 
            this.PCParts_CPU.Name = "PCParts_CPU";
            this.PCParts_CPU.Size = new System.Drawing.Size(216, 26);
            this.PCParts_CPU.Text = "CPU";
            // 
            // PCParts_RAM
            // 
            this.PCParts_RAM.Name = "PCParts_RAM";
            this.PCParts_RAM.Size = new System.Drawing.Size(216, 26);
            this.PCParts_RAM.Text = "RAM";
            // 
            // PCParts_GPU
            // 
            this.PCParts_GPU.Name = "PCParts_GPU";
            this.PCParts_GPU.Size = new System.Drawing.Size(216, 26);
            this.PCParts_GPU.Text = "Card đồ họa (GPU)";
            this.PCParts_GPU.Click += new System.EventHandler(this.PCParts_GPU_Click);
            // 
            // PCParts_DiskDrive
            // 
            this.PCParts_DiskDrive.Name = "PCParts_DiskDrive";
            this.PCParts_DiskDrive.Size = new System.Drawing.Size(216, 26);
            this.PCParts_DiskDrive.Text = "Ổ cứng";
            // 
            // categoryEmployee
            // 
            this.categoryEmployee.Name = "categoryEmployee";
            this.categoryEmployee.Size = new System.Drawing.Size(211, 26);
            this.categoryEmployee.Text = "Nhân viên";
            // 
            // categoryCustomer
            // 
            this.categoryCustomer.Name = "categoryCustomer";
            this.categoryCustomer.Size = new System.Drawing.Size(211, 26);
            this.categoryCustomer.Text = "Khách hàng";
            // 
            // categoryProvider
            // 
            this.categoryProvider.Name = "categoryProvider";
            this.categoryProvider.Size = new System.Drawing.Size(211, 26);
            this.categoryProvider.Text = "Nhà cung cấp";
            this.categoryProvider.Click += new System.EventHandler(this.categoryProvider_Click);
            // 
            // categoryOthers
            // 
            this.categoryOthers.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Others_MonitorDetails,
            this.Others_Manufacturers});
            this.categoryOthers.Name = "categoryOthers";
            this.categoryOthers.Size = new System.Drawing.Size(211, 26);
            this.categoryOthers.Text = "Khác";
            // 
            // Others_MonitorDetails
            // 
            this.Others_MonitorDetails.Name = "Others_MonitorDetails";
            this.Others_MonitorDetails.Size = new System.Drawing.Size(204, 26);
            this.Others_MonitorDetails.Text = "Chi tiết màn hình";
            // 
            // Others_Manufacturers
            // 
            this.Others_Manufacturers.Name = "Others_Manufacturers";
            this.Others_Manufacturers.Size = new System.Drawing.Size(204, 26);
            this.Others_Manufacturers.Text = "Hãng sản xuất";
            // 
            // receiptMenuItem
            // 
            this.receiptMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.receiptBuy,
            this.receiptSell});
            this.receiptMenuItem.Name = "receiptMenuItem";
            this.receiptMenuItem.Size = new System.Drawing.Size(81, 24);
            this.receiptMenuItem.Text = "Hóa đơn";
            // 
            // receiptBuy
            // 
            this.receiptBuy.Name = "receiptBuy";
            this.receiptBuy.Size = new System.Drawing.Size(224, 26);
            this.receiptBuy.Text = "Hóa đơn nhập";
            // 
            // receiptSell
            // 
            this.receiptSell.Name = "receiptSell";
            this.receiptSell.Size = new System.Drawing.Size(224, 26);
            this.receiptSell.Text = "Hóa đơn bán";
            this.receiptSell.Click += new System.EventHandler(this.receiptSell_Click);
            // 
            // reportMenuItem
            // 
            this.reportMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reportBuy,
            this.reportSell,
            this.reportIncome});
            this.reportMenuItem.Name = "reportMenuItem";
            this.reportMenuItem.Size = new System.Drawing.Size(77, 24);
            this.reportMenuItem.Text = "Báo cáo";
            // 
            // reportBuy
            // 
            this.reportBuy.Name = "reportBuy";
            this.reportBuy.Size = new System.Drawing.Size(224, 26);
            this.reportBuy.Text = "Báo cáo nhập hàng";
            // 
            // reportSell
            // 
            this.reportSell.Name = "reportSell";
            this.reportSell.Size = new System.Drawing.Size(224, 26);
            this.reportSell.Text = "Báo cáo bán hàng";
            // 
            // reportIncome
            // 
            this.reportIncome.Name = "reportIncome";
            this.reportIncome.Size = new System.Drawing.Size(224, 26);
            this.reportIncome.Text = "Báo cáo doanh thu";
            // 
            // searchMenuItem
            // 
            this.searchMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.searchBuyReceipt,
            this.searchSellReceipt});
            this.searchMenuItem.Name = "searchMenuItem";
            this.searchMenuItem.Size = new System.Drawing.Size(84, 24);
            this.searchMenuItem.Text = "Tìm kiếm";
            // 
            // searchBuyReceipt
            // 
            this.searchBuyReceipt.Name = "searchBuyReceipt";
            this.searchBuyReceipt.Size = new System.Drawing.Size(187, 26);
            this.searchBuyReceipt.Text = "Hóa đơn nhập";
            // 
            // searchSellReceipt
            // 
            this.searchSellReceipt.Name = "searchSellReceipt";
            this.searchSellReceipt.Size = new System.Drawing.Size(187, 26);
            this.searchSellReceipt.Text = "Hóa đơn bán";
            // 
            // aboutUsMenuItem
            // 
            this.aboutUsMenuItem.Name = "aboutUsMenuItem";
            this.aboutUsMenuItem.Size = new System.Drawing.Size(106, 24);
            this.aboutUsMenuItem.Text = "Về chúng tôi";
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Name = "exitMenuItem";
            this.exitMenuItem.Size = new System.Drawing.Size(61, 24);
            this.exitMenuItem.Text = "Thoát";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::pc_market.Properties.Resources.banner;
            this.ClientSize = new System.Drawing.Size(1699, 777);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "Cửa hàng máy tính PC Market";
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.ToolStripMenuItem reportBuy;
        private System.Windows.Forms.ToolStripMenuItem reportSell;
        private System.Windows.Forms.ToolStripMenuItem reportIncome;
        private System.Windows.Forms.ToolStripMenuItem searchBuyReceipt;
        private System.Windows.Forms.ToolStripMenuItem searchSellReceipt;

        private System.Windows.Forms.ToolStripMenuItem categoryOthers;
        private System.Windows.Forms.ToolStripMenuItem Others_MonitorDetails;
        private System.Windows.Forms.ToolStripMenuItem Others_Manufacturers;
        private System.Windows.Forms.ToolStripMenuItem receiptBuy;
        private System.Windows.Forms.ToolStripMenuItem receiptSell;

        private System.Windows.Forms.ToolStripMenuItem categoryEmployee;
        private System.Windows.Forms.ToolStripMenuItem categoryCustomer;
        private System.Windows.Forms.ToolStripMenuItem categoryProvider;

        private System.Windows.Forms.ToolStripMenuItem PCParts_Mainboard;
        private System.Windows.Forms.ToolStripMenuItem PCParts_CPU;
        private System.Windows.Forms.ToolStripMenuItem PCParts_RAM;
        private System.Windows.Forms.ToolStripMenuItem PCParts_GPU;
        private System.Windows.Forms.ToolStripMenuItem PCParts_DiskDrive;

        private System.Windows.Forms.ToolStripMenuItem categoryPC;
        private System.Windows.Forms.ToolStripMenuItem categoryPCParts;

        private System.Windows.Forms.ToolStripMenuItem searchMenuItem;

        private System.Windows.Forms.ToolStripMenuItem aboutUsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitMenuItem;

        private System.Windows.Forms.ToolStripMenuItem receiptMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportMenuItem;

        private System.Windows.Forms.ToolStripMenuItem categoriesMenuItem;

        private System.Windows.Forms.MenuStrip menuStrip1;

        #endregion
    }
}