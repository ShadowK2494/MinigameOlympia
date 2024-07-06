namespace MinigameOlympia {
    partial class QuestionRound1 {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuestionRound1));
            this.QuestionArea = new System.Windows.Forms.PictureBox();
            this.lblQuestion = new System.Windows.Forms.Label();
            this.Clock = new System.Windows.Forms.PictureBox();
            this.tbAnswer = new System.Windows.Forms.TextBox();
            this.btnAnswer = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.QuestionArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Clock)).BeginInit();
            this.SuspendLayout();
            // 
            // QuestionArea
            // 
            this.QuestionArea.BackColor = System.Drawing.Color.Transparent;
            this.QuestionArea.Location = new System.Drawing.Point(35, 87);
            this.QuestionArea.Name = "QuestionArea";
            this.QuestionArea.Size = new System.Drawing.Size(727, 99);
            this.QuestionArea.TabIndex = 0;
            this.QuestionArea.TabStop = false;
            this.QuestionArea.Paint += new System.Windows.Forms.PaintEventHandler(this.QuestionArea_Paint);
            // 
            // lblQuestion
            // 
            this.lblQuestion.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblQuestion.Location = new System.Drawing.Point(30, 257);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(568, 106);
            this.lblQuestion.TabIndex = 1;
            this.lblQuestion.Text = "label1";
            // 
            // Clock
            // 
            this.Clock.BackColor = System.Drawing.Color.Transparent;
            this.Clock.Location = new System.Drawing.Point(634, 260);
            this.Clock.Name = "Clock";
            this.Clock.Size = new System.Drawing.Size(99, 99);
            this.Clock.TabIndex = 2;
            this.Clock.TabStop = false;
            this.Clock.Paint += new System.Windows.Forms.PaintEventHandler(this.Clock_Paint);
            // 
            // tbAnswer
            // 
            this.tbAnswer.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.tbAnswer.Location = new System.Drawing.Point(27, 378);
            this.tbAnswer.Name = "tbAnswer";
            this.tbAnswer.Size = new System.Drawing.Size(571, 30);
            this.tbAnswer.TabIndex = 3;
            this.tbAnswer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnAnswer
            // 
            this.btnAnswer.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnAnswer.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnAnswer.ForeColor = System.Drawing.Color.Black;
            this.btnAnswer.Location = new System.Drawing.Point(634, 372);
            this.btnAnswer.Name = "btnAnswer";
            this.btnAnswer.Size = new System.Drawing.Size(108, 39);
            this.btnAnswer.TabIndex = 70;
            this.btnAnswer.Text = "Trả lời";
            this.btnAnswer.UseVisualStyleBackColor = false;
            this.btnAnswer.Visible = false;
            this.btnAnswer.Click += new System.EventHandler(this.btnAnswer_Click);
            // 
            // QuestionRound1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MinigameOlympia.Properties.Resources.Room;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnAnswer);
            this.Controls.Add(this.tbAnswer);
            this.Controls.Add(this.Clock);
            this.Controls.Add(this.lblQuestion);
            this.Controls.Add(this.QuestionArea);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "QuestionRound1";
            this.Load += new System.EventHandler(this.QuestionRound1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.QuestionArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Clock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox QuestionArea;
        private System.Windows.Forms.Label lblQuestion;
        private System.Windows.Forms.PictureBox Clock;
        private System.Windows.Forms.TextBox tbAnswer;
        private System.Windows.Forms.Button btnAnswer;
    }
}