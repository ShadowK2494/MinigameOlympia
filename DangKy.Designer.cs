namespace MinigameOlympia {
    partial class DangKy {
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.tbPhone = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbRePass = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.cbbGender = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblAlertName = new System.Windows.Forms.Label();
            this.lblAlertUsername = new System.Windows.Forms.Label();
            this.lblAlertPassword = new System.Windows.Forms.Label();
            this.lblAlertRePass = new System.Windows.Forms.Label();
            this.lblAlertEmail = new System.Windows.Forms.Label();
            this.lblAlertPhone = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(546, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(245, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Create your account";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(386, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Full Name:";
            // 
            // tbName
            // 
            this.tbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.tbName.Location = new System.Drawing.Point(390, 85);
            this.tbName.Multiline = true;
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(283, 27);
            this.tbName.TabIndex = 2;
            this.tbName.TextChanged += new System.EventHandler(this.tbName_TextChanged);
            this.tbName.Leave += new System.EventHandler(this.CheckName);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Tai Le", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(705, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "Email:";
            // 
            // tbUsername
            // 
            this.tbUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.tbUsername.Location = new System.Drawing.Point(390, 162);
            this.tbUsername.Multiline = true;
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(283, 28);
            this.tbUsername.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Tai Le", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(386, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 19);
            this.label4.TabIndex = 9;
            this.label4.Text = "User Name:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Tai Le", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(705, 217);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 19);
            this.label5.TabIndex = 10;
            this.label5.Text = "Gender:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Tai Le", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(386, 217);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 19);
            this.label6.TabIndex = 12;
            this.label6.Text = "Password:";
            // 
            // tbPassword
            // 
            this.tbPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.tbPassword.Location = new System.Drawing.Point(390, 239);
            this.tbPassword.Multiline = true;
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(283, 28);
            this.tbPassword.TabIndex = 13;
            this.tbPassword.TextChanged += new System.EventHandler(this.PasswordTextbox);
            // 
            // tbEmail
            // 
            this.tbEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.tbEmail.Location = new System.Drawing.Point(709, 85);
            this.tbEmail.Multiline = true;
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(316, 27);
            this.tbEmail.TabIndex = 14;
            // 
            // tbPhone
            // 
            this.tbPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.tbPhone.Location = new System.Drawing.Point(709, 162);
            this.tbPhone.Multiline = true;
            this.tbPhone.Name = "tbPhone";
            this.tbPhone.Size = new System.Drawing.Size(316, 28);
            this.tbPhone.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Tai Le", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(705, 136);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(116, 19);
            this.label7.TabIndex = 16;
            this.label7.Text = "Phone number:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Tai Le", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(386, 295);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 19);
            this.label8.TabIndex = 19;
            this.label8.Text = "Re-password:";
            // 
            // tbRePass
            // 
            this.tbRePass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.tbRePass.Location = new System.Drawing.Point(390, 317);
            this.tbRePass.Multiline = true;
            this.tbRePass.Name = "tbRePass";
            this.tbRePass.Size = new System.Drawing.Size(283, 28);
            this.tbRePass.TabIndex = 20;
            this.tbRePass.TextChanged += new System.EventHandler(this.RePasswordTextbox);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Tai Le", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label9.Location = new System.Drawing.Point(1003, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(19, 19);
            this.label9.TabIndex = 21;
            this.label9.Text = "X";
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.Location = new System.Drawing.Point(565, 390);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(241, 47);
            this.btnSubmit.TabIndex = 22;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Tai Le", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label10.Location = new System.Drawing.Point(12, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 19);
            this.label10.TabIndex = 23;
            this.label10.Text = "Back";
            this.label10.Click += new System.EventHandler(this.BackToRootForm);
            // 
            // cbbGender
            // 
            this.cbbGender.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cbbGender.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbbGender.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbGender.Items.AddRange(new object[] {
            "Male",
            "Female",
            "Other"});
            this.cbbGender.Location = new System.Drawing.Point(709, 243);
            this.cbbGender.Name = "cbbGender";
            this.cbbGender.Size = new System.Drawing.Size(218, 24);
            this.cbbGender.TabIndex = 24;
            this.cbbGender.TextChanged += new System.EventHandler(this.cbbGender_TextChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MinigameOlympia.Properties.Resources.Background;
            this.pictureBox1.Location = new System.Drawing.Point(-2, -4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(356, 453);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // lblAlertName
            // 
            this.lblAlertName.AutoSize = true;
            this.lblAlertName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlertName.ForeColor = System.Drawing.Color.Red;
            this.lblAlertName.Location = new System.Drawing.Point(387, 115);
            this.lblAlertName.Name = "lblAlertName";
            this.lblAlertName.Size = new System.Drawing.Size(13, 13);
            this.lblAlertName.TabIndex = 25;
            this.lblAlertName.Text = "a";
            // 
            // lblAlertUsername
            // 
            this.lblAlertUsername.AutoSize = true;
            this.lblAlertUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlertUsername.ForeColor = System.Drawing.Color.Red;
            this.lblAlertUsername.Location = new System.Drawing.Point(387, 193);
            this.lblAlertUsername.Name = "lblAlertUsername";
            this.lblAlertUsername.Size = new System.Drawing.Size(13, 13);
            this.lblAlertUsername.TabIndex = 26;
            this.lblAlertUsername.Text = "a";
            // 
            // lblAlertPassword
            // 
            this.lblAlertPassword.AutoSize = true;
            this.lblAlertPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlertPassword.ForeColor = System.Drawing.Color.Red;
            this.lblAlertPassword.Location = new System.Drawing.Point(387, 270);
            this.lblAlertPassword.Name = "lblAlertPassword";
            this.lblAlertPassword.Size = new System.Drawing.Size(13, 13);
            this.lblAlertPassword.TabIndex = 27;
            this.lblAlertPassword.Text = "a";
            // 
            // lblAlertRePass
            // 
            this.lblAlertRePass.AutoSize = true;
            this.lblAlertRePass.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlertRePass.ForeColor = System.Drawing.Color.Red;
            this.lblAlertRePass.Location = new System.Drawing.Point(387, 348);
            this.lblAlertRePass.Name = "lblAlertRePass";
            this.lblAlertRePass.Size = new System.Drawing.Size(13, 13);
            this.lblAlertRePass.TabIndex = 28;
            this.lblAlertRePass.Text = "a";
            // 
            // lblAlertEmail
            // 
            this.lblAlertEmail.AutoSize = true;
            this.lblAlertEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlertEmail.ForeColor = System.Drawing.Color.Red;
            this.lblAlertEmail.Location = new System.Drawing.Point(706, 115);
            this.lblAlertEmail.Name = "lblAlertEmail";
            this.lblAlertEmail.Size = new System.Drawing.Size(13, 13);
            this.lblAlertEmail.TabIndex = 29;
            this.lblAlertEmail.Text = "a";
            // 
            // lblAlertPhone
            // 
            this.lblAlertPhone.AutoSize = true;
            this.lblAlertPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlertPhone.ForeColor = System.Drawing.Color.Red;
            this.lblAlertPhone.Location = new System.Drawing.Point(706, 193);
            this.lblAlertPhone.Name = "lblAlertPhone";
            this.lblAlertPhone.Size = new System.Drawing.Size(13, 13);
            this.lblAlertPhone.TabIndex = 30;
            this.lblAlertPhone.Text = "a";
            // 
            // DangKy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 449);
            this.Controls.Add(this.lblAlertPhone);
            this.Controls.Add(this.lblAlertEmail);
            this.Controls.Add(this.lblAlertRePass);
            this.Controls.Add(this.lblAlertPassword);
            this.Controls.Add(this.lblAlertUsername);
            this.Controls.Add(this.lblAlertName);
            this.Controls.Add(this.cbbGender);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tbRePass);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbPhone);
            this.Controls.Add(this.tbEmail);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbUsername);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "DangKy";
            this.Text = "Đăng ký";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.TextBox tbPhone;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbRePass;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbbGender;
        private System.Windows.Forms.Label lblAlertName;
        private System.Windows.Forms.Label lblAlertUsername;
        private System.Windows.Forms.Label lblAlertPassword;
        private System.Windows.Forms.Label lblAlertRePass;
        private System.Windows.Forms.Label lblAlertEmail;
        private System.Windows.Forms.Label lblAlertPhone;
    }
}