using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Program7_5
{
    public partial class Form1 : Form
    {
        // 儲存球隊與冠軍隊伍資料
        private List<string> teams = new List<string>();
        private List<string> winners = new List<string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 提示選擇球隊名稱檔案
            MessageBox.Show("請選取球隊名稱的檔案（Teams.txt）", "步驟 1", MessageBoxButtons.OK, MessageBoxIcon.Information);
            讀取Teams檔案();

            // 提示選擇比賽紀錄檔案
            MessageBox.Show("請選取球隊比賽紀錄的檔案（WorldSeriesWinners.txt）", "步驟 2", MessageBoxButtons.OK, MessageBoxIcon.Information);
            讀取Winners檔案();
        }

        private void 讀取Teams檔案()
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Title = "請選擇球隊名稱檔案（Teams.txt）";
                openFileDialog.Filter = "文字檔案 (*.txt)|*.txt";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    teams = new List<string>(File.ReadAllLines(openFileDialog.FileName));
                    listBox1.Items.Clear();
                    foreach (string team in teams)
                    {
                        listBox1.Items.Add(team);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("讀取球隊名稱檔案失敗：" + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void 讀取Winners檔案()
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Title = "請選擇世界大賽冠軍紀錄檔案（WorldSeriesWinners.txt）";
                openFileDialog.Filter = "文字檔案 (*.txt)|*.txt";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    winners = new List<string>(File.ReadAllLines(openFileDialog.FileName));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("讀取世界大賽冠軍紀錄檔案失敗：" + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null) return;

            string selectedTeam = listBox1.SelectedItem.ToString();
            int winCount = 0;
            List<int> winYears = new List<int>();

            int year = 1903;
            int index = 0;

            // 遍歷每一筆冠軍資料（winners），並跳過未舉行的年份
            while (index < winners.Count && year <= 2009)
            {
                if (year == 1904 || year == 1994)
                {
                    year++;
                    continue;
                }

                if (winners[index] == selectedTeam)
                {
                    winCount++;
                    winYears.Add(year);
                }

                year++;
                index++;
            }

            label1.Text = $"{selectedTeam} 從 1903 年至 2009 年共獲得 {winCount} 次世界大賽冠軍。\n" +
              (winYears.Count > 0 ? $"獲勝年份：{string.Join("、", winYears)}" : "無奪冠紀錄。");

        }
    }
}
