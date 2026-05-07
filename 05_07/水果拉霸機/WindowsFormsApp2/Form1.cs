using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace SlotMachine
{
    public partial class Form1 : Form
    {
        // 圖片資源 (10種水果)
        private ImageList imageList1;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;

        // 控制項
        private Label label_depositPrompt;
        private TextBox textBox_deposit;
        private Button button_deposit;
        private Label label_balance;
        private Label label_lastWin;
        private Label label_betPrompt;
        private ComboBox comboBox_bet;
        private Label label_totalSpins;
        private Label label_winCount;
        private Label label_winRate;
        private Button button1;  // 旋轉
        private Button button2;  // 離開

        // 程式狀態變數
        private Random rand;
        private int n1, n2, n3;          // 三個轉輪圖片索引 (0~9)
        private int prize;                // 本次旋轉獎金 (初始 0)
        private int balance;              // 目前餘額 (初始 0)
        private int totalDeposited;       // 累計存入金額 (初始 0)
        private int totalSpins;           // 累計旋轉次數 (初始 0)
        private int winCount;             // 累計中獎次數 (初始 0)

        // 動畫相關變數
        private Timer spinTimer;
        private int spinTick;
        private int lastBet;              // 本次下注金額 (動畫結束後 checkWinner 使用)
        private bool pb1stopped;
        private bool pb2stopped;
        private bool pb3stopped;

        // 預先決定的最終圖片索引 (在開始動畫前決定)
        private int finalN1, finalN2, finalN3;

        // 水果名稱對應索引
        private string[] fruitNames = { "Apple", "Banana", "Cherries", "Grapes", "Lemon", 
                                        "Line", "Orange", "Pear", "Strawberry", "Watermelon" };

        public Form1()
        {
            InitializeComponent();
            LoadImagesFromFolder();  // 從資料夾載入圖片
            LoadGameState();         // 嘗試載入存檔
        }

        private void InitializeComponent()
        {
            this.label_depositPrompt = new Label();
            this.textBox_deposit = new TextBox();
            this.button_deposit = new Button();
            this.label_balance = new Label();
            this.label_lastWin = new Label();
            this.label_betPrompt = new Label();
            this.comboBox_bet = new ComboBox();
            this.label_totalSpins = new Label();
            this.label_winCount = new Label();
            this.label_winRate = new Label();
            this.button1 = new Button();
            this.button2 = new Button();
            this.pictureBox1 = new PictureBox();
            this.pictureBox2 = new PictureBox();
            this.pictureBox3 = new PictureBox();
            this.imageList1 = new ImageList();
            this.spinTimer = new Timer();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();

            // imageList1 設定
            imageList1.ImageSize = new Size(120, 120);
            imageList1.ColorDepth = ColorDepth.Depth32Bit;

            // pictureBox1
            this.pictureBox1.Location = new Point(30, 80);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Size(120, 120);
            this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pictureBox1.BackColor = Color.LightGray;
            this.pictureBox1.BorderStyle = BorderStyle.FixedSingle;

            // pictureBox2
            this.pictureBox2.Location = new Point(170, 80);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new Size(120, 120);
            this.pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pictureBox2.BackColor = Color.LightGray;
            this.pictureBox2.BorderStyle = BorderStyle.FixedSingle;

            // pictureBox3
            this.pictureBox3.Location = new Point(310, 80);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new Size(120, 120);
            this.pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pictureBox3.BackColor = Color.LightGray;
            this.pictureBox3.BorderStyle = BorderStyle.FixedSingle;

            // label_depositPrompt
            this.label_depositPrompt.AutoSize = true;
            this.label_depositPrompt.Location = new Point(30, 20);
            this.label_depositPrompt.Text = "存入金額：$";
            this.label_depositPrompt.Font = new Font("微軟正黑體", 10);

            // textBox_deposit
            this.textBox_deposit.Location = new Point(120, 17);
            this.textBox_deposit.Size = new Size(100, 25);
            this.textBox_deposit.Font = new Font("微軟正黑體", 10);

            // button_deposit
            this.button_deposit.Location = new Point(230, 16);
            this.button_deposit.Size = new Size(60, 28);
            this.button_deposit.Text = "存入";
            this.button_deposit.Font = new Font("微軟正黑體", 10);
            this.button_deposit.Click += new EventHandler(this.button_deposit_Click);

            // label_balance
            this.label_balance.AutoSize = true;
            this.label_balance.Location = new Point(30, 55);
            this.label_balance.Text = "餘額：NT$0.00";
            this.label_balance.Font = new Font("微軟正黑體", 10, FontStyle.Bold);

            // label_lastWin
            this.label_lastWin.AutoSize = true;
            this.label_lastWin.Location = new Point(250, 55);
            this.label_lastWin.Text = "本次獲得：NT$0.00";
            this.label_lastWin.Font = new Font("微軟正黑體", 10, FontStyle.Bold);
            this.label_lastWin.ForeColor = Color.Green;

            // label_betPrompt
            this.label_betPrompt.AutoSize = true;
            this.label_betPrompt.Location = new Point(30, 220);
            this.label_betPrompt.Text = "下注金額：";
            this.label_betPrompt.Font = new Font("微軟正黑體", 10);

            // comboBox_bet (DropDownList)
            this.comboBox_bet.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBox_bet.Items.AddRange(new object[] { "$1", "$5", "$10", "$50" });
            this.comboBox_bet.SelectedIndex = 0;
            this.comboBox_bet.Location = new Point(120, 217);
            this.comboBox_bet.Size = new Size(70, 25);
            this.comboBox_bet.Font = new Font("微軟正黑體", 10);
            this.comboBox_bet.SelectedIndexChanged += new EventHandler(this.comboBox_bet_SelectedIndexChanged);

            // label_totalSpins
            this.label_totalSpins.AutoSize = true;
            this.label_totalSpins.Location = new Point(30, 260);
            this.label_totalSpins.Text = "旋轉：0 次";
            this.label_totalSpins.Font = new Font("微軟正黑體", 10);

            // label_winCount
            this.label_winCount.AutoSize = true;
            this.label_winCount.Location = new Point(30, 290);
            this.label_winCount.Text = "中獎：0 次";
            this.label_winCount.Font = new Font("微軟正黑體", 10);

            // label_winRate
            this.label_winRate.AutoSize = true;
            this.label_winRate.Location = new Point(30, 320);
            this.label_winRate.Text = "勝率：0.0%";
            this.label_winRate.Font = new Font("微軟正黑體", 10);

            // button1 (旋轉)
            this.button1.Location = new Point(310, 260);
            this.button1.Size = new Size(80, 45);
            this.button1.Text = "旋轉";
            this.button1.Font = new Font("微軟正黑體", 12, FontStyle.Bold);
            this.button1.BackColor = Color.LightBlue;
            this.button1.Enabled = false;
            this.button1.Click += new EventHandler(this.button1_Click);

            // button2 (離開)
            this.button2.Location = new Point(310, 315);
            this.button2.Size = new Size(80, 45);
            this.button2.Text = "離開";
            this.button2.Font = new Font("微軟正黑體", 12, FontStyle.Bold);
            this.button2.BackColor = Color.LightCoral;
            this.button2.Click += new EventHandler(this.button2_Click);

            // spinTimer
            this.spinTimer.Interval = 80;
            this.spinTimer.Tick += new EventHandler(this.spinTimer_Tick);

            // Form1
            this.ClientSize = new Size(470, 400);
            this.Controls.Add(this.label_depositPrompt);
            this.Controls.Add(this.textBox_deposit);
            this.Controls.Add(this.button_deposit);
            this.Controls.Add(this.label_balance);
            this.Controls.Add(this.label_lastWin);
            this.Controls.Add(this.label_betPrompt);
            this.Controls.Add(this.comboBox_bet);
            this.Controls.Add(this.label_totalSpins);
            this.Controls.Add(this.label_winCount);
            this.Controls.Add(this.label_winRate);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox3);
            this.Text = "吃角子老虎機";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormClosing += new FormClosingEventHandler(this.Form1_FormClosing);

            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

            // 初始化亂數
            rand = new Random();
            UpdateUI();
        }

        /// <summary>
        /// 從 images 資料夾載入 BMP 圖片
        /// 圖片檔名對應：
        /// 索引 0: Apple.bmp
        /// 索引 1: Banana.bmp
        /// 索引 2: Cherries.bmp
        /// 索引 3: Grapes.bmp
        /// 索引 4: Lemon.bmp
        /// 索引 5: Line.bmp
        /// 索引 6: Orange.bmp
        /// 索引 7: Pear.bmp
        /// 索引 8: Strawberry.bmp
        /// 索引 9: Watermelon.bmp
        /// </summary>
        private void LoadImagesFromFolder()
        {
            string imagesFolder = Path.Combine(Application.StartupPath, "images");
            
            // 如果 images 資料夾不存在，建立它
            if (!Directory.Exists(imagesFolder))
            {
                Directory.CreateDirectory(imagesFolder);
                MessageBox.Show($"請將您的 BMP 圖片放入以下資料夾：\n{imagesFolder}\n\n需要的檔案名稱：\n" +
                    "Apple.bmp, Banana.bmp, Cherries.bmp, Grapes.bmp, Lemon.bmp,\n" +
                    "Line.bmp, Orange.bmp, Pear.bmp, Strawberry.bmp, Watermelon.bmp",
                    "圖片放置提醒", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // 載入圖片 (依照水果名稱對應索引)
            int loadedCount = 0;
            for (int i = 0; i < fruitNames.Length; i++)
            {
                string bmpPath = Path.Combine(imagesFolder, $"{fruitNames[i]}.bmp");
                Image img = null;
                
                if (File.Exists(bmpPath))
                {
                    try
                    {
                        img = Image.FromFile(bmpPath);
                        // 調整圖片大小為 120x120
                        Bitmap resizedImg = new Bitmap(img, new Size(120, 120));
                        imageList1.Images.Add(resizedImg);
                        img.Dispose();
                        loadedCount++;
                    }
                    catch (Exception ex)
                    {
                        // 圖片載入失敗，使用預設圖示
                        Console.WriteLine($"載入 {fruitNames[i]}.bmp 失敗: {ex.Message}");
                        imageList1.Images.Add(CreateDefaultFruitImage(i));
                    }
                }
                else
                {
                    // 找不到圖片，使用預設圖示
                    imageList1.Images.Add(CreateDefaultFruitImage(i));
                }
            }

            // 顯示載入結果
            if (loadedCount > 0)
            {
                Console.WriteLine($"成功載入 {loadedCount} 張圖片");
            }
            else
            {
                MessageBox.Show($"找不到 BMP 圖片！\n請將您的圖片放入：\n{imagesFolder}\n\n需要的檔案：\n" +
                    "Apple.bmp, Banana.bmp, Cherries.bmp, Grapes.bmp, Lemon.bmp,\n" +
                    "Line.bmp, Orange.bmp, Pear.bmp, Strawberry.bmp, Watermelon.bmp",
                    "找不到圖片", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
            // 設定預設顯示
            pictureBox1.Image = imageList1.Images[0];
            pictureBox2.Image = imageList1.Images[0];
            pictureBox3.Image = imageList1.Images[0];
        }

        /// <summary>
        /// 建立預設的水果圖片（當找不到圖片檔時使用）
        /// </summary>
        private Image CreateDefaultFruitImage(int index)
        {
            string[] displayNames = { "🍎 Apple", "🍌 Banana", "🍒 Cherries", "🍇 Grapes", "🍋 Lemon", 
                                      "🍋 Line", "🍊 Orange", "🍐 Pear", "🍓 Strawberry", "🍉 Watermelon" };
            Color[] colors = { Color.Red, Color.Gold, Color.DarkRed, Color.Purple, Color.YellowGreen,
                               Color.LightGreen, Color.Orange, Color.YellowGreen, Color.HotPink, Color.Green };
            
            Bitmap bmp = new Bitmap(120, 120);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(colors[index]);
                using (Font font = new Font("Segoe UI", 12, FontStyle.Bold))
                {
                    StringFormat sf = new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    };
                    g.DrawString(displayNames[index], font, Brushes.White, new RectangleF(0, 0, 120, 120), sf);
                }
            }
            return bmp;
        }

        // 更新餘額與按鈕狀態
        private void UpdateUI()
        {
            label_balance.Text = $"餘額：NT${balance}.00";
            label_lastWin.Text = $"本次獲得：NT${prize}.00";
            // 旋轉按鈕啟用條件：餘額 >= 下注金額 且 不在動畫中
            int bet = GetCurrentBet();
            button1.Enabled = (balance >= bet) && !spinTimer.Enabled;
        }

        // 更新統計標籤
        private void UpdateStats()
        {
            label_totalSpins.Text = $"旋轉：{totalSpins} 次";
            label_winCount.Text = $"中獎：{winCount} 次";
            double winRate = (totalSpins == 0) ? 0.0 : (double)winCount / totalSpins * 100.0;
            label_winRate.Text = $"勝率：{winRate:F1}%";
        }

        // 取得目前下注金額 (整數)
        private int GetCurrentBet()
        {
            string selected = comboBox_bet.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selected)) return 1;
            return int.Parse(selected.TrimStart('$'));
        }

        // 存入按鈕
        private void button_deposit_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox_deposit.Text, out int amount) || amount <= 0)
            {
                MessageBox.Show("請輸入有效的存入金額（必須為正整數）", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            balance += amount;
            totalDeposited += amount;
            textBox_deposit.Clear();
            UpdateUI();
            SaveGameState();
        }

        // 下注選項變更
        private void comboBox_bet_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateUI();
        }

        // 旋轉按鈕
        private void button1_Click(object sender, EventArgs e)
        {
            int bet = GetCurrentBet();
            if (balance < bet)
            {
                MessageBox.Show("餘額不足，請先存入金額。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            balance -= bet;
            lastBet = bet;
            prize = 0;

            finalN1 = rand.Next(10);
            finalN2 = rand.Next(10);
            finalN3 = rand.Next(10);

            spinTick = 0;
            pb1stopped = false;
            pb2stopped = false;
            pb3stopped = false;

            UpdateUI();
            spinTimer.Start();
        }

        // 動畫計時器 Tick
        private void spinTimer_Tick(object sender, EventArgs e)
        {
            spinTick++;

            if (!pb1stopped && spinTick >= 10)
            {
                pb1stopped = true;
                pictureBox1.Image = imageList1.Images[finalN1];
                n1 = finalN1;
            }

            if (!pb2stopped && spinTick >= 17)
            {
                pb2stopped = true;
                pictureBox2.Image = imageList1.Images[finalN2];
                n2 = finalN2;
            }

            if (!pb3stopped && spinTick >= 24)
            {
                pb3stopped = true;
                pictureBox3.Image = imageList1.Images[finalN3];
                n3 = finalN3;
            }

            if (!pb1stopped)
            {
                int randIdx = rand.Next(10);
                pictureBox1.Image = imageList1.Images[randIdx];
            }
            if (!pb2stopped)
            {
                int randIdx = rand.Next(10);
                pictureBox2.Image = imageList1.Images[randIdx];
            }
            if (!pb3stopped)
            {
                int randIdx = rand.Next(10);
                pictureBox3.Image = imageList1.Images[randIdx];
            }

            if (pb1stopped && pb2stopped && pb3stopped)
            {
                spinTimer.Stop();
                CheckWinner();
                totalSpins++;
                if (prize > 0) winCount++;
                UpdateStats();
                balance += prize;
                UpdateUI();
                SaveGameState();
            }
        }

        // 勝負判斷
        private void CheckWinner()
        {
            if (n1 == n2 && n2 == n3)
            {
                prize = lastBet * 10;
                label_lastWin.Text = $"本次獲得：NT${prize}.00";
                label_lastWin.ForeColor = Color.Red;
                return;
            }

            if (n1 == n2 || n1 == n3 || n2 == n3)
            {
                prize = lastBet * 2;
                label_lastWin.Text = $"本次獲得：NT${prize}.00";
                label_lastWin.ForeColor = Color.Blue;
                return;
            }

            prize = 0;
            label_lastWin.Text = $"本次獲得：NT$0.00";
            label_lastWin.ForeColor = Color.Gray;
        }

        // 離開按鈕
        private void button2_Click(object sender, EventArgs e)
        {
            int netGain = balance - totalDeposited;
            MessageBox.Show($"累計存入：NT${totalDeposited}.00\n目前餘額：NT${balance}.00\n淨損益：NT${netGain}.00", 
                "遊戲結算", MessageBoxButtons.OK, MessageBoxIcon.Information);
            SaveGameState();
            this.Close();
        }

        // 儲存遊戲狀態
        private void SaveGameState()
        {
            string filePath = Path.Combine(Application.StartupPath, "savegame.txt");
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"balance={balance}");
            sb.AppendLine($"totalDeposited={totalDeposited}");
            sb.AppendLine($"totalSpins={totalSpins}");
            sb.AppendLine($"winCount={winCount}");
            try
            {
                File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);
            }
            catch (Exception ex)
            {
                Console.WriteLine("儲存失敗: " + ex.Message);
            }
        }

        // 載入遊戲狀態
        private void LoadGameState()
        {
            string filePath = Path.Combine(Application.StartupPath, "savegame.txt");
            if (!File.Exists(filePath)) return;

            try
            {
                string[] lines = File.ReadAllLines(filePath, Encoding.UTF8);
                foreach (string line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    string[] parts = line.Split('=');
                    if (parts.Length != 2) continue;
                    string key = parts[0].Trim();
                    if (int.TryParse(parts[1].Trim(), out int value))
                    {
                        switch (key)
                        {
                            case "balance": balance = value; break;
                            case "totalDeposited": totalDeposited = value; break;
                            case "totalSpins": totalSpins = value; break;
                            case "winCount": winCount = value; break;
                        }
                    }
                }
                UpdateUI();
                UpdateStats();
            }
            catch (Exception ex)
            {
                Console.WriteLine("載入失敗: " + ex.Message);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveGameState();
        }
    }
}
