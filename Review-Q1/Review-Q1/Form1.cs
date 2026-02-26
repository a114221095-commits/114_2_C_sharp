    using System;
using System.Drawing;
using System.Windows.Forms;

namespace Review_Q1
{
    public partial class Form1 : Form
    {
        private enum Move { None, Rock, Paper, Scissors }

        private readonly Random _rnd = new Random();
        private Move _computerMove = Move.None;
        private Move _playerMove = Move.None;

        public Form1()
        {
            InitializeComponent();
        }

        private void PlayMove(Move player)
        {
            _playerMove = player;
            _computerMove = (Move)_rnd.Next(1, 4); // 1..3
            UpdateResult();
            picPlayer.Invalidate();
            picComputer.Invalidate();
        }

        private void UpdateResult()
        {
            if (_playerMove == Move.None || _computerMove == Move.None)
            {
                txtResult.Text = "";
                return;
            }

            if (_playerMove == _computerMove)
            {
                txtResult.Text = "平手";
                return;
            }

            bool playerWins =
                (_playerMove == Move.Rock && _computerMove == Move.Scissors) ||
                (_playerMove == Move.Paper && _computerMove == Move.Rock) ||
                (_playerMove == Move.Scissors && _computerMove == Move.Paper);

            if (playerWins)
            {
                txtResult.Text = "玩家獲勝！";
            }
            else
            {
                txtResult.Text = "電腦獲勝！";
            }
        }

        private string MoveToText(Move m)
        {
            return m switch
            {
                Move.Rock => "石頭",
                Move.Paper => "布",
                Move.Scissors => "剪刀",
                _ => ""
            };
        }

        private void btnRock_Click(object sender, EventArgs e)
        {
            PlayMove(Move.Rock);
        }

        private void btnPaper_Click(object sender, EventArgs e)
        {
            PlayMove(Move.Paper);
        }

        private void btnScissors_Click(object sender, EventArgs e)
        {
            PlayMove(Move.Scissors);
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            btnRock.Enabled = false;
            btnPaper.Enabled = false;
            btnScissors.Enabled = false;
            txtResult.Text = "遊戲已結束";
        }

        private void picPlayer_Paint(object sender, PaintEventArgs e)
        {
            DrawMoveInBox(e.Graphics, picPlayer.ClientRectangle, MoveToText(_playerMove));
        }

        private void picComputer_Paint(object sender, PaintEventArgs e)
        {
            DrawMoveInBox(e.Graphics, picComputer.ClientRectangle, MoveToText(_computerMove));
        }

        private void DrawMoveInBox(Graphics g, Rectangle rect, string text)
        {
            g.Clear(picPlayer.BackColor);
            using (var sf = new StringFormat())
            using (var brush = new SolidBrush(Color.Black))
            {
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;
                using (var font = new Font("微軟正黑體", 14f, FontStyle.Bold))
                {
                    g.DrawString(string.IsNullOrEmpty(text) ? "" : text, font, brush, rect, sf);
                }
            }
        }
    }
}
