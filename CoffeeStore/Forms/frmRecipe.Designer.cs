namespace CoffeeStore.Forms
{
    partial class frmRecipe
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
            this.btnAdd = new System.Windows.Forms.Button();
            this.dgvRecipe = new System.Windows.Forms.DataGridView();
            this.grpFood = new System.Windows.Forms.GroupBox();
            this.cboFood = new System.Windows.Forms.ComboBox();
            this.grpMaterial = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecipe)).BeginInit();
            this.grpFood.SuspendLayout();
            this.grpMaterial.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(66, 164);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(112, 36);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dgvRecipe
            // 
            this.dgvRecipe.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRecipe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecipe.Location = new System.Drawing.Point(8, 33);
            this.dgvRecipe.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvRecipe.Name = "dgvRecipe";
            this.dgvRecipe.RowHeadersVisible = false;
            this.dgvRecipe.RowHeadersWidth = 51;
            this.dgvRecipe.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvRecipe.RowTemplate.Height = 24;
            this.dgvRecipe.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRecipe.Size = new System.Drawing.Size(531, 319);
            this.dgvRecipe.TabIndex = 1;
            // 
            // grpFood
            // 
            this.grpFood.Controls.Add(this.cboFood);
            this.grpFood.Location = new System.Drawing.Point(29, 77);
            this.grpFood.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpFood.Name = "grpFood";
            this.grpFood.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpFood.Size = new System.Drawing.Size(576, 143);
            this.grpFood.TabIndex = 2;
            this.grpFood.TabStop = false;
            this.grpFood.Text = "Món:";
            // 
            // cboFood
            // 
            this.cboFood.FormattingEnabled = true;
            this.cboFood.Location = new System.Drawing.Point(53, 33);
            this.cboFood.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboFood.Name = "cboFood";
            this.cboFood.Size = new System.Drawing.Size(299, 33);
            this.cboFood.TabIndex = 0;
            this.cboFood.SelectedIndexChanged += new System.EventHandler(this.cboFood_SelectedIndexChanged);
            // 
            // grpMaterial
            // 
            this.grpMaterial.Controls.Add(this.dgvRecipe);
            this.grpMaterial.Location = new System.Drawing.Point(29, 230);
            this.grpMaterial.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpMaterial.Name = "grpMaterial";
            this.grpMaterial.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpMaterial.Size = new System.Drawing.Size(576, 375);
            this.grpMaterial.TabIndex = 3;
            this.grpMaterial.TabStop = false;
            this.grpMaterial.Text = "Nguyên liệu:";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(306, 164);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(112, 36);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Xoá";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(186, 164);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(112, 36);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "Sửa";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(15, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(590, 42);
            this.label1.TabIndex = 5;
            this.label1.Text = "ĐIỀU CHỈNH CÔNG THỨC MÓN";
            // 
            // frmRecipe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 715);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.grpMaterial);
            this.Controls.Add(this.grpFood);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmRecipe";
            this.Text = "FoodRecipe";
            this.Load += new System.EventHandler(this.frmRecipe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecipe)).EndInit();
            this.grpFood.ResumeLayout(false);
            this.grpMaterial.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView dgvRecipe;
        private System.Windows.Forms.GroupBox grpFood;
        private System.Windows.Forms.ComboBox cboFood;
        private System.Windows.Forms.GroupBox grpMaterial;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Label label1;
    }
}