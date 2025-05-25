namespace InventoryManagementSystem.frm
{
    partial class UserSettingsForm
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
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.gbtxtCurrentUser = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.guna2Panel4 = new Guna.UI2.WinForms.Guna2Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvstaff = new System.Windows.Forms.DataGridView();
            this.dgvsuperadmin = new System.Windows.Forms.DataGridView();
            this.dgvadminuser = new System.Windows.Forms.DataGridView();
            this.btnadd = new Guna.UI2.WinForms.Guna2Button();
            this.btnrefresh = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.guna2Panel1.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            this.guna2Panel3.SuspendLayout();
            this.guna2Panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvstaff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvsuperadmin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvadminuser)).BeginInit();
            this.SuspendLayout();
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(19)))), ((int)(((byte)(38)))));
            this.guna2Panel1.BorderRadius = 6;
            this.guna2Panel1.BorderThickness = 1;
            this.guna2Panel1.Controls.Add(this.label2);
            this.guna2Panel1.Location = new System.Drawing.Point(26, 30);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(948, 42);
            this.guna2Panel1.TabIndex = 29;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(3, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 25);
            this.label2.TabIndex = 10;
            this.label2.Text = "User Settings";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(19)))), ((int)(((byte)(38)))));
            this.label3.Location = new System.Drawing.Point(23, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 17);
            this.label3.TabIndex = 32;
            this.label3.Text = "Current User:";
            // 
            // gbtxtCurrentUser
            // 
            this.gbtxtCurrentUser.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(19)))), ((int)(((byte)(38)))));
            this.gbtxtCurrentUser.BorderRadius = 4;
            this.gbtxtCurrentUser.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.gbtxtCurrentUser.DefaultText = "";
            this.gbtxtCurrentUser.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.gbtxtCurrentUser.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.gbtxtCurrentUser.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.gbtxtCurrentUser.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.gbtxtCurrentUser.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.gbtxtCurrentUser.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gbtxtCurrentUser.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.gbtxtCurrentUser.Location = new System.Drawing.Point(112, 95);
            this.gbtxtCurrentUser.Name = "gbtxtCurrentUser";
            this.gbtxtCurrentUser.PlaceholderText = "";
            this.gbtxtCurrentUser.ReadOnly = true;
            this.gbtxtCurrentUser.SelectedText = "";
            this.gbtxtCurrentUser.Size = new System.Drawing.Size(200, 27);
            this.gbtxtCurrentUser.TabIndex = 33;
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(19)))), ((int)(((byte)(38)))));
            this.guna2Panel2.Controls.Add(this.label4);
            this.guna2Panel2.Location = new System.Drawing.Point(26, 148);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(465, 33);
            this.guna2Panel2.TabIndex = 34;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(7, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 17);
            this.label4.TabIndex = 37;
            this.label4.Text = "Admin/Owner";
            // 
            // guna2Panel3
            // 
            this.guna2Panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(19)))), ((int)(((byte)(38)))));
            this.guna2Panel3.Controls.Add(this.label5);
            this.guna2Panel3.Location = new System.Drawing.Point(524, 148);
            this.guna2Panel3.Name = "guna2Panel3";
            this.guna2Panel3.Size = new System.Drawing.Size(446, 33);
            this.guna2Panel3.TabIndex = 35;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(8, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 17);
            this.label5.TabIndex = 38;
            this.label5.Text = "Staff";
            // 
            // guna2Panel4
            // 
            this.guna2Panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(19)))), ((int)(((byte)(38)))));
            this.guna2Panel4.Controls.Add(this.label6);
            this.guna2Panel4.Location = new System.Drawing.Point(26, 321);
            this.guna2Panel4.Name = "guna2Panel4";
            this.guna2Panel4.Size = new System.Drawing.Size(465, 33);
            this.guna2Panel4.TabIndex = 36;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(8, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 17);
            this.label6.TabIndex = 38;
            this.label6.Text = "Super Admin";
            // 
            // dgvstaff
            // 
            this.dgvstaff.AllowUserToAddRows = false;
            this.dgvstaff.AllowUserToDeleteRows = false;
            this.dgvstaff.AllowUserToResizeColumns = false;
            this.dgvstaff.AllowUserToResizeRows = false;
            this.dgvstaff.BackgroundColor = System.Drawing.Color.White;
            this.dgvstaff.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvstaff.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgvstaff.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvstaff.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvstaff.Location = new System.Drawing.Point(524, 187);
            this.dgvstaff.MultiSelect = false;
            this.dgvstaff.Name = "dgvstaff";
            this.dgvstaff.RowHeadersVisible = false;
            this.dgvstaff.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvstaff.Size = new System.Drawing.Size(450, 116);
            this.dgvstaff.TabIndex = 37;
            // 
            // dgvsuperadmin
            // 
            this.dgvsuperadmin.AllowUserToAddRows = false;
            this.dgvsuperadmin.AllowUserToDeleteRows = false;
            this.dgvsuperadmin.AllowUserToResizeColumns = false;
            this.dgvsuperadmin.AllowUserToResizeRows = false;
            this.dgvsuperadmin.BackgroundColor = System.Drawing.Color.White;
            this.dgvsuperadmin.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvsuperadmin.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgvsuperadmin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvsuperadmin.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvsuperadmin.Location = new System.Drawing.Point(26, 360);
            this.dgvsuperadmin.MultiSelect = false;
            this.dgvsuperadmin.Name = "dgvsuperadmin";
            this.dgvsuperadmin.RowHeadersVisible = false;
            this.dgvsuperadmin.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvsuperadmin.Size = new System.Drawing.Size(465, 116);
            this.dgvsuperadmin.TabIndex = 38;
            // 
            // dgvadminuser
            // 
            this.dgvadminuser.AllowUserToAddRows = false;
            this.dgvadminuser.AllowUserToDeleteRows = false;
            this.dgvadminuser.AllowUserToResizeColumns = false;
            this.dgvadminuser.AllowUserToResizeRows = false;
            this.dgvadminuser.BackgroundColor = System.Drawing.Color.White;
            this.dgvadminuser.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvadminuser.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgvadminuser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvadminuser.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvadminuser.Location = new System.Drawing.Point(26, 187);
            this.dgvadminuser.MultiSelect = false;
            this.dgvadminuser.Name = "dgvadminuser";
            this.dgvadminuser.RowHeadersVisible = false;
            this.dgvadminuser.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvadminuser.Size = new System.Drawing.Size(465, 116);
            this.dgvadminuser.TabIndex = 39;
            // 
            // btnadd
            // 
            this.btnadd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnadd.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(19)))), ((int)(((byte)(38)))));
            this.btnadd.BorderRadius = 10;
            this.btnadd.BorderThickness = 1;
            this.btnadd.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnadd.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnadd.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnadd.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnadd.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(19)))), ((int)(((byte)(38)))));
            this.btnadd.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnadd.ForeColor = System.Drawing.Color.White;
            this.btnadd.HoverState.FillColor = System.Drawing.Color.White;
            this.btnadd.HoverState.ForeColor = System.Drawing.Color.Black;
            this.btnadd.Location = new System.Drawing.Point(760, 444);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(104, 32);
            this.btnadd.TabIndex = 40;
            this.btnadd.Text = "Add new";
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // btnrefresh
            // 
            this.btnrefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnrefresh.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(19)))), ((int)(((byte)(38)))));
            this.btnrefresh.BorderRadius = 10;
            this.btnrefresh.BorderThickness = 1;
            this.btnrefresh.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnrefresh.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnrefresh.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnrefresh.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnrefresh.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(19)))), ((int)(((byte)(38)))));
            this.btnrefresh.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnrefresh.ForeColor = System.Drawing.Color.White;
            this.btnrefresh.HoverState.FillColor = System.Drawing.Color.White;
            this.btnrefresh.HoverState.ForeColor = System.Drawing.Color.Black;
            this.btnrefresh.Location = new System.Drawing.Point(870, 444);
            this.btnrefresh.Name = "btnrefresh";
            this.btnrefresh.Size = new System.Drawing.Size(104, 32);
            this.btnrefresh.TabIndex = 41;
            this.btnrefresh.Text = "Refresh";
            this.btnrefresh.Click += new System.EventHandler(this.btnrefresh_Click);
            // 
            // UserSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1025, 586);
            this.Controls.Add(this.btnrefresh);
            this.Controls.Add(this.btnadd);
            this.Controls.Add(this.dgvadminuser);
            this.Controls.Add(this.dgvsuperadmin);
            this.Controls.Add(this.dgvstaff);
            this.Controls.Add(this.guna2Panel4);
            this.Controls.Add(this.guna2Panel3);
            this.Controls.Add(this.guna2Panel2);
            this.Controls.Add(this.gbtxtCurrentUser);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.guna2Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UserSettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProductsForm";
            this.Load += new System.EventHandler(this.UserSettingsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel2.PerformLayout();
            this.guna2Panel3.ResumeLayout(false);
            this.guna2Panel3.PerformLayout();
            this.guna2Panel4.ResumeLayout(false);
            this.guna2Panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvstaff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvsuperadmin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvadminuser)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2TextBox gbtxtCurrentUser;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvadminuser;
        private System.Windows.Forms.DataGridView dgvsuperadmin;
        private System.Windows.Forms.DataGridView dgvstaff;
        private Guna.UI2.WinForms.Guna2Button btnadd;
        private Guna.UI2.WinForms.Guna2Button btnrefresh;
    }
}