namespace Array_To_File
{
    partial class Form1
    {
        /// <summary>
        /// 必需的設計器變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理任何正在使用的資源。
        /// </summary>
        /// <param name="disposing">如果應釋放託管資源，則為 true；否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                // 釋放所有使用中的資源
                components.Dispose();
            }
            // 呼叫基底類別的 Dispose 方法
            base.Dispose(disposing);
        }

        #region Windows Form 設計器生成的代碼

        /// <summary>
        /// 設計器支持所需的方法 - 請勿使用代碼編輯器修改此方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.instructionsLabel = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // instructionsLabel
            // 
            // 設定 instructionsLabel 的位置、名稱、大小和其他屬性
            this.instructionsLabel.Location = new System.Drawing.Point(11, 16);
            this.instructionsLabel.Name = "instructionsLabel";
            this.instructionsLabel.Size = new System.Drawing.Size(242, 33);
            this.instructionsLabel.TabIndex = 0;
            this.instructionsLabel.Text = "點擊 OK 按鈕將 numbers 陣列的內容寫入名為 Values.txt 的檔案中。";
            this.instructionsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // okButton
            // 
            // 設定 okButton 的位置、名稱、大小和其他屬性
            this.okButton.Location = new System.Drawing.Point(95, 68);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            // 設定 okButton 的點擊事件處理程序
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // Form1
            // 
            // 設定 Form1 的自動縮放尺寸、縮放模式、客戶區大小和其他屬性
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 107);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.instructionsLabel);
            this.Name = "Form1";
            this.Text = "Array To File";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label instructionsLabel;
        private System.Windows.Forms.Button okButton;
    }
}


