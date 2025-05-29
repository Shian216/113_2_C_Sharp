using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Cell_Phone_Inventory
{
    public partial class Form1 : Form
    {
        // 儲存手機清單
        List<CellPhone> phoneList = new List<CellPhone>();

        public Form1()
        {
            InitializeComponent();

            // 設定介面文字
            phoneListBox.Text = "品牌：";
            promptModelLabel.Text = "型號：";
            promptPriceLabel.Text = "價格：";
            addPhoneButton.Text = "新增手機";
            exitButton.Text = "離開";
            phoneListBox.Text = "手機清單";

            // 初始化顯示用標籤
            brandTextBox.Text = "";
            modelTextBox.Text = "";
            phoneListBox.Text = "";
        }

        private void GetPhoneData(CellPhone phone)
        {
            phone.Brand = brandTextBox.Text.Trim();
            phone.Model = modelTextBox.Text.Trim();

            if (decimal.TryParse(priceTextBox.Text.Trim(), out decimal price))
            {
                phone.Price = price;
            }
            else
            {
                MessageBox.Show("價格格式無效，請輸入有效的數字。", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                priceTextBox.Focus();
                phone.Price = 0;
            }
        }

        private void addPhoneButton_Click(object sender, EventArgs e)
        {
            CellPhone phone = new CellPhone();
            GetPhoneData(phone);

            if (string.IsNullOrWhiteSpace(phone.Brand) || string.IsNullOrWhiteSpace(phone.Model) || phone.Price <= 0)
            {
                MessageBox.Show("請完整且正確填寫所有欄位！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            phoneList.Add(phone);
            phoneListBox.Items.Add($"{phone.Brand} {phone.Model}");

            brandTextBox.Clear();
            modelTextBox.Clear();
            priceTextBox.Clear();
        }

        private void phoneListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = phoneListBox.SelectedIndex;

            if (index >= 0 && index < phoneList.Count)
            {
                CellPhone selectedPhone = phoneList[index];
                brandTextBox.Text = $"品牌：{selectedPhone.Brand}";
                modelTextBox.Text = $"型號：{selectedPhone.Model}";
                phoneListBox.Text = $"價格：{selectedPhone.Price:C}";
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
