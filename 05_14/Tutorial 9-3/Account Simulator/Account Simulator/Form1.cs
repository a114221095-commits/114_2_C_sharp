using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Account_Simulator
{
    public partial class Form1 : Form
    {
        
        private BankAccount account = new BankAccount(20000m);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Display the starting balance.
            balanceDescriptionLabel.Text = account.Balance.ToString("C2");
            UpdateBalanceDisplay();
        }

        private void depositButton_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(depositTextBox.Text, out decimal amount))
            {
                account.Deposit(amount);
                UpdateBalanceDisplay();
                depositTextBox.Clear();
                depositTextBox.Focus();
            }
            else
            {
                MessageBox.Show("請輸入有效的金額。", "輸入錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                depositTextBox.Focus();
            }
        }

        private void withdrawButton_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(withdrawTextBox.Text, out decimal amount))
            {
                account.Withdraw(amount);
                UpdateBalanceDisplay();
                withdrawTextBox.Clear();
                withdrawTextBox.Focus();
            }
            else
            {
                MessageBox.Show("請輸入有效的金額。", "輸入錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                withdrawTextBox.Focus();
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // Close the form.
            this.Close();
        }

        private void UpdateBalanceDisplay()
        {
            balanceLabel.Text = account.Balance.ToString("C2");
        }
    }
}
