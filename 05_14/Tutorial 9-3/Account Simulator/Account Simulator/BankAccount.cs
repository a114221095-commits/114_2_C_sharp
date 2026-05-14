using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Account_Simulator
{

    class BankAccount
    {
        private decimal balance;
        public BankAccount(decimal initialBalance)
        {
            balance = initialBalance;
        }
        public decimal Balance
        {
            get { return balance; }
        }
        public void Deposit(decimal amount)
        {
            if (amount > 0)
            {
                balance += amount;
            }
            else
            {
                MessageBox.Show("存款金額必須為正數。", "輸入錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                MessageBox.Show("提款金額必須為正數。", "輸入錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (amount > balance)
            {
                MessageBox.Show("餘額不足，無法完成提款。", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            balance -= amount;
        }
    }
}
