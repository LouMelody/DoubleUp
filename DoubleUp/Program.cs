using System;
using System.Linq;
namespace DoubleUp
{
    internal class Program
    {
        static Card[] flops;
        static int position = 2;
        static void Main(string[] args)
        {
            Random rnd = new Random();
            bool firstPick = true;
            int picked = 0;
            flops = Enumerable.Range(0, 5).Select(_ => new Card(rnd.Next(1, 13))).ToArray();

            Util.ShowFlops(flops);

            Console.WriteLine("    ^     ");
            Console.WriteLine("めくるカードを選んでください。　(←/→: 移動, Enter: 決定)");

            Console.CursorVisible = false;

            ConsoleKeyInfo info = Console.ReadKey(true);
            while(info.Key != ConsoleKey.C)
            {
                if(info.Key == ConsoleKey.RightArrow) 
                {
                    OverrideCursor(true);
                }
                else if(info.Key == ConsoleKey.LeftArrow) 
                {
                    OverrideCursor(false);
                }
                else if(info.Key == ConsoleKey.Enter)
                {
                    flops[position].fliped = true;
                    if (firstPick)
                    {
                        picked = flops[position].rank;
                        Util.ShowFlops(flops);
                        OverrideCursor(true);
                        Util.ShowDialog("前に選んだカードより値が大きければ勝ち。　(←/→: 移動, Enter: 決定)");
                    } else
                    {
                        int secondPick = flops[position].rank;
                        int result = Judge(picked, secondPick);
                        Util.ShowFlops(flops);
                        Util.ShowResult(result);
                    }

                        firstPick = false;
                }
                info = Console.ReadKey(true);
            }

            Console.CursorVisible = true;
        }

        /// <summary>
        /// 勝ち負けの判定
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns>
        /// 0: 引き分け
        /// 1: 勝ち
        /// -1: 負け
        /// </returns>
        static int Judge(int first, int second)
        {
            if(first == second)
                return 0;
            if (second > first)
                return 1;
            else
                return -1;
        }
        static void OverrideCursor(bool increase)
        {
            if (increase)
                position++;
            else
                position--;

            if (position == -1)
                position = 4;

            position = position % 5;
            if (flops[position].fliped)
                if (increase)
                {
                    OverrideCursor(true);
                    return;
                }
                else
                {
                    OverrideCursor(false);
                    return;
                }
            switch(position)
            {
                case 0:
                    Console.SetCursorPosition(0, 1);
                    Console.Write("^          ");
                    break;
                case 1:
                    Console.SetCursorPosition(0, 1);
                    Console.Write("  ^       ");
                    break;
                case 2:
                    Console.SetCursorPosition(0, 1);
                    Console.Write("    ^      ");
                    break;
                case 3:
                    Console.SetCursorPosition(0, 1);
                    Console.Write("      ^   ");
                    break;
                case 4:
                    Console.SetCursorPosition(0, 1);
                    Console.Write("        ^ ");
                    break;
            }
        }
    }
}