using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Lottery_Numbers
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            // 建立隨機數生成器
            Random random = new Random();

            // 儲存樂透號碼的 HashSet，確保不重複
            HashSet<int> lotteryNumbers = new HashSet<int>();

            // 生成 6 個不重複的號碼
            while (lotteryNumbers.Count < 6)
            {
                int number = random.Next(1, 50); // 生成 1 到 49 的隨機數
                lotteryNumbers.Add(number);
            }

            // 將號碼排序並轉換為字串
            string result = string.Join(", ", lotteryNumbers.OrderBy(n => n));

            // 顯示結果於 MessageBox
            MessageBox.Show($"生成的樂透號碼為: {result}", "樂透號碼", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉表單
            this.Close();
        }
    }
}


