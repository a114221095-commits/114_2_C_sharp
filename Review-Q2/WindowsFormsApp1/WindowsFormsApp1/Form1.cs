using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        // 常數價格
        private const decimal OIL_CHANGE = 780m;
        private const decimal LUBE_JOB = 540m;
        private const decimal RADIATOR_FLUSH = 900m;
        private const decimal TRANSMISSION_FLUSH = 2400m;
        private const decimal INSPECTION = 450m;
        private const decimal MUFFLER_REPLACEMENT = 3000m;
        private const decimal TIRE_ROTATION = 600m;
        private const decimal LABOR_RATE_PER_HOUR = 600m;
        private const decimal PARTS_TAX_RATE = 0.06m;

        // 計算結果暫存
        private decimal serviceAndLaborTotal = 0m;
        private decimal partsCost = 0m;
        private decimal taxAmount = 0m;
        private decimal grandTotal = 0m;

        private readonly CultureInfo taiwan = new CultureInfo("zh-TW");

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ClearAll();
        }

        #region 費用計算方法

        private decimal OilLubeCharges()
        {
            decimal total = 0m;
            if (cbOilChange.Checked) total += OIL_CHANGE;
            if (cbLubeJob.Checked) total += LUBE_JOB;
            return total;
        }

        private decimal FlushCharges()
        {
            decimal total = 0m;
            if (cbRadiatorFlush.Checked) total += RADIATOR_FLUSH;
            if (cbTransmissionFlush.Checked) total += TRANSMISSION_FLUSH;
            return total;
        }

        private decimal MiscCharges()
        {
            decimal total = 0m;
            if (cbInspection.Checked) total += INSPECTION;
            if (cbReplaceMuffler.Checked) total += MUFFLER_REPLACEMENT;
            if (cbTireRotation.Checked) total += TIRE_ROTATION;
            return total;
        }

        private decimal OtherCharges(out decimal laborCost, out decimal parts)
        {
            laborCost = 0m;
            parts = 0m;

            // 解析零件費用
            if (!string.IsNullOrWhiteSpace(txtParts.Text))
            {
                decimal p;
                if (decimal.TryParse(txtParts.Text, out p) && p >= 0m)
                {
                    parts = p;
                }
                else
                {
                    MessageBox.Show("零件費用輸入錯誤，請輸入非負數字。", "輸入錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtParts.Focus();
                    return 0m;
                }
            }

            // 解析工時
            if (!string.IsNullOrWhiteSpace(txtLabor.Text))
            {
                decimal hours;
                if (decimal.TryParse(txtLabor.Text, out hours) && hours >= 0m)
                {
                    laborCost = hours * LABOR_RATE_PER_HOUR;
                }
                else
                {
                    MessageBox.Show("工時輸入錯誤，請輸入非負數字。", "輸入錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtLabor.Focus();
                    return 0m;
                }
            }

            return laborCost;
        }

        private decimal TaxCharges(decimal parts)
        {
            return Math.Round(parts * PARTS_TAX_RATE, 2);
        }

        private void TotalCharges()
        {
            decimal oilLube = OilLubeCharges();
            decimal flush = FlushCharges();
            decimal misc = MiscCharges();
            decimal labor;
            decimal parts;
            OtherCharges(out labor, out parts); // 設定 out 變數

            serviceAndLaborTotal = oilLube + flush + misc + labor;
            partsCost = parts;
            taxAmount = TaxCharges(partsCost);
            grandTotal = serviceAndLaborTotal + partsCost + taxAmount;

            // 顯示
            txtServiceLabor.Text = serviceAndLaborTotal.ToString("C0", taiwan);
            txtPartsCost.Text = partsCost.ToString("C0", taiwan);
            txtTax.Text = taxAmount.ToString("C0", taiwan);
            txtTotal.Text = grandTotal.ToString("C0", taiwan);
        }

        #endregion

        #region 事件處理

        private void calculateButton_Click(object sender, EventArgs e)
        {
            TotalCharges();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否清除所有輸入與結果？", "確認清除", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ClearAll();
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = MessageBox.Show("離開前是否要儲存本次維修明細？", "儲存明細", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Cancel)
            {
                e.Cancel = true;
                return;
            }
            if (result == DialogResult.Yes)
            {
                bool saved = SaveServiceDetailsToFile();
                if (!saved)
                {
                    // 若儲存失敗則中止關閉（給使用者機會修正）
                    e.Cancel = true;
                }
            }
        }

        #endregion

        #region 清除方法

        private void ClearOilLube()
        {
            cbOilChange.Checked = false;
            cbLubeJob.Checked = false;
        }

        private void ClearFlushes()
        {
            cbRadiatorFlush.Checked = false;
            cbTransmissionFlush.Checked = false;
        }

        private void ClearMisc()
        {
            cbInspection.Checked = false;
            cbReplaceMuffler.Checked = false;
            cbTireRotation.Checked = false;
        }

        private void ClearOther()
        {
            txtParts.Text = string.Empty;
            txtLabor.Text = string.Empty;
        }

        private void ClearFees()
        {
            txtServiceLabor.Text = string.Empty;
            txtPartsCost.Text = string.Empty;
            txtTax.Text = string.Empty;
            txtTotal.Text = string.Empty;
        }

        private void ClearAll()
        {
            ClearOilLube();
            ClearFlushes();
            ClearMisc();
            ClearOther();
            ClearFees();

            serviceAndLaborTotal = partsCost = taxAmount = grandTotal = 0m;
        }

        #endregion

        #region 檔案輸出

        private bool SaveServiceDetailsToFile()
        {
            // 確保最新計算
            TotalCharges();

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "文字檔 (*.txt)|*.txt|所有檔案 (*.*)|*.*";
                sfd.FileName = $"維修明細_{DateTime.Now:yyyyMMdd_HHmmss}.txt";
                if (sfd.ShowDialog() != DialogResult.OK) return true; // 使用者選擇取消視為成功（不阻止關閉）

                StreamWriter writer = null;
                try
                {
                    writer = new StreamWriter(sfd.FileName, false, new UTF8Encoding(false));

                    writer.WriteLine("汽車維修服務 - 明細報表");
                    writer.WriteLine("產生時間: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    writer.WriteLine(new string('-', 50));
                    writer.WriteLine("服務項目：");

                    if (cbOilChange.Checked) writer.WriteLine($"  - 更換機油：{OIL_CHANGE.ToString("C0", taiwan)}");
                    if (cbLubeJob.Checked) writer.WriteLine($"  - 潤滑保養：{LUBE_JOB.ToString("C0", taiwan)}");
                    if (cbRadiatorFlush.Checked) writer.WriteLine($"  - 水箱清洗：{RADIATOR_FLUSH.ToString("C0", taiwan)}");
                    if (cbTransmissionFlush.Checked) writer.WriteLine($"  - 變速箱清洗：{TRANSMISSION_FLUSH.ToString("C0", taiwan)}");
                    if (cbInspection.Checked) writer.WriteLine($"  - 檢驗：{INSPECTION.ToString("C0", taiwan)}");
                    if (cbReplaceMuffler.Checked) writer.WriteLine($"  - 更換消音器：{MUFFLER_REPLACEMENT.ToString("C0", taiwan)}");
                    if (cbTireRotation.Checked) writer.WriteLine($"  - 輪胎換位：{TIRE_ROTATION.ToString("C0", taiwan)}");

                    writer.WriteLine();
                    writer.WriteLine("零件與工時：");
                    writer.WriteLine($"  零件費用: {partsCost.ToString("C0", taiwan)}");
                    decimal laborHours = 0m;
                    decimal.TryParse(txtLabor.Text, out laborHours);
                    writer.WriteLine($"  工時(小時): {txtLabor.Text}  (費率 {LABOR_RATE_PER_HOUR.ToString("C0", taiwan)}/小時)");
                    writer.WriteLine($"  工時費用: {(laborHours * LABOR_RATE_PER_HOUR).ToString("C0", taiwan)}");

                    writer.WriteLine();
                    writer.WriteLine("費用明細：");
                    writer.WriteLine($"  服務與工資總額: {serviceAndLaborTotal.ToString("C0", taiwan)}");
                    writer.WriteLine($"  零件: {partsCost.ToString("C0", taiwan)}");
                    writer.WriteLine($"  稅金(零件 6%): {taxAmount.ToString("C0", taiwan)}");
                    writer.WriteLine($"  總費用: {grandTotal.ToString("C0", taiwan)}");

                    writer.WriteLine(new string('-', 50));
                    writer.WriteLine("感謝您使用本系統。");

                    MessageBox.Show("已成功儲存維修明細。", "儲存完成", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("儲存失敗：" + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                finally
                {
                    if (writer != null) writer.Close();
                }
            }
        }

        #endregion
    }
}
