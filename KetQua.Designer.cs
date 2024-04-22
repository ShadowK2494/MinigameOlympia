namespace MinigameOlympia
{
    partial class KetQua
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
            this.label_name = new System.Windows.Forms.Label();
            this.label_score = new System.Windows.Forms.Label();
            this.pictureBox_avt = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_avt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label_name
            // 
            this.label_name.AutoSize = true;
            this.label_name.BackColor = System.Drawing.Color.Transparent;
            this.label_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label_name.Location = new System.Drawing.Point(413, 365);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(263, 39);
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
            this.label_score.Location = new System.Drawing.Point(470, 423);
            this.label_score.Name = "label_score";
            this.label_score.Size = new System.Drawing.Size(142, 39);
            this.label_score.TabIndex = 3;
            this.label_score.Text = "Điểm số";
            this.label_score.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox_avt
            // 
            this.pictureBox_avt.Location = new System.Drawing.Point(434, 164);
            this.pictureBox_avt.Name = "pictureBox_avt";
            this.pictureBox_avt.Size = new System.Drawing.Size(224, 198);
            this.pictureBox_avt.TabIndex = 1;
            this.pictureBox_avt.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::MinigameOlympia.Properties.Resources.KetQua;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1109, 554);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // KetQua
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1109, 554);
            this.Controls.Add(this.label_score);
            this.Controls.Add(this.label_name);
            this.Controls.Add(this.pictureBox_avt);
            this.Controls.Add(this.pictureBox1);
            this.Name = "KetQua";
            this.Text = "KetQua";
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
    }
}