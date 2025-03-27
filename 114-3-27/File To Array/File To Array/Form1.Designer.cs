using System;
using System.Windows.Forms;

namespace FileToArray
{
    public partial class Form1 : Form  // 確保繼承自 Form 類別
    {
        /// <summary>
        /// 必需的設計器變量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Button btnLoadFile;
        private OpenFileDialog openFileDialog;

        /// <summary>
        /// 清理所有正在使用的資源。
        /// </summary>
        /// <param name="disposing">如果應釋放托管資源，為 true；否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // 釋放托管資源
                if (components != null)
                {
                    components.Dispose();
                }
            }
            // 釋放非托管資源
            base.Dispose(disposing);  // 呼叫基底類別的 Dispose 方法
        }

        #region Windows 窗體設計器生成的代碼

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnLoadFile = new Button();
            this.openFileDialog = new OpenFileDialog();

            // 
            // btnLoadFile
            // 
            this.btnLoadFile.Location = new System.Drawing.Point(350, 200);
            this.btnLoadFile.Name = "btnLoadFile";
            this.btnLoadFile.Size = new System.Drawing.Size(100, 30);
            this.btnLoadFile.TabIndex = 0;
            this.btnLoadFile.Text = "載入檔案";
            this.btnLoadFile.UseVisualStyleBackColor = true;
            this.btnLoadFile.Click += new EventHandler(this.btnLoadFile_Click);

            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F); // 設定自動縮放的比例
            this.AutoScaleMode = AutoScaleMode.Font;  // 設定為字型縮放模式
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnLoadFile);
            this.Name = "Form1";
            this.Text = "檔案轉陣列範例";
            this.ResumeLayout(false);
        }

        #endregion

        // 當按鈕被點擊時觸發這個方法
        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            // 顯示檔案選擇對話框
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                try
                {
                    // 讀取檔案內容並將每一行轉換為陣列
                    string[] lines = System.IO.File.ReadAllLines(filePath);

                    // 顯示檔案內容
                    MessageBox.Show("檔案內容轉換為陣列，總行數: " + lines.Length);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("檔案讀取錯誤: " + ex.Message);
                }
            }
        }
    }
}







