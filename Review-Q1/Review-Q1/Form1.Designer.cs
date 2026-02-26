namespace Review_Q1
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblComputer;
        private System.Windows.Forms.Label lblPlayer;
        private System.Windows.Forms.PictureBox picComputer;
        private System.Windows.Forms.PictureBox picPlayer;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Button btnRock;
        private System.Windows.Forms.Button btnPaper;
        private System.Windows.Forms.Button btnScissors;
        private System.Windows.Forms.Button btnEnd;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            this.ClientSize = new System.Drawing.Size(420, 380);
            this.Text = "猜拳遊戲";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            // Labels
            this.lblComputer = new System.Windows.Forms.Label();
            this.lblComputer.AutoSize = true;
            this.lblComputer.Font = new System.Drawing.Font("微軟正黑體", 14F);
            this.lblComputer.Location = new System.Drawing.Point(50, 20);
            this.lblComputer.Name = "lblComputer";
            this.lblComputer.Size = new System.Drawing.Size(70, 24);
            this.lblComputer.Text = "電腦出";

            this.lblPlayer = new System.Windows.Forms.Label();
            this.lblPlayer.AutoSize = true;
            this.lblPlayer.Font = new System.Drawing.Font("微軟正黑體", 14F);
            this.lblPlayer.Location = new System.Drawing.Point(260, 20);
            this.lblPlayer.Name = "lblPlayer";
            this.lblPlayer.Size = new System.Drawing.Size(70, 24);
            this.lblPlayer.Text = "玩家出";

            // PictureBoxes
            this.picComputer = new System.Windows.Forms.PictureBox();
            this.picComputer.BackColor = System.Drawing.Color.Peru;
            this.picComputer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picComputer.Location = new System.Drawing.Point(30, 55);
            this.picComputer.Name = "picComputer";
            this.picComputer.Size = new System.Drawing.Size(160, 120);
            this.picComputer.Paint += new System.Windows.Forms.PaintEventHandler(this.picComputer_Paint);

            this.picPlayer = new System.Windows.Forms.PictureBox();
            this.picPlayer.BackColor = System.Drawing.Color.Peru;
            this.picPlayer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picPlayer.Location = new System.Drawing.Point(240, 55);
            this.picPlayer.Name = "picPlayer";
            this.picPlayer.Size = new System.Drawing.Size(160, 120);
            this.picPlayer.Paint += new System.Windows.Forms.PaintEventHandler(this.picPlayer_Paint);

            // Result textbox
            this.txtResult = new System.Windows.Forms.TextBox();
            this.txtResult.Location = new System.Drawing.Point(50, 190);
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(300, 25);
            this.txtResult.ReadOnly = true;
            this.txtResult.Font = new System.Drawing.Font("微軟正黑體", 10F);

            // Buttons for moves
            this.btnRock = new System.Windows.Forms.Button();
            this.btnRock.Location = new System.Drawing.Point(40, 230);
            this.btnRock.Name = "btnRock";
            this.btnRock.Size = new System.Drawing.Size(80, 40);
            this.btnRock.Text = "石頭";
            this.btnRock.Click += new System.EventHandler(this.btnRock_Click);

            this.btnPaper = new System.Windows.Forms.Button();
            this.btnPaper.Location = new System.Drawing.Point(160, 230);
            this.btnPaper.Name = "btnPaper";
            this.btnPaper.Size = new System.Drawing.Size(80, 40);
            this.btnPaper.Text = "布";
            this.btnPaper.Click += new System.EventHandler(this.btnPaper_Click);

            this.btnScissors = new System.Windows.Forms.Button();
            this.btnScissors.Location = new System.Drawing.Point(280, 230);
            this.btnScissors.Name = "btnScissors";
            this.btnScissors.Size = new System.Drawing.Size(80, 40);
            this.btnScissors.Text = "剪刀";
            this.btnScissors.Click += new System.EventHandler(this.btnScissors_Click);

            // End button
            this.btnEnd = new System.Windows.Forms.Button();
            this.btnEnd.Location = new System.Drawing.Point(150, 290);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(120, 40);
            this.btnEnd.Text = "結束遊戲";
            this.btnEnd.Click += new System.EventHandler(this.btnEnd_Click);

            // Add controls
            this.Controls.Add(this.lblComputer);
            this.Controls.Add(this.lblPlayer);
            this.Controls.Add(this.picComputer);
            this.Controls.Add(this.picPlayer);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.btnRock);
            this.Controls.Add(this.btnPaper);
            this.Controls.Add(this.btnScissors);
            this.Controls.Add(this.btnEnd);
        }

        #endregion
    }
}

