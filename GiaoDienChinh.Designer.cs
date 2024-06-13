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
            this.pnRank = new System.Windows.Forms.Panel();
            this.btnEnter = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ptbAvatar = new System.Windows.Forms.PictureBox();
            this.pnFriendList = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnCreateRoom = new System.Windows.Forms.Button();
            this.grbRank.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // grbRank
            // 
            this.grbRank.BackColor = System.Drawing.Color.Transparent;
            this.grbRank.Controls.Add(this.pnRank);
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
            // pnRank
            // 
            this.pnRank.AutoScroll = true;
            this.pnRank.Location = new System.Drawing.Point(5, 43);
            this.pnRank.Name = "pnRank";
            this.pnRank.Size = new System.Drawing.Size(233, 319);
            this.pnRank.TabIndex = 0;
            // 
            // btnEnter
            // 
            this.btnEnter.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnEnter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEnter.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold);
            this.btnEnter.Location = new System.Drawing.Point(263, 208);
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
            this.label1.Location = new System.Drawing.Point(112, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(496, 39);
            this.label1.TabIndex = 5;
            this.label1.Text = "ĐƯỜNG LÊN ĐỈNH OLYMPIA";
            // 
            // ptbAvatar
            // 
            this.ptbAvatar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ptbAvatar.Location = new System.Drawing.Point(10, 8);
            this.ptbAvatar.Name = "ptbAvatar";
            this.ptbAvatar.Size = new System.Drawing.Size(81, 81);
            this.ptbAvatar.TabIndex = 6;
            this.ptbAvatar.TabStop = false;
            this.ptbAvatar.Click += new System.EventHandler(this.ptbAvatar_Click);
            // 
            // pnFriendList
            // 
            this.pnFriendList.AutoScroll = true;
            this.pnFriendList.BackColor = System.Drawing.Color.DodgerBlue;
            this.pnFriendList.Location = new System.Drawing.Point(12, 118);
            this.pnFriendList.Name = "pnFriendList";
            this.pnFriendList.Size = new System.Drawing.Size(81, 265);
            this.pnFriendList.TabIndex = 7;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold);
            this.btnExit.Location = new System.Drawing.Point(263, 298);
            this.btnExit.Margin = new System.Windows.Forms.Padding(2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(184, 66);
            this.btnExit.TabIndex = 8;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnCreateRoom
            // 
            this.btnCreateRoom.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnCreateRoom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCreateRoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold);
            this.btnCreateRoom.Location = new System.Drawing.Point(263, 118);
            this.btnCreateRoom.Margin = new System.Windows.Forms.Padding(2);
            this.btnCreateRoom.Name = "btnCreateRoom";
            this.btnCreateRoom.Size = new System.Drawing.Size(184, 66);
            this.btnCreateRoom.TabIndex = 9;
            this.btnCreateRoom.Text = "Tạo phòng";
            this.btnCreateRoom.UseVisualStyleBackColor = false;
            this.btnCreateRoom.Click += new System.EventHandler(this.btnCreateRoom_Click);
            // 
            // GiaoDienChinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::MinigameOlympia.Properties.Resources.Room;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(867, 414);
            this.Controls.Add(this.btnCreateRoom);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.pnFriendList);
            this.Controls.Add(this.ptbAvatar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEnter);
            this.Controls.Add(this.grbRank);
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "GiaoDienChinh";
            this.Text = "Giao diện chính";
            this.Load += new System.EventHandler(this.GiaoDienChinh_Load);
            this.grbRank.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ptbAvatar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox grbRank;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox ptbAvatar;
        private System.Windows.Forms.Panel pnFriendList;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnCreateRoom;
        private System.Windows.Forms.Panel pnRank;
    }
}