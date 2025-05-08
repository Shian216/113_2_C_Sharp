using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Password_Validation
{
    public partial class Form1 : Form
    {
        // 回傳字串中大寫字母的數量
        private int NumberUpperCase(string str)
        {
            return str.Count(char.IsUpper);
        }

        // 回傳字串中小寫字母的數量
        private int NumberLowerCase(string str)
        {
            return str.Count(char.IsLower);
        }

        // 回傳字串中數字的數量
        private int NumberDigits(string str)
        {
            return str.Count(char.IsDigit);
        }

        // 當使用者按下 "檢查密碼" 按鈕時
        private void checkPasswordButton_Click(object sender, EventArgs e)
        {
            string password = passwordTextBox.Text;

            int upperCount = NumberUpperCase(password);
            int lowerCount = NumberLowerCase(password);
            int digitCount = NumberDigits(password);

            // 判斷密碼是否符合條件
            if (password.Length >= 8 && upperCount > 0 && lowerCount > 0 && digitCount > 0)
            {
                MessageBox.Show("密碼有效！");
            }
            else
            {
                string message = "密碼無效。請確認以下條件皆符合：\n";
                if (password.Length < 8)
                    message += "- 至少 8 個字元\n";
                if (upperCount == 0)
                    message += "- 至少包含一個大寫字母\n";
                if (lowerCount == 0)
                    message += "- 至少包含一個小寫字母\n";
                if (digitCount == 0)
                    message += "- 至少包含一個數字\n";

                MessageBox.Show(message, "驗證失敗");
            }
        }

        // 當使用者按下 "退出" 按鈕時
        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
    