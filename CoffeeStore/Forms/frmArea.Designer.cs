namespace CoffeeStore.Forms
{
    partial class frmArea
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
            this.components = new System.ComponentModel.Container();
            this.flpArea = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDeleteArea = new System.Windows.Forms.Button();
            this.btnAddArea = new System.Windows.Forms.Button();
            this.btnUpdateArea = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnAddTable = new System.Windows.Forms.Button();
            this.btnEditTable = new System.Windows.Forms.Button();
            this.flpTable = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // flpArea
            // 
            this.flpArea.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.flpArea.Location = new System.Drawing.Point(6, 33);
            this.flpArea.Name = "flpArea";
            this.flpArea.Size = new System.Drawing.Size(689, 447);
            this.flpArea.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDeleteArea);
            this.groupBox1.Controls.Add(this.btnAddArea);
            this.groupBox1.Controls.Add(this.btnUpdateArea);
            this.groupBox1.Controls.Add(this.flpArea);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(713, 666);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Khu vực";
            // 
            // btnDeleteArea
            // 
            this.btnDeleteArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteArea.Location = new System.Drawing.Point(6, 582);
            this.btnDeleteArea.Name = "btnDeleteArea";
            this.btnDeleteArea.Size = new System.Drawing.Size(97, 35);
            this.btnDeleteArea.TabIndex = 4;
            this.btnDeleteArea.UseVisualStyleBackColor = true;
            // 
            // btnAddArea
            // 
            this.btnAddArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddArea.Location = new System.Drawing.Point(6, 500);
            this.btnAddArea.Name = "btnAddArea";
            this.btnAddArea.Size = new System.Drawing.Size(97, 35);
            this.btnAddArea.TabIndex = 2;
            this.btnAddArea.Text = "Thêm";
            this.btnAddArea.UseVisualStyleBackColor = true;
            this.btnAddArea.Click += new System.EventHandler(this.btnAddArea_Click);
            // 
            // btnUpdateArea
            // 
            this.btnUpdateArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateArea.Location = new System.Drawing.Point(6, 541);
            this.btnUpdateArea.Name = "btnUpdateArea";
            this.btnUpdateArea.Size = new System.Drawing.Size(97, 35);
            this.btnUpdateArea.TabIndex = 3;
            this.btnUpdateArea.Text = "Sửa";
            this.btnUpdateArea.UseVisualStyleBackColor = true;
            this.btnUpdateArea.Click += new System.EventHandler(this.btnUpdateArea_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.btnAddTable);
            this.groupBox2.Controls.Add(this.btnEditTable);
            this.groupBox2.Controls.Add(this.flpTable);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(731, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(655, 666);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Bàn";
            this.groupBox2.Visible = false;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(535, 580);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 33);
            this.button1.TabIndex = 4;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnAddTable
            // 
            this.btnAddTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddTable.Location = new System.Drawing.Point(535, 502);
            this.btnAddTable.Name = "btnAddTable";
            this.btnAddTable.Size = new System.Drawing.Size(114, 33);
            this.btnAddTable.TabIndex = 2;
            this.btnAddTable.Text = "Thêm";
            this.btnAddTable.UseVisualStyleBackColor = true;
            this.btnAddTable.Click += new System.EventHandler(this.btnAddTable_Click);
            // 
            // btnEditTable
            // 
            this.btnEditTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditTable.Location = new System.Drawing.Point(535, 541);
            this.btnEditTable.Name = "btnEditTable";
            this.btnEditTable.Size = new System.Drawing.Size(114, 33);
            this.btnEditTable.TabIndex = 3;
            this.btnEditTable.Text = "Sửa";
            this.btnEditTable.UseVisualStyleBackColor = true;
            this.btnEditTable.Click += new System.EventHandler(this.btnEditTable_Click);
            // 
            // flpTable
            // 
            this.flpTable.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.flpTable.Location = new System.Drawing.Point(6, 33);
            this.flpTable.Name = "flpTable";
            this.flpTable.Size = new System.Drawing.Size(643, 447);
            this.flpTable.TabIndex = 0;
            // 
            // frmArea
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1398, 690);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmArea";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmArea";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmArea_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpArea;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAddArea;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnUpdateArea;
        private System.Windows.Forms.Button btnDeleteArea;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnAddTable;
        private System.Windows.Forms.Button btnEditTable;
        private System.Windows.Forms.FlowLayoutPanel flpTable;
    }
}