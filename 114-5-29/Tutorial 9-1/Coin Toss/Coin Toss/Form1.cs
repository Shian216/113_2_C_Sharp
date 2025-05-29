using System;
using System.Windows.Forms;

namespace Coin_Toss
{
    public partial class Form1 : Form
    {
        // 建立一個隨機數產生器，用於擲硬幣的隨機結果
        private Random random = new Random();

        public Form1()
        {
            InitializeComponent();

            // 設定按鈕的顯示文字為繁體中文
            tossButton.Text = "擲硬幣";
            exitButton.Text = "離開";
            // 不再使用 resultLabel，移除此相關設定
        }

        private void tossButton_Click(object sender, EventArgs e)
        {
            // 當使用者點擊「擲硬幣」按鈕時，隨機產生 0 或 1
            // 0 代表正面，1 代表反面，並以訊息方塊顯示結果
            int toss = random.Next(2); // 產生 0 或 1

            if (toss == 0)
            {
                MessageBox.Show("正面", "擲硬幣結果", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("反面", "擲硬幣結果", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉表單，結束應用程式
            this.Close();
        }
    }
}
