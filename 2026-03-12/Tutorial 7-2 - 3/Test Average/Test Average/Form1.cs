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
        // 不會修改傳入陣列（先複製再排序）。
        private int Highest(int[] sArray)
        {
            if (sArray == null || sArray.Length == 0)
                return 0;

            int[] scoreCopy = new int[sArray.Length];
            Array.Copy(sArray, scoreCopy, sArray.Length);
            Array.Sort(scoreCopy);
            return scoreCopy[scoreCopy.Length - 1];
        }

        // The Lowest method accepts an int array argument
        // and returns the lowest value in that array.
        // 不會修改傳入陣列（先複製再排序）。
        private int Lowest(int[] sArray)
        {
            if (sArray == null || sArray.Length == 0)
                return 0;

            int[] scoreCopy = new int[sArray.Length];
            Array.Copy(sArray, scoreCopy, sArray.Length);
            Array.Sort(scoreCopy);
            return scoreCopy[0];
        }

        // 讀取 TestScores.txt 並回傳有效（非空白）資料列數
        private int getFileScoreCount()
        {
            int count = 0;

            try
            {
                using (StreamReader inputFile = File.OpenText("TestScores.txt"))
                {
                    while (!inputFile.EndOfStream)
                    {
                        string line = inputFile.ReadLine();
                        if (!string.IsNullOrWhiteSpace(line))
                        {
                            count++;
                        }
                    }
                }
            }
            catch (Exception)
            {
                // 若檔案不存在或讀取失敗，回傳 0（呼叫端會處理）
                count = 0;
            }

            return count;
        }

        private void getScoresButton_Click(object sender, EventArgs e)
        {
            testScoresListBox.Items.Clear();
            highScoreLabel.Text = string.Empty;
            lowScoreLabel.Text = string.Empty;
            averageScoreLabel.Text = string.Empty;

            int size = getFileScoreCount();
            if (size == 0)
            {
                MessageBox.Show("找不到成績資料或檔案為空。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int[] scores = new int[size];
            int index = 0;
            StreamReader inputFile = null;

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

                // 顯示由小到大排序的成績（排序不會影響 Highest/Lowest 因為它們也會複製）
                Array.Sort(scores);
                foreach (int val in scores)
                {
                    testScoresListBox.Items.Add(val);
                }

                int high = Highest(scores);
                int low = Lowest(scores);
                double avg = Average(scores);

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
