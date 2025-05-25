namespace InventoryManagementSystem
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.cbPass = new System.Windows.Forms.CheckBox();
            this.btnSign = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlLoginBox = new System.Windows.Forms.Panel();
            this.btnCreate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlLoginBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(478, 93);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(8, 8);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // txtUserName
            // 
            this.txtUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUserName.Location = new System.Drawing.Point(51, 175);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(224, 20);
            this.txtUserName.TabIndex = 1;
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(51, 212);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(224, 20);
            this.txtPass.TabIndex = 2;
            // 
            // cbPass
            // 
            this.cbPass.AutoSize = true;
            this.cbPass.Font = new System.Drawing.Font("Constantia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPass.Location = new System.Drawing.Point(178, 237);
            this.cbPass.Name = "cbPass";
            this.cbPass.Size = new System.Drawing.Size(103, 17);
            this.cbPass.TabIndex = 3;
            this.cbPass.Text = "Show password?";
            this.cbPass.UseVisualStyleBackColor = true;
            this.cbPass.CheckedChanged += new System.EventHandler(this.cbPass_CheckedChanged);
            // 
            // btnSign
            // 
            this.btnSign.BackColor = System.Drawing.Color.CadetBlue;
            this.btnSign.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSign.ForeColor = System.Drawing.Color.White;
            this.btnSign.Location = new System.Drawing.Point(89, 263);
            this.btnSign.Name = "btnSign";
            this.btnSign.Size = new System.Drawing.Size(140, 30);
            this.btnSign.TabIndex = 4;
            this.btnSign.Text = "SIGN IN";
            this.btnSign.UseVisualStyleBackColor = false;
            this.btnSign.Click += new System.EventHandler(this.btnSign_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(-2, -40);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(329, 260);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pnlLoginBox
            // 
            this.pnlLoginBox.BackColor = System.Drawing.Color.Azure;
            this.pnlLoginBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLoginBox.Controls.Add(this.btnCreate);
            this.pnlLoginBox.Controls.Add(this.btnSign);
            this.pnlLoginBox.Controls.Add(this.cbPass);
            this.pnlLoginBox.Controls.Add(this.txtPass);
            this.pnlLoginBox.Controls.Add(this.txtUserName);
            this.pnlLoginBox.Controls.Add(this.pictureBox1);
            this.pnlLoginBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pnlLoginBox.Location = new System.Drawing.Point(47, 32);
            this.pnlLoginBox.Name = "pnlLoginBox";
            this.pnlLoginBox.Padding = new System.Windows.Forms.Padding(10);
            this.pnlLoginBox.Size = new System.Drawing.Size(329, 355);
            this.pnlLoginBox.TabIndex = 1;
            // 
            // btnCreate
            // 
            this.btnCreate.BackColor = System.Drawing.Color.CadetBlue;
            this.btnCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreate.ForeColor = System.Drawing.Color.White;
            this.btnCreate.Location = new System.Drawing.Point(123, 301);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 5;
            this.btnCreate.Text = "Create user";
            this.btnCreate.UseVisualStyleBackColor = false;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(427, 422);
            this.Controls.Add(this.pnlLoginBox);
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlLoginBox.ResumeLayout(false);
            this.pnlLoginBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.CheckBox cbPass;
        private System.Windows.Forms.Button btnSign;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel pnlLoginBox;
        private System.Windows.Forms.Button btnCreate;
    }
}

