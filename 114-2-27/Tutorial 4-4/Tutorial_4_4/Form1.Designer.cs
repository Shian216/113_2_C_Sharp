namespace Tutorial_4_4
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtKm = new System.Windows.Forms.TextBox();
            this.TxtL = new System.Windows.Forms.TextBox();
            this.LblShow = new System.Windows.Forms.Label();
            this.BtnCount = new System.Windows.Forms.Button();
            this.BtnExit = new System.Windows.Forms.Button();
            this.LbxLog = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(12, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 47);
            this.label1.TabIndex = 0;
            this.label1.Text = "輸入行駛里程數";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(9, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(191, 47);
            this.label2.TabIndex = 1;
            this.label2.Text = "消耗油量公升數";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(9, 245);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(191, 47);
            this.label3.TabIndex = 2;
            this.label3.Text = "平均油耗";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TxtKm
            // 
            this.TxtKm.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.TxtKm.Location = new System.Drawing.Point(206, 87);
            this.TxtKm.Name = "TxtKm";
            this.TxtKm.Size = new System.Drawing.Size(306, 39);
            this.TxtKm.TabIndex = 3;
            // 
            // TxtL
            // 
            this.TxtL.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.TxtL.Location = new System.Drawing.Point(206, 170);
            this.TxtL.Name = "TxtL";
            this.TxtL.Size = new System.Drawing.Size(306, 39);
            this.TxtL.TabIndex = 4;
            // 
            // LblShow
            // 
            this.LblShow.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LblShow.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.LblShow.Location = new System.Drawing.Point(206, 249);
            this.LblShow.Name = "LblShow";
            this.LblShow.Size = new System.Drawing.Size(306, 39);
            this.LblShow.TabIndex = 5;
            this.LblShow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnCount
            // 
            this.BtnCount.Font = new System.Drawing.Font("微軟正黑體", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.BtnCount.Location = new System.Drawing.Point(70, 329);
            this.BtnCount.Name = "BtnCount";
            this.BtnCount.Size = new System.Drawing.Size(188, 47);
            this.BtnCount.TabIndex = 6;
            this.BtnCount.Text = "計算";
            this.BtnCount.UseVisualStyleBackColor = true;
            this.BtnCount.Click += new System.EventHandler(this.BtnCount_Click);
            // 
            // BtnExit
            // 
            this.BtnExit.Font = new System.Drawing.Font("微軟正黑體", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.BtnExit.Location = new System.Drawing.Point(292, 329);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(188, 47);
            this.BtnExit.TabIndex = 7;
            this.BtnExit.Text = "離開";
            this.BtnExit.UseVisualStyleBackColor = true;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // LbxLog
            // 
            this.LbxLog.FormattingEnabled = true;
            this.LbxLog.ItemHeight = 12;
            this.LbxLog.Location = new System.Drawing.Point(554, 87);
            this.LbxLog.Name = "LbxLog";
            this.LbxLog.Size = new System.Drawing.Size(169, 220);
            this.LbxLog.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button1.Location = new System.Drawing.Point(554, 313);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(169, 31);
            this.button1.TabIndex = 9;
            this.button1.Text = "平均油耗";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.LbxLog);
            this.Controls.Add(this.BtnExit);
            this.Controls.Add(this.BtnCount);
            this.Controls.Add(this.LblShow);
            this.Controls.Add(this.TxtL);
            this.Controls.Add(this.TxtKm);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtKm;
        private System.Windows.Forms.TextBox TxtL;
        private System.Windows.Forms.Label LblShow;
        private System.Windows.Forms.Button BtnCount;
        private System.Windows.Forms.Button BtnExit;
        private System.Windows.Forms.ListBox LbxLog;
        private System.Windows.Forms.Button button1;
    }
}

