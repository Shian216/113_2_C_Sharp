using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Program7_5
{
    public partial class Form1 : Form
    {
        // 結構定義
        public class TeamData
        {
            public string Name { get; set; }
            public int WinCount { get; set; }
            public List<int> WinYears { get; set; }

            public TeamData(string name)
            {
                Name = name;
                WinCount = 0;
                WinYears = new List<int>();
            }
        }

        private List<string> teams = new List<string>();
        private List<string> winners = new List<string>();
        private List<TeamData> teamDataList = new List<TeamData>();

        private string teamsFilePath = "";
        private string winnersFilePath = "";
        private int maxYear = 2009;

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
                    var allWinners = new List<string>(File.ReadAllLines(winnersFilePath));

                    // 只取 1903-2009 年的資料（105 筆）
                    winners = allWinners.Take(105).ToList();

                    List<int> validYears = new List<int>();
                    int year = 1903;
                    while (validYears.Count < winners.Count)
                    {
                        if (year != 1904 && year != 1994)
                            validYears.Add(year);
                        year++;
                    }

                    teamDataList.Clear();
                    foreach (string team in teams)
                    {
                        teamDataList.Add(new TeamData(team));
                    }

                    for (int i = 0; i < winners.Count; i++)
                    {
                        string winner = winners[i];
                        int winYear = validYears[i];

                        TeamData team = teamDataList.FirstOrDefault(t => t.Name == winner);
                        if (team == null)
                        {
                            team = new TeamData(winner);
                            teamDataList.Add(team);
                            if (!teams.Contains(winner))
                                teams.Add(winner);
                        }

                        team.WinCount++;
                        team.WinYears.Add(winYear);
                    }

                    maxYear = 2009; // 只顯示到 2009
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
            TeamData selectedData = teamDataList.FirstOrDefault(t => t.Name == selectedTeam);

            if (selectedData != null)
            {
                int startYear = 1903;
                int endYear = maxYear;

                // 只顯示 maxYear 以內的年份
                var winYearsInRange = selectedData.WinYears.Where(y => y <= maxYear).ToList();
                int winCountInRange = winYearsInRange.Count;

                label1.Text = $"{selectedData.Name} 從 {startYear} 年至 {endYear} 年共獲得 {winCountInRange} 次世界大賽冠軍。\n" +
                              (winYearsInRange.Count > 0
                                  ? $"獲勝年份：{string.Join("、", winYearsInRange)}"
                                  : "無奪冠紀錄。");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
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

                    for (int i = 0; i < newWinners.Length; i++)
                    {
                        string winner = newWinners[i];
                        int year = 2010 + i;

                        winners.Add(winner);

                        if (!teams.Contains(winner))
                        {
                            teams.Add(winner);
                            listBox1.Items.Add(winner);
                        }

                        TeamData team = teamDataList.FirstOrDefault(t => t.Name == winner);
                        if (team == null)
                        {
                            team = new TeamData(winner);
                            teamDataList.Add(team);
                        }

                        team.WinCount++;
                        team.WinYears.Add(year);
                    }

                    maxYear = 2024;

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

                MessageBox.Show($"資料已儲存至以下位置：\n球隊檔案：{teamsFilePath}\n冠軍紀錄：{winnersFilePath}\n\n程式即將關閉。", "儲存完成", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("儲存失敗：" + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}




