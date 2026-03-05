    namespace WindowsFormsApp1
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        private void InitializeComponent()
        {
            this.groupBoxOilLube = new System.Windows.Forms.GroupBox();
            this.cbLubeJob = new System.Windows.Forms.CheckBox();
            this.cbOilChange = new System.Windows.Forms.CheckBox();
            this.groupBoxFlush = new System.Windows.Forms.GroupBox();
            this.cbTransmissionFlush = new System.Windows.Forms.CheckBox();
            this.cbRadiatorFlush = new System.Windows.Forms.CheckBox();
            this.groupBoxMisc = new System.Windows.Forms.GroupBox();
            this.cbTireRotation = new System.Windows.Forms.CheckBox();
            this.cbReplaceMuffler = new System.Windows.Forms.CheckBox();
            this.cbInspection = new System.Windows.Forms.CheckBox();
            this.groupBoxOther = new System.Windows.Forms.GroupBox();
            this.labelParts = new System.Windows.Forms.Label();
            this.labelLabor = new System.Windows.Forms.Label();
            this.txtParts = new System.Windows.Forms.TextBox();
            this.txtLabor = new System.Windows.Forms.TextBox();
            this.groupBoxFees = new System.Windows.Forms.GroupBox();
            this.labelTotal = new System.Windows.Forms.Label();
            this.labelTax = new System.Windows.Forms.Label();
            this.labelPartsCost = new System.Windows.Forms.Label();
            this.labelServiceLabor = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.txtTax = new System.Windows.Forms.TextBox();
            this.txtPartsCost = new System.Windows.Forms.TextBox();
            this.txtServiceLabor = new System.Windows.Forms.TextBox();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.groupBoxOilLube.SuspendLayout();
            this.groupBoxFlush.SuspendLayout();
            this.groupBoxMisc.SuspendLayout();
            this.groupBoxOther.SuspendLayout();
            this.groupBoxFees.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxOilLube
            // 
            this.groupBoxOilLube.Controls.Add(this.cbLubeJob);
            this.groupBoxOilLube.Controls.Add(this.cbOilChange);
            this.groupBoxOilLube.Location = new System.Drawing.Point(12, 12);
            this.groupBoxOilLube.Name = "groupBoxOilLube";
            this.groupBoxOilLube.Size = new System.Drawing.Size(220, 90);
            this.groupBoxOilLube.TabIndex = 0;
            this.groupBoxOilLube.TabStop = false;
            this.groupBoxOilLube.Text = "機油與潤滑";
            // 
            // cbLubeJob
            // 
            this.cbLubeJob.AutoSize = true;
            this.cbLubeJob.Location = new System.Drawing.Point(14, 54);
            this.cbLubeJob.Name = "cbLubeJob";
            this.cbLubeJob.Size = new System.Drawing.Size(136, 22);
            this.cbLubeJob.TabIndex = 1;
            this.cbLubeJob.Text = "潤滑保養 (NT$540)";
            this.cbLubeJob.UseVisualStyleBackColor = true;
            // 
            // cbOilChange
            // 
            this.cbOilChange.AutoSize = true;
            this.cbOilChange.Location = new System.Drawing.Point(14, 26);
            this.cbOilChange.Name = "cbOilChange";
            this.cbOilChange.Size = new System.Drawing.Size(156, 22);
            this.cbOilChange.TabIndex = 0;
            this.cbOilChange.Text = "更換機油 (NT$780)";
            this.cbOilChange.UseVisualStyleBackColor = true;
            // 
            // groupBoxFlush
            // 
            this.groupBoxFlush.Controls.Add(this.cbTransmissionFlush);
            this.groupBoxFlush.Controls.Add(this.cbRadiatorFlush);
            this.groupBoxFlush.Location = new System.Drawing.Point(246, 12);
            this.groupBoxFlush.Name = "groupBoxFlush";
            this.groupBoxFlush.Size = new System.Drawing.Size(220, 90);
            this.groupBoxFlush.TabIndex = 1;
            this.groupBoxFlush.TabStop = false;
            this.groupBoxFlush.Text = "清洗服務";
            // 
            // cbTransmissionFlush
            // 
            this.cbTransmissionFlush.AutoSize = true;
            this.cbTransmissionFlush.Location = new System.Drawing.Point(14, 54);
            this.cbTransmissionFlush.Name = "cbTransmissionFlush";
            this.cbTransmissionFlush.Size = new System.Drawing.Size(196, 22);
            this.cbTransmissionFlush.TabIndex = 1;
            this.cbTransmissionFlush.Text = "變速箱清洗 (NT$2,400)";
            this.cbTransmissionFlush.UseVisualStyleBackColor = true;
            // 
            // cbRadiatorFlush
            // 
            this.cbRadiatorFlush.AutoSize = true;
            this.cbRadiatorFlush.Location = new System.Drawing.Point(14, 26);
            this.cbRadiatorFlush.Name = "cbRadiatorFlush";
            this.cbRadiatorFlush.Size = new System.Drawing.Size(148, 22);
            this.cbRadiatorFlush.TabIndex = 0;
            this.cbRadiatorFlush.Text = "水箱清洗 (NT$900)";
            this.cbRadiatorFlush.UseVisualStyleBackColor = true;
            // 
            // groupBoxMisc
            // 
            this.groupBoxMisc.Controls.Add(this.cbTireRotation);
            this.groupBoxMisc.Controls.Add(this.cbReplaceMuffler);
            this.groupBoxMisc.Controls.Add(this.cbInspection);
            this.groupBoxMisc.Location = new System.Drawing.Point(12, 118);
            this.groupBoxMisc.Name = "groupBoxMisc";
            this.groupBoxMisc.Size = new System.Drawing.Size(454, 90);
            this.groupBoxMisc.TabIndex = 2;
            this.groupBoxMisc.TabStop = false;
            this.groupBoxMisc.Text = "其他服務";
            // 
            // cbTireRotation
            // 
            this.cbTireRotation.AutoSize = true;
            this.cbTireRotation.Location = new System.Drawing.Point(324, 26);
            this.cbTireRotation.Name = "cbTireRotation";
            this.cbTireRotation.Size = new System.Drawing.Size(136, 22);
            this.cbTireRotation.TabIndex = 2;
            this.cbTireRotation.Text = "輪胎換位 (NT$600)";
            this.cbTireRotation.UseVisualStyleBackColor = true;
            // 
            // cbReplaceMuffler
            // 
            this.cbReplaceMuffler.AutoSize = true;
            this.cbReplaceMuffler.Location = new System.Drawing.Point(164, 26);
            this.cbReplaceMuffler.Name = "cbReplaceMuffler";
            this.cbReplaceMuffler.Size = new System.Drawing.Size(180, 22);
            this.cbReplaceMuffler.TabIndex = 1;
            this.cbReplaceMuffler.Text = "更換消音器 (NT$3,000)";
            this.cbReplaceMuffler.UseVisualStyleBackColor = true;
            // 
            // cbInspection
            // 
            this.cbInspection.AutoSize = true;
            this.cbInspection.Location = new System.Drawing.Point(14, 26);
            this.cbInspection.Name = "cbInspection";
            this.cbInspection.Size = new System.Drawing.Size(120, 22);
            this.cbInspection.TabIndex = 0;
            this.cbInspection.Text = "檢驗 (NT$450)";
            this.cbInspection.UseVisualStyleBackColor = true;
            // 
            // groupBoxOther
            // 
            this.groupBoxOther.Controls.Add(this.labelParts);
            this.groupBoxOther.Controls.Add(this.labelLabor);
            this.groupBoxOther.Controls.Add(this.txtParts);
            this.groupBoxOther.Controls.Add(this.txtLabor);
            this.groupBoxOther.Location = new System.Drawing.Point(12, 222);
            this.groupBoxOther.Name = "groupBoxOther";
            this.groupBoxOther.Size = new System.Drawing.Size(454, 80);
            this.groupBoxOther.TabIndex = 3;
            this.groupBoxOther.TabStop = false;
            this.groupBoxOther.Text = "零件與工時";
            // 
            // labelParts
            // 
            this.labelParts.AutoSize = true;
            this.labelParts.Location = new System.Drawing.Point(18, 32);
            this.labelParts.Name = "labelParts";
            this.labelParts.Size = new System.Drawing.Size(66, 18);
            this.labelParts.TabIndex = 3;
            this.labelParts.Text = "零件 (NT$)";
            // 
            // labelLabor
            // 
            this.labelLabor.AutoSize = true;
            this.labelLabor.Location = new System.Drawing.Point(242, 32);
            this.labelLabor.Name = "labelLabor";
            this.labelLabor.Size = new System.Drawing.Size(70, 18);
            this.labelLabor.TabIndex = 2;
            this.labelLabor.Text = "工時 (小時)" ;
            // 
            // txtParts
            // 
            this.txtParts.Location = new System.Drawing.Point(90, 29);
            this.txtParts.Name = "txtParts";
            this.txtParts.Size = new System.Drawing.Size(130, 29);
            this.txtParts.TabIndex = 0;
            // 
            // txtLabor
            // 
            this.txtLabor.Location = new System.Drawing.Point(318, 29);
            this.txtLabor.Name = "txtLabor";
            this.txtLabor.Size = new System.Drawing.Size(88, 29);
            this.txtLabor.TabIndex = 1;
            // 
            // groupBoxFees
            // 
            this.groupBoxFees.Controls.Add(this.labelTotal);
            this.groupBoxFees.Controls.Add(this.labelTax);
            this.groupBoxFees.Controls.Add(this.labelPartsCost);
            this.groupBoxFees.Controls.Add(this.labelServiceLabor);
            this.groupBoxFees.Controls.Add(this.txtTotal);
            this.groupBoxFees.Controls.Add(this.txtTax);
            this.groupBoxFees.Controls.Add(this.txtPartsCost);
            this.groupBoxFees.Controls.Add(this.txtServiceLabor);
            this.groupBoxFees.Location = new System.Drawing.Point(12, 312);
            this.groupBoxFees.Name = "groupBoxFees";
            this.groupBoxFees.Size = new System.Drawing.Size(454, 160);
            this.groupBoxFees.TabIndex = 4;
            this.groupBoxFees.TabStop = false;
            this.groupBoxFees.Text = "費用摘要";
            // 
            // labelTotal
            // 
            this.labelTotal.AutoSize = true;
            this.labelTotal.Location = new System.Drawing.Point(18, 120);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(54, 18);
            this.labelTotal.TabIndex = 7;
            this.labelTotal.Text = "總費用";
            // 
            // labelTax
            // 
            this.labelTax.AutoSize = true;
            this.labelTax.Location = new System.Drawing.Point(18, 86);
            this.labelTax.Name = "labelTax";
            this.labelTax.Size = new System.Drawing.Size(66, 18);
            this.labelTax.TabIndex = 6;
            this.labelTax.Text = "稅金 (零件)";
            // 
            // labelPartsCost
            // 
            this.labelPartsCost.AutoSize = true;
            this.labelPartsCost.Location = new System.Drawing.Point(18, 52);
            this.labelPartsCost.Name = "labelPartsCost";
            this.labelPartsCost.Size = new System.Drawing.Size(36, 18);
            this.labelPartsCost.TabIndex = 5;
            this.labelPartsCost.Text = "零件";
            // 
            // labelServiceLabor
            // 
            this.labelServiceLabor.AutoSize = true;
            this.labelServiceLabor.Location = new System.Drawing.Point(18, 22);
            this.labelServiceLabor.Name = "labelServiceLabor";
            this.labelServiceLabor.Size = new System.Drawing.Size(90, 18);
            this.labelServiceLabor.TabIndex = 4;
            this.labelServiceLabor.Text = "服務與工資";
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(132, 117);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(152, 29);
            this.txtTotal.TabIndex = 3;
            // 
            // txtTax
            // 
            this.txtTax.Location = new System.Drawing.Point(132, 83);
            this.txtTax.Name = "txtTax";
            this.txtTax.ReadOnly = true;
            this.txtTax.Size = new System.Drawing.Size(152, 29);
            this.txtTax.TabIndex = 2;
            // 
            // txtPartsCost
            // 
            this.txtPartsCost.Location = new System.Drawing.Point(132, 49);
            this.txtPartsCost.Name = "txtPartsCost";
            this.txtPartsCost.ReadOnly = true;
            this.txtPartsCost.Size = new System.Drawing.Size(152, 29);
            this.txtPartsCost.TabIndex = 1;
            // 
            // txtServiceLabor
            // 
            this.txtServiceLabor.Location = new System.Drawing.Point(132, 19);
            this.txtServiceLabor.Name = "txtServiceLabor";
            this.txtServiceLabor.ReadOnly = true;
            this.txtServiceLabor.Size = new System.Drawing.Size(152, 29);
            this.txtServiceLabor.TabIndex = 0;
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(492, 330);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(120, 36);
            this.btnCalculate.TabIndex = 5;
            this.btnCalculate.Text = "計算總額";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.calculateButton_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(492, 380);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(120, 36);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "清除";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(492, 430);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(120, 36);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "離開";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(630, 490);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.groupBoxFees);
            this.Controls.Add(this.groupBoxOther);
            this.Controls.Add(this.groupBoxMisc);
            this.Controls.Add(this.groupBoxFlush);
            this.Controls.Add(this.groupBoxOilLube);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "汽車維修服務";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.groupBoxOilLube.ResumeLayout(false);
            this.groupBoxOilLube.PerformLayout();
            this.groupBoxFlush.ResumeLayout(false);
            this.groupBoxFlush.PerformLayout();
            this.groupBoxMisc.ResumeLayout(false);
            this.groupBoxMisc.PerformLayout();
            this.groupBoxOther.ResumeLayout(false);
            this.groupBoxOther.PerformLayout();
            this.groupBoxFees.ResumeLayout(false);
            this.groupBoxFees.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxOilLube;
        private System.Windows.Forms.CheckBox cbLubeJob;
        private System.Windows.Forms.CheckBox cbOilChange;
        private System.Windows.Forms.GroupBox groupBoxFlush;
        private System.Windows.Forms.CheckBox cbTransmissionFlush;
        private System.Windows.Forms.CheckBox cbRadiatorFlush;
        private System.Windows.Forms.GroupBox groupBoxMisc;
        private System.Windows.Forms.CheckBox cbTireRotation;
        private System.Windows.Forms.CheckBox cbReplaceMuffler;
        private System.Windows.Forms.CheckBox cbInspection;
        private System.Windows.Forms.GroupBox groupBoxOther;
        private System.Windows.Forms.Label labelParts;
        private System.Windows.Forms.Label labelLabor;
        private System.Windows.Forms.TextBox txtParts;
        private System.Windows.Forms.TextBox txtLabor;
        private System.Windows.Forms.GroupBox groupBoxFees;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.Label labelTax;
        private System.Windows.Forms.Label labelPartsCost;
        private System.Windows.Forms.Label labelServiceLabor;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.TextBox txtTax;
        private System.Windows.Forms.TextBox txtPartsCost;
        private System.Windows.Forms.TextBox txtServiceLabor;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnExit;
    }
}

