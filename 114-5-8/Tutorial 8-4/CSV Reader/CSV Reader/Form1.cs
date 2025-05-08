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

namespace CSV_Reader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void getScoresButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            openFileDialog.Title = "選擇 CSV 檔案";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string[] lines = File.ReadAllLines(openFileDialog.FileName);
                    string output = "";

                    foreach (string line in lines)
                    {
                        string[] parts = line.Split(',');

                        if (parts.Length == 2)
                        {
                            string name = parts[0].Trim();
                            string score = parts[1].Trim();
                            output += $"{name}：{score}\n";
                        }
                    }

                    // 顯示在 message box 或某個 TextBox/ListBox
                    MessageBox.Show(output, "成績列表");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"讀取檔案時發生錯誤：{ex.Message}", "錯誤");
                }
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

