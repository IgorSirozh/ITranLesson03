using System;
using System.Collections.Generic;
using System.Text;

namespace RPSGame
{

    public class ResultsTable
    {
        string[] moves;
        int tableSide;
        int decider;
        public string[,] resTable;

        public ResultsTable(string[] moves) 
        {
            this.moves = moves;
            tableSide = moves.Length + 1;
            decider = tableSide / 2 - 1;
            resTable = new string[tableSide, tableSide];
            fillTheTable();
            printTheTable();
        }

        public void fillTheTable()
        {
            WinRule myWinRule = new WinRule();
            resTable[0, 0] = "X";
            for (int i = 1; i < tableSide; i++)
                resTable[i, 0] = resTable[0, i] = moves[i - 1];

            for (int i = 1; i < tableSide; i++)
                for (int j = 1; j < tableSide; j++)
                    resTable[i, j] = myWinRule.decideRPSWinner(decider, i - 1, j - 1);
        }

        public void printTheTable()
        {
            for (int i = 0; i < tableSide; i++)
            {
                for (int j=0;j< tableSide;j++)
                    Console.Write(String.Format("{0,10}", resTable[i, j]));
                Console.WriteLine();
            }
        }
    }
}
