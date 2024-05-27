namespace MinigameOlympia {
    partial class GiaoDienChinh {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GiaoDienChinh));
            this.grbRank = new System.Windows.Forms.GroupBox();
            this.lvRank = new System.Windows.Forms.ListView();
            this.btnEnter = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ptbAvatar = new System.Windows.Forms.PictureBox();
            this.lvFriends = new System.Windows.Forms.ListView();
            this.grbRank.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // grbRank
            // 
            this.grbRank.BackColor = System.Drawing.Color.Transparent;
            this.grbRank.Controls.Add(this.lvRank);
            this.grbRank.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.grbRank.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.grbRank.Location = new System.Drawing.Point(613, 21);
            this.grbRank.Margin = new System.Windows.Forms.Padding(2);
            this.grbRank.Name = "grbRank";
            this.grbRank.Padding = new System.Windows.Forms.Padding(2);
            this.grbRank.Size = new System.Drawing.Size(243, 382);
            this.grbRank.TabIndex = 4;
            this.grbRank.TabStop = false;
            this.grbRank.Text = "BẢNG XẾP HẠNG";
            // 
            // lvRank
            // 
            this.lvRank.BackColor = System.Drawing.Color.LightBlue;
            this.lvRank.HideSelection = false;
            this.lvRank.Location = new System.Drawing.Point(16, 55);
            this.lvRank.Margin = new System.Windows.Forms.Padding(2);
            this.lvRank.Name = "lvRank";
            this.lvRank.Size = new System.Drawing.Size(213, 307);
            this.lvRank.TabIndex = 0;
            this.lvRank.UseCompatibleStateImageBehavior = false;
            // 
            // btnEnter
            // 
            this.btnEnter.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnEnter.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold);
            this.btnEnter.Location = new System.Drawing.Point(300, 250);
            this.btnEnter.Margin = new System.Windows.Forms.Padding(2);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(184, 66);
            this.btnEnter.TabIndex = 0;
            this.btnEnter.Text = "Vào phòng";
            this.btnEnter.UseVisualStyleBackColor = false;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(112, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(496, 39);
            this.label1.TabIndex = 5;
            this.label1.Text = "ĐƯỜNG LÊN ĐỈNH OLYMPIA";
            // 
            // ptbAvatar
            // 
            this.ptbAvatar.Location = new System.Drawing.Point(10, 8);
            this.ptbAvatar.Name = "ptbAvatar";
            this.ptbAvatar.Size = new System.Drawing.Size(93, 81);
            this.ptbAvatar.TabIndex = 6;
            this.ptbAvatar.TabStop = false;
            this.ptbAvatar.Click += new System.EventHandler(this.ptbAvatar_Click);
            // 
            // lvFriends
            // 
            this.lvFriends.BackColor = System.Drawing.Color.DodgerBlue;
            this.lvFriends.HideSelection = false;
            this.lvFriends.Location = new System.Drawing.Point(10, 118);
            this.lvFriends.Name = "lvFriends";
            this.lvFriends.Size = new System.Drawing.Size(93, 284);
            this.lvFriends.TabIndex = 7;
            this.lvFriends.UseCompatibleStateImageBehavior = false;
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::MinigameOlympia.Properties.Resources.Room;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(867, 414);
            this.Controls.Add(this.lvFriends);
            this.Controls.Add(this.ptbAvatar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEnter);
            this.Controls.Add(this.grbRank);
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainScreen";
            this.Text = "GiaoDienChinh";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainScreenClosing);
            this.grbRank.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ptbAvatar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox grbRank;
        private System.Windows.Forms.ListView lvRank;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox ptbAvatar;
        private System.Windows.Forms.ListView lvFriends;
    }
}