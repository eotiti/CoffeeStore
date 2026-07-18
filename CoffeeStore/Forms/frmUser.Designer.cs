namespace CoffeeStore.Forms
{
    partial class frmUser
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
            this.dgvUser = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFullname = new System.Windows.Forms.TextBox();
            this.pnlInfor = new System.Windows.Forms.Panel();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkHide = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cbxPermission = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.rdoActive = new System.Windows.Forms.RadioButton();
            this.rdoDeactive = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).BeginInit();
            this.pnlInfor.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvUser
            // 
            this.dgvUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUser.Location = new System.Drawing.Point(42, 67);
            this.dgvUser.Name = "dgvUser";
            this.dgvUser.RowHeadersWidth = 51;
            this.dgvUser.RowTemplate.Height = 24;
            this.dgvUser.Size = new System.Drawing.Size(402, 437);
            this.dgvUser.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(292, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(469, 42);
            this.label1.TabIndex = 1;
            this.label1.Text = "DANH SÁCH NHÂN VIÊN";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 29);
            this.label2.TabIndex = 2;
            this.label2.Text = "Họ tên:";
            // 
            // txtFullname
            // 
            this.txtFullname.Location = new System.Drawing.Point(148, 16);
            this.txtFullname.Name = "txtFullname";
            this.txtFullname.Size = new System.Drawing.Size(278, 34);
            this.txtFullname.TabIndex = 3;
            // 
            // pnlInfor
            // 
            this.pnlInfor.Controls.Add(this.rdoDeactive);
            this.pnlInfor.Controls.Add(this.rdoActive);
            this.pnlInfor.Controls.Add(this.label5);
            this.pnlInfor.Controls.Add(this.cbxPermission);
            this.pnlInfor.Controls.Add(this.btnCancel);
            this.pnlInfor.Controls.Add(this.btnSave);
            this.pnlInfor.Controls.Add(this.chkHide);
            this.pnlInfor.Controls.Add(this.txtPassword);
            this.pnlInfor.Controls.Add(this.label4);
            this.pnlInfor.Controls.Add(this.txtUsername);
            this.pnlInfor.Controls.Add(this.label3);
            this.pnlInfor.Controls.Add(this.txtFullname);
            this.pnlInfor.Controls.Add(this.label2);
            this.pnlInfor.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlInfor.Location = new System.Drawing.Point(465, 67);
            this.pnlInfor.Name = "pnlInfor";
            this.pnlInfor.Size = new System.Drawing.Size(559, 437);
            this.pnlInfor.TabIndex = 4;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(148, 137);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(278, 34);
            this.txtUsername.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 29);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tài khoản:";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(148, 197);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(278, 34);
            this.txtPassword.TabIndex = 7;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 29);
            this.label4.TabIndex = 6;
            this.label4.Text = "Mật khẩu:";
            // 
            // chkHide
            // 
            this.chkHide.AutoSize = true;
            this.chkHide.Location = new System.Drawing.Point(432, 196);
            this.chkHide.Name = "chkHide";
            this.chkHide.Size = new System.Drawing.Size(85, 33);
            this.chkHide.TabIndex = 8;
            this.chkHide.Text = "Hiện";
            this.chkHide.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(149, 297);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(105, 46);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(310, 297);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(105, 46);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Reset";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // cbxPermission
            // 
            this.cbxPermission.FormattingEnabled = true;
            this.cbxPermission.Location = new System.Drawing.Point(148, 73);
            this.cbxPermission.Name = "cbxPermission";
            this.cbxPermission.Size = new System.Drawing.Size(185, 37);
            this.cbxPermission.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 29);
            this.label5.TabIndex = 12;
            this.label5.Text = "Quyền:";
            // 
            // rdoActive
            // 
            this.rdoActive.AutoSize = true;
            this.rdoActive.Location = new System.Drawing.Point(148, 237);
            this.rdoActive.Name = "rdoActive";
            this.rdoActive.Size = new System.Drawing.Size(98, 33);
            this.rdoActive.TabIndex = 13;
            this.rdoActive.TabStop = true;
            this.rdoActive.Text = "Active";
            this.rdoActive.UseVisualStyleBackColor = true;
            // 
            // rdoDeactive
            // 
            this.rdoDeactive.AutoSize = true;
            this.rdoDeactive.Location = new System.Drawing.Point(295, 237);
            this.rdoDeactive.Name = "rdoDeactive";
            this.rdoDeactive.Size = new System.Drawing.Size(127, 33);
            this.rdoDeactive.TabIndex = 14;
            this.rdoDeactive.TabStop = true;
            this.rdoDeactive.Text = "Deactive";
            this.rdoDeactive.UseVisualStyleBackColor = true;
            // 
            // frmUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1036, 531);
            this.Controls.Add(this.pnlInfor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvUser);
            this.Name = "frmUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "QUẢN LÝ NHÂN VIÊN";
            this.Load += new System.EventHandler(this.frmUser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).EndInit();
            this.pnlInfor.ResumeLayout(false);
            this.pnlInfor.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvUser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFullname;
        private System.Windows.Forms.Panel pnlInfor;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox chkHide;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbxPermission;
        private System.Windows.Forms.RadioButton rdoActive;
        private System.Windows.Forms.RadioButton rdoDeactive;
    }
}