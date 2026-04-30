namespace Color_Spectrum
{
    partial class Form1
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
            this.promptLabel = new System.Windows.Forms.Label();
            this.colorLabel = new System.Windows.Forms.Label();
            this.redLabel = new System.Windows.Forms.Label();
            this.orangeLabel = new System.Windows.Forms.Label();
            this.yellowLabel = new System.Windows.Forms.Label();
            this.greenLabel = new System.Windows.Forms.Label();
            this.blueLabel = new System.Windows.Forms.Label();
            this.indigoLabel = new System.Windows.Forms.Label();
            this.violetLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // promptLabel
            // 
            this.promptLabel.AutoSize = true;
            this.promptLabel.Location = new System.Drawing.Point(147, 9);
            this.promptLabel.Name = "promptLabel";
            this.promptLabel.Size = new System.Drawing.Size(151, 13);
            this.promptLabel.TabIndex = 7;
            this.promptLabel.Text = "Select a Color of the Spectrum";
            // 
            // colorLabel
            // 
            this.colorLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.colorLabel.Location = new System.Drawing.Point(172, 72);
            this.colorLabel.Name = "colorLabel";
            this.colorLabel.Size = new System.Drawing.Size(100, 23);
            this.colorLabel.TabIndex = 8;
            this.colorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // redLabel
            // 
            this.redLabel.BackColor = System.Drawing.Color.Red;
            this.redLabel.Location = new System.Drawing.Point(8, 33);
            this.redLabel.Name = "redLabel";
            this.redLabel.Size = new System.Drawing.Size(56, 23);
            this.redLabel.TabIndex = 9;
            this.redLabel.Click += new System.EventHandler(this.redLabel_Click);
            // 
            // orangeLabel
            // 
            this.orangeLabel.BackColor = System.Drawing.Color.Orange;
            this.orangeLabel.Location = new System.Drawing.Point(70, 33);
            this.orangeLabel.Name = "orangeLabel";
            this.orangeLabel.Size = new System.Drawing.Size(56, 23);
            this.orangeLabel.TabIndex = 10;
            this.orangeLabel.Click += new System.EventHandler(this.orangeLabel_Click);
            // 
            // yellowLabel
            // 
            this.yellowLabel.BackColor = System.Drawing.Color.Yellow;
            this.yellowLabel.Location = new System.Drawing.Point(132, 33);
            this.yellowLabel.Name = "yellowLabel";
            this.yellowLabel.Size = new System.Drawing.Size(56, 23);
            this.yellowLabel.TabIndex = 11;
            this.yellowLabel.Click += new System.EventHandler(this.yellowLabel_Click);
            // 
            // greenLabel
            // 
            this.greenLabel.BackColor = System.Drawing.Color.Green;
            this.greenLabel.Location = new System.Drawing.Point(194, 33);
            this.greenLabel.Name = "greenLabel";
            this.greenLabel.Size = new System.Drawing.Size(56, 23);
            this.greenLabel.TabIndex = 12;
            this.greenLabel.Click += new System.EventHandler(this.greenLabel_Click);
            // 
            // blueLabel
            // 
            this.blueLabel.BackColor = System.Drawing.Color.Blue;
            this.blueLabel.Location = new System.Drawing.Point(256, 33);
            this.blueLabel.Name = "blueLabel";
            this.blueLabel.Size = new System.Drawing.Size(56, 23);
            this.blueLabel.TabIndex = 13;
            this.blueLabel.Click += new System.EventHandler(this.blueLabel_Click);
            // 
            // indigoLabel
            // 
            this.indigoLabel.BackColor = System.Drawing.Color.Indigo;
            this.indigoLabel.Location = new System.Drawing.Point(318, 33);
            this.indigoLabel.Name = "indigoLabel";
            this.indigoLabel.Size = new System.Drawing.Size(56, 23);
            this.indigoLabel.TabIndex = 14;
            this.indigoLabel.Click += new System.EventHandler(this.indigoLabel_Click);
            // 
            // violetLabel
            // 
            this.violetLabel.BackColor = System.Drawing.Color.Violet;
            this.violetLabel.Location = new System.Drawing.Point(380, 33);
            this.violetLabel.Name = "violetLabel";
            this.violetLabel.Size = new System.Drawing.Size(56, 23);
            this.violetLabel.TabIndex = 15;
            this.violetLabel.Click += new System.EventHandler(this.violetLabel_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 112);
            this.Controls.Add(this.violetLabel);
            this.Controls.Add(this.indigoLabel);
            this.Controls.Add(this.blueLabel);
            this.Controls.Add(this.greenLabel);
            this.Controls.Add(this.yellowLabel);
            this.Controls.Add(this.orangeLabel);
            this.Controls.Add(this.redLabel);
            this.Controls.Add(this.colorLabel);
            this.Controls.Add(this.promptLabel);
            this.Name = "Form1";
            this.Text = "Color Spectrum";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label promptLabel;
        private System.Windows.Forms.Label colorLabel;
        private System.Windows.Forms.Label redLabel;
        private System.Windows.Forms.Label orangeLabel;
        private System.Windows.Forms.Label yellowLabel;
        private System.Windows.Forms.Label greenLabel;
        private System.Windows.Forms.Label blueLabel;
        private System.Windows.Forms.Label indigoLabel;
        private System.Windows.Forms.Label violetLabel;
    }
}

