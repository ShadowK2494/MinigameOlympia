namespace MinigameOlympia {
    partial class TaoLaiMatKhau {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaoLaiMatKhau));
            this.btnSubmit = new System.Windows.Forms.Button();
            this.tbRePass = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ptbPassword = new System.Windows.Forms.PictureBox();
            this.ptbRePass = new System.Windows.Forms.PictureBox();
            this.lblAlertPassword = new System.Windows.Forms.Label();
            this.lblAlertRePass = new System.Windows.Forms.Label();
            this.lblBack = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbRePass)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnSubmit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.Location = new System.Drawing.Point(339, 248);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(2);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(181, 38);
            this.btnSubmit.TabIndex = 28;
            this.btnSubmit.Text = "Xác nhận";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_ClickAsync);
            // 
            // tbRePass
            // 
            this.tbRePass.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.tbRePass.Location = new System.Drawing.Point(278, 172);
            this.tbRePass.Margin = new System.Windows.Forms.Padding(2);
            this.tbRePass.Name = "tbRePass";
            this.tbRePass.Size = new System.Drawing.Size(287, 24);
            this.tbRePass.TabIndex = 27;
            this.tbRePass.TextChanged += new System.EventHandler(this.RePasswordTextbox);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(275, 151);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 18);
            this.label3.TabIndex = 26;
            this.label3.Text = "Nhập lại mật khẩu:";
            // 
            // tbPassword
            // 
            this.tbPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.tbPassword.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tbPassword.Location = new System.Drawing.Point(278, 93);
            this.tbPassword.Margin = new System.Windows.Forms.Padding(2);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(287, 24);
            this.tbPassword.TabIndex = 25;
            this.tbPassword.TextChanged += new System.EventHandler(this.PasswordTextbox);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(275, 72);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 18);
            this.label2.TabIndex = 24;
            this.label2.Text = "Mật khẩu mới:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(345, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 29);
            this.label1.TabIndex = 23;
            this.label1.Text = "Tạo lại mật khẩu";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MinigameOlympia.Properties.Resources.BackgroundLogin;
            this.pictureBox1.Location = new System.Drawing.Point(-5, -1);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(266, 368);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            // 
            // ptbPassword
            // 
            this.ptbPassword.BackColor = System.Drawing.Color.White;
            this.ptbPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ptbPassword.Image = global::MinigameOlympia.Properties.Resources.ShowPass;
            this.ptbPassword.Location = new System.Drawing.Point(534, 95);
            this.ptbPassword.Name = "ptbPassword";
            this.ptbPassword.Size = new System.Drawing.Size(29, 20);
            this.ptbPassword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbPassword.TabIndex = 33;
            this.ptbPassword.TabStop = false;
            this.ptbPassword.Click += new System.EventHandler(this.ptbPassword_Click);
            // 
            // ptbRePass
            // 
            this.ptbRePass.BackColor = System.Drawing.Color.White;
            this.ptbRePass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ptbRePass.Image = global::MinigameOlympia.Properties.Resources.ShowPass;
            this.ptbRePass.Location = new System.Drawing.Point(534, 174);
            this.ptbRePass.Name = "ptbRePass";
            this.ptbRePass.Size = new System.Drawing.Size(29, 20);
            this.ptbRePass.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbRePass.TabIndex = 34;
            this.ptbRePass.TabStop = false;
            this.ptbRePass.Click += new System.EventHandler(this.ptbRePass_Click);
            // 
            // lblAlertPassword
            // 
            this.lblAlertPassword.AutoSize = true;
            this.lblAlertPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlertPassword.ForeColor = System.Drawing.Color.Red;
            this.lblAlertPassword.Location = new System.Drawing.Point(276, 119);
            this.lblAlertPassword.Name = "lblAlertPassword";
            this.lblAlertPassword.Size = new System.Drawing.Size(13, 13);
            this.lblAlertPassword.TabIndex = 35;
            this.lblAlertPassword.Text = "a";
            this.lblAlertPassword.Visible = false;
            // 
            // lblAlertRePass
            // 
            this.lblAlertRePass.AutoSize = true;
            this.lblAlertRePass.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlertRePass.ForeColor = System.Drawing.Color.Red;
            this.lblAlertRePass.Location = new System.Drawing.Point(276, 198);
            this.lblAlertRePass.Name = "lblAlertRePass";
            this.lblAlertRePass.Size = new System.Drawing.Size(13, 13);
            this.lblAlertRePass.TabIndex = 36;
            this.lblAlertRePass.Text = "a";
            this.lblAlertRePass.Visible = false;
            // 
            // lblBack
            // 
            this.lblBack.AutoSize = true;
            this.lblBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblBack.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBack.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblBack.Location = new System.Drawing.Point(5, 9);
            this.lblBack.Name = "lblBack";
            this.lblBack.Size = new System.Drawing.Size(66, 18);
            this.lblBack.TabIndex = 37;
            this.lblBack.Text = "Quay về";
            this.lblBack.Click += new System.EventHandler(this.BackToSignInForm);
            // 
            // CreateNewPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 317);
            this.Controls.Add(this.lblBack);
            this.Controls.Add(this.lblAlertRePass);
            this.Controls.Add(this.lblAlertPassword);
            this.Controls.Add(this.ptbRePass);
            this.Controls.Add(this.ptbPassword);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.tbRePass);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "CreateNewPassword";
            this.Text = "Tạo lại mật khẩu";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbRePass)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.TextBox tbRePass;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox ptbPassword;
        private System.Windows.Forms.PictureBox ptbRePass;
        private System.Windows.Forms.Label lblAlertPassword;
        private System.Windows.Forms.Label lblAlertRePass;
        private System.Windows.Forms.Label lblBack;
    }
}