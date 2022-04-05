using System;

namespace RPSGame
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                RPSGame newGame = new RPSGame(args);
                newGame.startGame();
            }
            catch (Exception e)
            {
                Console.WriteLine("Warning! Error!");
                Console.WriteLine(e.Message);
                Console.WriteLine("Example: Rock Paper Scissors");
            }
        }
    }
}
