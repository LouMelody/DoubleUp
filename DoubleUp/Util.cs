using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleUp
{
    static internal class Util
    {
        public static void ShowFlops(Card[] cards)
        {
            Console.SetCursorPosition(0, 0);
            foreach(var card in cards)
            {
                if (card.fliped)
                    Console.Write(card.MapToRank() + " ");
                else
                    Console.Write("* ");
            }
            Console.WriteLine();
        }

        public static void ShowDialog(string str)
        {
            Console.SetCursorPosition(0, 2);
            Console.WriteLine(str);
        }

        public static void ShowResult(int result)
        {
            Console.SetCursorPosition(0, 3);
            switch(result)
            {
                case 0:
                    Console.WriteLine("引き分けです");
                    break;
                case 1:
                    Console.WriteLine("あなたの勝利です");
                    break;
                case -1:
                    Console.WriteLine("あなたの負けです");
                    break;
            }
        }
        public static bool AskContinue()
        {
            bool invalid = true;
            bool returnValue = false;
            while(invalid)
            {
                Console.SetCursorPosition(0, 4);
                ClearLine();
                Console.Write("もう一度挑戦しますか (y/n):");
                string value = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(value))
                    value = "";
                if (value == "y" || value == "Y")
                {
                    invalid = false;
                    returnValue = true;
                }
                else if (value == "n" || value == "N")
                {
                    invalid = false;
                    returnValue = false;
                }
            }
            return returnValue;
        }
        public static void ClearResult()
        {
            Console.SetCursorPosition(0, 3);
            ClearLine();
            Console.SetCursorPosition(0, 4);
            ClearLine();
        }
        public static void ClearLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }
    }
}
