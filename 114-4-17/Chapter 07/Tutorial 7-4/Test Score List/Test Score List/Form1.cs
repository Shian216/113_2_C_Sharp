using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Test_Score_List
{
    public partial class Form1 : Form
    {
        private ListBox scoresListBox;

        public Form1()
        {
            InitializeComponent();
            InitializeCustomComponents();
        }

        private void InitializeCustomComponents()
        {
            // Initialize the ListBox
            scoresListBox = new ListBox
            {
                Location = new System.Drawing.Point(20, 20), // 設定位置
                Size = new System.Drawing.Size(200, 150)    // 設定大小
            };

            // Add the ListBox to the form
            this.Controls.Add(scoresListBox);
        }

        private void getScoresButton_Click(object sender, EventArgs e)
        {
            double averageScore;    // To hold the average score
            int numAboveAverage;    // Number of above average scores
            int numBelowAverage;    // Number of below average scores

            // Create a List to hold the scores.
            List<int> scoresList = new List<int>();

            // Read the scores from the file into the List.
            ReadScores(scoresList);

            // Display the scores.
            DisplayScores(scoresList);

            // Display the average score.
            averageScore = Average(scoresList);
            averageLabel.Text = averageScore.ToString("n1");

            // Display the number of above average scores.
            numAboveAverage = AboveAverage(scoresList, averageScore);
            aboveAverageLabel.Text = numAboveAverage.ToString();

            // Display the number of below average scores.
            numBelowAverage = BelowAverage(scoresList, averageScore);
            belowAverageLabel.Text = numBelowAverage.ToString();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // Close the form.
            this.Close();
        }

        private void ReadScores(List<int> scoresList)
        {
            try
            {
                // Open the file and read all lines.
                string[] lines = File.ReadAllLines("scores.txt");

                // Parse each line into an integer and add to the list.
                foreach (string line in lines)
                {
                    if (int.TryParse(line, out int score))
                    {
                        scoresList.Add(score);
                    }
                }
            }
            catch (Exception ex)
            {
                // Display an error message if the file cannot be read.
                MessageBox.Show($"Error reading the file: {ex.Message}");
            }
        }

        private void DisplayScores(List<int> scoresList)
        {
            // Clear the ListBox
            scoresListBox.Items.Clear();

            // Add each score to the ListBox.
            foreach (int score in scoresList)
            {
                scoresListBox.Items.Add(score);
            }
        }

        private double Average(List<int> scoresList)
        {
            // Calculate and return the average score.
            if (scoresList.Count > 0)
            {
                return scoresList.Average();
            }
            return 0.0;
        }

        private int AboveAverage(List<int> scoresList, double average)
        {
            // Count and return the number of scores above the average.
            return scoresList.Count(score => score > average);
        }

        private int BelowAverage(List<int> scoresList, double average)
        {
            // Count and return the number of scores below the average.
            return scoresList.Count(score => score < average);
        }
    }
}
