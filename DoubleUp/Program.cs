using System;
using System.Linq;
namespace DoubleUp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using(Game game = new Game())
            {
                game.Init();
                game.ShowFirst();
                while(game.gameContinue)
                {
                    if(game.gameReset)
                    {
                        game.Init();
                        game.ShowFirst();
                        Util.ClearResult();
                        game.gameReset = false;
                    }
                    game.MainLoop();
                }
            }
        }
    }
}