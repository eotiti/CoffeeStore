namespace CoffeeStore.Forms
{
    partial class frmMain
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.lblCurrentUser = new System.Windows.Forms.Label();
            this.toolOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.giaoHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolAccount = new System.Windows.Forms.ToolStripMenuItem();
            this.menuArea = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFood = new System.Windows.Forms.ToolStripMenuItem();
            this.toolReport = new System.Windows.Forms.ToolStripMenuItem();
            this.menuWarehouse = new System.Windows.Forms.ToolStripMenuItem();
            this.báoCáoXuấtnhậpTồnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kIỂMKÊToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuManagment = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAccount = new System.Windows.Forms.ToolStripMenuItem();
            this.mậtKhẩuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.Color.Gainsboro;
            this.menuStrip.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuStrip.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolOrder,
            this.toolAccount,
            this.toolReport,
            this.menuManagment});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip.Size = new System.Drawing.Size(227, 1055);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            this.menuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip_ItemClicked);
            // 
            // lblCurrentUser
            // 
            this.lblCurrentUser.AutoSize = true;
            this.lblCurrentUser.Location = new System.Drawing.Point(12, 288);
            this.lblCurrentUser.Name = "lblCurrentUser";
            this.lblCurrentUser.Size = new System.Drawing.Size(64, 25);
            this.lblCurrentUser.TabIndex = 2;
            this.lblCurrentUser.Text = "label1";
            // 
            // toolOrder
            // 
            this.toolOrder.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuOrder,
            this.giaoHàngToolStripMenuItem});
            this.toolOrder.Image = global::CoffeeStore.Properties.Resources.buy;
            this.toolOrder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolOrder.Name = "toolOrder";
            this.toolOrder.Size = new System.Drawing.Size(214, 45);
            this.toolOrder.Text = "Bán hàng";
            this.toolOrder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // menuOrder
            // 
            this.menuOrder.Image = global::CoffeeStore.Properties.Resources.pencil;
            this.menuOrder.Name = "menuOrder";
            this.menuOrder.Size = new System.Drawing.Size(246, 46);
            this.menuOrder.Text = "Gọi món";
            this.menuOrder.Click += new System.EventHandler(this.menuOrder_Click);
            // 
            // giaoHàngToolStripMenuItem
            // 
            this.giaoHàngToolStripMenuItem.Name = "giaoHàngToolStripMenuItem";
            this.giaoHàngToolStripMenuItem.Size = new System.Drawing.Size(246, 46);
            this.giaoHàngToolStripMenuItem.Text = "Giao hàng";
            // 
            // toolAccount
            // 
            this.toolAccount.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuArea,
            this.menuCategory,
            this.menuFood});
            this.toolAccount.Image = global::CoffeeStore.Properties.Resources.briefcase;
            this.toolAccount.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolAccount.Name = "toolAccount";
            this.toolAccount.Size = new System.Drawing.Size(214, 45);
            this.toolAccount.Text = "Quản trị";
            this.toolAccount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // menuArea
            // 
            this.menuArea.Image = global::CoffeeStore.Properties.Resources._02_Data_Center;
            this.menuArea.Name = "menuArea";
            this.menuArea.Size = new System.Drawing.Size(276, 46);
            this.menuArea.Text = "Khu vực-Bàn";
            this.menuArea.Click += new System.EventHandler(this.menuArea_Click);
            // 
            // menuCategory
            // 
            this.menuCategory.Image = global::CoffeeStore.Properties.Resources._12_Investigation;
            this.menuCategory.Name = "menuCategory";
            this.menuCategory.Size = new System.Drawing.Size(276, 46);
            this.menuCategory.Text = "Category";
            this.menuCategory.Click += new System.EventHandler(this.menuCategory_Click);
            // 
            // menuFood
            // 
            this.menuFood.Image = global::CoffeeStore.Properties.Resources._17_Reusable_Bottle_;
            this.menuFood.Name = "menuFood";
            this.menuFood.Size = new System.Drawing.Size(276, 46);
            this.menuFood.Text = "Food-Drink";
            this.menuFood.Click += new System.EventHandler(this.menuFood_Click);
            // 
            // toolReport
            // 
            this.toolReport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuWarehouse,
            this.báoCáoXuấtnhậpTồnToolStripMenuItem,
            this.kIỂMKÊToolStripMenuItem});
            this.toolReport.Image = global::CoffeeStore.Properties.Resources._20_Report;
            this.toolReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolReport.Name = "toolReport";
            this.toolReport.Size = new System.Drawing.Size(214, 45);
            this.toolReport.Text = "Báo cáo/Kho";
            this.toolReport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // menuWarehouse
            // 
            this.menuWarehouse.Image = global::CoffeeStore.Properties.Resources._02_Data_Center;
            this.menuWarehouse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menuWarehouse.Name = "menuWarehouse";
            this.menuWarehouse.Size = new System.Drawing.Size(240, 46);
            this.menuWarehouse.Text = "Nhập kho";
            // 
            // báoCáoXuấtnhậpTồnToolStripMenuItem
            // 
            this.báoCáoXuấtnhậpTồnToolStripMenuItem.Image = global::CoffeeStore.Properties.Resources._11_Analytics;
            this.báoCáoXuấtnhậpTồnToolStripMenuItem.Name = "báoCáoXuấtnhậpTồnToolStripMenuItem";
            this.báoCáoXuấtnhậpTồnToolStripMenuItem.Size = new System.Drawing.Size(240, 46);
            this.báoCáoXuấtnhậpTồnToolStripMenuItem.Text = "BC X-N-T";
            // 
            // kIỂMKÊToolStripMenuItem
            // 
            this.kIỂMKÊToolStripMenuItem.Image = global::CoffeeStore.Properties.Resources.statistics;
            this.kIỂMKÊToolStripMenuItem.Name = "kIỂMKÊToolStripMenuItem";
            this.kIỂMKÊToolStripMenuItem.Size = new System.Drawing.Size(240, 46);
            this.kIỂMKÊToolStripMenuItem.Text = "KIỂM KÊ";
            // 
            // menuManagment
            // 
            this.menuManagment.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAccount,
            this.mậtKhẩuToolStripMenuItem,
            this.menuLogout});
            this.menuManagment.Image = global::CoffeeStore.Properties.Resources.user_icon;
            this.menuManagment.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menuManagment.Name = "menuManagment";
            this.menuManagment.Size = new System.Drawing.Size(214, 45);
            this.menuManagment.Text = "Tài khoản";
            this.menuManagment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // menuAccount
            // 
            this.menuAccount.Image = global::CoffeeStore.Properties.Resources.banner;
            this.menuAccount.Name = "menuAccount";
            this.menuAccount.Size = new System.Drawing.Size(245, 46);
            this.menuAccount.Text = "Thông tin";
            this.menuAccount.Click += new System.EventHandler(this.menuAccount_Click);
            // 
            // mậtKhẩuToolStripMenuItem
            // 
            this.mậtKhẩuToolStripMenuItem.Image = global::CoffeeStore.Properties.Resources.logo_login;
            this.mậtKhẩuToolStripMenuItem.Name = "mậtKhẩuToolStripMenuItem";
            this.mậtKhẩuToolStripMenuItem.Size = new System.Drawing.Size(245, 46);
            this.mậtKhẩuToolStripMenuItem.Text = "Mật khẩu";
            // 
            // menuLogout
            // 
            this.menuLogout.Image = global::CoffeeStore.Properties.Resources.images;
            this.menuLogout.Name = "menuLogout";
            this.menuLogout.Size = new System.Drawing.Size(245, 46);
            this.menuLogout.Text = "Đăng xuất";
            this.menuLogout.Click += new System.EventHandler(this.menuLogout_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.lblCurrentUser);
            this.Controls.Add(this.menuStrip);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolAccount;
        private System.Windows.Forms.ToolStripMenuItem toolOrder;
        private System.Windows.Forms.ToolStripMenuItem toolReport;
        private System.Windows.Forms.ToolStripMenuItem menuManagment;
        private System.Windows.Forms.ToolStripMenuItem menuArea;
        private System.Windows.Forms.ToolStripMenuItem menuCategory;
        private System.Windows.Forms.ToolStripMenuItem menuOrder;
        private System.Windows.Forms.ToolStripMenuItem menuAccount;
        private System.Windows.Forms.Label lblCurrentUser;
        private System.Windows.Forms.ToolStripMenuItem menuFood;
        private System.Windows.Forms.ToolStripMenuItem mậtKhẩuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuLogout;
        private System.Windows.Forms.ToolStripMenuItem giaoHàngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuWarehouse;
        private System.Windows.Forms.ToolStripMenuItem báoCáoXuấtnhậpTồnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kIỂMKÊToolStripMenuItem;
    }
}