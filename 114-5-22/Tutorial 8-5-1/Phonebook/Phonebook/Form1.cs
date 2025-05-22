using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Phonebook
{
    struct PhoneBookEntry
    {
        public string name;
        public string phone;
    }

    public partial class Form1 : Form
    {
        // Field to hold a list of PhoneBookEntry objects.
        private List<PhoneBookEntry> phoneList = 
            new List<PhoneBookEntry>();

        public Form1()
        {
            InitializeComponent();
        }

        // The ReadFile method reads the contents of the
        // PhoneList.txt file and stores it as PhoneBookEntry
        // objects in the phoneList.

        // 讀取 PhoneList.txt 並填入 phoneList
        private void ReadFile()
        {
            try
            {
                string[] lines = File.ReadAllLines("PhoneList.txt");

                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 2)
                    {
                        PhoneBookEntry entry = new PhoneBookEntry
                        {
                            name = parts[0].Trim(),
                            phone = parts[1].Trim()
                        };
                        phoneList.Add(entry);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("錯誤讀取檔案：" + ex.Message);
            }
        }

        // 顯示所有名字在 ListBox 中
        private void DisplayNames()
        {
            nameListBox.Items.Clear();

            foreach (PhoneBookEntry entry in phoneList)
            {
                nameListBox.Items.Add(entry.name);
            }
        }

        // 表單載入時執行
        private void Form1_Load(object sender, EventArgs e)
        {
            ReadFile();
            DisplayNames();
        }

        // 選擇名字時顯示對應電話號碼
        private void nameListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = nameListBox.SelectedIndex;
            if (index >= 0 && index < phoneList.Count)
            {
                phoneLabel.Text = phoneList[index].phone;
            }
        }

        // 關閉表單
        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}