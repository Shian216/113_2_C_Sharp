using System;
using System.Drawing;
using System.Windows.Forms;

namespace Seating_Chart
{
    public partial class Form1 : Form
    {
        // ✅ 只新增 seatTextBox，rowTextBox 和 colTextBox 已在 Designer.cs 裡面了
        private TextBox seatTextBox;

        public Form1()
        {
            InitializeComponent();

            // ✅ 動態建立 seatTextBox
            seatTextBox = new TextBox
            {
                Location = new Point(20, 20),
                Size = new Size(200, 30),
                Name = "seatTextBox"
            };
            this.Controls.Add(seatTextBox);
        }

        private void displayPriceButton_Click(object sender, EventArgs e)
        {
            string seatArea = seatTextBox.Text.Trim().ToLower();
            string row = rowTextBox.Text.Trim(); // ✅ 來自 Designer.cs，這裡不要宣告
            string col = colTextBox.Text.Trim(); // ✅ 來自 Designer.cs，這裡不要宣告
            string message;

            if (!int.TryParse(row, out int rowNumber) || rowNumber < 0 || rowNumber > 5)
            {
                MessageBox.Show("請輸入有效的行數 (0 到 5).", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(col, out int colNumber) || colNumber < 0 || colNumber > 3)
            {
                MessageBox.Show("請輸入有效的列數 (0 到 3).", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            switch (seatArea)
            {
                case "vip":
                    message = $"VIP 區域的票價為 $150. 行數: {rowNumber}, 列數: {colNumber}";
                    break;
                case "regular":
                    message = $"普通區域的票價為 $75. 行數: {rowNumber}, 列數: {colNumber}";
                    break;
                case "economy":
                    message = $"經濟區域的票價為 $50. 行數: {rowNumber}, 列數: {colNumber}";
                    break;
                default:
                    message = "請輸入有效的座位區域 (VIP, Regular, Economy).";
                    break;
            }

            MessageBox.Show(message, "票價資訊", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
