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
            this.pnlMain = new System.Windows.Forms.Panel();
            this.toolOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDelivery = new System.Windows.Forms.ToolStripMenuItem();
            this.toolManager = new System.Windows.Forms.ToolStripMenuItem();
            this.menuArea = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFood = new System.Windows.Forms.ToolStripMenuItem();
            this.toolReport = new System.Windows.Forms.ToolStripMenuItem();
            this.menuWarehouse = new System.Windows.Forms.ToolStripMenuItem();
            this.menuReport = new System.Windows.Forms.ToolStripMenuItem();
            this.menuKiemKe = new System.Windows.Forms.ToolStripMenuItem();
            this.toolAccount = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAccount = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPassword = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolCurrentUser = new System.Windows.Forms.ToolStripMenuItem();
            this.menuUser = new System.Windows.Forms.ToolStripMenuItem();
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
            this.toolManager,
            this.toolReport,
            this.toolAccount,
            this.toolCurrentUser});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip.Size = new System.Drawing.Size(227, 1055);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // pnlMain
            // 
            this.pnlMain.Location = new System.Drawing.Point(230, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1682, 1043);
            this.pnlMain.TabIndex = 4;
            // 
            // toolOrder
            // 
            this.toolOrder.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuOrder,
            this.menuDelivery});
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
            // menuDelivery
            // 
            this.menuDelivery.Name = "menuDelivery";
            this.menuDelivery.Size = new System.Drawing.Size(246, 46);
            this.menuDelivery.Text = "Giao hàng";
            // 
            // toolManager
            // 
            this.toolManager.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuArea,
            this.menuCategory,
            this.menuFood,
            this.menuUser});
            this.toolManager.Image = global::CoffeeStore.Properties.Resources.briefcase;
            this.toolManager.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolManager.Name = "toolManager";
            this.toolManager.Size = new System.Drawing.Size(214, 45);
            this.toolManager.Text = "Quản trị";
            this.toolManager.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.menuReport,
            this.menuKiemKe});
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
            // menuReport
            // 
            this.menuReport.Image = global::CoffeeStore.Properties.Resources._11_Analytics;
            this.menuReport.Name = "menuReport";
            this.menuReport.Size = new System.Drawing.Size(240, 46);
            this.menuReport.Text = "BC X-N-T";
            // 
            // menuKiemKe
            // 
            this.menuKiemKe.Image = global::CoffeeStore.Properties.Resources.statistics;
            this.menuKiemKe.Name = "menuKiemKe";
            this.menuKiemKe.Size = new System.Drawing.Size(240, 46);
            this.menuKiemKe.Text = "KIỂM KÊ";
            // 
            // toolAccount
            // 
            this.toolAccount.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAccount,
            this.menuPassword,
            this.menuLogout});
            this.toolAccount.Image = global::CoffeeStore.Properties.Resources.user_icon;
            this.toolAccount.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolAccount.Name = "toolAccount";
            this.toolAccount.Size = new System.Drawing.Size(214, 45);
            this.toolAccount.Text = "Tài khoản";
            this.toolAccount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // menuAccount
            // 
            this.menuAccount.Image = global::CoffeeStore.Properties.Resources.banner;
            this.menuAccount.Name = "menuAccount";
            this.menuAccount.Size = new System.Drawing.Size(245, 46);
            this.menuAccount.Text = "Thông tin";
            this.menuAccount.Click += new System.EventHandler(this.menuAccount_Click);
            // 
            // menuPassword
            // 
            this.menuPassword.Image = global::CoffeeStore.Properties.Resources.logo_login;
            this.menuPassword.Name = "menuPassword";
            this.menuPassword.Size = new System.Drawing.Size(245, 46);
            this.menuPassword.Text = "Mật khẩu";
            // 
            // menuLogout
            // 
            this.menuLogout.Image = global::CoffeeStore.Properties.Resources.images;
            this.menuLogout.Name = "menuLogout";
            this.menuLogout.Size = new System.Drawing.Size(245, 46);
            this.menuLogout.Text = "Đăng xuất";
            this.menuLogout.Click += new System.EventHandler(this.menuLogout_Click);
            // 
            // toolCurrentUser
            // 
            this.toolCurrentUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.toolCurrentUser.Name = "toolCurrentUser";
            this.toolCurrentUser.Size = new System.Drawing.Size(214, 45);
            this.toolCurrentUser.Text = "currentUser";
            // 
            // menuUser
            // 
            this.menuUser.Name = "menuUser";
            this.menuUser.Size = new System.Drawing.Size(348, 46);
            this.menuUser.Text = "Quản lý nhân viên";
            this.menuUser.Click += new System.EventHandler(this.menuUser_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.menuStrip);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
        private System.Windows.Forms.ToolStripMenuItem toolManager;
        private System.Windows.Forms.ToolStripMenuItem toolOrder;
        private System.Windows.Forms.ToolStripMenuItem toolReport;
        private System.Windows.Forms.ToolStripMenuItem toolAccount;
        private System.Windows.Forms.ToolStripMenuItem menuArea;
        private System.Windows.Forms.ToolStripMenuItem menuCategory;
        private System.Windows.Forms.ToolStripMenuItem menuOrder;
        private System.Windows.Forms.ToolStripMenuItem menuAccount;
        private System.Windows.Forms.ToolStripMenuItem menuFood;
        private System.Windows.Forms.ToolStripMenuItem menuPassword;
        private System.Windows.Forms.ToolStripMenuItem menuLogout;
        private System.Windows.Forms.ToolStripMenuItem menuDelivery;
        private System.Windows.Forms.ToolStripMenuItem menuWarehouse;
        private System.Windows.Forms.ToolStripMenuItem menuReport;
        private System.Windows.Forms.ToolStripMenuItem menuKiemKe;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.ToolStripMenuItem toolCurrentUser;
        private System.Windows.Forms.ToolStripMenuItem menuUser;
    }
}