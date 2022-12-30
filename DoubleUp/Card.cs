using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleUp
{
    internal class Card
    {
        public int rank { get; set; }
        public bool fliped { get; set; }

        public Card(int rank)
        {
            this.rank = rank;
            this.fliped = false;
        }

        public String MapToRank()
        {
            switch (rank)
            {
                case 1:
                    return "2";
                case 2:
                    return "3";
                case 3:
                    return "4";
                case 4:
                    return "5";
                case 5:
                    return "6";
                case 6:
                    return "7";
                case 7:
                    return "8";
                case 8:
                    return "9";
                case 9:
                    return "J";
                case 10:
                    return "Q";
                case 11:
                    return "K";
                case 12:
                    return "A";
                default:
                    throw new ArgumentException("invalid arg");
            }
        }
    }
}
