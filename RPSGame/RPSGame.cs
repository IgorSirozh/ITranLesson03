using System;
using System.Collections.Generic;
using System.Text;

namespace RPSGame
{
    public class RPSGame
    {
        public string[] moves;
        public int decider;
        public int pcMove;
        public Byte[] pcMoveHMACKey;
        public Byte[] pcMoveHMACValue;
        public int plMove;
        public RPSGame(string[] moves) 
        {
            correctinput(moves);
            this.moves = moves;
            decider = (moves.Length - 1) / 2;
        }
        public void correctinput(string[] moves)
        {
            if (moves.Length<3)
                throw new Exception("Number of moves must be at least 3");

            if (moves.Length % 2 == 0)
                throw new Exception("Number of moves must be odd");

            for (int i = 0; i < moves.Length - 1; i++)
                for (int j = i + 1; j < moves.Length; j++)
                    if (moves[i].Equals(moves[j]))
                        throw new Exception("the same moves: " + moves[i] + ", use different moves");
        }
        public void startGame()
        {
            generatePCMove();
            Console.WriteLine("HMAC: " + Convert.ToHexString(pcMoveHMACValue));
            Console.WriteLine("Available moves:");
            for (int i = 0; i < moves.Length;)
                Console.WriteLine(++i +" - "+moves[i-1]);
            Console.WriteLine("0 - exit");
            Console.WriteLine("? - help");
            Console.Write("Enter your move: ");
            generatePlMove();
            if (plMove == -1)
                System.Environment.Exit(0);
            Console.WriteLine("Your move: " + moves[plMove]);
            Console.WriteLine("Computer move: " + moves[pcMove]);

            WinRule myWinRule = new WinRule();
            Console.WriteLine("You "+myWinRule.decideRPSWinner(decider, plMove, pcMove));
            Console.WriteLine("HMAC Key: " + Convert.ToHexString(pcMoveHMACKey));
        }
        public void generatePlMove()
        {
            string playersAttempt = Console.ReadLine();
            if (playersAttempt.Equals("?"))
            {
                ResultsTable myResultsTable = new ResultsTable(moves);
                Console.Write("Enter your move: ");
                generatePlMove();
            }
            else
            {
                try 
                {
                    int tPlMove = Int32.Parse(playersAttempt);
                    if ((tPlMove >= 0) && (tPlMove <= moves.Length)) 
                    {
                        plMove = tPlMove-1;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input");
                        Console.Write("Enter your move: ");
                        generatePlMove();
                    }
                }
                catch 
                { 
                    Console.WriteLine("Invalid input");
                    Console.Write("Enter your move: ");
                    generatePlMove();
                }
            }
        }
        public void generatePCMove()
        {
            Random rnd = new Random();
            pcMove = rnd.Next(moves.Length);
            string moooove = moves[pcMove];
            HMACGen myHMACGen = new HMACGen(moooove);
            pcMoveHMACKey = myHMACGen.hmacKey;
            pcMoveHMACValue = myHMACGen.hmacSha2;
        }
    }
}
