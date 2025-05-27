namespace InventoryManagementSystem.frm
{
    partial class AddProduct
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
            this.gnbtnCancel = new Guna.UI2.WinForms.Guna2Button();
            this.gnbtnSave = new Guna.UI2.WinForms.Guna2Button();
            this.dgAddProducts = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgAddProducts)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // gnbtnCancel
            // 
            this.gnbtnCancel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(19)))), ((int)(((byte)(38)))));
            this.gnbtnCancel.BorderRadius = 10;
            this.gnbtnCancel.BorderThickness = 1;
            this.gnbtnCancel.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.gnbtnCancel.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.gnbtnCancel.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.gnbtnCancel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.gnbtnCancel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(19)))), ((int)(((byte)(38)))));
            this.gnbtnCancel.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gnbtnCancel.ForeColor = System.Drawing.Color.White;
            this.gnbtnCancel.HoverState.FillColor = System.Drawing.Color.White;
            this.gnbtnCancel.HoverState.ForeColor = System.Drawing.Color.Black;
            this.gnbtnCancel.Location = new System.Drawing.Point(415, 387);
            this.gnbtnCancel.Name = "gnbtnCancel";
            this.gnbtnCancel.Size = new System.Drawing.Size(107, 40);
            this.gnbtnCancel.TabIndex = 33;
            this.gnbtnCancel.Text = "Cancel";
            this.gnbtnCancel.Click += new System.EventHandler(this.gnbtnCancel_Click);
            // 
            // gnbtnSave
            // 
            this.gnbtnSave.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(19)))), ((int)(((byte)(38)))));
            this.gnbtnSave.BorderRadius = 10;
            this.gnbtnSave.BorderThickness = 1;
            this.gnbtnSave.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.gnbtnSave.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.gnbtnSave.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.gnbtnSave.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.gnbtnSave.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(19)))), ((int)(((byte)(38)))));
            this.gnbtnSave.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gnbtnSave.ForeColor = System.Drawing.Color.White;
            this.gnbtnSave.HoverState.FillColor = System.Drawing.Color.White;
            this.gnbtnSave.HoverState.ForeColor = System.Drawing.Color.Black;
            this.gnbtnSave.Location = new System.Drawing.Point(532, 387);
            this.gnbtnSave.Name = "gnbtnSave";
            this.gnbtnSave.Size = new System.Drawing.Size(107, 40);
            this.gnbtnSave.TabIndex = 32;
            this.gnbtnSave.Text = "Save";
            this.gnbtnSave.Click += new System.EventHandler(this.gnbtnSave_Click);
            // 
            // dgAddProducts
            // 
            this.dgAddProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgAddProducts.BackgroundColor = System.Drawing.Color.White;
            this.dgAddProducts.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgAddProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAddProducts.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(19)))), ((int)(((byte)(38)))));
            this.dgAddProducts.Location = new System.Drawing.Point(26, 69);
            this.dgAddProducts.Name = "dgAddProducts";
            this.dgAddProducts.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgAddProducts.RowHeadersVisible = false;
            this.dgAddProducts.Size = new System.Drawing.Size(620, 308);
            this.dgAddProducts.TabIndex = 31;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(11, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Add Product\r\n";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(19)))), ((int)(((byte)(38)))));
            this.panel3.Controls.Add(this.label3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(674, 40);
            this.panel3.TabIndex = 30;
            // 
            // AddProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 440);
            this.Controls.Add(this.dgAddProducts);
            this.Controls.Add(this.gnbtnCancel);
            this.Controls.Add(this.gnbtnSave);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddProduct";
            this.Load += new System.EventHandler(this.AddProduct_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgAddProducts)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button gnbtnCancel;
        private Guna.UI2.WinForms.Guna2Button gnbtnSave;
        private System.Windows.Forms.DataGridView dgAddProducts;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
    }
}