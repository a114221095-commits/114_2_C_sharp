using SlotMachine;
using System;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());  // ← 這行很重要！
        }
    }
}