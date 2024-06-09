namespace MinigameOlympia {
    partial class DangNhap {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DangNhap));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.btnSignIn = new System.Windows.Forms.Button();
            this.X = new System.Windows.Forms.Button();
            this.lblForgetPass = new System.Windows.Forms.Label();
            this.btnSignUp = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.ptbPassword = new System.Windows.Forms.PictureBox();
            this.lblAlertUsername = new System.Windows.Forms.Label();
            this.lblAlertPassword = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbPassword)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(301, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(303, 31);
            this.label1.TabIndex = 8;
            this.label1.Text = "Đăng nhập vào tài khoản";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(303, 67);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 19);
            this.label2.TabIndex = 9;
            this.label2.Text = "Username:";
            // 
            // tbUsername
            // 
            this.tbUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.tbUsername.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tbUsername.Location = new System.Drawing.Point(307, 88);
            this.tbUsername.Margin = new System.Windows.Forms.Padding(2);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(287, 24);
            this.tbUsername.TabIndex = 10;
            this.tbUsername.TextChanged += new System.EventHandler(this.tbUsername_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Tai Le", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(306, 146);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 19);
            this.label3.TabIndex = 11;
            this.label3.Text = "Mật khẩu:";
            // 
            // tbPassword
            // 
            this.tbPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.tbPassword.Location = new System.Drawing.Point(307, 167);
            this.tbPassword.Margin = new System.Windows.Forms.Padding(2);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(287, 24);
            this.tbPassword.TabIndex = 12;
            this.tbPassword.TextChanged += new System.EventHandler(this.PasswordTextbox);
            // 
            // btnSignIn
            // 
            this.btnSignIn.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnSignIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSignIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnSignIn.ForeColor = System.Drawing.Color.White;
            this.btnSignIn.Location = new System.Drawing.Point(358, 299);
            this.btnSignIn.Margin = new System.Windows.Forms.Padding(2);
            this.btnSignIn.Name = "btnSignIn";
            this.btnSignIn.Size = new System.Drawing.Size(181, 38);
            this.btnSignIn.TabIndex = 14;
            this.btnSignIn.Text = "ĐĂNG NHẬP";
            this.btnSignIn.UseVisualStyleBackColor = false;
            this.btnSignIn.Click += new System.EventHandler(this.btnSignIn_Click);
            // 
            // X
            // 
            this.X.BackColor = System.Drawing.Color.White;
            this.X.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.X.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.X.Location = new System.Drawing.Point(760, 7);
            this.X.Margin = new System.Windows.Forms.Padding(2);
            this.X.Name = "X";
            this.X.Size = new System.Drawing.Size(31, 32);
            this.X.TabIndex = 15;
            this.X.Text = "X";
            this.X.UseVisualStyleBackColor = false;
            // 
            // lblForgetPass
            // 
            this.lblForgetPass.AutoSize = true;
            this.lblForgetPass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblForgetPass.Font = new System.Drawing.Font("Microsoft Tai Le", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblForgetPass.Location = new System.Drawing.Point(506, 231);
            this.lblForgetPass.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblForgetPass.Name = "lblForgetPass";
            this.lblForgetPass.Size = new System.Drawing.Size(118, 19);
            this.lblForgetPass.TabIndex = 17;
            this.lblForgetPass.Text = "Quên mật khẩu";
            this.lblForgetPass.Click += new System.EventHandler(this.ForgetPassword);
            // 
            // btnSignUp
            // 
            this.btnSignUp.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnSignUp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSignUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnSignUp.ForeColor = System.Drawing.Color.White;
            this.btnSignUp.Location = new System.Drawing.Point(47, 299);
            this.btnSignUp.Margin = new System.Windows.Forms.Padding(2);
            this.btnSignUp.Name = "btnSignUp";
            this.btnSignUp.Size = new System.Drawing.Size(181, 38);
            this.btnSignUp.TabIndex = 20;
            this.btnSignUp.Text = "ĐĂNG KÝ";
            this.btnSignUp.UseVisualStyleBackColor = false;
            this.btnSignUp.Click += new System.EventHandler(this.btnSignUp_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MinigameOlympia.Properties.Resources.BackgroundLogin;
            this.pictureBox1.Location = new System.Drawing.Point(2, 1);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(267, 366);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label10.Font = new System.Drawing.Font("Microsoft Tai Le", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label10.Location = new System.Drawing.Point(12, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 19);
            this.label10.TabIndex = 24;
            this.label10.Text = "Quay về";
            this.label10.Click += new System.EventHandler(this.BackToRootForm);
            // 
            // ptbPassword
            // 
            this.ptbPassword.BackColor = System.Drawing.Color.White;
            this.ptbPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ptbPassword.Image = global::MinigameOlympia.Properties.Resources.ShowPass;
            this.ptbPassword.Location = new System.Drawing.Point(563, 169);
            this.ptbPassword.Name = "ptbPassword";
            this.ptbPassword.Size = new System.Drawing.Size(29, 20);
            this.ptbPassword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbPassword.TabIndex = 32;
            this.ptbPassword.TabStop = false;
            this.ptbPassword.Click += new System.EventHandler(this.ptbPassword_Click);
            // 
            // lblAlertUsername
            // 
            this.lblAlertUsername.AutoSize = true;
            this.lblAlertUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlertUsername.ForeColor = System.Drawing.Color.Red;
            this.lblAlertUsername.Location = new System.Drawing.Point(307, 114);
            this.lblAlertUsername.Name = "lblAlertUsername";
            this.lblAlertUsername.Size = new System.Drawing.Size(13, 13);
            this.lblAlertUsername.TabIndex = 33;
            this.lblAlertUsername.Text = "a";
            this.lblAlertUsername.Visible = false;
            // 
            // lblAlertPassword
            // 
            this.lblAlertPassword.AutoSize = true;
            this.lblAlertPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlertPassword.ForeColor = System.Drawing.Color.Red;
            this.lblAlertPassword.Location = new System.Drawing.Point(307, 193);
            this.lblAlertPassword.Name = "lblAlertPassword";
            this.lblAlertPassword.Size = new System.Drawing.Size(13, 13);
            this.lblAlertPassword.TabIndex = 34;
            this.lblAlertPassword.Text = "a";
            this.lblAlertPassword.Visible = false;
            // 
            // DangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(648, 368);
            this.Controls.Add(this.lblAlertPassword);
            this.Controls.Add(this.lblAlertUsername);
            this.Controls.Add(this.ptbPassword);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnSignUp);
            this.Controls.Add(this.lblForgetPass);
            this.Controls.Add(this.X);
            this.Controls.Add(this.btnSignIn);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbUsername);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "DangNhap";
            this.Text = "SignIn";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbPassword)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Button btnSignIn;
        private System.Windows.Forms.Button X;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblForgetPass;
        private System.Windows.Forms.Button btnSignUp;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox ptbPassword;
        private System.Windows.Forms.Label lblAlertUsername;
        private System.Windows.Forms.Label lblAlertPassword;
    }
}