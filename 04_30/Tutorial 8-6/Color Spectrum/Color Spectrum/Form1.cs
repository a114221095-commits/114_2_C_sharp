using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Color_Spectrum
{
    // 顏色列舉
    enum Spectrum
    {
        Red = 10,
        Orange = 20,
        Yellow = 30,
        Green = 40,
        Blue = 50,
        Indigo = 60,
        Violet = 70
    }

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // 顯示顏色的方法
        private void DisplayColor(Spectrum color)
        {
            colorLabel.Text = ((int)color).ToString() + " : " + color.ToString();
        }

        // 紅色點擊事件
        private void redLabel_Click(object sender, EventArgs e)
        {
            DisplayColor(Spectrum.Red);
        }

        // 橙色點擊事件
        private void orangeLabel_Click(object sender, EventArgs e)
        {
            DisplayColor(Spectrum.Orange);
        }

        // 黃色點擊事件
        private void yellowLabel_Click(object sender, EventArgs e)
        {
            DisplayColor(Spectrum.Yellow);
        }

        // 綠色點擊事件
        private void greenLabel_Click(object sender, EventArgs e)
        {
            DisplayColor(Spectrum.Green);
        }

        // 藍色點擊事件
        private void blueLabel_Click(object sender, EventArgs e)
        {
            DisplayColor(Spectrum.Blue);
        }

        // 靛色點擊事件
        private void indigoLabel_Click(object sender, EventArgs e)
        {
            DisplayColor(Spectrum.Indigo);
        }

        // 紫色點擊事件
        private void violetLabel_Click(object sender, EventArgs e)
        {
            DisplayColor(Spectrum.Violet);
        }
    }
}
