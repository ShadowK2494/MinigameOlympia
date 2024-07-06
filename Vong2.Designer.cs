namespace MinigameOlympia {
    partial class Vong2 {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Vong2));
            this.gbQuestion = new System.Windows.Forms.GroupBox();
            this.vvwQuestion = new LibVLCSharp.WinForms.VideoView();
            this.ptbQuestion = new System.Windows.Forms.PictureBox();
            this.pnInfo = new System.Windows.Forms.Panel();
            this.lblPointPlayer1 = new System.Windows.Forms.Label();
            this.ptbPlayer1 = new System.Windows.Forms.PictureBox();
            this.lblPointPlayer4 = new System.Windows.Forms.Label();
            this.lblPlayer4 = new System.Windows.Forms.Label();
            this.ptbPlayer4 = new System.Windows.Forms.PictureBox();
            this.lblPointPlayer3 = new System.Windows.Forms.Label();
            this.lblPlayer3 = new System.Windows.Forms.Label();
            this.ptbPlayer3 = new System.Windows.Forms.PictureBox();
            this.lblPlayer1 = new System.Windows.Forms.Label();
            this.lblPointPlayer2 = new System.Windows.Forms.Label();
            this.lblPlayer2 = new System.Windows.Forms.Label();
            this.ptbPlayer2 = new System.Windows.Forms.PictureBox();
            this.btnAnswer = new System.Windows.Forms.Button();
            this.tbAnswer = new System.Windows.Forms.TextBox();
            this.Guide = new System.Windows.Forms.PictureBox();
            this.gbQuestion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vvwQuestion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbQuestion)).BeginInit();
            this.pnInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbPlayer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbPlayer4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbPlayer3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbPlayer2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Guide)).BeginInit();
            this.SuspendLayout();
            // 
            // gbQuestion
            // 
            this.gbQuestion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gbQuestion.Controls.Add(this.vvwQuestion);
            this.gbQuestion.Controls.Add(this.ptbQuestion);
            this.gbQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.gbQuestion.Location = new System.Drawing.Point(335, 12);
            this.gbQuestion.Margin = new System.Windows.Forms.Padding(2);
            this.gbQuestion.Name = "gbQuestion";
            this.gbQuestion.Padding = new System.Windows.Forms.Padding(2);
            this.gbQuestion.Size = new System.Drawing.Size(600, 434);
            this.gbQuestion.TabIndex = 35;
            this.gbQuestion.TabStop = false;
            this.gbQuestion.Text = "Câu hỏi";
            // 
            // vvwQuestion
            // 
            this.vvwQuestion.BackColor = System.Drawing.Color.Black;
            this.vvwQuestion.Location = new System.Drawing.Point(5, 28);
            this.vvwQuestion.MediaPlayer = null;
            this.vvwQuestion.Name = "vvwQuestion";
            this.vvwQuestion.Size = new System.Drawing.Size(590, 401);
            this.vvwQuestion.TabIndex = 1;
            this.vvwQuestion.Text = "videoView1";
            // 
            // ptbQuestion
            // 
            this.ptbQuestion.Location = new System.Drawing.Point(47, 55);
            this.ptbQuestion.Name = "ptbQuestion";
            this.ptbQuestion.Size = new System.Drawing.Size(512, 332);
            this.ptbQuestion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbQuestion.TabIndex = 0;
            this.ptbQuestion.TabStop = false;
            this.ptbQuestion.Visible = false;
            // 
            // pnInfo
            // 
            this.pnInfo.BackColor = System.Drawing.Color.Transparent;
            this.pnInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnInfo.Controls.Add(this.lblPointPlayer1);
            this.pnInfo.Controls.Add(this.ptbPlayer1);
            this.pnInfo.Controls.Add(this.lblPointPlayer4);
            this.pnInfo.Controls.Add(this.lblPlayer4);
            this.pnInfo.Controls.Add(this.ptbPlayer4);
            this.pnInfo.Controls.Add(this.lblPointPlayer3);
            this.pnInfo.Controls.Add(this.lblPlayer3);
            this.pnInfo.Controls.Add(this.ptbPlayer3);
            this.pnInfo.Controls.Add(this.lblPlayer1);
            this.pnInfo.Controls.Add(this.lblPointPlayer2);
            this.pnInfo.Controls.Add(this.lblPlayer2);
            this.pnInfo.Controls.Add(this.ptbPlayer2);
            this.pnInfo.Location = new System.Drawing.Point(28, 12);
            this.pnInfo.Name = "pnInfo";
            this.pnInfo.Size = new System.Drawing.Size(239, 434);
            this.pnInfo.TabIndex = 55;
            // 
            // lblPointPlayer1
            // 
            this.lblPointPlayer1.BackColor = System.Drawing.Color.Transparent;
            this.lblPointPlayer1.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblPointPlayer1.ForeColor = System.Drawing.Color.White;
            this.lblPointPlayer1.Location = new System.Drawing.Point(109, 53);
            this.lblPointPlayer1.Name = "lblPointPlayer1";
            this.lblPointPlayer1.Size = new System.Drawing.Size(114, 32);
            this.lblPointPlayer1.TabIndex = 53;
            this.lblPointPlayer1.Tag = "info1";
            this.lblPointPlayer1.Text = "0";
            this.lblPointPlayer1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ptbPlayer1
            // 
            this.ptbPlayer1.BackColor = System.Drawing.Color.Transparent;
            this.ptbPlayer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ptbPlayer1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ptbPlayer1.Location = new System.Drawing.Point(23, 14);
            this.ptbPlayer1.Name = "ptbPlayer1";
            this.ptbPlayer1.Size = new System.Drawing.Size(81, 81);
            this.ptbPlayer1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbPlayer1.TabIndex = 51;
            this.ptbPlayer1.TabStop = false;
            this.ptbPlayer1.Tag = "info1";
            // 
            // lblPointPlayer4
            // 
            this.lblPointPlayer4.BackColor = System.Drawing.Color.Transparent;
            this.lblPointPlayer4.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblPointPlayer4.ForeColor = System.Drawing.Color.White;
            this.lblPointPlayer4.Location = new System.Drawing.Point(113, 373);
            this.lblPointPlayer4.Name = "lblPointPlayer4";
            this.lblPointPlayer4.Size = new System.Drawing.Size(110, 32);
            this.lblPointPlayer4.TabIndex = 61;
            this.lblPointPlayer4.Tag = "info4";
            this.lblPointPlayer4.Text = "0";
            this.lblPointPlayer4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPlayer4
            // 
            this.lblPlayer4.BackColor = System.Drawing.Color.Transparent;
            this.lblPlayer4.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblPlayer4.ForeColor = System.Drawing.Color.White;
            this.lblPlayer4.Location = new System.Drawing.Point(111, 348);
            this.lblPlayer4.Name = "lblPlayer4";
            this.lblPlayer4.Size = new System.Drawing.Size(112, 23);
            this.lblPlayer4.TabIndex = 60;
            this.lblPlayer4.Tag = "info4";
            this.lblPlayer4.Text = "Player 4";
            this.lblPlayer4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ptbPlayer4
            // 
            this.ptbPlayer4.BackColor = System.Drawing.Color.Transparent;
            this.ptbPlayer4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ptbPlayer4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ptbPlayer4.Location = new System.Drawing.Point(23, 335);
            this.ptbPlayer4.Name = "ptbPlayer4";
            this.ptbPlayer4.Size = new System.Drawing.Size(81, 81);
            this.ptbPlayer4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbPlayer4.TabIndex = 59;
            this.ptbPlayer4.TabStop = false;
            this.ptbPlayer4.Tag = "info4";
            // 
            // lblPointPlayer3
            // 
            this.lblPointPlayer3.BackColor = System.Drawing.Color.Transparent;
            this.lblPointPlayer3.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblPointPlayer3.ForeColor = System.Drawing.Color.White;
            this.lblPointPlayer3.Location = new System.Drawing.Point(113, 271);
            this.lblPointPlayer3.Name = "lblPointPlayer3";
            this.lblPointPlayer3.Size = new System.Drawing.Size(114, 32);
            this.lblPointPlayer3.TabIndex = 58;
            this.lblPointPlayer3.Tag = "info3";
            this.lblPointPlayer3.Text = "0";
            this.lblPointPlayer3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPlayer3
            // 
            this.lblPlayer3.BackColor = System.Drawing.Color.Transparent;
            this.lblPlayer3.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblPlayer3.ForeColor = System.Drawing.Color.White;
            this.lblPlayer3.Location = new System.Drawing.Point(111, 242);
            this.lblPlayer3.Name = "lblPlayer3";
            this.lblPlayer3.Size = new System.Drawing.Size(112, 23);
            this.lblPlayer3.TabIndex = 57;
            this.lblPlayer3.Tag = "info3";
            this.lblPlayer3.Text = "Player 3";
            this.lblPlayer3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ptbPlayer3
            // 
            this.ptbPlayer3.BackColor = System.Drawing.Color.Transparent;
            this.ptbPlayer3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ptbPlayer3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ptbPlayer3.Location = new System.Drawing.Point(23, 231);
            this.ptbPlayer3.Name = "ptbPlayer3";
            this.ptbPlayer3.Size = new System.Drawing.Size(81, 81);
            this.ptbPlayer3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbPlayer3.TabIndex = 56;
            this.ptbPlayer3.TabStop = false;
            this.ptbPlayer3.Tag = "info3";
            // 
            // lblPlayer1
            // 
            this.lblPlayer1.BackColor = System.Drawing.Color.Transparent;
            this.lblPlayer1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblPlayer1.ForeColor = System.Drawing.Color.White;
            this.lblPlayer1.Location = new System.Drawing.Point(111, 25);
            this.lblPlayer1.Name = "lblPlayer1";
            this.lblPlayer1.Size = new System.Drawing.Size(114, 23);
            this.lblPlayer1.TabIndex = 52;
            this.lblPlayer1.Tag = "info1";
            this.lblPlayer1.Text = "Player 1";
            this.lblPlayer1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPointPlayer2
            // 
            this.lblPointPlayer2.BackColor = System.Drawing.Color.Transparent;
            this.lblPointPlayer2.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblPointPlayer2.ForeColor = System.Drawing.Color.White;
            this.lblPointPlayer2.Location = new System.Drawing.Point(109, 159);
            this.lblPointPlayer2.Name = "lblPointPlayer2";
            this.lblPointPlayer2.Size = new System.Drawing.Size(114, 32);
            this.lblPointPlayer2.TabIndex = 55;
            this.lblPointPlayer2.Tag = "info2";
            this.lblPointPlayer2.Text = "0";
            this.lblPointPlayer2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPlayer2
            // 
            this.lblPlayer2.BackColor = System.Drawing.Color.Transparent;
            this.lblPlayer2.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblPlayer2.ForeColor = System.Drawing.Color.White;
            this.lblPlayer2.Location = new System.Drawing.Point(109, 130);
            this.lblPlayer2.Name = "lblPlayer2";
            this.lblPlayer2.Size = new System.Drawing.Size(114, 23);
            this.lblPlayer2.TabIndex = 55;
            this.lblPlayer2.Tag = "info2";
            this.lblPlayer2.Text = "Player 2";
            this.lblPlayer2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ptbPlayer2
            // 
            this.ptbPlayer2.BackColor = System.Drawing.Color.Transparent;
            this.ptbPlayer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ptbPlayer2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ptbPlayer2.Location = new System.Drawing.Point(23, 120);
            this.ptbPlayer2.Name = "ptbPlayer2";
            this.ptbPlayer2.Size = new System.Drawing.Size(81, 81);
            this.ptbPlayer2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbPlayer2.TabIndex = 55;
            this.ptbPlayer2.TabStop = false;
            this.ptbPlayer2.Tag = "info2";
            // 
            // btnAnswer
            // 
            this.btnAnswer.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnAnswer.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnAnswer.ForeColor = System.Drawing.Color.Black;
            this.btnAnswer.Location = new System.Drawing.Point(827, 462);
            this.btnAnswer.Name = "btnAnswer";
            this.btnAnswer.Size = new System.Drawing.Size(108, 39);
            this.btnAnswer.TabIndex = 72;
            this.btnAnswer.Text = "Trả lời";
            this.btnAnswer.UseVisualStyleBackColor = false;
            this.btnAnswer.Visible = false;
            this.btnAnswer.Click += new System.EventHandler(this.btnAnswer_Click);
            // 
            // tbAnswer
            // 
            this.tbAnswer.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.tbAnswer.Location = new System.Drawing.Point(82, 466);
            this.tbAnswer.MaxLength = 20;
            this.tbAnswer.Name = "tbAnswer";
            this.tbAnswer.Size = new System.Drawing.Size(726, 30);
            this.tbAnswer.TabIndex = 71;
            this.tbAnswer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Guide
            // 
            this.Guide.BackColor = System.Drawing.Color.Transparent;
            this.Guide.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Guide.Image = global::MinigameOlympia.Properties.Resources.QuestionMark;
            this.Guide.Location = new System.Drawing.Point(24, 462);
            this.Guide.Name = "Guide";
            this.Guide.Size = new System.Drawing.Size(39, 39);
            this.Guide.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Guide.TabIndex = 73;
            this.Guide.TabStop = false;
            this.Guide.Click += new System.EventHandler(this.Guide_Click);
            // 
            // Round2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MinigameOlympia.Properties.Resources.Room;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(951, 522);
            this.Controls.Add(this.Guide);
            this.Controls.Add(this.btnAnswer);
            this.Controls.Add(this.tbAnswer);
            this.Controls.Add(this.gbQuestion);
            this.Controls.Add(this.pnInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Round2";
            this.Text = "Vòng thi Tăng tốc";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Round2_FormClosing);
            this.Load += new System.EventHandler(this.Round2_Load);
            this.gbQuestion.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.vvwQuestion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbQuestion)).EndInit();
            this.pnInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ptbPlayer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbPlayer4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbPlayer3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbPlayer2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Guide)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox gbQuestion;
        private System.Windows.Forms.Panel pnInfo;
        private System.Windows.Forms.Label lblPointPlayer1;
        private System.Windows.Forms.PictureBox ptbPlayer1;
        private System.Windows.Forms.Label lblPointPlayer4;
        private System.Windows.Forms.Label lblPlayer4;
        private System.Windows.Forms.PictureBox ptbPlayer4;
        private System.Windows.Forms.Label lblPointPlayer3;
        private System.Windows.Forms.Label lblPlayer3;
        private System.Windows.Forms.PictureBox ptbPlayer3;
        private System.Windows.Forms.Label lblPlayer1;
        private System.Windows.Forms.Label lblPointPlayer2;
        private System.Windows.Forms.Label lblPlayer2;
        private System.Windows.Forms.PictureBox ptbPlayer2;
        private System.Windows.Forms.PictureBox ptbQuestion;
        private System.Windows.Forms.Button btnAnswer;
        private System.Windows.Forms.TextBox tbAnswer;
        private LibVLCSharp.WinForms.VideoView vvwQuestion;
        private System.Windows.Forms.PictureBox Guide;
    }
}