namespace MinigameOlympia {
    partial class KetQua {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KetQua));
            this.label_name = new System.Windows.Forms.Label();
            this.label_score = new System.Windows.Forms.Label();
            this.pictureBox_avt = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblYourScore = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_avt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label_name
            // 
            this.label_name.AutoSize = true;
            this.label_name.BackColor = System.Drawing.Color.Transparent;
            this.label_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label_name.Location = new System.Drawing.Point(310, 248);
            this.label_name.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(209, 31);
            this.label_name.TabIndex = 2;
            this.label_name.Text = "Tên người thắng";
            this.label_name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_score
            // 
            this.label_score.AutoSize = true;
            this.label_score.BackColor = System.Drawing.Color.Transparent;
            this.label_score.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label_score.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label_score.Location = new System.Drawing.Point(352, 295);
            this.label_score.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_score.Name = "label_score";
            this.label_score.Size = new System.Drawing.Size(113, 31);
            this.label_score.TabIndex = 3;
            this.label_score.Text = "Điểm số";
            this.label_score.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox_avt
            // 
            this.pictureBox_avt.Location = new System.Drawing.Point(326, 84);
            this.pictureBox_avt.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox_avt.Name = "pictureBox_avt";
            this.pictureBox_avt.Size = new System.Drawing.Size(168, 161);
            this.pictureBox_avt.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_avt.TabIndex = 1;
            this.pictureBox_avt.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::MinigameOlympia.Properties.Resources.KetQua;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(832, 450);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lblYourScore
            // 
            this.lblYourScore.AutoSize = true;
            this.lblYourScore.BackColor = System.Drawing.Color.Transparent;
            this.lblYourScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.lblYourScore.Location = new System.Drawing.Point(296, 354);
            this.lblYourScore.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblYourScore.Name = "lblYourScore";
            this.lblYourScore.Size = new System.Drawing.Size(188, 31);
            this.lblYourScore.TabIndex = 4;
            this.lblYourScore.Text = "Điểm của bạn:";
            this.lblYourScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Result
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 450);
            this.Controls.Add(this.lblYourScore);
            this.Controls.Add(this.label_score);
            this.Controls.Add(this.label_name);
            this.Controls.Add(this.pictureBox_avt);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Result";
            this.Text = "Kết quả";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Result_FormClosing);
            this.Load += new System.EventHandler(this.Result_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_avt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox_avt;
        private System.Windows.Forms.Label label_name;
        private System.Windows.Forms.Label label_score;
        private System.Windows.Forms.Label lblYourScore;
    }
}