using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Telephone_Unformat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // 設定表單的標題文字
            this.Text = "電話號碼格式化工具";

            // 設定按鈕的文字
            unformatButton.Text = "移除格式";
            exitButton.Text = "退出";
        }

        // IsValidFormat 方法
        // 此方法接受一個字串參數，並檢查該字串是否符合美國電話號碼的格式。
        // 格式要求為：(XXX)XXX-XXXX，其中 X 為數字。
        // 如果字串符合格式，則回傳 true；否則回傳 false。
        private bool IsValidFormat(string str)
        {
            if (str.Length == 13 &&
                str[0] == '(' &&
                str[4] == ')' &&
                str[8] == '-')
            {
                string areaCode = str.Substring(1, 3);
                string firstPart = str.Substring(5, 3);
                string secondPart = str.Substring(9, 4);

                // 檢查區域碼、第一部分和第二部分是否都是數字
                if (IsAllDigits(areaCode) &&
                    IsAllDigits(firstPart) &&
                    IsAllDigits(secondPart))
                {
                    return true;
                }
            }
            return false;
        }

        // IsAllDigits 方法
        // 此方法檢查字串是否只包含數字。
        private bool IsAllDigits(string str)
        {
            return str.All(char.IsDigit);
        }

        // Unformat 方法
        // 此方法接受一個字串參數（以參考方式傳遞），該字串假設為格式化的電話號碼。
        // 格式化的電話號碼格式為：(XXX)XXX-XXXX。
        // 此方法會移除字串中的括號與連字號，將其轉換為未格式化的純數字字串。
        private void Unformat(ref string str)
        {
            // 使用 Remove 移除非數字字元
            str = str.Remove(0, 1); // 移除開頭的 (
            str = str.Remove(3, 1); // 移除結尾的 )
            str = str.Remove(6, 1); // 移除中間的 -
        }

        // unformatButton_Click 事件處理方法
        // 當使用者按下 "移除格式" 按鈕時觸發此事件。
        // 此方法應該執行電話號碼的格式移除邏輯。
        private void unformatButton_Click(object sender, EventArgs e)
        {
            // 從文字框中取得使用者輸入的電話號碼
            string Input = numberTextBox.Text;

            // 檢查電話號碼格式是否正確
            if (IsValidFormat(Input))
            {
                // 去除格式
                Unformat(ref Input);

                // 顯示格式化後的結果
                MessageBox.Show("格式化後的電話號碼為：" + Input, "格式化結果", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // 顯示錯誤訊息
                MessageBox.Show("請輸入正確的電話號碼格式！", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // 清空輸入框
                numberTextBox.Clear();

                // 將焦點設置到輸入框
                numberTextBox.Focus();
            }
        }

        // exitButton_Click 事件處理方法
        // 當使用者按下 "退出" 按鈕時觸發此事件。
        // 此方法會關閉目前的表單，結束應用程式。
        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉表單
            this.Close();
        }
    }
}
