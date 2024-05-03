namespace MinigameOlympia {
    partial class CreateAvatar {
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
            this.label10 = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ptbAvatar = new System.Windows.Forms.PictureBox();
            this.rdbDefault = new System.Windows.Forms.RadioButton();
            this.rdbSelect = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Tai Le", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label10.Location = new System.Drawing.Point(17, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 19);
            this.label10.TabIndex = 50;
            this.label10.Text = "Back";
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.Location = new System.Drawing.Point(443, 358);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(241, 47);
            this.btnSubmit.TabIndex = 49;
            this.btnSubmit.Text = "Xác nhận";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MinigameOlympia.Properties.Resources.BackgroundLogin;
            this.pictureBox1.Location = new System.Drawing.Point(0, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(309, 423);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 46;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(455, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 31);
            this.label1.TabIndex = 34;
            this.label1.Text = "Tạo ảnh đại diện";
            // 
            // ptbAvatar
            // 
            this.ptbAvatar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ptbAvatar.Image = global::MinigameOlympia.Properties.Resources.plus;
            this.ptbAvatar.Location = new System.Drawing.Point(475, 171);
            this.ptbAvatar.Name = "ptbAvatar";
            this.ptbAvatar.Size = new System.Drawing.Size(173, 162);
            this.ptbAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbAvatar.TabIndex = 51;
            this.ptbAvatar.TabStop = false;
            // 
            // rdbDefault
            // 
            this.rdbDefault.AutoSize = true;
            this.rdbDefault.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.rdbDefault.Location = new System.Drawing.Point(497, 86);
            this.rdbDefault.Name = "rdbDefault";
            this.rdbDefault.Size = new System.Drawing.Size(107, 28);
            this.rdbDefault.TabIndex = 52;
            this.rdbDefault.TabStop = true;
            this.rdbDefault.Text = "Mặc định";
            this.rdbDefault.UseVisualStyleBackColor = true;
            this.rdbDefault.Click += new System.EventHandler(this.rdbDefault_Click);
            // 
            // rdbSelect
            // 
            this.rdbSelect.AutoSize = true;
            this.rdbSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.rdbSelect.Location = new System.Drawing.Point(497, 120);
            this.rdbSelect.Name = "rdbSelect";
            this.rdbSelect.Size = new System.Drawing.Size(122, 28);
            this.rdbSelect.TabIndex = 52;
            this.rdbSelect.TabStop = true;
            this.rdbSelect.Text = "Tải ảnh lên";
            this.rdbSelect.UseVisualStyleBackColor = true;
            this.rdbSelect.Click += new System.EventHandler(this.rdbSelect_Click);
            // 
            // CreateAvatar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 417);
            this.Controls.Add(this.rdbSelect);
            this.Controls.Add(this.rdbDefault);
            this.Controls.Add(this.ptbAvatar);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Name = "CreateAvatar";
            this.Text = "TaoAvatar";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbAvatar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox ptbAvatar;
        private System.Windows.Forms.RadioButton rdbDefault;
        private System.Windows.Forms.RadioButton rdbSelect;
    }
}