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
    // 定義 Student 結構體
    public struct Student
    {
        public string ClassName;   // 班級
        public string StudentId;   // 學籍
        public string Name;        // 姓名
        public int[] Scores;       // 成績陣列 (5個成績)

        // 計算平均成績的方法
        public double GetAverage()
        {
            if (Scores == null || Scores.Length == 0)
                return 0;

            int total = 0;
            foreach (int score in Scores)
            {
                total += score;
            }
            return (double)total / Scores.Length;
        }
    }

    public partial class Form1 : Form
    {
        // 全域成績簿 List
        private List<Student> gradeBook = new List<Student>();

        public Form1()
        {
            InitializeComponent();
        }

        private void getScoresButton_Click(object sender, EventArgs e)
        {
            try
            {
                // 清除舊資料
                averagesListBox.Items.Clear();

                // 清空 gradeBook
                gradeBook.Clear();

                char[] delim = { ',' };

                // 讀取 CSV 檔案（使用 UTF-8 編碼，若亂碼可改為 Encoding.Default）
                using (StreamReader inputFile = new StreamReader("Grades.csv", Encoding.UTF8))
                {
                    string line;
                    bool isFirstLine = true;

                    while (!inputFile.EndOfStream)
                    {
                        line = inputFile.ReadLine();

                        // 跳過空白行
                        if (string.IsNullOrWhiteSpace(line))
                            continue;

                        // 如果是第一行且包含標題，跳過標題行（可選）
                        if (isFirstLine && line.Contains("班級") || line.Contains("class"))
                        {
                            isFirstLine = false;
                            continue;
                        }
                        isFirstLine = false;

                        string[] fields = line.Split(delim);

                        // 新格式：班級 - 學籍 - 姓名 - score1 - score2 - score3 - score4 - score5 → 共8個欄位
                        if (fields.Length == 8)
                        {
                            // 建立 Student 物件
                            Student student = new Student();
                            student.ClassName = fields[0].Trim();   // 班級
                            student.StudentId = fields[1].Trim();   // 學籍
                            student.Name = fields[2].Trim();        // 姓名

                            // 讀取5個成績
                            student.Scores = new int[5];
                            bool validData = true;

                            for (int i = 0; i < 5; i++)
                            {
                                if (!int.TryParse(fields[3 + i].Trim(), out student.Scores[i]))
                                {
                                    validData = false;
                                    MessageBox.Show($"成績格式錯誤: {line}");
                                    break;
                                }
                            }

                            if (validData)
                            {
                                // 加入 gradeBook
                                gradeBook.Add(student);

                                // 顯示到 ListBox：班級 學籍 姓名 平均成績
                                double avg = student.GetAverage();
                                averagesListBox.Items.Add($"{student.ClassName} {student.StudentId} {student.Name} {avg:F2}");
                            }
                        }
                        else
                        {
                            MessageBox.Show("資料格式錯誤（需要8個欄位）: " + line);
                        }
                    }
                }

                // 顯示總共讀取幾筆資料
                if (gradeBook.Count > 0)
                {
                    averagesListBox.Items.Insert(0, $"=== 共讀取 {gradeBook.Count} 筆學生資料 ===");
                    averagesListBox.Items.Insert(1, "");
                }
                else
                {
                    averagesListBox.Items.Add("沒有讀取到任何資料");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("讀取 CSV 檔案時發生錯誤: " + ex.Message);
            }
        }

        // 新增：顯示所有學生資料的方法（可選功能）
        private void DisplayAllStudents()
        {
            averagesListBox.Items.Clear();
            foreach (Student student in gradeBook)
            {
                double avg = student.GetAverage();
                averagesListBox.Items.Add($"{student.ClassName} {student.StudentId} {student.Name} {avg:F2}");
            }
        }

        // 新增：依班級篩選的方法（可選功能）
        private void DisplayStudentsByClass(string className)
        {
            averagesListBox.Items.Clear();
            var filtered = gradeBook.Where(s => s.ClassName == className).ToList();

            foreach (Student student in filtered)
            {
                double avg = student.GetAverage();
                averagesListBox.Items.Add($"{student.ClassName} {student.StudentId} {student.Name} {avg:F2}");
            }

            averagesListBox.Items.Insert(0, $"=== {className} 共 {filtered.Count} 人 ===");
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void averagesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 可選：點擊 ListBox 項目時顯示詳細資訊
            if (averagesListBox.SelectedIndex >= 0 && gradeBook.Count > 0)
            {
                int index = averagesListBox.SelectedIndex;
                // 跳過標題行
                if (index < gradeBook.Count + 2 && index >= 2)
                {
                    Student s = gradeBook[index - 2];
                    string scoreStr = string.Join(", ", s.Scores);
                    MessageBox.Show($"學生：{s.Name}\n班級：{s.ClassName}\n學籍：{s.StudentId}\n成績：{scoreStr}\n平均：{s.GetAverage():F2}");
                }
            }
        }
    }
}