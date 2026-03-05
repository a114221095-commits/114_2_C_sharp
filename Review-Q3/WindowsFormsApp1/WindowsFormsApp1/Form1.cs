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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private const int NumberCount = 5;
        private const int MinNumber = 1;
        private const int MaxNumber = 49;

        private readonly Label[] lblNumbers = new Label[NumberCount];
        private readonly Button btnGenerate = new Button();
        private readonly Button btnLoadWinning = new Button();
        private readonly Button btnExit = new Button();
        private readonly ListBox lstWinning = new ListBox();
        private readonly Label lblResultTitle = new Label();
        private readonly Label lblResultCount = new Label();
        private readonly Label lblPrize = new Label();

        private readonly Random rnd = new Random();
        private int[] currentNumbers = null;     // 使用者產生的號碼
        private int[] winningNumbers = null;     // 從檔案讀取的開獎號碼

        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            Text = "樂透號碼產生器";
            ClientSize = new Size(620, 360);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;

            var bigFont = new Font("微軟正黑體", 18f, FontStyle.Regular);

            // 建立顯示號碼的 Label 陣列
            for (int i = 0; i < NumberCount; i++)
            {
                var lbl = new Label
                {
                    Size = new Size(90, 60),
                    Location = new Point(20 + i * 110, 20),
                    BorderStyle = BorderStyle.FixedSingle,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = bigFont,
                    Text = string.Empty
                };
                lblNumbers[i] = lbl;
                Controls.Add(lbl);
            }

            // 產生號碼按鈕
            btnGenerate.Text = "產生號碼";
            btnGenerate.Font = new Font("微軟正黑體", 12f);
            btnGenerate.Size = new Size(160, 48);
            btnGenerate.Location = new Point(20, 100);
            btnGenerate.Click += BtnGenerate_Click;
            Controls.Add(btnGenerate);

            // 開獎號碼按鈕
            btnLoadWinning.Text = "開獎號碼";
            btnLoadWinning.Font = new Font("微軟正黑體", 12f);
            btnLoadWinning.Size = new Size(160, 48);
            btnLoadWinning.Location = new Point(200, 100);
            btnLoadWinning.Click += BtnLoadWinning_Click;
            Controls.Add(btnLoadWinning);

            // 離開按鈕
            btnExit.Text = "離開";
            btnExit.Font = new Font("微軟正黑體", 12f);
            btnExit.Size = new Size(160, 48);
            btnExit.Location = new Point(380, 100);
            btnExit.Click += BtnExit_Click;
            Controls.Add(btnExit);

            // ListBox 顯示開獎號碼
            lstWinning.Font = new Font("微軟正黑體", 12f);
            lstWinning.Size = new Size(300, 140);
            lstWinning.Location = new Point(20, 170);
            Controls.Add(lstWinning);

            // 比對結果顯示（標題）
            lblResultTitle.Text = "比對結果：";
            lblResultTitle.Font = new Font("微軟正黑體", 14f, FontStyle.Bold);
            lblResultTitle.ForeColor = Color.DarkRed;
            lblResultTitle.Location = new Point(340, 170);
            lblResultTitle.Size = new Size(260, 30);
            Controls.Add(lblResultTitle);

            // 中獎數量顯示
            lblResultCount.Text = "中 0 個號碼";
            lblResultCount.Font = new Font("微軟正黑體", 14f);
            lblResultCount.Location = new Point(340, 210);
            lblResultCount.Size = new Size(260, 30);
            Controls.Add(lblResultCount);

            // 獎項顯示
            lblPrize.Text = "未比對";
            lblPrize.Font = new Font("微軟正黑體", 16f, FontStyle.Bold);
            lblPrize.ForeColor = Color.Black;
            lblPrize.Location = new Point(340, 250);
            lblPrize.Size = new Size(260, 60);
            Controls.Add(lblPrize);

            // 預設狀態
            UpdateUiState();
        }

        private void BtnGenerate_Click(object sender, EventArgs e)
        {
            currentNumbers = GenerateUniqueRandomNumbers(NumberCount, MinNumber, MaxNumber);
            Array.Sort(currentNumbers);
            DisplayCurrentNumbers();
            UpdateUiState();

            // 若已經有開獎號碼，立即比對
            if (winningNumbers != null)
            {
                CompareAndShowResult();
            }
        }

        private void BtnLoadWinning_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "文字檔 (*.txt)|*.txt|所有檔案 (*.*)|*.*";
                ofd.Title = "選擇開獎號碼檔案";
                if (ofd.ShowDialog() != DialogResult.OK) return;

                try
                {
                    var lines = File.ReadAllLines(ofd.FileName, Encoding.UTF8);
                    if (lines.Length < NumberCount)
                    {
                        MessageBox.Show($"檔案必須包含至少 {NumberCount} 行數字 (每行一個數字)。", "檔案格式錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    int[] parsed = new int[NumberCount];
                    for (int i = 0; i < NumberCount; i++)
                    {
                        var line = lines[i].Trim();
                        if (!int.TryParse(line, out int v))
                        {
                            MessageBox.Show($"第 {i + 1} 行不是有效整數：\"{line}\"。", "格式錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        if (v < MinNumber || v > MaxNumber)
                        {
                            MessageBox.Show($"第 {i + 1} 行數字超出範圍 (應為 {MinNumber} 到 {MaxNumber})：{v}", "數值錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        parsed[i] = v;
                    }

                    // 檢查檔案內是否有重複號碼（可視需求決定是否允許）
                    for (int i = 0; i < NumberCount; i++)
                    {
                        for (int j = i + 1; j < NumberCount; j++)
                        {
                            if (parsed[i] == parsed[j])
                            {
                                MessageBox.Show($"檔案中發現重複號碼：{parsed[i]}，請檢查檔案。", "格式錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                    }

                    winningNumbers = parsed;
                    Array.Sort(winningNumbers);
                    DisplayWinningNumbers();
                    UpdateUiState();

                    if (currentNumbers != null)
                    {
                        CompareAndShowResult();
                    }
                }
                catch (FileNotFoundException)
                {
                    MessageBox.Show("檔案不存在。", "檔案錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (IOException ex)
                {
                    MessageBox.Show("讀取檔案時發生錯誤：" + ex.Message, "IO 錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("處理檔案時發生未預期的錯誤：" + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        // 使用基本迴圈與陣列產生不重複亂數（避免使用 Linq 或集合）
        private int[] GenerateUniqueRandomNumbers(int count, int minInclusive, int maxInclusive)
        {
            var results = new int[count];
            int generated = 0;

            while (generated < count)
            {
                int candidate = rnd.Next(minInclusive, maxInclusive + 1);

                // 檢查是否與已生成重複
                bool exists = false;
                for (int i = 0; i < generated; i++)
                {
                    if (results[i] == candidate)
                    {
                        exists = true;
                        break;
                    }
                }

                if (!exists)
                {
                    results[generated] = candidate;
                    generated++;
                }
                // 若重複，繼續下一次迴圈產生新的 candidate
            }

            return results;
        }

        private void DisplayCurrentNumbers()
        {
            if (currentNumbers == null) return;
            for (int i = 0; i < NumberCount; i++)
            {
                lblNumbers[i].Text = currentNumbers[i].ToString();
            }
        }

        private void DisplayWinningNumbers()
        {
            lstWinning.Items.Clear();
            if (winningNumbers == null) return;
            for (int i = 0; i < NumberCount; i++)
            {
                lstWinning.Items.Add($"第 {i + 1} 個號碼: {winningNumbers[i]}");
            }
        }

        private void CompareAndShowResult()
        {
            if (currentNumbers == null || winningNumbers == null) return;

            int matchCount = 0;
            // 比對使用基本迴圈與陣列
            for (int i = 0; i < currentNumbers.Length; i++)
            {
                for (int j = 0; j < winningNumbers.Length; j++)
                {
                    if (currentNumbers[i] == winningNumbers[j])
                    {
                        matchCount++;
                        break;
                    }
                }
            }

            lblResultCount.Text = $"中 {matchCount} 個號碼";

            // 簡單獎項判定（可依實作需求調整）
            switch (matchCount)
            {
                case 5:
                    lblPrize.Text = "恭喜，中頭獎！";
                    lblPrize.ForeColor = Color.DarkGreen;
                    break;
                case 4:
                    lblPrize.Text = "中 2 獎（四碼）";
                    lblPrize.ForeColor = Color.Blue;
                    break;
                case 3:
                    lblPrize.Text = "中 3 獎（三碼）";
                    lblPrize.ForeColor = Color.Orange;
                    break;
                case 2:
                case 1:
                    lblPrize.Text = "未達獎項門檻";
                    lblPrize.ForeColor = Color.DarkRed;
                    break;
                default:
                    lblPrize.Text = "沒中獎";
                    lblPrize.ForeColor = Color.DarkRed;
                    break;
            }
        }

        private void UpdateUiState()
        {
            // 按鈕與顯示狀態管理：產生號碼與讀檔皆可獨立使用；若兩者都存在則自動比對
            btnGenerate.Enabled = true;
            btnLoadWinning.Enabled = true;
            btnExit.Enabled = true;

            lblResultCount.Text = currentNumbers == null ? "尚未產生號碼" : lblResultCount.Text;
            lblPrize.Text = (currentNumbers == null && winningNumbers == null) ? "未比對" : lblPrize.Text;
        }
    }
}
