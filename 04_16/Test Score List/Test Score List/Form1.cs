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

namespace Test_Score_List
{
    public partial class Form1 : Form
    {
        // 將成績 List 提昇為欄位，供各事件存取
        private List<int> scoresList = new List<int>();
        private List<string> studentRecords = new List<string>();

        public Form1()
        {
            InitializeComponent();
        }

        // ReadScores : 從 TestScores.txt 檔案讀取「學號 分數」並加入 lists
        private void ReadScores()
        {
            string filePath = "TestScores.txt"; // 成績檔案路徑
            scoresList.Clear();
            studentRecords.Clear();

            try
            {
                if (!File.Exists(filePath))
                {
                    MessageBox.Show("成績檔案不存在： " + filePath);
                    return;
                }

                using (StreamReader reader = File.OpenText(filePath))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine(); // 讀取一行資料
                        if (!string.IsNullOrWhiteSpace(line))
                        {
                            // 使用空白字元分割學號和分數
                            string[] parts = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                            if (parts.Length >= 2)
                            {
                                string studentId = parts[0]; // 取得學號
                                int score;

                                // 嘗試將分數部分轉換為整數
                                if (int.TryParse(parts[1], out score))
                                {
                                    scoresList.Add(score); // 將分數加入 scoresList
                                    studentRecords.Add(studentId + " " + score); // 將完整資訊加入 studentRecords
                                }
                                // 若分數解析失敗則略過該行
                            }
                            // 若 parts 長度不足則略過該行
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("讀取成績時發生錯誤： " + ex.Message);
            }
        }

        // DisplayScores : 將 studentRecords（若有）或 scoresList 中的所有成績加入 ListBox 顯示
        private void DisplayScores()
        {
            DisplayScores(scoresList);
        }

        // 參數化版本：顯示傳入的 scores 清單（若 studentRecords 有資料則以 studentRecords 為主）
        private void DisplayScores(List<int> scores)
        {
            testScoresListBox.Items.Clear();
            int index = 1;

            if (studentRecords != null && studentRecords.Count > 0)
            {
                foreach (string record in studentRecords)
                {
                    testScoresListBox.Items.Add($"第{index}筆: {record}");
                    index++;
                }
            }
            else
            {
                foreach (int score in scores)
                {
                    testScoresListBox.Items.Add($"第{index}筆: {score}");
                    index++;
                }
            }
        }

        // Average : 計算並回傳成績平均值（無參數版）
        private double Average()
        {
            return Average(scoresList);
        }

        // 參數化版本：使用 LINQ 計算傳入清單的平均值
        private double Average(List<int> scores)
        {
            if (scores == null || scores.Count == 0)
            {
                return 0.0;
            }

            var averageQuery =
                from score in scores
                select score;

            return averageQuery.Average();
        }

        // AboveAverage : 計算大於平均值的成績數量（無參數版）
        private int AboveAverage(double averageScore)
        {
            return AboveAverage(scoresList, averageScore);
        }

        // 參數化版本：計算傳入清單中大於平均值的數量 (LINQ)
        private int AboveAverage(List<int> scores, double avg)
        {
            if (scores == null || scores.Count == 0)
            {
                return 0;
            }

            var aboveAvgQuery =
                from score in scores
                where score > avg
                select score;

            return aboveAvgQuery.Count();
        }

        // BelowAverage : 計算低於平均值的成績數量（無參數版）
        private int BelowAverage()
        {
            return BelowAverage(scoresList);
        }

        // 參數化版本：計算傳入清單中低於平均值的數量 (LINQ)
        private int BelowAverage(List<int> scores)
        {
            if (scores == null || scores.Count == 0)
            {
                return 0;
            }

            double avg = Average(scores);

            var belowAvgQuery =
                from score in scores
                where score < avg
                select score;

            return belowAvgQuery.Count();
        }

        private void getScoresButton_Click(object sender, EventArgs e)
        {
            double averageScore;    // To hold the average score
            int numAboveAverage;    // Number of above average scores
            int numBelowAverage;    // Number of below average scores

            // Read the scores from the file into the field List.
            ReadScores();

            // Display the scores.
            DisplayScores();

            // Display the average score.
            averageScore = Average();
            averageLabel.Text = averageScore.ToString("n1");

            // Display the number of above average scores.  
            numAboveAverage = AboveAverage(averageScore);
            aboveAverageLabel.Text = numAboveAverage.ToString();

            // Display the number of below average scores.
            numBelowAverage = BelowAverage();
            belowAverageLabel.Text = numBelowAverage.ToString();
        }

        // 搜尋按鈕事件：在 studentRecords 中尋找使用者輸入的成績（使用 LINQ + Enumerable.Range）
        private void searchButton_Click(object sender, EventArgs e)
        {
            if (scoresList == null || scoresList.Count == 0)
            {
                searchResultLabel.Text = "請先按「載入成績」載入資料";
                return;
            }

            // 嘗試將輸入轉為整數
            int searchScore;
            if (!int.TryParse(searchTextBox.Text, out searchScore))
            {
                searchResultLabel.Text = "請輸入有效的整數成績";
                return;
            }

            // 使用 Enumerable.Range 搭配 LINQ 取得所有符合條件的 studentRecords（保留索引對應）
            var searchQuery =
                from index in Enumerable.Range(0, studentRecords.Count)
                where scoresList[index] == searchScore
                select studentRecords[index];

            var foundItems = searchQuery.ToList();

            if (foundItems.Count > 0)
            {
                // 建立輸出字串，包含所有符合的項目
                StringBuilder result = new StringBuilder();
                result.AppendLine($"找到 {foundItems.Count} 筆分數為 {searchScore} 的紀錄：");

                int i = 1;
                foreach (var item in foundItems)
                {
                    result.AppendLine($"{i}. {item}");
                    i++;
                }

                searchResultLabel.Text = result.ToString();
            }
            else
            {
                searchResultLabel.Text = "分數不存在";
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉表單並結束應用程式
            this.Close();
        }

        private void avgScoreDescriptionLabel_Click(object sender, EventArgs e)
        {

        }

        private void belowAvgDescriptionLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
