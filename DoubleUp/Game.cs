using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleUp
{
    internal class Game : IDisposable
    {
        Random rnd = new Random();
        int position = 2;
        int pickedPos = 0;
        Card[] flops;
        bool firstPick = true;
        bool gameContinue = true;

        public Game()
        {
            flops = Enumerable.Range(0, 5).Select(_ => new Card(rnd.Next(1, 13))).ToArray();
            Console.CursorVisible = false;
        }
        public void Init()
        {
            flops = Enumerable.Range(0, 5).Select(_ => new Card(rnd.Next(1, 13))).ToArray();
            position = 2;
            pickedPos = 0;
            firstPick = true;
        }
        ConsoleKeyInfo info;
        public void MainLoop()
        {
            Util.ShowFlops(flops);

            Console.WriteLine("    ^     ");
            Console.WriteLine("めくるカードを選んでください。　(←/→: 移動, Enter: 決定)");

            info = Console.ReadKey(true);

            if (info.Key == ConsoleKey.RightArrow)
            {
                OverrideCursor(true);
            }
            else if (info.Key == ConsoleKey.LeftArrow)
            {
                OverrideCursor(false);
            }
            else if (info.Key == ConsoleKey.Enter)
            {
                flops[position].fliped = true;
                if (firstPick)
                {
                    pickedPos = flops[position].rank;
                    Util.ShowFlops(flops);
                    OverrideCursor(true);
                    Util.ShowDialog("前に選んだカードより値が大きければ勝ち。　(←/→: 移動, Enter: 決定)");
                }
                else
                {
                    int secondPick = flops[position].rank;
                    int result = Judge(pickedPos, secondPick);
                    Util.ShowFlops(flops);
                    Util.ShowResult(result);
                    gameContinue = Util.AskContinue();
                    return;
                }

                firstPick = false;
            }
            info = Console.ReadKey(true);
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
        int Judge(int first, int second)
        {
            if (first == second)
                return 0;
            if (second > first)
                return 1;
            else
                return -1;
        }
        void OverrideCursor(bool increase)
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
            switch (position)
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
        public void Dispose()
        {
            Console.CursorVisible = true;
        }
    }
}
