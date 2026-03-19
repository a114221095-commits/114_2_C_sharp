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
                return 0.0;

            double sum = 0;
            foreach (int val in scores)
            {
                sum += val;
            }

            return sum / scores.Length;
        }

        // The Highest method accepts an int array argument
        // and returns the highest value in that array.
        private int Highest(int[] scores)
        {
            if (scores == null || scores.Length == 0)
                return 0;

            int high = scores[0];
            foreach (int val in scores)
            {
                if (val > high)
                    high = val;
            }

            return high;
        }

        // The Lowest method accepts an int array argument
        // and returns the lowest value in that array.
        private int Lowest(int[] scores)
        {
            if (scores == null || scores.Length == 0)
                return 0;

            int low = scores[0];
            foreach (int val in scores)
            {
                if (val < low)
                    low = val;
            }

            return low;
        }

        private void getScoresButton_Click(object sender, EventArgs e)
        {
            const int SIZE = 5;
            int[] scores = new int[SIZE];
            StreamReader inputFile = null;
            int index = 0;

            testScoresListBox.Items.Clear();
            highScoreLabel.Text = string.Empty;
            lowScoreLabel.Text = string.Empty;
            averageScoreLabel.Text = string.Empty;

            try
            {
                inputFile = File.OpenText("TestScores.txt");

                while (!inputFile.EndOfStream && index < scores.Length)
                {
                    string line = inputFile.ReadLine();
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        scores[index] = int.Parse(line);
                        index++;
                    }
                }

                inputFile.Close();
                inputFile = null;

                if (index == 0)
                {
                    MessageBox.Show("找不到成績資料或檔案為空。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // 只使用實際讀入的元素
                int[] usedScores = new int[index];
                Array.Copy(scores, usedScores, index);

                foreach (int val in usedScores)
                {
                    testScoresListBox.Items.Add(val);
                }

                int high = Highest(usedScores);
                int low = Lowest(usedScores);
                double avg = Average(usedScores);

                highScoreLabel.Text = high.ToString();
                lowScoreLabel.Text = low.ToString();
                averageScoreLabel.Text = avg.ToString("F1");
            }
            catch (Exception ex)
            {
                // 顯示錯誤訊息
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (inputFile != null)
                {
                    inputFile.Close();
                }
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // Close the form.
            this.Close();
        }
    }
}
