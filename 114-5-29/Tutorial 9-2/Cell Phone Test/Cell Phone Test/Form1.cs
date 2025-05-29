using System;
using System.Windows.Forms;

namespace Cell_Phone_Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // 設定標籤和按鈕的顯示文字
            promptBrandLabel.Text = "品牌：";
            promptModelLabel.Text = "型號：";
            promptPriceLabel.Text = "價格：";

            createObjectButton.Text = "建立物件";
            exitButton.Text = "結束";
        }

        /// <summary>
        /// 從表單輸入欄位取得使用者輸入，並設定到 CellPhone 物件。
        /// </summary>
        /// <param name="phone">CellPhone 物件</param>
        private void GetPhoneData(CellPhone phone)
        {
            phone.Brand = brandTextBox.Text;
            phone.Model = modelTextBox.Text;

            if (decimal.TryParse(priceTextBox.Text, out decimal price))
            {
                phone.Price = price;
            }
            else
            {
                MessageBox.Show("請輸入有效的價格數字！");
                priceTextBox.Focus();
            }
        }

        /// <summary>
        /// 使用者按下「建立物件」按鈕後的處理。
        /// </summary>
        private void createObjectButton_Click(object sender, EventArgs e)
        {
            CellPhone phone = new CellPhone();
            GetPhoneData(phone);

            // 使用 MessageBox 顯示結果
            MessageBox.Show(
                $"品牌：{phone.Brand}\n" +
                $"型號：{phone.Model}\n" +
                $"價格：{phone.Price:C}",
                "手機資訊",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        /// <summary>
        /// 離開按鈕：關閉應用程式。
        /// </summary>
        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
