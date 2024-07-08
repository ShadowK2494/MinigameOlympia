namespace MinigameOlympia {
    partial class InfoRound {
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
            this.lblInfoRound = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblInfoRound
            // 
            this.lblInfoRound.BackColor = System.Drawing.Color.Transparent;
            this.lblInfoRound.Font = new System.Drawing.Font("Times New Roman", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblInfoRound.ForeColor = System.Drawing.Color.Yellow;
            this.lblInfoRound.Location = new System.Drawing.Point(101, 174);
            this.lblInfoRound.Name = "lblInfoRound";
            this.lblInfoRound.Size = new System.Drawing.Size(591, 98);
            this.lblInfoRound.TabIndex = 63;
            this.lblInfoRound.Tag = "";
            this.lblInfoRound.Text = "Tên vòng thi";
            this.lblInfoRound.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // InfoRound
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MinigameOlympia.Properties.Resources.Room;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblInfoRound);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "InfoRound";
            this.Text = "InfoRound";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InfoRound_FormClosing);
            this.Load += new System.EventHandler(this.InfoRound_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblInfoRound;
    }
}