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

namespace Test_Average
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // The Average method accepts an int array argument
        // and returns the Average of the values in the array.
        private double Average(int[] scores)
        {
            if (scores == null || scores.Length == 0)
                return 0;

            return scores.Average();
        }

        // The Highest method accepts an int array argument
        // and returns the highest value in that array.
        private int Highest(int[] scores)
        {
            if (scores == null || scores.Length == 0)
                return 0;

            return scores.Max();
        }

        // The Lowest method accepts an int array argument
        // and returns the lowest value in that array.
        private int Lowest(int[] scores)
        {
            if (scores == null || scores.Length == 0)
                return 0;

            return scores.Min();
        }

        private void getScoresButton_Click(object sender, EventArgs e)
        {
            try
            {
                // 假設分數來自檔案 "scores.txt"
                string filePath = "scores.txt";

                if (!File.Exists(filePath))
                {
                    MessageBox.Show("分數檔案不存在。", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 讀取分數並轉換為整數陣列
                string[] lines = File.ReadAllLines(filePath);
                int[] scores = Array.ConvertAll(lines, int.Parse);

                // 計算平均值、最高分與最低分
                double average = Average(scores);
                int highest = Highest(scores);
                int lowest = Lowest(scores);

                // 顯示結果
                MessageBox.Show($"平均分數: {average:F2}\n最高分: {highest}\n最低分: {lowest}", "結果", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"發生錯誤: {ex.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // Close the form.
            this.Close();
        }
    }
}
