using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Program7_5
{
    public partial class Form1 : Form
    {
        private List<string> teams = new List<string>();
        private List<string> winners = new List<string>();
        private string teamsFilePath = "";
        private string winnersFilePath = "";
        private int maxYear = 2009; // 初始只顯示到2009

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("請選取球隊名稱的檔案（Teams.txt）", "步驟 1", MessageBoxButtons.OK, MessageBoxIcon.Information);
            讀取Teams檔案();

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
                    teamsFilePath = openFileDialog.FileName;
                    teams = new List<string>(File.ReadAllLines(teamsFilePath));

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
                    winnersFilePath = openFileDialog.FileName;
                    winners = new List<string>(File.ReadAllLines(winnersFilePath));
                    // 僅保留1903~2009年資料（排除1904、1994），共105筆
                    List<int> validYears = new List<int>();
                    int year = 1903;
                    while (validYears.Count < 105)
                    {
                        if (year != 1904 && year != 1994)
                            validYears.Add(year);
                        year++;
                    }
                    if (winners.Count > 105)
                        winners = winners.Take(105).ToList();
                    maxYear = 2009;
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

            // 產生1903~maxYear的年份清單（排除1904與1994）
            List<int> validYears = new List<int>();
            for (int y = 1903; y <= maxYear; y++)
            {
                if (y != 1904 && y != 1994)
                    validYears.Add(y);
            }

            int dataCount = Math.Min(winners.Count, validYears.Count);
            for (int i = 0; i < dataCount; i++)
            {
                if (winners[i] == selectedTeam)
                {
                    winCount++;
                    winYears.Add(validYears[i]);
                }
            }

            int startYear = validYears.First();
            int endYear = validYears.Last();

            label1.Text = $"{selectedTeam} 從 {startYear} 年至 {endYear} 年共獲得 {winCount} 次世界大賽冠軍。\n" +
                          (winYears.Count > 0 ? $"獲勝年份：{string.Join("、", winYears)}" : "無奪冠紀錄。");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                // 僅允許在105筆時新增
                if (winners.Count != 105)
                {
                    MessageBox.Show("只能在尚未新增2010-2024年資料時進行此操作。", "操作錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Title = "請選擇 2010 年以後的冠軍紀錄檔案";
                openFileDialog.Filter = "文字檔案 (*.txt)|*.txt";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string[] newWinners = File.ReadAllLines(openFileDialog.FileName);

                    if (newWinners.Length != 15)
                    {
                        MessageBox.Show("新增資料必須為 2010 年至 2024 年共 15 筆紀錄。", "資料錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    foreach (string winner in newWinners)
                    {
                        winners.Add(winner);

                        if (!teams.Contains(winner))
                        {
                            teams.Add(winner);
                            listBox1.Items.Add(winner);
                        }
                    }

                    maxYear = 2024; // 新增後顯示到2024

                    // 若已選定隊伍則自動刷新
                    if (listBox1.SelectedItem != null)
                    {
                        listBox1_SelectedIndexChanged(null, null);
                    }

                    MessageBox.Show("新增資料成功！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("新增資料失敗：" + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(teamsFilePath))
                    File.WriteAllLines(teamsFilePath, teams);

                if (!string.IsNullOrEmpty(winnersFilePath))
                    File.WriteAllLines(winnersFilePath, winners);

                MessageBox.Show("資料已儲存，程式將結束。", "儲存完成", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit(); // 關閉程式
            }
            catch (Exception ex)
            {
                MessageBox.Show("儲存失敗：" + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}



