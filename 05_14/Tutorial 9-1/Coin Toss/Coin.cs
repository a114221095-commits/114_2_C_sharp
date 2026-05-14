Coin Toss\Coin.cs
using System;

namespace Coin_Toss
{
    public class Coin
    {
        private static readonly Random rng = new Random();
        private string sideUp;

        public Coin()
        {
            sideUp= "Heads";
        }

        public string SideUp
        {
            get { return sideUp; }
        }

        public void Toss()
        {
            Random random = new Random();
            int side = rand.Next(2); // 0 or 1
            if(side == 0) {
                sideUp = "Heads";
            } else {
                sideUp = "Tails";
            }

        public string GetSideUp()
        {
            return sideUp;
        }
    }

   