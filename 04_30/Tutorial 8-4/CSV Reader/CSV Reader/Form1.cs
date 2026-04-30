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
using System.Diagnostics;

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
            try
            {
                StreamReader inputFile;
                char[] delim = { ',' };
                // 清除舊資料
                averagesListBox.Items.Clear();

                using (inputFile = File.OpenText("Grades.csv"))
                {
                    string line;
                    while (!inputFile.EndOfStream)
                    {
                        line = inputFile.ReadLine();

                        string[] fields = line.Split(delim);
                        // 新格式：班级 - 学籍 - 姓名 - score1 - score2 - score3 - score4 - score5 → 共8个字段
                        if (fields.Length == 8)
                        {
                            string className = fields[0];   // 班级
                            string studentId = fields[1];   // 学籍
                            string name = fields[2];        // 姓名

                            int total = 0;
                            // 计算后5个成绩（fields[3] 到 fields[7]）
                            for (int i = 3; i < fields.Length; i++)
                            {
                                total += int.Parse(fields[i]);
                            }
                            double average = (double)total / 5;  // 5个成绩

                            // 输出格式：班级 学籍 姓名 平均成绩
                            averagesListBox.Items.Add($"{className} {studentId} {name} {average:F2}");
                        }
                        else
                        {
                            MessageBox.Show("資料格式錯誤: " + line);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("讀取 CSV 檔案時發生錯誤: " + ex.Message);
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // Close the form.
            this.Close();
        }

        private void averagesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
