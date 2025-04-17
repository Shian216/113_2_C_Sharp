using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Seating_Chart
{
    public partial class Form1 : Form
    {
        // 定義 seatTextBox
        private TextBox seatTextBox;

        public Form1()
        {
            InitializeComponent();

            // 初始化 seatTextBox
            seatTextBox = new TextBox
            {
                Location = new System.Drawing.Point(20, 20), // 設定位置
                Size = new System.Drawing.Size(100, 20),    // 設定大小
                Name = "seatTextBox"                       // 設定名稱
            };

            // 將 TextBox 加入到表單中
            this.Controls.Add(seatTextBox);
        }

        private void displayPriceButton_Click(object sender, EventArgs e)
        {
            // 假設座位與價格的對應關係
            Dictionary<string, decimal> seatPrices = new Dictionary<string, decimal>
            {
                { "A1", 50.0m },
                { "A2", 50.0m },
                { "B1", 40.0m },
                { "B2", 40.0m },
                { "C1", 30.0m },
                { "C2", 30.0m }
            };

            // 確保 seatTextBox 有輸入值
            string selectedSeat = seatTextBox.Text.Trim();

            if (!string.IsNullOrEmpty(selectedSeat))
            {
                // 檢查輸入的座位是否在價格表中
                if (seatPrices.TryGetValue(selectedSeat, out decimal price))
                {
                    // 顯示價格
                    MessageBox.Show($"座位 {selectedSeat} 的價格是 {price:C}", "價格資訊");
                }
                else
                {
                    MessageBox.Show("輸入的座位無效。", "錯誤");
                }
            }
            else
            {
                MessageBox.Show("請輸入一個座位編號。", "提示");
            }
        }
    }
}
