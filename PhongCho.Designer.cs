namespace MinigameOlympia {
    partial class PhongCho {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PhongCho));
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblRoomCode = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ptbHome = new System.Windows.Forms.PictureBox();
            this.lblRoom = new System.Windows.Forms.Label();
            this.panelMain = new System.Windows.Forms.Panel();
            this.BtnStart = new System.Windows.Forms.Button();
            this.lblPlayer4 = new System.Windows.Forms.Label();
            this.lblPlayer3 = new System.Windows.Forms.Label();
            this.lblPlayer2 = new System.Windows.Forms.Label();
            this.lblPlayer1 = new System.Windows.Forms.Label();
            this.ptbPlayer2 = new System.Windows.Forms.PictureBox();
            this.ptbPlayer3 = new System.Windows.Forms.PictureBox();
            this.ptbPlayer4 = new System.Windows.Forms.PictureBox();
            this.ptbPlayer1 = new System.Windows.Forms.PictureBox();
            this.grbFriends = new System.Windows.Forms.GroupBox();
            this.pnFriend = new System.Windows.Forms.Panel();
            this.lblInfo = new System.Windows.Forms.Label();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbHome)).BeginInit();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbPlayer2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbPlayer3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbPlayer4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbPlayer1)).BeginInit();
            this.grbFriends.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.Transparent;
            this.panelHeader.Controls.Add(this.lblRoomCode);
            this.panelHeader.Controls.Add(this.label1);
            this.panelHeader.Controls.Add(this.ptbHome);
            this.panelHeader.Controls.Add(this.lblRoom);
            this.panelHeader.Location = new System.Drawing.Point(25, 28);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(595, 43);
            this.panelHeader.TabIndex = 0;
            // 
            // lblRoomCode
            // 
            this.lblRoomCode.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblRoomCode.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblRoomCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblRoomCode.Location = new System.Drawing.Point(504, 0);
            this.lblRoomCode.Name = "lblRoomCode";
            this.lblRoomCode.Size = new System.Drawing.Size(91, 43);
            this.lblRoomCode.TabIndex = 4;
            this.lblRoomCode.Text = "Code";
            this.lblRoomCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(397, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 43);
            this.label1.TabIndex = 3;
            this.label1.Text = "Mã phòng:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ptbHome
            // 
            this.ptbHome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ptbHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ptbHome.Dock = System.Windows.Forms.DockStyle.Left;
            this.ptbHome.ErrorImage = null;
            this.ptbHome.Image = global::MinigameOlympia.Properties.Resources.ButtonHome;
            this.ptbHome.Location = new System.Drawing.Point(0, 0);
            this.ptbHome.Name = "ptbHome";
            this.ptbHome.Size = new System.Drawing.Size(43, 43);
            this.ptbHome.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbHome.TabIndex = 2;
            this.ptbHome.TabStop = false;
            this.ptbHome.Click += new System.EventHandler(this.ptbHome_Click);
            // 
            // lblRoom
            // 
            this.lblRoom.Font = new System.Drawing.Font("Times New Roman", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblRoom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblRoom.Location = new System.Drawing.Point(0, 0);
            this.lblRoom.Name = "lblRoom";
            this.lblRoom.Size = new System.Drawing.Size(408, 43);
            this.lblRoom.TabIndex = 1;
            this.lblRoom.Text = "Phòng chờ";
            this.lblRoom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.Transparent;
            this.panelMain.Controls.Add(this.BtnStart);
            this.panelMain.Controls.Add(this.lblPlayer4);
            this.panelMain.Controls.Add(this.lblPlayer3);
            this.panelMain.Controls.Add(this.lblPlayer2);
            this.panelMain.Controls.Add(this.lblPlayer1);
            this.panelMain.Controls.Add(this.ptbPlayer2);
            this.panelMain.Controls.Add(this.ptbPlayer3);
            this.panelMain.Controls.Add(this.ptbPlayer4);
            this.panelMain.Controls.Add(this.ptbPlayer1);
            this.panelMain.Location = new System.Drawing.Point(25, 86);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(595, 325);
            this.panelMain.TabIndex = 1;
            // 
            // BtnStart
            // 
            this.BtnStart.BackColor = System.Drawing.Color.LightCyan;
            this.BtnStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnStart.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.BtnStart.Location = new System.Drawing.Point(216, 247);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(146, 46);
            this.BtnStart.TabIndex = 8;
            this.BtnStart.Text = "Bắt đầu";
            this.BtnStart.UseVisualStyleBackColor = false;
            this.BtnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // lblPlayer4
            // 
            this.lblPlayer4.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblPlayer4.ForeColor = System.Drawing.Color.White;
            this.lblPlayer4.Location = new System.Drawing.Point(452, 169);
            this.lblPlayer4.Name = "lblPlayer4";
            this.lblPlayer4.Size = new System.Drawing.Size(114, 23);
            this.lblPlayer4.TabIndex = 7;
            this.lblPlayer4.Tag = "4";
            this.lblPlayer4.Text = "Player 4";
            this.lblPlayer4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPlayer3
            // 
            this.lblPlayer3.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblPlayer3.ForeColor = System.Drawing.Color.White;
            this.lblPlayer3.Location = new System.Drawing.Point(312, 169);
            this.lblPlayer3.Name = "lblPlayer3";
            this.lblPlayer3.Size = new System.Drawing.Size(114, 23);
            this.lblPlayer3.TabIndex = 6;
            this.lblPlayer3.Tag = "3";
            this.lblPlayer3.Text = "Player 3";
            this.lblPlayer3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPlayer2
            // 
            this.lblPlayer2.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblPlayer2.ForeColor = System.Drawing.Color.White;
            this.lblPlayer2.Location = new System.Drawing.Point(172, 169);
            this.lblPlayer2.Name = "lblPlayer2";
            this.lblPlayer2.Size = new System.Drawing.Size(114, 23);
            this.lblPlayer2.TabIndex = 5;
            this.lblPlayer2.Tag = "2";
            this.lblPlayer2.Text = "Player 2";
            this.lblPlayer2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPlayer1
            // 
            this.lblPlayer1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblPlayer1.ForeColor = System.Drawing.Color.White;
            this.lblPlayer1.Location = new System.Drawing.Point(34, 169);
            this.lblPlayer1.Name = "lblPlayer1";
            this.lblPlayer1.Size = new System.Drawing.Size(114, 23);
            this.lblPlayer1.TabIndex = 4;
            this.lblPlayer1.Tag = "1";
            this.lblPlayer1.Text = "Player 1";
            this.lblPlayer1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ptbPlayer2
            // 
            this.ptbPlayer2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ptbPlayer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ptbPlayer2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ptbPlayer2.Image = global::MinigameOlympia.Properties.Resources.plus;
            this.ptbPlayer2.Location = new System.Drawing.Point(187, 69);
            this.ptbPlayer2.Name = "ptbPlayer2";
            this.ptbPlayer2.Size = new System.Drawing.Size(81, 81);
            this.ptbPlayer2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbPlayer2.TabIndex = 3;
            this.ptbPlayer2.TabStop = false;
            this.ptbPlayer2.Tag = "2";
            // 
            // ptbPlayer3
            // 
            this.ptbPlayer3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ptbPlayer3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ptbPlayer3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ptbPlayer3.Image = global::MinigameOlympia.Properties.Resources.plus;
            this.ptbPlayer3.Location = new System.Drawing.Point(327, 68);
            this.ptbPlayer3.Name = "ptbPlayer3";
            this.ptbPlayer3.Size = new System.Drawing.Size(81, 81);
            this.ptbPlayer3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbPlayer3.TabIndex = 2;
            this.ptbPlayer3.TabStop = false;
            this.ptbPlayer3.Tag = "3";
            // 
            // ptbPlayer4
            // 
            this.ptbPlayer4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ptbPlayer4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ptbPlayer4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ptbPlayer4.Image = global::MinigameOlympia.Properties.Resources.plus;
            this.ptbPlayer4.Location = new System.Drawing.Point(465, 68);
            this.ptbPlayer4.Name = "ptbPlayer4";
            this.ptbPlayer4.Size = new System.Drawing.Size(81, 81);
            this.ptbPlayer4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbPlayer4.TabIndex = 1;
            this.ptbPlayer4.TabStop = false;
            this.ptbPlayer4.Tag = "4";
            // 
            // ptbPlayer1
            // 
            this.ptbPlayer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ptbPlayer1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ptbPlayer1.Location = new System.Drawing.Point(49, 69);
            this.ptbPlayer1.Name = "ptbPlayer1";
            this.ptbPlayer1.Size = new System.Drawing.Size(81, 81);
            this.ptbPlayer1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbPlayer1.TabIndex = 0;
            this.ptbPlayer1.TabStop = false;
            this.ptbPlayer1.Tag = "1";
            // 
            // grbFriends
            // 
            this.grbFriends.BackColor = System.Drawing.Color.Transparent;
            this.grbFriends.Controls.Add(this.pnFriend);
            this.grbFriends.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.grbFriends.ForeColor = System.Drawing.Color.White;
            this.grbFriends.Location = new System.Drawing.Point(626, 53);
            this.grbFriends.Name = "grbFriends";
            this.grbFriends.Size = new System.Drawing.Size(238, 358);
            this.grbFriends.TabIndex = 2;
            this.grbFriends.TabStop = false;
            this.grbFriends.Text = "Bạn bè";
            // 
            // pnFriend
            // 
            this.pnFriend.AutoScroll = true;
            this.pnFriend.Location = new System.Drawing.Point(2, 33);
            this.pnFriend.Name = "pnFriend";
            this.pnFriend.Size = new System.Drawing.Size(233, 319);
            this.pnFriend.TabIndex = 1;
            // 
            // lblInfo
            // 
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblInfo.Location = new System.Drawing.Point(652, 13);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(190, 27);
            this.lblInfo.TabIndex = 3;
            this.lblInfo.Text = "Đang ghép phòng...";
            this.lblInfo.Visible = false;
            // 
            // Room
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LemonChiffon;
            this.BackgroundImage = global::MinigameOlympia.Properties.Resources.Room;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(890, 450);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.grbFriends);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Room";
            this.Text = "Phòng chờ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PhongCho_FormClosing);
            this.Load += new System.EventHandler(this.PhongCho_Load);
            this.panelHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ptbHome)).EndInit();
            this.panelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ptbPlayer2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbPlayer3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbPlayer4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbPlayer1)).EndInit();
            this.grbFriends.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Panel panelMain;
        public System.Windows.Forms.Label lblRoom;
        private System.Windows.Forms.PictureBox ptbPlayer1;
        private System.Windows.Forms.PictureBox ptbPlayer3;
        private System.Windows.Forms.PictureBox ptbPlayer4;
        private System.Windows.Forms.Label lblPlayer1;
        private System.Windows.Forms.Label lblPlayer4;
        private System.Windows.Forms.Label lblPlayer3;
        private System.Windows.Forms.Label lblPlayer2;
        private System.Windows.Forms.GroupBox grbFriends;
        private System.Windows.Forms.PictureBox ptbPlayer2;
        private System.Windows.Forms.PictureBox ptbHome;
        private System.Windows.Forms.Button BtnStart;
        public System.Windows.Forms.Label lblRoomCode;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnFriend;
        private System.Windows.Forms.Label lblInfo;
    }
}