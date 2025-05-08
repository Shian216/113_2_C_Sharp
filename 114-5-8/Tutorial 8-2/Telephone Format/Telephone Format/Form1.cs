using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Telephone_Format
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // 檢查字串是否為 10 位數字
        private bool IsValidNumber(string str)
        {
            return str.All(char.IsDigit) && str.Length == 10;
        }

        // 將字串格式化為 (XXX)XXX-XXXX
        private void TelephoneFormat(ref string str)
        {
            str = $"({str.Substring(0, 3)}){str.Substring(3, 3)}-{str.Substring(6, 4)}";
        }

        // 按下格式化按鈕時執行
        private void formatButton_Click(object sender, EventArgs e)
        {
            string input = phoneNumberTextBox.Text.Trim(); // 假設有名為 phoneNumberTextBox 的 TextBox

            // 移除非數字字元（如果使用者手動輸入格式）
            input = new string(input.Where(char.IsDigit).ToArray());

            if (IsValidNumber(input))
            {
                TelephoneFormat(ref input);
                phoneNumberTextBox.Text = input;
            }
            else
            {
                MessageBox.Show("請輸入正確的 10 位數字電話號碼。", "格式錯誤");
            }
        }

        // 關閉視窗
        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
