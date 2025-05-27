namespace InventoryManagementSystem
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.gbbtnExit = new Guna.UI2.WinForms.Guna2ControlBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnsupplier = new System.Windows.Forms.Button();
            this.lblrole = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.btnProdInventory = new System.Windows.Forms.Button();
            this.btncategpries = new System.Windows.Forms.Button();
            this.btnProducts = new System.Windows.Forms.Button();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblName = new System.Windows.Forms.Label();
            this.panelform = new Guna.UI2.WinForms.Guna2Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(19)))), ((int)(((byte)(38)))));
            this.panel1.Controls.Add(this.gbbtnExit);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1200, 40);
            this.panel1.TabIndex = 2;
            // 
            // gbbtnExit
            // 
            this.gbbtnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbbtnExit.BorderColor = System.Drawing.Color.DarkSlateGray;
            this.gbbtnExit.BorderRadius = 3;
            this.gbbtnExit.BorderThickness = 1;
            this.gbbtnExit.CustomClick = true;
            this.gbbtnExit.FillColor = System.Drawing.Color.DarkSlateGray;
            this.gbbtnExit.HoverState.FillColor = System.Drawing.Color.SlateGray;
            this.gbbtnExit.IconColor = System.Drawing.Color.White;
            this.gbbtnExit.Location = new System.Drawing.Point(1162, 8);
            this.gbbtnExit.Name = "gbbtnExit";
            this.gbbtnExit.Size = new System.Drawing.Size(29, 22);
            this.gbbtnExit.TabIndex = 14;
            this.gbbtnExit.Click += new System.EventHandler(this.gbbtnExit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(11, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(256, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Inventory Management System";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(19)))), ((int)(((byte)(38)))));
            this.panel2.Controls.Add(this.btnsupplier);
            this.panel2.Controls.Add(this.lblrole);
            this.panel2.Controls.Add(this.button7);
            this.panel2.Controls.Add(this.btnLogout);
            this.panel2.Controls.Add(this.button8);
            this.panel2.Controls.Add(this.btnProdInventory);
            this.panel2.Controls.Add(this.btncategpries);
            this.panel2.Controls.Add(this.btnProducts);
            this.panel2.Controls.Add(this.btnDashboard);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.lblName);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 40);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(184, 560);
            this.panel2.TabIndex = 24;
            // 
            // btnsupplier
            // 
            this.btnsupplier.FlatAppearance.BorderSize = 0;
            this.btnsupplier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsupplier.ForeColor = System.Drawing.Color.White;
            this.btnsupplier.Image = ((System.Drawing.Image)(resources.GetObject("btnsupplier.Image")));
            this.btnsupplier.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnsupplier.Location = new System.Drawing.Point(8, 296);
            this.btnsupplier.Name = "btnsupplier";
            this.btnsupplier.Size = new System.Drawing.Size(175, 36);
            this.btnsupplier.TabIndex = 26;
            this.btnsupplier.Text = "   Supplier";
            this.btnsupplier.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnsupplier.UseVisualStyleBackColor = true;
            this.btnsupplier.Click += new System.EventHandler(this.btnsupplier_Click);
            // 
            // lblrole
            // 
            this.lblrole.AutoSize = true;
            this.lblrole.ForeColor = System.Drawing.Color.White;
            this.lblrole.Location = new System.Drawing.Point(60, 109);
            this.lblrole.Name = "lblrole";
            this.lblrole.Size = new System.Drawing.Size(67, 13);
            this.lblrole.TabIndex = 24;
            this.lblrole.Text = "Administrator";
            // 
            // button7
            // 
            this.button7.FlatAppearance.BorderSize = 0;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.ForeColor = System.Drawing.Color.White;
            this.button7.Image = ((System.Drawing.Image)(resources.GetObject("button7.Image")));
            this.button7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button7.Location = new System.Drawing.Point(8, 338);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(175, 36);
            this.button7.TabIndex = 12;
            this.button7.Text = "  User Settings";
            this.button7.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click_1);
            // 
            // btnLogout
            // 
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Image = ((System.Drawing.Image)(resources.GetObject("btnLogout.Image")));
            this.btnLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.Location = new System.Drawing.Point(3, 521);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(178, 36);
            this.btnLogout.TabIndex = 11;
            this.btnLogout.Text = "  Logout";
            this.btnLogout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // button8
            // 
            this.button8.FlatAppearance.BorderSize = 0;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.ForeColor = System.Drawing.Color.White;
            this.button8.Image = ((System.Drawing.Image)(resources.GetObject("button8.Image")));
            this.button8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button8.Location = new System.Drawing.Point(3, 628);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(301, 36);
            this.button8.TabIndex = 10;
            this.button8.Text = "  Logout";
            this.button8.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button8.UseVisualStyleBackColor = true;
            // 
            // btnProdInventory
            // 
            this.btnProdInventory.FlatAppearance.BorderSize = 0;
            this.btnProdInventory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProdInventory.ForeColor = System.Drawing.Color.White;
            this.btnProdInventory.Image = ((System.Drawing.Image)(resources.GetObject("btnProdInventory.Image")));
            this.btnProdInventory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProdInventory.Location = new System.Drawing.Point(7, 254);
            this.btnProdInventory.Name = "btnProdInventory";
            this.btnProdInventory.Size = new System.Drawing.Size(175, 36);
            this.btnProdInventory.TabIndex = 7;
            this.btnProdInventory.Text = "  Product Inventory";
            this.btnProdInventory.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProdInventory.UseVisualStyleBackColor = true;
            this.btnProdInventory.Click += new System.EventHandler(this.btnProdInventory_Click_1);
            // 
            // btncategpries
            // 
            this.btncategpries.FlatAppearance.BorderSize = 0;
            this.btncategpries.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncategpries.ForeColor = System.Drawing.Color.White;
            this.btncategpries.Image = ((System.Drawing.Image)(resources.GetObject("btncategpries.Image")));
            this.btncategpries.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btncategpries.Location = new System.Drawing.Point(9, 212);
            this.btncategpries.Name = "btncategpries";
            this.btncategpries.Size = new System.Drawing.Size(173, 36);
            this.btncategpries.TabIndex = 6;
            this.btncategpries.Text = "   Categories";
            this.btncategpries.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btncategpries.UseVisualStyleBackColor = true;
            this.btncategpries.Click += new System.EventHandler(this.btncategpries_Click);
            // 
            // btnProducts
            // 
            this.btnProducts.FlatAppearance.BorderSize = 0;
            this.btnProducts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProducts.ForeColor = System.Drawing.Color.White;
            this.btnProducts.Image = ((System.Drawing.Image)(resources.GetObject("btnProducts.Image")));
            this.btnProducts.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProducts.Location = new System.Drawing.Point(8, 171);
            this.btnProducts.Name = "btnProducts";
            this.btnProducts.Size = new System.Drawing.Size(174, 36);
            this.btnProducts.TabIndex = 5;
            this.btnProducts.Text = "  Products";
            this.btnProducts.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProducts.UseVisualStyleBackColor = true;
            this.btnProducts.Click += new System.EventHandler(this.btnProducts_Click_1);
            // 
            // btnDashboard
            // 
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.ForeColor = System.Drawing.Color.White;
            this.btnDashboard.Image = ((System.Drawing.Image)(resources.GetObject("btnDashboard.Image")));
            this.btnDashboard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.Location = new System.Drawing.Point(8, 129);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(174, 36);
            this.btnDashboard.TabIndex = 3;
            this.btnDashboard.Text = "  Dashboard";
            this.btnDashboard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDashboard.UseVisualStyleBackColor = true;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(52, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(80, 80);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lblName
            // 
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.White;
            this.lblName.Location = new System.Drawing.Point(6, 81);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(176, 39);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Username";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelform
            // 
            this.panelform.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelform.Location = new System.Drawing.Point(190, 46);
            this.panelform.Name = "panelform";
            this.panelform.Size = new System.Drawing.Size(998, 542);
            this.panelform.TabIndex = 25;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1200, 600);
            this.Controls.Add(this.panelform);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2ControlBox gbbtnExit;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblrole;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button btnProdInventory;
        private System.Windows.Forms.Button btncategpries;
        private System.Windows.Forms.Button btnProducts;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblName;
        private Guna.UI2.WinForms.Guna2Panel panelform;
        private System.Windows.Forms.Button btnsupplier;
    }
}